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
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
               // foreach (string Impresora in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
             //   {
                   // cbImpresora.Items.Add(Impresora);
                   // cbImpresora.SelectedIndex = 0;
                    txtNombre.Text = Datos.ConsultarValor("nombreempresa", "principal", ";");
                    txtDireccion.Text = Datos.ConsultarValor("direccionempresa", "principal", ";");
                    txtCorreo.Text = Datos.ConsultarValor("correo", "principal", ";");
                    txtCorreoAprobacion.Text = Datos.ConsultarValor("correoaprobacion", "principal", ";");
                    txtTelefono.Text = Datos.ConsultarValor("telefonoempresa", "principal", ";");
                    txtRNC.Text = Datos.ConsultarValor("rnc", "principal", ";");
                    txtUrlJsonConsulta.Text = Datos.ConsultarValor("urlconsulta", "principal", ";");
                    txtUrlJsonConsultaEmpleado.Text = Datos.ConsultarValor("urlempleado", "principal", ";");
                    txtUrlJsonSalida.Text = Datos.ConsultarValor("urlsalida", "principal", ";");


                

                  //  cbImpresora.Text = Datos.ConsultarValor("impresora", "principal", ";");
               // }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message);
                this.Close();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
          
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0)
            {
                if (txtDireccion.Text.Length > 0)
                {
                    if (txtTelefono.Text.Length > 0)
                    {
                        if (txtCorreo.Text.Length > 0)
                        {
                            if (txtCorreo.Text.Length > 0)
                            {

                                string Campo = "nombreempresa = '" + txtNombre.Text + "', direccionempresa = '" +
                                                       txtDireccion.Text + "', impresora = '" + cbImpresora.Text +
                                                       "', telefonoempresa = '" + txtTelefono.Text +
                                                       "', correo = '" + this.txtCorreo.Text +
                                                       "',correoaprobacion = '" + this.txtCorreoAprobacion.Text +
                                                       "', rnc = '" + this.txtRNC.Text +
                                                       "', urlconsulta = '" + this.txtUrlJsonConsulta.Text +
                                                       "', urlsalida = '" + this.txtUrlJsonSalida.Text +
                                                       "', urlempleado = '" + this.txtUrlJsonConsultaEmpleado.Text + "'";

                                Datos.Actualizar("principal", Campo, "Id = 1;");
                                MessageBox.Show("Datos Actualizados.");
                                Close();

                            }
                            else
                            {
                                errorProvider1.SetError(txtRNC, "Ingrese el RNC");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtCorreo, "Ingrese el Correo");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtTelefono, "Ingrese el Telefono");
                    }

                }
                else
                {
                    errorProvider1.SetError(txtDireccion, "Ingrese la Direccion");
                }
            }
            else
            {
                errorProvider1.SetError(txtNombre, "Ingrese el Nombre");
            }
        }
    }
}
