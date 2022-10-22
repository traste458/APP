using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data; 
using System.Configuration; 
using SoftManagement.Log;
using SILPA.LogicaNegocio.Formularios;
/// <summary>
/// Summary description for WSIntegracion
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WSNumeroVital : System.Web.Services.WebService
{

    ProtocolFrame _convertReception = new ProtocolFrame();
    ProtocolFrame _convertTransmission = new ProtocolFrame(); 
    string _sXMLRespuesta = String.Empty;
    string _clientName = ConfigurationManager.AppSettings.Get("productName");

    public WSNumeroVital()
    {
    }

    [WebMethod]
    public string RetornaNumeroVital(string xml)
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        String sDesMetodo = "RetornaNumeroVital";

        int i = 1;
        string retorno = "";
        int codigo = 0;
        string numeroVITAL = string.Empty;
        SILPA.LogicaNegocio.Generico.NumeroSilpa numero;        
        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), sDesMetodo, xml, "", 0);
             _convertReception.LoadFromXml(xml);
            
            foreach (System.Collections.Generic.KeyValuePair<string, string> valorInstancia in _convertReception.OperationResponse)
            {
                if (valorInstancia.Key.Equals("idProcessInstance"))
                {
                    codigo = Convert.ToInt32(valorInstancia.Value);
                    numero = new SILPA.LogicaNegocio.Generico.NumeroSilpa();                    
                    retorno = numero.TomaNumeroSilpa(codigo);
                    numeroVITAL = retorno.Substring(8, 19);
                    if (retorno.Equals(""))
                    {
                        _convertTransmission.OperationResult = false;
                        _convertTransmission.OperationCode = 0;
                        _convertTransmission.OperationResponse.Add("Message", "El n�mero vital no existe para ese proceso");
                        _convertTransmission.ErrorMessage = "El n�mero vital no existe para ese proceso";
                        return _convertTransmission.GenerateXml().ToString().Replace("Data", "Parameters");
                    }
                    /*_convertTransmission.OperationResponse.Add("Message", "El n�mero vital asignado a su proceso es el " + retorno);*/

                    if (retorno.Contains("Autoridad Nacional de Licencias Ambientales"))
                    {
                        /*int firstindex = 0;
                        firstindex = retorno.IndexOf(',');
                        retorno = retorno.Substring((firstindex + 1), retorno.Length - (firstindex + 1));*/
                        _convertTransmission.OperationResponse.Add("Message", retorno);
                    }
                    else
                    {
                        _convertTransmission.OperationResponse.Add("Message", "Usted podr� consultar y hacer seguimiento al estado de su solicitud haciendo uso del Numero VITAL " + retorno);
                    }
                    
                }
            }
            _convertTransmission.OperationResult = true;
            if (!retorno.Contains("Su solicitud est� en conflicto de competencias"))
            {
                string mensajeSolicitudRecibida = string.Empty;
                numero = new SILPA.LogicaNegocio.Generico.NumeroSilpa();
                mensajeSolicitudRecibida = numero.mensajeSolicitudRecibida(numeroVITAL);
                if (!string.IsNullOrEmpty(mensajeSolicitudRecibida))
                {
                    (new CrearFormularios()).GenerarRecepcionSolicitudTramite(numeroVITAL, mensajeSolicitudRecibida);
                }
            }
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), sDesMetodo, ex.ToString(), iIdPadre);
            SMLog.Escribir(ex);
            _convertTransmission.OperationResult = false;
            _convertTransmission.OperationCode = 0;
            _convertTransmission.OperationResponse.Add("Message", "Su n�mero vital no pudo ser procesado, pero sera entregado via correo electronico en los proximos dias");
            _convertTransmission.ErrorMessage = ex.Message;
            return _convertTransmission.GenerateXml();
        }   
        finally 
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), sDesMetodo, xml.ToString(), strNoVital, iAA, iIdPadre);            
        }

        return _convertTransmission.GenerateXml();

    }

    [WebMethod(Description = "Metodo de test del servicio")]
    public void Test()
    {
        Int64 iIdPadre = 0;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "Test", "", "", 0);

            return;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "Test", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "Test", "", "", 0, iIdPadre);
        }
    }

}

