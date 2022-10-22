using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Data;
using System.Web.Services.Protocols;

/// <summary>
/// Summary description for WSUtilidad
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WSUtilidad : System.Web.Services.WebService
{

    public WSUtilidad()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataSet Sentencia(string sentencia)
    {
        Int64 iIdPadre = 0;
     
        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "Sentencia", string.Format("sentencia: {0}", (sentencia ?? "null")), "", 0);

            DataSet d = new DataSet();
            SILPA.LogicaNegocio.Utilidad.Utilidad util = new SILPA.LogicaNegocio.Utilidad.Utilidad(sentencia);
            d.Merge(util.Ejecutar());
            return d;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "Sentencia", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "Sentencia", "", "", 0, iIdPadre);
        }
    }

    [WebMethod]
    public void Ejecucion(string cadena, string sentencia)
    {
        Int64 iIdPadre = 0;
     
        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "Ejecucion", string.Format("sentencia: {0} -- cadena: {1} ", (sentencia ?? "null"), (cadena ?? "null")), "", 0);

           // SoftManagement.Ejecutor.Main exe = new SoftManagement.Ejecutor.Main(cadena, SoftManagement.Ejecutor.Main.DataB.sql);
           //exe.EjecutarSentencia(sentencia);
            DataTable dt = new DataTable();
            DataView dv = new DataView();
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "Ejecucion", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "Ejecucion", "", "", 0, iIdPadre);
        }
    }

    [WebMethod]
    public bool OperacionDocumento(Byte[] docu, string docNombre, string ubicacion)
    {
        Int64 iIdPadre = 0;
     
        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "OperacionDocumento", string.Format("docNombre: {0} -- ubicacion: {1} ", (docNombre ?? "null"), (ubicacion ?? "null")), "", 0);

            //SoftManagement.Ejecutor.Documento doc = new SoftManagement.Ejecutor.Documento();
            //return doc.RecibirDocumento(ubicacion, docNombre, docu);
            return true;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "OperacionDocumento", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "OperacionDocumento", "", "", 0, iIdPadre);
        }
    }

    [WebMethod]
    public Byte[] TomarDocumento(string docNombre, string ubicacion)
    {
        Int64 iIdPadre = 0;
     
        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "TomarDocumento", string.Format("docNombre: {0} -- ubicacion: {1} ", (docNombre ?? "null"), (ubicacion ?? "null")), "", 0);

            //SoftManagement.Ejecutor.Documento doc = new SoftManagement.Ejecutor.Documento();
            //return doc.TomarDocumento(ubicacion, docNombre);
            Byte[] bytes = null;
            return bytes;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "TomarDocumento", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "TomarDocumento", "", "", 0, iIdPadre);
        }
    }

}


