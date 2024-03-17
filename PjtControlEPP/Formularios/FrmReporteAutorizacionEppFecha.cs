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
    public partial class FrmReporteAutorizacionEppFecha : Form
    {
        public FrmReporteAutorizacionEppFecha()
        {
            InitializeComponent();
        }

        private void FrmReporteAutorizacionEppFecha_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportes.ReporteAutorizacionPorFecha' Puede moverla o quitarla según sea necesario.
            this.reporteAutorizacionPorFechaTableAdapter.Fill(this.reportes.ReporteAutorizacionPorFecha);

            this.reportViewer1.RefreshReport();
        }
    }
}
