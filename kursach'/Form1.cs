using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Text = "0";
        }
        public string history_tmp="";
        public bool equal_clicked = false;
        public string cmd=" ";
        public double a=0,result;
        

        private double Factorial(double n)
        {
            int res = 1;
            for (int j = 1; j <= n; j++) res *= j;
            return res;
        }

        private void BTN_point_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "0") richTextBox1.Text = "0.";
            else                          richTextBox1.Text += ".";
        }

        private void delete_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "0";
            History.Text = "";
            cmd = " ";
            history_tmp = "";
        }
   
        private void NumClick(object sender, EventArgs e)
        {
            int Num = 0;
            if (sender == BTN_0) Num = 0;
            else if (sender == BTN_1) Num = 1;
            else if (sender == BTN_2) Num = 2;
            else if (sender == BTN_3) Num = 3;
            else if (sender == BTN_4) Num = 4;
            else if (sender == BTN_5) Num = 5;
            else if (sender == BTN_6) Num = 6;
            else if (sender == BTN_7) Num = 7;
            else if (sender == BTN_8) Num = 8;
            else if (sender == BTN_9) Num = 9;
            
            if (richTextBox1.Text == "0") richTextBox1.Text = "";
            richTextBox1.Text += Num;
            history_tmp += Num;
            build_history(false);
            equal_clicked = false;
            }
        private void build_history(bool ravno)
        {
            History.Text = history_tmp;
            if(ravno==true) History.Text+="=" + result.ToString();
        }

        private void OneOperand_Click(object sender, EventArgs e)
        {
            calc_result();
            result = 0;
            double b = Double.Parse(richTextBox1.Text);
            if (DEG.Checked) b = b*Math.PI/180;

            if      (sender == BTN_cos)       {result = Math.Cos(b);                history_tmp = "cos(" + history_tmp + ")"; }
            else if (sender == BTN_sin)       {result = Math.Sin(b);                history_tmp = "sin(" + history_tmp + ")"; }
            else if (sender == BTN_tan)       {result = Math.Tan(b);                history_tmp = "tan(" + history_tmp + ")"; }
            else if (sender == BTN_sqrt_3)    {result = Math.Pow(b, (double)1 / 3); history_tmp = "sqrt1/3(" + history_tmp + ")"; }
            else if (sender == BTN_powten_x)  {result = Math.Pow(10, b);            history_tmp = "pow10(" + history_tmp + ")"; }
            else if (sender == BTN_ln)        {result = Math.Log(b);                history_tmp = "ln(" + history_tmp + ")"; }
            else if (sender == BTN_pow_two)   {result = Math.Pow(b, 2);             history_tmp = "pow(" + history_tmp + ")"; }
            else if (sender == BTN_pow_3)     {result = Math.Pow(b, 3);             history_tmp = "pow3(" + history_tmp + ")"; }
            else if (sender == BTN_log)       {result = Math.Log10(b);              history_tmp = "log(" + history_tmp + ")"; }
            else if (sender == BTN_sqrt)      {result = Math.Sqrt(b);               history_tmp = "sqrt(" + history_tmp + ")"; }
            else if (sender == BTN_one_div_x) {result = 1 / b;                      history_tmp = "1/x(" + history_tmp + ")"; }
            else if (sender == BTN_pi)        {result = Math.PI;                    history_tmp = "PI(" + history_tmp + ")"; }
            else if (sender == BTN_factorial) {result = Factorial(b);               history_tmp = "n!(" + history_tmp + ")"; }
           
            
            richTextBox1.Text = Convert.ToString(result);
            equal_clicked = false;
            build_history(true);

        }

        private void calc_result() 
        {
            double b = Double.Parse(richTextBox1.Text);
            result=b;
            switch (cmd)
            {
                case "+":      result = a + b; break;
                case "/":      result = a / b; break;
                case "*":      result = a * b; break;
                case "-":      result = a - b; break;
                case "pow_xy": result = Math.Pow(a, b); break;
               
            }

            richTextBox1.Text = result.ToString();
            a = result;
        }
        private void BTN_result_Click(object sender, EventArgs e)
        {
        if (equal_clicked == true) return;
        equal_clicked = true;
        calc_result();
        build_history(true);
        }

        private void TwoOperand_Click(object sender, EventArgs e)
        {
        calc_result();
        if      (sender == BTN_plus)    {cmd = "+"; history_tmp += "+"; }
        else if (sender == BTN_minus)   {cmd = "-"; history_tmp += "-"; }
        else if (sender == BTN_mul)     {cmd = "*"; history_tmp = "(" + history_tmp + ")*"; }
        else if (sender == BTN_div)     {cmd = "/"; history_tmp = "(" + history_tmp + ")/"; } 
        else if (sender == BTN_pow_x_y) {cmd = "pow_xy"; history_tmp = a +"^";}
            a = Convert.ToDouble(richTextBox1.Text);
        richTextBox1.Text = "";
        richTextBox1.Focus();
        build_history(false);
        }
      
    }
}
