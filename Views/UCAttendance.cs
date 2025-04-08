using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectoIntegrador.Controllers;
using proyectoIntegrador.Helpers;

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

        private void dgvAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAttendance_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
        private void UCAttendance_Load(object sender, EventArgs e)

        {
            LoadGridAttedance(1);
            
            /*

                        if (userID != -1)
                        {
                            controller.InsertAttendance(userID);
                        }
                        else
                        {
                            Console.WriteLine("No se pudo detectar la huella.");
                        }*/

            /*
            var user_id = FingerprintHelper.UserIDForAttendance();
            if (user_id == -1)
            {
                Console.WriteLine("error no esta en el sensor");
            }
            else
            {
                var controller = new employee_controller();
                var existe = controller.FingerprintExists(user_id);
                if (existe)
                {
                    var controllerA = new attendance_controller();
                    var result = controllerA.InsertAttendance(user_id);
                    Console.WriteLine(user_id);

                    LoadGridAttedance(2);
                    Console.WriteLine("Match");
                }
                else
                {
                    Console.WriteLine("no existe coincidencia");
                }
            }


            */
        }
        public void LoadGridAttedance(int numero)
        {
            dgvAttendance.DataSource = null;
            dgvAttendance.Rows.Clear();
            dgvAttendance.Columns.Clear();

            var logica = new attendance_controller();

            var autoincremento = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            dgvAttendance.Columns.Add(autoincremento);

            if (numero == 1)
            {
                dgvAttendance.DataSource = logica.GetAll();
            }
            else
            {
                dgvAttendance.DataSource = logica.SearchByEmployee(txtSearch.Text.Trim());
            }
            dgvAttendance.Columns["idAsistencia"].HeaderText = "ID";
            dgvAttendance.Columns["idEmpleado"].HeaderText = "EMPLEADO";
            dgvAttendance.Columns["fecha"].HeaderText = "FECHA";
            dgvAttendance.Columns["horaEntrada"].HeaderText = "ENTRADA";
            dgvAttendance.Columns["horaSalida"].HeaderText = "SALIDA";
            dgvAttendance.Columns["Justificado"].HeaderText = "JUSTIFICADO";
        }

        private void dgvAttendance_Leave(object sender, EventArgs e)
        {

        }


        private void UCAttendance_Leave(object sender, EventArgs e)
        {

        }

        //modo asistencia
        private void button1_Click(object sender, EventArgs e)
        {
            
            var controller = new attendance_controller();
            int userID = FingerprintHelper.UserIDForAttendance();
            if (userID != -1)
            {
                controller.InsertAttendance(userID);
            }
            else
            {
                Console.WriteLine("No se pudo detectar la huella.");

            }
        }

    }
}
