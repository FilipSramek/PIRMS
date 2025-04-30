using Serial2;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace DataMaker.Drivers
{
    public class Serial : SerialPort
    {
        private readonly Rfc1662 rfc1662 = new();

        // Událost, která předá přijatá data jako seznam double
        public event Action<List<double>> DataPacketReceived;

               /// Inicializace sériového portu
           public void Initialize(string port, int baudRate)
        {
            PortName = port;
            BaudRate = baudRate;

            rfc1662.PacketReceived += Rfc1662_PacketReceived;
            DataReceived += Serial_DataReceived;
        }

            /// Zpracování přijatého paketu (více hodnot typu double)
               private void Rfc1662_PacketReceived(byte[] buffer)
        {
            var values = new List<double>();

            for (int i = 0; i + 8 <= buffer.Length; i += 8)
            {
                double value = BitConverter.ToDouble(buffer, i);
                values.Add(value);
            }

            // Vyvolání události, pokud má někdo zájem o data
            DataPacketReceived?.Invoke(values);
        }

       
        /// Zpracování přijatých dat ze sériového portu (raw byte stream)
       
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int length = BytesToRead;
                byte[] buffer = new byte[length];
                Read(buffer, 0, length);
                rfc1662.PutData(buffer, length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při čtení ze sériového portu: " + ex.Message);
            }
        }

        
        /// Odeslání řetězce přes sériový port zakódovaného poddle RFC1662
        
        public void WriteString(string data)
        {
            try
            {
                if (!IsOpen)
                    Open();

                byte[] buffer = Encoding.ASCII.GetBytes(data);
                byte[] encoded = rfc1662.RemoveSpecialCharacters(buffer);

                Write(new byte[] { Rfc1662.STX }, 0, 1);
                Write(encoded, 0, encoded.Length);
                Write(new byte[] { Rfc1662.STX }, 0, 1);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při zápisu na port: " + ex.Message);
            }
        }
    }
}

