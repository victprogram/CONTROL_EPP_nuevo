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
    public partial class FrmReciboEPP : Form
    {
        public FrmReciboEPP()
        {
            InitializeComponent();
        }

        private void FrmReciboEPP_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'reportes.FacturaEPP' Puede moverla o quitarla según sea necesario.
            this.facturaEPPTableAdapter.Fill(this.reportes.FacturaEPP);

            this.reportViewer1.RefreshReport();
        }
    }
}
