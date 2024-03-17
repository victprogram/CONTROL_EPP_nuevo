using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PjtControlEPP
{
    public partial class Salida
    {
        public int Almacen { get; set; }
        public string Usuario { get; set; }
        public string Doc { get; set; }
        public int Tipodoc { get; set; }
        public string fecha_hora { get; set; }
        public List<Detalle> Detalle { get; set; }
        public string Obs { get; set; }
        public int Dpto { get; set; }
        
    }

    public partial class Detalle
    {
        public int Cantidad { get; set; }
        public string Comentario { get; set; }
        public int Item { get; set; }
    }

    public class Row
    {
        public string linea { get; set; }
        public string nombre { get; set; }
        //  public string precio { get; set; }
        public string barras { get; set; }
        public string especificacion { get; set; }
        public int codigo { get; set; }
        //  public int tax1 { get; set; }
        //  public int taxporc1 { get; set; }
        //  public int tax2 { get; set; }
        //   public int taxporc2 { get; set; }
        //    public double descuento_maximo { get; set; }
        public string existencia { get; set; }
        //   public int cantporempaque { get; set; }
        //public int ventaminima { get; set; }
        public double costo_ult { get; set; }
        //public double precio1 { get; set; }
        //public double precio2 { get; set; }
        //public double precio3 { get; set; }
        //public double precio4 { get; set; }
        //public double precio5 { get; set; }
        //public double precio6 { get; set; }
        
        //public string barras { get; set; }
        //public int cantporempaque { get; set; }
        //public int codigo { get; set; }
        //public double comision { get; set; }
        //public double costo_prom { get; set; }
        //public double costo_ult { get; set; }
        //public double descuento { get; set; }
        //public double descuento_maximo { get; set; }
        //public string dpto { get; set; }
        //public bool enexistencia { get; set; }
        //public string especificacion { get; set; }
        //public int existencia { get; set; }
        //public object familia { get; set; }
        //public DateTime fecha_ultima_compra { get; set; }
        //public string foto { get; set; }
        //public string linea { get; set; }
        //public string marca { get; set; }
        //public string nombre { get; set; }
        //public double precio { get; set; }
        //public double precio1 { get; set; }
        //public double precio2 { get; set; }
        //public double precio3 { get; set; }
        //public double precio4 { get; set; }
        //public double precio5 { get; set; }
        //public double precio6 { get; set; }
        //public string referencia { get; set; }
        //public int tax1 { get; set; }
        //public int tax2 { get; set; }
        //public int taxporc1 { get; set; }
        //public int taxporc2 { get; set; }
        //public string unidadventa { get; set; }
        //public int ventaminima { get; set; } 

        
    }

    public class repuesta
    {
        public IList<Row> Rows { get; set; }
    }

    public class Empleados
    {

        //public string afp_nombre { get; set; }
        public string apellidos { get; set; }
        //public string ars_nombre { get; set; }
        public string cargo_nombre { get; set; }
        public string cedula { get; set; }
        public string otrocodigo { get; set; }
        //public string ciudad_nombre { get; set; }
        public string codigo { get; set; }
        //public string direccion { get; set; }
        public string dpto_nombre { get; set; }
        //public string email { get; set; }
        //public string emergencia { get; set; }
        //public DateTime entrada { get; set; }
        //public string estado_nombre { get; set; }
        //public bool extranjero { get; set; }
        //public string foto { get; set; }
        //public DateTime nacimiento { get; set; }
       // public string nombre { get; set; }
        public string nombres { get; set; }
        //public string sexo { get; set; }
        //public bool soltero { get; set; }
        //public string sucursal_nombre { get; set; }
        public string tel1 { get; set; }
        //public string tel2 { get; set; }
        //public string tel3 { get; set; }
        //public string tel4 { get; set; }
        //public int tipo { get; set; } 

    }

    public class repuestaEmpleado
    {
        public IList<Empleados> Rows { get; set; }
    }


   
}
