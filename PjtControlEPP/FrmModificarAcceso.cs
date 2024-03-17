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

namespace PjtControlEPP
{
    public partial class FrmModificarAcceso : Form
    {
        public FrmModificarAcceso()
        {
            InitializeComponent();
        }

        private MySqlConnection C = Datos.C;
        public Int32 ResiveDatos;
        private string claveUsuario;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtClaveAnterior.Text == claveUsuario)
            {
                if (txtClaveNueva.Text.Length > 0)
                {
                    if (txtRepetirClave.Text.Length > 0)
                    {
                        if (txtRepetirClave.Text == txtClaveNueva.Text)
                        {
                            string campos = "clave='" + txtClaveNueva.Text + "',tipo='" + 1 + "'";


                            if (Datos.Actualizar("usuarios", campos, "idusuario=" + ResiveDatos))
                            {
                                MessageBox.Show("Contraseña fue cambiada de manera exitosa.");
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Error almodificar los datos");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Las Contraseñas no son iguales");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe de reperir la Contraseña nueva");
                    }
                }
                else
                {
                    MessageBox.Show("Debe de ingresar la Contraseña nueva");
                }
            }
            else
            {
                MessageBox.Show("Contraseña anterior ingresada no es valida");
            }
        }

        private void FrmModificarAcceso_Load(object sender, EventArgs e)
        {
            C.Close();

            claveUsuario = Datos.Consultar3("clave", "usuarios", "where idusuario=" + ResiveDatos).Rows[0][0].ToString();

            txtIdusuario.Text = ResiveDatos.ToString();
        }
    }
}
