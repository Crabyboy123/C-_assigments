using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework2.Storage
{
    public interface ILogStorage
    {
        string Load();
        void Save(string content);
    }
}
