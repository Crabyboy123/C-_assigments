using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PV178.Homeworks.Homework1.Tests
{
    [TestClass]
    public class CoordinatesTests
    {
        [TestMethod]
        public void CreatedWithValidInput_SameInputAccessible()
        {
            var c = new Coordinates(10, 20);

            Assert.AreEqual(10, c.Left, "Value of parameter left passed to constructor cannot be read from property Left");
            Assert.AreEqual(20, c.Top, "Value of parameter top passed to constructor cannot be read from property Top");
        }

        [TestMethod]
        public void LeftPropertyValueSet_SameValueReadFromProperty()
        {
            var c = new Coordinates();
            c.Left = 30;

            Assert.AreEqual(30, c.Left, "Unable to read the same value which was set to the property Left");
        }

        [TestMethod]
        public void TopPropertyValueSet_SameValueReadFromProperty()
        {
            var c = new Coordinates();
            c.Top = 25;

            Assert.AreEqual(25, c.Top, "Unable to read the same value which was set to the property Top");
        }

        [TestMethod]
        public void ToString_CreatedWithValidInput_CorrectResultExpected()
        {
            var c = new Coordinates(10, 20);

            Assert.AreEqual("[10;20]", c.ToString(), "Method ToString returns invalid value");
        }

        [TestMethod]
        public void Equals_EqualInstancesCompared_CorrectResult()
        {
            var c1 = new Coordinates(10, 20);
            var c2 = new Coordinates(10, 20);

            Assert.AreEqual(true, c1.Equals(c2), "Method Equals returns invalid value");
        }

        [TestMethod]
        public void Equals_PartiallyUnequalInstancesCompared_CorrectResult()
        {
            var c1 = new Coordinates(10, 20);
            var c2 = new Coordinates(15, 20);

            Assert.AreEqual(false, c1.Equals(c2), "Method Equals returns invalid value");
        }

        [TestMethod]
        public void Equals_PartiallyUnequalInstancesCompared2_CorrectResult()
        {
            var c1 = new Coordinates(10, 20);
            var c2 = new Coordinates(10, 22);

            Assert.AreEqual(false, c1.Equals(c2), "Method Equals returns invalid value");
        }

        [TestMethod]
        public void Equals_InequalInstancesCompared_CorrectResult()
        {
            var c1 = new Coordinates(12, 20);
            var c2 = new Coordinates(10, 23);

            Assert.AreEqual(false, c1.Equals(c2), "Method Equals returns invalid value");
        }

        [TestMethod]
        public void Equals_NullPassed_CorrectResult()
        {
            var c1 = new Coordinates(12, 20);
            Assert.AreEqual(false, c1.Equals(null), "Method Equals returns invalid value");
        }

        [TestMethod]
        public void Equals_DifferentObjectTypePassed_CorrectResult()
        {
            var c1 = new Coordinates(12, 20);
            Assert.AreEqual(false, c1.Equals("test"), "Method Equals returns invalid value");
        }

        [TestMethod]
        public void Equals_EqualBoxedInstanceCompared_CorrectResult()
        {
            var c1 = new Coordinates(10, 20);
            var c2 = new Coordinates(10, 20);

            Assert.AreEqual(true, c1.Equals((object)c2), "Method Equals returns invalid value");
        }

        [TestMethod]
        public void IsInRectangle_CoordinateIsInCornerOfRectangle_CorrectResult()
        {
            var c1 = new Coordinates(10, 20);
            var result = c1.IsInRectangle(10, 20, 10, 10);

            Assert.AreEqual(true, result, "Method IsInRectangle returned invalid result");
        }

        [TestMethod]
        public void IsInRectangle_CoordinateIsInCornerOfRectangle2_CorrectResult()
        {
            var c1 = new Coordinates(10, 20);
            var result = c1.IsInRectangle(5, 5, 5, 15);

            Assert.AreEqual(true, result, "Method IsInRectangle returned invalid result");
        }

        [TestMethod]
        public void IsInRectangle_CoordinateIsOnBorderOfRectangle_CorrectResult()
        {
            var c1 = new Coordinates(10, 20);
            var result = c1.IsInRectangle(5, 20, 10, 15);

            Assert.AreEqual(true, result, "Method IsInRectangle returned invalid result");
        }

        [TestMethod]
        public void IsInRectangle_CoordinateIsOnBorderOfRectangle2_CorrectResult()
        {
            var c1 = new Coordinates(10, 20);
            var result = c1.IsInRectangle(10, 10, 5, 30);

            Assert.AreEqual(true, result, "Method IsInRectangle returned invalid result");
        }

        //
        [TestMethod]
        public void IsInRectangle_CoordinateIsOutOfRectangle_CorrectResult()
        {
            var c1 = new Coordinates(10, 20);
            var result = c1.IsInRectangle(11, 20, 10, 10);

            Assert.AreEqual(false, result, "Method IsInRectangle returned invalid result");
        }

        [TestMethod]
        public void IsInRectangle_CoordinateIsOutOfRectangle2_CorrectResult()
        {
            var c1 = new Coordinates(10, 20);
            var result = c1.IsInRectangle(5, 4, 5, 15);

            Assert.AreEqual(false, result, "Method IsInRectangle returned invalid result");
        }

        [TestMethod]
        public void IsInRectangle_CoordinateIsOutOfRectangle3_CorrectResult()
        {
            var c1 = new Coordinates(10, 20);
            var result = c1.IsInRectangle(5, 21, 10, 15);

            Assert.AreEqual(false, result, "Method IsInRectangle returned invalid result");
        }

        [TestMethod]
        public void IsInRectangle_CoordinateIsOutOfRectangle4_CorrectResult()
        {
            var c1 = new Coordinates(10, 20);
            var result = c1.IsInRectangle(11, 10, 5, 30);

            Assert.AreEqual(false, result, "Method IsInRectangle returned invalid result");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsInRectangle_InvalidParameter_ExceptionThrown()
        {
            var c1 = new Coordinates(10, 20);
            var result = c1.IsInRectangle(11, 10, -5, 30);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsInRectangle_InvalidParameter2_ExceptionThrown()
        {
            var c1 = new Coordinates(10, 20);
            var result = c1.IsInRectangle(11, 10, 5, -30);
        }

        
    }
}
