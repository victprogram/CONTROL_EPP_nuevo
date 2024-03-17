using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace PjtControlEPP.Formularios
{
    public partial class FrmBuscarAutorizacionEmpleado : Form
    {
        public FrmBuscarAutorizacionEmpleado()
        {
            InitializeComponent();
        }
        private MySqlConnection cnn = Datos.C;
        private void FrmBuscarAutorizacionEmpleado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'consultas.filtroempleadoepp' Puede moverla o quitarla según sea necesario.
            this.filtroempleadoeppTableAdapter.Fill(this.consultas.filtroempleadoepp);

            //string urljsonConsulta = Datos.Consultar3("urlempleado", "principal", "where id=1").Rows[0][0].ToString();
            
            //WebClient wc = new WebClient();

            //var datos = wc.DownloadString(urljsonConsulta);

            //var rs = JsonConvert.DeserializeObject<repuestaEmpleado>(datos);

            
            //foreach (var item in rs.Rows)
            //{
               
            //    dtgEmpleado.Rows.Add(item.codigo, item.nombres, item.apellidos, item.cedula);
            //}
            
            
            
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
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

            string idempleado = dtgEmpleado.CurrentRow.Cells["idempleado"].Value.ToString();

            string campos = "fechainicio = '" + fechaInicio + "', fechafinal = '" + fechaFinal +
                            "', idempleado= '" + idempleado + "'";

            Datos.Actualizar("fecha", campos, "Id=1");


            Close();

            FrmReporteAutorizacionPorEmpleado reporteAutorizacionPorEmpleado=new FrmReporteAutorizacionPorEmpleado();
            reporteAutorizacionPorEmpleado.Show();

        }
    }
}
