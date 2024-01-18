using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class AdminInterface : Form
    {
        public AdminInterface()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TrainRouteAdmin a = new TrainRouteAdmin();
            a.Show();
            this.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.Show();
            this.Hide();
        }

        private void AdminInterface_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManageStaffSalaryAdmin a = new ManageStaffSalaryAdmin();
            a.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AnnouncementAdmin a = new AnnouncementAdmin();
            a.Show();
            this.Hide();
        }
    }
}
