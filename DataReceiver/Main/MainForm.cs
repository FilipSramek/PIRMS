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

        }

        private void btnSetConfig_Click(object sender, EventArgs e)
        {
            string port = cmbBoxPort.Text;
            int.TryParse(cmbBoxBoud.Text, out int boudRate);

            Serial serial = new Serial();
            serial.Initialize(port, boudRate);

            txtSetConfig.Text = serial.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timerZeroPointOneHz_Tick(object sender, EventArgs e)
        {

        }
    }
}