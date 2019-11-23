using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SMS
{
    public partial class Register : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; password=; database=smsdb;");
        String gender;
        String subject;
        public Register()
        {
            InitializeComponent();
            fillCombo();
        }

        void fillCombo() {
            connection.Open();
            String query = "select * from district;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read()) {
                String s = myReader.GetString("dname");
                comboBox1.Items.Add(s);
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String regno = textBox1.Text;
            String name = textBox2.Text;
            String des = richTextBox1.Text;
            String password = textBox3.Text;
            String dname = comboBox1.Text;
            
            connection.Open();

            String query1 = "select did from district where dname = '" + dname +"';";
            MySqlCommand cmd1 = new MySqlCommand(query1, connection);
            MySqlDataReader myReader1 = cmd1.ExecuteReader();
            myReader1.Read();
            int dsid  = myReader1.GetInt16("did");
            myReader1.Close();

            String query2 = "select sid from subject where sname = '" + subject + "';";
            MySqlCommand cmd2 = new MySqlCommand(query2, connection);
            myReader1 = cmd2.ExecuteReader();
            myReader1.Read();
            int sid = myReader1.GetInt16("sid");
            myReader1.Close();


            String query = string.Format("insert into student values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}' )", regno, name, gender, dsid, sid, password);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MessageBox.Show("signed up");
            connection.Close();
            Form1 f = new Form1();
            this.Hide();
            f.Show();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "female";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            subject = "csc";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            subject = "stats";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            subject = "maths";
        }

       

      


        
    }
}
