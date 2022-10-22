using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SILPA.LogicaNegocio.WSIntegracionVITAL_LOFL;
using System.Text;
using System.Configuration;
using SILPA.Comun;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using SoftManagement.Log;

public partial class Salvoconducto_RedireccionLOFL : System.Web.UI.Page
{

    public class AnlaModel
    {
        public string TokenIngreso { get; set; }

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        //Session["Usuario"] = 62487;
        //vital_redirigir_init();
        //return;
        if (new Utilidades().ValidacionToken() == false)
        {
            Response.Redirect(@"..\Utilitario\MensajeValidacion.aspx");
        }
        else
        {
            //Session["Usuario"] = 62490;
            vital_redirigir_init();
        }
    }

    private void vital_redirigir_init()
    {
        Configuracion ObjConfiguracion = new Configuracion();
        string xmlLOFL = string.Empty;
        string Resultado = string.Empty;
        string UrlLofl = ObjConfiguracion.integradorRedirect;
        IntegracionVital_LOFL ObjIntegracionVital_LOFL = new IntegracionVital_LOFL();
        xmlLOFL = ObjIntegracionVital_LOFL.GenerarXML(long.Parse(Session["Usuario"].ToString()));
        SMLog.Escribir(Severidad.Informativo, "LOFL XML sin encriptar: " + xmlLOFL);
        AnlaModel ObjXmlVitalLoflRequest = new AnlaModel();
        ObjXmlVitalLoflRequest.TokenIngreso = ObjIntegracionVital_LOFL.Encrypt3DES(xmlLOFL);
        LogueoLOFL(UrlLofl, ObjXmlVitalLoflRequest);
    }


    private void LogueoLOFL(string url, AnlaModel objectRequest)
    {
        IntegracionVital_LOFL ObjIntegracionVital_LOFL = new IntegracionVital_LOFL();
        string result = string.Empty;
        JavaScriptSerializer js = new JavaScriptSerializer();
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);
        var customURL = url + json;
        SMLog.Escribir(Severidad.Informativo, "LOFL XML peticion: " + customURL);
        SMLog.Escribir(Severidad.Informativo, "LOFL XML JSON: " + json);
        Response.Redirect(customURL, endResponse: true);

    }
}
