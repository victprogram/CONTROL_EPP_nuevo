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
    public partial class FrmArea : Form
    {
        public FrmArea()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreArea.Text.Length > 0)
            {

                string sql = "Insert into area(nombrearea) values('" + this.txtNombreArea.Text + "')";

                if (Datos.Insertar(sql))
                {
                    txtNombreArea.Clear();
                    CargarDatos();

                }
                else
                {
                    MessageBox.Show("Error al ingresar los datos");
                }
            }
            else
            {
                MessageBox.Show("Deve ingresar el Area");
            }
        }

        private void FrmArea_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Datos.Consultar("Select * from area", "area");
            this.dtgArea.DataSource = Datos.ds.Tables["area"];
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmModificarArea modificarArea = new FrmModificarArea();

            if (dtgArea.CurrentRow != null)
            {
                Int32 selecionado = (Int32)dtgArea.CurrentRow.Cells["idarea"].Value;
                modificarArea.RecibeDatos = selecionado;

            }
            else
            {
                MessageBox.Show("Selecione el Area a modificar");
            }
            modificarArea.Show();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Desea eliminar el Area seleccionado?", "AVISO", MessageBoxButtons.YesNo,
             MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                if (dtgArea.CurrentRow != null)
                {
                    if (Datos.Eliminar("area", "idarea=" + dtgArea.CurrentRow.Cells["idarea"].Value))
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
                    MessageBox.Show("tiene que seleccional un Area para  eliminar");
                }
            }
            else
            {
                return;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
