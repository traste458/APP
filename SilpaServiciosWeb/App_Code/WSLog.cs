using SoftManagement.LogWS;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descripción breve de WSLog
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WSLog : System.Web.Services.WebService {

    public WSLog () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }

    [WebMethod]
    public void InsertarLog(string strNombreWS, string strNombreMetodo, string strMensaje)
    {
        Int64 iIdPadre = 0;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "InsertarLog", string.Format("strNombreWS: {0} -- strNombreMetodo: {1} -- strMensaje: {2}", (strNombreWS ?? "null"), (strNombreMetodo ?? "null"), (strMensaje ?? "null")), "", 0);
            SMLogWS.EscribirExcepcion(strNombreWS, strNombreMetodo, strMensaje, 0);
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "InsertarLog", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "InsertarLog", "", "", 0, iIdPadre);
        }
    }
    
}
