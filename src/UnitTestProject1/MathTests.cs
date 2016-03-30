using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Calculator;


namespace Calculator_Tests
{
    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void TestObjectCreation()
        {
            //tests wheather constructor is working properly
            Calculator.Math math = new Calculator.Math();
            Assert.IsTrue(math is Calculator.Math);
        }

        [TestMethod]
        public void TestAddition()
        {

        }
    }
}
