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
    public partial class FrmBuscarEppFechaPlano : Form
    {
        public FrmBuscarEppFechaPlano()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmBuscarEppFechaPlano_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string fechaInicio = DtpInicio.Value.ToString("yyy/MM/dd");
            string fechaFinal = DtpFinal.Value.ToString("yyy/MM/dd");


            string campos = "fechainicio = '" + fechaInicio + "', fechafinal = '" + fechaFinal + "'";

            Datos.Actualizar("fecha", campos, "Id=1");


            Close();

            FrmReporteEppFechaPlano reporteEppFechaPlano = new FrmReporteEppFechaPlano();
            reporteEppFechaPlano.Show();
        }
    }
}
