using DataMaker;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataMaker.Drivers
{
    class Serial:SerialPort
    {
        int currentIndex = 0;
        ConcurrentQueue<double> data = new ConcurrentQueue<double>();
        Rfc1662 rfc1662 = new Rfc1662();

        public void init(string portName, int baudRate)
        {
            rfc1662.PacketReceived += Rfc1662_PacketReceived;
            this.PortName = portName;
            this.BaudRate = baudRate;
            this.DataBits = 8;
            this.Parity = Parity.None;
            this.StopBits = StopBits.One;
            this.Handshake = Handshake.None;
            this.ReadTimeout = 500;
            this.WriteTimeout = 500;
            this.Open();
        }

        private void initSerial(string portName, int baudRate)
        {
            serialPort1.PortName = portName;
            serialPort1.BaudRate = baudRate;
            serialPort2.PortName = portName;
            serialPort2.BaudRate = baudRate;
            serialPort1.Open();
            serialPort2.Open();
        }

        private void Rfc1662_PacketReceived(byte[] buffer)
        {
            double acceleration = BitConverter.ToDouble(buffer, 0);
            data.Enqueue(acceleration);
        }

        private void serialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while (this.BytesToRead > 0)
            {
                int length = this.BytesToRead;
                byte[] buffer = new byte[length];
                this.Read(buffer, 0, length);
                rfc1662.PutData(buffer, length);
            }
        }

        public double dataPoint()
        {
            while (data.Count > 0)
            {
                bool ok = data.TryDequeue(out double acceleration);
                return acceleration;
            }
            return 0;
        }

        public void Send(double acc)
        {
            byte[] buffer = BitConverter.GetBytes(acc);
            byte[] encoded = rfc1662.RemoveSpecialCharacters(buffer);
            this.Write(new byte[] { Rfc1662.STX }, 0, 1);
            this.Write(encoded, 0, encoded.Length);
            this.Write(new byte[] { Rfc1662.STX }, 0, 1);
        }
    }
}
