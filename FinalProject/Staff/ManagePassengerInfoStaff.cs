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
    public partial class ManagePassengerInfoStaff : Form
    {
        public ManagePassengerInfoStaff()
        {
            InitializeComponent();
        }

        private void ManagePassengerInfoStaff_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select name,id,phone,gender,city FROM Passenger";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StaffInterface a = new StaffInterface();
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
                string query = "select *from Passenger where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("id", textBox6.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);

                string name = dt.Rows[0]["name"].ToString();
                int id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                string phone = dt.Rows[0]["phone"].ToString();
                string gender = dt.Rows[0]["gender"].ToString();
                string city = dt.Rows[0]["city"].ToString();

                textBox1.Text = name;
                textBox2.Text = id.ToString();
                textBox3.Text = phone;
                textBox4.Text = gender;
                textBox5.Text = city;

            }
            else
            {
                MessageBox.Show("Please Enter correct ID");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("update Passenger set name=@name, phone=@phone, gender=@gender, city=@city where id=@id", connection);


            connection.Open();
            cmd.Parameters.AddWithValue("@id", textBox2.Text);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@gender", textBox4.Text);
            cmd.Parameters.AddWithValue("@city", textBox5.Text);

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Update successful !");
                string connectionString2 = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                SqlConnection con = new SqlConnection(connectionString2);
                string query = "select name,id,phone,gender,city FROM Passenger";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
