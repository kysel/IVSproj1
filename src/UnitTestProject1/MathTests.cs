using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Calculator;


namespace Calculator_Tests
{
    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void TestAddition()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            Assert.AreEqual(42, math.DoOperation(Operations.Add, 42), 1e-6);
            Assert.AreEqual(50, math.DoOperation(Operations.Add, 8), 1e-6);
            Assert.AreEqual(50, math.Result());
        }

        [TestMethod]
        public void TestSubstraction()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            Assert.AreEqual(100, math.DoOperation(Operations.Sub, 100), 1e-6);
            Assert.AreEqual(50, math.DoOperation(Operations.Sub, 50), 1e-6);
            Assert.AreEqual(0, math.DoOperation(Operations.Sub, 50), 1e-6);
            Assert.AreEqual(0, math.Result());
        }

        /*[TestMethod]
        public void TestObjectCreation()
        {
            //tests wheather constructor is working properly
            Assert.IsTrue(math is Calculator.Math);
        }

        [TestMethod]
        public void TestAddition()
        {
            //longs
            Assert.Equals(10, math.Add(6, 4));
            Assert.Equals(-5, math.Add(5, -10));

            //doubles
            Assert.Equals(0.4, math.Add(0.1, 0.3));
        }

        [TestMethod]
        public void TestSubstraction()
        {
            //longs
            Assert.Equals(10, math.Sub(16, 6));
            Assert.Equals(15, math.Sub(5, -10));

            //doubles
            Assert.Equals(0.4, math.Sub(0.5, 0.1));
            Assert.Equals(-0.1, math.Sub(0.2, 0.3));
        }

        [TestMethod]
        public void TestMultiplication()
        {
            //longs
            Assert.Equals(32, math.Mul(16, 2));
            Assert.Equals(-50, math.Mul(5, -10));

            //doubles
            Assert.Equals(0.05, math.Mul(0.5, 0.1));
            Assert.Equals(-0.06, math.Mul(-0.2, 0.3));
        }

        [TestMethod]
        public void TestDivision()
        {
            //longs
            Assert.Equals(8, math.Div(16, 2));
            Assert.Equals(-2, math.Div(10, -5));

            //doubles
            Assert.Equals(5.0, math.Div(0.5, 0.1));
            Assert.Equals(-0.4, math.Div(-0.2, 0.5));
        }

        [TestMethod]
        public void TestFactorial()
        {
            Assert.Equals(6, math.Fact(3));
            Assert.Equals(3628800, math.Fact(10));
        }

        [TestMethod]
        public void TestPower()
        {
            //longs
            Assert.Equals(256, math.Pow(16, 2));
            Assert.Equals(-8, math.Pow(-2, 3));

            //doubles
            Assert.Equals(25.0, math.Pow(5.0, 2));
            Assert.Equals(-8.0, math.Pow(-2.0, 3));
        }

        [TestMethod]
        public void TestAbsoluteValue()
        {
            //longs
            Assert.Equals(10, math.Abs(10));
            Assert.Equals(10, math.Abs(-10));

            //doubles
            Assert.Equals(5.0, math.Abs(5.0));
            Assert.Equals(5.0, math.Abs(-5.0));
        }

        [TestMethod]
        public void ParserTestSimple()
        {
            //two operands
            Assert.Equals(11, math.parser("10+1"));
            Assert.Equals(20, math.parser("30-10"));
            Assert.Equals(150, math.parser("5*30"));
            Assert.Equals(20, math.parser("80/4"));
            Assert.Equals(24, math.parser("4!"));
            Assert.Equals(256, math.parser("2^8"));
            Assert.Equals(100, math.parser("|-100|"));
        }

        [TestMethod]
        public void ParserTestComplex()
        {
            //multiple operands
            Assert.Equals(6, math.parser("10+1-5"));
            Assert.Equals(0, math.parser("30-10-10-10"));

            Assert.Equals(300, math.parser("5*30*2"));
            Assert.Equals(100, math.parser("80/4*5"));
            Assert.Equals(100, math.parser("80*5/4"));

            Assert.Equals(48, math.parser("2*4!"));

            Assert.Equals(1280, math.parser("5*2^8"));
            Assert.Equals(10000, math.parser("|-100|*100"));

            Assert.Equals(1280, math.parser("|-2^8|*5"));
        }*/

        // TODO: 
    }
}
