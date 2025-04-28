using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Serial2.Drivers
{
    public class csv
    {
        public List<double> Data = new List<double>();
        public void Load(string filePath)
        {
            Data.Clear(); // Clear any previous data
            int validLinesCount = 0;

            foreach (var line in File.ReadAllLines(filePath))
            {
                // Trim spaces and check if the line is not empty
                string trimmedLine = line.Trim();
                if (string.IsNullOrEmpty(trimmedLine))
                    continue; // Skip empty lines

                // Try parsing the number
                if (double.TryParse(trimmedLine, out double value))
                {
                    Data.Add(value);
                    validLinesCount++;
                }
            }

            // Optionally display a message box with the number of valid entries
            MessageBox.Show($"Loaded {validLinesCount} valid numbers from the CSV.");
        }
    }
}
