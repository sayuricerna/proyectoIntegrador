using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectoIntegrador.Config;
using proyectoIntegrador.Controllers;
using proyectoIntegrador.Helpers;

namespace proyectoIntegrador.Views
{
    public partial class Login : Form
    {
        private readonly connection _connection = new connection();

        public Login()
        {
            InitializeComponent();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            user_controler controller = new user_controler();
            encryptP encrypt = new encryptP();
            var usuario = controller.GetAll().FirstOrDefault(u => u.NombreUsuario == username && u.Estado);

            if (usuario != null)
            {
                bool isValid = encrypt.VerifyPassword(password, usuario.Contrasenia);

                if (isValid)
                {
                    // Registrar auditoría de ingreso
                    using (var conn = _connection.GetConnection())
                    {
                        conn.Open();
                        AuditHelper.RegistrarAuditoria(conn, usuario.IdUsuario, "LOGIN", "Usuario", "Usuario ha iniciado sesión");
                    }

                    Session.IdUsuario = usuario.IdUsuario;
                    Session.NombreUsuario = usuario.NombreUsuario;
                    Session.RolUsuario = usuario.RolUsuario;
                    Session.IdEmpleado = usuario.IdEmpleado;
                    Session.NombreEmpleado = usuario.NombreEmpleado;

                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Usuario no encontrado o inactivo", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false; // Muestra el texto normal
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true; // Muestra los puntos
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
