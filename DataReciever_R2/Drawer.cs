using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DataReciever
{
    class Drawer
    {
        public Chart chart { get; set; }

        public override string ToString()
        {
            return "Drawer";
        }

        /// <summary>
        /// Nakreslí celý graf z jednoho list<double>
        /// </summary>
        /// <param name="windowSize"></param>
        /// <param name="Spectrum"></param>
        public void DrawStatic(int windowSize, List<double> spectrum)
        {
            try
            {
                chart.ChartAreas[0].AxisX.Minimum = 0;
                chart.ChartAreas[0].AxisX.Maximum = windowSize;
                chart.ChartAreas[0].AxisY.ScaleView.Zoom(1, 10000000);
                for (int i = 0; i < spectrum.Count; i++)
                {
                    chart.Series[0].Points.AddXY(i, spectrum[i]);
                }
            }
            catch (Exception ex)
            {
                //implementuj exeption handeling
            }
            
        }
        /// <summary>
        /// Postupné vykreslování grafu s postupně chodícími data
        /// </summary>
        /// <param name="windowSize"></param>
        /// <param name="signal"></param>
        /// <param name="time"></param>
        public void DrawDynamic(int windowSize, double signal, long time)
        {
            try
            {
                time++;
                if (time > windowSize)
                {
                    chart.ChartAreas[0].AxisX.Minimum = time - windowSize;
                    chart.ChartAreas[0].AxisX.Maximum = time;
                }

                // Check if the chart and series are properly initialized
                if (chart == null)
                {
                    throw new InvalidOperationException("Chart is not initialized.");
                }

                if (chart.Series.Count == 0)
                {
                    throw new InvalidOperationException("No series found in the chart.");
                }

                chart.Series[0].Points.AddXY(time, signal);

                while (chart.Series[0].Points[0].XValue < time - windowSize)
                {
                    chart.Series[0].Points.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                // Log the exception to help debug the issue
                Console.WriteLine($"Error in DrawDynamic: {ex.Message}");
            }
        }
        /// <summary>
        /// Vymaže včechny body v grafu (důležité udělat před zápisem dalších čísel do grafu jinak bude nekonečný)
        /// </summary>
        public void Clear()
        {
            chart.Series[0].Points.Clear();
        }
    }
}
