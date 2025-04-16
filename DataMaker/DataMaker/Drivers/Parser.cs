using Project.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMaker.Drivers
{
    class Parser
    {
        public override string ToString()
        {
            return "#Id#Time#Value#";
        }
        public static string ToSend(SensorData data)
        {
            return $"{data.Id};{data.Time};{data.Value}";
        }
    }
}
