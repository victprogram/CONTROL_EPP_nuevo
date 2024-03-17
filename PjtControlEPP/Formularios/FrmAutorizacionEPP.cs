using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PjtControlEPP.Formularios
{
    public partial class FrmAutorizacionEPP : Form
    {
        public FrmAutorizacionEPP()
        {
            InitializeComponent();
        }
        private MySqlConnection C = Datos.C;
         private double Cant_;
        private string idempleado;
        private int IdP;
        private string numeroR;
        public string idusuario;
        private string cargo;
       

       
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (cargo == "MODERADOR")
            {
                FrmConsultaEmpeadoPorUsuario empleados = new FrmConsultaEmpeadoPorUsuario();

                empleados.ShowDialog();

                if (empleados.Seleccion == "S")
                {
                    idempleado = empleados.Idempleado;
                    txtNombreEmpleado.Text = empleados.Nombre;
                    txtApellido.Text = empleados.Apellido;
                    txtCedula.Text = empleados.Cedula;
                    txtArea.Text = empleados.Area;
                    txtOracleID.Text = empleados.Oracleid;

                }
            }
            else
            {
                FrmConsultaEmpleados empleados = new FrmConsultaEmpleados();

                empleados.ShowDialog();

                if (empleados.Seleccion == "S")
                {
                    idempleado = empleados.Idempleado;
                    txtNombreEmpleado.Text = empleados.Nombre;
                    txtApellido.Text = empleados.Apellido;
                    txtCedula.Text = empleados.Cedula;
                    txtArea.Text = empleados.Area;

                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
           
            
            if (txtNombreEmpleado.Text.Length>0)
            {
                 FrmConsultaInventario Producto = new FrmConsultaInventario();
            
                if (Producto.ShowDialog() == DialogResult.OK)
                {
                    txtidproducto.Text = Producto.idproducto;
                    IdP = Int32.Parse(Producto.idproducto);


                    string fecha = Datos.Consultar3("fechavence", "detallesfacturas", "where detallesfacturas.idproducto="+Producto.idproducto).Rows[0][0].ToString();

                    
                    MySqlCommand cmd = new MySqlCommand("Select cantidad from inventario where idproducto=" + IdP, C);
                    C.Open();
                    MySqlDataReader leer = cmd.ExecuteReader();
                    
                    if (leer.Read())
                    {

                        int Cnt = leer.GetInt32(0);
                        Cant_ = Cnt;
                        C.Close();
                        if (Cant_ > 0)
                        {
                          
                            txtNombreEPP.Text = Producto.nombreproducto;
                            txtFechaVence.Text = fecha;


                        }
                        else
                        {
                            MessageBox.Show("La Cantidad Esta en  :  " + Cant_ + "  Favor revise sus Stock ");
                            C.Close();



                        }

                    }

                }
            }
            else
            {
                MessageBox.Show("primero debe de selecionar el empleado");
            }

        }


      

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string fecha = dtpFecha.Value.ToString("yyy/MM/dd");
            txtCodigoConsulta.Text = Datos.ConsultarValor("codigoautorizacion", "autorizacionepp", "where autorizacionepp.codigoautorizacion='" + txtCodigoautorizacion.Text + "'");

            if (txtCodigoConsulta.Text == txtCodigoautorizacion.Text)
            {
                MessageBox.Show("El codigo ingresado ya existe,favor ingresar uno diferente");
                txtCodigoautorizacion.Clear();

                txtCodigoautorizacion.Focus();
               
                return;

            }
            else
            {
                if (txtNombreEmpleado.Text.Length > 0)
                {
                    if (txtCodigoautorizacion.Text.Length > 0)
                    {
                        if (txtNombreEPP.Text.Length > 0)
                        {
                            if (txtObservacion.Text.Length > 0)
                            {
                                string sql =
                                    "insert into autorizacionepp(fechaautorizacion,idusuario,idempleado,idproducto,fechavence,codigoautorizacion,observacion) values('" +
                                    fecha + "','" +
                                    idusuario + "','" +
                                    idempleado + "','" + txtidproducto.Text + "','" +
                                    this.txtFechaVence.Text + "','" + this.txtCodigoautorizacion.Text + "','" +
                                    this.txtObservacion.Text + "')";
                                if (Datos.Insertar(sql))
                                {
                                        txtMensaje.Text +=" Autorización del empleado: " + txtNombreEmpleado.Text + " " + txtApellido.Text + " \r\n ";
                                        txtMensaje.Text +=" Portador de la cedula: " + txtCedula.Text +  " \r\n ";
                                        txtMensaje.Text += " OracleID: " + txtOracleID.Text + " \r\n ";
                                        txtMensaje.Text += "Perteneciente al area: " + txtArea.Text + " \r\n ";
                                        txtMensaje.Text += "Solicita: " + txtNombreEPP.Text + " \r\n ";
                                        txtMensaje.Text += "Dicho EPP vence en fecha de: " + txtFechaVence.Text + " \r\n ";
                                        txtMensaje.Text += "CODIGO DE AUTOIZACION ES: " + txtCodigoautorizacion.Text + " \r\n ";
                                        txtMensaje.Text += "Observación: " + txtObservacion.Text + " \r\n ";


                                    panel1.Visible = true;

                                }
                                else
                                {
                                    MessageBox.Show("Error al registrar usuario");
                                }

                                string campos1 = "codigoautorizacion = '" + this.txtCodigoautorizacion.Text + "'";

                                Datos.Actualizar("fecha", campos1, "Id=1");



                            }
                            else
                            {
                                errorProvider1.SetError(txtObservacion, "Favor ingresar la Observación");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtNombreEPP, "Favor ingresar el EPP");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtCodigoautorizacion, "Favor ingresar el Codigo de Autorización");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNombreEmpleado,"Favor ingresar el empleado");
                }

            }


           
        }

        private void txtCodigoautorizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;

                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                    MessageBox.Show("Solo se Apcetan Numeros");
                }
        }

        private void FrmAutorizacionEPP_Load(object sender, EventArgs e)
        {

            string correo = Datos.Consultar3("correo", "usuarios", "where idusuario="+ idusuario).Rows[0][0].ToString();

            string cargo1 = Datos.Consultar3("cargo", "usuarios", "where idusuario=" + idusuario).Rows[0][0].ToString();
            cargo = cargo1;

            txtDe.Text = correo;


            StringBuilder builder = new StringBuilder();
            
            Random random = new Random();
            int ch;
            for (int i = 0; i < 4; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            txtCodigoautorizacion.Text = builder.ToString();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Correos Cr = new Correos();
                MailMessage mnsj = new MailMessage();

                mnsj.Subject = txtasunto.Text;

                mnsj.To.Add(new MailAddress(txtPara.Text));

                mnsj.CC.Add(new MailAddress(txtCopia.Text) );

                mnsj.From = new MailAddress(txtDe.Text, txtDe.Text);

                /* Si deseamos Adjuntar algún archivo*/
              //  mnsj.Attachments.Add(new Attachment("C:\\archivo.pdf"));

                mnsj.Body = txtMensaje.Text;

                /* Enviar */
                Cr.MandarCorreo(mnsj);
               // Enviado = true;

                panel1.Visible = false;

                MessageBox.Show("El Mail se ha Enviado Correctamente", "Listo!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                FrmReporteAutorizacionEPP autorizacionPoliza = new FrmReporteAutorizacionEPP();
                autorizacionPoliza.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                FrmReporteAutorizacionEPP autorizacionPoliza = new FrmReporteAutorizacionEPP();
                autorizacionPoliza.Show();

                panel1.Visible = false;

                //  this.Close();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

            FrmReporteAutorizacionEPP autorizacionPoliza = new FrmReporteAutorizacionEPP();
            autorizacionPoliza.Show();

            panel1.Visible = false;
            this.Close();
        }
    }
}
