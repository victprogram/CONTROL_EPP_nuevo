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
    public partial class FrmModificarEmpleado : Form
    {
        public FrmModificarEmpleado()
        {
            InitializeComponent();
        }
        private MySqlConnection Cn = Datos.C;

        public Int32 ResiveDatos;

        private Int32 RecibeIdArea;
        private Int32 RecibeidPO;
        private void FrmModificarEmpleado_Load(object sender, EventArgs e)
        {


            MySqlCommand cmd2 = new MySqlCommand("Select NombrePO from PO", Cn);

            Cn.Open();


            MySqlDataReader leer2 = cmd2.ExecuteReader();

            while (leer2 != null && leer2.Read())
            {
                CmbPO.Items.Add(leer2.GetString(leer2.GetOrdinal("NombrePO")));
            }
            Cn.Close();


            MySqlCommand cmd1 = new MySqlCommand("Select nombrearea from area", Cn);
            Cn.Open();
            MySqlDataReader leer1 = cmd1.ExecuteReader();
            while (leer1 != null && leer1.Read())
            {
                cmbarea.Items.Add(leer1.GetString(leer1.GetOrdinal("nombrearea")));
            }
            Cn.Close();
            


            MySqlCommand cmd = new MySqlCommand("Select * from empleados where idempleado=" + ResiveDatos, Cn);
            Cn.Open();
            MySqlDataReader leer = cmd.ExecuteReader();

            if (leer != null && leer.Read())
            {
                txtidempleado.Text = leer.GetInt32(0).ToString();
                txtnombre.Text = leer.GetString(1);
                txtapellido.Text = leer.GetString(2);
                txttelefono.Text = leer.GetString(3);
                txtcedula.Text = leer.GetString(4);
                txtoracleid.Text = leer.GetString(5);
                string idarea = leer.GetInt32(6).ToString();
               Int32 idPO = leer.GetInt32(7);

                Cn.Close();
                //busca la unidad Correspondiente


                MySqlCommand cmd3 = new MySqlCommand("Select nombrearea from area where idarea=@idarea", Cn);
                cmd3.Parameters.AddWithValue("idarea", idarea);
                Cn.Open();
                MySqlDataReader leer3 = cmd3.ExecuteReader();
                if (leer3 != null && leer3.Read())
                {
                    cmbarea.Text = leer3.GetString(leer3.GetOrdinal("nombrearea"));

                }
                Cn.Close();


                MySqlCommand cmd4 = new MySqlCommand("Select NombrePO from PO where idPO=@idPO", Cn);
                cmd4.Parameters.AddWithValue("idPO", idPO);
                Cn.Open();
                MySqlDataReader leer4 = cmd4.ExecuteReader();
                if (leer4 != null && leer4.Read())
                {
                    CmbPO.Text = leer4.GetString(leer4.GetOrdinal("NombrePO"));

                }
                Cn.Close();





            }
            else
            {
                MessageBox.Show("Error al leer los datosdel usuario");
                Cn.Close();
            }

            Cn.Close();
        }


        private void BuscarIdarea()
        {
            Cn.Close();

            MySqlCommand cmd = new MySqlCommand("Select idarea from area where nombrearea=@nombrearea", Cn);
            cmd.Parameters.AddWithValue("nombrearea", cmbarea.Text);

            Cn.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            if (leer != null && leer.Read())
            {
                RecibeIdArea = leer.GetInt32(leer.GetOrdinal("idarea"));
            }
            Cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text.Length > 0)
            {
                if (txtapellido.Text.Length > 0)
                {
                      if (txttelefono.Text.Length > 0)
                        {
                            if (txtcedula.Text.Length > 0)
                            {
                                if (txtoracleid.Text.Length > 0)
                                {
                                    if (cmbarea.Text.Length > 0)
                                    {
                                        if (CmbPO.Text.Length>0)
                                        {

                                           
                                            string campos = "nombre='" + this.txtnombre.Text +
                                                                      "',apellido='" + this.txtapellido.Text +
                                                                      "',telefono='" + this.txttelefono.Text +
                                                                      "',cedula='" + this.txtcedula.Text +
                                                                      "',oracleid='" +this.txtoracleid.Text +
                                                                      "',idarea='" +RecibeIdArea +
                                                                      "',idPO='" + RecibeidPO +
                                                                      "'";



                                        if (Datos.Actualizar("empleados", campos,
                                            "idempleado=" + ResiveDatos))
                                        {
                                            MessageBox.Show(@"Datos Actualizado");
                                            this.Close();
                                            FrmEmpleados empleados = new FrmEmpleados();
                                            empleados.Show();
                                        }
                                        else
                                        {
                                            MessageBox.Show(@"Error al actualizar los datos");
                                        }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Debe ingresar la PO");
                                        }

                                    }
                                    else
                                    {
                                        errorProvider1.SetError(cmbarea,"Ingrese el area");

                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(txtoracleid, "Ingrese el OracleID");
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txtcedula, "Ingrese la Cedula");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txttelefono, "Ingrese el Telefono");
                        }
                  
                }
                else
                {
                    errorProvider1.SetError(txtapellido, "Ingrese el Apellido");
                }
            }
            else
            {
                errorProvider1.SetError(txtnombre, "Ingrese el Nombre");
            }
        }

        private void cmbarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarIdarea();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmEmpleados empleados = new FrmEmpleados();
            empleados.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cmbarea.Items.Clear();


            MySqlCommand cmd3 = new MySqlCommand("Select nombrearea from area", Cn);

            Cn.Open();
            MySqlDataReader leer3 = cmd3.ExecuteReader();
            if (leer3 != null && leer3.Read())
            {
                cmbarea.Items.Add(leer3.GetString(leer3.GetOrdinal("nombrearea")));

            }
            Cn.Close();


        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FrmArea area=new FrmArea();
            area.Show();
        }

        private void CmbPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cn.Close();

            MySqlCommand cmd = new MySqlCommand("Select idPO from PO where NombrePO=@NombrePO", Cn);
            cmd.Parameters.AddWithValue("NombrePO", CmbPO.Text);

            Cn.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            if (leer != null && leer.Read())
            {
                RecibeidPO = leer.GetInt32(leer.GetOrdinal("idPO"));
            }
            Cn.Close();
        }



    }
}
