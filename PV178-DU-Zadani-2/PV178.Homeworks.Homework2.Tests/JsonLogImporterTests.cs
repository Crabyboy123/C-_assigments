using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using PV178.Homeworks.Homework2.Entities;
using PV178.Homeworks.Homework2.Import;
using PV178.Homeworks.Homework2.Storage;

namespace PV178.Homeworks.Homework2.Tests
{
    [TestClass]
    public class JsonLogImporterTests
    {
        ILogStorage storage;

        [TestInitialize]
        public void Setup()
        {
            var storageMock = new Mock<ILogStorage>();
            storageMock.Setup(p => p.Load()).Returns(SampleData.JsonFormatLog);
            this.storage = storageMock.Object;
        }

        [TestMethod]
        public void Import_PassValidSerializedLog_ReturnsCorrectResults()
        {
            ILogImporter<SQLServerLogEvent> importer = new JsonLogImporter<SQLServerLogEvent>(storage);
            var result = importer.Import();

            Assert.AreEqual(SampleData.JsonFormatLog, JsonConvert.SerializeObject(result));
        }
    }
}
