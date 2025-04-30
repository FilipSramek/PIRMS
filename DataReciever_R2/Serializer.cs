using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReciever
{
    class Serializer
    {
        /// <summary>
        /// Serializuje objekt Data do pole bajtů
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] DataToByte(Data data)
        {
            using (var ms = new MemoryStream())
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write(data.TimeStamp.ToBinary());
                writer.Write(data.Value);
                return ms.ToArray();
            }
        }



        /// <summary>
        /// Deserializuje pole bajtů do objektu Data
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public Data ByteToData(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            using (var reader = new BinaryReader(ms))
            {
                long timeBinary = reader.ReadInt64();
                double value = reader.ReadDouble();
                return new Data
                {
                    TimeStamp = DateTime.FromBinary(timeBinary),
                    Value = value
                };
            }
        }



        /// <summary>
        /// Serializuje objekt Data do stringu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string DataToString(Data data)
        {
            return $"{data.TimeStamp},{data.Value}";
        }



        /// <summary>
        /// Deserializuje string (podle zadaného oddělovače) do objektu Data 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public Data StringToData(string str,char separator)
        {
            string[] parts = str.Split(separator);
            return new Data
            {
                TimeStamp = DateTime.Parse(parts[0]),
                Value = double.Parse(parts[1])
            };
        }
    }
}
