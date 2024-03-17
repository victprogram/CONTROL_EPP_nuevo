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
    public partial class FrmReporteEppCategoria : Form
    {
        public FrmReporteEppCategoria()
        {
            InitializeComponent();
        }

        private void FrmReporteEppCategoria_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportes.ReporteInventario_Por_Categoria' Puede moverla o quitarla según sea necesario.
            this.reporteInventario_Por_CategoriaTableAdapter.Fill(this.reportes.ReporteInventario_Por_Categoria);

            this.reportViewer1.RefreshReport();
        }
    }
}
