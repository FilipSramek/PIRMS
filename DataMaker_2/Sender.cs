using System;
using System.Collections;
using System.Collections.Concurrent;
using System.IO.Ports; // kvůli SerialPort
using System.Windows.Forms;
using DataReciever;

namespace DataMaker
{
    public class Sender
    {
        private readonly SerialPort port;
        private readonly Rfc1662 rfc;
        private readonly Serializer serializer;

        public ConcurrentQueue<Data> ReceivedDataQueue = new ConcurrentQueue<Data>();

        public Sender(SerialPort serialPort)
        {
            port = serialPort;
            rfc = new Rfc1662();
            serializer = new Serializer();

            rfc.PacketReceived += Rfc_PacketReceived;
        }

        // Odešle objekt Data přes sériový port s RFC1662 rámcem
        public void Send(Data data)
        {
            byte[] raw = serializer.DataToByte(data);
            byte[] encoded = rfc.RemoveSpecialCharacters(raw);
            port.Write(new byte[] { Rfc1662.STX }, 0, 1);
            port.Write(encoded, 0, encoded.Length);
            port.Write(new byte[] { Rfc1662.STX }, 0, 1); // konec paketu
        }

        // Aktivuje příjem dat ze sériového portu a dekódování pomocí RFC1662
        public void AttachReceiver()
        {
            port.DataReceived += Port_DataReceived;
        }

        // Čte přijatá data a předává je do dekodéru RFC1662
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (port.BytesToRead > 0)
            {
                int length = port.BytesToRead;
                byte[] buffer = new byte[length];
                port.Read(buffer, 0, length);
                rfc.PutData(buffer, length);
            } // čeká na data
        }

        // Zpracuje kompletní dekódovaný paket a převádí ho zpět na objekt Data
        private void Rfc_PacketReceived(byte[] buffer)
        {
            Data data = new Data();
            data = serializer.ByteToData(buffer);
            ReceivedDataQueue.Enqueue(data); // Používáme nový název fronty
        }
    }
}