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
        public void TestAddition()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            Assert.AreEqual(42, math.DoOperation(Operations.Add, 42), delta);
            Assert.AreEqual(50, math.DoOperation(Operations.Add, 8), delta);
            Assert.AreEqual(50, math.Result());
        }

        [TestMethod]
        public void TestSubstraction()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            Assert.AreEqual(100, math.DoOperation(Operations.Sub, 100), delta);
            Assert.AreEqual(50, math.DoOperation(Operations.Sub, 50), delta);
            Assert.AreEqual(0, math.DoOperation(Operations.Sub, 50), delta);
            Assert.AreEqual(0, math.Result(), delta);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            Assert.AreEqual(10, math.DoOperation(Operations.Mul, 10), delta);
            Assert.AreEqual(1000, math.DoOperation(Operation.Mul, 100), delta);
            Assert.AreEqual(1, math.DoOperation(Operation.Mul, 0.001), delta);
            Assert.AreEqual(1, math.Result(), delta);
        }

        [TestMethod]
        public void TestDivision()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            Assert.AreEqual(100, math.DoOperation(Operations.Div, 100), delta);
            Assert.AreEqual(0.1, math.DoOperation(Operations.Div, 1000), delta);
            Assert.AreEqual(10, math.DoOperation(Operations.Div, 0.01), delta);
            Assert.AreEqual(10, math.Result(), delta);
        }

        [TestMethod]
        public void TestFactorial()
        {
            Calculator.MyMath math = new Calculator.MyMath();

            Assert.AreEqual(6, math.DoOperation(Operations.Fact, 3), delta); //faktoriál přímo zadané hodnoty
            Assert.AreEqual(720, math.DoOperation(Operations.Fact), delta); //faktoriál hodnoty z předchozího výpočtu
            Assert.AreEqual(720, math.Result(), delta);
        }

        /*
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
