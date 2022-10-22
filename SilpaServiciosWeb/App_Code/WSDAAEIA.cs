using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
using System.Data;
using SILPA.LogicaNegocio;
using SILPA.LogicaNegocio.Generico;
using SILPA.AccesoDatos.Correspondencia;
using SILPA.AccesoDatos.Generico;
using SILPA.AccesoDatos.DAA;
using SoftManagement.Log;
using SoftManagement.LogWS;
using SILPA.Servicios.DAASolicitud;
using SILPA.Servicios.DAASolicitud.Entidades;
using SILPA.Servicios.DAASolicitud.Enum;


/// <summary>
/// Summary description for WSDAAEIA
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WSDAAEIA : System.Web.Services.WebService
{

    public WSDAAEIA()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    /// <summary>
    /// HAVA:
    /// M�todo para realizar el reenv�o de la solicitud a la Autoridad Ambiental Competente
    /// </summary>
    /// <param name="datosEnvio">String en formato XML con los datos del reenv�o</param>
    /// <returns>bool</returns>
    [WebMethod]
    public bool ReenviarSolicitudDAA(string datosEnvio)
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        String sDesMetodo = "ReenviarSolicitudDAA";

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), sDesMetodo, datosEnvio, "", 0);
            //CorrespondenciaSilpaDalc _objCorres = new CorrespondenciaSilpaDalc();
            SILPA.LogicaNegocio.DAA.DAA objDaa = new SILPA.LogicaNegocio.DAA.DAA();
            objDaa.ReenviarSolicitud(datosEnvio);
            //bool result = _objCorres.ReasignarAutoridadRadicacion(intIdRadicacion, intAutIdAsignada, intAutIdEntrega);
            return true;
        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), sDesMetodo, ex.ToString(), iIdPadre);
            SMLog.Escribir(ex);
            string strException = "Validar los pasos efectuados al realizar el reenv�o de la solicitud a la Autoridad Ambiental Competente.";
            throw new Exception(strException, ex);
        }

        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), sDesMetodo, datosEnvio, strNoVital, iAA, iIdPadre);
        }

    }


    /// <summary>
    /// JNS 20210409 - Retorna el listado de autoridades ambientales a las cuales se puede reasignar la solicitud 
    /// </summary>
    /// <returns>string con XML que contiene la informaci�n de las autoridades.</returns>
    [WebMethod(Description = "[Retorna el listado de autoridades ambientales a las cuales se puede reasignar una solicitud]", MessageName = "ObtenerAutoridadesReasignarDAASolicitud")]
    public string ObtenerAutoridadesReasignarDAASolicitud()
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        String sDesMetodo = "ObtenerAutoridadesReasignarDAASolicitud";
        DAASolicitudFacade objDAASolicitudFacade = null;
        string strAutoridades = "";

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), sDesMetodo, "", "", 0);
            objDAASolicitudFacade = new DAASolicitudFacade();
            strAutoridades = objDAASolicitudFacade.ObtenerAutoridadesAmbientalesReasignar();
        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), sDesMetodo, ex.ToString(), iIdPadre);
            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "Error obteniendo informaci�n de las autoridades: " + ex.Message + " - " + (ex.StackTrace != null ? ex.StackTrace.ToString() : ""));
            strAutoridades = new DAASolicitudAutoridades(CodigoRespuestaEnum.ERROR, "Se presento un problema en la consulta de autoridades").GetXml();
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), sDesMetodo, strAutoridades, strNoVital, iAA, iIdPadre);
        }

        return strAutoridades;
    }


    /// <summary>
    /// JNS 20210409 - Retorna el listado de esatado que puede tomar una solicitud de reasignacion
    /// </summary>
    /// <returns>string con XML que contiene la informaci�n de los estados.</returns>
    [WebMethod(Description = "[Retorna el listado de esatado que puede tomar una solicitud de reasignacion]", MessageName = "ObtenerEstadosSolicitudesReasignacionDAASolicitud")]
    public string ObtenerEstadosSolicitudesReasignacionDAASolicitud()
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        String sDesMetodo = "ObtenerEstadosSolicitudesReasignacionDAASolicitud";
        DAASolicitudFacade objDAASolicitudFacade = null;
        string strEstados = "";

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), sDesMetodo, "", "", 0);
            objDAASolicitudFacade = new DAASolicitudFacade();
            strEstados = objDAASolicitudFacade.ObtenerEstadosSolicitudesReasignacion();
        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), sDesMetodo, ex.ToString(), iIdPadre);
            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "Error obteniendo informaci�n de los estados: " + ex.Message + " - " + (ex.StackTrace != null ? ex.StackTrace.ToString() : ""));
            strEstados = new DAASolicitudEstadosReasignacion(CodigoRespuestaEnum.ERROR, "Se presento un problema en la consulta de estados").GetXml();
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), sDesMetodo, strEstados, strNoVital, iAA, iIdPadre);
        }

        return strEstados;
    }


    /// <summary>
    /// JNS 20210406 - Obtiene la informaci�n de una solicitud de tr�mite por el n�mero VITAL 
    /// </summary>
    /// <param name="intAutoridadID">int con el identificador de la autoridad ambiental a la cual se encuentra asignada la solicitud de tr�mite.</param>
    /// <param name="strNumeroVITAL">string con el n�mero VITAL</param>
    /// <returns>string con XML que contiene la informaci�n de la solicitud.</returns>
    [WebMethod(Description = "[Obtiene la informaci�n de una solicitud de tr�mite por el n�mero VITAL. Es indispensable que el id de la autoridad corresponda con la autoridad que tiene el tr�mite asignado]", MessageName = "ObtenerDAASolicitudNumeroVITAL")]
    public string ObtenerDAASolicitudNumeroVITAL(int intAutoridadID, string strNumeroVITAL)
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        String sDesMetodo = "ObtenerDAASolicitudNumeroVITAL";
        DAASolicitudFacade objDAASolicitudFacade = null;
        string strSolicitud = "";

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), sDesMetodo, "intAutoridadID: " + intAutoridadID.ToString() + " - strNumeroVITAL: " + (strNumeroVITAL ?? "null"), "", 0);
            objDAASolicitudFacade = new DAASolicitudFacade();
            strSolicitud = objDAASolicitudFacade.ObtenerDAASolicitudNumeroVITAL(intAutoridadID, strNumeroVITAL);
        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), sDesMetodo, ex.ToString(), iIdPadre);
            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "Error obteniendo informaci�n de la solicitud: " + ex.Message + " - " + (ex.StackTrace != null ? ex.StackTrace.ToString() : ""));
            strSolicitud = new DAASolicitudTramite(CodigoRespuestaEnum.ERROR, "Se presento un problema en el proceso de consulta de la solicitud de tr�mite").GetXml();
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), sDesMetodo, strSolicitud, strNoVital, iAA, iIdPadre);
        }

        return strSolicitud;
    }


    /// <summary>
    /// JNS 20210406 - Registrar una petici�n de reasignaci�n de solicitud de tr�mite
    /// </summary>
    /// <param name="intAutoridadAmbientalID">int con el identificador de la autoridad ambiental que esta solicitando la reasignaci�n</param>
    /// <param name="intAutoridadAmbientalReasignarID">int con el identificador de la autoridad ambiental a quien se solicita reasignar</param>
    /// <param name="strNumeroVITAL">string con el n�mero VITAL al cual se reasignar� la solicitud</param>
    /// <param name="intUsuarioSolicitanteID">int con el identificador del usuario de la autoridad ambiental que realiza la solicitud. Opcional enviar -1</param>
    /// <returns>string con la informaci�n de la solicitud de reasignaci�n registrada</returns>
    [WebMethod(Description = "[Solicitar la reasignaci�n de una solicitud de tr�mite]", MessageName = "SolicitarReasignacionSolicitudDAA")]
    public string SolicitarReasignacionDAASolicitud(int intAutoridadAmbientalID, int intAutoridadAmbientalReasignarID, string strNumeroVITAL, int intUsuarioSolicitanteID)
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        String sDesMetodo = "SolicitarReasignacionSolicitudDAA";
        string strSolicitud = "";

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), sDesMetodo,
                                              "intAutoridadAmbientalID: " + intAutoridadAmbientalID.ToString() + " - " +
                                              "intAutoridadAmbientalReasignarID: " + intAutoridadAmbientalReasignarID.ToString() + " - " +
                                              "strNumeroVITAL: " + (strNumeroVITAL ?? "null") + " - " +
                                              "intUsuarioSolicitanteID: " + intUsuarioSolicitanteID.ToString() + " - ", "", 0);
            DAASolicitudFacade objDAASolicitudFacade = new DAASolicitudFacade();
            strSolicitud = objDAASolicitudFacade.SolicitarReasignacionDAASolicitud(intAutoridadAmbientalID, intAutoridadAmbientalReasignarID, strNumeroVITAL, intUsuarioSolicitanteID);
        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), sDesMetodo, ex.ToString(), iIdPadre);
            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "Error durante de la solicitud de reasignaci�n: " + ex.Message + " - " + (ex.StackTrace != null ? ex.StackTrace.ToString() : ""));
            strSolicitud = new DAASolicitudReasignacion(CodigoRespuestaEnum.ERROR, "Se presento un problema durante el registro de la solicitud de reasignaci�n").GetXml();
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), sDesMetodo, strSolicitud, strNoVital, iAA, iIdPadre);
        }

        return strSolicitud;
    }

    /// <summary>
    /// JNS 20210406 - Aprueba una solicitud de reasignaci�n
    /// </summary>
    /// <param name="intSolicitudReasignacionID">int con el identificador de la solicitud de reasignaci�n</param>
    /// <param name="strCodigoSolicitudReasignacion">string con el codigo de la solicitud de reasignaci�n</param>
    /// <param name="intUsuarioAprobadorID">int con el identificador del usuario en la autoridad que realiza la aprobaci�n. Opcional enviar -1</param>
    /// <returns>string con el resultado del proceso</returns>
    [WebMethod(Description = "[Aprobar una solicitud de reasignaci�n]", MessageName = "AprobarSolicitudReasignacionDAASolicitud")]
    public string AprobarSolicitudReasignacionDAASolicitud(int intSolicitudReasignacionID, string strCodigoSolicitudReasignacion, int intUsuarioAprobadorID)
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        String sDesMetodo = "AprobarSolicitudReasignacionDAASolicitud";
        string strRespuesta = "";

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), sDesMetodo, 
                                              "intSolicitudReasignacionID: " + intSolicitudReasignacionID.ToString() +
                                              " - strCodigoSolicitudReasignacion: " + (strCodigoSolicitudReasignacion ?? "null") +
                                              " - intUsuarioAprobadorID: " + intUsuarioAprobadorID.ToString(), 
                                              "", 0);
            DAASolicitudFacade objDAASolicitudFacade = new DAASolicitudFacade();
            strRespuesta = objDAASolicitudFacade.AprobarSolicitudReasignacion(intSolicitudReasignacionID, strCodigoSolicitudReasignacion, intUsuarioAprobadorID);
        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), sDesMetodo, ex.ToString(), iIdPadre);
            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "Error durante la aprobaci�n de la solicitud de reasignaci�n: " + ex.Message + " - " + (ex.StackTrace != null ? ex.StackTrace.ToString() : ""));
            strRespuesta = new DAASolicitudRespuesta(CodigoRespuestaEnum.ERROR, "Se presento un problema durante la aprobaci�n de la solicitud de reasignaci�n").GetXml();
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), sDesMetodo, strRespuesta, strNoVital, iAA, iIdPadre);
        }

        return strRespuesta;
    }

    /// <summary>
    /// JNS 20210406 - Rechaza una solicitud de reasignaci�n
    /// </summary>
    /// <param name="intSolicitudReasignacionID">int con el identificador de la solicitud de reasignaci�n</param>
    /// <param name="strCodigoSolicitudReasignacion">string con el codigo de la solicitud de reasignaci�n</param>
    /// <param name="intUsuarioAprobadorID">int con el identificador del usuario en la autoridad que realiza el rechazo. Opcional enviar -1</param>
    /// <returns>string con el resultado del proceso</returns>
    [WebMethod(Description = "[Rechaza una solicitud de reasignaci�n]", MessageName = "RechazarSolicitudReasignacionDAASolicitud")]
    public string RechazarSolicitudReasignacionDAASolicitud(int intSolicitudReasignacionID, string strCodigoSolicitudReasignacion, int intUsuarioAprobadorID)
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        String sDesMetodo = "RechazarSolicitudReasignacionDAASolicitud";
        string strRespuesta = "";

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), sDesMetodo,
                                              "intSolicitudReasignacionID: " + intSolicitudReasignacionID.ToString() +
                                              " - strCodigoSolicitudReasignacion: " + (strCodigoSolicitudReasignacion ?? "null") +
                                              " - intUsuarioAprobadorID: " + intUsuarioAprobadorID.ToString(),
                                              "", 0);
            DAASolicitudFacade objDAASolicitudFacade = new DAASolicitudFacade();
            strRespuesta = objDAASolicitudFacade.RechazarSolicitudReasignacion(intSolicitudReasignacionID, strCodigoSolicitudReasignacion, intUsuarioAprobadorID);
        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), sDesMetodo, ex.ToString(), iIdPadre);
            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "Error durante rechazo de la solicitud de reasignaci�n: " + ex.Message + " - " + (ex.StackTrace != null ? ex.StackTrace.ToString() : ""));
            strRespuesta = new DAASolicitudRespuesta(CodigoRespuestaEnum.ERROR, "Se presento un problema durante el rechazo de la solicitud de reasignaci�n").GetXml();
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), sDesMetodo, strRespuesta, strNoVital, iAA, iIdPadre);
        }

        return strRespuesta;
    }

    /// <summary>
    /// JNS 20210406 - Obtener el listado de solicitudes de reasignacion realizadas por una autoridad.
    /// </summary>
    /// <param name="intAutoridadID">int con el identificador de la autoridad que realizo la solicitud</param>
    /// <param name="strNumeroVITAL">string con el n�mero VITAL</param>
    /// <param name="intAutoridadReasignar">int con el identificador a la cual se reasigno</param>
    /// <param name="intEstadoSolicitudID">int con el identificador del estado de la solicitud. Opcional enviar -1</param>
    /// <param name="objFechaSolicitudInicial">Fecha inicial desde la cual se realiza la busqueda</param>
    /// <param name="objFechaSolicitudFinal">Fecha Final desde la cual se realiza la busqueda</param>
    /// <returns>string con la informaci�n de las solicitudes</returns>
    [WebMethod(Description = "[Obtener el listado de solicitudes de reasignacion realizadas por una autoridad]", MessageName = "ObtenerSolicitudesReasignacionRealizadasAutoridad")]
    public string ObtenerSolicitudesReasignacionRealizadasAutoridad(int intAutoridadID, string strNumeroVITAL, int intAutoridadReasignar, int intEstadoSolicitudID, DateTime objFechaSolicitudInicial, DateTime objFechaSolicitudFinal)
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        String sDesMetodo = "ObtenerSolicitudesReasignacionRealizadasAutoridad";
        string strSolicitudes = "";

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), sDesMetodo,
                                              "intAutoridadID: " + intAutoridadID.ToString() + " - " +
                                              "strNumeroVITAL: " + (strNumeroVITAL ?? "null") + " - " +
                                              "intAutoridadReasignar: " + intAutoridadReasignar.ToString() + " - " +
                                              "intEstadoSolicitudID: " + intEstadoSolicitudID.ToString() + " - " +
                                              "objFechaSolicitudInicial: " + objFechaSolicitudInicial.ToString() + " - " +
                                              "objFechaSolicitudFinal: " + objFechaSolicitudFinal.ToString(),
                                              "", 0);
            DAASolicitudFacade objDAASolicitudFacade = new DAASolicitudFacade();
            strSolicitudes = objDAASolicitudFacade.ObtenerSolicitudesReasignacionRealizadasAutoridad(intAutoridadID, strNumeroVITAL, intAutoridadReasignar, intEstadoSolicitudID, objFechaSolicitudInicial, objFechaSolicitudFinal);
        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), sDesMetodo, ex.ToString(), iIdPadre);
            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "Error durante la consulta de las solicitudes de reasignaci�n: " + ex.Message + " - " + (ex.StackTrace != null ? ex.StackTrace.ToString() : ""));
            strSolicitudes = new DAASolicitudesReasignacion(CodigoRespuestaEnum.ERROR, "Se presento un problema durante la consulta de las solicitudes de reasignaci�n").GetXml();
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), sDesMetodo, strSolicitudes, strNoVital, iAA, iIdPadre);
        }

        return strSolicitudes;
    }

    /// <summary>
    /// JNS 20210406 - Obtener el listado de solicitudes de reasignacion asignadas.
    /// </summary>
    /// <param name="intAutoridadID">int con el identificador de la autoridad que recibe solicitud</param>
    /// <param name="strNumeroVITAL">string con el n�mero VITAL. Opcional enviar vac�o</param>
    /// <param name="intAutoridadSolicitante">int con el identificador de la autoridad que realizo la solicitud. Opcional enviar -1</param>
    /// <param name="intEstadoSolicitudID">int con el estado de la solicitud. Opcional especificar -1</param>
    /// <param name="objFechaSolicitudInicial">Fecha inicial desde la cual se realiza la busqueda</param>
    /// <param name="objFechaSolicitudFinal">Fecha Final desde la cual se realiza la busqueda</param>
    /// <returns>string con la informaci�n de las solicitudes de reasignaci�n</returns>
    [WebMethod(Description = "[Obtener el listado de solicitudes de reasignacion asignadas]", MessageName = "ObtenerSolicitudesReasignacionAsignadasAutoridad")]
    public string ObtenerSolicitudesReasignacionAsignadasAutoridad(int intAutoridadID, string strNumeroVITAL, int intAutoridadSolicitante, int intEstadoSolicitudID, DateTime objFechaSolicitudInicial, DateTime objFechaSolicitudFinal)
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        String sDesMetodo = "ObtenerSolicitudesReasignacionAsignadasAutoridad";
        string strSolicitudes = "";

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), sDesMetodo,
                                              "intAutoridadID: " + intAutoridadID.ToString() + " - " +
                                              "strNumeroVITAL: " + (strNumeroVITAL ?? "null") + " - " +
                                              "intAutoridadSolicitante: " + intAutoridadSolicitante.ToString() + " - " +
                                              "intEstadoSolicitudID: " + intEstadoSolicitudID.ToString() + " - " +                                              
                                              "objFechaSolicitudInicial: " + objFechaSolicitudInicial.ToString() + " - " +
                                              "objFechaSolicitudFinal: " + objFechaSolicitudFinal.ToString(),
                                              "", 0);
            DAASolicitudFacade objDAASolicitudFacade = new DAASolicitudFacade();
            strSolicitudes = objDAASolicitudFacade.ObtenerSolicitudesReasignacionAsignadasAutoridad(intAutoridadID, strNumeroVITAL, intAutoridadSolicitante, intEstadoSolicitudID, objFechaSolicitudInicial, objFechaSolicitudFinal);
        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), sDesMetodo, ex.ToString(), iIdPadre);
            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "Error durante la consulta de las solicitudes de reasignaci�n: " + ex.Message + " - " + (ex.StackTrace != null ? ex.StackTrace.ToString() : ""));
            strSolicitudes = new DAASolicitudesReasignacion(CodigoRespuestaEnum.ERROR, "Se presento un problema durante la consulta de las solicitudes de reasignaci�n").GetXml();
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), sDesMetodo, strSolicitudes, strNoVital, iAA, iIdPadre);
        }

        return strSolicitudes;
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

