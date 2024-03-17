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
    public partial class FrmModificarDespacho : Form
    {
        public FrmModificarDespacho()
        {
            InitializeComponent();
        }

        private MySqlConnection C = Datos.C;

        private DataTable dsM;
        private MySqlCommandBuilder builderM;
        private MySqlDataAdapter daM;

        private DataTable dsD;
        private MySqlCommandBuilder builderD;
        private MySqlDataAdapter daD;

        private string recibeID;

        private void FrmModificarDespacho_Load(object sender, EventArgs e)
        {

            CargarFactura();

        }

        private void CargarFactura()
        {
            try
            {


            string Cadena1 = "select idfactura, fechaF, idusuario, idempleado,Cedula,OracleID,NombreEmpleado,AreaTrabajo,NombrePO, codigoaprovacion,observacion, estado from facturas order by idfactura asc";

            dsM = new DataTable();
            daM = new MySqlDataAdapter(Cadena1, C);
            builderM = new MySqlCommandBuilder(daM);
            daM.Fill(dsM);
            dtgDespacho.DataSource = dsM;

            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex.Message);
            }
        }

        private void CargarDetalleEPP()
        {
            try
            {
                string Cadena2 = "select iddetallesfactura, idfactura, idempleado, idproducto,nombreepp, cantidad,precio,subtotal, tiempovida,fechavence,codigoaprovacion,estado from detallesfacturas where detallesfacturas.idfactura= " + recibeID;

                dsD = new DataTable();
                daD = new MySqlDataAdapter(Cadena2, C);
                builderD = new MySqlCommandBuilder(daD);
                daD.Fill(dsD);
                dtgDetallesDespacho.DataSource = dsD;
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex.Message);
            }



            

        }

        private void button2_Click(object sender, EventArgs e)
        {

            
          
        }

        private void dtgDespacho_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
           
        }

        private void dtgDespacho_Click(object sender, EventArgs e)
        {
           
        }

        private void dtgDespacho_CellStateChanged_1(object sender, DataGridViewCellStateChangedEventArgs e)
        {
          
        }

        private void dtgDespacho_Click_1(object sender, EventArgs e)
        {
            if (dtgDespacho.CurrentRow != null)
            {

                recibeID = dtgDespacho.CurrentRow.Cells["idfactura"].Value.ToString();

                string estado = dtgDespacho.CurrentRow.Cells["estado"].Value.ToString();

                if (estado == "0")
                {
                    txtSalidaAnulado.Text = "SALIDA ANULADA";

                    btnAnularSalida.Enabled = false;
                    btnDeAnularSalida.Enabled = true;

                }
                else
                {
                    txtSalidaAnulado.Text = "";
                    btnAnularSalida.Enabled = true;
                    btnDeAnularSalida.Enabled = false;
                }


            }


            CargarDetalleEPP();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                daM.Update(dsM);
              //  daD.Update(dsD);

                MessageBox.Show("Los Datos Actualizado Correctamente");

             //  this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {


            if (txtBuscar.Text.Length > 0)
            {
                MySqlCommand cmd = new MySqlCommand("AnularFactura", C)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (dtgDespacho.CurrentRow != null)
                    cmd.Parameters.Add(new MySqlParameter("_idfactura", dtgDespacho.CurrentRow.Cells["idfactura"].Value.ToString()));


                C.Open();
                cmd.ExecuteNonQuery();
                C.Close();



                txtSalidaAnulado.Text = "ITEM ANULADO";
                btnAnularSalida.Enabled = false;
                btnDeAnularSalida.Enabled = true;

                BuscarOrden();

            }
            else
            {
                MessageBox.Show("Sabor colocar el numero de factura y dele a buscar");
            }



        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarFactura();
            CargarDetalleEPP();
        }

        private void btnAnularITEM_Click(object sender, EventArgs e)
        {



            if (txtBuscar.Text.Length > 0)
            {
                MySqlCommand cmd = new MySqlCommand("AnularITEM", C)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (dtgDetallesDespacho.CurrentRow != null)
                    cmd.Parameters.Add(new MySqlParameter("_iddetallesfactura", dtgDetallesDespacho.CurrentRow.Cells["iddetallesfactura"].Value.ToString()));


                C.Open();
                cmd.ExecuteNonQuery();

                C.Close();


                        
                        txtItemAnulado.Text = "ITEM ANULADO";
                btnAnularITEM.Enabled = false;
                btnDeAnularITEM.Enabled = true;

                CargarDetalleEPP();

            }
            else
            {
                MessageBox.Show("Favor colocar el numero de factura y dele a buscar");
            }



        }

        private void dtgDetallesDespacho_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

           
        }

        private void dtgDetallesDespacho_Click(object sender, EventArgs e)
        {
            if (dtgDetallesDespacho.CurrentRow != null)
            {
                string estadoD = dtgDetallesDespacho.CurrentRow.Cells["estado"].Value.ToString();

                if (estadoD == "0")
                {
                    txtItemAnulado.Text = "ITEM ANULADO";
                    btnAnularITEM.Enabled = false;
                    btnDeAnularITEM.Enabled = true;
                }
                else
                {
                    txtItemAnulado.Text = "";
                    btnAnularITEM.Enabled = true;
                    btnDeAnularITEM.Enabled = false;
                }
            }
        }

        private void radTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;

                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                    MessageBox.Show("Solo se Apcetan Numeros");
                }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarOrden();


        }

        private void BuscarOrden()
        {
            if (txtBuscar.Text.Length > 0)
            {

                string consulta = "select idfactura, fechaF, idusuario, idempleado,Cedula,OracleID,NombreEmpleado,AreaTrabajo,NombrePO, codigoaprovacion,observacion, estado from facturas order by idfactura asc";
                C.Open();
                BindingSource origen = new BindingSource();
                MySqlDataAdapter dt = new MySqlDataAdapter(consulta, C);
                System.Data.DataTable datatable = new DataTable();
                dt.Fill(datatable);
                origen.DataSource = datatable;
                this.dtgDespacho.DataSource = origen;

                origen.Filter = "idfactura =" + Int32.Parse(txtBuscar.Text);


                if (dtgDetallesDespacho.CurrentRow != null)
                {
                    string estadoD = dtgDetallesDespacho.CurrentRow.Cells["estado"].Value.ToString();

                    if (estadoD == "0")
                    {

                        txtSalidaAnulado.Text = "SALIDA ANULADO";
                        btnAnularSalida.Enabled = false;
                        btnDeAnularSalida.Enabled = true;


                    }
                    else
                    {
                        txtSalidaAnulado.Text = "";
                        btnAnularSalida.Enabled = true;
                        btnDeAnularSalida.Enabled = false;
                    }
                }

            }
            else
            {
                CargarFactura();
            }


            C.Close();
        }

        private void dtgDespacho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                MySqlCommand cmd = new MySqlCommand("AnularFactura", C)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (dtgDespacho.CurrentRow != null)
                    cmd.Parameters.Add(new MySqlParameter("_idfactura", dtgDespacho.CurrentRow.Cells["idfactura"].Value.ToString()));


                C.Open();
                cmd.ExecuteNonQuery();
                C.Close();



                txtSalidaAnulado.Text = "";

                btnAnularSalida.Enabled = true;
                btnDeAnularSalida.Enabled = false;

                BuscarOrden();

            }
            else
            {
                MessageBox.Show("Sabor colocar el numero de factura y dele a buscar");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                MySqlCommand cmd = new MySqlCommand("AnularITEM", C)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (dtgDetallesDespacho.CurrentRow != null)
                    cmd.Parameters.Add(new MySqlParameter("_iddetallesfactura", dtgDetallesDespacho.CurrentRow.Cells["iddetallesfactura"].Value.ToString()));


                C.Open();
                cmd.ExecuteNonQuery();

                C.Close();


             
                        txtItemAnulado.Text = "";
                        btnAnularITEM.Enabled = false;
                        btnDeAnularITEM.Enabled = true;

                CargarDetalleEPP();

            }
            else
            {
                MessageBox.Show("Sabor colocar el numero de factura y dele a buscar");
            }
        }




    }
}
