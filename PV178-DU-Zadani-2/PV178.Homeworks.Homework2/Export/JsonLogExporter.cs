using PV178.Homeworks.Homework2.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework2.Export
{
    public class JsonLogExporter<T> : ILogExporter<T> where T : class, new()
    {
        public JsonLogExporter(ILogStorage logStorage)
        {

        }
        public void Export(List<T> data)
        {
            throw new NotImplementedException();
        }
    }
}
