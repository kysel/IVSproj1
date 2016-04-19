using System;
using System.Windows.Forms;


namespace Calculator {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            KeyPreview = true;  //allow shortcuts
        }

        private MyMath _mat = new MyMath();

        /// <summary>
        /// True if user changed TB input value
        /// </summary>
        private bool InputChangeFromUser => !_mat.CurrentResult.ToString().Equals(textBox1.Text);

        /// <summary>
        /// True if the TB input value changed
        /// </summary>
        private bool _inputChanged;

        /// <summary>
        /// True if the first value was given
        /// </summary>
        private bool _first = true;

        private void bNumber_Click(object sender, EventArgs e) {
            if (!InputChangeFromUser)
                textBox1.Text = "";
            textBox1.AppendText(((Button)sender).Text);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (_first)
            {
                _mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
                _mat.DoOperation(Operations.Add, 0);//seting operation as current
                _first = false;
                return;
            }
            _inputChanged = false;
            textBox1.Text = _mat.DoOperation(Operations.Add, Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void bResult_Click(object sender, EventArgs e) {
            double? op = null;
            if (InputChangeFromUser || !_inputChanged)
                op = double.Parse(textBox1.Text);
            textBox1.Text = _mat.Result(op).ToString();
            _first = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) => _inputChanged = true;

        private void bClear_Click(object sender, EventArgs e)
        {
            _first = true;
            textBox1.Text = Convert.ToString(_mat.Clear());
        }

        private void bSub_Click(object sender, EventArgs e)
        {
            if (_first)
            {
                _mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
                _mat.DoOperation(Operations.Sub, 0);//seting operation as current
                _first = false;
                return;
            }            
            _inputChanged = false;
            textBox1.Text = _mat.DoOperation(Operations.Sub, Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void bMul_Click(object sender, EventArgs e)
        {
            if (_first)
            {
                _mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
                _mat.DoOperation(Operations.Mul, 1);//seting operation as current
                _first = false;
                return;
            }
           
            _inputChanged = false;
            textBox1.Text = _mat.DoOperation(Operations.Mul, Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void bDiv_Click(object sender, EventArgs e)
        {
            if (_first)
            {
                _mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
                _mat.DoOperation(Operations.Div, 1);//seting operation as current
                _first = false;
                return;
            }
            _inputChanged = false;
            textBox1.Text = _mat.DoOperation(Operations.Div, Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void bFact_Click(object sender, EventArgs e)
        {
            if (_first)
            {
                _mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
                _mat.DoOperation(Operations.Fact, 1);//seting operation as current
                _first = false;
                return;
            }
            _inputChanged = false;
            textBox1.Text = _mat.DoOperation(Operations.Fact, Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void bPower_Click(object sender, EventArgs e)
        {
            if (_first)
            {
                _mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
                _mat.DoOperation(Operations.Pow, 1);//seting operation as current
                _first = false;
                return;
            }
            _inputChanged = false;
            textBox1.Text = _mat.DoOperation(Operations.Pow, Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void bAbsolute_Click(object sender, EventArgs e)
        {
            if (_first)
            {
                _mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
                _mat.DoOperation(Operations.Abs, 1);//seting operation as current
                _first = false;
                return;
            }
            _inputChanged = false;
            textBox1.Text = _mat.DoOperation(Operations.Abs, Convert.ToDouble(textBox1.Text)).ToString();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                case Keys.D0:
                    button0.PerformClick();
                    break;
                case Keys.NumPad1:
                case Keys.D1:
                    button1.PerformClick();
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    button2.PerformClick();
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    button3.PerformClick();
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    button4.PerformClick();
                    break;
                case Keys.NumPad5:
                case Keys.D5:
                    button5.PerformClick();
                    break;
                case Keys.NumPad6:
                case Keys.D6:
                    button6.PerformClick();
                    break;
                case Keys.NumPad7:
                case Keys.D7:
                    button7.PerformClick();
                    break;
                case Keys.NumPad8:
                case Keys.D8:
                    button8.PerformClick();
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    button9.PerformClick();
                    break;
                case Keys.Oemplus:
                case Keys.Add:
                    bAdd.PerformClick();
                    break;
                case Keys.OemMinus:
                case Keys.Subtract:
                    bSubstract.PerformClick();
                    break;
                case Keys.Multiply:
                    bMultiply.PerformClick();
                    break;
                case Keys.Divide:
                    bDivide.PerformClick();
                    break;
                default:
                    base.OnKeyDown(e);
                    return;
            }
            e.Handled = true;
        }
    }
}
