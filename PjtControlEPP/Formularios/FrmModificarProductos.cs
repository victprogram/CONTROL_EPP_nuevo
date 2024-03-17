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
    public partial class FrmModificarProductos : Form
    {
        public FrmModificarProductos()
        {
            InitializeComponent();
        }
        private MySqlConnection Cn = Datos.C;

        public Int32 ResiveDatos;

        private Int32 RecibeIdCategoria;
        private void FrmModificarProductos_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd1 = new MySqlCommand("Select nombrecategoria from categoria", Cn);
            Cn.Open();
            MySqlDataReader leer1 = cmd1.ExecuteReader();
            while (leer1 != null && leer1.Read())
            {
                cmbcategoria.Items.Add(leer1.GetString(leer1.GetOrdinal("nombrecategoria")));
            }
            Cn.Close();



            MySqlCommand cmd = new MySqlCommand("Select * from inventario where idproducto=" + ResiveDatos, Cn);
            Cn.Open();
            MySqlDataReader leer = cmd.ExecuteReader();

            if (leer != null && leer.Read())
            {
                txtIdproducto.Text = leer.GetInt32(0).ToString();
                txtMarca.Text = leer.GetString(1);
                txtnombreproducto.Text = leer.GetString(2);
                string idcategoria = leer.GetInt32(3).ToString();
                txtcantidad.Text = leer.GetString(4);
                txttiempovida.Text = leer.GetString(5);
               



                Cn.Close();
                //busca la unidad Correspondiente


                MySqlCommand cmd3 = new MySqlCommand("Select nombrecategoria from categoria where idcategoria=@idcategoria", Cn);
                cmd3.Parameters.AddWithValue("idcategoria", idcategoria);
                Cn.Open();
                MySqlDataReader leer3 = cmd3.ExecuteReader();
                if (leer3 != null && leer3.Read())
                {
                    cmbcategoria.Text = leer3.GetString(leer3.GetOrdinal("nombrecategoria"));

                }
                Cn.Close();



            }
            else
            {
                MessageBox.Show("Error al leer los datos");
                Cn.Close();
            }

            Cn.Close();
        }


        private void BuscarIdCategoria()
        {
            Cn.Close();

            MySqlCommand cmd = new MySqlCommand("Select idcategoria from categoria where nombrecategoria=@nombrecategoria", Cn);
            cmd.Parameters.AddWithValue("nombrecategoria", cmbcategoria.Text);

            Cn.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            if (leer != null && leer.Read())
            {
                RecibeIdCategoria = leer.GetInt32(leer.GetOrdinal("idcategoria"));
            }
            Cn.Close();
        }

        private void cmbcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarIdCategoria();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnombreproducto.Text.Length > 0)
            {
                if (txtcantidad.Text.Length > 0)
                {
                    if (txttiempovida.Text.Length > 0)
                    {
                        if (txtMarca.Text.Length > 0)
                        {
                            string campos = "marca='" + this.txtMarca.Text +
                                       "',nombreproducto='" + this.txtnombreproducto.Text +
                                       "',idcategoria='" + RecibeIdCategoria +
                                       "',cantidad='" + this.txtcantidad.Text +
                                       "',tiempovida='" + this.txttiempovida.Text +
                                       "'";



                            if (Datos.Actualizar("inventario", campos,
                                "idproducto=" + ResiveDatos))
                            {
                                MessageBox.Show(@"Datos Actualizado");
                                this.Close();
                                FrmInventarios inventario = new FrmInventarios();
                                inventario.Show();
                            }
                            else
                            {
                                MessageBox.Show(@"Error al actualizar los datos");
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
                    errorProvider1.SetError(txtcantidad, "Ingrese la Cantidad");
                }
            }
            else
            {
                errorProvider1.SetError(txtnombreproducto, "Imprese el nombre del EPP");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmInventarios inventario = new FrmInventarios();
            inventario.Show();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FrmCategoria categoria=new FrmCategoria();
            categoria.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cmbcategoria.Items.Clear();

            MySqlCommand cmd1 = new MySqlCommand("Select nombrecategoria from categoria", Cn);
            Cn.Open();
            MySqlDataReader leer1 = cmd1.ExecuteReader();
            while (leer1 != null && leer1.Read())
            {
                cmbcategoria.Items.Add(leer1.GetString(leer1.GetOrdinal("nombrecategoria")));
            }
            Cn.Close();
        }
            
        

       

    }
}
