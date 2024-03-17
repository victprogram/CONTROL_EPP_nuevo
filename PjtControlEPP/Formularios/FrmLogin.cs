using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PjtControlEPP.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }


        #region Drag Form/ Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        #endregion 



        private MySqlConnection C = Datos.C;
        public string idusuario, Nombre, Apellido, Usuario, Cargo, Clave, Estado, Tipo;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarusuario();
        }

        private void cargarusuario()
        {
            if (txtUsuario.Text.Length > 0)
            {
                if (txtClave.Text.Length > 0)
                {

                    MySqlCommand cmd = new MySqlCommand("select idusuario,nombre,apellido,usuario,clave,cargo,estado,tipo from usuarios where usuario='"+txtUsuario.Text+"' and clave='"+txtClave.Text+"'", C);

                    try
                    {
                        C.Open();
                        MySqlDataReader leer = cmd.ExecuteReader();
                        if (leer.Read())
                        {

                            idusuario = leer.GetInt32(0).ToString();
                            Nombre = leer.GetString(1).ToString();
                            Apellido = leer.GetString(2).ToString();
                            Usuario = leer.GetString(3).ToString();
                            Clave = leer.GetString(4).ToString();
                            Cargo = leer.GetString(5).ToString();
                            Estado = leer.GetString(6).ToString();
                            Tipo = leer.GetString(7).ToString();


                            if (Usuario == txtUsuario.Text)
                            {
                                if (Clave == txtClave.Text)
                                {
                                    if (Tipo == "1")
                                    {
                                        if (Estado == "1")
                                        {
                                            C.Close();

                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                            C.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("USUARIO ESTA DESABILITADO");
                                        }
                                    }
                                    else
                                    {
                                        FrmModificarAcceso modificarAcceso = new FrmModificarAcceso();

                                        txtClave.Clear();
                                        Int32 selecionado = Int32.Parse(idusuario);
                                        modificarAcceso.ResiveDatos = selecionado;
                                        modificarAcceso.Show();


                                    }
                                }
                                else
                                {
                                    MessageBox.Show("CONTRASEÑA INCORRECTA");
                                }

                            }
                            else
                            {
                                MessageBox.Show("USUARIO INCORRECTO");
                            }




                        }

                        else
                        {
                            MessageBox.Show("Error al ingresar los datos");
                            C.Close();
                        }
                        C.Close();

                    }
                    catch (Exception)
                    {

                        MessageBox.Show(" Ohhh algo anda mal... Revice su conexion, es posible que no este conectando al Servidor. Si el problema continua favor contactar con el administrador de sistema");
                    }


                }
                else
                {
                    errorProvider1.SetError(txtClave, "Ingrese la Clave");
                }
            }
            else
            {
                errorProvider1.SetError(txtUsuario, "Ingrese el usuario");
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int) Keys.Enter)
            {
                cargarusuario();
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {

                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {

                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.Black;
            }
        }


        
 

        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "CONTRASEÑA")
            {

                txtClave.Text = "";
                txtClave.PasswordChar = '*';
                txtClave.ForeColor = Color.Black;
                txtClave.UseSystemPasswordChar = true;

            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {

                txtClave.Text = "CONTRASEÑA";
                txtClave.ForeColor = Color.Black;
                txtClave.UseSystemPasswordChar = false;

            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            cargarusuario();
        }

        private void txtClave_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                cargarusuario();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        long sizeOfUpdate = 0;

        private void UpdateApplication()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                ad.CheckForUpdateCompleted += new CheckForUpdateCompletedEventHandler(ad_CheckForUpdateCompleted);
                ad.CheckForUpdateProgressChanged += new DeploymentProgressChangedEventHandler(ad_CheckForUpdateProgressChanged);

                ad.CheckForUpdateAsync();
            }
        }

        void ad_CheckForUpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {



            downloadStatus.Text = String.Format("descargando: {0}. {1:D}K de {2:D}K descargado.", GetProgressString(e.State), e.BytesCompleted / 1024, e.BytesTotal / 1024);
        }

        string GetProgressString(DeploymentProgressState state)
        {
            if (state == DeploymentProgressState.DownloadingApplicationFiles)
            {
                return "application files";
            }
            else if (state == DeploymentProgressState.DownloadingApplicationInformation)
            {
                return "application manifest";
            }
            else
            {
                return "deployment manifest";
            }
        }

        void ad_CheckForUpdateCompleted(object sender, CheckForUpdateCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("ERROR: No se pudo recuperar la nueva versión de la aplicación. Razón: \n" + e.Error.Message + "\nInforme este error al administrador del sistema..");
                return;
            }
            else if (e.Cancelled == true)
            {
                MessageBox.Show("La actualización fue cancelada.");
            }

            // Ask the user if they would like to update the application now.
            if (e.UpdateAvailable)
            {
                sizeOfUpdate = e.UpdateSizeBytes;

                if (!e.IsUpdateRequired)
                {
                    DialogResult dr = MessageBox.Show("Hay disponible una actualización. ¿Desea actualizar la aplicación ahora? \n\nTiempo estimado de descarga: ", "Actualización disponible", MessageBoxButtons.OKCancel);
                    if (DialogResult.OK == dr)
                    {
                        downloadStatus.Visible = true;
                        BeginUpdate();
                    }
                }
                else
                {
                    MessageBox.Show("Una actualización obligatoria está disponible para su aplicación. Instalaremos la actualización ahora, después de lo cual guardaremos todos sus datos en curso y reiniciaremos su aplicación.");
                    BeginUpdate();
                }
            }
        }

        private void BeginUpdate()
        {
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            ad.UpdateCompleted += new AsyncCompletedEventHandler(ad_UpdateCompleted);

            // Indicate progress in the application's status bar.
            ad.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(ad_UpdateProgressChanged);
            ad.UpdateAsync();
        }

        void ad_UpdateProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            String progressText = String.Format("{0:D}K descargado de {1:D}K - {2:D}% completo", e.BytesCompleted / 1024, e.BytesTotal / 1024, e.ProgressPercentage);
            downloadStatus.Text = progressText;
        }

        void ad_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Se canceló la actualización de la última versión de la aplicación.");
                return;
            }
            else if (e.Error != null)
            {
                MessageBox.Show("ERROR: No se pudo instalar la última versión de la aplicación. Razón: \n" + e.Error.Message + "\nInforme este error al administrador del sistema..");
                return;
            }

            DialogResult dr = MessageBox.Show("La aplicación ha sido actualizada. Desea reiniciar? (Si no reinicia ahora, la nueva versión no entrará en vigor hasta que cierre y vuelva a iniciar la aplicación.)", "Reiniciar aplicación", MessageBoxButtons.OKCancel);
            if (DialogResult.OK == dr)
            {
                Application.Restart();
            }
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {

            UpdateApplication();


            //UpdateCheckInfo inf;
            //if (ApplicationDeployment.IsNetworkDeployed)
            //{
            //    ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            //    try
            //    {
            //        inf = ad.CheckForDetailedUpdate();
            //    }
            //    catch (DeploymentDownloadException dde)
            //    {

            //        return;
            //    }

            //    if (inf.UpdateAvailable)
            //    {
            //        if (MessageBox.Show("HAY UNA NUEVA ACTUALIZACION, ACEPTE PARA INSTALAR", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            //        {


            //            try
            //            {
            //                btnlogin.Enabled = true;

            //                ad.Update();
            //                Application.Restart();


            //            }
            //            catch (Exception ex)
            //            {

            //                MessageBox.Show("No fue posible Actualizar. Error: " + ex.Message);
            //            }

                    

            //        }
            //        else
            //        {
            //            btnlogin.Enabled = false;
            //        }
            //    }
            //}   
        }
    }
}
