using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectoIntegrador.Helpers;
using proyectoIntegrador.Views.Administration;

namespace proyectoIntegrador.Views
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            if (Session.IdUsuario == 0)
            {
                MessageBox.Show("No hay sesión activa. Por favor inicie sesión.");
                this.Close(); // O redirigir al formulario de login
                return;
            }
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
            UCReport uCReports = new UCReport();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Session.IdUsuario = 0; // O el valor que utilices para indicar que no hay sesión

            Application.Restart();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); //Evitar que quede en debugging al cerrar

        }
    }
}
