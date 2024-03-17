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
    public partial class FrmConsultaEmpeadoPorUsuario : Form
    {
        public FrmConsultaEmpeadoPorUsuario()
        {
            InitializeComponent();
        }

        public string Idempleado;
        public string Nombre;
        public string Apellido;
        public string Cedula;
        public string Oracleid;
        public string Area;
        public string Seleccion = "Null";
        private void FrmConsultaEmpeadoPorUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'consultas.ConsultaEmpleadosPorUsuarios' Puede moverla o quitarla según sea necesario.
            this.consultaEmpleadosPorUsuariosTableAdapter.Fill(this.consultas.ConsultaEmpleadosPorUsuarios);

        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dtgEmpleados.CurrentRow != null)
            {


                Idempleado = dtgEmpleados.CurrentRow.Cells["idempleado"].Value.ToString();
                Cedula = dtgEmpleados.CurrentRow.Cells["cedula"].Value.ToString();
                Oracleid = dtgEmpleados.CurrentRow.Cells["oracleid"].Value.ToString();
                Nombre = dtgEmpleados.CurrentRow.Cells["nombre"].Value.ToString();
                Apellido = dtgEmpleados.CurrentRow.Cells["apellido"].Value.ToString();
                Area = dtgEmpleados.CurrentRow.Cells["nombrearea"].Value.ToString();



                Seleccion = "S";
                Close();


                this.Close();
            }
        }
    }
}
