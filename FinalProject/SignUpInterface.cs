using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FinalProject
{
    public partial class SignUpInterface : Form
    {
        string idvalidation = @"^\d+$";
        public SignUpInterface()
        {
            InitializeComponent();
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            PassengerLoginInterface q = new PassengerLoginInterface();
            q.Show();
            this.Hide();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignUpInterface_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && textBox6.Text != "")
            {


                

                string query = "insert into Passenger (name,id, pass, phone, gender, city) values (@name,@id, @pass, @phone, @gender, @city)";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("name", textBox1.Text);
                cmd.Parameters.AddWithValue("id", textBox2.Text);
                cmd.Parameters.AddWithValue("pass", textBox3.Text);
                cmd.Parameters.AddWithValue("phone", textBox4.Text);
                cmd.Parameters.AddWithValue("gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("city", textBox6.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sign Up done!");


                }
                else { MessageBox.Show("Error!"); }
                con.Close();
            }
            else { MessageBox.Show("Error!"); }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Name Cannot Be Empty!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox2.Text, idvalidation) == false)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "ID is invalid, Try Integer Numbers");
            }
            else
            {
                errorProvider2.Clear();
            }
            
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Password Cannot Be Empty!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Phone No. Cannot Be Empty!");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) == true)
            {
                comboBox1.Focus();
                errorProvider5.SetError(this.textBox4, "Gender Cannot Be Empty!");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) == true)
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "City Cannot Be Empty!");
            }
            else
            {
                errorProvider6.Clear();
            }
        }
    }
}
