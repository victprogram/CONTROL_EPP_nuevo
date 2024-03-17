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
    public partial class FrmBuscarEppMarca : Form
    {
        public FrmBuscarEppMarca()
        {
            InitializeComponent();
        }
        private MySqlConnection Cn = Datos.C;
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void FrmBuscarEppMarca_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("Select marca from inventario", Cn);


            Cn.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            while (leer != null && leer.Read())
            {
                CmbMarca.Items.Add(leer.GetString(leer.GetOrdinal("marca")));
            }

            Cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string marca = CmbMarca.Text;

            if (CmbMarca.Text.Length > 0)
            {
                string campos = "marca= '" + marca + "'";

                Datos.Actualizar("fecha", campos, "Id=1");


                Close();

                FrmReporteEppMarca reportemarca = new FrmReporteEppMarca();
                reportemarca.Show();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el Nombre de la Marca");
            }
        }
    }
}
