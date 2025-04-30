using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReciever
{
    class Data
    {
        public DateTime TimeStamp { get; set; }
        public double Value { get; set; }

        public override string ToString()
        {
            return $"TimeStamp: {TimeStamp}, Value: {Value}";
        }
    }
}
