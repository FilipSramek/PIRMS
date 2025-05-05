using DataMaker_r3;
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

namespace DataMaker_R3
{
    public partial class MainForm: Form
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
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Data data in dataList) // Takhle to být nemůže v tomto programu protože by to úplně zastavilo zbytek programu (v tom druhém to, ale takto být může)
            {
                this.sender.Send(data);         //TOTO MUSÍME OPRAVIT PROTOŽE PROGRAM DELÁ TOTO A NIC JINÉHO BĚHEM TOHO
                txtDebug.Text = data.ToString();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                /*string portName = txtPort.Text;
                
                if (!int.TryParse(txtBould.Text, out int baudRate))
                {
                    txtDebug.Text = "Invalid baud rate.";
                    return;
                }

                if (serialPort1.IsOpen)
                {
                    txtDebug.Text = "Serial port is already open.";
                    return;
                }*/

                serialPort1.PortName = "COM10";   //upravit na portName
                serialPort1.BaudRate = 921600;   //upravit na boudRate
                serialPort1.Open();
                //start timer 
                timer1.Start();

                this.sender.AttachReceiver();

                txtDebug.Text = /*$*/"Connected to {portName} at {baudRate} baud.\n";



                signal = csv.CsvToListDouble("C:\\Users\\filip\\SynologyDrive\\VŠB-TUO\\Předměty\\PIRMS - Prostředky implementace řídících a monitorovacích systémů\\Project\\PIRMS\\DataMaker\\data.csv");
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
    }
}
