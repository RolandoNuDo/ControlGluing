using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using capadepresentacion.Custom;
using CapaEntidad;
using CapaLogica1;
using CapaPresentacion.Custom;

namespace capadepresentacion
{
    public partial class Login1 : BasePage
    {
        public string idUsuario = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["UserSession"] = null;
            }
        }
        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool auth = Membership.ValidateUser(LoginUser.UserName, LoginUser.Password);
            if (auth)
            {
                Usuario objUsuario = UsuarioL.getInstance().AccesoSitema(LoginUser.UserName, LoginUser.Password);
                if (objUsuario != null)
                {
                    SessionManager = new SessionManager(Session);
                    SessionManager.UserSessionObjeto = objUsuario;
                    //Response.Write("<script>alert('Usuario Correcto')</script>");
                    //Response.Redirect("PanelGeneral.aspx");
                    if(objUsuario.Nivel == "Admin")
                    {
                        FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
                    }else if(objUsuario.Nivel == "Escaner") {
                        idUsuario = objUsuario.ID.ToString();
                        FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
                        Response.Redirect("AgregarCajaScan.aspx");
                    }
                   

                }
                else
                {
                    Response.Write("<script>alert('Usuario Incorrecto')</script>");
                }
            }
        

        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
         
        }

    }
}
