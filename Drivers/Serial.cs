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
        private SerialPort serial;

        //TO-DO:Implement serial port selector
        //      Implement serial port bouldrate selector

        public void Initialize(string port, int bouldRate)
        {
            serial = new SerialPort(port, bouldRate);
            serial.Open();
        }

        public string ReadData()
        {
            if (serial == null || !serial.IsOpen)
            {
                throw new InvalidOperationException("Serial port is not initialized or open.");
            }

            return serial.ReadLine();
        }
    }
}
