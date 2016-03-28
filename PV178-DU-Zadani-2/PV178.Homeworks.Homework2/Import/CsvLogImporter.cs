using PV178.Homeworks.Homework2.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework2.Import
{
    public class CsvLogImporter<T> : ILogImporter<T> where T : class, new()
    {
        private ILogStorage lS;
        private string[] cM;
        private bool hHR;
        private char cD;
        private char tQ;

        public CsvLogImporter(ILogStorage logStorage, string[] columnMappings, bool hasHeaderRow, char columnDelimiter, char textQualifier)
        {
            if (logStorage == null)
                throw new ArgumentNullException("logStorage is null");

            System.Reflection.MemberInfo info = typeof(T);
            


            lS = logStorage;
            cM = columnMappings;
            hHR = hasHeaderRow;
            cD = columnDelimiter;
            tQ = textQualifier;
        }

        public List<T> Import()
        {
            List<T> list = new List<T>();
            string[] csv = lS.Load().Split(new string[]{Environment.NewLine}, StringSplitOptions.None);
            foreach(string line in csv)
            {

            }

        }
    }
}
