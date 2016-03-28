using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PV178.Homeworks.Homework2.Storage
{
    public class TextFileLogStorage : ILogStorage
    {
        private StreamReader sr;
        private StreamWriter sw;

        public TextFileLogStorage(string fileName)
        {
            sr = new StreamReader(fileName);
            sw = new StreamWriter(fileName, false);
        }
        public string Load()
        {
            return sr.ReadToEnd();
        }

        public void Save(string content)
        {
            sw.Write(content);
        }
    }
}
