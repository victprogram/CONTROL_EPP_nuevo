using System;
using System.Net;
using System.Windows.Forms;

using Newtonsoft.Json;
using Telerik.WinControls.UI;
using Application = System.Windows.Forms.Application;


namespace PjtControlEPP.Formularios
{
    public partial class FrmConsultaInventario : Form
    {
        public FrmConsultaInventario()
        {
            InitializeComponent();
        }

        public string idproducto;
        public string nombreproducto;
        public string cantidad;
        public string tiempovida;
        public string precio;
        public string Seleccion = "Null";

      

        private void FrmConsultaInventario_Load(object sender, EventArgs e)
        {
            
            string urljsonConsulta = Datos.Consultar3("urlconsulta", "principal", "where id=1").Rows[0][0].ToString();
            
            WebClient wc = new WebClient();


          

            var datos = wc.DownloadString(urljsonConsulta);

            var rs = JsonConvert.DeserializeObject<repuesta>(datos);

            foreach (var item in rs.Rows)
            {
               if (item.linea == "EPP")
                {
                    dtgProductos.Rows.Add(item.linea, item.codigo, item.barras, item.nombre, item.existencia, item.costo_ult, item.especificacion);

                   
                
                }
            }
       
           
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dtgProductos.CurrentRow != null)
                {


                    idproducto = dtgProductos.CurrentRow.Cells["idproducto"].Value.ToString();
                    nombreproducto = dtgProductos.CurrentRow.Cells["nombreproducto"].Value.ToString();
                    cantidad = dtgProductos.CurrentRow.Cells["cantidad"].Value.ToString();
                    precio = dtgProductos.CurrentRow.Cells["Precio"].Value.ToString();
                    tiempovida = dtgProductos.CurrentRow.Cells["tiempovida"].Value.ToString();

                    this.DialogResult = DialogResult.OK;
                    Close();


                }
                else
                {
                    MessageBox.Show("Debe de selecionar algun articulo");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: "+ ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewExcel(dtgProductos);
        }

        private void ExportarDataGridViewExcel(RadGridView dtgProductos)
        {
            //SaveFileDialog fichero = new SaveFileDialog();
            //fichero.Filter = "Excel (*.xls)|*.xls";
            //if (fichero.ShowDialog() == DialogResult.OK)
            //{
            //    Workbook libros_trabajo;
            //    Worksheet hoja_trabajo;
            //    var aplicacion = new Application();
            //    libros_trabajo = aplicacion.Workbooks.Add();
            //    hoja_trabajo =
            //        (Worksheet)libros_trabajo.Worksheets.get_Item(1);
            //    //Recorremos el DataGridView rellenando la hoja de trabajo
            //    for (int i = 0; i < dtgProductos.Rows.Count - 1; i++)
            //    {
            //        for (int j = 0; j < dtgProductos.Columns.Count; j++)
            //        {
            //            hoja_trabajo.Cells[i + 1, j + 1] = dtgProductos.Rows[i].Cells[j].Value.ToString();
            //        }
            //    }
            //    libros_trabajo.SaveAs(fichero.FileName,
            //        XlFileFormat.xlWorkbookNormal);
            //    libros_trabajo.Close(true);
            //    aplicacion.Quit();
            //}
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
           
        }

       


    }
}
