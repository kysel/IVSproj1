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


        private void button1_Click(object sender, EventArgs e) {
            if (!InputChangeFromUser)
                textBox1.Text = "";
            textBox1.AppendText(((Button)sender).Text);
        }
        
        private void button12_Click(object sender, EventArgs e) {
            _inputChanged = false;
            if (!InputChangeFromUser)
                return;
            textBox1.Text = _mat.DoOperation(Operations.Add, Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void button14_Click(object sender, EventArgs e) {
            double? op = null;
            if (InputChangeFromUser || !_inputChanged)
                op = double.Parse(textBox1.Text);
            textBox1.Text = _mat.Result(op).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) => _inputChanged = true;

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(_mat.Clear());
        }

    }
}
