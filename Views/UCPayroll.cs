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
    public partial class UCPayroll : UserControl
    {
        public UCPayroll()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Payroll.frmAdvanceP frmAdvanceP = new Payroll.frmAdvanceP();
            frmAdvanceP.ShowDialog();
        }

        private void UCPayroll_Load(object sender, EventArgs e)
        {

        }
    }
}
