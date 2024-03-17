using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PjtControlEPP.Formularios
{
    public partial class FrmPrincial : Form
    {
        public FrmPrincial()
        {
            InitializeComponent();
        }

        private MySqlConnection C = Datos.C;
        private string enviaidusuario;
        private string nombreusuario;

        private void FrmPrincial_Load(object sender, EventArgs e)
        {
            //lblApellido.Focus();

            FrmLogin login = new FrmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                lblNombre.Text = login.Nombre;
                lblApellido.Text = login.Apellido;
                lblCargo.Text = login.Cargo;
                enviaidusuario = login.idusuario;
                nombreusuario = login.Usuario;

                //   txtUsuario.Text = "" + lblNombre.Text + " " + lblApellido.Text + " Tiene Acceso de: " + lblCargo.Text + "";


                //FrmModificarDestachoEPP MSalida = new FrmModificarDestachoEPP();
                //MSalida.IdUsuario = enviaidusuario;
                //MSalida.nombreusuario = nombreusuario;
                //MSalida.ShowDialog();



                try
                {
                    string nombre = "" + lblNombre.Text + " " + lblApellido.Text + "";

                    DateTime fechaingreso = DateTime.Now;
                    string fi = fechaingreso.ToString(CultureInfo.InvariantCulture);


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                //   ADMINISTRADOR
                //   MODERADOR
                //  AUTORIZADOR

                if (lblCargo.Text == "CONSULTA")
                {
               
                    usuariosToolStripMenuItem.Enabled = false;
                    SistemaTool.Enabled = false;
                    autorizacionToolStripMenuItem.Enabled = false;
                    registrosToolStripMenuItem.Enabled = false;
                    usuariosToolStripMenuItem.Enabled = false;
                    autorizacionesToolStripMenuItem.Enabled = false;
                   // empleadosToolStripMenuItem1.Enabled = false;
           
                    archivosToolStripMenuItem.Enabled = false;



                }

                if (lblCargo.Text == "MODERADOR")
                {
                    configuraciónToolStripMenuItem.Enabled = false;
                    usuariosToolStripMenuItem.Enabled = false;
                    modificarSalidaEPPToolStripMenuItem.Enabled = false;



                }
                if (lblCargo.Text == "AUTORIZADOR")
                {
                    registrosToolStripMenuItem.Enabled = false;
                    usuariosToolStripMenuItem.Enabled = false;
                    configuraciónToolStripMenuItem.Enabled = false;


                   // despachoToolStripMenuItem.Enabled = false;
                    respachoToolStripMenuItem.Enabled = false;
                   // inventarioToolStripMenuItem1.Enabled = false;
                    empleadosToolStripMenuItem1.Enabled = false;
                 //   facturasToolStripMenuItem.Enabled = false;
                    modificarSalidaEPPToolStripMenuItem.Enabled = false;


                }


            }
            else
            {
                this.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios usuarios = new FrmUsuarios();
            usuarios.Show();
        }

        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inventarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultaInventario consultaInventario = new FrmConsultaInventario();
            consultaInventario.Show();
        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultaEmpleados consultaEmpleados = new FrmConsultaEmpleados();
            consultaEmpleados.Show();
        }

        private void respachoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDestachoEPP destachoProductos = new FrmDestachoEPP();
            destachoProductos.IdUsuario = enviaidusuario;
            destachoProductos.nombreusuario = nombreusuario;
            destachoProductos.ShowDialog();
        }

        private void autorizarEPPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConfiguracion configuracion = new FrmConfiguracion();
            configuracion.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaDespachoEPP consultaDespachoEpp = new FrmConsultaDespachoEPP();
            consultaDespachoEpp.ShowDialog();
        }

        private void iDToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void autorizacionEPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaAutorizacion consultaAutorizacion = new FrmConsultaAutorizacion();
            consultaAutorizacion.Show();
        }

        private void empleadosToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void eppToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void porCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void porMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void porFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarEppFecha buscarEppFecha = new FrmBuscarEppFecha();
            buscarEppFecha.Show();
        }

        private void porAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarDespachoEppArea despachoEppArea = new FrmBuscarDespachoEppArea();
            despachoEppArea.Show();
        }

        private void porEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarEppEmpleado eppEmpleado = new FrmBuscarEppEmpleado();
            eppEmpleado.Show();
        }

        private void porFechaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBuscarAutorizacionFecha autorizacionFecha = new FrmBuscarAutorizacionFecha();
            autorizacionFecha.Show();
        }

        private void porEmpleadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBuscarAutorizacionEmpleado autorizacionEmpleado = new FrmBuscarAutorizacionEmpleado();
            autorizacionEmpleado.Show();
        }

        private void modificarDespachoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModificarDespacho modificarDespacho = new FrmModificarDespacho();
            modificarDespacho.Show();
        }

        private void pOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPo po = new FrmPo();
            po.Show();
        }

        private void porFechaPlanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarEppFechaPlano buscarEppFechaPlano = new FrmBuscarEppFechaPlano();
            buscarEppFechaPlano.Show();
        }

        private void porAreaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBuscarAurorizacionporArea aurorizacionporArea = new FrmBuscarAurorizacionporArea();
            aurorizacionporArea.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                C.Open();
                if (C != null && C.State == ConnectionState.Open)
                {
                    conetado.Visible = true;
                    desconetado.Visible = false;
                }
            }
            catch (Exception ex)
            {
                conetado.Visible = false;
                desconetado.Visible = true;
            }




            C.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void autorizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaAutorizacion consultaAutorizacion = new FrmConsultaAutorizacion();
            consultaAutorizacion.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            UpdateCheckInfo inf;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                try
                {
                    inf = ad.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException dde)
                {

                    return;
                }

                if (inf.UpdateAvailable)
                {
                    if (MessageBox.Show("HAY UNA NUEVA ACTUALIZACION, DESEA INSTALAR AHORA. ASI ACEPTA SE VA A REINCIIAR EL SISTEMA", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {


                        try
                        {


                            ad.Update();
                            Application.Restart();


                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("No fue posible Actualizar. Error: " + ex.Message);
                        }



                    }
                    else
                    {
                        return;
                    }
                }
            }  
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
           
        }

        private void modificarSalidaEPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModificarDestachoEPP MSalida = new FrmModificarDestachoEPP();
            MSalida.IdUsuario = enviaidusuario;
            MSalida.nombreusuario = nombreusuario;
            MSalida.ShowDialog();
        }

        private void eJEMPLOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEjemploReporte ejemplo= new FrmEjemploReporte();
            ejemplo.Show();
        }

      
       

        
    }
}
