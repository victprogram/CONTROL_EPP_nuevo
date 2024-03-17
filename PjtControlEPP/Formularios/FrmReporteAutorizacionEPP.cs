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
    public partial class FrmReporteAutorizacionEPP : Form
    {
        public FrmReporteAutorizacionEPP()
        {
            InitializeComponent();
        }

        private void FrmReporteAutorizacionPoliza_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportes.ReporteAutorizacion' Puede moverla o quitarla según sea necesario.
            this.reporteAutorizacionTableAdapter.Fill(this.reportes.ReporteAutorizacion);

            this.reportViewer1.RefreshReport();
        }
    }
}
