using Project.Drivers;

namespace Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Correct and put this code to seral port selector
            
            Serial serial = new Project.Drivers.Serial();

            serial.Initialize("COM1", 9600);
        }
    }
}