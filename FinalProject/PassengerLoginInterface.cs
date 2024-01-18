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

namespace FinalProject
{
    public partial class PassengerLoginInterface : Form
    {
        public PassengerLoginInterface()
        {
            InitializeComponent();
        }
        public static int id;

        private void button4_Click(object sender, EventArgs e)
        {
            SignUpInterface a = new SignUpInterface();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                SqlConnection connection = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand("select *FROM Passenger WHERE id = @id and pass = @pass", connection);

                connection.Open();
                cmd.Parameters.Add(new SqlParameter("id", textBox1.Text));
                cmd.Parameters.Add(new SqlParameter("pass", textBox2.Text));

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    PassengerInterface a = new PassengerInterface();
                    a.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Log in failed,doesn't match ID or Password", "Enter correct information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("Please insert your correct ID & Password");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "ID Cannot Be Empty!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Password Cannot Be Empty!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void PassengerLoginInterface_Load(object sender, EventArgs e)
        {

        }
    }
}
   