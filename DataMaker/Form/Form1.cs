using DataMaker.Drivers;

namespace DataMaker
{
    public partial class Form1 : Form
    {
        Serial serial = new Serial();
        public Form1()
        {
            InitializeComponent();
            serial.Initialize("COM1", 1000000); //implemet serial port selector
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                serial.WriteData(i);
            }
        }
    }
}
