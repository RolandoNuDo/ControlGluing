using CapaEntidad;
using CapaLogica1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace capadepresentacion
{
    public partial class Tabla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Caja> ListarCajas()
        {
            List<Caja> Lista = null;
            try
            {
                Lista = CajaLN.getInstance().listaCajas();
            }
            catch (Exception ex)
            {
                Lista = null;
            }
            return Lista;
        }
    }
}