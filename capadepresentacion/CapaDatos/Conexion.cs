using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace CapaDatos
{
    public class Conexion
    {
        #region "PATRON SINGLETON"
        private static Conexion conexion = null;
        private Conexion()
        {
        }
        public static Conexion getInstance()
        {
            if(conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }
        #endregion

        public NpgsqlConnection ConexionBD()
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = "Server = localhost; Database = gluing; User Id = postgres; Password = root;";
            return conexion;
        }
    }
}
