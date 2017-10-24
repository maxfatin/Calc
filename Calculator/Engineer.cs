using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Engineer : Form
    {
        double value = 0;
        String operation = "";
        bool operation_pressed = false;
        int result_click = 0;
        double value_right = 0;
        double percentage = 0;
        bool percentage_pressed = false;
        bool mathPow = false;


        private void disableButtons()
        {
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                    btnPower.Enabled = true;
                }
                catch { }
            }
        }

        private void enableButtons()
        {
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                }
                catch { }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if ((txtInput.Text == "0") || (operation_pressed == true))
                txtInput.Clear();

            Button b = (Button)sender;
            if ((txtInput.Text == "") && (b.Text == ","))
                txtInput.Text = "0";

            txtInput.Text += b.Text;
            label1.Focus();
            operation_pressed = false;
            value_right = Double.Parse(txtInput.Text);
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = Double.Parse(txtInput.Text);
            operation_pressed = true;
            mathPow = true;
            if (mathPow == true)
                textBox1.Text = (value + " ^ ").ToString();
            else
                textBox1.Text = txtInput.Text + " " + b.Text + " ";
            label1.Focus();

        }

        private void btnPower_Click_1(object sender, EventArgs e)
        {
            label1.Focus();
            if (btnPower.Text == "OFF")
            {
                btnPower.Text = "ON";
                disableButtons();
            }

            else
            {
                enableButtons();
                btnPower.Text = "OFF";
            }
        }

        private void btnResult_Click_1(object sender, EventArgs e)
        {
            //value_right = Double.Parse(txtInput.Text);
            //textBox1.Text += value_right;

            if (percentage_pressed == false)
                textBox1.Text += txtInput.Text;
            else
                textBox1.Text += percentage.ToString();

            if (mathPow == true)
                textBox1.Text = (value + " ^ " + Double.Parse(txtInput.Text)).ToString();


            switch (operation)
            {
                case "+":
                    txtInput.Text = (value + Double.Parse(txtInput.Text)).ToString();
                    break;
                case "-":
                    txtInput.Text = (value - Double.Parse(txtInput.Text)).ToString();
                    break;
                case "*":
                    txtInput.Text = (value * Double.Parse(txtInput.Text)).ToString();
                    break;
                case "/":
                    txtInput.Text = (value / Double.Parse(txtInput.Text)).ToString();
                    break;
                case "x^y":
                    txtInput.Text = Math.Pow(value, Double.Parse(txtInput.Text)).ToString();
                    break;
                case "n√":
                    if (Double.Parse(txtInput.Text) != 0)
                        txtInput.Text = Math.Pow(value, 1 / Double.Parse(txtInput.Text)).ToString();
                    else
                        txtInput.Text = "Error";
                    break;

                default:
                    break;

            }
            result_click++;

            if (result_click > 1)
                if (percentage_pressed == true)
                    textBox1.Text = value + operation + percentage.ToString();
                else if (mathPow == true)
                    textBox1.Text = (value + " ^ " + Double.Parse(txtInput.Text)).ToString();
                else
                    textBox1.Text = value + operation + value_right;

            label1.Focus();
            operation_pressed = false;
            percentage_pressed = false;
            mathPow = false;
        }

        private void btnClearAll_Click_1(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtInput.Text = "0";
            label1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            textBox1.Clear();
            //txtInput.Text = "0";
            //value = Double.Parse(textBox1.Text);
            label1.Focus();
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            if (value >= 0)
                txtInput.Text = Math.Sqrt(Double.Parse(txtInput.Text)).ToString();
            else
                txtInput.Text = "Error";
            label1.Focus();
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            txtInput.Text = (Double.Parse(txtInput.Text) * (-1)).ToString();
            label1.Focus();
        }

        private void btnInverse_Click_1(object sender, EventArgs e)
        {
            if (Double.Parse(txtInput.Text) != 0)
                txtInput.Text = ((1 / Double.Parse(txtInput.Text)).ToString());
            else
                txtInput.Text = "Error";
            label1.Focus();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            txtInput.Text = Math.Pow(Double.Parse(txtInput.Text), 2).ToString();
            label1.Focus();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            percentage_pressed = true;
            value_right = Double.Parse(txtInput.Text);
            txtInput.Clear();
            percentage = value / 100 * value_right;
            txtInput.Text = percentage.ToString();
            label1.Focus();
        }

        public Engineer()
        {
            InitializeComponent();
        }

        private void Engineer_Load(object sender, EventArgs e)
        {
           
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainCalc = new Form1();
            mainCalc.Show();

        }

        private void exitApp(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnRootN_Click(object sender, EventArgs e)
        {

        }

        private void btnTenPowerN_Click(object sender, EventArgs e)
        {
            txtInput.Text = Math.Pow(10, Double.Parse(txtInput.Text)).ToString();
            label1.Focus();
        }

        private void btnPiNum_Click(object sender, EventArgs e)
        {
            txtInput.Text = Math.PI.ToString();
            label1.Focus();
        }

        private void btnFact_Click(object sender, EventArgs e)
        {
            txtInput.Text = Factorial(Double.Parse(txtInput.Text)).ToString();
            label1.Focus();
        }

        static double Factorial(double n)
        {
            double r = 1;
            for (int i = 2; i <= n; ++i)
                r *= i;
            return r;
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            txtInput.Text = Math.Sin(Math.PI*Double.Parse(txtInput.Text)/180).ToString();
            label1.Focus();
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            txtInput.Text = Math.Cos(Math.PI * Double.Parse(txtInput.Text) / 180).ToString();
            label1.Focus();
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            txtInput.Text = Math.Tan(Math.PI * Double.Parse(txtInput.Text) / 180).ToString();
            label1.Focus();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            txtInput.Text = Math.Log(Double.Parse(txtInput.Text)).ToString();
            label1.Focus();
        }

        private void btnLog10_Click(object sender, EventArgs e)
        {
            txtInput.Text = Math.Log10(Double.Parse(txtInput.Text)).ToString();
            label1.Focus();
        }
    }
}
