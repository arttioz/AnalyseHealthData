using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnalyseHealthData
{
    public static class Utils
    {
        public static Dictionary<string, int> setupDataDic(String headerLine)
        {

            Dictionary<string, int> dataDicIndex = new Dictionary<string, int>();
            string[] dataDic = headerLine.Split(',');

            for (int i = 0; i < dataDic.Length; i++)
            {
                string key = dataDic[i];

                dataDicIndex.Add(key, i);

            }

            return dataDicIndex;
        }

        

        public static String getVal(String key, string[] data, Dictionary<string, int> dataDic)
        {

            return data[dataDic[key]].Trim();
        }

        public static Encoding GetEncoding(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;

            using (var reader = new System.IO.StreamReader(filename, true))
            {
                var currentEncoding = reader.CurrentEncoding;

                if(currentEncoding == Encoding.UTF8)
                    return Encoding.UTF8; 
            }


            return System.Text.Encoding.GetEncoding(874);
        }
    }
}
