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

namespace DataReciever
{
    public partial class MainForm: Form
    {
        FFT fft = new FFT();

        List<double> signal = new List<double>();
        List<double> magnitudeSpectrum = new List<double>();
        List<double> phaseSpectrum = new List<double>();
        Data data = new Data();


        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Drawer ChartTemporal = new Drawer { chart = chrtTimeSpace };
                
            ChartPhase.DrawDynamic(100, data.Value, signal.Count);
        }

        private void timer1000_Tick(object sender, EventArgs e)
        {
            Drawer ChartPhase = new Drawer { chart = chrtFreqSpacePhase };
            Drawer ChartMagnitude = new Drawer { chart = chrtFreqSpaceMag };

            magnitudeSpectrum = fft.GetMagnitudes(signal); //podle toho co budeme chtít počítat -> fáze nebo magnitudy
            phaseSpectrum = fft.GetPhases(signal);

            ChartPhase.DrawStatic(100, phaseSpectrum);
            ChartMagnitude.DrawStatic(100, magnitudeSpectrum);
        }     
    }
}
