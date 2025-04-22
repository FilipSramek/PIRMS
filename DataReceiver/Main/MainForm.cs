using Project.Drivers;
using Serial2;
using System.Collections.Concurrent;
using System.IO.Ports;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    public partial class MainForm : Form
    {
        Serial serial = new Serial();
        Rfc1662 rfc1662 = new Rfc1662();
        ConcurrentQueue<SensorData> data = new ConcurrentQueue<SensorData>();
        public MainForm()
        {
            InitializeComponent();
            rfc1662.PacketReceived += Rfc1662_PacketReceived;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSetConfig_Click(object sender, EventArgs e)
        {
            string port = cmbBoxPort.Text;
            int.TryParse(cmbBoxBoud.Text, out int boudRate);
            serial.Initialize(port, boudRate);
            txtDebug.Text = serial.ToString();
            if (!serial.IsOpen)
            {
                serial.Open();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
















        private void Rfc1662_PacketReceived(byte[] buffer)
        {
            SensorData sensorData = new SensorData();
            sensorData.Value = BitConverter.ToDouble(buffer, 0);
            data.Enqueue(sensorData);
            txtDebug.Text = sensorData.ToString();
        }

        private void serialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while (serial.BytesToRead > 0)
            {
                int length = serial.BytesToRead;
                byte[] buffer = new byte[length];
                serial.Read(buffer, 0, length);
                rfc1662.PutData(buffer, length);
            }
        }


        private void timerZeroPointOneHz_Tick(object sender, EventArgs e)
        {
            while (data.Count > 0)
            {
                SensorData Data = new SensorData();  
                bool ok = data.TryDequeue(out Data);
                if (ok)
                {
                    listView2.Items.Clear();
                    foreach (var item in data)
                    {
                        ListViewItem listViewItem = new ListViewItem(item.ToString());
                        listView2.Items.Add(listViewItem);
                    }
                } 
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}