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
            LoadGridAttedance(2);
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
            for (int i = 0; i < dgvAttendance.Rows.Count; i++)
            {
                dgvAttendance.Rows[i].Cells[0].Value = i + 1;
            }
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
                dgvAttendance.DataSource = logica.GetAllView();
            }
            else
            {
                dgvAttendance.DataSource = logica.SearchView(txtSearch.Text.Trim());
            }
            dgvAttendance.Columns["idAsistencia"].Visible = false;
            dgvAttendance.Columns["idEmpleado"].Visible = false;
            dgvAttendance.Columns["nombreEmpleado"].HeaderText = "Empleado";
            dgvAttendance.Columns["fecha"].HeaderText = "Fecha";
            dgvAttendance.Columns["horaEntrada"].HeaderText = "Hora Entrada";
            dgvAttendance.Columns["horaSalida"].HeaderText = "Hora Salida";
            dgvAttendance.Columns["horasTrabajadasTiempo"].HeaderText = "Horas Trabajadas";
            dgvAttendance.Columns["horasSuplementariasTiempo"].HeaderText = "Horas Suplementarias";
            dgvAttendance.Columns["horasExtrasTiempo"].HeaderText = "Horas Extraordinarias";
            dgvAttendance.Columns["horasNOTrabajadasTiempo"].HeaderText = "Horas NO trabajadas";
            dgvAttendance.Columns["justificadoStr"].HeaderText = "Justificado";
            dgvAttendance.Columns["MotivoJustificacion"].HeaderText = "Motivo";
            dgvAttendance.Columns["DetalleJustificacion"].HeaderText = "Detalle de Justificación";

            dgvAttendance.ColumnHeadersDefaultCellStyle.Font = new Font(dgvAttendance.Font, FontStyle.Bold);

        }

        private void dgvAttendance_Leave(object sender, EventArgs e)
        {

        }


        private void UCAttendance_Leave(object sender, EventArgs e)
        {

        }

        //modo asistencia
        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                var controller = new attendance_controller();
                int userID = FingerprintHelper.UserIDForAttendance();

                if (userID != -1)
                {
                    controller.InsertAttendance(userID);
                }
                else
                {
                    // Mostrar un mensaje en la UI debe hacerse en el hilo principal
                    MessageBox.Show("No se pudo detectar la huella.");
                }
            });

            // Una vez termina la asistencia, recarga la tabla
            LoadGridAttedance(1);

            //var controller = new attendance_controller();
            //int userID = FingerprintHelper.UserIDForAttendance();
            //if (userID != -1)
            //{
            //    controller.InsertAttendance(userID);
            //}
            //else
            //{
            //    Console.WriteLine("No se pudo detectar la huella.");

            //}
        }

        private void dgvAttendance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoadGridAttedance(2);

        }
    }
}
