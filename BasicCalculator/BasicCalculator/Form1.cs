using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        String Operation = "";
        StringBuilder ResultString = new StringBuilder();
        bool getvalue = false;
        double currentValue = 0;
        double prevValue = 0;
        private double accumulator = 0;
        private String lastOperation;
        bool PressedFirstTime = true;
        double tempVal = 0;
        double val2 = 0;
        string from = "";
        string to = "";

        public Form1()
        {
            InitializeComponent();

        }

        private void ClickedButtonValue(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "Button")
            {
                Button ButtonClicked = (Button)sender;
                if ((Result1.Text == "0") || (getvalue))
                    Result1.Text = "";
                getvalue = false;

                if (ButtonClicked.Text == ".")
                {
                    if (!Result1.Text.Contains("."))

                        Result1.Text = Result1.Text + ButtonClicked.Text;
                }
                else
                {
                    Result1.Text = Result1.Text + ButtonClicked.Text;
                }
            }
        }


        private void OperationPerform(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Operation = b.Text;
            getvalue = true;
            currentValue = double.Parse(Result1.Text);


            if (PressedFirstTime == false && lastOperation != "=")
            {
                tempVal = 0;
                ResultString.Clear();
                PressedFirstTime = true;
                lastOperation = Operation;
                Operation = "";
            }

            if (currentValue == accumulator && currentValue != prevValue)
            {
                Result1.Text = accumulator.ToString();
                Result2.Text = ResultString.ToString();

            }
            else

            {
                switch (lastOperation)
                {
                    case "+":
                        accumulator += currentValue;
                        break;
                    case "-":
                        accumulator -= currentValue;
                        break;

                    case "*":
                        accumulator *= currentValue;
                        break;

                    case "/":
                        if (currentValue == 0)
                        {
                            MessageBox.Show("Error:Divided By Zero Not Permisible").ToString();
                            Result1.Text = 0.ToString();
                            ResultString.Clear();
                            Result2.Text = 0.ToString();
                            break;
                        }
                        accumulator /= currentValue;
                        break;

                    case "%":                     
                        double percent = 100;
                        double val = currentValue / percent;
                        accumulator = val;
                        break;
                    case "SqRoot":
                        accumulator = Math.Sqrt(currentValue);
                        break;

                    case "x^2":
                        accumulator = Math.Pow(accumulator, 2);
                        break;

                    case "1/x":
                        accumulator = (1 / currentValue);
                        break;

                    default: accumulator = currentValue; break;
                }


                lastOperation = Operation;
                prevValue = currentValue;

                Result1.Text = accumulator.ToString();
                Operation = "";

                ResultString.Append(accumulator + " " + lastOperation);
                Result2.Text = ResultString.ToString();

            }
        }


        private void button_Eq_Click(object sender, EventArgs e)
        {
            Result2.Text = "";
            if (prevValue == 0 && ResultString.Length == 0)
            {
                Result2.Text = "";
            }
            else

            if (double.TryParse(Result1.Text, out val2))
            {
                switch (lastOperation)
                {
                    case "+":
                        if (PressedFirstTime)
                        {
                            tempVal = Convert.ToDouble(Result1.Text);
                            PressedFirstTime = false;
                        }
                        Result2.Text = "";
                        accumulator += tempVal;
                        break;
                    case "-":
                        if (PressedFirstTime)
                        {
                            tempVal = Convert.ToDouble(Result1.Text);
                            PressedFirstTime = false;
                        }
                        Result2.Text = "";
                        accumulator -= tempVal;
                        break;
                    case "*":
                        if (PressedFirstTime)
                        {
                            tempVal = Convert.ToDouble(Result1.Text);
                            PressedFirstTime = false;
                        }
                        Result2.Text = "";
                        accumulator *= tempVal;
                        break;
                    case "/":
                        if (currentValue == 0)
                        {
                            MessageBox.Show("Error:Divided By Zero Not Permisible").ToString();
                            Result1.Text = 0.ToString();
                            ResultString.Clear();
                            Result2.Text = 0.ToString();
                            break;
                        }
                        else
                        {
                            if (PressedFirstTime)
                            {
                                tempVal = Convert.ToDouble(Result1.Text);
                                PressedFirstTime = false;
                            }
                            Result2.Text = "";
                            accumulator /= tempVal;
                        }
                        break;
                    case "%":
                      
                        double percent = 100;
                        double val = currentValue / percent;
                        accumulator = val;
                        break;
                    case "SqRoot":
                        if (PressedFirstTime)
                        {
                            tempVal = Convert.ToDouble(Result1.Text);
                            PressedFirstTime = false;

                        }
                        Result2.Text = "";
                        accumulator = Math.Sqrt(tempVal);
                        break;

                    case "x^2":
                        if (PressedFirstTime)
                        {
                            tempVal = Convert.ToDouble(Result1.Text);
                            PressedFirstTime = false;
                        }
                        Result2.Text = "";
                        accumulator = Math.Pow(tempVal, 2); break;

                    case "1/x":
                        if (PressedFirstTime)
                        {
                            tempVal = Convert.ToDouble(Result1.Text);
                        }
                        Result2.Text = "";
                        accumulator = (1 / tempVal);
                        break;

                    default: break;
                }


                ResultString.Clear();
                ResultString.Append(accumulator + " " + lastOperation + " " + tempVal);
                Result2.Text = ResultString.ToString();
                Result1.Text = accumulator.ToString();
                Operation = "";
            }

        }


        private void button_BackSpace(object sender, EventArgs e)
        {
            if (Result1.Text.Length > 0)
            {
                Result1.Text = Result1.Text.Remove(Result1.Text.Length - 1, 1);
            }
            if (Result1.Text == "")
            {
                Result1.Text = "0";
            }
        }

        private void button_Neg_Click(object sender, EventArgs e)
        {
            if (Result1.Text.Contains("-"))
            {
                Result1.Text = Result1.Text.Remove(0, 1);
                Result2.Text = Result1.Text;
            }
            else
                Result1.Text = "-" + Result1.Text;
            Result2.Text = Result1.Text;
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Result1.Text = "0";
            Result2.Text = "";
            accumulator = 0;
            PressedFirstTime = true;
            Operation = "";
            lastOperation = "";
            tempVal = 0;
            ResultString.Clear();

        }

        private void button_ClearResult_Click(object sender, EventArgs e)
        {
            Result1.Text = "0";
            Result2.Text = "";
            accumulator = 0;
            PressedFirstTime = true;
            Operation = "";
            lastOperation = "";
            tempVal = 0;
            ResultString.Clear();

        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (from == "Binary")
            {
                e.Handled = !("\b01".Contains(e.KeyChar));
            }
            else if (from == "Decimal")
            {
                e.Handled = !("\b012345678".Contains(e.KeyChar));
            }
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {

            if (from == "Decimal" && to == "Binary")
            {
                if (textBox1.Text == "")
                    MessageBox.Show("Please Enter value");
                else
                {

                    if ((textBox1.Text).Length > 8)
                    {
                        MessageBox.Show("Max Length(8) of Number Exceeds");
                        textBox1.Text = "";
                    }
                    else
                    {
                        label6.Text = "Binary No is : ";
                        int no = Convert.ToInt32(textBox1.Text);
                        string s = "";
                        int x = 0;
                        while (no != 0 || x != 1)
                        {
                            x = no % 2;
                            s = s + x.ToString();
                            no = no / 2;
                        }
                        char[] charArray = s.ToCharArray();
                        Array.Reverse(charArray);
                        string ResultString = new string(charArray);
                        textBox2.Text = ResultString;
                    }

                }


            }
            if (from == "Decimal" && to == "Decimal")
            {
                if (textBox1.Text == "")
                    MessageBox.Show("Please Enter value");
                else
                {
                    if ((textBox1.Text).Length > 8)
                    {
                        MessageBox.Show("Max Length(8) of Number Exceeds");
                        textBox1.Text = "";
                    }
                    else
                    {
                        label6.Text = "Decimal No is : ";
                        textBox2.Text = textBox1.Text;
                    }
                }
            }

            if (from == "Binary" && to == "Decimal")
            {
                int num, binary_val, decimal_val = 0, base_val = 1, rem;
                if (textBox1.Text == "")
                    MessageBox.Show("Please Enter value");
                else
                {
                    if ((textBox1.Text).Length > 8)
                    {
                        MessageBox.Show("Max Length(8) of Number Exceeds");
                        textBox1.Text = "";
                    }
                    else
                    {
                        label6.Text = "Decimal No is : ";
                        num = Convert.ToInt32(textBox1.Text);

                        binary_val = num;

                        while (num > 0)
                        {
                            rem = num % 10;
                            decimal_val = decimal_val + rem * base_val;
                            num = num / 10;
                            base_val = base_val * 2;
                        }
                        textBox2.Text = decimal_val.ToString();
                    }
                }
            }

            if (from == "Binary" && to == "Binary")
            {
                if (textBox1.Text == "")
                    MessageBox.Show("Please Enter value");
                else
                {
                   if ((textBox1.Text).Length > 8)
                    {
                        MessageBox.Show("Max Length(8) of Number Exceeds");
                        textBox1.Text = "";
                    }
                    else
                    {
                        label6.Text = "Binary No is : ";
                        textBox2.Text = textBox1.Text;
                    }
                }
            }
        }        

                private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
                {
                    from = comboBox1.SelectedItem.ToString();
                    label5.Text = comboBox1.SelectedItem.ToString() + " Number";
                    if (textBox1.Text != "")
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }

                private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
                {
                    to = comboBox2.SelectedItem.ToString();
                }
            }
        }

