﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoIntegrador.Views
{
    public partial class UCAttendance : UserControl
    {
        public UCAttendance()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Attendance.frmJustification frmJustification = new Attendance.frmJustification();
            frmJustification.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
