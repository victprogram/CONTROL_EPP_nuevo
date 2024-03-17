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
    public partial class FrmRegistroUsuario : Form
    {
        public FrmRegistroUsuario()
        {
            InitializeComponent();
        }

        private void FrmRegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0)
            {
                if (txtApellido.Text.Length > 0)
                {
                    if (txtUsuario.Text.Length > 0)
                    {
                        if (txtClave.Text.Length > 0)
                        {
                            if (cmbCargo.Text.Length > 0)
                            {


                                string sql = "insert into usuarios(nombre,apellido,usuario,clave,cargo,correo) values('" +
                                    this.txtNombre.Text + "','" + this.txtApellido.Text + "','" +
                                    this.txtUsuario.Text + "','" + this.txtClave.Text + "','" + this.cmbCargo.Text + "','" + this.txtCorreo.Text + "')";
                                if (Datos.Insertar(sql))
                                {


                                    DialogResult res = MessageBox.Show(@"Desea Ingresar un nuevo usuario?", @"REGISTRO INSERTADO",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (res == DialogResult.Yes)
                                    {
                                        txtNombre.Clear();
                                        txtApellido.Clear();
                                        txtClave.Clear();
                                        txtUsuario.Clear();
                                        txtNombre.Focus();
                                        return;


                                    }
                                    else
                                    {
                                        this.Close();
                                        FrmUsuarios usuario = new FrmUsuarios();
                                        usuario.Show();

                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Error al registrar usuario");
                                }

                            }
                            else
                            {
                                errorProvider1.SetError(cmbCargo, "Ingrese el Cargo");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtClave, "Ingrese la clave");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtUsuario, "Ingrese el usuario");
                    }

                }
                else
                {
                    errorProvider1.SetError(txtApellido, "Ingrese el apellido");
                }
            }
            else
            {
                errorProvider1.SetError(txtNombre, "Ingrese el nombre");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmUsuarios usuario = new FrmUsuarios();
            usuario.Show();
        }
    }
}
