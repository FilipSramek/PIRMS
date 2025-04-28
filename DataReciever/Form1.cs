using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataReciever
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1000_Tick(object sender, EventArgs e)
        {
            var fft = new FFT();
            List<double> signal = new List<double>();
            List<double> spectrum = fft.ComputeMagnitude(signal);
        }
    }
}
