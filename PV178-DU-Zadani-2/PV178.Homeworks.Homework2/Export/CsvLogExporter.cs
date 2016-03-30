using PV178.Homeworks.Homework2.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework2.Export
{
    public class CsvLogExporter<T> : ILogExporter<T> where T : class, new()
    {
        private ILogStorage logStorage_;
        private string[] columnMappings_;
        private bool hasHeaderRow_;
        private char columnDelimiter_;
        private char textQualifier_;

        public CsvLogExporter(ILogStorage logStorage, string[] columnMappings, bool hasHeaderRow, char columnDelimiter, char textQualifier)
        {
            if (logStorage == null)
                throw new ArgumentNullException("logStorage is null");

            logStorage_ = logStorage;
            columnMappings_ = columnMappings;
            hasHeaderRow_ = hasHeaderRow;
            columnDelimiter_ = columnDelimiter;
            textQualifier_ = textQualifier;
        }
        public void Export(List<T> data)
        {
            string output = "";
            if (hasHeaderRow_)
            {
                foreach (string col in columnMappings_)
                    output += col + columnDelimiter_;
                output.Remove(output.Length - 1, 1);
                output += "\r\n";
            }

            foreach(T d in data)
            {
                d
            }

            logStorage_.Save(output);
        }
    }
}
