using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using SILPA.Servicios.BPMProcess;
using SILPA.Servicios.BPMProcess.Entidades;


/// <summary>
/// Summary description for WSProcess
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WSProcess : System.Web.Services.WebService
{

    public WSProcess()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod(Description = "Crear proceso.")]    
    public string CrearProceso(string ClientId, Int64 FormId, Int64 UserID, string ValoresXML)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";
     
        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "CrearProceso", string.Format("ClientId: {0} -- FormId: {1} -- UserID: {2} -- ValoresXML: {3} ", (ClientId ?? "null"), FormId.ToString(), UserID.ToString(), (ValoresXML ?? "null")), "", 0);
            BPMProcess objProcess = new BPMProcess();
            strRespuesta = objProcess.CrearProcesoBPM(ClientId, FormId, UserID, ValoresXML);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "CrearProceso", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "CrearProceso", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }

    [WebMethod(Description = "Crear proceso SILA.")]
    public string CrearProcesoAutoridad(Int64 TramiteId, Int64 PerId, Int64 AutId,string ValoresXML)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "CrearProcesoAutoridad", string.Format("TramiteId: {0} -- PerId: {1} -- ValoresXML: {2} ", TramiteId.ToString(), PerId.ToString(), (ValoresXML ?? "null")), "", Convert.ToInt32(AutId));
	        BPMProcess objProcess = new BPMProcess();
	        strRespuesta = objProcess.CrearProcesoAutoridad(TramiteId, PerId, AutId, ValoresXML);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "CrearProcesoAutoridad", ex.ToString(), iIdPadre);
            string strException = "Validar los pasos efectuados al Crear proceso en SILA.";
            throw new Exception(strException, ex);
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "CrearProcesoAutoridad", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Registrar un formulario en VITAL.")]
    public string RegistrarFormularioProceso(string strUsuarioAutorizado, long lngFormularioID, long lngUsuarioFormularioID, string xmlFormulario)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "RegistrarFormularioProceso", string.Format("strUsuarioAutorizado: {0} -- lngFormularioID: {1} -- lngUsuarioFormularioID: {2} -- xmlFormulario: {3} ", (strUsuarioAutorizado ?? "null"), lngFormularioID.ToString(), lngUsuarioFormularioID.ToString(), (xmlFormulario ?? "null")), "", 0);

            BPMProcess objProcess = new BPMProcess();
            strRespuesta = objProcess.RegistrarFormularioProceso(strUsuarioAutorizado, lngFormularioID, lngUsuarioFormularioID, xmlFormulario);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "RegistrarFormularioProceso", ex.ToString(), iIdPadre);
            throw new Exception("Error durante el registro del formulario en el sistema", ex);
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "RegistrarFormularioProceso", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Finaliza el proceso actual relacionada al numero VITAL indicado.")]
    public string FinalizarProcesoNumeroVITAL(string strNumeroVITAL)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "FinalizarProcesoNumeroVITAL", string.Format("strNumeroVITAL: {0}", (strNumeroVITAL ?? "null")), "", 0);

            BPMProcess objProcess = new BPMProcess();
            strRespuesta = objProcess.FinalizarProcesoNumeroVITAL(strNumeroVITAL);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "FinalizarProcesoNumeroVITAL", ex.ToString(), iIdPadre);
            throw new Exception("Error durante la finalizacion del proceso", ex);
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "FinalizarProcesoNumeroVITAL", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Obtiene la lista de los formularios disponibles para ser utilizados")]
    public string ObtenerFormularios()
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "ObtenerFormularios", "", "", 0);

            BPMProcess objProcess = new BPMProcess();
            strRespuesta = objProcess.ObtenerFormularios();
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "ObtenerFormularios", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "ObtenerFormularios", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    } 

    [WebMethod(Description = "Obtiene la lista De campos de un formulario Especifico")]
    public string ObtenerCampos(Int64 FormId)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "ObtenerCampos", string.Format("FormId: {0}", FormId.ToString()), "", 0);

            BPMProcess objProcess = new BPMProcess();
            strRespuesta = objProcess.ObtenerCampos(FormId);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "ObtenerCampos", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "ObtenerCampos", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Obtiene la lista de los registros pendientes por radicar en SIGPRO. Se envían como parametros: identificador de la autoridad, fecha inicial (yyyy-MM-dd HH:mm:ss)  y fecha final (yyyy-MM-dd HH:mm:ss)")]
    public RespuestaWsConsultaRegistrosRadicarSigproEntity ConsultarRegistrosRadicarSigpro(int idAutoridadAmbiental, string fechaInicial, string fechaFinal)
    {
        var respuesta = new RespuestaWsConsultaRegistrosRadicarSigproEntity();
        Int64 iIdPadre = 0;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "ConsultarRegistrosRadicarSigpro", string.Format("fechaInicial: {0} -- fechaFinal: {1} ", (fechaInicial ?? "null"), (fechaFinal ?? "null")), "", idAutoridadAmbiental);

            BPMProcess objProcess = new BPMProcess();
            var listaRespuesta = objProcess.ObtenerRegistrosPendientesRadicacionSigpro(idAutoridadAmbiental, fechaInicial, fechaFinal);            
            respuesta.ListaRegistrosRadicarSigpro = listaRespuesta;
            respuesta.CantidadRegistro = listaRespuesta.Count;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "ConsultarRegistrosRadicarSigpro", ex.ToString(), iIdPadre);
            respuesta.Error = true;
            respuesta.TextoError = ex.Message;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "ConsultarRegistrosRadicarSigpro", (respuesta != null ? respuesta.GetXml() : "null"), "", 0, iIdPadre);
        }

        return respuesta;        
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

