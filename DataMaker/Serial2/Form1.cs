using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Serial2.Drivers;
using DataMaker.Drivers;
using System.IO.Ports;

namespace DataMaker
{
    
    public partial class Form1 : Form
    {
        csv csv = new csv();
        int currentIndex = 0;
        ConcurrentQueue<double> data = new ConcurrentQueue<double>();
        Rfc1662 rfc1662 = new Rfc1662();
        public Form1()
        {
            InitializeComponent();
            initSerial("COM10", 9600);
            csv.Load("C:\\Users\\filip\\SynologyDrive\\VŠB-TUO\\Předměty\\PIRMS - Prostředky implementace řídících a monitorovacích systémů\\Project\\PIRMS\\DataMaker\\data.csv");
            rfc1662.PacketReceived += Rfc1662_PacketReceived;
            

        }

        private void Rfc1662_PacketReceived(byte[] buffer)
        {
           double acceleration = BitConverter.ToDouble(buffer, 0);
           data.Enqueue(acceleration);
        }

        private void initSerial(string portName, int baudRate)
        {
            serialPort1.PortName = portName;
            serialPort1.BaudRate = baudRate;
            //serialPort2.PortName = portName;
            //serialPort2.BaudRate = baudRate;
            serialPort1.Open();
            //serialPort2.Open();
        }

        private void serialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while (serialPort2.BytesToRead > 0)
            {
                int length = serialPort2.BytesToRead;
                byte[] buffer = new byte[length];
                serialPort2.Read(buffer, 0, length);
                rfc1662.PutData(buffer, length);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            while (data.Count > 0)
            {
                bool ok = data.TryDequeue(out double acceleration);
                if (ok)
                {
                    // mám data v acceleration
                    chart1.Series[0].Points.AddY(acceleration); 
                }
            }
        }

        private void Send(double acc)
        {
            byte [] buffer = BitConverter.GetBytes(acc);
            byte[] encoded = rfc1662.RemoveSpecialCharacters(buffer);
            serialPort1.Write(new byte[] { Rfc1662.STX },0,1);
            serialPort1.Write(encoded,0,encoded.Length);
            serialPort1.Write(new byte[] { Rfc1662.STX }, 0, 1);
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            
            
            if (currentIndex < csv.Data.Count)
            {
                double valueToSend = csv.Data[currentIndex];
                Send(valueToSend);
                currentIndex++;
            }
            else
            {
                timer2.Stop(); // All data sent, stop the timer
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
