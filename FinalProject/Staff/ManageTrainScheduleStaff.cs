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
    public partial class ManageTrainScheduleStaff : Form
    {
        public ManageTrainScheduleStaff()
        {
            InitializeComponent();
        }

        private void ManageTrainScheduleStaff_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select *FROM t_info";
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
            if (comboBox1.Text != "")
            {
                string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                SqlConnection con = new SqlConnection(connectionString);
                string query = "select *from t_info where train_name = @train_name";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("train_name", comboBox1.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);

                string train_name = dt.Rows[0]["train_name"].ToString();
                string departure = dt.Rows[0]["departure"].ToString();
                string station_1 = dt.Rows[0]["station_1"].ToString();
                string station_2 = dt.Rows[0]["station_2"].ToString();
                string station_3 = dt.Rows[0]["station_3"].ToString();
                string arrival = dt.Rows[0]["arrival"].ToString();

                textBox1.Text = train_name;
                textBox2.Text = departure;
                textBox3.Text = station_1;
                textBox4.Text = station_2;
                textBox5.Text = station_3;
                textBox6.Text = arrival;

            }
            else
            {
                MessageBox.Show("Please Enter correct information");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("update t_info set departure=@departure, station_1=@station_1, station_2=@station_2, station_3=@station_3,arrival=@arrival where train_name=@train_name", connection);


            connection.Open();
            cmd.Parameters.AddWithValue("@train_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@departure", textBox2.Text);
            cmd.Parameters.AddWithValue("@station_1", textBox3.Text);
            cmd.Parameters.AddWithValue("@station_2", textBox4.Text);
            cmd.Parameters.AddWithValue("@station_3", textBox5.Text);
            cmd.Parameters.AddWithValue("@arrival", textBox6.Text);

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Update successful !");
                string connectionString2 = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                SqlConnection con = new SqlConnection(connectionString2);
                string query = "select *FROM t_info";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
