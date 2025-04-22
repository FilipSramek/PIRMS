using Serial2;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace Project.Drivers
{
    class Serial : SerialPort
    {
        ConcurrentQueue<double> data = new ConcurrentQueue<double>();
        Rfc1662 rfc1662 = new Rfc1662();

        /// <summary>
        /// Writes information about serial port
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Port: {this.PortName}; BouldRate: {this.BaudRate}";
        }

        /// <summary>
        /// Initialize serial port
        /// </summary>
        /// <param name="port"></param>
        /// <param name="bouldRate"></param>
        public void Initialize(string port, int bouldRate)
        {
            try 
            {
                this.PortName = port;
                this.BaudRate = bouldRate;

                rfc1662.PacketReceived += Rfc1662_PacketReceived;
            }

            catch (Exception e)
            {
                //TO - DO: Implement error handling
            }
        }


        /// <summary>
        /// Decodes message from RFC1662 standard
        /// </summary>
        /// <param name="buffer"></param>
        private void Rfc1662_PacketReceived(byte[] buffer)
        {
            double acceleration = BitConverter.ToDouble(buffer, 0);
            data.Enqueue(acceleration);
        }

        /// <summary>
        /// Read data from serial port
        /// </summary>
        /// <returns>String with data</returns>
        public void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while (this.BytesToRead > 0)
            {
                int length = this.BytesToRead;
                byte[] buffer = new byte[length];
                this.Read(buffer, 0, length);
                rfc1662.PutData(buffer, length);
            }
        }


        /// <summary>
        /// Write data to serial port
        /// </summary>
        /// <param name="Data"></param>
        public void WriteData(double Data)
        {
            try
            {
                if (!this.IsOpen)
                {
                    this.Open();
                }
                byte[] buffer = BitConverter.GetBytes(Data);
                byte[] encoded = rfc1662.RemoveSpecialCharacters(buffer);
                this.Write(new byte[] { Rfc1662.STX }, 0, 1);
                this.Write(encoded, 0, encoded.Length);
                this.Write(new byte[] { Rfc1662.STX }, 0, 1);
                this.Close();
            }
            catch (Exception e)
            {
                //TO - DO: Implement error handling
            }
        }
    }
}

