using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectoIntegrador.Views.Administration;

namespace proyectoIntegrador.Views
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            UCDashboard uCDashboard = new UCDashboard();
            pnlGeneral.Controls.Clear();
            uCDashboard.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(uCDashboard);
            this.WindowState = FormWindowState.Maximized; // Abre en pantalla completa

        }

        private void btnAsistencias_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UCPersonnelM uCPersonnelM = new UCPersonnelM();
            pnlGeneral.Controls.Clear();
            uCPersonnelM.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(uCPersonnelM);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UCAttendance uCAttendance = new UCAttendance();
            pnlGeneral.Controls.Clear();
            uCAttendance.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(uCAttendance);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UCPayroll uCPayroll = new UCPayroll();
            pnlGeneral.Controls.Clear();
            uCPayroll.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(uCPayroll);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UCReports uCReports = new UCReports();
            pnlGeneral.Controls.Clear();
            uCReports.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(uCReports);
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            UCAudits uCAudits = new UCAudits();
            pnlGeneral.Controls.Clear();
            uCAudits.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(uCAudits);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UCDashboard uCDashboard = new UCDashboard();   
            pnlGeneral.Controls.Clear();
            uCDashboard.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(uCDashboard);

        }
    }
}
