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
    public partial class FrmPo : Form
    {
        public FrmPo()
        {
            InitializeComponent();
        }

        private void FrmPo_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Datos.Consultar("Select * from Po", "Po");
            this.dtgPo.DataSource = Datos.ds.Tables["Po"];
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
          
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtNombrePo.Text.Length > 0)
            {

                string sql = "Insert into po(NombrePO) values('" + this.txtNombrePo.Text + "')";

                if (Datos.Insertar(sql))
                {
                    txtNombrePo.Clear();
                    CargarDatos();

                }
                else
                {
                    txtError.Text = "Error al ingresar los datos";
                }
            }
            else
            {
                txtError.Text = "Deve ingresar la PO";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Desea eliminar la PO seleccionado?", "AVISO", MessageBoxButtons.YesNo,
           MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                if (dtgPo.CurrentRow != null)
                {
                    if (Datos.Eliminar("po", "idPO=" + dtgPo.CurrentRow.Cells["idPO"].Value))
                    {
                        CargarDatos();
                    }
                    else
                    {
                        txtError.Text = "Algo salio mal.....";
                    }
                }
                else
                {
                    txtError.Text = "tiene que seleccional la PO para  eliminar";
                }
            }
            else
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmModificarPo modificarPo = new FrmModificarPo();

            if (dtgPo.CurrentRow != null)
            {
                Int32 selecionado = (Int32)dtgPo.CurrentRow.Cells["idPO"].Value;
                modificarPo.RecibeDatos = selecionado;

            }
            else
            {
                txtError.Text = "Selecione la PO a modificar";
            }
            modificarPo.Show();
            this.Close();
        }
    }
}
