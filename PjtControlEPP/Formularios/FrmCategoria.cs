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
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Datos.Consultar("Select * from categoria", "categoria");
            this.dtgCategoria.DataSource = Datos.ds.Tables["categoria"];
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreCategoria.Text.Length > 0)
            {

                string ruta = "Insert into categoria(nombrecategoria) values('" + this.txtNombreCategoria.Text + "')";

                if (Datos.Insertar(ruta))
                {
                    txtNombreCategoria.Clear();
                    CargarDatos();
                    txtNombreCategoria.Focus();

                }
                else
                {
                    MessageBox.Show("Error al ingresar los datos");
                }
            }
            else
            {
                MessageBox.Show("Deve ingresar el Grupo");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Desea eliminar el grupo seleccionado?", "AVISO", MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                if (dtgCategoria.CurrentRow != null)
                {
                    if (Datos.Eliminar("categoria", "idcategoria=" + dtgCategoria.CurrentRow.Cells["idcategoria"].Value))
                    {
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Algo salio mal.....");
                    }
                }
                else
                {
                    MessageBox.Show("tiene que seleccional la categoria para  eliminar");
                }
            }
            else
            {
                return;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmModificarCategoria modificarCategoria = new FrmModificarCategoria();

            if (dtgCategoria.CurrentRow != null)
            {
                Int32 selecionado = (Int32)dtgCategoria.CurrentRow.Cells["idcategoria"].Value;
                modificarCategoria.RecibeDatos = selecionado;

            }
            else
            {
                MessageBox.Show("Selecione la Categoria a modificar");
            }
            modificarCategoria.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
