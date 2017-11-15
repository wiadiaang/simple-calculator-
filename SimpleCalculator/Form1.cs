using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        string operation = string.Empty;
        bool DivideByZero = false;
        bool ModuludOfZero = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + "3";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + "6";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + "5";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + "4";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + "9";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + "8";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtResult.Text + "7";
        }

        private void btnModules_Click(object sender, EventArgs e)
        {
            string bkp = string.Empty;
            if (txtResult.Text != "")
            {
                Calculations();
                if (txtResult.Text[txtResult.Text.Length - 1] != '%')
                {
                    if (txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("*") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("-") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("/") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("+"))
                    {
                        bkp = RemoveLastChar(txtResult.Text);
                        txtResult.Text = bkp + "%";
                    }
                    else
                    {
                        if (!DivideByZero && !ModuludOfZero)
                        txtResult.Text = txtResult.Text + "%";
                        //txtExpression.Text = txtExpression.Text + txtResult.Text;
                    }
                }
            }
            operation = "modulus";
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            int counter = 0;
            if (txtResult.Text != "")
            {
                //Calculations();
                if (txtResult.Text[txtResult.Text.Length - 1] != '.')
                {
                    char[] signs = { '/', '*', '-', '+', '%' };
                    foreach (char c in signs)
                    {
                        if (txtResult.Text.Contains(c))
                        {
                            //int index = txtResult.Text.LastIndexOf(c);
                            string[] SignSplitted = txtResult.Text.Split(c);
                            //if (!txtResult.Text.Substring(index, txtResult.Text.Length - 1).Contains('.'))
                            //{
                            counter++;
                            if (!SignSplitted[1].Contains('.'))
                                txtResult.Text = txtResult.Text + ".";
                            //}
                        }
                    }
                    if (counter == 0)
                    {
                        if (!txtResult.Text.Contains('.'))
                            txtResult.Text = txtResult.Text + ".";
                    }
                }
            }
            else
            {
                txtResult.Text = txtResult.Text + "0.";
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            string bkp = string.Empty;
            if (txtResult.Text != string.Empty)
            {
                if (txtResult.Text[txtResult.Text.Length - 1] != Convert.ToChar("+"))
                {
                    Calculations();
                    if (txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("*") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("-") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("/") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("%"))
                    {
                        bkp = RemoveLastChar(txtResult.Text);
                        txtResult.Text = bkp + "+";
                    }
                    else
                    {
                        if (!DivideByZero && !ModuludOfZero)
                        txtResult.Text = txtResult.Text + "+";
                    }
                }
            }
            operation = "plus";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            string bkp = string.Empty;
            if (txtResult.Text != string.Empty)
            {
                //  num1 = float.Parse(txtResult.Text);
                if (txtResult.Text[txtResult.Text.Length - 1] != Convert.ToChar("-"))
                {
                    Calculations();
                    if (txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("*") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("+") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("/") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("%"))
                    {
                        bkp = RemoveLastChar(txtResult.Text);
                        txtResult.Text = bkp + "-";
                    }
                    else
                    {
                        if (!DivideByZero && !ModuludOfZero)
                        txtResult.Text = txtResult.Text + "-";
                        //txtExpression.Text = txtExpression.Text + txtResult.Text;
                    }
                }
                operation = "minus";
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            string bkp = string.Empty;
            if (txtResult.Text != string.Empty)
            {
                Calculations();
                if (txtResult.Text[txtResult.Text.Length - 1] != Convert.ToChar("*"))
                {
                    if (txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("-") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("+") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("/") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("%"))
                    {
                        bkp = RemoveLastChar(txtResult.Text);
                        txtResult.Text = bkp + "*";
                    }
                    else
                    {
                        if (!DivideByZero && !ModuludOfZero)
                        txtResult.Text = txtResult.Text + "*";
                        //txtExpression.Text = txtExpression.Text + txtResult.Text;
                    }
                }
            }
            operation = "multiply";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            string bkp = string.Empty;
            if (txtResult.Text != string.Empty)
            {
                Calculations();
                if (txtResult.Text[txtResult.Text.Length - 1] != Convert.ToChar("/"))
                {
                    if (txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("*") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("+") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("/") || txtResult.Text[txtResult.Text.Length - 1] == Convert.ToChar("%"))
                    {
                        bkp = RemoveLastChar(txtResult.Text);
                        txtResult.Text = bkp + "/";
                    }
                    else
                    {
                        if (!DivideByZero && !ModuludOfZero)
                        txtResult.Text = txtResult.Text + "/";
                        //txtExpression.Text = txtExpression.Text + txtResult.Text;
                    }
                }
            }
            operation = "divide";
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            Calculations();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }

        private void btnBkpSpace_Click(object sender, EventArgs e)
        {
            string bkp = RemoveLastChar(txtResult.Text);
            txtResult.Text = bkp;
        }

        public string RemoveLastChar(string fulltext)
        {
            string bkp = string.Empty;
            char[] text = fulltext.ToCharArray();
            for (int i = 0; i < text.Length - 1; i++)
            {
                bkp += text[i];
            }
            return bkp;
        }

        public long CalculateIntegerResult(string operation, long num1, long num2)
        {
            long resut = 0;
            try
            {
                if (txtResult.Text.Contains("+") || txtResult.Text.Contains("-") || txtResult.Text.Contains("*") || txtResult.Text.Contains("/") || txtResult.Text.Contains("%"))
                {
                    switch (operation)
                    {
                        case "plus":
                            resut = num1 + num2;
                            break;
                        case "minus":
                            resut = num1 - num2;
                            break;
                        case "multiply":
                            resut = num1 * num2;
                            break;
                        case "divide":
                            resut = num1 / num2;
                            break;
                        case "modulus":
                            resut = num1 % num2;
                            break;
                        default:
                            break;
                    }
                }
                return resut;
            }
            catch
            {
                return resut;
            }
        }

        public float CalculateFloatResult(string operation, float num1, float num2)
        {
            float resut = 0;
            try
            {
                if (txtResult.Text.Contains("+") || txtResult.Text.Contains("-") || txtResult.Text.Contains("*") || txtResult.Text.Contains("/") || txtResult.Text.Contains("%"))
                {
                    switch (operation)
                    {
                        case "plus":
                            resut = num1 + num2;
                            break;
                        case "minus":
                            resut = num1 - num2;
                            break;
                        case "multiply":
                            resut = num1 * num2;
                            break;
                        case "divide":
                            resut = num1 / num2;
                            break;
                        case "modulus":
                            if (num2 != 0.0)
                                resut = num1 % num2;
                            else
                                MessageBox.Show("Cannot find Modulus of Zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            break;
                    }
                }
                return resut;
            }
            catch
            {
                return resut;
            }
        }

        public void Calculations()
        {
            try
            {
                if (txtResult.Text.Contains('+'))
                {
                    string[] splitted = txtResult.Text.Split('+');
                    if (splitted[1] != "")
                    {
                        if (splitted[0].Contains('.') || splitted[1].Contains('.'))
                        {
                            float floatResult = CalculateFloatResult("plus", float.Parse(splitted[0]), float.Parse(splitted[1]));
                            txtResult.Text = Convert.ToString(floatResult);
                        }
                        else
                        {
                            long rr = CalculateIntegerResult("plus", long.Parse(splitted[0]), long.Parse(splitted[1]));
                            txtResult.Text = Convert.ToString(rr);
                        }
                    }
                }
                if (txtResult.Text.Contains('-'))
                {
                    string[] splitted = txtResult.Text.Split('-');
                    if (splitted[1] != "")
                    {
                        if (splitted[0].Contains('.') || splitted[1].Contains('.'))
                        {
                            float floatResult = CalculateFloatResult("minus", float.Parse(splitted[0]), float.Parse(splitted[1]));
                            txtResult.Text = Convert.ToString(floatResult);
                        }
                        else
                        {
                            long rr = CalculateIntegerResult("minus", long.Parse(splitted[0]), long.Parse(splitted[1]));
                            txtResult.Text = Convert.ToString(rr);
                        }
                    }
                }
                if (txtResult.Text.Contains('*'))
                {
                    string[] splitted = txtResult.Text.Split('*');
                    if (splitted[1] != "")
                    {
                        if (splitted[0].Contains('.') || splitted[1].Contains('.'))
                        {
                            float floatResult = CalculateFloatResult("multiply", float.Parse(splitted[0]), float.Parse(splitted[1]));
                            txtResult.Text = Convert.ToString(floatResult);
                        }
                        else
                        {
                            long rr = CalculateIntegerResult("multiply", long.Parse(splitted[0]), long.Parse(splitted[1]));
                            txtResult.Text = Convert.ToString(rr);
                        }
                    }
                }
                if (txtResult.Text.Contains('/'))
                {
                    string[] splitted = txtResult.Text.Split('/');
                    if (splitted[1] != "")
                    {
                        if (!splitted[1].Contains('.'))
                        {
                            if (Convert.ToInt32(splitted[1]) != 0)
                            {
                                if (splitted[0].Contains('.') || splitted[1].Contains('.'))
                                {
                                    float floatResult = CalculateFloatResult("divide", float.Parse(splitted[0]), float.Parse(splitted[1]));
                                    txtResult.Text = Convert.ToString(floatResult);
                                }
                                else
                                {
                                    long rr = CalculateIntegerResult("divide", long.Parse(splitted[0]), long.Parse(splitted[1]));
                                    txtResult.Text = Convert.ToString(rr);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cannot divide by Zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DivideByZero = true;
                            }
                        }
                        else
                        {
                            if (float.Parse(splitted[1]) != 0)
                            {
                                if (splitted[0].Contains('.') || splitted[1].Contains('.'))
                                {
                                    float floatResult = CalculateFloatResult("divide", float.Parse(splitted[0]), float.Parse(splitted[1]));
                                    txtResult.Text = Convert.ToString(floatResult);
                                }
                                else
                                {
                                    long rr = CalculateIntegerResult("divide", long.Parse(splitted[0]), long.Parse(splitted[1]));
                                    txtResult.Text = Convert.ToString(rr);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cannot divide by Zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DivideByZero = true;
                            }
                        }
                    }
                }
                if (txtResult.Text.Contains('%'))
                {
                    string[] splitted = txtResult.Text.Split('%');
                    if (splitted[1] != "")
                    {
                        if (splitted[0].Contains('.') || splitted[1].Contains('.'))
                        {
                            float floatResult = CalculateFloatResult("modulus", float.Parse(splitted[0]), float.Parse(splitted[1]));
                            txtResult.Text = Convert.ToString(floatResult);
                        }
                        else
                        {
                            if (Convert.ToInt32(splitted[1]) == 0)
                            {
                                MessageBox.Show("Cannot find Modulus of Zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ModuludOfZero = true;
                            }
                            else
                            {
                                long rr = CalculateIntegerResult("modulus", long.Parse(splitted[0]), long.Parse(splitted[1]));
                                txtResult.Text = Convert.ToString(rr);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
