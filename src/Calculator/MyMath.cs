using System;
using System.Diagnostics;
using System.Linq;

namespace Calculator
{
    /// <summary>
    /// In enum <c>Operations</c> are stored all possible operations
    /// </summary>
    public enum Operations
    {
        Set,
        Abs,
        Sub,
        Add,
        Mul,
        Div,
        Fact,
        Pow,
        NoOp
    }

    /// <summary>
    /// <c>MyMath</c> library contains all definitions of operations for proper calculator work. 
    /// </summary>
    public class MyMath
    {
        /// <summary>
        /// Private variable <c>_currentOperation</c> is used for storing actual operation code.
        /// </summary>
        private Operations _currentOperation;

        /// <summary>
        /// Private variable <c>CurrentResult</c> is used as buffer for actual computation result.
        /// </summary>
        public double CurrentResult { get; private set; }

        /// <summary>
        /// Private variable <c>_lastOperand</c> is used for storing last operation code.
        /// </summary>
        private double _lastOperand;
        
        /// <summary>
        /// <c>DoOperation</c> is used for performing operations on given param <c>op</c>
        /// <c>CurrentResult</c> is then set or adjusted by result of operation.
        /// <c>_currentOperation</c> is set to actual operation code.
        /// </summary>
        /// <param name="oper">Code of operation</param>
        /// <param name="op">Value of operator</param>
        /// <returns><c>CurrentResult</c></returns>
        public double DoOperation(Operations oper, double? op=null)
        {
            _currentOperation = oper;
            switch (_currentOperation)
            {
                case Operations.Set:
                    Debug.Assert(op.HasValue, "op must have value");
                    CurrentResult = op.Value;
                    _lastOperand = op.Value;
                    break;
                case Operations.Add:
                    Debug.Assert(op.HasValue, "op must have value");
                    CurrentResult += op.Value;
                    break;
                case Operations.Sub:
                    Debug.Assert(op.HasValue, "op must have value");
                    CurrentResult -= op.Value;
                    break;
                case Operations.Mul:
                    Debug.Assert(op.HasValue, "op must have value");
                    CurrentResult *= op.Value;
                    break;
                case Operations.Div:
                    Debug.Assert(op.HasValue, "op must have value");
                    if(Math.Abs(op.Value) < 1e-6)
                        CurrentResult = double.NaN;
                    CurrentResult /= op.Value;
                    break;
                case Operations.Fact:
                    if (op.HasValue)
                        CurrentResult = op.Value;
                        var x = Convert.ToInt32(CurrentResult);
                    CurrentResult = Fact(x);
                    break;
                case Operations.Pow:
                    Debug.Assert(op.HasValue, "op must have value");
                    CurrentResult = Power(op.Value);
                    break;
                case Operations.Abs:
                    if (op.HasValue)
                        CurrentResult = op.Value;
                    CurrentResult = Abs();
                    break;
            }
            return CurrentResult;
        }

        /// <summary>
        /// <c>Result</c> is used for returning result of last operation. 
        /// If parameter <c>op</c> is given, <c>lastOperand</c> is set to <c>op</c> value.
        /// </summary>
        /// <param name="op">Value of operand</param>
        /// <returns>The result of current operation.</returns>
        public double Result(double? op = null) {
            if(op.HasValue)
                _lastOperand = op.Value;
            return DoOperation(_currentOperation, _lastOperand);
        }

        /// <summary>
        /// <c>Clear</c> clears <c>CurrentResult</c> variable and sets the <c>_currentOperation</c> to "No Operation" code.
        /// </summary>
        /// <returns>0</returns>
        public double Clear()
        {
            CurrentResult = 0;
            _currentOperation = Operations.NoOp;
            return CurrentResult;
        }

        /// <summary>
        /// <c>Abs</c> is used for getting absolute value of <c>CurrentResult</c>.
        /// </summary>
        /// <returns>Absolute value of <c>CurrentResult</c></returns>
        private double Abs() => Math.Abs(CurrentResult);

        /// <summary>
        /// <c>Power</c> is used for getting <c>CurrentResult</c> powered by <c>x</c>.
        /// </summary>
        /// <param name="x">The exponent</param>
        /// <returns><c>CurrentResult</c> powered by <c>x</c></returns>
        private double Power(double x) => Math.Pow(CurrentResult, x);

        /// <summary>
        /// <c>Fact</c> is used for getting factorial of <c>x</c>.
        /// </summary>
        /// <param name="x">The base of factorial</param>
        /// <returns>Factorial of <c>x</c></returns>
        private double Fact(int x)
        {
            if (x < 0)
                return double.NaN;
            if (x == 0)
                return 1;
            var fact = Enumerable.Range(1, x).Aggregate((acc, n) => acc*n);
            if (fact == 0)
                return double.PositiveInfinity;
            return fact;
        }
    }
}
