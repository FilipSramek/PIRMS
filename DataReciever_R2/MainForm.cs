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
using System.IO.Ports;
using System.Net.NetworkInformation;

namespace DataReciever
{
    public partial class MainForm : Form
    {
        Fft fft = new Fft();

        List<double> signal = new List<double>();
        List<Complex32> complex = new List<Complex32>();
        List<double> magnitudeSpectrum = new List<double>();
        List<double> phaseSpectrum = new List<double>();
        List<Data> dataList = new List<Data>();
        Data data = new Data();
        CsvDriver csv = new CsvDriver();
        CircularQueue<Data> circularQueueData = new CircularQueue<Data>(10000);
        CircularQueue<double> circularQueueVal = new CircularQueue<double>(10000);
        Queue<double> queueVal = new Queue<double>();
        Queue<DateTime> queueTime = new Queue<DateTime>();
        // Move the initialization of the Sender instance to the constructor
        Sender sender;
        bool isRunning = false; // flag to prevent re-entrance
        Drawer ChartTemporal;
        long cycleCounter = 0;

        public MainForm()
        {
            InitializeComponent();
            sender = new Sender(serialPort2);
            ChartTemporal = new Drawer() { chart = chrtTimeSpace };
        
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
            while (this.sender.ReceivedDataQueue.TryDequeue(out Data receivedData))
            {
                //circularQueueData.Enqueue(receivedData);
                circularQueueVal.Enqueue(receivedData.Value);
                data = receivedData;
                queueVal.Enqueue(receivedData.Value);
                queueTime.Enqueue(receivedData.TimeStamp);
                txtDebug.Text = $"Received: {data.Value}\n";
            }
        }

        private async void timer1000_Tick(object sender, EventArgs e)
        {
            if (isRunning) return; // skip if already running

            isRunning = true;
            try
            {
                // Do your async work here
                Drawer ChartPhase = new Drawer { chart = chrtFreqSpacePhase };
                Drawer ChartMagnitude = new Drawer { chart = chrtFreqSpaceMag };

                //signal = circularQueue.ToList().Select(data => data.Value).ToList();
                signal = circularQueueVal.ToList();                                         //2ms

                complex = await fft.GetComplexAsync(signal);                                //1900ms
                magnitudeSpectrum = await fft.GetMagnitudesAsync(complex);                  //450ms
                phaseSpectrum = await fft.GetPhasesAsync(complex);                          //5ms

                await ChartPhase.ClearAsync();                                              //1300ms
                await ChartMagnitude.ClearAsync();                                          //450m

                if (phaseSpectrum != null)
                    await ChartPhase.DrawStaticAsync(10000, phaseSpectrum);                 //105ms

                if (magnitudeSpectrum != null)
                    await ChartMagnitude.DrawStaticAsync(10000, magnitudeSpectrum);         //2700ms
                else
                    txtDebug.Text = "Magnitude spectrum is null.";
            }
            catch (Exception ex)
            {
                txtDebug.Text = $"Error drawing chart: {ex.Message}";
            }
            finally
            {
                isRunning = false; // release lock
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!int.TryParse(cmbBaudRate.SelectedItem?.ToString(), out int baudRate))
                {
                    txtDebug.Text = "Neplatný baud rate.";
                    return;
                }

                string portName = cmbPort.SelectedItem?.ToString();     //Pokud cmbPort.SelectedItem není null, tak se převede na string
                if (string.IsNullOrEmpty(portName))
                {
                txtDebug.Text = "Prosím, vyberte sériový port.";
                return;
                }

                if (serialPort2.IsOpen)
                {
                    txtDebug.Text = "Serial port is already open.";
                    return;
                }

                serialPort2.PortName = portName;
                serialPort2.BaudRate = baudRate;
                serialPort2.Open();

                this.sender.AttachReceiver();

                txtDebug.Text = $"Připojeno k {portName} na rychlosti {baudRate} baud.\n";

                timer1000.Enabled = true;
                timer100.Enabled = true;
                timer1.Enabled = true;
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

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            try
            {
                if (cycleCounter % 2 == 0 && queueVal.Count > 0 && queueTime.Count > 0)
                {
                    double signalVal = queueVal.Dequeue();
                    queueTime.Dequeue();

                    ChartTemporal.DrawDynamic(100, signalVal, cycleCounter / 2);
                }
                else
                {
                    if (queueVal.Count > 0) queueVal.Dequeue();
                    if (queueTime.Count > 0) queueTime.Dequeue();
                }

                cycleCounter++;
            }
            catch
            {
                txtDebug.Text = "Něco se nepovedlo při vykreslování grafu v časové doméně";
            }
        }
    }
}
