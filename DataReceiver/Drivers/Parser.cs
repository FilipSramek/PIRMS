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
        {                                                                   //data format: id#time#value...
            string[] messages = data.Split((char)0x03);
            data = messages[messages.Length - 1];
            
            for (int i = 0; i < messages.Length - 1; i++)
            {
                string message = messages[i].TrimStart((char)0x02);
                string[] part = message.Split('~');
                
                
                int.TryParse(part[0], out int id);
                DateTime.TryParse(part[1], out DateTime time);
                double.TryParse(part[2], out double value);
                //xxx.TryParse(part[i], out xxx xxx);

                return new SensorData { Id = id, Time = time, Value = value };  //returns the parsed data as a new instance of object
                //fill i acording to the position in full data
            }



            

                                        

             
        }
        
    }
}
