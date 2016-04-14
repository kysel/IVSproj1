using System;
using System.Windows.Forms;


namespace Calculator {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
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


        private bool first = true;

        private void button1_Click(object sender, EventArgs e) {
            if (!InputChangeFromUser)
                textBox1.Text = "";
            textBox1.AppendText(((Button)sender).Text);
        }
        
        private void button12_Click(object sender, EventArgs e) {
            if (first)
            {
                _mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
                _mat.DoOperation(Operations.Add, 0);//seting operation as current
                first = false;
                return;
            }             
            _inputChanged = false;
            textBox1.Text = _mat.DoOperation(Operations.Add, Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void button14_Click(object sender, EventArgs e) {
            double? op = null;
            if (InputChangeFromUser || !_inputChanged)
                op = double.Parse(textBox1.Text);
            textBox1.Text = _mat.Result(op).ToString();
            first = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) => _inputChanged = true;

        private void button15_Click(object sender, EventArgs e)
        {
            first = true;
            textBox1.Text = Convert.ToString(_mat.Clear());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (first)
            {
                _mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
                _mat.DoOperation(Operations.Sub, 0);//seting operation as current
                first = false;
                return;
            }            
           
            _inputChanged = false;
            textBox1.Text = _mat.DoOperation(Operations.Sub, Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (first)
            {
                _mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
                _mat.DoOperation(Operations.Mul, 1);//seting operation as current
                first = false;
                return;
            }
           
            _inputChanged = false;
            textBox1.Text = _mat.DoOperation(Operations.Mul, Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (first)
            {
                _mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
                _mat.DoOperation(Operations.Div, 1);//seting operation as current
                first = false;
                return;
            }
            _inputChanged = false;
            textBox1.Text = _mat.DoOperation(Operations.Div, Convert.ToDouble(textBox1.Text)).ToString();
        }
    }
}
