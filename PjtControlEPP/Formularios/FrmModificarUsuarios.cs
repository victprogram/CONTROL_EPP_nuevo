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
    public partial class FrmModificarUsuarios : Form
    {
        public FrmModificarUsuarios()
        {
            InitializeComponent();
        }
        private MySqlConnection C = Datos.C;
        public Int32 ResiveDatos;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0)
            {
                if (txtApellido.Text.Length > 0)
                {
                    if (txtIdUsuario.Text.Length > 0)
                    {
                        if (txtClave.Text.Length > 0)
                        {

                            string campos = "nombre='" + this.txtNombre.Text + "',apellido='" + this.txtApellido.Text +
                                            "',usuario='" +
                                            this.txtUsuario.Text + "',clave='" + this.txtClave.Text + "',cargo='" +
                                            this.cmbCargo.Text + "',correo='" +
                                            this.txtCorreo.Text + "'";


                            if (Datos.Actualizar("usuarios", campos, "idusuario=" + ResiveDatos))
                            {
                                MessageBox.Show("El usuario se modifico con exito");
                                this.Close();
                                FrmUsuarios usuario = new FrmUsuarios();
                                usuario.Show();
                            }
                            else
                            {
                                MessageBox.Show("Error almodificar los datos");
                            }


                        }
                        else
                        {
                            errorProvider1.SetError(txtClave, "ingrese la clave");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtIdUsuario, "ingrese el usuario");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtApellido, "ingrese el apellido");
                }
            }
        }

        private void FrmModificarUsuarios_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from usuarios where idusuario=" + ResiveDatos, C);
            C.Open();
            MySqlDataReader leer = cmd.ExecuteReader();

            if (leer != null && leer.Read())
            {
                txtIdUsuario.Text = leer.GetInt32(0).ToString();
                txtNombre.Text = leer.GetString(1);
                txtApellido.Text = leer.GetString(2);
                txtUsuario.Text = leer.GetString(3);
                txtClave.Text = leer.GetString(4);
                cmbCargo.Text = leer.GetString(5);
                txtCorreo.Text = leer.GetString(6);


            }
            else
            {
                MessageBox.Show("Error al leer los datosdel usuario");
                C.Close();
            }

            C.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmUsuarios usuario = new FrmUsuarios();
            usuario.Show();
        }
    }
}
