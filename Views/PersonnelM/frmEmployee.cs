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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace proyectoIntegrador.Views.PersonnelM
{
    public partial class frmEmployee : Form
    {
        public bool modoEdision = false;
        public int id = 0;
        public frmEmployee(string modo)
        {
            InitializeComponent();
            if (modo != "n")
            {
                this.modoEdision = true;
                this.id = int.Parse(modo);
            }
        }
        public void loadDpt()
        {
            var list = new department_controller();
            cmbDpt.DataSource = list.GetAllDepartments();
            cmbDpt.ValueMember = "IdDepartamento";
            cmbDpt.DisplayMember = "NombreDepartamento";
        }
        public void loadPosition()
        {
            var listaestudiantes = new estudiante_controller();
            cmbEstudiantes.DataSource = listaestudiantes.ObtenerTodos();
            cmbEstudiantes.ValueMember = "IdEstudiante";
            cmbEstudiantes.DisplayMember = "Cedula";
            cmbEstudiantes.SelectedIndexChanged += new EventHandler(cmbEstudiantes_SelectedIndexChanged);

        }



    }
}