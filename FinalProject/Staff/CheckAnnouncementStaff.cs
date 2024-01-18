﻿using System;
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
    public partial class CheckAnnouncementStaff : Form
    {
        public CheckAnnouncementStaff()
        {
            InitializeComponent();
        }

        private void CheckAnnouncementStaff_Load(object sender, EventArgs e)
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
            StaffInterface a = new StaffInterface();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
