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
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace PjtControlEPP.Formularios
{
    public partial class FrmConsultaEmpleados : Form
    {
        public FrmConsultaEmpleados()
        {
            InitializeComponent();
        }

        public string Idempleado;
        public string Nombre;
        public string Apellido;
        public string Cedula;
        public string Oracleid;
        public string Area;
        public string Ocupacion;
        public string nombrepo;
        public string Seleccion = "Null";

        private MySqlConnection Cn = Datos.C;

        private void FrmConsultaEmpleados_Load(object sender, EventArgs e)
        {

            string urljsonConsulta = Datos.Consultar3("urlempleado", "principal", "where id=1").Rows[0][0].ToString();


            WebClient wc = new WebClient();

            var datos = wc.DownloadString(urljsonConsulta);

            var rs = JsonConvert.DeserializeObject<repuestaEmpleado>(datos);

            foreach (var item in rs.Rows)
            {
                dtgEmpleados.Rows.Add(item.codigo,item.otrocodigo, item.cedula, item.nombres, item.apellidos,item.cargo_nombre, item.dpto_nombre, item.tel1);
            }


            
         
        }

        //private void CargarEmpleados()
        //{
        //    DataTable dt = new DataTable();

        //    string Cadena = "SELECT empleados.idempleado, empleados.nombre, empleados.apellido, empleados.telefono, empleados.cedula, empleados.oracleid, area.nombrearea, po.NombrePO FROM empleados INNER JOIN area ON empleados.idarea = area.idarea INNER JOIN po ON empleados.idPO = po.idPO order by empleados.idempleado asc";

        //    MySqlCommand cmd = new MySqlCommand(Cadena, Cn);
        //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //    da.Fill(dt);

        //    dtgEmpleados.DataSource = dt;

        //}



        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void dtgEmpleados_DoubleClick(object sender, EventArgs e)
        {
            if (dtgEmpleados.CurrentRow != null)
            {


                try
                {
                    Idempleado = dtgEmpleados.CurrentRow.Cells["idempleado"].Value.ToString();
                    Cedula = dtgEmpleados.CurrentRow.Cells["cedula"].Value.ToString();
                    Oracleid = dtgEmpleados.CurrentRow.Cells["OracleID"].Value.ToString();
                    Nombre = dtgEmpleados.CurrentRow.Cells["nombre"].Value.ToString();
                    Apellido = dtgEmpleados.CurrentRow.Cells["apellido"].Value.ToString();
                    Ocupacion = dtgEmpleados.CurrentRow.Cells["ocupacion"].Value.ToString();
                    Area = dtgEmpleados.CurrentRow.Cells["nombrearea"].Value.ToString();




                    Seleccion = "S";
                    Close();


                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(
                        "ES POSIBLE QUE ESTE FALTANDO ALGUNA INFORMACION DEL EMPLEADO. FAVOR REVISAR LAS COLUMNA "+ex.Message);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
