using DataMaker.Drivers;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using DataMaker;
using System.Globalization;

namespace DataMaker
{
    public partial class Form1 : Form
    {


        Serial serial = new Serial();
        private List<(int Id, double Time, double Value1, double Value2)> dataToSend = new();
        private int currentIndex = 0;
       

        public Form1()
        {
            InitializeComponent();
            serial.Initialize("COM10", 115200); // Port a baudrate si mùžeme upravit
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Získání dostupných COM portù
            comboBoxPort.Items.AddRange(SerialPort.GetPortNames());

            comboBoxPort.Items.Add("TEST1");

            // Naplnìní standardních hodnot baud rate

            comboBoxBaud.Items.Add("9600");
            comboBoxBaud.Items.Add("19200");
            comboBoxBaud.Items.Add("38400");
            comboBoxBaud.Items.Add("57600");
            comboBoxBaud.Items.Add("115200");

            // Nastavení výchozího výbìru
            if (comboBoxPort.Items.Count > 0)
                comboBoxPort.SelectedIndex = 0;

            comboBoxBaud.SelectedItem = "115200";

            // Naètení posledních vybraných hodnot
            if (!string.IsNullOrEmpty(Settings.Default.LastPort) && comboBoxPort.Items.Contains(Settings.Default.LastPort))
            {
                comboBoxPort.SelectedItem = Settings.Default.LastPort;
            }

            if (!string.IsNullOrEmpty(Settings.Default.LastBaud) && comboBoxBaud.Items.Contains(Settings.Default.LastBaud))
            {
                comboBoxBaud.SelectedItem = Settings.Default.LastBaud;
            }
        }

        private void btnLoadCsv_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV files (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadCsv(ofd.FileName);
                MessageBox.Show("CSV naèteno.");
            }

        }

        private async void btnStartSending_Click(object sender, EventArgs e)
        {
            await StartSending();
            if (dataToSend.Count == 0)
            {
                MessageBox.Show("Nejdøív naèti CSV soubor.");
                return;
            }

            StartSending();
        }

        private void LoadCsv(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            dataToSend.Clear();
            int idCounter = 0;

            // --- Pøeskoèíme hlavièku a jedeme po skuteèných datech
            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');
                // Èekáme pøesnì 4 sloupce: Id, Time, Value_Hlava, Value_Vlnovod
                if (parts.Length < 4)
                    continue;

                // Parsujeme ID (int) a tøi double pomocí InvariantCulture
                if (int.TryParse(parts[0], NumberStyles.Integer,
                                 CultureInfo.InvariantCulture, out int id) &&
                    double.TryParse(parts[1], NumberStyles.Float,
                                    CultureInfo.InvariantCulture, out double time) &&
                    double.TryParse(parts[2], NumberStyles.Float,
                                    CultureInfo.InvariantCulture, out double value1) &&
                    double.TryParse(parts[3], NumberStyles.Float,
                                    CultureInfo.InvariantCulture, out double value2))
                {
                    // Ukládáme do seznamu
                    dataToSend.Add((idCounter++, time, value1, value2));
                }
            }

            MessageBox.Show($"CSV naèteno. Platných vzorkù: {dataToSend.Count}",
                            "Naètení dokonèeno", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
        private List<List<string>> ChunkData(List<string> data, int size)  //metoda na rozdìlení velkého seznamu na menší èásti
        {
            var chunks = new List<List<string>>();
            for (int i = 0; i < data.Count; i += size)
            {
                chunks.Add(data.Skip(i).Take(size).ToList());
            }
            return chunks;
        }

        private async Task StartSending()
        {
            if (!serial.IsOpen)
            {
                try
                {
                    serial.Open();
                
                catch (Exception ex)
                {
                    MessageBox.Show("Nepodaøilo se otevøít port: " + ex.Message);
                    return;
                }
            }

            var stringData = dataToSend.Select(item => $"#{item.Id}#{item.Time}#{item.Value1}#{item.Value2}#").ToList();
            var chunks = ChunkData(stringData, 100);

            foreach (var chunk in chunks)
            {
                foreach (var line in chunk)
                {
                    serial.WriteString(line);  
                    await Task.Delay(100);      // Pauza mezi jednotlivými øádky
                }

                await Task.Delay(500);          // Pauza mezi bloky (100 øádkù)
            }

            MessageBox.Show("Všechna data byla odeslána.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonInitSerial_Click(object sender, EventArgs e)
        {
            if (comboBoxPort.SelectedItem == null || comboBoxBaud.SelectedItem == null)
            {
                MessageBox.Show("Vyber port a rychlost.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string port = comboBoxPort.SelectedItem.ToString();
            int baudRate = int.Parse(comboBoxBaud.SelectedItem.ToString());

            // Uložení nastavení
            Settings.Default.LastPort = port;
            Settings.Default.LastBaud = baudRate.ToString();
            Settings.Default.Save();

            try
            {
                serial.Initialize(port, baudRate);
                MessageBox.Show("Port inicializován", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba pøi inicializaci: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

