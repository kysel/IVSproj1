using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Calculator;


namespace Calculator_Tests
{
    [TestClass]
    public class MathTests
    {
        double delta = 1e-6;

        [TestMethod]
        public void TestInitialValue()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            Assert.AreEqual(0, math.Result(), delta);
        }

        [TestMethod]
        public void TestInputValue()
        {
            //In some cases (power eg.) there is need for one single value given before operations
            //Then calling math.DoOperation(Operations.Set, new_value) results in: value^new_value

            Calculator.MyMath math = new Calculator.MyMath();

            Assert.AreEqual(10, math.DoOperation(Operations.Set, 10), delta);
            Assert.AreEqual(10, math.Result(), delta);
        }

        [TestMethod]
        public void TestClear()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            math.DoOperation(Operations.Set, 10);
            Assert.AreEqual(0, math.Clear(), delta);
            Assert.AreEqual(0, math.Result(), delta);
        }

        [TestMethod]
        public void TestAddition()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            Assert.AreEqual(42, math.DoOperation(Operations.Add, 42), delta);
            Assert.AreEqual(50, math.DoOperation(Operations.Add, 8), delta);
            Assert.AreEqual(50, math.Result(), delta);
        }

        [TestMethod]
        public void TestSubstraction()
        {
            Calculator.MyMath math = new Calculator.MyMath();
            Assert.AreEqual(200, math.DoOperation(Operations.Set, 200), delta);
            Assert.AreEqual(100, math.DoOperation(Operations.Sub, 100), delta);
            Assert.AreEqual(50, math.DoOperation(Operations.Sub, 50), delta);
            Assert.AreEqual(0, math.DoOperation(Operations.Sub, 50), delta);
            Assert.AreEqual(0, math.Result(), delta);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            Calculator.MyMath math = new Calculator.MyMath();
            Assert.AreEqual(1, math.DoOperation(Operations.Set, 1), delta);
            Assert.AreEqual(10, math.DoOperation(Operations.Mul, 10), delta);
            Assert.AreEqual(1000, math.DoOperation(Operations.Mul, 100), delta);
            Assert.AreEqual(1, math.DoOperation(Operations.Mul, 0.001), delta);
            Assert.AreEqual(1, math.Result(), delta);
        }

        [TestMethod]
        public void TestDivision()
        {
            Calculator.MyMath math = new Calculator.MyMath();
            Assert.AreEqual(10000, math.DoOperation(Operations.Set, 10000), delta);
            Assert.AreEqual(100, math.DoOperation(Operations.Div, 100), delta);
            Assert.AreEqual(0.1, math.DoOperation(Operations.Div, 1000), delta);
            Assert.AreEqual(10, math.DoOperation(Operations.Div, 0.01), delta);
            Assert.AreEqual(10, math.Result(), delta);
        }

        [TestMethod]
        public void TestFactorial()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            Assert.AreEqual(6, math.DoOperation(Operations.Fact, 3), delta); //factorial of explicit value
            Assert.AreEqual(720, math.DoOperation(Operations.Fact), delta); //factorial of value from previous computation
            Assert.AreEqual(720, math.Result(), delta);
        }

        [TestMethod]
        public void TestPower()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            math.DoOperation(Operations.Set, 10);
            Assert.AreEqual(1000, math.DoOperation(Operations.Pow, 3), delta);
            Assert.AreEqual(1000, math.Result(), delta);

            math.DoOperation(Operations.Set, 0.1);
            Assert.AreEqual(0.001, math.DoOperation(Operations.Pow, 3), delta);
            Assert.AreEqual(0.001, math.Result(), delta);
        }

        [TestMethod]
        public void TestAbsoluteValue()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            Assert.AreEqual(0.5, math.DoOperation(Operations.Abs, -0.5), delta);
            Assert.AreEqual(0.5, math.DoOperation(Operations.Abs, 0.5), delta);
            Assert.AreEqual(0.5, math.Result(), delta);

            math.Clear();
            math.DoOperation(Operations.Set, -4);
            Assert.AreEqual(4, math.DoOperation(Operations.Abs), delta);
        }
    }
}
