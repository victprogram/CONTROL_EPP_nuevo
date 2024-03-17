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
    public partial class FrmEjemploReporte : Form
    {
        public FrmEjemploReporte()
        {
            InitializeComponent();
        }

        private void FrmEjemploReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportes.FacturaPorArea' Puede moverla o quitarla según sea necesario.
            this.facturaPorAreaTableAdapter.Fill(this.reportes.FacturaPorArea);

            this.reportViewer1.RefreshReport();
        }
    }
}
