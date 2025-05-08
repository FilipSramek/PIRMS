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
        public async Task DrawStaticAsync(int windowSize, List<double> spectrum)
        {
            try
            {
                await Task.Run(() =>
                {
                    chart.Invoke((Action)(() =>
                    {
                        chart.ChartAreas[0].AxisX.Minimum = 0;
                        chart.ChartAreas[0].AxisX.Maximum = windowSize;
                        chart.ChartAreas[0].AxisY.ScaleView.Zoom(1, 10000000);
                        foreach (var series in chart.Series)
                        {
                            series.Points.Clear();
                        }
                        for (int i = 0; i < spectrum.Count; i++)
                        {
                            chart.Series[0].Points.AddXY(i, spectrum[i]);
                        }
                    }));
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DrawStaticAsync: {ex.Message}");
            }
        }

        /// <summary>
        /// Postupné vykreslování grafu s postupně chodícími data
        /// </summary>
        /// <param name="windowSize"></param>
        /// <param name="signal"></param>
        /// <param name="time"></param>
        public async Task DrawDynamicAsync(int windowSize, double signal, long time)
        {
            try
            {
                await Task.Run(() =>
                {
                    chart.Invoke((Action)(() =>
                    {
                        time++;
                        if (time > windowSize)
                        {
                            chart.ChartAreas[0].AxisX.Minimum = time - windowSize;
                            chart.ChartAreas[0].AxisX.Maximum = time;
                        }

                        chart.Series[0].Points.AddXY(time, signal);

                        while (chart.Series[0].Points[0].XValue < time - windowSize)
                        {
                            chart.Series[0].Points.RemoveAt(0);
                        }
                    }));
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DrawDynamicAsync: {ex.Message}");
            }
        }

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

                chart.Series[0].Points.AddXY(time, signal);

                while (chart.Series[0].Points[0].XValue < time - windowSize)
                {
                    chart.Series[0].Points.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DrawDynamicAsync: {ex.Message}");
            }
        }

        /// <summary>
        /// Vymaže včechny body v grafu (důležité udělat před zápisem dalších čísel do grafu jinak bude nekonečný)
        /// </summary>
        public async Task ClearAsync()
        {
            await Task.Run(() =>
            {
                chart.Invoke((Action)(() =>
                {
                    chart.Series[0].Points.Clear();
                }));
            });
        }

        public void Clear()
        {      
           chart.Series[0].Points.Clear();
        }
    }
}
