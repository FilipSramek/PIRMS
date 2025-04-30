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
        public override string ToString()
        {
            return base.ToString();
        }
        public static byte[] ToByte(Data data)
        {
            using (var ms = new MemoryStream())
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write(data.TimeStamp.ToBinary());
                writer.Write(data.Value);
                return ms.ToArray();
            }
        }

        public static Data ToData(byte[] bytes)
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
    }
}
