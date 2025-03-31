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
            string port = txtPort.Text;
            int.TryParse(txtBoud.Text, out int boudRate);

            Serial serial = new Serial();
            serial.Initialize(port, boudRate);

            txtSetConfig.Text = serial.ToString();
        }
    }
}