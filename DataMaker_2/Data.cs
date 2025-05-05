using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMaker
{
    /// <summary>
    /// Třída na ukládání proměnných
    /// </summary>
    public class Data
    {

        public DateTime TimeStamp { get; set; }
        public double Value { get; set; }

        public Data AddTimeStemp(List<double> signal)
        {
            foreach (var value in signal)
            {
                this.Value = value;
                this.TimeStamp = DateTime.Now;
            }
            
            TimeStamp = DateTime.Now;
            return this;
        }

        public override string ToString()
        {
            return $"TimeStamp: {TimeStamp}, Value: {Value}";
        }
    }
}
