using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project.Drivers
{
    class Serial : SerialPort
    {
        public override string ToString()
        {
            return $"Port: {this.PortName}; BouldRate: {this.BaudRate}";
        }

        /// <summary>
        /// Initialize serial port
        /// </summary>
        /// <param name="port"></param>
        /// <param name="bouldRate"></param>
        public void Initialize(string port, int bouldRate)
        {
            this.PortName = port;
            this.BaudRate = bouldRate;
        }

        /// <summary>
        /// Read data from serial port
        /// </summary>
        /// <returns>String with data</returns>
        public string ReadData()
        {
            string data = this.ReadExisting(); 
            return data;
        }      
    }
}
