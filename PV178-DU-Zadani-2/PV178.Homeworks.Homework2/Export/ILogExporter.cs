using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework2.Export
{
    public interface ILogExporter<T> where T : class, new()
    {
        void Export(List<T> data);
    }
}
