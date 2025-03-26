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
        public class Data
        {
            int id;
            double time;
            double value;
        }

        Data data = new Data();
        SerialPort serial = new SerialPort();

        //TO-DO:Implement serial port selector
        //      Implement serial port bouldrate selector

        public void Initialize(string port, int bouldRate)
        {

            serial.PortName = port;
            serial.BaudRate = bouldRate;    
            serial.Open();
        }

        public string ReadData()
        {
            string data = serial.ReadLine();

            return data;
        }
        public bool ReadParseData(string data)
        {
            

            return true;
            
            
        }
        private void ParseData()
        {
            //TO-DO: Implement data parsing

        }
    }
}
