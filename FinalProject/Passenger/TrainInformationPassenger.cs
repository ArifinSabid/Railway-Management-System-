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
    public partial class TrainInformationPassenger : Form
    {
        public TrainInformationPassenger()
        {
            InitializeComponent();
        }

        private void TrainInformationPassenger_Load(object sender, EventArgs e)
        {

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
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            else
            {
                MessageBox.Show("Please Enter Your ID & PassWord");
            }
        }
    }
}
