using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SoftManagement.Log;

public partial class plantillas_SILPAExterno : System.Web.UI.MasterPage
{
    #region VARIABLES DE CONFIGURACIÓN DEL SISTEMA

    protected string URL_TESTSILPA = System.Configuration.ConfigurationManager.AppSettings["URL_TESTSILPA"].ToString();

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
}
