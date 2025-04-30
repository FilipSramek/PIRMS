using System;
using System.Collections.Generic;
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
        /// Draw chart from whole list<double> at ones
        /// </summary>
        /// <param name="windowSize"></param>
        /// <param name="Spectrum"></param>
        public void DrawStatic(int windowSize, List<double> Spectrum)
        {
            chart.ChartAreas[0].AxisX.Minimum = windowSize;
            chart.ChartAreas[0].AxisX.Maximum = 0;

            for (int i = 0; i < Spectrum.Count; i++)
            {
                chart.Series[0].Points.AddXY(i, Spectrum[i]);
            }
        }
        /// <summary>
        /// Draw the chart incrementally with each double that comes in
        /// </summary>
        /// <param name="windowSize"></param>
        /// <param name="signal"></param>
        /// <param name="time"></param>
        public void DrawDynamic(int windowSize, double signal, long time = 0)
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

        public void Clear()
        {
            chart.Series[0].Points.Clear();
        }
    }
}
