using System;
using System.Diagnostics;
using System.Linq;

namespace Calculator
{
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

    public class MyMath
    {
        private Operations _currentOperation;
        private double _currentResult;

        public double DoOperation(Operations oper, double? op=null)
        {
            _currentOperation = oper;
            switch (_currentOperation)
            {
                case Operations.Set:
                    Debug.Assert(op.HasValue, "op must have value");
                    _currentResult = op.Value;
                    break;
                case Operations.Add:
                    Debug.Assert(op.HasValue, "op must have value");
                    _currentResult += op.Value;
                    break;
                case Operations.Sub:
                    Debug.Assert(op.HasValue, "op must have value");
                    _currentResult -= op.Value;
                    break;
                case Operations.Mul:
                    Debug.Assert(op.HasValue, "op must have value");
                    _currentResult *= op.Value;
                    break;
                case Operations.Div:
                    Debug.Assert(op.HasValue, "op must have value");
                    _currentResult /= op.Value;
                    break;
                case Operations.Fact:
                    if (op.HasValue)
                        _currentResult = op.Value;
                        var x = Convert.ToInt32(_currentResult);
                    _currentResult = Fact(x);
                    break;
                case Operations.Pow:
                    Debug.Assert(op.HasValue, "op must have value");
                    _currentResult = Power(op.Value);
                    break;
                case Operations.Abs:
                    if (op.HasValue)
                        _currentResult = op.Value;
                    _currentResult = Abs();
                    break;
            }
            return _currentResult;
        }

        public double Result()
        {
            switch (_currentOperation)
            {
                    
            }
            return _currentResult;
        }

        public double Clear()
        {
            _currentResult = 0;
            _currentOperation = Operations.NoOp;
            return _currentResult;
        }

        private double Abs() => Math.Abs(_currentResult);

        private double Power(double x) => Math.Pow(_currentResult, x);

        private long Fact(int x) {
            if (x == 0)
                return 1;
            return Enumerable.Range(1, x).Aggregate((acc, n) => acc*n);
        }
    }
}
