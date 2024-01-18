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
    public partial class PassengerInterface : Form
    {
        public PassengerInterface()
        {
            InitializeComponent();
        }

        private void PassengerInterface_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookTicketPassenger a = new BookTicketPassenger();
            a.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TrainInformationPassenger a = new TrainInformationPassenger();
            a.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckAnnouncementPassenger a = new CheckAnnouncementPassenger();
            a.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
