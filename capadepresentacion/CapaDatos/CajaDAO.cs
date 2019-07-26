using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidad;
using Npgsql;

namespace CapaDatos
{
    public class CajaDAO
    {
        #region "PATRON SINGLETON"
        private static CajaDAO daoCaja = null;
        private CajaDAO() { }
        public static CajaDAO getInstance()
        {
            if (daoCaja == null)
            {
                daoCaja = new CajaDAO();
            }
            return daoCaja;
        }
        #endregion

        public bool RegistrarCaja(Caja objCaja)
        {
            NpgsqlConnection con = null;
            NpgsqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new NpgsqlCommand("INSERT INTO public.mercado(fecha_entrada, existencia,codigorack, id_etiqueta) VALUES('now()', 'true', '" + objCaja.CodigoRack + "', '" + objCaja.ID_Etiqueta + "'); ", con);
                con.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    response = true;
                }
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        public List<Caja> listaCajas()
        {
            List<Caja> listas = new List<Caja>();
            NpgsqlConnection con = null;
            NpgsqlCommand cmd = null;
            NpgsqlDataReader dr = null;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new NpgsqlCommand("SELECT * FROM mercado mer INNER JOIN infoetiqueta inf ON mer.id_etiqueta = inf.numserie", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //crear objetos tipo caja
                    Caja objCaja = new Caja();
                    objCaja.FechaEntrada = dr["fechacreacion"].ToString();
                    objCaja.CodigoRack = dr["codigorack"].ToString();
                    objCaja.Nivel = dr["nivel"].ToString();
                    objCaja.ID_Etiqueta = dr["id_etiqueta"].ToString();
                    objCaja.Fila = "C";
                    objCaja.Liberacion = Convert.ToString((DateTime.Now - Convert.ToDateTime(dr["fechacreacion"].ToString())).TotalHours);
                    objCaja.NoParte = dr["numparte"].ToString();
                    // añadir a la lista de objetos
                    listas.Add(objCaja);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return listas;
        }
        public bool ConsultarCaja(string numserie)
        {
            int contador = 0;
            int tiempoSecado = 0;
            NpgsqlConnection con = null;
            NpgsqlCommand cmd = null;
            NpgsqlDataReader dr = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new NpgsqlCommand("SELECT * FROM mercado mer INNER JOIN infoetiqueta inf ON mer.id_etiqueta = inf.numserie WHERE mer.id_etiqueta = '" + numserie+"';", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tiempoSecado = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(dr["fechacreacion"].ToString())).TotalHours);
                    contador++;
                }

            }catch(Exception ex)
            {
                response = false;
            }
            finally
            {
                con.Close();
            }
            if(tiempoSecado >= 4)
            {
                response = true;
            }
            else
            {
                response = false;
            }
            return response;
        }
        public bool EliminarCaja(string numserie)
        {
            NpgsqlConnection con = null;
            NpgsqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new NpgsqlCommand("DELETE FROM mercado WHERE id_etiqueta = '"+numserie+"';", con);
                con.Open();
                cmd.ExecuteNonQuery();
                response = true;
            }
            catch(Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }
        public bool RegistrarCajaScaner(Caja objCaja)
        {
            NpgsqlConnection con = null;
            NpgsqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new NpgsqlCommand("INSERT INTO public.mercado(fecha_entrada, existencia, nivel, codigorack, id_usuario, id_etiqueta, fila, rack) VALUES('now()', true, '"+objCaja.Nivel+"', '"+objCaja.CodigoRack+"', '"+objCaja.ID_Usuario+"', '"+objCaja.ID_Etiqueta+"', '"+objCaja.Fila+"', '"+objCaja.Rack+"'); ", con);
                con.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0)
                {
                    response = true;
                }
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }
    }
}
