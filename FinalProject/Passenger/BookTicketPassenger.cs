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
    public partial class BookTicketPassenger : Form
    {
        public BookTicketPassenger()
        {
            InitializeComponent();
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && dateTimePicker1.Text != "" && comboBox4.Text != "")
            {




                string query = "insert into bookticket (passenger_id,booking_id,fcity,ftocity,jdate,t_name,class) values (@passenger_id,@booking_id,@fcity,@ftocity,@jdate,@t_name,@class)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("passenger_id", textBox1.Text);
                cmd.Parameters.AddWithValue("booking_id", textBox2.Text);
                cmd.Parameters.AddWithValue("fcity", comboBox1.Text);
                cmd.Parameters.AddWithValue("ftocity", comboBox2.Text);
                cmd.Parameters.AddWithValue("jdate", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("t_name", comboBox3.Text);
                cmd.Parameters.AddWithValue("class", comboBox4.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Booking done!");


                }
                else { MessageBox.Show("Error!"); }
                con.Close();
            } 
            else { MessageBox.Show("Error!"); }
        }
        
        
        
        private void BookTicketPassenger_Load(object sender, EventArgs e)
        {
            textBox1.Text = PassengerLoginInterface.id.ToString();
            SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345");
            SqlDataAdapter sda2 = new SqlDataAdapter("Select isnull (max(cast(booking_id as int)),0)+1 from bookticket", con2);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            textBox2.Text = dt2.Rows[0][0].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PassengerInterface a = new PassengerInterface();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
