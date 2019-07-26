using CapaEntidad;
using CapaLogica1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using capadepresentacion;

namespace capadepresentacion
{
    public partial class AgregarCajaScan : System.Web.UI.Page
    {
        int idUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["UserSessionObjeto"] != null)
                {
                    Usuario objUsuario = (Usuario)Session["UserSessionObjeto"];
                    idUsuario = objUsuario.ID;
                }
               
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("SacarCajaScan.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        private Caja GetEntity()
        {
            Caja objCaja = new Caja();
            if (txtRack.Text.Length > 8)
            {
                string filtro = "";
                filtro = txtRack.Text;
                int subString = filtro.Length;                
                objCaja.Rack = filtro.Substring(0,subString-3);
                objCaja.ID_Etiqueta = txtNumSerie.Text;
                objCaja.Fila = filtro.Substring(subString - 1);
                objCaja.Nivel = filtro.Substring(subString - 3, 2);
                objCaja.ID_Usuario = idUsuario;
                objCaja.CodigoRack = filtro;
            }
            else
            {
                objCaja = null;
            }

            return objCaja;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                //Registro de la caja 
                Caja objCaja = GetEntity();
                //enviar a la capa logica 
                bool response = CajaLN.getInstance().RegistroCajasScaner(objCaja);
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNumSerie.Text = "";
            txtRack.Text = "";
        }
    }
}