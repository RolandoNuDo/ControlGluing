using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidad;
using Npgsql;
using Npgsql.PostgresTypes;
using NpgsqlTypes;
namespace CapaDatos
{
    public class UsuarioDAO
    {
        #region "PATRON SINGLETON"
        private static UsuarioDAO daoUsuario = null;
        private UsuarioDAO() { }
        public static UsuarioDAO getInstance()
        {
            if(daoUsuario == null)
            {
                daoUsuario = new UsuarioDAO();
            }
            return daoUsuario;
        }
        #endregion

        public Usuario AccesoSitema(string user, string pass)
        {
            NpgsqlConnection conexion = null;
            NpgsqlCommand cmd = null;
            Usuario objUsuario = null;
            NpgsqlDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new NpgsqlCommand("SELECT * FROM usuarios WHERE usuario = '"+user+"' AND contrasenia = '"+pass+"';", conexion);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objUsuario = new Usuario();
                    objUsuario.ID = Convert.ToInt32(dr["id_usuario"].ToString());
                    objUsuario.User = dr["usuario"].ToString();
                    objUsuario.Password = dr["contrasenia"].ToString();
                    objUsuario.Nivel = dr["Nivel"].ToString();
                }
            }catch(Exception ex)
            {
                objUsuario = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return objUsuario;
        }
    }
}
