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
    }
}
