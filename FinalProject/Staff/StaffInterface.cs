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
    public partial class StaffInterface : Form
    {
        public StaffInterface()
        {
            InitializeComponent();
        }

        private void StaffInterface_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MangeTicketBookingStaff a = new MangeTicketBookingStaff();
            a.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagePassengerInfoStaff a = new ManagePassengerInfoStaff();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManageTrainScheduleStaff a = new ManageTrainScheduleStaff();
            a.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckAnnouncementStaff a = new CheckAnnouncementStaff();
            a.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
