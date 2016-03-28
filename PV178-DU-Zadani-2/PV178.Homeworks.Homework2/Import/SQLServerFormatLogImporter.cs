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
        public SQLServerFormatLogImporter(ILogStorage logStorage)
        {

        }
        public List<SQLServerLogEvent> Import()
        {
            throw new NotImplementedException();
        }
    }
}
