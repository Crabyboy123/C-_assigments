using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework3
{
    // TODO: Implementujte datový typ BookListRecord, aby reprezentoval vstupní data.
    //       Formát vstupních dat:
    //       CourseCode;Teacher;Area;Course;Book;Edition;Author;Ibsn;New;Used;Rent
    //       AR202;Conyers;Art;Painting II: Watercolor;Everything You Ever Wanted to Know;;;0-82305649x;26;;
    //       AR203;Zerger;Art;Photography;Photography;10;Upton;0-205711499;133;;58
    //       AR210;Zerger;Art;Drawing II;Drawing Manual Vilppu;2;Vilppu;1-892053039;44;;
    //       AR230;Erwy-Shr;Art;Graphic Design I;;;;;;;
    // 
    public class BookListRecord
    {
        public string CourseCode { get; set; }

        public string Teacher { get; set; }
        
        public string Area { get; set; }

        public string Course { get; set; }
        
        public string Book { get; set; }
        
        public int? Edition { get; set; }
        
        public string Author { get; set; }
        
        // Překlep, ale neopravoval jsem protože byl i v zadání a dodaných datech
        public string Ibsn { get; set; }
        
        public int? New { get; set; }
        
        public int? Used { get; set; }

        public int? Rent { get; set; }
    }
}
