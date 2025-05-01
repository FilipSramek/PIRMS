using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataReciever
    {
        class CsvDriver : Serializer
        {
            /// <summary>
            /// Napíše jednu instanci třídy Data do csv souboru
            /// </summary>
            /// <param name="filePath"></param>
            /// <param name="data"></param>
            public void DataToCsv(string filePath, Data data)
            {
                string dataString = this.DataToString(data);
                using (var writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(dataString);
                }
            }

            /// <summary>
            /// Napíše celý List<Data> do csv souboru
            /// </summary>
            /// <param name="filePath"></param>
            /// <param name="data"></param>
            public void ListDataToCsv(string filePath, List<Data> data)
            {
                using (var writer = new StreamWriter(filePath, append: true))
                {
                    foreach (var item in data)
                    {
                        string dataString = this.DataToString(item);
                        writer.WriteLine(dataString);
                    }
                }
            }
            /// <summary>
            /// Přečte data z csv dá je do List<Data>
            /// </summary>
            /// <param name="filePath"></param>
            /// <returns></returns>
            public List<Data> CsvToList(string filePath)
            {
                List<Data> data = new List<Data>();
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        data.Add(this.StringToData(line, ','));
                    }
                }
                return data;
            }
        }
    }


