using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        String concat = "";
        List<String> list = new List<String>();
        int countDivision = 0;
        int countMultiplication = 0;
        int countAddition = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0") {
                textBox1.Clear();
            }
            //create a object button and casr the object into button
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + button.Text;
            //list.Add(textBox1.Text);
            concat = concat + button.Text;
            label1.Text = concat;
        }

        private void operator_click(object sender, EventArgs e)
        {  
            Button button = (Button)sender;
            if (button.Text == "/") {
                countDivision += 1;
            }
            else if (button.Text == "*") {
                countMultiplication += 1;
            }
            else if (button.Text == "+") {
                countAddition += 1;
            }
            concat = concat + button.Text;
            list.Add(textBox1.Text);
            textBox1.Clear();
            list.Add(button.Text);
            label1.Text = concat;
        }

        private void ce_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void c_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            concat = "";
            label1.Text = "";
            list.Clear();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            list.Add(textBox1.Text);
            textBox1.Clear();
            
            for (int j = 0; j < list.Count; j++)
            {
                int i = 0;
                while (i < list.Count && list.Count >= 3 )
                {
                    String obj = list[i];
                    Double r = 0;
                  
                    if (obj == "/")
                    {
                        r = Convert.ToDouble(list[i - 1]) / Convert.ToDouble(list[i + 1]);
                        list[i - 1] = Convert.ToString(r);
                        list.RemoveAt(i);
                        list.RemoveAt(i);
                        countDivision -= 1;
                    }
                    else if (obj == "*" && countDivision == 0)
                    {
                        r = Convert.ToDouble(list[i - 1]) * Convert.ToDouble(list[i + 1]);
                       
                        list[i - 1] = Convert.ToString(r);
                        list.RemoveAt(i);
                        list.RemoveAt(i);
                        countMultiplication -= 1;
                    }
                    else if (obj == "+" && countMultiplication == 0)
                    {
                        r = Convert.ToDouble(list[i - 1]) + Convert.ToDouble(list[i + 1]);
                        list[i - 1] = Convert.ToString(r);
                        list.RemoveAt(i);
                        list.RemoveAt(i);
                        countAddition -= 1; 
                    }
                    else if (obj == "-" && countMultiplication == 0)
                    {
                         r = Convert.ToDouble(list[i - 1]) - Convert.ToDouble(list[i + 1]);
                         list[i - 1] = Convert.ToString(r);
                         list.RemoveAt(i);
                         list.RemoveAt(i);
                    }
                    i++;
                }
            }
            for (int j = 0; j < list.Count; j++) {

                label1.Text = label1.Text + " = " + list[j];
            }
            textBox1.Clear();     
        }      
    }
}
