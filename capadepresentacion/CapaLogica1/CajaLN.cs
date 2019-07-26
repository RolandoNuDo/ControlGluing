using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaLogica1
{
    public class CajaLN
    {
        #region "PATRON SINGLETON"
        private static CajaLN objCaja = null;
        private CajaLN() { }
        public static CajaLN getInstance()
        {
            if (objCaja == null)
            {
                objCaja = new CajaLN();
            }
            return objCaja;
        }
        #endregion

        public bool RegistroCajas(Caja objCaja)
        {
            try
            {
                return CajaDAO.getInstance().RegistrarCaja(objCaja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool EliminarCaja(string numserie)
        {
            try
            {
                return CajaDAO.getInstance().EliminarCaja(numserie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Consulta(string numserie)
        {
            try
            {
                return CajaDAO.getInstance().ConsultarCaja(numserie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RegistroCajasScaner(Caja objCaja)
        {
            try
            {
                return CajaDAO.getInstance().RegistrarCajaScaner(objCaja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Caja> listaCajas()
        {
            try
            {
                return CajaDAO.getInstance().listaCajas();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
