using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using PV178.Homeworks.Homework2.Entities;
using PV178.Homeworks.Homework2.Export;
using PV178.Homeworks.Homework2.Storage;
using System.Collections.Generic;

namespace PV178.Homeworks.Homework2.Tests
{
    [TestClass]
    public class JsonLogExporterTests
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
        public void Export_PassData_GeneratesCorrectJSON()
        {
            ILogExporter<SQLServerLogEvent> exporter = new JsonLogExporter<SQLServerLogEvent>(storage);
            var exportedData = JsonConvert.DeserializeObject<List<SQLServerLogEvent>>(SampleData.JsonFormatLog);

            exporter.Export(exportedData);

            Assert.AreEqual(SampleData.JsonFormatLog, savedContent);
        }
    }
}
