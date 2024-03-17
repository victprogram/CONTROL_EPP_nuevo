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
    public partial class FrmBuscarAurorizacionporArea : Form
    {
        public FrmBuscarAurorizacionporArea()
        {
            InitializeComponent();
        }
        private MySqlConnection Cn = Datos.C;


     
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBuscarAurorizacionporArea_Load(object sender, EventArgs e)
        {


            
            MySqlCommand cmd2 = new MySqlCommand("Select distinct AreaTrabajo from facturas", Cn);

            Cn.Open();



            MySqlDataReader leer2 = cmd2.ExecuteReader();
            while (leer2 != null && leer2.Read())
            {
                CmbArea.Items.Add(leer2.GetString(leer2.GetOrdinal("AreaTrabajo")));
            }



            Cn.Close();


            //string urljsonConsulta = Datos.Consultar3("urlempleado", "principal", "where id=1").Rows[0][0].ToString();

            //WebClient wc = new WebClient();

            //var datos = wc.DownloadString(urljsonConsulta);

            //var rs = JsonConvert.DeserializeObject<repuestaEmpleado>(datos);


          
            //foreach (var item in rs.Rows)
            //{

            //    if (!CmbArea.Items.Contains(item.dpto_nombre))
            //    {
            //        CmbArea.Items.Add(item.dpto_nombre);
            //    }
               
               
            //}



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
            string area = CmbArea.Text;

            if (CmbArea.Text.Length > 0)
            {
                string campos = "nombrearea= '" + area + "'";

                Datos.Actualizar("fecha", campos, "Id=1");

                Close();

                FrmReportesAutorizacionPorArea autorizacionPorArea = new FrmReportesAutorizacionPorArea();
                autorizacionPorArea.Show();
            }
            else
            {
               txtError.Text="Favor de seleccionar el Nombre del Area";
            }
        }
    }
}
