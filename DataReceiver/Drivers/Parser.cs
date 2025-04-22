using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Markup;
using static Project.Drivers.Serial;

namespace Project.Drivers
{
    //TO-DO:Implement serial port data parser  FINISHED
    //      Implement serial port data buffer
    //      Write a actual data format to parser

    /// <summary>
    /// Parser for the sensor data, child of SensorData
    /// </summary>
    public class Parser : SensorData
    {
        public override string ToString()
        {
            return $"ID: {Id}, Time: {Time}, Value: {Value}"; //override ToString to return the things that are relevant to me
        }

        /// <summary>
        /// Parses the data from the sensor
        /// </summary>
        /// <param name="data"></param>
        /// <param name="devider"></param>
        /// <returns>parsed data as a object SensorData</returns>
        public SensorData ParseData(string data, char devider)
        {
            // Data format: id~time~value, multiple messages separated by ETX (0x03)
            
            string[] messages = data.Split((char)0x03);
            SensorData result = null;

            for (int i = 0; i < messages.Length; i++)
            {
                string message = messages[i].Trim();
                if (string.IsNullOrWhiteSpace(message)) continue;

                message = message.TrimStart((char)0x02); // Remove STX if present
                string[] part = message.Split(devider);

                if (part.Length >= 3)
                {
                    int.TryParse(part[0], out int id);
                    DateTime.TryParse(part[1], out DateTime time);
                    double.TryParse(part[2], out double value);

                    result = new SensorData { Id = id, Time = time, Value = value };
                }
            }

            return result;
        }
    }
}
