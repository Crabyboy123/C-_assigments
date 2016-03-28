using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Newtonsoft.Json;
using PV178.Homeworks.Homework2.Storage;
using PV178.Homeworks.Homework2.Import;
using PV178.Homeworks.Homework2.Entities;

namespace PV178.Homeworks.Homework2.Tests
{
    [TestClass]
    public class CsvLogImporterTests
    {
        public ILogStorage MockStorage(string returns)
        {
            var storageMock = new Mock<ILogStorage>();
            storageMock.Setup(p => p.Load()).Returns(returns);
            return storageMock.Object;
        }

        [TestMethod]
        public void Import_PassValidCSVWithoutHeaderRow_ReturnsCorrectResults()
        {
            ILogImporter<SQLServerLogEvent> importer = new CsvLogImporter<SQLServerLogEvent>(MockStorage(SampleData.CsvFormatLog), new string[] { "EventTime", "ServerName", "ErrorNumber", "ErrorSeverity", "DatabaseName", "ErrorMessage" }, false, ';', '"');
            var exportedData = JsonConvert.DeserializeObject<List<SQLServerLogEvent>>(SampleData.JsonFormatLog);

            var result = importer.Import();

            Assert.AreEqual(SampleData.JsonFormatLog, JsonConvert.SerializeObject(result));
        }

        [TestMethod]
        public void Import_PassValidCSVWithoutHeaderRow2_ReturnsCorrectResults()
        {
            ILogImporter<SQLServerLogEvent> importer = new CsvLogImporter<SQLServerLogEvent>(MockStorage(SampleData.CsvFormatLog2), new string[] { "ErrorNumber", "EventTime", "ServerName", "ErrorSeverity", "DatabaseName", "ErrorMessage" }, false, ';', '"');
            var exportedData = JsonConvert.DeserializeObject<List<SQLServerLogEvent>>(SampleData.JsonFormatLog);

            var result = importer.Import();

            Assert.AreEqual(SampleData.JsonFormatLog, JsonConvert.SerializeObject(result));
        }

        [TestMethod]
        public void Import_PassValidCSVWithHeaderRow_ReturnsCorrectResults()
        {
            ILogImporter<SQLServerLogEvent> importer = new CsvLogImporter<SQLServerLogEvent>(MockStorage(SampleData.CsvFormatLogWithHeader), new string[] { "EventTime", "ServerName", "ErrorNumber", "ErrorSeverity", "DatabaseName", "ErrorMessage" }, true, ';', '"');
            var exportedData = JsonConvert.DeserializeObject<List<SQLServerLogEvent>>(SampleData.JsonFormatLog);

            var result = importer.Import();

            Assert.AreEqual(SampleData.JsonFormatLog, JsonConvert.SerializeObject(result));
        }
    }
}
