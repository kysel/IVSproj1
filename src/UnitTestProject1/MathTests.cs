using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Calculator;


namespace Calculator_Tests
{
    [TestClass]
    public class MathTests
    {
        Calculator.Math math = new Calculator.Math();

        [TestMethod]
        public void TestObjectCreation()
        {
            //tests wheather constructor is working properly
            Assert.IsTrue(math is Calculator.Math);
        }

        [TestMethod]
        public void TestAddition()
        {
            //integers
            Assert.Equals(10, math.add(6, 4));
            Assert.Equals(-5, math.add(5, -10));

            //floats
            Assert.Equals(0.4, math.add(0.1, 0.3));
        }

        [TestMethod]
        public void TestSubstraction()
        {
            //integers
            Assert.Equals(10, math.sub(16, 6));
            Assert.Equals(15, math.sub(5, -10));

            //floats
            Assert.Equals(0.4, math.sub(0.5, 0.1));
            Assert.Equals(-0.1, math.sub(0.2, 0.3));
        }

        [TestMethod]
        public void TestMultiplication()
        {
            //integers
            Assert.Equals(32, math.mul(16, 2));
            Assert.Equals(-50, math.mul(5, -10));

            //floats
            Assert.Equals(0.05, math.mul(0.5, 0.1));
            Assert.Equals(-0.06, math.mul(-0.2, 0.3));
        }

        [TestMethod]
        public void TestDivision()
        {
            //integers
            Assert.Equals(8, math.div(16, 2));
            Assert.Equals(-2, math.div(10, -5));

            //floats
            Assert.Equals(5.0, math.div(0.5, 0.1));
            Assert.Equals(-0.4, math.div(-0.2, 0.5));
        }

        [TestMethod]
        public void TestFactorial()
        {
            Assert.Equals(6, math.fact(3));
            Assert.Equals(3628800, math.fact(10));
        }

        [TestMethod]
        public void TestPower()
        {
            //integers
            Assert.Equals(256, math.pow(16, 2));
            Assert.Equals(-8, math.pow(-2, 3));

            //floats
            Assert.Equals(25.0, math.pow(5.0, 2));
            Assert.Equals(-8.0, math.pow(-2.0, 3));
        }
    }
}
