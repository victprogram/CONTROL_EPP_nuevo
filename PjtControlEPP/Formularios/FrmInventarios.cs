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
    public partial class FrmInventarios : Form
    {
        public FrmInventarios()
        {
            InitializeComponent();
        }
        private MySqlConnection C = Datos.C;
        private void FrmInventarios_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void cargarProductos()
        {
            Datos.Consultar("select idproducto,marca,nombreproducto,idcategoria,cantidad,tiempovida from inventario", "inventario");
            dtgProductos.DataSource = Datos.ds.Tables["inventario"];
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            FrmRegistrarProductos productos=new FrmRegistrarProductos();
            productos.Show();
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmModificarProductos modificarproductos = new FrmModificarProductos();

            if (dtgProductos.CurrentRow != null)
            {
                Int32 selecionado = (Int32)dtgProductos.CurrentRow.Cells["idproducto"].Value;
                modificarproductos.ResiveDatos = selecionado;
                modificarproductos.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("el usuario no esta selecionado");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Desea Eliminar el EPP", "AVISO", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            else
            {
                if (dtgProductos.CurrentRow != null &&
                    (Datos.Eliminar("inventario", "idproducto=" + dtgProductos.CurrentRow.Cells["idproducto"].Value)))
                {
                    MessageBox.Show("EPP fue eliminado");
                    cargarProductos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el EPP");
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            string consulta = "select idproducto,marca,nombreproducto,idcategoria,cantidad,tiempovida from inventario";
            C.Open();
            BindingSource origen = new BindingSource();
            MySqlDataAdapter dt = new MySqlDataAdapter(consulta, C);
            System.Data.DataTable datatable = new DataTable();
            dt.Fill(datatable);
            origen.DataSource = datatable;
            this.dtgProductos.DataSource = origen;
            origen.Filter = "nombreproducto LIKE '%" + txtBuscar.Text + "%'";
            C.Close();
        }


    }
}
