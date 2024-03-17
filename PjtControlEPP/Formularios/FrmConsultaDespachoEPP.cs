using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PjtControlEPP.Formularios
{
    public partial class FrmConsultaDespachoEPP : Form
    {
        public FrmConsultaDespachoEPP()
        {
            InitializeComponent();
        }

        private void FrmConsultaDespachoEPP_Load(object sender, EventArgs e)
        {
           
           
           
          

        }


        private void BtnLocalizar_Click(object sender, EventArgs e)
        {
            if (txtFechaDesde.Text.Length > 9)
            {
                if (txtFechaHasta.Text.Length > 9)
                {
                    try
                    {
                        this.consultasFacturaETableAdapter.FillDepsachoFecha(consultas.ConsultasFacturaE, DateTime.Parse(txtFechaDesde.Text), DateTime.Parse(txtFechaHasta.Text));

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Algo esta mal. " + ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Debe de ingresar la fecha final");
                }
            }
            else
            {
                MessageBox.Show("Debe de ingresar la fecha de inicio");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgDespacho_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string idfactura = dtgDespacho.CurrentRow.Cells["idfactura"].Value.ToString();

                string campos = "idfactura = '" + idfactura + "'";

                Datos.Actualizar("fecha", campos, "Id=1");



                FrmReciboEPP reciboEpp = new FrmReciboEPP();
                reciboEpp.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe de selecionar alguna salida ");
            }
        }
    }
}
