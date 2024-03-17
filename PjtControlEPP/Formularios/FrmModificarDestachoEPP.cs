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
    public partial class FrmModificarDestachoEPP : Form
    {
        public FrmModificarDestachoEPP()
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
                    "HTTP://192.168.1.200/BPRESTSERVICES/EMPLEADO.RSVC?PAGINA=1&ROWSPORPAGINA=1000&CEDULA=" +
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

                        var datos = wc.DownloadString(UrlJsonConsulta);

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


            string urljsonConsultaC = "HTTP://192.168.1.200/BPRESTSERVICES/GETWEBCATALOGPAGINADO.RSVC?INCLUIRCOSTO=SI?PAGINA=1&ROWSPORPAGINA=3000&CODIGO=" + ResiveIDproducto;


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

                string urljsonConsultaItem = "HTTP://192.168.1.200/BPRESTSERVICES/GETWEBCATALOGPAGINADO.RSVC?INCLUIRCOSTO=SI?PAGINA=1&ROWSPORPAGINA=3000&CODIGO=" + ResiveIDproducto;


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
           


            string Orden =Datos.Consultar3("idfactura", "facturas", "ORDER BY facturas.idfactura DESC").Rows[0][0].ToString();

            Int32 NumOrden = Int32.Parse(Orden);

            Int32 SumNumOrden = NumOrden + 1;

            _idfactura = SumNumOrden.ToString();

            txtNumeroFactura.Text = _idfactura;



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


       


        private async void button3_Click_3(object sender, EventArgs e)
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
                                            txtError.Clear();

                                            string fecha = dtpFecha.Value.ToString("yyy/MM/dd");


                                            string NombreEmpleado = "" + txtNombreEmpleado.Text + " " + txtApellido.Text + "";


                                            //foreach (DataGridViewRow item in dgProductos.Rows)
                                            //{

                                            //    if (int.Parse(item.Cells["codigoautorizacion"].Value.ToString()) >= 1)
                                            //    {


                                            //        MySqlCommand cmd2 = new MySqlCommand("RegistrarAutorizacion", C)
                                            //        {
                                            //            CommandType = CommandType.StoredProcedure
                                            //        };

                                            //        DateTime fechavence = DateTime.Parse(item.Cells["FechaVence"].Value.ToString());
                                            //        cmd2.Parameters.Add(new MySqlParameter("_fecha", fecha));
                                            //        cmd2.Parameters.Add(new MySqlParameter("_idusuario", IdUsuario));
                                            //        cmd2.Parameters.Add(new MySqlParameter("_idempleado", idempleado));
                                            //        cmd2.Parameters.Add(new MySqlParameter("_idproducto", item.Cells["IdProducto"].Value.ToString()));
                                            //        cmd2.Parameters.Add(new MySqlParameter("_fechavence", fechavence.ToString("yyy/MM/dd")));
                                            //        cmd2.Parameters.Add(new MySqlParameter("_codigoautorizacion", item.Cells["codigoautorizacion"].Value.ToString()));
                                            //        cmd2.Parameters.Add(new MySqlParameter("_observacion", this.txtObservacionE.Text));

                                                    
                                            //        C.Open();
                                            //        cmd2.ExecuteNonQuery();

                                            //        C.Close();

                                            //    }
                                            //}




                                           // " UPDATE facturas SET fechaF = '" + fecha + "',idusuario = '" + IdUsuario + "',idempleado = '" + idempleado + "',Cedula = '" + txtCedula.Text + "',OracleID = '" + txtOracleID.Text + "',NombreEmpleado = '" + NombreEmpleado + "',Ocupacion = '" + txtOcupacion.Text + "',AreaTrabajo = '" + txtArea.Text + "',NombrePO = '" + CmbPo.Text + "',codigoaprovacion = '" + 0 + "',observacion = '" + txtobservacion.Text + "',nombre_documento = '" + CmbDocumento.Text + "' WHERE idfactura = " + txtBuscar.Text;




                                            //        cmd1.Parameters.Add(new MySqlParameter("_idempleado", idempleado));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_idproducto", item.Cells["IdProducto"].Value.ToString()));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_nombreepp", item.Cells["NombreProducto"].Value.ToString()));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_cantidad", item.Cells["Cantidad"].Value.ToString()));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_precio", item.Cells["Precio"].Value.ToString()));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_subtotal", item.Cells["subtotal"].Value.ToString()));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_tiempovida", item.Cells["tiempovida"].Value.ToString()));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_fechavence", fechavence.ToString("yyy/MM/dd")));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_codigoaprovacion", item.Cells["codigoautorizacion"].Value.ToString()));



                                string Tabla = "facturas";
                                string sql = "fechaF = '" + fecha + "',idusuario = '" + IdUsuario + "',idempleado = '" + txtIdEmpleado.Text + "',Cedula = '" + txtCedula.Text + "',OracleID = '" + txtOracleID.Text + "',NombreEmpleado = '" + NombreEmpleado + "',Ocupacion = '" + txtOcupacion.Text + "',AreaTrabajo = '" + txtArea.Text + "',NombrePO = '" + CmbPo.Text + "',codigoaprovacion = '" + 0 + "',observacion = '" + txtobservacion.Text + "',nombre_documento = '" + CmbDocumento.Text + "'";
                              
                                string condicion = "idfactura = " + txtBuscar.Text;


                                            if (Datos.Actualizar(Tabla,sql,condicion))
                                            {
                                                
                                            }


                                            foreach (DataGridViewRow item in dgProductos.Rows)
                                            {
                                                DateTime fechavence = DateTime.Parse(item.Cells["FechaVence"].Value.ToString());

                                                if (Datos.Actualizar("detallesfacturas", " idempleado = '" + item.Cells["idemp"].Value.ToString() + "', idproducto = '" + item.Cells["IdProducto"].Value.ToString() + "', nombreepp = '" + item.Cells["NombreProducto"].Value.ToString() + "', cantidad = '" + item.Cells["Cantidad"].Value.ToString() + "', precio = '" + item.Cells["Precio"].Value.ToString() + "', subtotal = '" + item.Cells["subtotal"].Value.ToString() + "', tiempovida = '" + item.Cells["tiempovida"].Value.ToString() + "', fechavence = '" + fechavence.ToString("yyy/MM/dd") + "', codigoaprovacion = '" + item.Cells["codigoautorizacion"].Value.ToString() + "' ", "idfactura ='" + txtBuscar.Text + "' and idempleado='" + txtIdEmpleado.Text + "' and idproducto='" + item.Cells["IdProducto"].Value.ToString() + "' "))
                                                {

                                                }
                                            }



                                           CargarFactura();

                                           DialogResult res = MessageBox.Show("DESEA IMPRIMIR?", "DATOS ACTUALIZADO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                                           if (res == DialogResult.Yes)
                                           {
                                              


                                               string campos1 = "idfactura = '" + txtBuscar.Text + "'";

                                               Datos.Actualizar("fecha", campos1, "Id=1");


                                               FrmReciboEPP reciboEpp = new FrmReciboEPP();
                                               reciboEpp.Show();
                                           }
                                           else
                                           {
                                               return;
                                           }

                         

                                    



                               

                                //  foreach (DataGridViewRow item in dgProductos.Rows)
                                //{

                                //    if (Datos.Actualizar("detallesfacturas", "idempleado = '" + idempleado + "',idproducto = '" + item.Cells["IdProducto"].Value.ToString() + "',nombreepp = '" + item.Cells["NombreProducto"].Value.ToString() + "',cantidad = '" + item.Cells["Cantidad"].Value.ToString() + "',precio = '" + item.Cells["Precio"].Value.ToString() + "',subtotal = '" + item.Cells["subtotal"].Value.ToString() + "',tiempovida = '" + item.Cells["tiempovida"].Value.ToString() + "',fechavence = '" + DateTime.Parse(item.Cells["FechaVence"].Value.ToString() + "',codigoaprovacion = '" + item.Cells["codigoautorizacion"].Value.ToString() + "' ", ""))
                                //    {
                                //        MessageBox.Show("Datos Actualizados");
                                //    }
                                //}





                                //  UPDATE detallesfacturas SET iddetallesfactura = ,idfactura = ,idempleado = ,idproducto = ,nombreepp = ,cantidad = ,precio = ,subtotal = ,tiempovida = ,fechavence = ,codigoaprovacion = ,estado = where 





                                            //string tablaactualizar ="Productos INNER JOIN DetallesFactura ON Productos.IdProducto=DetallesFactura.IdProducto";
                                            //string campoactualizar = "Productos.Cantidad = Productos.Cantidad+DetallesFactura.Cantidad";
                                            //string condicionactualizar = "DetallesFactura.Idfactura=" + ResiveIDDevolucion;

                                            //if (Datos.Actualizar(tablaactualizar, campoactualizar, condicionactualizar))
                                            //{
                                            //}

                                          

                                          //  MySqlCommand cmd = new MySqlCommand("RegistrarFactura", C)
                                          //  {
                                          //      CommandType = CommandType.StoredProcedure
                                          //  };

                                          //  cmd.Parameters.Add(new MySqlParameter("_fecha", fecha));
                                          //  cmd.Parameters.Add(new MySqlParameter("_idusuario", IdUsuario));
                                          //  cmd.Parameters.Add(new MySqlParameter("_idempleado", idempleado));
                                          //  cmd.Parameters.Add(new MySqlParameter("_Cedula", txtCedula.Text));
                                          //  cmd.Parameters.Add(new MySqlParameter("_OracleID", txtOracleID.Text));
                                          //  cmd.Parameters.Add(new MySqlParameter("_NombreEmpleado", NombreEmpleado));
                                          //  cmd.Parameters.Add(new MySqlParameter("_Ocupacion", txtOcupacion.Text));
                                          //  cmd.Parameters.Add(new MySqlParameter("_AreaTrabajo", txtArea.Text));
                                          //  cmd.Parameters.Add(new MySqlParameter("_NombrePO", CmbPo.Text));
                                          //  cmd.Parameters.Add(new MySqlParameter("_observacion", txtobservacion.Text));
                                          //  cmd.Parameters.Add(new MySqlParameter("_nombre_documento", CmbDocumento.Text));
                                          //  cmd.Parameters.Add(new MySqlParameter("_AfectaImpro", "NO"));
                                          ////  cmd.Parameters.Add(new MySqlParameter("_DatosImpro", carga));


                                          //  C.Open();
                                          //  cmd.ExecuteNonQuery();
                                          //  C.Close();




                                            //string noRecibo = Datos.Consultar3("idfactura", "facturas", "ORDER BY facturas.idfactura DESC").Rows[0][0].ToString();

                                            //_idfactura = noRecibo;


                                            //foreach (DataGridViewRow item in dgProductos.Rows)
                                            //{

                                            //    if (item.Cells["idproducto"].Value != null)
                                            //    {

                                            //        MySqlCommand cmd1 = new MySqlCommand("RegistrarDetalleFactura", C)
                                            //        {
                                            //            CommandType = CommandType.StoredProcedure
                                            //        };

                                            //        DateTime fechavence = DateTime.Parse(item.Cells["FechaVence"].Value.ToString());

                                            //        cmd1.Parameters.Add(new MySqlParameter("_idempleado", idempleado));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_idproducto", item.Cells["IdProducto"].Value.ToString()));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_nombreepp", item.Cells["NombreProducto"].Value.ToString()));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_cantidad", item.Cells["Cantidad"].Value.ToString()));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_precio", item.Cells["Precio"].Value.ToString()));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_subtotal", item.Cells["subtotal"].Value.ToString()));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_tiempovida", item.Cells["tiempovida"].Value.ToString()));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_fechavence", fechavence.ToString("yyy/MM/dd")));
                                            //        cmd1.Parameters.Add(new MySqlParameter("_codigoaprovacion", item.Cells["codigoautorizacion"].Value.ToString()));

                                            //        C.Open();
                                            //        cmd1.ExecuteNonQuery();
                                            //        C.Close();

                                            //    }

                                            //}





                                        






                                            //Int32 NumOrden = Int32.Parse(Orden);

                                            //Int32 SumNumOrden = NumOrden + 1;

                                            //_idfactura = SumNumOrden.ToString();





                                }
                                catch (Exception ex)
                                {

                                    DialogResult res =
                                       MessageBox.Show(
                                           "MOTIFIQUE A TECNOLOGIA. ESTE ERROR BLOQUEARA SU USUARIO POR SEGURIDAD Y SERRARA EL SISTEMA",
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
                if (txtNombreEmpleado.Text.Length > 0)
                {
                    btnFacrurar.Enabled = true;
                    txtCodigobarra.Enabled = false;


                  //  string urljsonConsulta = Datos.Consultar3("urlconsulta", "principal", "where id=1").Rows[0][0].ToString();

                    string urljsonConsulta = "HTTP://192.168.1.200/BPRESTSERVICES/GETWEBCATALOGPAGINADO.RSVC?INCLUIRCOSTO=SI?PAGINA=1&ROWSPORPAGINA=3000&CODIGO="+txtCodigobarra.Text;

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

                                MessageBox.Show( "EPP SELECIONADO LE FALTA EL TIEMPO DE VIDA ULTIL");


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

                                                MessageBox.Show("EL EPP YA ESTA SELECIONADO");

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
                                        MessageBox.Show( "La Cantidad Esta en  :  " + Cant_ + "  Favor revise sus Stock ");
                                        C.Close();

                                    }

                                }
                            }
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

            MySqlCommand cmd = new MySqlCommand("select id_tipo_documento,Codigo_Documento,codigo_inventario,nombre_almacen from tipodocumento where nombre_documento=@nombre_documento", C);
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


        private  DataTable QueryAsDataTable(string sql)
        {
            var da = new MySqlDataAdapter(sql, C);
            var ds = new DataSet();
            da.Fill(ds, "facturas");
            return ds.Tables["facturas"];
        }


        private void button3_Click_6(object sender, EventArgs e)
        {
           
            CargarFactura();
               

                
        }

        private void CargarFactura()
        {
            if (txtBuscar.Text.Length > 0)
            {
                dgProductos.Rows.Clear();


                string sql = "Select idfactura, fechaF, idusuario, idempleado, Cedula, OracleID, NombreEmpleado, Ocupacion, AreaTrabajo, NombrePO, codigoaprovacion, observacion, nombre_documento, AfectaImpro, estado from facturas where idfactura=" + txtBuscar.Text;
                var dt = QueryAsDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    {


                        txtNumeroFactura.Text = Convert.ToInt32(row["idfactura"]).ToString();
                        dtpFecha.Text = Convert.ToDateTime(row["fechaF"]).ToString();
                        string user = Convert.ToInt32(row["idusuario"]).ToString();
                        txtIdEmpleado.Text = Convert.ToInt32(row["idempleado"]).ToString();
                        txtCedula.Text = Convert.ToString(row["Cedula"]);
                        txtOracleID.Text = Convert.ToString(row["OracleID"]);
                        txtNombreEmpleado.Text = Convert.ToString(row["NombreEmpleado"]);
                        txtOcupacion.Text = Convert.ToString(row["Ocupacion"]);
                        txtArea.Text = Convert.ToString(row["AreaTrabajo"]);
                        CmbPo.Text = Convert.ToString(row["NombrePO"]);
                        txtobservacion.Text = Convert.ToString(row["observacion"]);
                        CmbDocumento.Text = Convert.ToString(row["nombre_documento"]);

                        string estado = Convert.ToChar(row["estado"]).ToString();



                        MySqlCommand cmd3 = new MySqlCommand("Select usuario from usuarios where idusuario=@idusuario", C);
                        cmd3.Parameters.AddWithValue("idusuario", user);
                        C.Open();
                        MySqlDataReader leer3 = cmd3.ExecuteReader();
                        if (leer3 != null && leer3.Read())
                        {
                            txtusuarioN.Text = leer3.GetString(leer3.GetOrdinal("usuario"));

                        }
                        C.Close();


                        if (estado == "1")
                        {
                            txtNombreEmpleado.Enabled = true;
                            txtApellido.Enabled = true;
                            txtArea.Enabled = true;
                            txtCedula.Enabled = true;
                            txtOracleID.Enabled = true;
                            CmbPo.Enabled = true;
                            txtobservacion.Enabled = true;
                            dgProductos.Enabled = true;
                            CmbDocumento.Enabled = true;
                            dtpFecha.Enabled = true;
                            btnBuscarCliente.Enabled = true;
                            txtCodigoConsulta.Enabled = true;
                            txtCodigoautorizacion.Enabled = true;
                            txtFechaVenceProductoDespachado.Enabled = true;
                            txtCodigobarra.Enabled = true;
                            txtTotal.Enabled = true;
                            txtOcupacion.Enabled = true;
                            txtIdEmpleado.Enabled = true;




                        }
                        else
                        {
                            if (estado == "0")
                            {
                                txtIdEmpleado.Enabled = false;
                                txtNombreEmpleado.Enabled = false;
                                txtApellido.Enabled = false;
                                txtArea.Enabled = false;
                                txtCedula.Enabled = false;
                                txtOracleID.Enabled = false;
                                CmbPo.Enabled = false;
                                txtobservacion.Enabled = false;
                                dgProductos.Enabled = false;
                                CmbDocumento.Enabled = false;
                                dtpFecha.Enabled = false;
                                btnBuscarCliente.Enabled = true;
                                txtCodigoConsulta.Enabled = false;
                                txtCodigoautorizacion.Enabled = false;
                                txtFechaVenceProductoDespachado.Enabled = false;
                                txtCodigobarra.Enabled = false;
                                txtTotal.Enabled = false;
                                txtOcupacion.Enabled = false;


                            }
                        }

                    }



                    //   string cadena = "SELECT iddetallesfactura,idfactura,idempleado,idproducto,nombreepp,cantidad,precio,subtotal,tiempovida,fechavence,codigoaprovacion,estado FROM detallesfacturas, facturas where  facturas.idfactura = detallesfacturas.idfactura and facturas.idempleado = detallesfacturas.idempleado and facturas.idfactura=" + txtBuscar.Text;

                    CargarDetallesItem();

                    C.Close();

                }
            }
            else
            {
                MessageBox.Show("DEBE DE INGRESAR LA ORDEN");
            }





        //string consulta = "select idfactura, fechaF, idusuario, idempleado,Cedula,OracleID,NombreEmpleado,AreaTrabajo,NombrePO, codigoaprovacion,observacion, estado from facturas order by idfactura asc";
            //C.Open();


            //  MySqlCommand cmd = new MySqlCommand("Select idfactura, fechaF, idusuario, idempleado, Cedula, OracleID, NombreEmpleado, Ocupacion, AreaTrabajo, NombrePO, codigoaprovacion, observacion, nombre_documento, AfectaImpro, estado from facturas where idfactura=" + txtBuscar, C);


            //MySqlCommand cmd = new MySqlCommand("Select idfactura, fechaF, idusuario, idempleado, Cedula, OracleID, NombreEmpleado, Ocupacion, AreaTrabajo, NombrePO, codigoaprovacion, observacion, nombre_documento, AfectaImpro, estado from facturas where idfactura=" + txtBuscar.Text, C);
            //C.Open();
            //MySqlDataReader leer = cmd.ExecuteReader();
            //if (leer != null && leer.Read())
            //{

            //    txtNumeroFactura.Text = leer.GetInt32(0).ToString();
            //    dtpFecha.Text = leer.GetDateTime(leer.GetOrdinal("fechaF")).ToShortDateString();
            //    string user = leer.GetString(2);
            //    txtIdEmpleado.Text = leer.GetString(3);
            //    txtCedula.Text = leer.GetString(4);
            //    txtOracleID.Text = leer.GetString(5);
            //    txtNombreEmpleado.Text = leer.GetString(6);
            //    txtOcupacion.Text = leer.GetString(7);
            //    txtArea.Text = leer.GetString(8);
            //    CmbPo.Text = leer.GetString(9);
            //    CmbDocumento.Text = leer.GetString(leer.GetOrdinal("nombre_documento"));







            //    C.Close();
            //    //busca la unidad Correspondiente


            //    MySqlCommand cmd3 = new MySqlCommand("Select usuario from usuarios where idusuario=@idusuario", C);
            //    cmd3.Parameters.AddWithValue("idusuario", user);
            //    C.Open();
            //    MySqlDataReader leer3 = cmd3.ExecuteReader();
            //    if (leer3 != null && leer3.Read())
            //    {
            //        txtusuarioN.Text = leer3.GetString(leer3.GetOrdinal("usuario"));

            //    }
            //    C.Close();




            //}
            //else
            //{
            //    MessageBox.Show("Los datos no se estan leyendo");
            //}

        }

        private void CargarDetallesItem()
        {
           
            dgProductos.Rows.Clear();
            
            
            string cadena = "SELECT detallesfacturas.idempleado,detallesfacturas.idproducto,detallesfacturas.nombreepp,detallesfacturas.cantidad,detallesfacturas.precio,detallesfacturas.subtotal,detallesfacturas.tiempovida,detallesfacturas.fechavence,detallesfacturas.codigoaprovacion,detallesfacturas.estado,detallesfacturas.iddetallesfactura  FROM facturas, detallesfacturas where facturas.idfactura = detallesfacturas.idfactura and facturas.idempleado = detallesfacturas.idempleado and facturas.idfactura=" + txtBuscar.Text;



            MySqlCommand cmd = new MySqlCommand(cadena, C);

            C.Open();


            MySqlDataReader leer = cmd.ExecuteReader();
            int renglon = 0;
            while (leer.Read())
            {
                renglon = dgProductos.Rows.Add();


                dgProductos.Rows[renglon].Cells["idemp"].Value = leer.GetInt32(0);
                dgProductos.Rows[renglon].Cells["IdProducto"].Value = leer.GetInt32(1);
                dgProductos.Rows[renglon].Cells["NombreProducto"].Value = leer.GetString(2);
                dgProductos.Rows[renglon].Cells["Cantidad"].Value = leer.GetInt16(3);
                dgProductos.Rows[renglon].Cells["Precio"].Value = leer.GetFloat(4);
                dgProductos.Rows[renglon].Cells["subtotal"].Value = leer.GetFloat(5);
                dgProductos.Rows[renglon].Cells["tiempovida"].Value = leer.GetInt32(6);
                dgProductos.Rows[renglon].Cells["FechaVence"].Value = leer.GetDateTime(7).ToString("dd-MM-yyy");
                dgProductos.Rows[renglon].Cells["codigoautorizacion"].Value = leer.GetString(8);
                dgProductos.Rows[renglon].Cells["estado"].Value = leer.GetString(9);
                dgProductos.Rows[renglon].Cells["iddetallesfactura"].Value = leer.GetString(10);


                

                //CalcularTotalVenta();
                //CalcularTotalProductos();
                //CalcularTotalDevolucion();
                //devuelta();
            }

            C.Close();



















        }

        private void btnAnularSalida_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                MySqlCommand cmd = new MySqlCommand("AnularFactura", C)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (txtBuscar.Text != null)
                {
                    cmd.Parameters.Add(new MySqlParameter("_idfactura", txtBuscar.Text));
                }
                


                C.Open();
                cmd.ExecuteNonQuery();
                C.Close();

                btnAnularSalida.Enabled = false;
                btnDeAnularSalida.Enabled = true;

                CargarFactura();




            }
            else
            {
                MessageBox.Show("Sabor colocar el numero de factura y dele a buscar");
            }
        }

        private void btnDeAnularSalida_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                MySqlCommand cmd = new MySqlCommand("AnularFactura", C)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (txtBuscar.Text != null)
                    cmd.Parameters.Add(new MySqlParameter("_idfactura", txtBuscar.Text));


                C.Open();
                cmd.ExecuteNonQuery();
                C.Close();

                CargarFactura();

                btnAnularSalida.Enabled = true;
                btnDeAnularSalida.Enabled = false;

          

            



            }
            else
            {
                MessageBox.Show("Sabor colocar el numero de factura y dele a buscar");
            }
        }

        private void btnDeAnularITEM_Click(object sender, EventArgs e)
        {


            if (txtBuscar.Text.Length > 0)
            {
                MySqlCommand cmd = new MySqlCommand("AnularITEM", C)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (dgProductos.CurrentRow != null)
                    cmd.Parameters.Add(new MySqlParameter("_iddetallesfactura", dgProductos.CurrentRow.Cells["iddetallesfactura"].Value.ToString()));


                C.Open();
                cmd.ExecuteNonQuery();
                C.Close();

                btnAnularITEM.Enabled = true;
                btnDeAnularITEM.Enabled = false;

                CargarDetallesItem();

                

            }
            else
            {
                MessageBox.Show("Sabor colocar el numero de factura y dele a buscar");
            }
            
            

        }

        private void btnAnularITEM_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                MySqlCommand cmd = new MySqlCommand("AnularITEM", C)
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (dgProductos.CurrentRow != null)
                    cmd.Parameters.Add(new MySqlParameter("_iddetallesfactura", dgProductos.CurrentRow.Cells["iddetallesfactura"].Value.ToString()));


                C.Open();
                cmd.ExecuteNonQuery();
                C.Close();

                btnAnularITEM.Enabled = false;
                btnDeAnularITEM.Enabled = true;

                CargarDetallesItem();

               

              
            }
            else
            {
                MessageBox.Show("Favor colocar el numero de factura y dele a buscar");
            }
        }

        private void dgProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void dgProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgProductos.Rows.Count > 0 && dgProductos.Columns.Count > 0)
            {
                foreach (DataGridViewRow r in dgProductos.Rows)
                {
                    if (Convert.ToString(r.Cells["estado"].Value) == "0")
                    {
                        r.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void BtnAgregarITEM_Click(object sender, EventArgs e)
        {

        }



        }

        
    }

