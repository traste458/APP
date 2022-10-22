using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using SILPA.LogicaNegocio.Generico;
using SILPA.AccesoDatos.Generico;
using SILPA.AccesoDatos;
using SILPA.Comun;
using SILPA.LogicaNegocio;
using SILPA.Servicios.RUIA;
using SoftManagement.Log;
using SoftManagement.LogWS;


/// <summary>
/// Summary description for WSPQ07
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WSPQ07 : System.Web.Services.WebService
{

    public WSPQ07()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(Description = "Retorna el listado de tipos de tramite")]
    public List<SILPA.AccesoDatos.Parametrizacion.TipoTramite> Tramites()
    {
        Int64 iIdPadre = 0;

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), "Tramites", "", "", 0);
            SILPA.LogicaNegocio.Parametrizacion.Parametrizacion tramite = new SILPA.LogicaNegocio.Parametrizacion.Parametrizacion();
            return tramite.Tramites();
        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), "Tramites", ex.ToString(), iIdPadre);
            SMLog.Escribir(ex);
            throw;
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), "Tramites", "", "", 0, iIdPadre);
        }
    }

      [WebMethod(Description = "Retorna el listado de tipos de tramite segun el parametro enviado")]
    public SILPA.AccesoDatos.Parametrizacion.TipoTramite ListarTramites(int idTramite)
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), "ListarTramites", idTramite.ToString(), "", 0);
            SILPA.LogicaNegocio.Parametrizacion.Parametrizacion tramite = new SILPA.LogicaNegocio.Parametrizacion.Parametrizacion();
            return tramite.Tramites(idTramite);
        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), "ListarTramites", ex.ToString(), iIdPadre);
            SMLog.Escribir(ex);
            throw;
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), "ListarTramites", idTramite.ToString(), strNoVital, iAA, iIdPadre);
        }
    }

    [WebMethod(Description = "Retorna el listado de tipos de documento")]
    public string Documentos()
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), "Documentos", "", "", 0);
            SILPA.LogicaNegocio.Parametrizacion.Parametrizacion documento = new SILPA.LogicaNegocio.Parametrizacion.Parametrizacion();
            return documento.Documentos();
        }
        catch (Exception ex)
        {
            //SMLog.Escribir(ex);
            SMLogWS.EscribirExcepcion(this.ToString(), "Documentos", ex.ToString(), iIdPadre);
            throw;
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), "Documentos", "", strNoVital, iAA, iIdPadre);
        }
    }

    [WebMethod(Description = "Retorna las listas de objetos básicos utilizados en RUIA")]
    public string listasRUIA()
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), "listasRUIA", "", "", 0);
            return new RUIAFachada().consultaTotal();
        }
        catch (Exception ex)
        {
            //SMLog.Escribir(ex);
            SMLogWS.EscribirExcepcion(this.ToString(), "listasRUIA", ex.ToString(), iIdPadre);
            throw;
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), "listasRUIA", "", strNoVital, iAA, iIdPadre);
        }
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

    //21-jun-2010 - aegb
    [WebMethod(Description = "Retorna las listas de objetos básicos utilizados en homologacion de datos")]
    public string ListasDatosHomologacion(int idTabla)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "ListasDatosHomologacion", "idTabla: " + idTabla.ToString(), "", 0);

            SILPA.LogicaNegocio.Generico.Listas datos = new SILPA.LogicaNegocio.Generico.Listas();
            strRespuesta =  datos.ObtenerDatosHomologacion(idTabla);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "ListasDatosHomologacion", ex.ToString(), iIdPadre);
            SMLog.Escribir(ex);
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "ListasDatosHomologacion", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }

        //22092020 - FRS
    [WebMethod(Description = "Retorna el ApplicationUser a partir del Persona Id")]
    public string ListarApplicationUserComplementoHomologacion(int idPersona)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "ListarApplicationUserComplementoHomologacion", "idPersona: " + idPersona.ToString(), "", 0);

            SILPA.LogicaNegocio.Generico.Listas datos = new SILPA.LogicaNegocio.Generico.Listas();
            strRespuesta = datos.ObtenerApplicationUserComplementoHomologacion(idPersona);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "ListarApplicationUserComplementoHomologacion", ex.ToString(), iIdPadre);
            SMLog.Escribir(ex);
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "ListarApplicationUserComplementoHomologacion", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }



    //22092020 - FRS
    [WebMethod(Description = "Retorna si la persona se encuentra activa a partir del Persona Id")]
    public int ObtenerSiPersonaActivaHomologacion(int idPersona) 
    {
        Int64 iIdPadre = 0;
        int intRespuesta = -1;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "ObtenerSiPersonaActivaHomologacion", "idPersona: " + idPersona.ToString(), "", 0);

            SILPA.LogicaNegocio.Generico.Listas datos = new SILPA.LogicaNegocio.Generico.Listas();
            intRespuesta = datos.ObtenerSiPersonaActivaHomologacion(idPersona);
            return intRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "ObtenerSiPersonaActivaHomologacion", ex.ToString(), iIdPadre);
            SMLog.Escribir(ex);
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "ObtenerSiPersonaActivaHomologacion", intRespuesta.ToString(), "", 0, iIdPadre);
        }
    }



    //22042020 JNS
    [WebMethod(Description = "Retorna el listado de clasificaciones de informacion adicional")]
    public string ListaClasificacionesInformacionAdicional(string p_strDescripcion, bool? p_blnActivo)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "ListaClasificacionesInformacionAdicional", string.Format("p_strDescripcion: {0} -- p_blnActivo: {1}", (p_strDescripcion ?? "null"), (p_blnActivo != null ? p_blnActivo.ToString() : "null")), "", 0);

            SILPA.LogicaNegocio.Generico.ClasificacionInformacionGeneral objClasificacionInformacionGeneral = new SILPA.LogicaNegocio.Generico.ClasificacionInformacionGeneral();
            strRespuesta = objClasificacionInformacionGeneral.ObtenerClasificaciones(p_strDescripcion, p_blnActivo);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "ListaClasificacionesInformacionAdicional", ex.ToString(), iIdPadre);
            SMLog.Escribir(ex);
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "ListaClasificacionesInformacionAdicional", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


    //22042020 JNS
    [WebMethod(Description = "Retorna la de la clasificacion")]
    public string ObtenerClasificacionInformacionAdicional(int clasificacionID)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "ObtenerClasificacionInformacionAdicional", string.Format("clasificacionID: {0}", clasificacionID.ToString()), "", 0);

            SILPA.LogicaNegocio.Generico.ClasificacionInformacionGeneral objClasificacionInformacionGeneral = new SILPA.LogicaNegocio.Generico.ClasificacionInformacionGeneral();
            strRespuesta = objClasificacionInformacionGeneral.ObtenerClasificacionInformacionAdicional(clasificacionID);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "ObtenerClasificacionInformacionAdicional", ex.ToString(), iIdPadre);
            SMLog.Escribir(ex);
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "ObtenerClasificacionInformacionAdicional", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


}

