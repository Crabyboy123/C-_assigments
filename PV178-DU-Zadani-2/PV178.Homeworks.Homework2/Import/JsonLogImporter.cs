using PV178.Homeworks.Homework2.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PV178.Homeworks.Homework2.Import
{
    public class JsonLogImporter<T> : ILogImporter<T> where T : class, new()
    {
        private ILogStorage logStorage_;

        public JsonLogImporter(ILogStorage logStorage)
        {
            if (logStorage == null)
                throw new ArgumentNullException("LogStorage is null");
            logStorage_ = logStorage;
        }
        public List<T> Import()
        {
            List<T> list = JsonConverter.

        }
    }
}
