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
        public double CurrentResult { get; private set; }
        private double _lastOperand;
        

        public double DoOperation(Operations oper, double? op=null)
        {
            _currentOperation = oper;
            switch (_currentOperation)
            {
                case Operations.Set:
                    Debug.Assert(op.HasValue, "op must have value");
                    CurrentResult = op.Value;
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

        public double Result(double? op = null) {
            if(op.HasValue)
                _lastOperand = op.Value;
            return DoOperation(_currentOperation, _lastOperand);
        }

        public double Clear()
        {
            CurrentResult = 0;
            _currentOperation = Operations.NoOp;
            return CurrentResult;
        }

        private double Abs() => Math.Abs(CurrentResult);

        private double Power(double x) => Math.Pow(CurrentResult, x);

        private long Fact(int x) {
            if (x == 0)
                return 1;
            return Enumerable.Range(1, x).Aggregate((acc, n) => acc*n);
        }
    }
}
