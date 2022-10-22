﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SILPA.LogicaNegocio.ConsultaPublica;
using SILPA.AccesoDatos.ConsultaPublica;
using SoftManagement.LogWS;

/// <summary>
/// Summary description for WSBodegaBuscador
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WSBodegaBuscador : System.Web.Services.WebService {

    public WSBodegaBuscador () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    /// <summary>
    /// Método que verifica si existe registro en la tabla de datos para la bodega de Consulta Pública
    /// </summary>
    /// <param name="talSolId">int: Id de la tarea.</param>
    /// <param name="solNumSilpa">String: SolNumSilpa</param>
    /// <param name="origen">String: Origen de la información (EIA, PUBLICACION, SILA, SILAMC, VITAL)</param>
    /// <returns>Array de String de dos posiciones, en la primera posición retorna el resultado de la verificacion, 1=>Encontró, 0=> No encontró, -1=> Error, en la segunda posición 
    /// detalla el error si se produjo</returns>
    [WebMethod(Description = "[Método que verifica si existe registro en la tabla de datos para la bodega de Consulta Pública]")]
    public List<String> VerificarSiExisteRegistroEnBodegaDatosConsultaPublica(int talSolId, string solNumSilpa, string origen)
    {
        var respuesta = new List<string>();
        Int64 iIdPadre = 0;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "VerificarSiExisteRegistroEnBodegaDatosConsultaPublica", string.Format("talSolId: {0} -- solNumSilpa: {1} -- origen: {2}", talSolId.ToString(), (solNumSilpa ?? "null"), (origen ?? "null")), "", 0);
            ConsultaPublica objConsultaPublica = new ConsultaPublica();
            var resp = objConsultaPublica.BuscarSiExisteRegistroEnBodega(talSolId, solNumSilpa, origen);
            respuesta.Add(resp);
            respuesta.Add("");
            return respuesta;
        }
        catch (Exception ex)
        {
            //SMLog.Escribir(ex);
            SMLogWS.EscribirExcepcion(this.ToString(), "VerificarSiExisteRegistroEnBodegaConsultaPublica", ex.ToString(), 5);
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "VerificarSiExisteRegistroEnBodegaDatosConsultaPublica", ex.ToString(), iIdPadre);
            respuesta.Add("-1");
            respuesta.Add(ex.Message); 
            return respuesta;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "VerificarSiExisteRegistroEnBodegaDatosConsultaPublica", "", "", 0, iIdPadre);
        }
    }


    /// <summary>
    /// Método que inserta registro en la tabla VS_BOD_DATA_SILA.
    /// </summary>
    /// <param name="talSolId">talSolId</param>
    /// <param name="solNumSilpa">solNumSilpa</param>
    /// <param name="secId">secId</param>
    /// <param name="SecNombre">SecNombre</param>
    /// <param name="secPadreId">secPadreId</param>
    /// <param name="nombreSecPadre">nombreSecPadre</param>
    /// <param name="autNombre">autNombre</param>
    /// <param name="traNombre">traNombre</param>
    /// <param name="expediente">expediente</param>
    /// <param name="nombreProyecto">nombreProyecto</param>
    /// <param name="tarFechaCreacion">tarFechaCreacion</param>
    /// <param name="tarFechaFinalizacion">tarFechaFinalizacion</param>
    /// <param name="municipio">municipio</param>
    /// <param name="departamento">departamento</param>
    /// <param name="nombreCompleto">nombreCompleto</param>
    /// <param name="solIdSolicitante">solIdSolicitante</param>
    /// <param name="origen">Origen de la información (EIA, PUBLICACION, SILA, SILAMC, VITAL)</param>
    /// <param name="numeroDocumento">numeroDocumento</param>
    /// <returns>Array de String de dos posiciones, en la primera posición retorna el resultado de la inserción, 1=>Insertó, 0=> No insertó, -1=> Error, en la segunda posición 
    /// detallará el error si se produjo</returns>
    [WebMethod(Description = "[Método que inserta registro en la tabla VS_BOD_DATA_SILA]")]
    public List<String> InsertarRegistroEnBodegaVsBodDataSila(int tarSolId,string solNumSilpa,string secId,string SecNombre,string secPadreId,string nombreSecPadre,
                                                    string autNombre,string traNombre,string expediente,string nombreProyecto,string tarFechaCreacion,
                                                    string tarFechaFinalizacion,string municipio,string departamento,string nombreCompleto,string solIdSolicitante,
                                                    string origen,string numeroDocumento)
    {
        var respuesta = new List<string>();
        Int64 iIdPadre = 0;

        try
        {
            string strDatosRecibidos = string.Format("tarSolId: {0} -- solNumSilpa: {1} -- secId: {2} -- SecNombre: {3} -- secPadreId: {4} -- nombreSecPadre: {5} -- autNombre: {6} -- traNombre: {7} -- expediente: {8} -- nombreProyecto: {9} -- tarFechaCreacion: {10} -- tarFechaFinalizacion: {11} -- municipio: {12} -- departamento: {13} -- nombreCompleto: {14} -- solIdSolicitante: {15} -- origen: {16} -- numeroDocumento: {17}",               
                                                    tarSolId.ToString(), (solNumSilpa ?? "null"),(secId ?? "null"),(SecNombre ?? "null"),(secPadreId ?? "null"),(nombreSecPadre ?? "null"),
                                                    (autNombre ?? "null"),(traNombre ?? "null"),(expediente ?? "null"),(nombreProyecto ?? "null"),(tarFechaCreacion ?? "null"),
                                                    (tarFechaFinalizacion ?? "null"),(municipio ?? "null"),(departamento ?? "null"),(nombreCompleto ?? "null"),(solIdSolicitante ?? "null"),
                                                    (origen ?? "null"), (numeroDocumento ?? "null"));
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "InsertarRegistroEnBodegaVsBodDataSila", strDatosRecibidos, "", 0);

            ConsultaPublica objConsultaPublica = new ConsultaPublica();

            var resp = objConsultaPublica.InsertarRegistroEnBodegaVsBodDataSila(tarSolId, solNumSilpa, secId, SecNombre, secPadreId, nombreSecPadre,
                                                    autNombre,traNombre,expediente,nombreProyecto, tarFechaCreacion,
                                                     tarFechaFinalizacion, municipio, departamento, nombreCompleto, solIdSolicitante,
                                                     origen.ToUpper(), numeroDocumento);
            respuesta.Add(resp.ToString());
            respuesta.Add("");
            return respuesta;
        }
        catch (Exception ex)
        {
            //SMLog.Escribir(ex);
            SMLogWS.EscribirExcepcion(this.ToString(), "InsertarRegistroEnBodegaVsBodDataSila", ex.ToString(), 5);
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "InsertarRegistroEnBodegaVsBodDataSila", ex.ToString(), iIdPadre);
            respuesta.Add("-1");
            respuesta.Add(ex.Message);
            return respuesta;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "InsertarRegistroEnBodegaVsBodDataSila", "", "", 0, iIdPadre);
        }
    }
}
