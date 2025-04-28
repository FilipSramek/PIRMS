using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMaker
{
    public class Rfc1662
    {
        public const byte STX = 0x7E;
        public const byte ESC = 0x7D;
        public readonly byte[] ESC_STX = { 0x7D, 0x5E };
        public readonly byte[] ESC_ESC = { 0x7D, 0x5D };

        public Rfc1662()
        {
            m = new MemoryStream();
            writer = new BinaryWriter(m);
        }

        public delegate void DlgPacketReceived(byte[] buffer);
        public event DlgPacketReceived PacketReceived;

        public delegate void DlgPacketError(Exception ex, byte[] buffer);
        public event DlgPacketError PacketError;

        MemoryStream m;
        BinaryWriter writer;

        public void PutData(byte[] data, int length)
        {
            for (int i = 0; i < length; i++)
            {
                byte b = data[i];
                if (b == STX)
                {
                    byte[] buffer = m.ToArray();
                    if (buffer.Length > 0)
                    {
                        bool bufferOK = false;
                        try
                        {
                            buffer = RemoveEscSequences(buffer);
                            bufferOK = true;
                        }
                        catch (Exception ex)
                        {
                            if (this.PacketError != null)
                                this.PacketError(ex, buffer);
                        }

                        if (this.PacketReceived != null && bufferOK)
                            this.PacketReceived(buffer);
                    }
                    m.Dispose();
                    writer.Dispose();
                    m = new MemoryStream();
                    writer = new BinaryWriter(m);
                }
                else
                {
                    writer.Write(b);
                }
            }
        }


        /// <summary>
        /// Decode message from RFC1662 standard
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public byte[] RemoveEscSequences(byte[] buffer)
        {
            using (MemoryStream m = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(m))
                {
                    int length = buffer.Length;
                    for (int i = 0; i < length; i++)
                    {
                        byte b = buffer[i];
                        switch (b)
                        {
                            case ESC:
                                i++;
                                if (buffer[i] == ESC_STX[1])
                                {
                                    writer.Write(STX);
                                }
                                else if (buffer[i] == ESC_ESC[1])
                                {
                                    writer.Write(ESC);
                                }
                                else
                                {
                                    throw new FormatException("RFC1662 Corupted");
                                }

                                break;
                            default:
                                writer.Write(b);
                                break;
                        }
                    }
                }
                return m.ToArray();
            }
        }

        /// <summary>
        /// Code message to RFC1622 standard
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public byte[] RemoveSpecialCharacters(byte[] buffer)
        {
            using (MemoryStream m = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(m))
                {
                    int length = buffer.Length;
                    for (int i = 0; i < length; i++)
                    {
                        byte b = buffer[i];
                        switch (b)
                        {
                            case STX:
                                writer.Write(ESC_STX);
                                break;
                            case ESC:
                                writer.Write(ESC_ESC);
                                break;
                            default:
                                writer.Write(b);
                                break;
                        }
                    }
                }
                return m.ToArray();
            }
        }
    }
}
