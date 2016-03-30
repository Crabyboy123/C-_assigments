using PV178.Homeworks.Homework2.Storage;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework2.Import
{
    public class CsvLogImporter<T> : ILogImporter<T> where T : class, new()
    {
        private ILogStorage logStorage_;
        private string[] columnMappings_;
        private bool hasHeaderRow_;
        private char columnDelimiter_;
        private char textQualifier_;

        public CsvLogImporter(ILogStorage logStorage, string[] columnMappings, bool hasHeaderRow, char columnDelimiter, char textQualifier)
        {
            if (logStorage == null)
                throw new ArgumentNullException("logStorage is null");

            logStorage_ = logStorage;
            columnMappings_ = columnMappings;
            hasHeaderRow_ = hasHeaderRow;
            columnDelimiter_ = columnDelimiter;
            textQualifier_ = textQualifier;
        }

        public List<T> Import()
        {
            Type t = typeof(T);
            PropertyInfo[] info = t.GetProperties();
            foreach(var i in info)
            {
                if (columnMappings_.Contains(i.Name))
                    throw new ArgumentException("Property doesn't exist");
            }

            string[] csv = logStorage_.Load().Split(new string[]{Environment.NewLine}, StringSplitOptions.None);
            if (hasHeaderRow_)
                Array.Copy(csv, 1, csv, 0, csv.Length - 1);

            List<T> list = new List<T>();
            foreach (string line in csv)
            {
                int i = 0;
                T obj = new T();
                string[] values = line.Split(columnDelimiter_);
                foreach(var col in columnMappings_)
                {
                    var property = t.GetProperty(col);
                    property.SetValue(obj, values[i]);
                    i++;
                }
                list.Add(obj);
            }
            return list;
        }
    }
}
