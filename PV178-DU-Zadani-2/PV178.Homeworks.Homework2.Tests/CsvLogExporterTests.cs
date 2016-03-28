using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using PV178.Homeworks.Homework2.Storage;
using PV178.Homeworks.Homework2.Export;
using PV178.Homeworks.Homework2.Entities;
using PV178.Homeworks.Homework2.Tests.Entities;

namespace PV178.Homeworks.Homework2.Tests
{
    [TestClass]
    public class CsvLogExporterTests
    {
        string savedContent;
        ILogStorage storage;

        [TestInitialize]
        public void Setup()
        {
            var storageMock = new Mock<ILogStorage>();
            storageMock.Setup(p => p.Save(It.IsAny<string>())).Callback((string c) => savedContent = c);
            this.storage = storageMock.Object;
        }

        [TestMethod]
        public void Export_NoHeaderRow_GeneratesCorrectCSV()
        {
            ILogExporter<SQLServerLogEvent> exporter = new CsvLogExporter<SQLServerLogEvent>(storage, new string[] { "EventTime", "ServerName", "ErrorNumber", "ErrorSeverity", "DatabaseName", "ErrorMessage" }, false, ';', '"');
            var exportedData = JsonConvert.DeserializeObject<List<SQLServerLogEvent>>(SampleData.JsonFormatLog);

            exporter.Export(exportedData);

            Assert.AreEqual(SampleData.CsvFormatLog, savedContent);
        }

        [TestMethod]
        public void Export_IncludeHeaderRow_GeneratesCorrectCSV()
        {
            ILogExporter<SQLServerLogEvent> exporter = new CsvLogExporter<SQLServerLogEvent>(storage, new string[] { "EventTime", "ServerName", "ErrorNumber", "ErrorSeverity", "DatabaseName", "ErrorMessage" }, true, ';', '"');
            var exportedData = JsonConvert.DeserializeObject<List<SQLServerLogEvent>>(SampleData.JsonFormatLog);

            exporter.Export(exportedData);

            var expectedResults = "EventTime;ServerName;ErrorNumber;ErrorSeverity;DatabaseName;ErrorMessage" + Environment.NewLine + SampleData.CsvFormatLog;
            Assert.AreEqual(expectedResults, savedContent);
        }

        [TestMethod]
        public void Export_IncludeHeaderRowDifferentColumnOrder_GeneratesCorrectCSV()
        {
            ILogExporter<SQLServerLogEvent> exporter = new CsvLogExporter<SQLServerLogEvent>(storage, new string[] { "ErrorNumber", "EventTime", "ServerName", "ErrorSeverity", "DatabaseName", "ErrorMessage" }, true, ';', '"');
            var exportedData = JsonConvert.DeserializeObject<List<SQLServerLogEvent>>(SampleData.JsonFormatLog);

            exporter.Export(exportedData);

            var expectedResults = "ErrorNumber;EventTime;ServerName;ErrorSeverity;DatabaseName;ErrorMessage" + Environment.NewLine + SampleData.CsvFormatLog2;
            Assert.AreEqual(expectedResults, savedContent);
        }

        [TestMethod]
        public void Export_IncludeHeaderRowUserEntity_GeneratesCorrectCSV()
        {
            ILogExporter<User> exporter = new CsvLogExporter<User>(storage, new string[] { "UserName", "UserID", "Registered" }, true, '*', '"');
            var exportedData = new List<User>();
            exportedData.Add(new User() { UserID = 32, UserName = "testUser", Registered = new DateTime(2016, 2, 10, 10, 44, 1, DateTimeKind.Local) });

            exporter.Export(exportedData);

            var expectedResults = "UserName*UserID*Registered" + Environment.NewLine + "\"testUser\"*32*2016-02-10 10:44:01" + Environment.NewLine;
            Assert.AreEqual(expectedResults, savedContent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_PassNullLogStorageParameter_ArgumentNullException()
        {
            ILogExporter<SQLServerLogEvent> exporter = new CsvLogExporter<SQLServerLogEvent>(null, new string[] { "ErrorNumber", "EventTime", "ServerName", "ErrorSeverity", "DatabaseName", "ErrorMessage" }, true, ';', '"');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_PassNullColumnMappingsParameter_ArgumentNullException()
        {
            ILogExporter<SQLServerLogEvent> exporter = new CsvLogExporter<SQLServerLogEvent>(storage, null, true, ';', '"');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Export_PassNullDataParameter_ArgumentNullException()
        {
            ILogExporter<SQLServerLogEvent> exporter = new CsvLogExporter<SQLServerLogEvent>(storage, new string[] { "EventTime", "ServerName", "ErrorNumber", "ErrorSeverity", "DatabaseName", "ErrorMessage" }, true, ';', '"');
            exporter.Export(null);
        }
    }
}
