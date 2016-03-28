using PV178.Homeworks.Homework2.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework2.Import
{
    public class JsonLogImporter<T> : ILogImporter<T> where T : class, new()
    {
        public JsonLogImporter(ILogStorage logStorage)
        {

        }
        public List<T> Import()
        {
            throw new NotImplementedException();
        }
    }
}
