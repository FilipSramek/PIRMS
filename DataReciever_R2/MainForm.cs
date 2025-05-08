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
            timer1000.Enabled = true;
            timer100.Enabled = true;
            timer1.Enabled = true;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            
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
                signal = circularQueueVal.ToList();

                complex = await fft.GetComplexAsync(signal);
                magnitudeSpectrum = fft.GetMagnitudes(complex);
                phaseSpectrum = fft.GetPhases(complex);

                ChartPhase.Clear();
                ChartMagnitude.Clear();

                if (phaseSpectrum != null)
                    ChartPhase.DrawStatic(10000, phaseSpectrum);

                if (magnitudeSpectrum != null)
                    ChartMagnitude.DrawStatic(10000, magnitudeSpectrum);
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
                string portName = txtPort.Text;

                /*if (!int.TryParse(txtBould.Text, out int baudRate)) //je důležité odkomentovat na to aby fungovalu uživatelské rozhraní
                {
                    txtDebug.Text = "Invalid baud rate.";
                    return;
                }*/

                if (serialPort1.IsOpen)
                {
                    txtDebug.Text = "Serial port is already open.";
                    return;
                }
                
                serialPort2.PortName = "COM10";   //nahraď portName a boudRate z textBoxu, jen jsem si ulehčil debugobání
                serialPort2.BaudRate = 921600;
                serialPort2.Open();

                this.sender.AttachReceiver();

                txtDebug.Text = $"Connected to {portName} at {921600} baud.\n";
                                
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

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    // Skip every other value by using a counter
                    if (cycleCounter % 2 == 0 && queueVal.Count > 0 && queueTime.Count > 0)
                    {
                        double signalVal = queueVal.Dequeue();
                        queueTime.Dequeue(); // Discard the time value since it's no longer needed

                        // Safely update the chart on the UI thread
                        this.Invoke((Action)(() =>
                        {
                            ChartTemporal.DrawDynamic(1000, signalVal, cycleCounter / 2); // Use cycleCounter/2 as the x-value
                        }));
                    }
                    else
                    {
                        // Skip the current value
                        if (queueVal.Count > 0) queueVal.Dequeue();
                        if (queueTime.Count > 0) queueTime.Dequeue();
                    }

                    cycleCounter++; // Increment the counter
                }
                catch
                {
                    this.Invoke((Action)(() =>
                    {
                        txtDebug.Text = "Něco se nepovedlo při vykreslování grafu v časové doméně";
                    }));
                }
            });
        }
    }
}
