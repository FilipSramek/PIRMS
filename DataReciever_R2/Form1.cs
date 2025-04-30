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
    public partial class Form1: Form
    {
        List<double> signal = new List<double>();
        FFT fft = new FFT();
        List<double> magnitudeSpectrum = new List<double>();
        List<double> phaseSpectrum = new List<double>();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawChartTimeSpace(100);
        }

        private void timer1000_Tick(object sender, EventArgs e)
        {
            magnitudeSpectrum = fft.GetMagnitudes(signal); //podle toho co budeme chtít počítat -> fáze nebo magnitudy
            phaseSpectrum = fft.GetPhases(signal);

            DrawChartMagnitudeSpertum(100);
            DrawChartPhaseSpectrum(100);

        }

        private void DrawChartMagnitudeSpertum(int windowSize)
        {
            chrtFreqSpaceMag.ChartAreas[0].AxisX.Minimum = windowSize;
            chrtFreqSpaceMag.ChartAreas[0].AxisX.Maximum = 0;

            for (int i = 0; i < magnitudeSpectrum.Count; i++)
            {
                chrtFreqSpaceMag.Series[0].Points.AddXY(i, magnitudeSpectrum[i]);
            }
        }

        private void DrawChartPhaseSpectrum(int windowSize)
        {          
            chrtFreqSpacePhase.ChartAreas[0].AxisX.Minimum = windowSize;
            chrtFreqSpacePhase.ChartAreas[0].AxisX.Maximum = 0;

            for (int i = 0; i < phaseSpectrum.Count; i++)
            {
                chrtFreqSpacePhase.Series[0].Points.AddXY(i, phaseSpectrum[i]);
            }
        }

        private void DrawChartTimeSpace(int windowSize)
        {
            double x = 0;

            if (x > windowSize)
            {
                chrtTimeSpace.ChartAreas[0].AxisX.Minimum = x - windowSize;
                chrtTimeSpace.ChartAreas[0].AxisX.Maximum = x;
            }

            foreach (var y in signal)
            {
                chrtTimeSpace.Series[0].Points.AddXY(x, y);
            }

            while (chrtTimeSpace.Series[0].Points[0].XValue < x - windowSize)
            {
                chrtTimeSpace.Series[0].Points.RemoveAt(0);
            }
            x++;
        }
    }
}
