using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PjtControlEPP.Properties;

namespace PjtControlEPP
{
    class Datos
    {
        private static MySqlCommandBuilder cmb;
        public static DataSet ds = new DataSet();
        public static MySqlDataAdapter da;
        public static MySqlCommand cmd;
        // public static DataRow UsuarioRow;

     

        public static MySqlConnection C = new MySqlConnection(Settings.Default.CadenaConexion);

        public static MySqlDataAdapter DataAdapter = new MySqlDataAdapter("", C);

        //Este metodo me consulta los datos

        public static void Consultar(String sql, String tabla)
        {
            ds.Tables.Clear();
            da = new MySqlDataAdapter(sql, C);
            cmb = new MySqlCommandBuilder(da);
            da.Fill(ds, tabla);
        }

        //metodo Eliminar elementos

        public static bool Eliminar(String tabla, string condicion)
        {
            C.Open();
            string sql = "Delete from " + tabla + " Where " + condicion;
            cmd = new MySqlCommand(sql, C);
            int i = cmd.ExecuteNonQuery();
            C.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Actualizar los Datos

        public static bool Actualizar(String tabla, string campos, string condicion)
        {
            C.Open();
            string sql = "UPDATE " + tabla + " set " + campos + " where " + condicion;
            cmd = new MySqlCommand(sql, C);
            int i = cmd.ExecuteNonQuery();
            C.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static DataTable Consultar2(String tabla)
        {
            string Sql = "Select * from " + tabla;
            da = new MySqlDataAdapter(Sql, C);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;
        }

        // metodo de insertar datos

        public static bool Insertar(string Sql)
        {
            C.Open();
            cmd = new MySqlCommand(Sql, C);
            int i = cmd.ExecuteNonQuery();
            C.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static void Registrar(string InsertComando)
        {
            MySqlCommand CMD = new MySqlCommand(InsertComando, C);
            try
            {
                C.Open();
                CMD.ExecuteNonQuery();
                C.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message + "\nError al Insertar, SQL: " + InsertComando, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                C.Close();
            }
        }

        public static string ConsultarValor(string Campo, string Tabla, string Condicion)
        {
            try
            {


                DataTable Filtrado = new DataTable();
                DataAdapter.SelectCommand.CommandText = "Select " + Campo + " FROM " + Tabla + " " + Condicion;
                C.Open();
                DataAdapter.Fill(Filtrado);
                C.Close();
                if (Filtrado.Rows.Count != 0)
                {
                    return Filtrado.Rows[0][0].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(
                    E.Message + "\nError al intentar filtrar, Campo: " + Campo + ", Tabla: " + Tabla + ", Condición: " +
                    Condicion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                C.Close();
            }
        }

        public static DataTable Consultar3(string Campos, string Tabla, string Condicion)
        {
            try
            {
                DataTable Filtrado = new DataTable();
                DataAdapter.SelectCommand.CommandText = "Select " + Campos + " FROM " + Tabla + " " + Condicion;
                C.Open();
                DataAdapter.Fill(Filtrado);
                C.Close();
                return Filtrado;
            }
            catch (Exception E)
            {
                MessageBox.Show(
                    E.Message + "\n\n/nError al Consultar, Campo: " + Campos + ", Tabla: " + Tabla + ", Condición: " +
                    Condicion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                C.Close();
            }

        }
    }
}