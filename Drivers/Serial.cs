using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project.Drivers
{
    class Serial
    {
        SerialPort serial = new SerialPort();

        //TO-DO:Implement serial port selector
        //      Implement serial port bouldrate 


        /// <summary>
        /// Initialize serial port
        /// </summary>
        /// <param name="port"></param>
        /// <param name="bouldRate"></param>
        public void Initialize(string port, int bouldRate)
        {
            serial.PortName = port;
            serial.BaudRate = bouldRate;
        }

        /// <summary>
        /// Read data from serial port
        /// </summary>
        /// <returns>String with data</returns>
        public string ReadData()
        {
            string data = serial.ReadExisting(); 
            return data;
        }
        
    }
}
