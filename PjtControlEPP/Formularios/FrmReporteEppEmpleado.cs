using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PjtControlEPP.Formularios
{
    public partial class FrmReporteEppEmpleado : Form
    {
        public FrmReporteEppEmpleado()
        {
            InitializeComponent();
        }

        private void FrmReporteEppEmpleado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportes.facturaeppporempleado' Puede moverla o quitarla según sea necesario.
            this.facturaeppporempleadoTableAdapter.Fill(this.reportes.facturaeppporempleado);

            this.reportViewer1.RefreshReport();
        }
    }
}
