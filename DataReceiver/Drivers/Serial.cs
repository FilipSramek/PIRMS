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
        string buffer = string.Empty;

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
            try
            {
                if (!this.IsOpen)
                {
                    return "Error - Port not open";
                }

                if (this.BytesToRead == 0)
                {
                    return "Error - No massage found";
                }

                buffer += this.ReadExisting();

                return buffer;

            }
            catch (Exception e)
            {
                //TO - DO: Implement error handling
                return $"Error - Exception: {e.Message}";
            }
        }
    }
}
