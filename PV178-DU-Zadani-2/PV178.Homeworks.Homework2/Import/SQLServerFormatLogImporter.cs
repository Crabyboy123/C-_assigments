using PV178.Homeworks.Homework2.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PV178.Homeworks.Homework2.Entities;

namespace PV178.Homeworks.Homework2.Import
{
    public class SQLServerFormatLogImporter : ILogImporter<SQLServerLogEvent>
    {
        private ILogStorage logStorage_;
        public SQLServerFormatLogImporter(ILogStorage logStorage)
        {
            if (logStorage == null)
                throw new ArgumentNullException("LogStorage is null");
            logStorage_ = logStorage;
        }

        public List<SQLServerLogEvent> Import()
        {
            
        }
    }
}
