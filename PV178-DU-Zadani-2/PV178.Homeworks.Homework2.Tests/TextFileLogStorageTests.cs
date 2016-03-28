using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using PV178.Homeworks.Homework2.Storage;

namespace PV178.Homeworks.Homework2.Tests
{
    [TestClass]
    public class TextFileLogStorageTests
    {
        const string SINGLE_LINE_STRING = "sample text";
        const string SINGLE_LINE_STRING_2 = "sample text 2";

        [TestMethod]
        public void SaveAndLoad_ValidFileNameSingleLineString_TextCorrectlySavedAndLoaded()
        {
            var logStorage = new TextFileLogStorage(Path.Combine(Path.GetTempPath(), "test.txt"));
            logStorage.Save(SINGLE_LINE_STRING);

            var logStorage2 = new TextFileLogStorage(Path.Combine(Path.GetTempPath(), "test.txt"));
            var content = logStorage2.Load();
            Assert.AreEqual(SINGLE_LINE_STRING, content);
        }

        [TestMethod]
        public void SaveAndLoad_ValidFileNameMultiLineString_TextCorrectlySavedAndLoaded()
        {
            var logStorage = new TextFileLogStorage(Path.Combine(Path.GetTempPath(), "test.txt"));
            logStorage.Save(SampleData.SQLServerFormatLog);

            var logStorage2 = new TextFileLogStorage(Path.Combine(Path.GetTempPath(), "test.txt"));
            var content = logStorage2.Load();
            Assert.AreEqual(SampleData.SQLServerFormatLog, content);
        }

        [TestMethod]
        public void SaveAndLoad_ExistingFile_FileOverwritten()
        {
            var logStorage = new TextFileLogStorage(Path.Combine(Path.GetTempPath(), "test.txt"));
            logStorage.Save(SINGLE_LINE_STRING);

            var logStorage2 = new TextFileLogStorage(Path.Combine(Path.GetTempPath(), "test.txt"));
            logStorage.Save(SINGLE_LINE_STRING_2);

            var logStorage3 = new TextFileLogStorage(Path.Combine(Path.GetTempPath(), "test.txt"));
            var content = logStorage3.Load();
            Assert.AreEqual(SINGLE_LINE_STRING_2, content);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_PassEmptyStringAsFileName_ArgumentNullException()
        {
            var logStorage = new TextFileLogStorage("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveAndLoad_PassNullAsFileName_ArgumentNullException()
        {
            var logStorage = new TextFileLogStorage(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Save_PassNullAsContent_ArgumentNullException()
        {
            var logStorage = new TextFileLogStorage(Path.Combine(Path.GetTempPath(), "test.txt"));
            logStorage.Save(null);
        }

        [TestMethod]
        public void SaveAndLoad_EmptyContent_NoExceptionThrown()
        {
            var logStorage = new TextFileLogStorage(Path.Combine(Path.GetTempPath(), "test.txt"));
            logStorage.Save("");

            var logStorage2 = new TextFileLogStorage(Path.Combine(Path.GetTempPath(), "test.txt"));
            var content = logStorage2.Load();
            Assert.AreEqual("", content);
        }
    }
}
