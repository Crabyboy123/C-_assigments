using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework2.Import
{
    public interface ILogImporter<T> where T : class, new()
    {
        List<T> Import();
    }
}
