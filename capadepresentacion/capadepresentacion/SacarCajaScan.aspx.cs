using CapaLogica1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace capadepresentacion
{
    public partial class SacarCajaScan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCajaScan.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string borrar = txtNumSerie.Text;
            bool response = CajaLN.getInstance().Consulta(borrar);
            if (response)
            {
                bool response2 = CajaLN.getInstance().EliminarCaja(borrar);
                if (response2)
                {
                    Response.Write("<script>alert('La Caja fue retirada del mercado')</script>");
                }
                else
                {
                    Response.Write("<script>alert('No se pudo eliminar la caja')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Esta caja aun no cumple con sus 4 horas o no se encuentra dada de alta')</script>");
            }
            txtNumSerie.Text = "";
        }
    }
}