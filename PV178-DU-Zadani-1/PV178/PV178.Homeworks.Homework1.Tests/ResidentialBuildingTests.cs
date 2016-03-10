using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PV178.Homeworks.Homework1.Tests
{
    [TestClass]
    public class ResidentialBuildingTests
    {
        ResidentialBuilding b;
        const string COMPANY_NAME = "FI MUNI";

        [TestInitialize]
        public void SetUp()
        {
            b = new ResidentialBuilding(COMPANY_NAME);
        }

        [TestMethod]
        public void ConstructionCompanyName_ValueSetInConstructor_ReturnsSameValueAsSet()
        {
            Assert.AreEqual(COMPANY_NAME, b.ConstructionCompanyName, "Construction company name passed to constructor is not accessible in property ConstructionCompanyName");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CalculateLandTax_BuildingNotBuiltInAnyWorld_ExceptionThrown()
        {
            b.CalculateLandTax();
        }

        [TestMethod]
        public void CalculateLandTax_BuildingBuilt_ReturnsValidVariableTax()
        {
            World w = new World(50, 50);
            w.Build(new Coordinates(2, 5), b);

            Assert.AreEqual((decimal)25.5, b.CalculateLandTax(), "Invalid land tax returned");

            var b2 = new ResidentialBuilding(COMPANY_NAME);
            w.Build(new Coordinates(2, 10), b2);

            Assert.AreEqual((decimal)31, b2.CalculateLandTax(), "Invalid land tax returned");
        }

        [TestMethod]
        public void ToString_BuildingBuilt_ReturnsValidResult()
        {
            World w = new World(50, 50);
            w.Build(new Coordinates(10, 10), b);

            var expectedResult = string.Format("Residential Building at {0} build by {1} pays {2} FI$", w.GetBuildingLocation(b), COMPANY_NAME, b.CalculateLandTax());
            Assert.AreEqual(expectedResult, b.ToString(), "ToString method returns invalid results");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void World_NullParameterPassed_ExceptionThrown()
        {
            b.World = null;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void World_WorldSetRepeatedly_ExceptionThrown()
        {
            World w = new World(50, 50);
            b.World = w;
            b.World = w;
        }
    }
}
