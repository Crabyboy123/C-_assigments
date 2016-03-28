using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using PV178.Homeworks.Homework2.Entities;
using PV178.Homeworks.Homework2.Import;
using PV178.Homeworks.Homework2.Storage;

namespace PV178.Homeworks.Homework2.Tests
{
    [TestClass]
    public class SQLServerFormatLogImporterTests
    {
        ILogStorage storage;

        [TestInitialize]
        public void Setup()
        {
            var storageMock = new Mock<ILogStorage>();
            storageMock.Setup(p => p.Load()).Returns(SampleData.SQLServerFormatLog);
            this.storage = storageMock.Object;
        }

        [TestMethod]
        public void Load_PassValidSQLLog_ReturnsCorrectResults()
        {
            ILogImporter<SQLServerLogEvent> importer = new SQLServerFormatLogImporter(storage);
            var result = importer.Import();

            Assert.AreEqual(SampleData.JsonFormatLog, JsonConvert.SerializeObject(result));
        }
    }
}
