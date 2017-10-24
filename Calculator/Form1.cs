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
    public partial class Form1 : Form
    {
        double value = 0;
        String operation = "";
        bool operation_pressed = false;
        int result_click = 0;
        double value_right = 0;
        double percentage = 0;
        bool percentage_pressed = false;
        bool menuClick = false;
        
        //public event KeyEventHandler KeyDown;

        public Form1()
        {
            InitializeComponent();
            
            KeyPreview = true;
        }

        private void disableButtons()
        {
            foreach(Control c in Controls)
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
            

        //    base.OnKeyPress(e);
        //    if (e.KeyChar == '1') txtInput.Text += "1";
        //    if (e.KeyChar == '2') txtInput.Text += "2";
        //    if (e.KeyChar == '3') txtInput.Text += "3";
        //    if (e.KeyChar == '4') txtInput.Text += "4";
        //    if (e.KeyChar == '5') txtInput.Text += "5";
        //    if (e.KeyChar == '6') txtInput.Text += "6";
        //    if (e.KeyChar == '7') txtInput.Text += "7";
        //    if (e.KeyChar == '8') txtInput.Text += "8";
        //    if (e.KeyChar == '9') txtInput.Text += "9";
        //    if (e.KeyChar == '0') txtInput.Text += "0";
        //    if (e.KeyChar == '+') txtInput.Text += "+";
        //    if (e.KeyChar == '-') txtInput.Text += "-";
        //    if (e.KeyChar == '*') txtInput.Text += "*";
        //    if (e.KeyChar == '/') txtInput.Text += "/";
        //    if (e.KeyChar == '=') txtInput.Text += "=";
        //}

        private void Button_Click(object sender, EventArgs e)
        {

            if ((txtInput.Text == "0")||(operation_pressed == true))
                txtInput.Clear();
            
            Button b = (Button)sender;

            if ((txtInput.Text == "") && (b.Text == ","))
                txtInput.Text = "0";

            txtInput.Text += b.Text;
                lbl.Focus();
            operation_pressed = false;
            value_right = Double.Parse(txtInput.Text);
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = Double.Parse(txtInput.Text);
            operation_pressed = true;
            textBox1.Text = txtInput.Text + " " + b.Text + " ";
            lbl.Focus();
            
        }

        private void btnPower_Click_1(object sender, EventArgs e)
        {
            lbl.Focus();
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
                
                default:
                    break;

            }
            result_click++;
            
            if (result_click > 1)
                if (percentage_pressed == true)
                    textBox1.Text = value + operation + percentage.ToString();
                else
                    textBox1.Text = value + operation + value_right;

            lbl.Focus();
            operation_pressed = false;
            percentage_pressed = false;
        }

        private void btnClearAll_Click_1(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtInput.Text = "0";
            lbl.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            textBox1.Clear();
            //txtInput.Text = "0";
            //value = Double.Parse(textBox1.Text);
            lbl.Focus();
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            if (value >= 0)
                txtInput.Text = Math.Sqrt(Double.Parse(txtInput.Text)).ToString();
            else
                txtInput.Text = "Error";
            lbl.Focus();
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            txtInput.Text = (Double.Parse(txtInput.Text) * (-1)).ToString();
            lbl.Focus();
        }

        private void btnInverse_Click_1(object sender, EventArgs e)
        {
            if (Double.Parse(txtInput.Text) != 0)
                txtInput.Text = ((1 / Double.Parse(txtInput.Text)).ToString());
            else
                txtInput.Text = "Error";
            lbl.Focus();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            txtInput.Text = Math.Pow(Double.Parse(txtInput.Text), 2).ToString();
            lbl.Focus();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            percentage_pressed = true;
            value_right = Double.Parse(txtInput.Text);
            txtInput.Clear();
            percentage = value / 100 * value_right;
            txtInput.Text = percentage.ToString();
            lbl.Focus();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
           this.Hide();
           Engineer engForm = new Engineer();
           engForm.Show();
        }

        private void Button1_Input(object sender, KeyEventArgs e)
        {

        }

        private void exitApp(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void NumKeyPressed(object sender, KeyPressEventArgs e)
        {

        }

        private void NumKeyPressed(object sender, KeyEventArgs e)
        {
            base.OnKeyDown(e);
            
            if (e.KeyValue == '1') textBox1.Text += "1";
            if (e.KeyValue == '2') txtInput.Text += "2";
            if (e.KeyValue == '3') txtInput.Text += "3";
            if (e.KeyValue == '4') txtInput.Text += "4";
            if (e.KeyValue == '5') txtInput.Text += "5";
            if (e.KeyValue == '6') txtInput.Text += "6";
            if (e.KeyValue == '7') txtInput.Text += "7";
            if (e.KeyValue == '8') txtInput.Text += "8";
            if (e.KeyValue == '9') txtInput.Text += "9";
            if (e.KeyValue == '0') txtInput.Text += "0";
            if (e.KeyValue == '+') txtInput.Text += "+";
            if (e.KeyValue == '-') txtInput.Text += "-";
            if (e.KeyValue == '*') txtInput.Text += "*";
            if (e.KeyValue == '/') txtInput.Text += "/";
            if (e.KeyValue == '=') txtInput.Text += "=";
        }
    }
}