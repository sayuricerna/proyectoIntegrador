using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Evita redimensionamiento
            this.MaximizeBox = false; // Deshabilita el botón de maximizar
            this.MinimizeBox = false; // (Opcional) Deshabilita minimizar
            this.StartPosition = FormStartPosition.CenterScreen; // Centra la ventana

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
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
