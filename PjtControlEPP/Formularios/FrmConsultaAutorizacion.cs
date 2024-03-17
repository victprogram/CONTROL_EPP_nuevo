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
    public partial class FrmConsultaAutorizacion : Form
    {
        public FrmConsultaAutorizacion()
        {
            InitializeComponent();
        }

        private void FrmConsultaAutorizacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'consultas.consultaautorizacion' Puede moverla o quitarla según sea necesario.
            this.consultaautorizacionTableAdapter.Fill(this.consultas.consultaautorizacion);
           
          
           
          

        }

        private void dtgEPP_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void dtgEPP_DoubleClick_1(object sender, EventArgs e)
        {
            string idfactura = dtgEPP.CurrentRow.Cells["codigoautorizacion"].Value.ToString();

            string campos = "codigoautorizacion = '" + idfactura + "'";

            Datos.Actualizar("fecha", campos, "Id=1");


            FrmReporteAutorizacionEPP autorizacionEpp = new FrmReporteAutorizacionEPP();
            autorizacionEpp.Show();
        }
    }
}
