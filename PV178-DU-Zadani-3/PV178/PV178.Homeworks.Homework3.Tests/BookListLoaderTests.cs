using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;

namespace PV178.Homeworks.Homework3.Tests
{
    [TestClass]
    public class BookListLoaderTests
    {
        [TestMethod]
        public void LoadList_PassedValidFilePathToData_ReturnsBooksCollection()
        {
            string executionFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string dataPath = (new Uri(Path.Combine(executionFolder, "Data\\data.txt.gz"))).LocalPath;
            IBookListLoader loader = new BookListLoader(dataPath);
            var books = loader.LoadList();

            Assert.AreEqual(TestData.TestData1, JsonConvert.SerializeObject(books));
        }
    }
}
