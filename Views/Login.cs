using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectoIntegrador.Controllers;
using proyectoIntegrador.Helpers;

namespace proyectoIntegrador.Views
{
    public partial class Login : Form
    {
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
