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
    public partial class FrmModificarCategoria : Form
    {
        public FrmModificarCategoria()
        {
            InitializeComponent();
        }
        public Int32 RecibeDatos;

        private MySqlConnection Cn = Datos.C;
        private void FrmModificarCategoria_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from categoria where idcategoria=" + RecibeDatos, Cn);


            Cn.Open();


            MySqlDataReader leer = cmd.ExecuteReader();
            if (leer != null && leer.Read())
            {

                txtIdCategoria.Text = leer.GetInt32(0).ToString();
                txtNombreCategoria.Text = leer.GetString(1);



            }
            else
            {
                MessageBox.Show("Los datos no se estan leyendo");
            }
            Cn.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreCategoria.Text.Length > 0)
            {



                string campos = "nombrecategoria='" + this.txtNombreCategoria.Text + "'";



                if (Datos.Actualizar("categoria", campos,
                    "idcategoria=" + RecibeDatos))
                {
                    MessageBox.Show(@"Datos Actualizado");
                    this.Close();

                    FrmCategoria categoria = new FrmCategoria();
                    categoria.Show();
                }
                else
                {
                    MessageBox.Show(@"Error al actualizar los datos");
                }

            }
            else
            {
                errorProvider1.SetError(txtNombreCategoria, "Ingrese la Categoria");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmCategoria categoria = new FrmCategoria();
            categoria.Show();
        }
    }
}
