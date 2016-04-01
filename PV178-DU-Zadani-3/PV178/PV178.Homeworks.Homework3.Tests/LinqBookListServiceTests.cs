using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PV178.Homeworks.Homework3.Tests
{
    [TestClass]
    public class LinqBookListServiceTests
    {
        IBookListLoader loader;
        Mock<IBookListLoader> loaderMock;
        IBookListService service;

        [TestInitialize]
        public void TestSetup()
        {
            loaderMock = new Mock<IBookListLoader>();
            loaderMock.Setup(p => p.LoadList()).Returns(JsonConvert.DeserializeObject<IEnumerable<BookListRecord>>(TestData.TestData1));
            loader = loaderMock.Object;

            service = new LinqBookListService(loader);
        }

        [TestMethod]
        public void ListCoursesByFirstLetterOfCode_PassValidParameter_ReturnsValidResults()
        {
            var results = service.ListCoursesByFirstLetterOfCode("Ba2");
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("BA224:Principles of Management", results.First());

            results = service.ListCoursesByFirstLetterOfCode("SO202");
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("SO202:Minorities in the US", results.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ListCoursesByFirstLetterOfCode_PassInvalidParameter_ThrowsException()
        {
            service.ListCoursesByFirstLetterOfCode(null);
        }

        [TestMethod]
        public void ListAreas_ReturnsValidResults()
        {
            var results = service.ListAreas();
            IEnumerable<string> expectedResults = JsonConvert.DeserializeObject<IEnumerable<string>>(TestData.Results_ListAreas);

            Assert.AreEqual(18, results.Count());
            Assert.AreEqual(true, results.OrderBy(p => p).SequenceEqual(expectedResults.OrderBy(p => p)));
        }

        [TestMethod]
        public void ListTeachers_ReturnsValidResults()
        {
            var results = service.ListTeachers();
            IEnumerable<Tuple<string, int>> expectedResults = JsonConvert.DeserializeObject<IEnumerable<Tuple<string, int>>>(TestData.Results_ListTeachers);
            Assert.AreEqual(52, expectedResults.Count());
            Assert.AreEqual(true, results.OrderBy(p=>p.Item1).SequenceEqual(expectedResults.OrderBy(p => p.Item1)));
        }

        [TestMethod]
        public void CoursesWithoutBook_ReturnsValidResults()
        {
            var results = service.CoursesWithoutBook();
            string[] expectedResults = JsonConvert.DeserializeObject<string[]>(TestData.Results_CoursesWithoutBook);
            Assert.AreEqual(19, expectedResults.Count());
            Assert.AreEqual(true, results.OrderBy(p => p).SequenceEqual(expectedResults.OrderBy(p => p)));
        }

        [TestMethod]
        public void AreAllBooksBuyable_BuyableMiexd_ReturnsBuyable()
        {
            bool result = service.AreAllBooksBuyable("Modern Languages");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AreAllBooksBuyable_BuyableUsed_ReturnsBuyable()
        {
            bool result = service.AreAllBooksBuyable("Mathematics");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AreAllBooksBuyable_NotAllCoursesHaveBookAllBuyable_ReturnsBuyable()
        {
            bool result = service.AreAllBooksBuyable("Technology");
            Assert.AreEqual(true, result);
        }
        
        [TestMethod]
        public void AreAllBooksBuyable_NotAllCoursesHaveBookSomeRentOnly_ReturnsNotBuyable()
        {
            bool result = service.AreAllBooksBuyable("Business Administration");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsAnyBookOfBookRentable_AreaWithSomeRentableBooks_ReturnsAnyRentable()
        {
            bool result = service.IsAnyBookOfBookRentable("Art");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsAnyBookOfBookRentable_AreaWithoutAnyRentableBooks_ReturnsNotAnyRentable()
        {
            bool result = service.IsAnyBookOfBookRentable("Communication");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CountRentableBooks_ReturnsValidResults()
        {
            int result = service.CountRentableBooks();
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void GetRoundedAveragePriceOfNewBook_ReturnsValidResults()
        {
            int result = service.GetRoundedAveragePriceOfNewBook();
            Assert.AreEqual(76, result);
        }

        [TestMethod]
        public void GetRoundedAveragePriceOfNewBook_EmptyListOfBooks_ReturnsValidResults()
        {
            loaderMock = new Mock<IBookListLoader>();
            loaderMock.Setup(p => p.LoadList()).Returns(new List<BookListRecord>());
            loader = loaderMock.Object;

            service = new LinqBookListService(loader);
            int result = service.GetRoundedAveragePriceOfNewBook();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetFirstBookForCourse_PassedCodeOfExistentCourse_ReturnsValidResults()
        {
            string result = service.GetFirstBookForCourse("TE141");
            Assert.AreEqual("Auto Fundamentals", result);
        }

        [TestMethod]
        public void GetFirstBookForCourse_PassedCodeOfExistentCourseWithoutBook_ReturnsValidResults()
        {
            string result = service.GetFirstBookForCourse("PA150");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetFirstBookForCourse_PassedCodeOfNonExistentCourse_ReturnsValidResults()
        {
            string result = service.GetFirstBookForCourse("TE142");
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFirstBookForCourse_PassedNullArgument_ExceptionThrown()
        {
            string result = service.GetFirstBookForCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFirstBookForCourse_PassedEmptyStringArgument_ExceptionThrown()
        {
            string result = service.GetFirstBookForCourse("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFirstBookForCourse_PassedWhiteSpaceStringArgument_ExceptionThrown()
        {
            string result = service.GetFirstBookForCourse(" ");
        }

        [TestMethod]
        public void ListAllCoursesWithArea_ReturnsValidResults()
        {
            var results = service.ListAllCoursesWithArea();
            IEnumerable<Tuple<string, string>> expectedResults = JsonConvert.DeserializeObject<IEnumerable<Tuple<string, string>>>(TestData.Results_ListAllCoursesWithArea);
            Assert.AreEqual(135, expectedResults.Count());
            Assert.AreEqual(true, results.OrderBy(p => p.Item1).SequenceEqual(expectedResults.OrderBy(p => p.Item1)));
        }

        [TestMethod]
        public void ListAllCoursesWithAreaAsDictionary_ReturnsValidResults()
        {
            var results = service.ListAllCoursesWithAreaAsDictionary();
            IDictionary<string, string> expectedResults = JsonConvert.DeserializeObject<IEnumerable<Tuple<string, string>>>(TestData.Results_ListAllCoursesWithArea).ToDictionary(p => p.Item1, o => o.Item2);
            Assert.AreEqual(135, expectedResults.Count());
            Assert.AreEqual(true, expectedResults.Keys.SequenceEqual(results.Keys));
            foreach (var key in results.Keys)
            {
                Assert.AreEqual(expectedResults[key], results[key]);
            }
        }

        [TestMethod]
        public void ListTeachersAndCoursesWithoutBook_ReturnsValidResults()
        {
            var results = service.ListTeachersAndCoursesWithoutBook();
            IEnumerable<Tuple<string, IEnumerable<string>>> expectedResults = JsonConvert.DeserializeObject<IEnumerable<Tuple<string, IEnumerable<string>>>>(TestData.Results_ListTeachersAndCoursesWithoutBook);
            Assert.AreEqual(52, expectedResults.Count());
            foreach (var item in results)
            {
                Assert.AreEqual(true, item.Item2.OrderBy(p => p).SequenceEqual(expectedResults.Single(p => p.Item1 == item.Item1).Item2.OrderBy(p => p)));
            }
            //Assert.AreEqual(true, results.OrderBy(p => p.Item1).SequenceEqual(expectedResults.OrderBy(p => p.Item1)));
        }

        [TestMethod]
        public void ListBookCountPerCourseUsingJoin_ReturnsValidResults()
        {
            var results = service.ListBookCountPerCourseUsingJoin(new string[] { "ML209", "EN111A", "BA326" });
            IEnumerable<Tuple<string, int>> expectedResults = JsonConvert.DeserializeObject<IEnumerable<Tuple<string, int>>>(TestData.Results_ListBookCountPerCourseUsingJoin);
            Assert.AreEqual(3, expectedResults.Count());
            Assert.AreEqual(true, results.OrderBy(p => p.Item1).SequenceEqual(expectedResults.OrderBy(p => p.Item1)));
        }

        [TestMethod]
        public void ListCoursesWithMostExpensiveBook_ReturnsValidResults()
        {
            var results = service.ListCoursesWithMostExpensiveBook();
            IEnumerable<string> expectedResults = JsonConvert.DeserializeObject<IEnumerable<string>>(TestData.Results_ListCoursesWithMostExpensiveBook);
            Assert.AreEqual(2, expectedResults.Count());
            Assert.AreEqual(true, results.OrderBy(p => p).SequenceEqual(expectedResults.OrderBy(p => p)));
        }

        [TestMethod]
        public void ListThreeMostExpensiveBooks_PassedCoursesWithMostExpensiveAcrossNewAndUsed_ReturnsValidResults()
        {
            var results = service.ListThreeMostExpensiveBooks(new List<string>() { "Curriculum & Instruction", "English" });
            IEnumerable<string> expectedResults = JsonConvert.DeserializeObject<IEnumerable<string>>(TestData.Results_ListThreeMostExpensiveBooks);
            Assert.AreEqual(3, expectedResults.Count());
            Assert.AreEqual(true, results.OrderBy(p => p).SequenceEqual(expectedResults.OrderBy(p => p)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ListThreeMostExpensiveBooks_PassedNullParameter_ExceptionThrown()
        {
            var results = service.ListThreeMostExpensiveBooks(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ListThreeMostExpensiveBooks_PassedCollectionContainsNull_ExceptionThrown()
        {
            var results = service.ListThreeMostExpensiveBooks(new List<string>() { "English", null });
        }
    }
}
