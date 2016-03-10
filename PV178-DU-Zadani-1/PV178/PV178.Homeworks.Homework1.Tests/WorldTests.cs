using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PV178.Homeworks.Homework1.Tests
{
    [TestClass]
    public class WorldTests
    {
        private IWorld w;

        [TestInitialize]
        public void SetUp()
        {
            w = new World(30, 20);
        }

        [TestMethod]
        public void CreatedWithValidInput_SameInputAccessible()
        {
            Assert.AreEqual(30, w.Width, "Value of parameter width passed to constructor cannot be read from property Width");
            Assert.AreEqual(20, w.Height, "Value of parameter height passed to constructor cannot be read from property Height");
        }

        [TestMethod]
        public void FreeTiles_EmptyWorld_ReturnsCorrectResults()
        {
            Assert.AreEqual(600, w.FreeTiles, "Number of FreeTiles was not returned correctly");
            
        }

        [TestMethod]
        public void FreeTiles_WorldWithOneBuilding_ReturnsCorrectResults()
        {
            var c = new Coordinates(5, 10);
            w.Build(c, new ResidentialBuilding("FI MUNI"));

            Assert.AreEqual(599, w.FreeTiles, "Number of FreeTiles was not returned correctly");
        }

        [TestMethod]
        public void Build_AddBuildingToEmptyWorld_BuildingAddedAndAccessibleAtGivenCoordinates()
        {
            var c = new Coordinates(5, 10);
            w.Build(c, new ResidentialBuilding("FI MUNI"));
            
            var b = w.GetBuildingAt(c);

            Assert.AreNotEqual(null, b, "GetBuildingAt incorretly did not return any building");
            Assert.AreEqual("FI MUNI", b.ConstructionCompanyName, "Returned building has different construction company");
            Assert.AreEqual(c, w.GetBuildingLocation(b), "Building is not built at given location");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Build_NullBuildingParameterPassed_ExceptionThrown()
        {
            w.Build(new Coordinates(5, 10), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Build_LeftCoordinateOutOfRange_ExceptionThrown()
        {
            w.Build(new Coordinates(31, 10), new ResidentialBuilding("FI MUNI"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Build_TopCoordinateOutOfRange_ExceptionThrown()
        {
            w.Build(new Coordinates(5, 21), new ResidentialBuilding("FI MUNI"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Build_LeftAndTopCoordinateOutOfRange_ExceptionThrown()
        {
            w.Build(new Coordinates(31, 21), new ResidentialBuilding("FI MUNI"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Build_BuildAtOccupiedSpot_ExceptionThrown()
        {
            w.Build(new Coordinates(5, 10), new ResidentialBuilding("FI MUNI"));
            w.Build(new Coordinates(5, 10), new ResidentialBuilding("FI MUNI 2"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Build_TheSameBuildingCannotBeBuiltTwice_ExceptionThrown()
        {
            var b = new ResidentialBuilding("FI MUNI");
            w.Build(new Coordinates(5, 10), b);
            w.Build(new Coordinates(6, 10), b);
        }

        [TestMethod]
        public void GetBuildingAt_CoordinateOfEmptySpot_NullReturned()
        {
            w.Build(new Coordinates(5, 10), new ResidentialBuilding("FI MUNI"));

            var b = w.GetBuildingAt(new Coordinates(5,11));

            Assert.AreEqual(null, b, "GetBuildingAt incorretly did return a building");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetBuildingAt_LeftCoordinateOutOfRange_ExceptionThrown()
        {
            var b = w.GetBuildingAt(new Coordinates(31, 11));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetBuildingAt_TopCoordinateOutOfRange_ExceptionThrown()
        {
            var b = w.GetBuildingAt(new Coordinates(31, 21));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetBuildingLocation_NullParameterPassed_ExceptionThrown()
        {
            var b = w.GetBuildingLocation(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetBuildingLocation_BuildingDoesNotExist_ExceptionThrown()
        {
            var b = w.GetBuildingLocation(new IndustrialBuilding("FI MUNI"));
        }

        [TestMethod]
        public void GetBuildingLocation_BuildingExists_ReturnsCorrectResult()
        {
            var b1 = new ResidentialBuilding("FI MUNI");
            var b2 = new IndustrialBuilding("FI MUNI");
            
            var c1 = new Coordinates(2, 5);
            var c2 = new Coordinates(5, 5);
            
            w.Build(c1, b1);
            w.Build(c2, b2);

            Assert.AreEqual(c1, w.GetBuildingLocation(b1), "Incorrect location of building was returned");
            Assert.AreEqual(c2, w.GetBuildingLocation(b2), "Incorrect location of building was returned");
        }

        [TestMethod]
        public void CalculateLandTax_TwoBuildingsBuilt_ReturnsCorrectResult()
        {
            w.Build(new Coordinates(2, 5), new ResidentialBuilding("FI MUNI"));
            w.Build(new Coordinates(5, 5), new IndustrialBuilding("FI MUNI"));

            Assert.AreEqual((decimal)57, w.CalculateLandTax(), "CalculatedLandTax is incorrect");
        }
    }
}
