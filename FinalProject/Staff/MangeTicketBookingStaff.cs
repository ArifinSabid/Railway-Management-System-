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
    public partial class MangeTicketBookingStaff : Form
    {
        public MangeTicketBookingStaff()
        {
            InitializeComponent();
        }

        private void MangeTicketBookingStaff_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select *FROM bookticket";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string connectionString1 = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con1 = new SqlConnection(connectionString1);
            string query1 = "select *FROM approved_booking";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con1);
            DataTable data1 = new DataTable();
            sda1.Fill(data1);
            dataGridView2.DataSource = data1;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (textBox1.Text != "")
            {




                string query = "insert into approved_booking (passenger_id,booking_id, fcity, ftocity, jdate,t_name, class) values (@passenger_id,@booking_id, @fcity, @ftocity, @jdate,@t_name, @class)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("passenger_id", textBox2.Text);
                cmd.Parameters.AddWithValue("booking_id", textBox3.Text);
                cmd.Parameters.AddWithValue("fcity", textBox4.Text);
                cmd.Parameters.AddWithValue("ftocity", textBox5.Text);
                cmd.Parameters.AddWithValue("jdate", textBox6.Text);
                cmd.Parameters.AddWithValue("t_name", textBox8.Text);
                cmd.Parameters.AddWithValue("class", textBox7.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    {
                        string connectionString2 = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                        SqlConnection connection = new SqlConnection(connectionString2);

                        SqlCommand cmd1 = new SqlCommand("delete bookticket where booking_id=@booking_id", connection);


                        connection.Open();
                        cmd1.Parameters.AddWithValue("@booking_id", textBox3.Text);


                        int a = cmd1.ExecuteNonQuery();
                        if (a > 0)
                        {

                            MessageBox.Show("Moved to Approved!");
                            textBox2.Clear();
                            string connectionString3 = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                            SqlConnection con3 = new SqlConnection(connectionString3);
                            string query3 = "select *FROM bookticket";
                            SqlDataAdapter sda = new SqlDataAdapter(query3, con3);
                            DataTable data = new DataTable();
                            sda.Fill(data);
                            dataGridView1.DataSource = data;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        }

                        else
                        {
                            MessageBox.Show("Approve failed!", "Enter valid information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        connection.Close();
                    }





                    MessageBox.Show("Approve done!");
                    string connectionString1 = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                    SqlConnection con1 = new SqlConnection(connectionString1);
                    string query1 = "select *FROM approved_booking";
                    SqlDataAdapter sda1 = new SqlDataAdapter(query1, con1);
                    DataTable data1 = new DataTable();
                    sda1.Fill(data1);
                    dataGridView2.DataSource = data1;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                }
                else { MessageBox.Show("Error!"); }
                con.Close();
            }
            else { MessageBox.Show("Error!"); }
        }

        private void button2_Click(object sender, EventArgs e)



        {
            if (textBox1.Text != "")
            {

                string connectionString = "Data Source=DESKTOP-LRRMEMO;Initial Catalog=FinalProject;Persist Security Info=True;User ID=sa;Password=12345";
                SqlConnection con = new SqlConnection(connectionString);
                string query = "select *from bookticket where booking_id = @booking_id";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("booking_id", textBox1.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);

                int passenger_id = Convert.ToInt32(dt.Rows[0]["passenger_id"].ToString());
                int booking_id = Convert.ToInt32(dt.Rows[0]["booking_id"].ToString());
                string fcity = dt.Rows[0]["fcity"].ToString();
                string ftocity = dt.Rows[0]["ftocity"].ToString();
                string jdate = dt.Rows[0]["jdate"].ToString();
                string t_name = dt.Rows[0]["t_name"].ToString();
                string classes = dt.Rows[0]["class"].ToString();



                textBox2.Text = passenger_id.ToString();
                textBox3.Text = booking_id.ToString();
                textBox4.Text = fcity;
                textBox5.Text = ftocity;
                textBox6.Text = jdate;
                textBox8.Text = t_name;
                textBox7.Text = classes;


            }

            else

            {
                MessageBox.Show("Please Enter correct Information");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

   
