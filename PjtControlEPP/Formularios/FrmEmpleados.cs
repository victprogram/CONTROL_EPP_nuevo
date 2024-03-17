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
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }
        private MySqlConnection C = Datos.C;
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            Cargarempleados();
        }

        private void Cargarempleados()
        {
            Datos.Consultar("select idempleado,concat(nombre,' ',apellido) as nombre,telefono,cedula,oracleid,idarea,idPO from empleados", "empleados");
            dtgEmpleado.DataSource = Datos.ds.Tables["empleados"];

        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            FrmRegistrarEmpleado ingresarempleado = new FrmRegistrarEmpleado();
            ingresarempleado.Show();
            this.Close();
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            FrmModificarEmpleado modificarempleado = new FrmModificarEmpleado();

            if (dtgEmpleado.CurrentRow != null)
            {
                Int32 selecionado = (Int32)dtgEmpleado.CurrentRow.Cells["idempleado"].Value;
                modificarempleado.ResiveDatos = selecionado;
                modificarempleado.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("el usuario no esta selecionado");
            }
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Desea Eliminar el Empleado", "AVISO", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            else
            {
                if (dtgEmpleado.CurrentRow != null &&
                    (Datos.Eliminar("empleados", "idempleado=" + dtgEmpleado.CurrentRow.Cells["idempleado"].Value)))
                {
                    MessageBox.Show("Empleado fue eliminado");
                    Cargarempleados();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el Empleado");
                }
            }
        }

        private void btnSalirEmpleado_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            string consulta = "select idempleado,concat(nombre,' ',apellido) as nombre,telefono,cedula,oracleid,idarea,idPO from empleados";
            C.Open();
            BindingSource origen = new BindingSource();
            MySqlDataAdapter dt = new MySqlDataAdapter(consulta, C);
            System.Data.DataTable datatable = new DataTable();
            dt.Fill(datatable);
            origen.DataSource = datatable;
            this.dtgEmpleado.DataSource = origen;
            origen.Filter = "nombre LIKE '%" + txtBuscar.Text + "%'";
            C.Close();
        }

    }
}
