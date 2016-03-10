using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string COMPANY_NAME = "FI MUNI";
            var b = new ResidentialBuilding(COMPANY_NAME);
            World w = new World(50, 50);
            w.Build(new Coordinates(10, 10), b);
            Console.WriteLine(b);
            Console.Read();

        }
    }
}
