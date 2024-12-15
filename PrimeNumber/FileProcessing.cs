using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
    internal class FileProcessing
    {
        //string path = "PrimeNumber.txt";

        public static void SaveToFileTxt(long number, string value, string path = "PrimeNumber.txt")//запись в текстовый файл
        {
            string str = "";
            str = $"{number} - {value}";            
            
            
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(str);
            }
        }

        public static void LoadFile()
        {


        }
    }
}
