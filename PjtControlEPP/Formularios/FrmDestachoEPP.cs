using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace PjtControlEPP.Formularios
{
    public partial class FrmDestachoEPP : Form
    {
        public FrmDestachoEPP()
        {
            InitializeComponent();
        }

       
        private MySqlConnection C = Datos.C;
        string strProducto = "";
        private int IdP;
        private double Cant_;
        private int ResiveCantidad;
        private string ResiveCampoC;
        public string IdUsuario;
        private string usuario;
        private string apellido;
        private string FechaVenceporEPP;
        private string idempleado;
        private string recibecodigoautorizacion;

        private int RecibeIdProAutorizacion;
        private double precioR;
        private string idproductoR;
        private string nombreproductoR;
        private string cantidadR;
        private string tvR;
        private string correousuarioE;
        private int recibeidPO;

        public string nombreusuario;

        private string _idfactura;
        private string UrlJsonConsulta;
        private string UrlJsonSalida;

        private string _NombreEmpleado;

        private string _mensajeErrorImpro;

        private int recibeID_Departamento;

        
        private Double Total = 0, Efectivo = 0, Cambio = 0, totalItbis = 0, itebisRi = 0;


        private void CalcularTotal()
        {
            Total = 0;
            itebisRi = 0;
            foreach (DataGridViewRow R in dgProductos.Rows)
            {
                if (R.Cells["subtotal"].Value != null)
                {


                    Total += double.Parse(R.Cells["subtotal"].Value.ToString());


                }
            }



            txtTotal.Text = Math.Round(Total, 2).ToString("#.00");


        }

        private void BuscarEmpleado()
        {

            if (txtCedula.Text.Length >= 11)
            {
               // string urljsonConsulta = Datos.Consultar3("urlempleado", "principal", "where id=1").Rows[0][0].ToString();

                string urljsonConsulta =
                    "HTTP://navarrowindows.ddns.net/BPRESTSERVICES/EMPLEADO.RSVC?PAGINA=1&ROWSPORPAGINA=1000&CEDULA=" +
                    txtCedula.Text;

                WebClient wc = new WebClient();

                var datos = wc.DownloadString(urljsonConsulta);

                var rs = JsonConvert.DeserializeObject<repuestaEmpleado>(datos);


                txtNombreEmpleado.Clear();
                txtApellido.Clear();
                txtArea.Clear();
                txtOracleID.Clear();
                txtOcupacion.Clear();

                foreach (var item in rs.Rows)
                {

                    if (txtCedula.Text == item.cedula)
                    {

                        idempleado = item.codigo;
                        txtNombreEmpleado.Text = item.nombres;
                        txtArea.Text = item.dpto_nombre;
                        txtApellido.Text = item.apellidos;
                        txtOracleID.Text = item.otrocodigo;
                        txtOcupacion.Text = item.cargo_nombre;
                    }
                    
                }
            }
            else
                if (txtOracleID.Text.Length>4) 
                {
                    string urljsonConsulta = Datos.Consultar3("urlempleado", "principal", "where id=1").Rows[0][0].ToString();


                    WebClient wc = new WebClient();

                    var datos = wc.DownloadString(urljsonConsulta);

                    var rs = JsonConvert.DeserializeObject<repuestaEmpleado>(datos);


                    txtNombreEmpleado.Clear();
                    txtApellido.Clear();
                    txtArea.Clear();
                    txtCedula.Clear();
                    txtOcupacion.Clear();

                    foreach (var item in rs.Rows)
                    {

                        if (txtOracleID.Text == item.otrocodigo)
                        {

                            idempleado = item.codigo;
                            txtNombreEmpleado.Text = item.nombres;
                            txtArea.Text = item.dpto_nombre;
                            txtApellido.Text = item.apellidos;
                            txtCedula.Text = item.cedula;
                            txtOcupacion.Text = item.cargo_nombre;
                        }
                        
                    }

                }
                else
                {
                    FrmConsultaEmpleados empleados = new FrmConsultaEmpleados();

                    empleados.ShowDialog();

                    if (empleados.Seleccion == "S")
                    {
                        idempleado = empleados.Idempleado;
                        txtNombreEmpleado.Text = empleados.Nombre;
                        txtApellido.Text = empleados.Apellido;
                        txtOracleID.Text = empleados.Oracleid;
                        txtCedula.Text = empleados.Cedula;
                        txtOcupacion.Text = empleados.Ocupacion;
                        txtArea.Text = empleados.Area;


                    }
                }

            

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
         
          
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtError.Clear();
            if (txtNombreEmpleado.Text.Length > 0)
            {
                btnFacrurar.Enabled = true;
                FrmConsultaInventario Producto = new FrmConsultaInventario();


                if (Producto.ShowDialog() == DialogResult.OK)
                {
                    IdP = Int32.Parse(Producto.idproducto);

                    idproductoR = Producto.idproducto;
                    nombreproductoR = Producto.nombreproducto;
                    cantidadR = Producto.cantidad;
                    tvR = Producto.tiempovida;
                    precioR = double.Parse(Producto.precio);

                    if (tvR== "")
                    {

                        MessageBox.Show("EPP SELECIONADO LE FALTA EL TIEMPO DE VIDA ULTIL");


                    }
                    else
                    {

                        WebClient wc = new WebClient();

                        string urljsonConsultaB = "HTTP://navarrowindows.ddns.net/BPRESTSERVICES/GETWEBCATALOGPAGINADO.RSVC?INCLUIRCOSTO=SI?PAGINA=1&ROWSPORPAGINA=3000&CODIGO=" + IdP;


                        var datos = wc.DownloadString(urljsonConsultaB);

                        var rs = JsonConvert.DeserializeObject<repuesta>(datos);

                        foreach (var item in rs.Rows)
                        {

                            if (item.codigo == IdP)
                            {
                                int Cnt = Int32.Parse(item.existencia);

                                Cant_ = Cnt;
                                C.Close();

                                if (Cant_ > 0)
                                {

                                    if (dgProductos.Rows.Count != 0)
                                    {
                                        bool temp = false;
                                        foreach (DataGridViewRow R in dgProductos.Rows)
                                        {

                                            if (R.Cells["idproducto"].Value.ToString() == Producto.idproducto)
                                            {

                                                temp = true;
                                                indexRow = R.Index;
                                                break;
                                            }
                                            else
                                            {
                                                temp = false;
                                            }
                                        }
                                        if (temp)
                                        {

                                            //int a = int.Parse(dgProductos.Rows[indexRow].Cells["Cantidad"].Value.ToString()) + 1;

                                            //dgProductos.Rows[indexRow].Cells["Cantidad"].Value = a.ToString();

                                            MessageBox.Show("EL EPP YA ESTA SELECIONADA");

                                        }
                                        else
                                        {

                                            validarFechaVence();

                                            if (txtFechaVenceProductoDespachado.Text.Length > 0)
                                            {
                                                DateTime f = dtpFecha.Value;
                                                string fechaActual = f.ToString("dd/MM/yyy");

                                                DateTime f1 = Convert.ToDateTime(fechaActual);
                                                int fechaA = Int32.Parse(f1.ToString("yyyyMMdd"));

                                                DateTime f2 = Convert.ToDateTime(txtFechaVenceProductoDespachado.Text);
                                                int fechaB = Int32.Parse(f2.ToString("yyyyMMdd"));


                                                if (fechaA >= fechaB)
                                                {
                                                    DateTime inicio = dtpFecha.Value;
                                                    int cantidad = int.Parse(Producto.tiempovida);
                                                    for (int r = 0; r < cantidad; r++)
                                                    {

                                                        inicio = inicio.AddDays(1);
                                                        FechaVenceporEPP = inicio.ToString("dd/MM/yyy");

                                                    }

                                                    //double cost = double.Parse(Producto.precio);

                                                    //double SubTotal = cost;

                                                    //string subTotalD = Math.Round(SubTotal, 2).ToString("#.00");

                                                    dgProductos.Rows.Add(Producto.idproducto, idempleado, Producto.nombreproducto, "1", Producto.precio, Producto.precio, Producto.tiempovida, FechaVenceporEPP, "0");


                                                    btnBuscarCliente.Enabled = false;

                                                }
                                                else
                                                {

                                                    panel1.Visible = true;
                                                    txtNombreE.Text = txtNombreEmpleado.Text;
                                                    txtApellidoE.Text = txtApellido.Text;
                                                    txtCedulaE.Text = txtCedula.Text;
                                                    txtAreaE.Text = txtArea.Text;

                                                    txtIdProductoE.Text = idproductoR;
                                                    txtNombreProductoE.Text = nombreproductoR;
                                                    txtFechavenceE.Text = txtFechaVenceProductoDespachado.Text;

                                                    txtMensaje.Text += "MENSAJE DE APROBACIÓN \r\n ";
                                                    txtMensaje.Text += "EMPLEADO: " + txtNombreEmpleado.Text + " " + txtApellido.Text + " \r\n ";
                                                    txtMensaje.Text += "CEDULA: " + txtCedula.Text + " \r\n ";
                                                    txtMensaje.Text += "TRABAJA EN AREA: " + txtArea.Text + " \r\n ";
                                                    txtMensaje.Text += "REGISTRA UNA SALIDA DEL EPP, CODIGO: " + idproductoR + " DESCRIPCIÓN: " + nombreproductoR + " \r\n ";
                                                    txtMensaje.Text += "DICHO EPP VENCE EN FECHA : " + txtFechaVenceProductoDespachado.Text + " \r\n ";
                                                    txtMensaje.Text += "OBSERVACIÓN: " + txtObservacionE.Text + " \r\n ";

                                                }
                                            }
                                            else
                                            {

                                                DateTime inicio = dtpFecha.Value;
                                                int cantidad = int.Parse(Producto.tiempovida);
                                                for (int r = 0; r < cantidad; r++)
                                                {

                                                    inicio = inicio.AddDays(1);
                                                    FechaVenceporEPP = inicio.ToString("dd/MM/yyy");

                                                }

                                                //double cost = double.Parse(Producto.precio);
                                                //double SubTotal = cost;
                                                //string subTotalD = Math.Round(SubTotal, 2).ToString("#.00");

                                                dgProductos.Rows.Add(Producto.idproducto, idempleado, Producto.nombreproducto, "1", Producto.precio, Producto.precio, Producto.tiempovida, FechaVenceporEPP, "0");
                                                
                                                btnBuscarCliente.Enabled = false;


                                            }


                                        }
                                    }
                                    else
                                    {

                                        
                                        validarFechaVence();

                                        if (txtFechaVenceProductoDespachado.Text.Length > 0)
                                        {
                                            DateTime f = dtpFecha.Value;
                                            string fechaActual = f.ToString("dd/MM/yyy");

                                            DateTime f1 = Convert.ToDateTime(fechaActual);
                                            int fechaA = Int32.Parse(f1.ToString("yyyyMMdd"));

                                            DateTime f2 = Convert.ToDateTime(txtFechaVenceProductoDespachado.Text);
                                            int fechaB = Int32.Parse(f2.ToString("yyyyMMdd"));


                                            if (fechaA >= fechaB)
                                            {
                                                DateTime inicio = dtpFecha.Value;
                                                int cantidad = int.Parse(Producto.tiempovida);
                                                for (int r = 0; r < cantidad; r++)
                                                {

                                                    inicio = inicio.AddDays(1);
                                                    FechaVenceporEPP = inicio.ToString("dd/MM/yyy");

                                                }

                                                dgProductos.Rows.Add(Producto.idproducto, idempleado, Producto.nombreproducto, "1", Producto.precio, Producto.precio, Producto.tiempovida, FechaVenceporEPP, "0");

                                                btnBuscarCliente.Enabled = false;

                                            }
                                            else
                                            {

                                                panel1.Visible = true;

                                                txtNombreE.Text = txtNombreEmpleado.Text;
                                                txtApellidoE.Text = txtApellido.Text;
                                                txtCedulaE.Text = txtCedula.Text;

                                                txtAreaE.Text = txtArea.Text;

                                                txtIdProductoE.Text = idproductoR;
                                                txtNombreProductoE.Text = nombreproductoR;
                                                txtFechavenceE.Text = txtFechaVenceProductoDespachado.Text;

                                                txtMensaje.Text += "MENSAJE DE APROBACIÓN \r\n ";
                                                txtMensaje.Text += "EMPLEADO: " + txtNombreEmpleado.Text + " " + txtApellido.Text + " \r\n ";
                                                txtMensaje.Text += "CEDULA: " + txtCedula.Text + " \r\n ";
                                                txtMensaje.Text += "TRABAJA EN AREA: " + txtArea.Text + " \r\n ";
                                                txtMensaje.Text += "REGISTRA UNA SALIDA DEL EPP, CODIGO: " + idproductoR + " DESCRIPCIÓN: " + nombreproductoR + " \r\n ";
                                                txtMensaje.Text += "DICHO EPP VENCE EN FECHA : " + txtFechaVenceProductoDespachado.Text + " \r\n ";
                                                txtMensaje.Text += "OBSERVACIÓN: " + txtObservacionE.Text + " \r\n ";

                                            }
                                        }
                                        else
                                        {

                                            DateTime inicio = dtpFecha.Value;
                                            int cantidad = int.Parse(Producto.tiempovida);
                                            for (int r = 0; r < cantidad; r++)
                                            {

                                                inicio = inicio.AddDays(1);
                                                FechaVenceporEPP = inicio.ToString("dd/MM/yyy");

                                            }

                                            //double cost = double.Parse(Producto.precio);
                                            //double SubTotal = cost;
                                            //string subTotalD = Math.Round(SubTotal, 2).ToString("#.00");


                                            dgProductos.Rows.Add(Producto.idproducto, idempleado,Producto.nombreproducto, "1", Producto.precio, Producto.precio, Producto.tiempovida, FechaVenceporEPP, "0");

                                            //dgProductos.Rows.Add(Producto.idproducto, idempleado, Producto.nombreproducto,
                                            //    "1", Producto.tiempovida, FechaVenceporEPP, "0");


                                            btnBuscarCliente.Enabled = false;


                                        }

                                    }


                                    btnFacrurar.Enabled = true;

                                }
                                else
                                {

                                    MessageBox.Show( "La Cantidad Esta en  :  " + Cant_ + "  Favor revise sus Stock ");
                                    C.Close();

                                }

                            }

                        }
                    }



                }


            }
            else
            {
                txtError.Text="Para buscar un EPP primero ingrese el empleado";
            }

            CalcularTotal();
           

        }

        private void validarFechaVence()
        {

           
            try
            {


                C.Open();

                MySqlCommand cmd = new MySqlCommand("ValidarFechaVence", C)
                {
                    CommandType = CommandType.StoredProcedure
                };


                cmd.Parameters.Add(new MySqlParameter("_idproducto", IdP.ToString()));
                cmd.Parameters.Add(new MySqlParameter("_idempleado", idempleado));

                cmd.ExecuteNonQuery();


                MySqlDataReader leer = cmd.ExecuteReader();

                if (leer != null && leer.Read())
                {

                    txtFechaVenceProductoDespachado.Text = leer.GetString(leer.GetOrdinal("fechavence"));


                }
                C.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }




        public int indexRow { get; set; }

        private void dgProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgProductos != null && dgProductos.CurrentCell.ColumnIndex == 3)
            {
                EditarCeldaCantidad();
            }

            if (dgProductos != null && dgProductos.CurrentCell.ColumnIndex == 4)
            {
                EditarCeldaPrecio();
            }
        }

        

        private void EditarCeldaPrecio()
        {
            txtError.Clear();
            double Precio = 0, Cantidad = 0, SubTotal = 0;

            
            if (dgProductos != null && dgProductos.CurrentCell.ColumnIndex == 4)
            {
                if (dgProductos.CurrentRow != null)
                {
                    btnFacrurar.Enabled = true;

                    Precio = double.Parse(dgProductos.CurrentRow.Cells["Precio"].Value.ToString());
                    Cantidad = Int32.Parse(dgProductos.CurrentRow.Cells["Cantidad"].Value.ToString());


                    SubTotal = Precio * Cantidad;



                    string subTotalE = Math.Round(SubTotal, 2).ToString("#.00");


                    dgProductos.CurrentRow.Cells["subtotal"].Value = subTotalE.ToString();

                }
                else
                {
                   txtError.Text="Selecione el producto";
                }
                CalcularTotal();
            }
            else
            {
                txtError.Text="Selecione el producto";
            }
            CalcularTotal();
            

        }


        

        private void EditarCeldaCantidad()
        {
            txtError.Clear();
            double Precio = 0, Cantidad = 0, SubTotal = 0;

            int ResiveIDproducto = int.Parse(dgProductos.CurrentRow.Cells["idproducto"].Value.ToString());


            string urljsonConsultaC = "HTTP://navarrowindows.ddns.net/BPRESTSERVICES/GETWEBCATALOGPAGINADO.RSVC?INCLUIRCOSTO=SI?PAGINA=1&ROWSPORPAGINA=3000&CODIGO=" + ResiveIDproducto;


                    WebClient wc = new WebClient();

                    var datos = wc.DownloadString(urljsonConsultaC);

                    var rs = JsonConvert.DeserializeObject<repuesta>(datos);

            foreach (var item in rs.Rows)
            {

                if (item.codigo == ResiveIDproducto)
                {
                    int Cnt = Int32.Parse(item.existencia);

                    Cant_ = Cnt;
                    C.Close();

                    if (dgProductos.CurrentRow != null &&
                        Int32.Parse(dgProductos.CurrentRow.Cells["Cantidad"].Value.ToString()) <= Cnt)
                    {

                        if (dgProductos != null && dgProductos.CurrentCell.ColumnIndex == 3)
                        {
                            if (dgProductos.CurrentRow != null)
                            {
                                btnFacrurar.Enabled = true;


                                Precio = double.Parse(dgProductos.CurrentRow.Cells["Precio"].Value.ToString());
                                Cantidad = int.Parse(dgProductos.CurrentRow.Cells["Cantidad"].Value.ToString());
                                
                                SubTotal = Precio * Cantidad;
                                
                                string subTotalE = Math.Round(SubTotal, 2).ToString("#.00");
                                
                                dgProductos.CurrentRow.Cells["SubTotal"].Value = subTotalE.ToString();


                            }
                            else
                            {
                                txtError.Text="Selecione el EPP";
                            }


                            btnFacrurar.Enabled = true;

                        }
                        else
                        {
                            txtError.Text="Selecione el EPP";
                        }
                    }
                    else
                    {
                        txtError.Text="Solo hay :  " + Cant_ + "  Disponible y usted esta seleccioando " +
                                        double.Parse(dgProductos.CurrentRow.Cells["Cantidad"].Value.ToString());
                        C.Close();
                        
                        btnFacrurar.Enabled = false;

                    }

                }
               

            }

            CalcularTotal();
          

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFacrurar_Click(object sender, EventArgs e)
        {
          
        }
        

        private MySqlCommand MySqlCommand(string p, MySqlConnection C)
        {
            throw new NotImplementedException();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

           
        }

        private void EnviaItemparovado()
        {
            txtError.Clear();
            try
            {

            

             // string codigoinstroducido = txtcodigoaprovacion.Text;

                btnFacrurar.Enabled = true;
                
                int ResiveIDproducto = IdP;
                
                WebClient wc = new WebClient();

                string urljsonConsultaItem = "HTTP://navarrowindows.ddns.net/BPRESTSERVICES/GETWEBCATALOGPAGINADO.RSVC?INCLUIRCOSTO=SI?PAGINA=1&ROWSPORPAGINA=3000&CODIGO=" + ResiveIDproducto;


                var datos = wc.DownloadString(urljsonConsultaItem);

                var rs = JsonConvert.DeserializeObject<repuesta>(datos);

                foreach (var item in rs.Rows)
                {

                    if (item.codigo == ResiveIDproducto)
                    {
                        int Cnt = Int32.Parse(item.existencia);

                        Cant_ = Cnt;
                        C.Close();

                        if (Cant_ > 0)
                        {

                            if (dgProductos.Rows.Count != 0)
                            {
                                bool temp = false;
                                foreach (DataGridViewRow R in dgProductos.Rows)
                                {

                                    if (R.Cells["idproducto"].Value.ToString() == idproductoR)
                                    {

                                        temp = true;
                                        indexRow = R.Index;
                                        break;
                                    }
                                    else
                                    {
                                        temp = false;
                                    }
                                }
                                if (temp)
                                {

                                    int a =
                                        int.Parse(dgProductos.Rows[indexRow].Cells["Cantidad"].Value.ToString()) +
                                        1;

                                    dgProductos.Rows[indexRow].Cells["Cantidad"].Value = a.ToString();

                                }
                                else
                                {

                                    DateTime inicio = dtpFecha.Value;
                                    int cantidad = int.Parse(tvR);
                                    for (int r = 0; r < cantidad; r++)
                                    {

                                        inicio = inicio.AddDays(1);
                                        FechaVenceporEPP = inicio.ToString("yyy/MM/dd");

                                    }

                                    //double cost = precioR;
                                    //double SubTotal = cost;
                                    //string subTotalD = Math.Round(SubTotal, 2).ToString("#.00");

                                    dgProductos.Rows.Add(idproductoR, idempleado, nombreproductoR, "1", precioR, precioR, tvR, FechaVenceporEPP, recibecodigoautorizacion);



                                    btnBuscarCliente.Enabled = false;

                                    txtcodigoaprovacion.Clear();

                                }
                            }
                            else
                            {

                                DateTime inicio = dtpFecha.Value;
                                int cantidad = int.Parse(tvR);
                                for (int r = 0; r < cantidad; r++)
                                {

                                    inicio = inicio.AddDays(1);
                                    FechaVenceporEPP = inicio.ToString("yyy/MM/dd");

                                }


                                double cost = precioR;

                                double SubTotal = cost;



                                string subTotalD = Math.Round(SubTotal, 2).ToString("#.00");


                                dgProductos.Rows.Add(idproductoR, idempleado, nombreproductoR, "1", precioR, subTotalD, tvR, FechaVenceporEPP, recibecodigoautorizacion);

                                btnBuscarCliente.Enabled = false;

                                txtcodigoaprovacion.Clear();


                            }

                            btnFacrurar.Enabled = true;

                        }
                        else
                        {
                           txtError.Text="La Cantidad Esta en  :  " + Cant_ + "  Favor revise sus Stock ";
                            C.Close();



                        }
                    }
                }

                

               

                panel1.Visible = false;

              //  Send();

                txtNombreE.Clear();
                txtAreaE.Clear();
                txtApellidoE.Clear();
                txtCedulaE.Clear();
                txtIdProductoE.Clear();
                txtNombreProductoE.Clear();
               
                txtObservacionE.Text = ".";
              
                txtMensaje.Clear();


            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtcodigoaprovacion.Clear();
            panel1.Visible = false;

            txtFechaVenceProductoDespachado.Clear();
            txtCodigoConsulta.Clear();
            txtCodigoautorizacion.Clear();
        }

        private void txtcodigoaprovacion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FrmDestachoProductos_Load(object sender, EventArgs e)
        {
           


            //string Orden =Datos.Consultar3("idfactura", "facturas", "ORDER BY facturas.idfactura DESC").Rows[0][0].ToString();

            //Int32 NumOrden = Int32.Parse(Orden);

            //Int32 SumNumOrden = NumOrden + 1;

            //_idfactura = SumNumOrden.ToString();

            //txtNumeroFactura.Text = _idfactura;



            MySqlCommand cmd = new MySqlCommand("Select NombrePO from po ORDER BY po.NombrePO ASC", C);

            C.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            while (leer != null && leer.Read())
            {
                CmbPo.Items.Add(leer.GetString(leer.GetOrdinal("NombrePO")));
            }
            C.Close();

            MySqlCommand cmd1 = new MySqlCommand("Select nombre_documento from tipodocumento", C);

            C.Open();

            MySqlDataReader leer1 = cmd1.ExecuteReader();

            while (leer1 != null && leer1.Read())
            {
                CmbDocumento.Items.Add(leer1.GetString(leer1.GetOrdinal("nombre_documento")));
            }
            C.Close();


            RbNoFactuacion.Checked = true;
            
            string correousuario = Datos.Consultar3("correo", "usuarios", "where idusuario=" + IdUsuario).Rows[0][0].ToString();
            string correoaprobacion = Datos.Consultar3("correoaprobacion", "principal", "where id=1").Rows[0][0].ToString();
            UrlJsonConsulta = Datos.Consultar3("urlconsulta", "principal", "where id=1").Rows[0][0].ToString();

            UrlJsonSalida = Datos.Consultar3("urlsalida", "principal", "where id=1").Rows[0][0].ToString();

            txtusuarioN.Text = nombreusuario;
            txtDe.Text = correousuario;
            txtCopia.Text = correousuario;

            txtPara.Text = correoaprobacion;


          



        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgProductos.CurrentRow != null) dgProductos.Rows.RemoveAt(dgProductos.CurrentRow.Index);

                if (dgProductos.CurrentRow == null)
                {
                    btnBuscarCliente.Enabled = true;
                }
                txtFechaVenceProductoDespachado.Clear();
                txtCodigoConsulta.Clear();
                txtCodigoautorizacion.Clear();

            }
            catch
            {
                MessageBox.Show("No hay datos para eliminar");

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgProductos.Rows.Clear();

            btnBuscarCliente.Enabled = true;

            txtFechaVenceProductoDespachado.Clear();
            txtCodigoConsulta.Clear();
            txtCodigoautorizacion.Clear();

        }

        private void dgProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgProductos != null && dgProductos.CurrentCell.ColumnIndex == 3)
            {
                EditarCeldaCantidad();
            }

            if (dgProductos != null && dgProductos.CurrentCell.ColumnIndex == 4)
            {
                EditarCeldaPrecio();
            }
        }


        //public  void Send()
        //{
        //    try
        //    {
               
        //        MailMessage mail = new MailMessage();
        //        mail.IsBodyHtml = true;
        //        mail.From = new MailAddress(txtDe.Text, "BIANKA NAVARRO");
        //        mail.To.Add(new MailAddress(txtPara.Text, "DIONISIO SEVERINO"));
        //       // mail.To.Add(new MailAddress(txtCopia.Text, "VICTOR VARGAS"));
        //        mail.Subject = txtasunto.Text;
        //        mail.Body = txtMensaje.Text;

        //        using (SmtpClient smtp = new SmtpClient())
        //        {
                    
        //            smtp.Host = "smtp.gmail.com";
        //            smtp.Port = 587;
        //            smtp.EnableSsl = true;
        //            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
        //            NetworkCred.UserName = "tecnologia@agencianavarro.com";
        //            NetworkCred.Password = "yeremyalfonso02";
        //            smtp.UseDefaultCredentials = true;
        //            smtp.Credentials = NetworkCred;
        //            smtp.Send(mail);

        //            MessageBox.Show("SE ENVIO UN CORREO AL DEPARTAMENTO DE HSE");
        //        }
        //    }
        //    catch (Exception )
        //    {
        //        MessageBox.Show("NO FUE POSIBLE ENVIAR EL CORREO. PUEDE CONTINUAR CON EL REGISTRO");

              
        //    }

            
        //}

        private void button2_Click(object sender, EventArgs e)
        {
           

            txtError.Clear();

            StringBuilder builder = new StringBuilder();

            Random random = new Random();
            int ch;
            for (int i = 0; i < 4; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            txtCodigoautorizacion.Text = builder.ToString();

            recibecodigoautorizacion = builder.ToString();
            
            string fecha = dtpFecha.Value.ToString("yyy/MM/dd");
            txtCodigoConsulta.Text = Datos.ConsultarValor("codigoautorizacion", "autorizacionepp", "where autorizacionepp.codigoautorizacion='" + txtCodigoautorizacion.Text + "'");

            if (txtCodigoConsulta.Text == txtCodigoautorizacion.Text)
            {
                MessageBox.Show("El codigo ingresado ya existe,favor General uno diferente");

                txtCodigoautorizacion.Clear();
                
                return;

            }
            else
            {

                try
                {

                    EnviaItemparovado();

                    //MySqlCommand cmd = new MySqlCommand("RegistrarAutorizacion", C)
                    //{
                    //    CommandType = CommandType.StoredProcedure
                    //};
                    //cmd.Parameters.Add(new MySqlParameter("_fecha", fecha));
                    //cmd.Parameters.Add(new MySqlParameter("_idusuario", IdUsuario));
                    //cmd.Parameters.Add(new MySqlParameter("_idempleado", idempleado));
                    //cmd.Parameters.Add(new MySqlParameter("_idproducto", idproductoR));
                    //cmd.Parameters.Add(new MySqlParameter("_fechavence", txtFechavenceE.Text));
                    //cmd.Parameters.Add(new MySqlParameter("_codigoautorizacion", this.txtCodigoautorizacion.Text));
                    //cmd.Parameters.Add(new MySqlParameter("_observacion", this.txtObservacionE.Text));

                    //C.Open();
                    //cmd.ExecuteNonQuery();

                    //C.Close();






                }
                catch (Exception ex)
                {

                    MessageBox.Show(" " + ex.Message);

                }

           

            }
            
    
        }

        private void CmbPo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FrmPo po = new FrmPo();
            po.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           

        }

        private void dgProductos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalcularTotal();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void btnCategoria_Click_1(object sender, EventArgs e)
        {
            FrmPo po = new FrmPo();
            po.Show();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            CmbPo.Items.Clear();



            MySqlCommand cmd1 = new MySqlCommand("Select NombrePO from po", C);

            C.Open();

            MySqlDataReader leer1 = cmd1.ExecuteReader();

            while (leer1 != null && leer1.Read())
            {
                CmbPo.Items.Add(leer1.GetString(leer1.GetOrdinal("NombrePO")));
            }
            C.Close();
        }

        private void txtOracleID_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            BuscarEmpleado();
        }

        private void button4_Click(object sender, EventArgs e)
        {

           DialogResult res=  MessageBox.Show("Esta seguro de querer salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (res == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }

     
        }


        //private async void EnviarImpro()
        //{
        //    // datos para registrar la salida EPP

        //    Salida invsalida = new Salida();
        //    invsalida.Almacen = int.Parse(txtarmancen.Text);
        //    invsalida.Usuario = txtusuarioN.Text;
        //    invsalida.Doc = txtdocumento.Text;
        //    invsalida.Tipodoc = int.Parse(txttipodocumento.Text);
        //    invsalida.Obs = "" + txtobservacion.Text + "SALIDAD: " + _idfactura + " DEL EMPLEADO: " + _NombreEmpleado;
        //    invsalida.Dpto = int.Parse(txtdepartamento.Text);

        //    // lista de EPP para dar salida

        //    List<Detalle> items = new List<Detalle>();

        //    foreach (DataGridViewRow dr in dgProductos.Rows)
        //    {


        //        if (dr.Cells["Cantidad"].Value != null)
        //        {
        //            Detalle concepto = new Detalle();

        //            concepto.Cantidad = int.Parse((string)dr.Cells["Cantidad"].Value);

        //            concepto.Comentario = (string)(dr.Cells["codigoautorizacion"].Value).ToString();

        //            concepto.Item = int.Parse((string)dr.Cells["IdProducto"].Value);

        //            items.Add(concepto);
        //        }

        //        invsalida.Detalle = items;


        //    }


        //    // aqui serializo los datos
        //    var carga = await Task.Run(() => JsonConvert.SerializeObject(invsalida));
        //    // me empaqueta la carga para enviar el json hacia HttpClient 
        //    var httpContent = new StringContent(carga, Encoding.UTF8, "application/json");
        //    using (var httpClient = new HttpClient())
        //    {
        //        try
        //        {

        //            // haciendo solicitu y esperando la repuesta
        //            var httpResponse = await httpClient.PostAsync(UrlJsonSalida,httpContent);

        //            // If verifique si obtengo alguna repuesta
        //            if (httpResponse.Content != null)
        //            {
        //                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                        
        //                // aqui prrsento culquier repuesta 
        //                  MessageBox.Show("" + responseContent);

        //            }


        //            //String SI = "SI";

        //            //string campos3 = "AfectaImpro = '" + SI + "'";

        //            //Datos.Actualizar("facturas", campos3, _idfactura.ToString());

        //            //  MySqlCommand cmd3 = new MySqlCommand("update facturas set AfectaImpro='" + SI + "'where idfactura=" + _idfactura, C);




        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(
        //                "NO FUE POSIBLE ENVIAR LA SALIDA A INVPRO, ANTE DE CERRAR ESTE MENSAJE. NOTIFICAR A TECNOLOGIA: " +
        //                ex.Message);

        //        }
        //    }
        //}


        private async void button3_Click_3(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show("Esta seguro de hacer el registro ?", "REVICE BIEN LA SALIDA",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                txtError.Clear();
                if (txtNombreEmpleado.Text.Length > 0)
                {
                    if (dgProductos.RowCount != 0)
                    {

                        if (CmbPo.Text.Length > 0)
                        {

                            if (CmbDocumento.Text.Length > 0)
                            {
                                if (txtobservacion.Text.Length < 230)
                                {
                                    try
                                    {


                                        if (RbNoFactuacion.Checked)
                                        {

                                            btnFacrurar.Enabled = false;

                                            try
                                            {


                                                txtError.Clear();

                                                string fecha = dtpFecha.Value.ToString("yyy/MM/dd");


                                                string OrdenN = Datos.Consultar3("idfactura", "facturas", "ORDER BY facturas.idfactura DESC").Rows[0][0].ToString();

                                                Int32 NumOrdenN = Int32.Parse(OrdenN);

                                                Int32 SumNumOrden = NumOrdenN + 1;

                                                _idfactura = SumNumOrden.ToString();



                                                string NombreEmpleado = "" + txtNombreEmpleado.Text + " " + txtApellido.Text + "";

                                                _NombreEmpleado = NombreEmpleado;

                                                Salida invsalida = new Salida();
                                                invsalida.Almacen = int.Parse(txtarmancen.Text);
                                                invsalida.Usuario = txtusuarioN.Text;
                                                invsalida.Doc = txtdocumento.Text;
                                                invsalida.Tipodoc = int.Parse(txttipodocumento.Text);


                                                // yyyy-MM-dd'T'HH:mm:ss.SSSZ

                                                // invsalida.Fecha = dtpFecha.Value.ToString("yyyy-MM-dd h:mm tt");

                                                // string fechaSalida2 = fecha.ToString("g", CultureInfo.CreateSpecificCulture("en-US"));
                                                //Resultado: 10/26/2018 4:30 PM

                                                // invsalida.fecha_hora = dtpFecha.Value.ToString("g", CultureInfo.CreateSpecificCulture("es-ES"));

                                                invsalida.fecha_hora = dtpFecha.Value.ToString("yyyy-MM-dd'T'HH:mm:ssZ");




                                                invsalida.Obs = "NUM: " + _idfactura + " SALIDA DEL EMPLEADO: " + NombreEmpleado + ". " + txtobservacion.Text;
                                                invsalida.Dpto = recibeID_Departamento;

                                                // lista de EPP para dar salida

                                                List<Detalle> items = new List<Detalle>();

                                                foreach (DataGridViewRow dr in dgProductos.Rows)
                                                {


                                                    if (dr.Cells["Cantidad"].Value != null)
                                                    {
                                                        Detalle concepto = new Detalle();

                                                        concepto.Cantidad = int.Parse((string)dr.Cells["Cantidad"].Value);

                                                        concepto.Comentario = (string)(dr.Cells["codigoautorizacion"].Value).ToString();

                                                        concepto.Item = int.Parse((string)dr.Cells["IdProducto"].Value);

                                                        items.Add(concepto);
                                                    }

                                                    invsalida.Detalle = items;


                                                }


                                                try
                                                {
                                                    // aqui serializo los datos
                                                    var carga = await Task.Run(() => JsonConvert.SerializeObject(invsalida));
                                                    // me empaqueta la carga para enviar el json hacia HttpClient 
                                                    var httpContent = new StringContent(carga, Encoding.UTF8, "application/json");
                                                    using (var httpClient = new HttpClient())
                                                    {

                                                        // haciendo solicitu y esperando la repuesta
                                                        var httpResponse = await httpClient.PostAsync(UrlJsonSalida, httpContent);

                                                        // If verifique si obtengo alguna repuesta
                                                        if (httpResponse.Content != null)
                                                        {
                                                            var responseContent = await httpResponse.Content.ReadAsStringAsync();


                                                            _mensajeErrorImpro = responseContent;

                                                            // aqui prrsento culquier repuesta 
                                                            //  MessageBox.Show("" + responseContent);

                                                        }


                                                    }
                                                }
                                                catch (Exception ex)
                                                {

                                                    MessageBox.Show("" + ex);
                                                }


                                                if (_mensajeErrorImpro.Length > 23)
                                                {
                                                    foreach (DataGridViewRow item in dgProductos.Rows)
                                                    {

                                                        if (int.Parse(item.Cells["codigoautorizacion"].Value.ToString()) >= 1)
                                                        {


                                                            MySqlCommand cmd2 = new MySqlCommand("RegistrarAutorizacion", C)
                                                            {
                                                                CommandType = CommandType.StoredProcedure
                                                            };

                                                            DateTime fechavence = DateTime.Parse(item.Cells["FechaVence"].Value.ToString());
                                                            cmd2.Parameters.Add(new MySqlParameter("_fecha", fecha));
                                                            cmd2.Parameters.Add(new MySqlParameter("_idusuario", IdUsuario));
                                                            cmd2.Parameters.Add(new MySqlParameter("_idempleado", idempleado));
                                                            cmd2.Parameters.Add(new MySqlParameter("_idproducto", item.Cells["IdProducto"].Value.ToString()));
                                                            cmd2.Parameters.Add(new MySqlParameter("_fechavence", fechavence.ToString("yyy/MM/dd")));
                                                            cmd2.Parameters.Add(new MySqlParameter("_codigoautorizacion", item.Cells["codigoautorizacion"].Value.ToString()));
                                                            cmd2.Parameters.Add(new MySqlParameter("_observacion", this.txtObservacionE.Text));


                                                            C.Open();
                                                            cmd2.ExecuteNonQuery();
                                                            cmd2.CommandTimeout = 0;
                                                            C.Close();

                                                        }
                                                    }


                                                    MySqlCommand cmd = new MySqlCommand("RegistrarFactura", C)
                                                    {
                                                        CommandType = CommandType.StoredProcedure
                                                    };

                                                    cmd.Parameters.Add(new MySqlParameter("_fecha", fecha));
                                                    cmd.Parameters.Add(new MySqlParameter("_idusuario", IdUsuario));
                                                    cmd.Parameters.Add(new MySqlParameter("_idempleado", idempleado));
                                                    cmd.Parameters.Add(new MySqlParameter("_Cedula", txtCedula.Text));
                                                    cmd.Parameters.Add(new MySqlParameter("_OracleID", txtOracleID.Text));
                                                    cmd.Parameters.Add(new MySqlParameter("_NombreEmpleado", NombreEmpleado));
                                                    cmd.Parameters.Add(new MySqlParameter("_Ocupacion", txtOcupacion.Text));
                                                    cmd.Parameters.Add(new MySqlParameter("_AreaTrabajo", txtArea.Text));
                                                    cmd.Parameters.Add(new MySqlParameter("_NombrePO", CmbPo.Text));
                                                    cmd.Parameters.Add(new MySqlParameter("_observacion", txtobservacion.Text));
                                                    cmd.Parameters.Add(new MySqlParameter("_nombre_documento", CmbDocumento.Text));
                                                    cmd.Parameters.Add(new MySqlParameter("_AfectaImpro", "SI"));
                                                    cmd.Parameters.Add(new MySqlParameter("_DatosImpro", _mensajeErrorImpro));

                                                    C.Open();
                                                    cmd.ExecuteNonQuery();
                                                    cmd.CommandTimeout = 0;
                                                    C.Close();




                                                    // datos para registrar la salida EPP


                                                    foreach (DataGridViewRow item in dgProductos.Rows)
                                                    {

                                                        if (item.Cells["idproducto"].Value != null)
                                                        {

                                                            MySqlCommand cmd1 = new MySqlCommand("RegistrarDetalleFactura", C)
                                                            {
                                                                CommandType = CommandType.StoredProcedure
                                                            };

                                                            DateTime fechavence = DateTime.Parse(item.Cells["FechaVence"].Value.ToString());

                                                            cmd1.Parameters.Add(new MySqlParameter("_idempleado", idempleado));
                                                            cmd1.Parameters.Add(new MySqlParameter("_idproducto", item.Cells["IdProducto"].Value.ToString()));
                                                            cmd1.Parameters.Add(new MySqlParameter("_nombreepp", item.Cells["NombreProducto"].Value.ToString()));
                                                            cmd1.Parameters.Add(new MySqlParameter("_cantidad", item.Cells["Cantidad"].Value.ToString()));
                                                            cmd1.Parameters.Add(new MySqlParameter("_precio", item.Cells["Precio"].Value.ToString()));
                                                            cmd1.Parameters.Add(new MySqlParameter("_subtotal", item.Cells["subtotal"].Value.ToString()));
                                                            cmd1.Parameters.Add(new MySqlParameter("_tiempovida", item.Cells["tiempovida"].Value.ToString()));
                                                            cmd1.Parameters.Add(new MySqlParameter("_fechavence", fechavence.ToString("yyy/MM/dd")));
                                                            cmd1.Parameters.Add(new MySqlParameter("_codigoaprovacion", item.Cells["codigoautorizacion"].Value.ToString()));

                                                            C.Open();
                                                            cmd1.ExecuteNonQuery();
                                                            cmd1.CommandTimeout = 0;
                                                            C.Close();

                                                        }

                                                    }

                                                    txtNombreEmpleado.Clear();
                                                    txtApellido.Clear();
                                                    txtArea.Clear();
                                                    txtCedula.Clear();
                                                    txtOracleID.Clear();
                                                    CmbPo.Text = "";
                                                    txtobservacion.Clear();
                                                    dgProductos.Rows.Clear();
                                                    btnBuscarCliente.Enabled = true;
                                                    txtCodigoConsulta.Clear();
                                                    txtCodigoautorizacion.Clear();
                                                    txtFechaVenceProductoDespachado.Clear();
                                                    _mensajeErrorImpro = "";



                                                    string OrdenV = Datos.Consultar3("idfactura", "facturas", "ORDER BY facturas.idfactura DESC").Rows[0][0].ToString();


                                                    string campos1 = "idfactura = '" + OrdenV + "'";

                                                    Datos.Actualizar("fecha", campos1, "Id=1");


                                                    FrmReciboEPP reciboEpp = new FrmReciboEPP();
                                                    reciboEpp.Show();

                                                    //Int32 NumOrdenV = Int32.Parse(OrdenV);

                                                    //Int32 SumNumOrdenV = NumOrdenV + 1;

                                                    //_idfactura = SumNumOrdenV.ToString();

                                                    btnFacrurar.Enabled = true;

                                                }
                                                else
                                                {
                                                    MessageBox.Show("NO FUE POSIBLE REGISTRAR EN IMPRO, VERIFIQUE LA EXISTENCIA DE LOS ARTICULOS EN INVENTARIO ALMACEN: " + _mensajeErrorImpro);

                                                }


                                            }
                                            catch (Exception ex)
                                            {


                                                DialogResult res =
                                                    MessageBox.Show("NO FUE POSIBLE REGISTRAR LA SALIDA EN EL SISTEMA DE EPP. DEBE REVISAR LA SALIDA EN INVPRO ANTE DE CONTINUAR", "AVISO IMPORTANTE " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);



                                                //if (res == DialogResult.OK)
                                                //{


                                                //    Datos.Actualizar("usuarios", "estado=0", "idusuario=" + IdUsuario);

                                                //    Application.Exit();


                                                //}





                                            }
                                            finally
                                            {
                                                C.Close();
                                            }


                                        }
                                        else
                                        {

                                            try
                                            {
                                                txtError.Clear();

                                                string fecha = dtpFecha.Value.ToString("yyy/MM/dd");


                                                string NombreEmpleado = "" + txtNombreEmpleado.Text + " " + txtApellido.Text + "";


                                                foreach (DataGridViewRow item in dgProductos.Rows)
                                                {

                                                    if (int.Parse(item.Cells["codigoautorizacion"].Value.ToString()) >= 1)
                                                    {


                                                        MySqlCommand cmd2 = new MySqlCommand("RegistrarAutorizacion", C)
                                                        {
                                                            CommandType = CommandType.StoredProcedure
                                                        };

                                                        DateTime fechavence = DateTime.Parse(item.Cells["FechaVence"].Value.ToString());
                                                        cmd2.Parameters.Add(new MySqlParameter("_fecha", fecha));
                                                        cmd2.Parameters.Add(new MySqlParameter("_idusuario", IdUsuario));
                                                        cmd2.Parameters.Add(new MySqlParameter("_idempleado", idempleado));
                                                        cmd2.Parameters.Add(new MySqlParameter("_idproducto", item.Cells["IdProducto"].Value.ToString()));
                                                        cmd2.Parameters.Add(new MySqlParameter("_fechavence", fechavence.ToString("yyy/MM/dd")));
                                                        cmd2.Parameters.Add(new MySqlParameter("_codigoautorizacion", item.Cells["codigoautorizacion"].Value.ToString()));
                                                        cmd2.Parameters.Add(new MySqlParameter("_observacion", this.txtObservacionE.Text));






                                                        C.Open();
                                                        cmd2.ExecuteNonQuery();
                                                        cmd2.CommandTimeout = 0;

                                                        C.Close();

                                                    }
                                                }



                                                var carga = JsonConvert.SerializeObject("NO_DATOS:");

                                                MySqlCommand cmd = new MySqlCommand("RegistrarFactura", C)
                                                {
                                                    CommandType = CommandType.StoredProcedure
                                                };

                                                cmd.Parameters.Add(new MySqlParameter("_fecha", fecha));
                                                cmd.Parameters.Add(new MySqlParameter("_idusuario", IdUsuario));
                                                cmd.Parameters.Add(new MySqlParameter("_idempleado", idempleado));
                                                cmd.Parameters.Add(new MySqlParameter("_Cedula", txtCedula.Text));
                                                cmd.Parameters.Add(new MySqlParameter("_OracleID", txtOracleID.Text));
                                                cmd.Parameters.Add(new MySqlParameter("_NombreEmpleado", NombreEmpleado));
                                                cmd.Parameters.Add(new MySqlParameter("_Ocupacion", txtOcupacion.Text));
                                                cmd.Parameters.Add(new MySqlParameter("_AreaTrabajo", txtArea.Text));
                                                cmd.Parameters.Add(new MySqlParameter("_NombrePO", CmbPo.Text));
                                                cmd.Parameters.Add(new MySqlParameter("_observacion", txtobservacion.Text));
                                                cmd.Parameters.Add(new MySqlParameter("_nombre_documento", CmbDocumento.Text));
                                                cmd.Parameters.Add(new MySqlParameter("_AfectaImpro", "NO"));
                                                cmd.Parameters.Add(new MySqlParameter("_DatosImpro", carga));


                                                C.Open();
                                                cmd.ExecuteNonQuery();
                                                C.Close();




                                                string noRecibo = Datos.Consultar3("idfactura", "facturas", "ORDER BY facturas.idfactura DESC").Rows[0][0].ToString();

                                                _idfactura = noRecibo;


                                                foreach (DataGridViewRow item in dgProductos.Rows)
                                                {

                                                    if (item.Cells["idproducto"].Value != null)
                                                    {

                                                        MySqlCommand cmd1 = new MySqlCommand("RegistrarDetalleFactura", C)
                                                        {
                                                            CommandType = CommandType.StoredProcedure
                                                        };

                                                        DateTime fechavence = DateTime.Parse(item.Cells["FechaVence"].Value.ToString());

                                                        cmd1.Parameters.Add(new MySqlParameter("_idempleado", idempleado));
                                                        cmd1.Parameters.Add(new MySqlParameter("_idproducto", item.Cells["IdProducto"].Value.ToString()));
                                                        cmd1.Parameters.Add(new MySqlParameter("_nombreepp", item.Cells["NombreProducto"].Value.ToString()));
                                                        cmd1.Parameters.Add(new MySqlParameter("_cantidad", item.Cells["Cantidad"].Value.ToString()));
                                                        cmd1.Parameters.Add(new MySqlParameter("_precio", item.Cells["Precio"].Value.ToString()));
                                                        cmd1.Parameters.Add(new MySqlParameter("_subtotal", item.Cells["subtotal"].Value.ToString()));
                                                        cmd1.Parameters.Add(new MySqlParameter("_tiempovida", item.Cells["tiempovida"].Value.ToString()));
                                                        cmd1.Parameters.Add(new MySqlParameter("_fechavence", fechavence.ToString("yyy/MM/dd")));
                                                        cmd1.Parameters.Add(new MySqlParameter("_codigoaprovacion", item.Cells["codigoautorizacion"].Value.ToString()));

                                                        C.Open();
                                                        cmd1.ExecuteNonQuery();
                                                        cmd1.CommandTimeout = 0;
                                                        C.Close();

                                                    }

                                                }


                                                txtNombreEmpleado.Clear();
                                                txtApellido.Clear();
                                                txtArea.Clear();
                                                txtCedula.Clear();
                                                txtOracleID.Clear();
                                                CmbPo.Text = "";
                                                txtobservacion.Clear();
                                                dgProductos.Rows.Clear();
                                                btnBuscarCliente.Enabled = true;
                                                txtCodigoConsulta.Clear();
                                                txtCodigoautorizacion.Clear();
                                                txtFechaVenceProductoDespachado.Clear();



                                                string Orden = Datos.Consultar3("idfactura", "facturas", "ORDER BY facturas.idfactura DESC").Rows[0][0].ToString();


                                                string campos1 = "idfactura = '" + Orden + "'";

                                                Datos.Actualizar("fecha", campos1, "Id=1");


                                                FrmReciboEPP reciboEpp = new FrmReciboEPP();
                                                reciboEpp.Show();






                                                //Int32 NumOrden = Int32.Parse(Orden);

                                                //Int32 SumNumOrden = NumOrden + 1;

                                                //_idfactura = SumNumOrden.ToString();





                                            }
                                            catch (Exception ex)
                                            {

                                                DialogResult res =
                                                   MessageBox.Show(
                                                       "NO FUE POSIBLE REGISTRAR LA SALIDA EN EL SISTEMA DE EPP. DEBE REVISAR LA SALIDA EN INVPRO ANTE DE CONTINUAR",
                                                       "AVISO IMPORTANTE", MessageBoxButtons.OK, MessageBoxIcon.Error);



                                                //if (res == DialogResult.OK)
                                                //{


                                                //    Datos.Actualizar("usuarios", "estado=0", "idusuario=" + IdUsuario);

                                                //    Application.Exit();


                                                //}

                                            }
                                            finally
                                            {
                                                C.Close();
                                            }


                                        }





                                    }
                                    catch (Exception ex)
                                    {

                                        MessageBox.Show("ERROR: " + ex.Message);
                                    }
                                    finally
                                    {
                                        C.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(
                                        "Ha superado los 230 carateres en el cuadro de OBSERVACION, debe de eliminar informacion");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Debe de ingresar el tipo de documento");
                            }


                        }
                        else
                        {
                            MessageBox.Show("Selecionar a que PO pertenece el empleado");

                        }

                    }
                    else
                    {
                        MessageBox.Show("No hay EPP seleccionados.");

                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el Empleado.");


                }

            }
            else
            {
                return;
            }


        }

        private void txtCedula_KeyPress_1(object sender, KeyPressEventArgs e)
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


            if (e.KeyChar == (int)Keys.Enter)
            {
                BuscarEmpleado();
            }
        }

        private void txtOracleID_KeyPress_1(object sender, KeyPressEventArgs e)
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


            if (e.KeyChar == (int)Keys.Enter)
            {
                BuscarEmpleado();
            }
        }

        private void dgProductos_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (dgProductos != null && dgProductos.CurrentCell.ColumnIndex == 3)
            {
                EditarCeldaCantidad();
            }

            if (dgProductos != null && dgProductos.CurrentCell.ColumnIndex == 4)
            {
                EditarCeldaPrecio();
            }
        }

        private void dgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgProductos_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgProductos != null && dgProductos.CurrentCell.ColumnIndex == 3)
            {
                EditarCeldaCantidad();
            }

            if (dgProductos != null && dgProductos.CurrentCell.ColumnIndex == 4)
            {
                EditarCeldaPrecio();
            }
        }

        private void dgProductos_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalcularTotal();
        }

        private void dgProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalcularTotal();
        }

        private void txtCodigobarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtError.Clear();


            


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



            if (e.KeyChar == (int)Keys.Enter)
            {
                if (txtCodigobarra.Text.Length > 0)
                {
                    if (txtNombreEmpleado.Text.Length > 0)
                    {
                        btnFacrurar.Enabled = true;
                        txtCodigobarra.Enabled = false;


                        //  string urljsonConsulta = Datos.Consultar3("urlconsulta", "principal", "where id=1").Rows[0][0].ToString();

                        string urljsonConsulta = "HTTP://navarrowindows.ddns.net/BPRESTSERVICES/GETWEBCATALOGPAGINADO.RSVC?INCLUIRCOSTO=SI?PAGINA=1&ROWSPORPAGINA=3000&CODIGO=" + txtCodigobarra.Text;

                        WebClient wc1 = new WebClient();

                        var datos1 = wc1.DownloadString(urljsonConsulta);

                        var rs1 = JsonConvert.DeserializeObject<repuesta>(datos1);

                        foreach (var item in rs1.Rows)
                        {
                            if (item.linea == "EPP")
                            {
                                if (item.codigo != int.Parse(txtCodigobarra.Text)) continue;
                                IdP = item.codigo;

                                idproductoR = item.codigo.ToString();
                                nombreproductoR = item.nombre;
                                cantidadR = item.existencia;
                                tvR = item.especificacion;
                                precioR = item.costo_ult;


                                if (tvR == "")
                                {

                                    MessageBox.Show("EPP SELECIONADO LE FALTA EL TIEMPO DE VIDA ULTIL");


                                }
                                else
                                {


                                    if (item.codigo == IdP)
                                    {
                                        int Cnt = Int32.Parse(item.existencia);

                                        Cant_ = Cnt;
                                        C.Close();

                                        if (Cant_ > 0)
                                        {

                                            if (dgProductos.Rows.Count != 0)
                                            {
                                                bool temp = false;
                                                foreach (DataGridViewRow R in dgProductos.Rows)
                                                {

                                                    if (R.Cells["idproducto"].Value.ToString() == idproductoR)
                                                    {

                                                        temp = true;
                                                        indexRow = R.Index;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        temp = false;
                                                    }
                                                }
                                                if (temp)
                                                {

                                                    //int a = int.Parse(dgProductos.Rows[indexRow].Cells["Cantidad"].Value.ToString()) + 1;

                                                    //dgProductos.Rows[indexRow].Cells["Cantidad"].Value = a.ToString();

                                                    MessageBox.Show("EL EPP YA ESTA SELECIONADA");

                                                }
                                                else
                                                {

                                                    validarFechaVence();

                                                    if (txtFechaVenceProductoDespachado.Text.Length > 0)
                                                    {
                                                        DateTime f = dtpFecha.Value;
                                                        string fechaActual = f.ToString("dd/MM/yyy");

                                                        DateTime f1 = Convert.ToDateTime(fechaActual);
                                                        int fechaA = Int32.Parse(f1.ToString("yyyyMMdd"));

                                                        DateTime f2 =
                                                            Convert.ToDateTime(txtFechaVenceProductoDespachado.Text);
                                                        int fechaB = Int32.Parse(f2.ToString("yyyyMMdd"));


                                                        if (fechaA >= fechaB)
                                                        {
                                                            DateTime inicio = dtpFecha.Value;
                                                            int cantidad = int.Parse(tvR);
                                                            for (int r = 0; r < cantidad; r++)
                                                            {

                                                                inicio = inicio.AddDays(1);
                                                                FechaVenceporEPP = inicio.ToString("dd/MM/yyy");

                                                            }

                                                            //double cost = precioR;

                                                            //double SubTotal = cost;



                                                            //string subTotalD = Math.Round(SubTotal, 2).ToString("#.00");


                                                            dgProductos.Rows.Add(idproductoR, idempleado, nombreproductoR, "1", precioR, precioR, tvR, FechaVenceporEPP, "0");



                                                            btnBuscarCliente.Enabled = false;

                                                        }
                                                        else
                                                        {

                                                            panel1.Visible = true;

                                                            txtNombreE.Text = txtNombreEmpleado.Text;
                                                            txtApellidoE.Text = txtApellido.Text;
                                                            txtCedulaE.Text = txtCedula.Text;

                                                            txtAreaE.Text = txtArea.Text;

                                                            txtIdProductoE.Text = idproductoR;
                                                            txtNombreProductoE.Text = nombreproductoR;
                                                            txtFechavenceE.Text = txtFechaVenceProductoDespachado.Text;

                                                            txtMensaje.Text += "MENSAJE DE APROBACIÓN \r\n ";
                                                            txtMensaje.Text += "EMPLEADO: " + txtNombreEmpleado.Text + " " +
                                                                               txtApellido.Text + " \r\n ";
                                                            txtMensaje.Text += "CEDULA: " + txtCedula.Text + " \r\n ";
                                                            txtMensaje.Text += "TRABAJA EN AREA: " + txtArea.Text + " \r\n ";
                                                            txtMensaje.Text += "REGISTRA UNA SALIDA DEL EPP, CODIGO: " +
                                                                               idproductoR + " DESCRIPCIÓN: " +
                                                                               nombreproductoR + " \r\n ";
                                                            txtMensaje.Text += "DICHO EPP VENCE EN FECHA : " +
                                                                               txtFechaVenceProductoDespachado.Text +
                                                                               " \r\n ";
                                                            txtMensaje.Text += "OBSERVACIÓN: " + txtObservacionE.Text +
                                                                               " \r\n ";

                                                        }
                                                    }
                                                    else
                                                    {

                                                        DateTime inicio = dtpFecha.Value;
                                                        int cantidad = int.Parse(tvR);
                                                        for (int r = 0; r < cantidad; r++)
                                                        {

                                                            inicio = inicio.AddDays(1);
                                                            FechaVenceporEPP = inicio.ToString("dd/MM/yyy");

                                                        }

                                                        //double cost = precioR;

                                                        //double SubTotal = cost;



                                                        //string subTotalD = Math.Round(SubTotal, 2).ToString("#.00");


                                                        dgProductos.Rows.Add(idproductoR, idempleado, nombreproductoR, "1", precioR, precioR, tvR, FechaVenceporEPP, "0");


                                                        btnBuscarCliente.Enabled = false;


                                                    }


                                                }
                                            }
                                            else
                                            {



                                                validarFechaVence();

                                                if (txtFechaVenceProductoDespachado.Text.Length > 0)
                                                {
                                                    DateTime f = dtpFecha.Value;
                                                    string fechaActual = f.ToString("dd/MM/yyy");

                                                    DateTime f1 = Convert.ToDateTime(fechaActual);
                                                    int fechaA = Int32.Parse(f1.ToString("yyyyMMdd"));

                                                    DateTime f2 = Convert.ToDateTime(txtFechaVenceProductoDespachado.Text);
                                                    int fechaB = Int32.Parse(f2.ToString("yyyyMMdd"));


                                                    if (fechaA >= fechaB)
                                                    {
                                                        DateTime inicio = dtpFecha.Value;
                                                        int cantidad = int.Parse(tvR);
                                                        for (int r = 0; r < cantidad; r++)
                                                        {

                                                            inicio = inicio.AddDays(1);
                                                            FechaVenceporEPP = inicio.ToString("dd/MM/yyy");

                                                        }

                                                        dgProductos.Rows.Add(idproductoR, idempleado, nombreproductoR, "1", precioR, precioR, tvR, FechaVenceporEPP, "0");


                                                        btnBuscarCliente.Enabled = false;

                                                    }
                                                    else
                                                    {

                                                        panel1.Visible = true;

                                                        txtNombreE.Text = txtNombreEmpleado.Text;
                                                        txtApellidoE.Text = txtApellido.Text;
                                                        txtCedulaE.Text = txtCedula.Text;

                                                        txtAreaE.Text = txtArea.Text;

                                                        txtIdProductoE.Text = idproductoR;
                                                        txtNombreProductoE.Text = nombreproductoR;
                                                        txtFechavenceE.Text = txtFechaVenceProductoDespachado.Text;

                                                        txtMensaje.Text += "MENSAJE DE APROBACIÓN \r\n ";
                                                        txtMensaje.Text += "EMPLEADO: " + txtNombreEmpleado.Text + " " +
                                                                           txtApellido.Text + " \r\n ";
                                                        txtMensaje.Text += "CEDULA: " + txtCedula.Text + " \r\n ";
                                                        txtMensaje.Text += "TRABAJA EN AREA: " + txtArea.Text + " \r\n ";
                                                        txtMensaje.Text += "REGISTRA UNA SALIDA DEL EPP, CODIGO: " +
                                                                           idproductoR + " DESCRIPCIÓN: " + nombreproductoR +
                                                                           " \r\n ";
                                                        txtMensaje.Text += "DICHO EPP VENCE EN FECHA : " +
                                                                           txtFechaVenceProductoDespachado.Text + " \r\n ";
                                                        txtMensaje.Text += "OBSERVACIÓN: " + txtObservacionE.Text + " \r\n ";

                                                    }
                                                }
                                                else
                                                {

                                                    DateTime inicio = dtpFecha.Value;
                                                    int cantidad = int.Parse(tvR);
                                                    for (int r = 0; r < cantidad; r++)
                                                    {

                                                        inicio = inicio.AddDays(1);
                                                        FechaVenceporEPP = inicio.ToString("dd/MM/yyy");

                                                    }

                                                    //double cost = precioR;

                                                    //double SubTotal = cost;

                                                    //string subTotalD = Math.Round(SubTotal, 2).ToString("#.00");


                                                    dgProductos.Rows.Add(idproductoR, idempleado, nombreproductoR, "1", precioR, precioR, tvR, FechaVenceporEPP, "0");



                                                    btnBuscarCliente.Enabled = false;


                                                }

                                            }


                                            btnFacrurar.Enabled = true;

                                        }
                                        else
                                        {
                                            MessageBox.Show("La Cantidad Esta en  :  " + Cant_ + "  Favor revise sus Stock ");
                                            C.Close();

                                        }

                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("CODIGO IMPRESADO NO PERTENECES A CATEGORIA EPP");
                            }
                        }

                        txtCodigobarra.Enabled = true;

                    }
                    else
                    {

                        MessageBox.Show("Para buscar un EPP primero ingrese el empleado");
                    }

                    txtCodigobarra.Clear();
                    txtCodigobarra.Focus();

                    CalcularTotal();
                }
                else
                {
                    MessageBox.Show("EL VALOR INGRESADO DEBE DE SER UN ENTERO POSITIVO");
                    txtCodigobarra.Focus();
                    txtCodigobarra.Clear();
                }

            }


        


        }

        private void button3_Click_4(object sender, EventArgs e)
        {
           
            }

        private void CmbPo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            BuscarId_Departamento();
        }


        private void BuscarId_Departamento()
        {
            C.Close();

            MySqlCommand cmd = new MySqlCommand("select idPO from po where NombrePO=@NombrePO", C);
            cmd.Parameters.AddWithValue("NombrePO", CmbPo.Text);

            C.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            if (leer != null && leer.Read())
            {
                recibeID_Departamento = leer.GetInt32(leer.GetOrdinal("idPO"));
            }
            C.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void BuscarId_Documento()
        {
            C.Close();

            MySqlCommand cmd = new MySqlCommand("select id_tipo_documento,Codigo_Documento,codigo_inventario,nombre_almacen from tipodocumentohellpad where nombre_documento=@nombre_documento", C);
            cmd.Parameters.AddWithValue("nombre_documento", CmbDocumento.Text);

            C.Open();

            MySqlDataReader leer = cmd.ExecuteReader();

            if (leer != null && leer.Read())
            {
                txttipodocumento.Text = leer.GetInt32(leer.GetOrdinal("id_tipo_documento")).ToString();
                txtarmancen.Text = leer.GetString(leer.GetOrdinal("codigo_inventario"));
                txtNombreAlmacen.Text = leer.GetString(leer.GetOrdinal("nombre_almacen"));
                txtdocumento.Text = leer.GetString(leer.GetOrdinal("Codigo_Documento"));


            }
            C.Close();
        }

        private void CmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarId_Documento();
        }

        private void txtobservacion_TextChanged(object sender, EventArgs e)
        {
            string[] palabras = new string[1];
            palabras[0] = txtobservacion.Text;
            //  palabras[1] = "Mundo";

            int numCaracteres = 0;
            for (int i = 0; i < palabras.Length; i++)
            {
                numCaracteres += palabras[i].Length;
            }
            lblContador.Text = numCaracteres.ToString();
        }

        private void txtCodigobarra_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_5(object sender, EventArgs e)
        {
           // MessageBox.Show("" + dtpFecha.Value.ToString("yyyy-MM-dd h:mm tt"));
        }



        }

        
    }

