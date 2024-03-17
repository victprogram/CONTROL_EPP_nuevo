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
    public partial class FrmReporteAutorizacionPorEmpleado : Form
    {
        public FrmReporteAutorizacionPorEmpleado()
        {
            InitializeComponent();
        }

        private void FrmReporteAutorizacionPorEmpleado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportes.ReporteAutorizacionPorEmpleado' Puede moverla o quitarla según sea necesario.
            this.reporteAutorizacionPorEmpleadoTableAdapter.Fill(this.reportes.ReporteAutorizacionPorEmpleado);

            this.reportViewer1.RefreshReport();
        }
    }
}
