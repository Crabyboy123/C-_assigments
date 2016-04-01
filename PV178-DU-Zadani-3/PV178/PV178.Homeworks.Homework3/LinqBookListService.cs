using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework3
{
    public class LinqBookListService : IBookListService
    {
        private IBookListLoader bookListLoader_;
        public LinqBookListService(IBookListLoader bookListLoader)
        {
            if (bookListLoader == null)
                throw new ArgumentNullException("Books are null");
            bookListLoader_ = bookListLoader;
        }

        public IList<string> ListCoursesByFirstLetterOfCode(string startsWith)
        {
            return bookListLoader_.LoadList().;
        }

        public IEnumerable<string> ListAreas()
        {
            
        }

        public IEnumerable<Tuple<string, int>> ListTeachers()
        {
            throw new NotImplementedException();
        }

        public string[] CoursesWithoutBook()
        {
            throw new NotImplementedException();
        }

        public bool AreAllBooksBuyable(string area)
        {
            throw new NotImplementedException();
        }

        public bool IsAnyBookOfBookRentable(string area)
        {
            throw new NotImplementedException();
        }

        public int CountRentableBooks()
        {
            throw new NotImplementedException();
        }

        public int GetRoundedAveragePriceOfNewBook()
        {
            throw new NotImplementedException();
        }

        public string GetFirstBookForCourse(string courseCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<string, string>> ListAllCoursesWithArea()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, string> ListAllCoursesWithAreaAsDictionary()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<string, IEnumerable<string>>> ListTeachersAndCoursesWithoutBook()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tuple<string, int>> ListBookCountPerCourseUsingJoin(params string[] codes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ListCoursesWithMostExpensiveBook()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ListThreeMostExpensiveBooks(IEnumerable<string> areas)
        {
            throw new NotImplementedException();
        }
    }
}
