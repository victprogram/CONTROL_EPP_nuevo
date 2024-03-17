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
    public partial class FrmDestachoProductos : Form
    {
        public FrmDestachoProductos()
        {
            InitializeComponent();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmConsultaEmpleados empleados= new  FrmConsultaEmpleados();

            empleados.ShowDialog();

            if (empleados.Seleccion == "S")
            {
                txtNombre.Text = empleados.Nombre;
                txtApellido.Text = empleados.Apellido;
                txtCedula.Text = empleados.Cedula;
                txtArea.Text = empleados.Area;
              
            }
        }
    }
}
