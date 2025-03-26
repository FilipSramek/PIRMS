using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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
        /// <summary>
        /// Parses the data from the sensor
        /// </summary>
        /// <param name="data"></param>
        /// <param name="devider"></param>
        /// <returns>parsed data as a object SensorData</returns>
        public SensorData ParseData(string data, char devider)
        {                                                                   //data format: id#time#value...

            string[] part = data.Split(devider);                            //splits the data into array of strings based on the devider


            int.TryParse(part[0], out int id);
            DateTime.TryParse(part[1], out DateTime time);
            double.TryParse(part[2], out double value);

            //xxx.TryParse(part[i], out xxx xxx);                           //fill i acording to the position in full data 

            return new SensorData { Id = id, Time = time, Value = value };  //returns the parsed data as a new instance of object 
        }

        public override string ToString()
        {
            return $"ID: {Id}, Time: {Time}, Value: {Value}"; //override ToString to return the things that are relevant to me
        }
    }
}
