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
    public partial class FrmReporteInventario : Form
    {
        public FrmReporteInventario()
        {
            InitializeComponent();
        }

        private void FrmReporteInventario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportes.ReporteInventario' Puede moverla o quitarla según sea necesario.
            this.reporteInventarioTableAdapter.Fill(this.reportes.ReporteInventario);

            this.reportViewer1.RefreshReport();
        }
    }
}
