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
    public partial class FrmModificarArea : Form
    {
        public FrmModificarArea()
        {
            InitializeComponent();
        }
        public Int32 RecibeDatos;

        private MySqlConnection Cn = Datos.C;
        private void FrmModificarArea_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from area where idarea=" + RecibeDatos, Cn);


            Cn.Open();


            MySqlDataReader leer = cmd.ExecuteReader();
            if (leer != null && leer.Read())
            {

                txtIdArea.Text = leer.GetInt32(0).ToString();
                txtNombreArea.Text = leer.GetString(1);



            }
            else
            {
                MessageBox.Show("Los datos no se estan leyendo");
            }
            Cn.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreArea.Text.Length > 0)
            {
                
                string campos = "nombrearea='" + this.txtNombreArea.Text + "'";
                
                if (Datos.Actualizar("area", campos,
                    "idarea=" + RecibeDatos))
                {
                    MessageBox.Show(@"Datos Actualizado");
                    this.Close();

                    FrmArea area = new FrmArea();
                    area.Show();
                }
                else
                {
                    MessageBox.Show(@"Error al actualizar los datos");
                }

            }
            else
            {
                errorProvider1.SetError(txtNombreArea, "Ingrese el Area");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

            FrmArea area = new FrmArea();
            area.Show();
        }
    }
}
