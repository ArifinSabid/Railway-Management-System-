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
    public partial class ManageStaffSalaryAdmin : Form
    {
        public ManageStaffSalaryAdmin()
        {
            InitializeComponent();
        }

        private void ManageStaffSalaryAdmin_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select *FROM staffSalary";
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
            if (textBox3.Text != "")
            {
                string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                SqlConnection con = new SqlConnection(connectionString);
                string query = "select *from staffSalary where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("id", textBox3.Text);
                

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                int Id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                int salary = Convert.ToInt32(dt.Rows[0]["salary"].ToString());



                textBox1.Text = Id.ToString();
                textBox2.Text = salary.ToString();



            }
            else
            {
                MessageBox.Show("Please Enter Your ID & PassWord");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("update staffSalary set salary=@salary where id=@id", connection);


            connection.Open();
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@salary", textBox2.Text);
            

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Update successful !");
                string connectionString2 = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                SqlConnection con = new SqlConnection(connectionString2);
                string query = "select *FROM staffSalary";
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
    }
}
        
