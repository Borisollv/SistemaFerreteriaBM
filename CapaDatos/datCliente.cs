using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{
    public class datCliente
    {
        #region singleton
        private static readonly datCliente UnicaInstancia = new datCliente();
        public static datCliente Instancia
        {
            get
            {
                return UnicaInstancia;
            }
        }
        #endregion

        #region metodos
        public Cliente VerificarInicioSesion(string usuario, string contrasena)
        {
            Cliente? e = null;
            SqlCommand? cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); // Conexión a la base de datos
                cmd = new SqlCommand("spVerificarInicioSesion", cn); // Consulta SQL a la base de datos
                cmd.CommandType = CommandType.StoredProcedure; // Tipo de consulta
                cmd.Parameters.AddWithValue("@praUsuario", usuario); // Parámetro de la consulta
                cmd.Parameters.AddWithValue("@praContrasena", contrasena); // Parámetro de la consulta
                cn.Open(); // Abrir la conexión
                SqlDataReader dr = cmd.ExecuteReader(); // Ejecutar la consulta

                if (dr.Read())
                {
                    e = new Cliente(); // Instanciar la clase Cliente
                    e.IdCliente = Convert.ToInt32(dr["idCliente"]); // Asignar el valor a la propiedad
                    e.Nombres = Convert.ToString(dr["Nombres"]); // Asignar el valor a la propiedad
                    e.Direccion = Convert.ToString(dr["Direccion"]); // Asignar el valor a la propiedad
                    e.Telefono = Convert.ToString(dr["Telefono"]); // Asignar el valor a la propiedad
                }
            }

            catch (Exception)
            {
                throw;
            }

            return e;
        }
    }
}


#endregion
