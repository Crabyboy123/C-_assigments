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
            if (startsWith == null)
                throw new ArgumentNullException("StartsWith is null");

            return bookListLoader_.LoadList()
                    .Where( x => x.CourseCode.ToLower().StartsWith(startsWith.ToLower()))
                    .Select(x => x.CourseCode + x.Course).ToList();
        }

        public IEnumerable<string> ListAreas()
        {
            return bookListLoader_.LoadList().Select(x => x.Area)
                   .Distinct(StringComparer.CurrentCultureIgnoreCase);    
        }

        public IEnumerable<Tuple<string, int>> ListTeachers()
        {
            return bookListLoader_.LoadList()
                   .Select(x => x.Teacher)
                   .Count()
                   .GroupBy();
        }

        public string[] CoursesWithoutBook()
        {
            return bookListLoader_.LoadList()
                .Where(x => x.Book == null)
                .Select(x => x.Course)
                //.GroupBy(x => x)
                .ToArray();
        }

        public bool AreAllBooksBuyable(string area)
        {
            if (area == null)
                throw new ArgumentNullException("Area is null");
            return bookListLoader_.LoadList()
                .Where(x => x.Area.ToLower().Equals(area.ToLower()))
                .All(x => x.New != null);
        }

        public bool IsAnyBookOfBookRentable(string area)
        {
            if (area == null)
                throw new ArgumentNullException("Area is null");
            return bookListLoader_.LoadList()
                .Where(x => x.Area.ToLower().Equals(area.ToLower()))
                .Any(x => x.Rent != null);
        }


        public int CountRentableBooks()
        {
            return bookListLoader_.LoadList()
                .Count(x => x.Rent != null);
        }

        public int GetRoundedAveragePriceOfNewBook()
        {
            return (int)Math.Round((double)(bookListLoader_.LoadList()
                .Where(x => x.New != null)
                .Select(x => x.New)
                .Average()));
        }

        public string GetFirstBookForCourse(string courseCode)
        {
            if (courseCode == null)
                throw new ArgumentNullException("CourseCose is null");
            if (String.IsNullOrWhiteSpace(courseCode))
                throw new ArgumentException("CourseCode is empty or whitespace");
            return bookListLoader_.LoadList()
                .Where(x => x.CourseCode.ToLower().Equals(courseCode.ToLower()))
                .Select(x => x.Book)
                .FirstOrDefault();
        }

        public IEnumerable<Tuple<string, string>> ListAllCoursesWithArea()
        {
            
        }

        public IDictionary<string, string> ListAllCoursesWithAreaAsDictionary()
        {
            
        }

        public IEnumerable<Tuple<string, IEnumerable<string>>> ListTeachersAndCoursesWithoutBook()
        {
            return bookListLoader_.LoadList()
                                   .Where(x => x.Book == null)
                                   .Select(x => Tuple.Create(x.Teacher, bookListLoader_.LoadList().Where(y => y.Teacher.Equals(x.Teacher)).Select(y => y.Course));
        }

        public IEnumerable<Tuple<string, int>> ListBookCountPerCourseUsingJoin(params string[] codes)
        {
            
        }

        public IEnumerable<string> ListCoursesWithMostExpensiveBook()
        {

        }

        public IEnumerable<string> ListThreeMostExpensiveBooks(IEnumerable<string> areas)
        {
            throw new NotImplementedException();
        }
    }
}
