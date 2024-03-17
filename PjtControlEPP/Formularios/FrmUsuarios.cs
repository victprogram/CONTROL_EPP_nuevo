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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }
        private MySqlConnection C = Datos.C;
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            Cargarusuario();
        }

        private void Cargarusuario()
        {
            Datos.Consultar("select idusuario,concat(nombre,' ',apellido) as nombre,usuario,cargo,correo from usuarios", "usuarios");
            dtgUsuario.DataSource = Datos.ds.Tables["usuarios"];

        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            FrmRegistroUsuario ingresarusuario = new FrmRegistroUsuario();
            ingresarusuario.Show();
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmModificarUsuarios modificarusuario = new FrmModificarUsuarios();

            if (dtgUsuario.CurrentRow != null)
            {
                Int32 selecionado = (Int32)dtgUsuario.CurrentRow.Cells["idusuario"].Value;
                modificarusuario.ResiveDatos = selecionado;
                modificarusuario.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("el usuario no esta selecionado");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Desea Eliminar el usuario", "AVISO", MessageBoxButtons.YesNo,
             MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            else
            {
                if (dtgUsuario.CurrentRow != null &&
                    (Datos.Eliminar("usuarios", "idusuario=" + dtgUsuario.CurrentRow.Cells["idusuario"].Value)))
                {
                    MessageBox.Show("Usuario fue eliminado");
                    Cargarusuario();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario");
                }
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            string consulta = "select idusuario,concat(nombre,' ',apellido) as nombre,usuario,cargo,correo from usuarios";
            C.Open();
            BindingSource origen = new BindingSource();
            MySqlDataAdapter dt = new MySqlDataAdapter(consulta, C);
            System.Data.DataTable datatable = new DataTable();
            dt.Fill(datatable);
            origen.DataSource = datatable;
            this.dtgUsuario.DataSource = origen;
            origen.Filter = "nombre LIKE '%" + txtBuscar.Text + "%'";
            C.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
