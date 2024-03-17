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
    public partial class FrmReporteEppFecha : Form
    {
        public FrmReporteEppFecha()
        {
            InitializeComponent();
        }

        private void FrmReporteEppFecha_Load(object sender, EventArgs e)
        {
           
        }

        private void FrmReporteEppFecha_Load_1(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportes1.facturaeppfecha' Puede moverla o quitarla según sea necesario.
            this.facturaeppfechaTableAdapter1.Fill(this.reportes1.facturaeppfecha);

            this.reportViewer2.RefreshReport();
        }
    }
}
