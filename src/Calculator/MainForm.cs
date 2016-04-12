using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;


namespace Calculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        MyMath mat = new MyMath();
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(((Button)sender).Text);
            //mat.DoOperation(Operations.Set, Convert.ToDouble(textBox1.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            mat.DoOperation(Operations.Add, Convert.ToDouble(textBox1.Text));
            textBox1.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button12.PerformClick();
            textBox1.Text = Convert.ToString(mat.Result());
        }
    }
}
