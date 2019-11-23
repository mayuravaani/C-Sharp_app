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
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; password=; database=smsdb;");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register regi = new Register();
            regi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String regno = textBox1.Text;
            String password = textBox2.Text;

            connection.Open();
            String query = "select count(*) from student where regno = '"+ regno + "' and password = '"+ password + "';";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                String query1 = "select name from student;";
                MySqlCommand cmd = new MySqlCommand(query1, connection);
                MySqlDataReader myReader = cmd.ExecuteReader();
                myReader.Read();
                String sname = myReader.GetString("name");
                
                this.Hide();
                main form2 = new main();
                form2.Show();
                form2.label2.Text = sname;
            }
            else {
                MessageBox.Show("check");
            }
                connection.Close();
        
        }
    }
}
