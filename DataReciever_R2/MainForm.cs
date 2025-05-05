using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;

namespace DataReciever
{
    public partial class MainForm: Form
    {
        Fft fft = new Fft();

        List<double> signal = new List<double>();
        List<Complex32> complex = new List<Complex32>();
        List<double> magnitudeSpectrum = new List<double>();
        List<double> phaseSpectrum = new List<double>();
        List<Data> dataList = new List<Data>();
        Data data = new Data();
        CsvDriver csv = new CsvDriver();
        // Move the initialization of the Sender instance to the constructor
        Sender senderSerial;


        public MainForm()
        {
            InitializeComponent();
            senderSerial = new Sender(serialPort2);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            signal = csv.CsvToListDouble("C:\\Users\\filip\\SynologyDrive\\VŠB-TUO\\Předměty\\PIRMS - Prostředky implementace řídících a monitorovacích systémů\\Project\\PIRMS\\DataMaker\\data.csv");
            foreach (var value in signal)
            {
                dataList.Add(new Data { TimeStamp = DateTime.Now, Value = value });
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var data in dataList)
            {
                senderSerial.Send(data);
            }           
            Drawer ChartTemporal = new Drawer { chart = chrtTimeSpace };               
            ChartTemporal.DrawDynamic(100, data.Value, signal.Count);
        }

        private void timer1000_Tick(object sender, EventArgs e)
        {            
            Drawer ChartPhase = new Drawer { chart = chrtFreqSpacePhase };
            Drawer ChartMagnitude = new Drawer { chart = chrtFreqSpaceMag };

            complex = fft.GetComplex(signal);
            magnitudeSpectrum = fft.GetMagnitudes(complex); //podle toho co budeme chtít počítat -> fáze nebo magnitudy
            phaseSpectrum = fft.GetPhases(complex);

            ChartPhase.DrawStatic(10000, phaseSpectrum);
            ChartMagnitude.DrawStatic(10000, magnitudeSpectrum);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string portName = txtPort.Text;

                if (!int.TryParse(txtBould.Text, out int baudRate))
                {
                    txtDebug.Text = "Invalid baud rate.";
                    return;
                }

                if (serialPort1.IsOpen)
                {
                    txtDebug.Text = "Serial port is already open.";
                    return;
                }

                serialPort1.PortName = portName;
                serialPort1.BaudRate = baudRate;
                serialPort1.Open();

                serialPort2.PortName = portName;
                serialPort2.BaudRate = baudRate;
                serialPort2.Open();

                txtDebug.Text = $"Connected to {portName} at {baudRate} baud.\n";

                timer100.Enabled = true;
                timer1000.Enabled = true;
            }
            catch (Exception ex)
            {
                txtDebug.Text = $"Error connecting to serial port: {ex.Message}";
            }
        }

        private void OnDataReceived(Data newData)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnDataReceived(newData)));
                return;
            }

            data = newData; // update your shared Data object
            signal.Add(data.Value); // assuming Data has a 'Value' property of type double

            if (signal.Count > 1000) // trim signal to a max size for performance
                signal.RemoveAt(0);

            txtDebug.AppendText($"Received: {data.Value}\n");
        }

    }
}
