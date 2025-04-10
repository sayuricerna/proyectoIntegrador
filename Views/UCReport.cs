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

namespace proyectoIntegrador.Views
{
    public partial class UCReport : UserControl
    {
        public UCReport()
        {
            InitializeComponent();
        }

        private void btnGenReport_Click(object sender, EventArgs e)
        {
            ReportClass.Lista_personal(this);

        }

        private void btbSearchReport_Click(object sender, EventArgs e)
        {

        }

    }
}
