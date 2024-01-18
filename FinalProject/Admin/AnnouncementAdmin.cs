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
    public partial class AnnouncementAdmin : Form
    {
        public AnnouncementAdmin()
        {
            InitializeComponent();
        }

        private void AnnouncementAdmin_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select *FROM AnnouncementAdmin";
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
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (textBox1.Text != "" && dateTimePicker1.Text != "")
            {




                string query = "insert into AnnouncementAdmin (date, announcement) values (@date, @announcement)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("announcement", textBox1.Text);
               
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Submit done!");
                    string connectionString2 = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                    SqlConnection con2 = new SqlConnection(connectionString2);
                    string query1 = "select *FROM AnnouncementAdmin";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, con2);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                }
                else { MessageBox.Show("Error!"); }
                con.Close();
            }
            else { MessageBox.Show("Error!"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
   
