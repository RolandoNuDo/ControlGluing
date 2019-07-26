using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using capadepresentacion.Custom;
using CapaEntidad;
using CapaLogica1;

namespace capadepresentacion
{
    public partial class WebForm1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        private Caja GetEntity()
        {
            Caja objCaja = new Caja();
            objCaja.CodigoRack = txtRack.Text;
            objCaja.ID_Etiqueta = txtNumSerie.Text;
            return objCaja;
        }
        [WebMethod]
        public static List<Caja> ListarCajas()
        {
            List<Caja> Lista = null;
            try
            {
                Lista = CajaLN.getInstance().listaCajas();
            }
            catch(Exception ex)
            {
                Lista = null; 
            }
            return Lista;
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                //Registro de la caja 
                Caja objCaja = GetEntity();
                //enviar a la capa logica 
                bool response = CajaLN.getInstance().RegistroCajas(objCaja);
                if (response)
                {
                    txtNumSerie.Text = "";
                    txtRack.Text = "";
                    Response.Write("<script>alert('Registro Correcto')</script>");
                }
                else
                {
                    txtNumSerie.Text = "";
                    txtRack.Text = "";
                    Response.Write("<script>alert('Registro Incorrecto')</script>");
                }
            }
        }
    }
}