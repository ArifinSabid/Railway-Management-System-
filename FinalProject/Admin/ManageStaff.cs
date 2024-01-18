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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select *FROM ManageStaffAdmin";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminInterface a = new AdminInterface();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                SqlConnection con = new SqlConnection(connectionString);
                string query = "select *from ManageStaffAdmin where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("id", textBox6.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);

                string name = dt.Rows[0]["name"].ToString();
                int Id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                string phone = dt.Rows[0]["phone"].ToString();
                string gender = dt.Rows[0]["gender"].ToString();
                string city = dt.Rows[0]["city"].ToString();

                textBox1.Text = name;
                textBox2.Text = Id.ToString();
                textBox3.Text = phone;
                textBox4.Text = gender;
                textBox5.Text = city;

            }
            else
            {
                MessageBox.Show("Please Enter Your ID & PassWord");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("update ManageStaffAdmin set name=@name, phone=@pn, gender=@gender, city=@cn where id=@id", connection);


            connection.Open();
            cmd.Parameters.AddWithValue("@id", textBox2.Text);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@pn", textBox3.Text);
            cmd.Parameters.AddWithValue("@gender", textBox4.Text);
            cmd.Parameters.AddWithValue("@cn", textBox5.Text);

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Update successful !");
                string connectionString2 = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                SqlConnection con = new SqlConnection(connectionString2);
                string query = "select *FROM ManageStaffAdmin";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }

            else
            {
                MessageBox.Show("Update failed!", "Enter valid information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("delete ManageStaffAdmin where id=@id", connection);


            connection.Open();
            cmd.Parameters.AddWithValue("@id", textBox2.Text);


            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {

                MessageBox.Show("DELETED!");
                string connectionString3 = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                SqlConnection con = new SqlConnection(connectionString3);
                string query = "select *FROM ManageStaffAdmin";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                textBox2.Clear();

            }

            else
            {
                MessageBox.Show("Delete failed!", "Enter valid information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
