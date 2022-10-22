using SILPA.AccesoDatos.Salvoconducto;
using SILPA.AccesoDatos.Aprovechamiento;
using SILPA.LogicaNegocio.Aprovechamiento;
using SILPA.LogicaNegocio.Salvoconducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SILPA.LogicaNegocio.Generico;
using System.Data;
using SILPA.AccesoDatos.Generico;
using System.Globalization;


public partial class Salvoconducto_LogValidacionSUNL : System.Web.UI.Page
{

    private string SalvoconductoID { get { return (string)ViewState["SalvoconductoID"]; } set { ViewState["SalvoconductoID"] = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        #region recibir parámetros de url
        if (Request.QueryString["enc"] != null && Request.QueryString["enc"].ToString() != "")
        {
            #region obtengo el valor de cada uno de los parámetros [modo: encriptado]
            string encryptedQueryString = Request.QueryString["enc"].Replace(" ", "+");
            string decryptedQueryString = Utilidades.Decrypt(encryptedQueryString);
            string[] QueryStringParameters = decryptedQueryString.Split(new char[] { '&' });

            SalvoconductoID = QueryStringParameters[0].Substring(QueryStringParameters[0].IndexOf("=") + 1);
            #endregion

            #region carga inro_odtial del formulario [modo: encriptado]
            if (!Page.IsPostBack)
            {
                #region deshabilitar boton atras navegador
                Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                Response.Cache.SetAllowResponseInBrowserHistory(false);
                Response.Cache.SetNoStore();
                #endregion

                //Usuario para pruebas
                //Session["Usuario"] = 32511;
                //CargarLogSunl(Convert.ToInt32(SalvoconductoID));
                //return;
                if (new Utilidades().ValidacionToken() == false)
                {
                    Response.Redirect(@"..\Utilitario\MensajeValidacion.aspx");
                }
                else
                {
                    #region recepción de parámetros [modo: encriptado]
                    if (!String.IsNullOrEmpty(SalvoconductoID))
                    {
                        //ejecutar métodos normales de tu formulario
                        CargarLogSunl(Convert.ToInt32(SalvoconductoID));
                    }
                    else
                    {
                        #region redirijo al usuario a la página de Login
                        string _strPagina = "window.top.location.href='../Utilitario/MensajeValidacion.aspx'";
                        Utilidades.AlertWindow(this.Page, "", _strPagina, (int)Utilidades._modo_apertura_formulario.ejecutarScript);
                        #endregion
                    }
                    #endregion

                }
                #endregion
            }
            else if (Request.QueryString["SalvoConductoID"] != null)
            {
                #region carga inro_odtial del formulario [modo: normal]
                if (!Page.IsPostBack)
                {
                    #region deshabilitar boton atras navegador
                    Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                    Response.Cache.SetAllowResponseInBrowserHistory(false);
                    Response.Cache.SetNoStore();
                    #endregion
                    //Session["Usuario"] = 32404;
                    if (new Utilidades().ValidacionToken() == false)
                    {
                        Response.Redirect(@"..\Utilitario\MensajeValidacion.aspx");
                    }
                    else
                    {
                        #region recepción de parámetros [modo: normal]
                        SalvoconductoID = this.Request.QueryString["SalvoConductoID"];
                        #endregion
                        // ejecutar métodos normales de tu formulario
                        SalvoconductoID = Request.QueryString["SalvoConductoID"];
                        CargarLogSunl(Convert.ToInt32(SalvoconductoID));
                    }
                }
                #endregion
                else
                {
                    #region redirijo al usuario a la página de Login
                    string _strPagina = "window.top.location.href='../Utilitario/MensajeValidacion.aspx'";
                    Utilidades.AlertWindow(this.Page, "", _strPagina, (int)Utilidades._modo_apertura_formulario.ejecutarScript);
                    #endregion
                }
            }
            #endregion
        }
    }
    public void CargarLogSunl(int SalvoconductoID)
    {
        DataSet ds = new DataSet();
        SalvoconductoNew clsSalvoconductoNew = new SalvoconductoNew();
        ds = clsSalvoconductoNew.ConsultarLogErroresSUNL(SalvoconductoID);
        if (ds != null && ds.Tables.Count > 0)
        {
            this.grvValidacionGralSunl.DataSource = ds.Tables[1];
            this.grvValidacionGralSunl.DataBind();
            this.gdvInconsistenciasEspecies.DataSource = ds.Tables[0];
            this.gdvInconsistenciasEspecies.DataBind();
        }
        else
        {
            Response.Redirect(@"..\Utilitario\MensajeValidacion.aspx");
        }

    }
}