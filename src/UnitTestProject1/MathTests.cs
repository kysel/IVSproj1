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
    }
}
