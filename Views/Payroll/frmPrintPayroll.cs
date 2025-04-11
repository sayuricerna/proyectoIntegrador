using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectoIntegrador.Views.Reports;

namespace proyectoIntegrador.Views.Payroll
{
    public partial class frmPrintPayroll : Form
    {
        private int idRol;

        public frmPrintPayroll(int idRol)
        {
            InitializeComponent();
            this.idRol = idRol;

        }

        private void frmPrintPayroll_Load(object sender, EventArgs e)
        {

            PayrollClass.showPayrollforPrint(this, idRol); // Usamos la variable que ya guardamos
            this.reportViewerPayroll.RefreshReport();
        }
    }
}
