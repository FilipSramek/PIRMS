using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace Project.Drivers
{
    /// <summary>
    /// Object that holds the data from the sensor
    /// </summary>
    public class SensorData
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public double Value { get; set; }

        
        public override string ToString()
        {
            return $"ID: {Id}, Time: {Time}, Value: {Value}"; //override ToString to return the things that are relevant to me
        }

        /// <summary>
        /// Serializes the SensorData object to json file
        /// </summary>
        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
        
        /// <summary>
        /// Deserializes the data from json file to SensorData object
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public SensorData Deserialize(string data)
        {
            return JsonSerializer.Deserialize<SensorData>(data);
        }

        /// <summary>
        /// Saves the data to a json file
        /// </summary>
        /// <param name="path">.json must be included</param>
        public void SaveToFile(string path)
        {
            File.WriteAllText(path, this.Serialize());
        }
    }
}
