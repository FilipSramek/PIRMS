using Project.Drivers;
using Serial2;
using System;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    public partial class MainForm : Form
    {

        private Chart chart;
        Serial serial = new Serial();
        ConcurrentQueue<double> data = new ConcurrentQueue<double>();
        Rfc1662 rfc1662 = new Rfc1662();

        public MainForm()
        {
            InitializeComponent();
            rfc1662.PacketReceived += Rfc1662_PacketReceived;
            serial.Initialize("COM10", 9600);
        }

        private void Rfc1662_PacketReceived(byte[] buffer)
        {
            double acceleration = BitConverter.ToDouble(buffer, 0);
            data.Enqueue(acceleration);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSetConfig_Click(object sender, EventArgs e)
        {
            string port = cmbBoxPort.Text;
            int.TryParse(cmbBoxBoud.Text, out int boudRate);
            
            txtDebug.Text = serial.ToString();
            
            if (!serial.IsOpen)
            {
                serial.Open();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timerZeroPointOneHz_Tick(object sender, EventArgs e)
        {
            
        }
        public void PutData(byte[] data, int length)
        {
            
        }
    }
}