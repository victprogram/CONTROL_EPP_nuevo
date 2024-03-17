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
    public partial class FrmReportesAutorizacionPorArea : Form
    {
        public FrmReportesAutorizacionPorArea()
        {
            InitializeComponent();
        }

        private void FrmReportesAutorizacionPorArea_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportes.ReporteAutorizacionPorArea' Puede moverla o quitarla según sea necesario.
            this.reporteAutorizacionPorAreaTableAdapter.Fill(this.reportes.ReporteAutorizacionPorArea);

            this.reportViewer1.RefreshReport();
        }
    }
}
