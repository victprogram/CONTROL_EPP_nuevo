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
    public partial class FrmReporteEppFechaPlano : Form
    {
        public FrmReporteEppFechaPlano()
        {
            InitializeComponent();
        }

        private void FrmReporteEppFechaPlano_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportes.reporteeppplano' Puede moverla o quitarla según sea necesario.
            this.reporteeppplanoTableAdapter.Fill(this.reportes.reporteeppplano);

            this.reportViewer1.RefreshReport();
        }
    }
}
