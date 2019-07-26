using System;
using System.Collections.Generic;
using System.Text;
using CapaDatos;
using CapaEntidad;
namespace CapaLogica1
{
    public class UsuarioL
    {
        #region "PATRON SINGLETON"
        private static UsuarioL objUsuario = null;
        private UsuarioL() { }
        public static UsuarioL getInstance()
        {
            if (objUsuario == null)
            {
                objUsuario = new UsuarioL();
            }
            return objUsuario;
        }
        #endregion
        public Usuario AccesoSitema(string user, string pass)
        {            
            try
            {
                return UsuarioDAO.getInstance().AccesoSitema(user, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
