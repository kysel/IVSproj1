using System;
using System.Windows.Forms;
using System.Xml.Schema;


namespace Calculator {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            KeyPreview = true;  //allow shortcuts
        }

        /// <summary>
        /// Creates an instance <c>_mat</c> of object <c>MyMath</c>.
        /// </summary>
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

        /// <summary>
        /// Format and print number to the text box, handles NaN.
        /// </summary>
        /// <param name="val">NUmber, that has to be printed</param>
        private void SetDisplayValue(double val) {
            if (double.IsNaN(val)) {
                textBox1.Text = "not a number";
                _mat.Clear();
            }
            else if (double.IsPositiveInfinity(val))
                textBox1.Text = "infinity";
            else if (double.IsNegativeInfinity(val))
                textBox1.Text = "negative infinity";
            else {
                const int maxLength = 10;
                var numStr = val.ToString($"G{maxLength}");
                if (numStr.Contains("E") && numStr.Length > maxLength){
                    var exponentLength = numStr.Length - numStr.IndexOf('E');
                    numStr = numStr.Substring(0, maxLength - exponentLength + 1) + numStr.Substring(numStr.IndexOf('E'));
                }
                textBox1.Text = numStr;
            }
        }

        /// <summary>
        /// <c>bNumber_Click</c> is called, when number button is clicked. 
        /// If so, value of button is appended to text field.
        /// </summary>
        /// <param name="sender">Clicked number button object</param>
        private void bNumber_Click(object sender, EventArgs e) {
            if (!InputChangeFromUser)
                textBox1.Text = "";
            textBox1.AppendText(((Button)sender).Text);
        }

        /// <summary>
        /// <c>bAdd_Click</c> is called, when "+" (add) button is clicked.
        /// If there is no valid number in <c>_mat</c> inner buffer, the buffer is set to value of text field and next operation is set to Add.
        /// In other case the given number is added to inner buffer and displayed in text field. 
        /// </summary>
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
            SetDisplayValue(_mat.DoOperation(Operations.Add, Convert.ToDouble(textBox1.Text)));
        }

        /// <summary>
        /// <c>bResult_Click</c> is called, when "=" (equal) button is clicked.
        /// It performs last operation with buffer and number in text field. The result is shown in text field.
        /// When clicked repeatedly, the last operation is performed on number in text field.
        /// </summary>
        private void bResult_Click(object sender, EventArgs e) {
            double? op = null;
            if (InputChangeFromUser || !_inputChanged)
                op = double.Parse(textBox1.Text);
            SetDisplayValue(_mat.Result(op));
            _first = true;
        }

        /// <summary>
        /// <c>textBox1_TextChanged</c> is setter for <c>_inputChanged</c>. It sets its value to true. 
        /// Is ised for marking, that value in text field has changed since last operation.
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e) => _inputChanged = true;

        /// <summary>
        /// <c>bClear_Click</c> is called, when "C" (clear) button is clicked.
        /// It sets private variable <c>_first</c> to true to mark the calculators initial state. 
        /// Also the text field is cleared.
        /// </summary>
        private void bClear_Click(object sender, EventArgs e)
        {
            _first = true;
            SetDisplayValue(_mat.Clear());
        }

        /// <summary>
        /// <c>bSub_Click</c> is called, when "-" (substract) button is clicked. 
        /// If current result in <c>_mat</c> is equal to text in text box, then minus is appended to text field. 
        /// If there is no valid number in <c>_mat</c> inner buffer, the buffer is set to value of text field and next operation is set to Sub.
        /// In other case the given number is substracted from inner buffer and displayed in text field. 
        /// </summary>
        private void bSub_Click(object sender, EventArgs e)
        {
            if (!InputChangeFromUser)
            {
                if (!InputChangeFromUser)
                    textBox1.Text = "";
                textBox1.AppendText(((Button)sender).Text);
                return;
            }
            if (_first)
            {
                _mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
                _mat.DoOperation(Operations.Sub, 0);//seting operation as current
                _first = false;
                return;
            }            
            _inputChanged = false;
            SetDisplayValue(_mat.DoOperation(Operations.Sub, Convert.ToDouble(textBox1.Text)));
        }

        /// <summary>
        /// <c>bMul_Click</c> is called, when "×" (multiply) button is clicked.
        /// If there is no valid number in <c>_mat</c> inner buffer, the buffer is set to value of text field and next operation is set to Mul.
        /// In other case the number in inner buffer is multiplied by input number and result is displayed in text field.
        /// </summary>
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
            SetDisplayValue(_mat.DoOperation(Operations.Mul, Convert.ToDouble(textBox1.Text)));
        }

        /// <summary>
        /// <c>Div_Click</c> is called, when "/" (divide) button is clicked.
        /// If there is no valid number in <c>_mat</c> inner buffer, the buffer is set to value of text field and next operation is set to Div.
        /// In other case the number in inner buffer is divided by input number and result is displayed in text field.
        /// </summary>
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
            SetDisplayValue(_mat.DoOperation(Operations.Div, Convert.ToDouble(textBox1.Text)));
        }

        /// <summary>
        /// <c>bFact_Click</c> is called, when "!" (factorial) button is clicked. 
        /// If there is no valid number in <c>_mat</c> inner buffer, the buffer is set to value of text field and next operation is set to Fact.
        /// In other case the factorial is computed from number in text field and result is displayed in text field.
        /// </summary>
        private void bFact_Click(object sender, EventArgs e)
        {
            if (_first)
            {
                _mat.DoOperation(Operations.Set, 0);
                _mat.DoOperation(Operations.Fact, Convert.ToDouble(textBox1.Text));//seting operation as current
                _first = false;
                return;
            }
            _inputChanged = false;
            SetDisplayValue(_mat.DoOperation(Operations.Fact, Convert.ToDouble(textBox1.Text)));
        }

        /// <summary>
        /// <c>bPower_Click</c> is caled, when "x^n" (power) button is clicked.
        /// If there is no valid number in <c>_mat</c> inner buffer, the buffer is set to value of text field and next operation is set to Pow.
        /// In other case the number in inner buffer is powered by input number.
        /// </summary>
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
            SetDisplayValue(_mat.DoOperation(Operations.Pow, Convert.ToDouble(textBox1.Text)));
        }

        /// <summary>
        /// <c>bAbsolute_Click</c> is called, when "|x|" (absolute) button is clicked.
        /// If there is no valid number in <c>_mat</c> inner buffer, the buffer is set to value of text field and next operation is set to Abs.
        /// In other case the number in inner buffer is set to its absolute value.
        /// </summary>
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
            SetDisplayValue(_mat.DoOperation(Operations.Abs, Convert.ToDouble(textBox1.Text)));
        }

        /// <summary>
        /// <c>OnKeyPress</c> handles keys pressed on physical keyboard and performs clicks on virtual one.
        /// </summary>
        /// <param name="e">is an object of pressed key.</param>
        protected override void OnKeyPress(KeyPressEventArgs e) {
            e.Handled = true;
            switch (e.KeyChar) {
                case '0':
                    button0.PerformClick();
                    break;
                case '1':
                    button1.PerformClick();
                    break;
                case '2':
                    button2.PerformClick();
                    break;
                case '3':
                    button3.PerformClick();
                    break;
                case '4':
                    button4.PerformClick();
                    break;
                case '5':
                    button5.PerformClick();
                    break;
                case '6':
                    button6.PerformClick();
                    break;
                case '7':
                    button7.PerformClick();
                    break;
                case '8':
                    button8.PerformClick();
                    break;
                case '9':
                    button9.PerformClick();
                    break;
                case '+':
                    bAdd.PerformClick();
                    break;
                case '-':
                    bSubstract.PerformClick();
                    break;
                case '*':
                case 'x':
                    bMultiply.PerformClick();
                    break;
                case '\\':
                case '/':
                    bDivide.PerformClick();
                    break;
                case '!':
                    bFact.PerformClick();
                    break;
                default:
                    e.Handled = false;
                    break;
            }
            base.OnKeyPress(e);
        }

        /// <summary>
        /// <c>OnKeyDown</c> handles press on keys Enter and Delete on physical keyboard and performs clicks on corresponding virtual buttons.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e) {
            e.Handled = true;
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    bResult.PerformClick();
                    break;
                case Keys.Delete:
                    bClear.PerformClick();
                    break;
                default:
                    e.Handled = false;
                    break;
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// <c>bDecimal_Click</c> is called, when button with decimal point is clicked. 
        /// If so, value of button is appended to text field.
        /// </summary>
        /// <param name="sender">Clicked number button object</param>
        private void bDecimal_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(((Button)sender).Text);
        }
    }
}
