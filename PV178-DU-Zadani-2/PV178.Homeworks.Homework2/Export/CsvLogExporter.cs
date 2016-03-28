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
        public CsvLogExporter(ILogStorage logStorage, string[] columnMappings, bool hasHeaderRow, char columnDelimiter, char textQualifier)
        {

        }
        public void Export(List<T> data)
        {
            throw new NotImplementedException();
        }
    }
}
