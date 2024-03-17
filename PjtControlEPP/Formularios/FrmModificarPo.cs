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
    public partial class FrmModificarPo : Form
    {
        public FrmModificarPo()
        {
            InitializeComponent();
        }

        public Int32 RecibeDatos;

        private MySqlConnection Cn = Datos.C;
        private void FrmModificarPo_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from po where idPO=" + RecibeDatos, Cn);


            Cn.Open();


            MySqlDataReader leer = cmd.ExecuteReader();
            if (leer != null && leer.Read())
            {

                txtIdArea.Text = leer.GetInt32(0).ToString();
                txtNombrePo.Text = leer.GetString(1);



            }
            else
            {
                MessageBox.Show("Los datos no se estan leyendo");
            }
            Cn.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

            FrmPo po = new FrmPo();
            po.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombrePo.Text.Length > 0)
            {

                string campos = "NombrePO='" + this.txtNombrePo.Text + "'";

                if (Datos.Actualizar("po", campos,
                    "idPO=" + RecibeDatos))
                {
                    MessageBox.Show(@"Datos Actualizado");
                    this.Close();



                    FrmPo po = new FrmPo();
                    po.Show();
                }
                else
                {
                    MessageBox.Show(@"Error al actualizar los datos");
                }

            }
            else
            {
                errorProvider1.SetError(txtNombrePo, "Ingrese la PO");
            }
        }

       
    }
}
