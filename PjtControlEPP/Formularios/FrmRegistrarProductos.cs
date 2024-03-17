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
    public partial class FrmRegistrarProductos : Form
    {
        public FrmRegistrarProductos()
        {
            InitializeComponent();
        }
        private MySqlConnection Cn = Datos.C;

        private Int32 RecibeIdCategoria;
        private void button2_Click(object sender, EventArgs e)
        {
            FrmInventarios inventarios=new FrmInventarios();
            inventarios.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombreProducto.Text.Length > 0)
            {
                if (txtCantidad.Text.Length > 0)
                {

                    if (txttiempovida.Text.Length > 0)
                    {
                        if (txtMarca.Text.Length > 0)
                        {
                            string Sql =
                   "insert into inventario (marca,nombreproducto,idcategoria,cantidad,tiempovida) values('" +
                   this.txtMarca.Text + "','" +
                   this.txtNombreProducto.Text + "','" + RecibeIdCategoria + "','" +
                   this.txtCantidad.Text + "','" +
                   this.txttiempovida.Text + "')";

                            if (Datos.Insertar(Sql))
                            {

                                // Limpiar();

                                DialogResult res =
                                    MessageBox.Show(@"Desea Ingresar un nuevo EPP?",
                                        @"REGISTRO INSERTADO",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (res == DialogResult.Yes)
                                {

                                    txtMarca.Clear();
                                    cmbCategoria.Items.Clear();
                                    txtNombreProducto.Clear();
                                    txtCantidad.Clear();
                                    txttiempovida.Clear();

                                    return;
                                }
                                else
                                {
                                    this.Close();
                                    FrmInventarios inventarios = new FrmInventarios();
                                    inventarios.Show();

                                }

                            }
                            else
                            {
                                MessageBox.Show("Error al leer los Datos");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtMarca, "Ingrese la Marca");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txttiempovida, "Ingrese el tiempo de vida");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtCantidad, "Ingrese la Cantidad");
                }

            }
            else
            {
                errorProvider1.SetError(txtNombreProducto, "Ingrese el nombre del EPP");
            }


           
        }

        private void FrmRegistrarProductos_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("Select nombrecategoria from categoria", Cn);

            Cn.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            while (leer != null && leer.Read())
            {
                cmbCategoria.Items.Add(leer.GetString(leer.GetOrdinal("nombrecategoria")));
            }
            Cn.Close();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("select idcategoria from categoria where nombrecategoria=@nombrecategoria", Cn);
            cmd.Parameters.AddWithValue("nombrecategoria", cmbCategoria.Text);

            Cn.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            if (leer != null && leer.Read())
            {
                RecibeIdCategoria = leer.GetInt32(leer.GetOrdinal("idcategoria"));
            }
            Cn.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FrmCategoria categoria=new FrmCategoria();
            categoria.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            cmbCategoria.Items.Clear();

            MySqlCommand cmd = new MySqlCommand("Select nombrecategoria from categoria", Cn);

            Cn.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            while (leer != null && leer.Read())
            {
                cmbCategoria.Items.Add(leer.GetString(leer.GetOrdinal("nombrecategoria")));
            }
            Cn.Close();
        }
    }
}
