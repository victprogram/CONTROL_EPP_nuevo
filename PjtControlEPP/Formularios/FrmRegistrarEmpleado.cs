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
    public partial class FrmRegistrarEmpleado : Form
    {
        public FrmRegistrarEmpleado()
        {
            InitializeComponent();
        }


        private MySqlConnection Cn = Datos.C;
       
        private int recibeidarea;
        private int recibeidPO;
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
                                        MessageBox.Show("" + recibeidPO);

                                        string sql = "insert into empleados(nombre,apellido,telefono,cedula,oracleid,idarea,idPO) values('" +
                                this.txtnombre.Text + "','" + this.txtapellido.Text + "','" +
                                this.txttelefono.Text + "','" + this.txtcedula.Text + "','" + this.txtoracleid.Text + "','" + recibeidarea + "','" + recibeidPO + "')";
                                        if (Datos.Insertar(sql))
                                        {


                                            DialogResult res = MessageBox.Show(@"Desea Ingresar un nuevo usuario?", @"REGISTRO INSERTADO",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (res == DialogResult.Yes)
                                            {
                                                txtnombre.Clear();
                                                txtapellido.Clear();
                                                txttelefono.Clear();
                                                txtcedula.Clear();
                                                txtoracleid.Clear();
                                                cmbarea.Text = "";
                                                txtnombre.Focus();
                                                return;


                                            }
                                            else
                                            {
                                                this.Close();
                                                FrmEmpleados empleados = new FrmEmpleados();
                                                empleados.Show();

                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("Error al registrar usuario");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Debe ingresar la PO");

                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(cmbarea,"ingrese el area");
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txtoracleid, "ingrese el OracleID");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtcedula, "ingrese la Cedula");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txttelefono, "ingrese el Telefono");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtapellido, "ingrese el Apellido");
                }
            }
            else
            {
                errorProvider1.SetError(txtnombre, "ingrese el Nombre");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmEmpleados empleados=new FrmEmpleados();
            empleados.Show();
            this.Close();
        }

        private void FrmRegistrarEmpleado_Load(object sender, EventArgs e)
        {

            
            MySqlCommand cmd1 = new MySqlCommand("Select NombrePO from Po", Cn);

            Cn.Open();


            MySqlDataReader leer1 = cmd1.ExecuteReader();

            while (leer1 != null && leer1.Read())
            {
                CmbPO.Items.Add(leer1.GetString(leer1.GetOrdinal("NombrePO")));
            }
            Cn.Close();
            
            
            
            MySqlCommand cmd = new MySqlCommand("Select nombrearea from area", Cn);

            Cn.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            while (leer != null && leer.Read())
            {
                cmbarea.Items.Add(leer.GetString(leer.GetOrdinal("nombrearea")));
            }
            Cn.Close();
        }

        private void cmbarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("select idarea from area where nombrearea=@nombrearea", Cn);
            cmd.Parameters.AddWithValue("nombrearea", cmbarea.Text);

            Cn.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            if (leer != null && leer.Read())
            {
                recibeidarea = leer.GetInt32(leer.GetOrdinal("idarea"));
            }
            Cn.Close();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FrmArea area=new FrmArea();
            area.Show();
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

        private void CmbPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("select idPO from PO where NombrePO=@NombrePO", Cn);
            cmd.Parameters.AddWithValue("NombrePO", CmbPO.Text);

            Cn.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            if (leer != null && leer.Read())
            {
                recibeidPO = leer.GetInt32(leer.GetOrdinal("idPO"));
            }
            Cn.Close();
        }
    }
}
