using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PjtControlEPP.Formularios
{
    public partial class FrmBuscarEppFecha : Form
    {
        public FrmBuscarEppFecha()
        {
            InitializeComponent();
        }
        private MySqlConnection Cn = Datos.C;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBuscarEppFecha_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
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

                            FrmReporteEppFecha reporteEppFecha = new FrmReporteEppFecha();
                            reporteEppFecha.Show();
                      
                
        }

      
        
    }
}
