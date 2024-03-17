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
    public partial class FrmBuscarEppCategoria : Form
    {
        public FrmBuscarEppCategoria()
        {
            InitializeComponent();
        }
        private MySqlConnection Cn = Datos.C;
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nombrecategoria = CmbCategoria.Text;

            if (CmbCategoria.Text.Length > 0)
            {
                string campos = "nombrecategoria= '" + nombrecategoria + "'";

                Datos.Actualizar("fecha", campos, "Id=1");


                Close();

                FrmReporteEppCategoria reportecategoria = new FrmReporteEppCategoria();
                reportecategoria.Show();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el Nombre de la Categoria");
            }
        }

        private void FrmBuscarEppCategoria_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd2 = new MySqlCommand("Select nombrecategoria from categoria", Cn);

            Cn.Open();



            MySqlDataReader leer2 = cmd2.ExecuteReader();
            while (leer2 != null && leer2.Read())
            {
                CmbCategoria.Items.Add(leer2.GetString(leer2.GetOrdinal("nombrecategoria")));
            }



            Cn.Close();
        }
    }
}
