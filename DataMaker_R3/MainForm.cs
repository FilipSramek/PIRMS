using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
using System.IO;
using DataReciever;

namespace DataMaker_R3
{
    public partial class MainForm : Form
    {
        List<double> signal = new List<double>();
        List<Complex32> complex = new List<Complex32>();
        List<double> magnitudeSpectrum = new List<double>();
        List<double> phaseSpectrum = new List<double>();
        List<Data> dataList = new List<Data>();
        Data data = new Data();
        CsvDriver csv = new CsvDriver();
        // Move the initialization of the Sender instance to the constructor
        Sender sender;

        public MainForm()
        {
            InitializeComponent();
            sender = new Sender(serialPort1);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cmbPort.Items.AddRange(ports);
            if (ports.Length > 0) cmbPort.SelectedIndex = 0;

            int[] baudRates = { 9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600 };

            foreach (var rate in baudRates)
                cmbBaudRate.Items.Add(rate.ToString());
            cmbBaudRate.SelectedItem = "921600";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Data data in dataList) // Takhle to být nemůže v tomto programu protože by to úplně zastavilo zbytek programu (v tom druhém to, ale takto být může)
            {
                this.sender.Send(data);         //TOTO MUSÍME OPRAVIT PROTOŽE PROGRAM DELÁ TOTO A NIC JINÉHO BĚHEM TOHO
                txtDebug.Text = data.ToString();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string portName = cmbPort.SelectedItem?.ToString();
                if (!int.TryParse(cmbBaudRate.SelectedItem?.ToString(), out int baudRate))
                {
                    txtDebug.Text = "Neplatný baud rate.";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFilePath.Text) || !File.Exists(txtFilePath.Text))
                {
                    txtDebug.Text = "Vyber validní CSV soubor.";
                    return;
                }

                serialPort1.PortName = portName;
                serialPort1.BaudRate = baudRate;
                serialPort1.Open();
                timer1.Start();

                this.sender.AttachReceiver();

                txtDebug.Text = /*$*/"Connected to {portName} at {baudRate} baud.\n";

                signal = csv.CsvToListDouble(txtFilePath.Text);
                foreach (var value in signal) //Umělé generování dat tak, aby byla vždy přiřazena jedna časová značka
                {
                    dataList.Add(new Data { TimeStamp = DateTime.Now, Value = value });
                }

                txtDebug.Text = "Data from csv was downloded\n";
            }
            catch (Exception ex)
            {
                txtDebug.Text = $"Error connecting to serial port: {ex.Message}";
            }
        }
        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = dialog.FileName;
            }
        }
    }
}
