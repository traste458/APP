using System.IO;
using System.Xml;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System;
using System.Web.UI.WebControls;
using SILPA.Servicios;
using SILPA.Servicios.SolicitudDAA;
using SILPA.Servicios.Generico;
using SILPA.Servicios.Generico.RadicarDocumento;
using SoftManagement.Log;
using SILPA.Servicios.CesionDerechos;
using Referenciador;
using SILPA.Servicios.ImpresionFUS;
using SILPA.Servicios.PINES;
using SILPA.LogicaNegocio.DAA;
//jmartinez obtengo la libreria para radicar 


[WebService(Namespace = "http://www.workflowcolombia.com/eworkflow/Services/WorkFlowServices.asmx")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class GattacaBPMServices9000 : System.Web.Services.WebService
{

    /// <summary>
    /// Url de ubicacion del servicio.
    /// </summary>
    private string url;


    /// <summary>
    /// constructor
    /// </summary>
    public GattacaBPMServices9000()
    {
        BPMServices.GattacaBPMServices9000 service = new BPMServices.GattacaBPMServices9000();
        this.url = service.Url;
        //this.url =  System.Configuration.ConfigurationManager.AppSettings["BpmServices"].ToString();
    }

    /// <summary>
    /// Constructor que permite el cambio de url del servicio del BPM Gattaca
    /// </summary>
    /// <param name="strUrl">url del servico</param>
    public GattacaBPMServices9000(string strUrl)
    {
        this.url = strUrl;
    }


    /// <summary>
    /// Configura el url del servicio del BPM Gattaca
    /// </summary>
    /// <param name="obj"></param>
    private void SetUrlServicio(ref BPMServices.GattacaBPMServices9000 obj)
    {
        if (this.url != string.Empty && this.url != null)
        {
            ((BPMServices.GattacaBPMServices9000)obj).Url = this.url;
        }
    }
    
    [WebMethod(Description = "Retorna True si la conexion al WS esta correcta")]
    public bool TestTransmission()
    {
        Int64 iIdPadre = 0;
        bool blnRespuesta = false;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "TestTransmission", "", "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            blnRespuesta = objBpmServices.TestTransmission();
            return blnRespuesta;
        }
        catch(Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "TestTransmission", ex.ToString(), iIdPadre);
            SMLog.Escribir(Severidad.Informativo, "++++Falla Incia TestTransmission: " +  ex.ToString());
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "TestTransmission", blnRespuesta.ToString(), "", 0, iIdPadre);
        }
    }

    [WebMethod(Description = "Retorna XML con los Paquetes asociados al cliente")]
    public string GetPackages(string Client, Int64 UserId, bool IsOnlyEnabled)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";
        
        try{
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetPackages", string.Format("Client: {0} -- UserId: {1} -- IsOnlyEnabled: {2} ", (Client ?? "null"), UserId.ToString(), IsOnlyEnabled.ToString()), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            strRespuesta = objBpmServices.GetPackages(Client, UserId, IsOnlyEnabled);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetPackages", ex.ToString(), iIdPadre);
            SMLog.Escribir(Severidad.Informativo, "++++Falla Incia GetPackages: " + ex.ToString());
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetPackages", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Retorna XML con los Procesos asociados al cliente")]
    public string GetProcesses(string Client,Int64 UserID,bool IsOnlyEnabled)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";
     
        try
       {
           iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetProcesses", string.Format("Client: {0} -- UserId: {1} -- IsOnlyEnabled: {2} ", (Client ?? "null"), UserID.ToString(), IsOnlyEnabled.ToString()), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            strRespuesta = objBpmServices.GetProcesses(Client, UserID, IsOnlyEnabled);
            return strRespuesta;
        }
        catch(Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetProcesses", ex.ToString(), iIdPadre);
            SMLog.Escribir(Severidad.Informativo, "++++Falla Incia GetProcesses: " + ex.ToString());
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetProcesses", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Retorna XML con los Procesos asociados al cliente")]
    public string GetProcessById(string Client, Int64 UserID, Int64 IdProcess)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetProcessById", string.Format("Client: {0} -- UserId: {1} -- IdProcess: {2} ", (Client ?? "null"), UserID.ToString(), IdProcess.ToString()), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            strRespuesta = objBpmServices.GetProcessById(Client, UserID, IdProcess);
            return strRespuesta;
        }
        catch(Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetProcessById", ex.ToString(), iIdPadre);
            SMLog.Escribir(Severidad.Informativo, "++++Falla Incia GetProcessById: " + ex.ToString());
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetProcessById", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }

    [WebMethod(Description = "Retorna XML con los Procesos asociados al cliente")]
    public string GetActivityInstanceByUserId(string Client, Int64 UserID, Int16 Status, Int64 Activity,Int64 IdProcessInstance, string OrderBy)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";
     
        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetActivityInstanceByUserId", string.Format("Client: {0} -- UserId: {1} -- Status: {2} -- Activity: {3} -- IdProcessInstance: {4} -- OrderBy: {5}", (Client ?? "null"), UserID.ToString(), Status.ToString(), Activity.ToString(), IdProcessInstance.ToString(), (OrderBy ?? "null")), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            strRespuesta = objBpmServices.GetActivityInstanceByUserId(Client, UserID, Status, Activity, IdProcessInstance, OrderBy);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetActivityInstanceByUserId", ex.ToString(), iIdPadre);
            SMLog.Escribir(Severidad.Informativo, "++++Falla Incia GetActivityInstanceByUserId: " + ex.ToString());
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetActivityInstanceByUserId", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }

    [WebMethod(Description = "Retorna XML con los Procesos asociados al cliente")]
    public string GetActivityInstancesByUserId(string Client, Int64 UserID, Int16 Status,Int64 IdProcessInstance, Int16 MaxInstanceActivity, string OrderBy)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetActivityInstancesByUserId", string.Format("Client: {0} -- UserId: {1} -- Status: {2} -- IdProcessInstance: {3} -- MaxInstanceActivity: {4} -- OrderBy: {5}", (Client ?? "null"), UserID.ToString(), Status.ToString(), IdProcessInstance.ToString(), MaxInstanceActivity.ToString(), (OrderBy ?? "null")), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            strRespuesta = objBpmServices.GetActivityInstancesByUserId(Client, UserID, Status,IdProcessInstance, MaxInstanceActivity, OrderBy);
            return strRespuesta;

        }
        catch(Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetActivityInstancesByUserId", ex.ToString(), iIdPadre);
            SMLog.Escribir(Severidad.Informativo, "++++Falla Incia GetActivityInstancesByUserId: " + ex.ToString());
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetActivityInstancesByUserId", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Retorna XML con los Procesos asociados al cliente")]
    public string GetProcessInstancesById(string Client, Int64 UserID, Int64 ProcessInstancesId)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetProcessInstancesById", string.Format("Client: {0} -- UserId: {1} -- ProcessInstancesId: {3}", (Client ?? "null"), UserID.ToString(), ProcessInstancesId.ToString()), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            strRespuesta = objBpmServices.GetProcessInstancesById(Client, UserID, ProcessInstancesId);
            return strRespuesta;
        }
       catch(Exception ex)
       {
           SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetProcessInstancesById", ex.ToString(), iIdPadre);
           SMLog.Escribir(Severidad.Informativo, "++++Falla Incia GetProcessInstancesById: " + ex.ToString());
           throw;
       }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetProcessInstancesById", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }



    [WebMethod(Description = "Crear un proceso por medio del Generador")]
    public string CreateProcessXML(string Client, string sXML)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "CreateProcessXML", string.Format("Client: {0} -- sXML: {1}", (Client ?? "null"), (sXML ?? "null")), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            strRespuesta = objBpmServices.CreateProcessXML(Client, sXML);
            return strRespuesta;
        }
        catch(Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "CreateProcessXML", ex.ToString(), iIdPadre);
            SMLog.Escribir(Severidad.Informativo, "++++Falla Incia CreateProcessXML: " + ex.ToString());
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "CreateProcessXML", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Crea una Instancia de Proceso")]
    public Int64 WMCreateProcessInstance(string Client, Int64 UserID, Int64 IDProcessCase, Int64 Sequence, string EntryDataType, string IDEntryData, string EntryData)
    {
        Int64 iIdPadre = 0;
        String strMensaje2 = "Client: " + Client + " UserID: " + UserID.ToString() + "  IDProcessCase: " + IDProcessCase.ToString() + " Sequence: " + Sequence.ToString() + " EntryDataType:" + EntryDataType + "IDEntryData: " + IDEntryData + " EntryData:" + EntryData;
        SMLog.Escribir(Severidad.Informativo, "++++ Incia WMCreateProcessInstance: " + strMensaje2);
        Int64 resultado = -1;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "WMCreateProcessInstance", string.Format("Client: {0} -- UserId: {1} -- IDProcessCase: {2} -- Sequence: {3} -- EntryDataType: {4} -- IDEntryData: {5} -- EntryData: {6}", (Client ?? "null"), UserID.ToString(), IDProcessCase.ToString(), Sequence.ToString(), (EntryDataType ?? "null"), (IDEntryData ?? "null"), (EntryData ?? "null")), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            resultado = objBpmServices.WMCreateProcessInstance(Client, UserID, IDProcessCase, Sequence, EntryDataType, IDEntryData, EntryData);
           
            ProcesoFachada proceso = new ProcesoFachada(Client, UserID, resultado);
            
            //imp.AdicionarProcesoImpresionFus((Int32)resultado);
            if (proceso.rad.objRadicacion._objRadDocIdentity.Id != 0)
            {
                ImpresionFUSFachada.GenerarFus(proceso.rad.objRadicacion._objRadDocIdentity.Id, (Int32)resultado, proceso.rad.objRadicacion._objRadDocIdentity.UbicacionDocumento, proceso.rad.objRadicacion._objRadDocIdentity.NumeroVITALCompleto, proceso.rad.objRadicacion._objRadDocIdentity.IdSolicitante);
                proceso.rad.objRadicacion._objRadDocIdentity.Leido = false;
                proceso.rad.objRadicacion.ActualizarEstadoRadicacion();                
            }


            int? IdAA = proceso.rad.objRadicacion._objRadDocIdentity.IdAA;

            if (IdAA == null)
            {
                IdAA = 0;
            }

            return resultado;
        }
        catch (Exception ex)
        {
            String strMensaje = "Client: " + Client + " UserID: " + UserID.ToString() + "  IDProcessCase: " + IDProcessCase.ToString() + " Sequence: " + Sequence.ToString() + " EntryDataType:" + EntryDataType + "IDEntryData: " + IDEntryData + " EntryData:" + EntryData;
            SMLog.Escribir(Severidad.Critico, "++++Falla Incia WMCreateProcessInstance: " +strMensaje + ex.ToString());
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "WMCreateProcessInstance", ex.ToString(), iIdPadre);
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "WMCreateProcessInstance", resultado.ToString(), "", 0, iIdPadre);
        }
    }



    /// <summary>
    /// Instancia los procesos de silpa
    /// </summary>
    /// <param name="Client"></param>
    /// <param name="UserID"></param>
    /// <param name="IDProcessInstance"></param>
    /// <returns></returns>
    [WebMethod(Description = "Inicia la ejecución de un proceso")]
    public Int64 WMStartProcessInstance(string Client, Int64 UserID, Int64 IDProcessInstance)
    {
        BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();

        SetUrlServicio(ref objBpmServices);
        string data = Client + " -  " + UserID.ToString() + " -  " + IDProcessInstance.ToString() + objBpmServices.Url.ToString();
        Int64 iIdPadre = 0;
        Int64 resultado=0;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "WMStartProcessInstance", string.Format("Client: {0} -- UserId: {1} -- IDProcessInstance: {2}", (Client ?? "null"), UserID.ToString(), IDProcessInstance.ToString()), "", 0);

            resultado = objBpmServices.WMStartProcessInstance(Client, UserID, IDProcessInstance);
            Alarmas clsAlarmas = new Alarmas();
            clsAlarmas.NotificarCrearcionActivityInstance(UserID, IDProcessInstance);
            return resultado;
        }
        catch (Exception ex)
        {
            SMLog.Escribir(Severidad.Informativo, "++++Falla Incia WMStartProcessInstance: " + ex.ToString());
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "WMStartProcessInstance", ex.ToString(), iIdPadre);
            return resultado;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "WMStartProcessInstance", resultado.ToString(), "", 0, iIdPadre);
        }
        
    }


    [WebMethod(Description = "Finaliza la ejecución de una tarea")]
    public string EndActivityInstance
        (
        string Client, Int64 UserID,Int64 activityInstanceID,Int64 processInstanceID,string selectedCondition,string comments,
        string outComments, string entryDataType, string entryData, string idEntryData
        )
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {

            String strMensaje = "Client: " + Client + " UserID: " + UserID.ToString() + " activityInstanceID:" + activityInstanceID.ToString() + "  IDProcessCase: " + processInstanceID.ToString() +
                " selectedCondition: " + selectedCondition + " comments:" + comments + "outComments: " + outComments + " entryDataType:" + entryDataType + " entryData:" + entryData + " idEntryData:" + idEntryData;
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "EndActivityInstance", strMensaje, "", 0);
            SMLog.Escribir(Severidad.Informativo, "++++Inicia la finalizacion de la tarea: " + strMensaje);
            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);

            strRespuesta = objBpmServices.EndActivityInstance
                (Client, UserID, activityInstanceID, processInstanceID, selectedCondition, comments,
                  outComments, entryDataType, entryData, idEntryData);

            return strRespuesta;
        }
        catch(Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "EndActivityInstance", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "EndActivityInstance", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Retorna las Condiciones validas para una instancia de actividad")]
    public BPMServices.ListItem[] GetConditionsByActivityInstance(string Client, Int64 UserID, Int64 ActivityInstanceID)
    {
        Int64 iIdPadre = 0;
        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetConditionsByActivityInstance", string.Format("Client: {0} -- UserId: {1} -- ActivityInstanceID: {2}", (Client ?? "null"), UserID.ToString(), ActivityInstanceID.ToString()), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            return objBpmServices.GetConditionsByActivityInstance(Client, UserID, ActivityInstanceID);
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetConditionsByActivityInstance", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetConditionsByActivityInstance", "", "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Retorna el tipo de condición de salida para una instancia de actividad")]
    public string GetConditionsTypeActivityInstance(string Client, Int64 UserID, Int64 ActivityInstanceID)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetConditionsTypeActivityInstance", string.Format("Client: {0} -- UserId: {1} -- ActivityInstanceID: {2}", (Client ?? "null"), UserID.ToString(), ActivityInstanceID.ToString()), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            strRespuesta = objBpmServices.GetConditionsTypeActivityInstance(Client, UserID, ActivityInstanceID);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetConditionsTypeActivityInstance", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetConditionsTypeActivityInstance", strRespuesta, "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Retorna las Condiciones validas para una actividad")]
    public string GetConditions(string Client, Int64 UserID, Int64 ActivityInstanceID)
    {     
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetConditions", string.Format("Client: {0} -- UserId: {1} -- ActivityInstanceID: {2}", (Client ?? "null"), UserID.ToString(), ActivityInstanceID.ToString()), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            return objBpmServices.GetConditions(Client, UserID, ActivityInstanceID);
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetConditions", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetConditions", strRespuesta, "", 0, iIdPadre);
        }
    }

    /// <summary>
    /// Método donde se instancia la Solicitud DAA
    /// </summary>
    /// <param name="Client"></param>
    /// <param name="UserID"></param>
    /// <param name="activityInstanceID"></param>
    /// <param name="processInstanceID"></param>
    /// <param name="entryDataType"></param>
    /// <param name="entryData"></param>
    /// <param name="idEntryData"></param>
    /// <returns>bool: True-> Exito / False: Fracaso</returns>
    [WebMethod(Description = "Adjunta a una instancia de actividad una referencia de datos de una herramienta externa.")]
    public bool AttachDataToActivityInstance(string Client,Int64 UserID,Int64 activityInstanceID,
                                             Int64 processInstanceID,string entryDataType,
                                             string entryData,string idEntryData)
    {

        
        bool blnResult = false;
        string strMensaje = "Client: " + Client + " UserId: " + UserID + " activityInstanceID: " + activityInstanceID + " processInstanceID: " + processInstanceID + " entryDataType: " + entryDataType + " entryData: " + entryData + " idEntryData: " + idEntryData;
        SMLog.Escribir(Severidad.Informativo, "++++Incia AttachDataToActivityInstanc -- " + strMensaje);
        Int64 iIdPadre = 0;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "AttachDataToActivityInstance", string.Format("Client: {0} -- UserId: {1} -- activityInstanceID: {2} -- processInstanceID: {3} -- entryDataType: {4} -- entryData: {5} -- idEntryData: {6}", (Client ?? "null"), UserID.ToString(), activityInstanceID.ToString(), processInstanceID.ToString(), (entryDataType ?? "null"), (entryData ?? "null"), (idEntryData ?? "null")), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);

            //SMLog.Escribir(Severidad.Informativo, "radicado desde:  AttachDataToActivityInstance A");

            RadicacionDocumentoFachada objRadFachada = new RadicacionDocumentoFachada();
            objRadFachada.EnviarDatosRadicacion(processInstanceID, entryData, idEntryData);

            blnResult = objBpmServices.AttachDataToActivityInstance(Client, UserID, activityInstanceID, processInstanceID, entryDataType,
                                                      entryData, idEntryData);

            // Se actualiza el participante de la forma
            // en el caso en que exista cesion de derechos..
            CesionFechada ces = new CesionFechada();
            ces.ActualizarParticipanteForma(processInstanceID);

            objRadFachada.VerificarActividadRadicable(Client, UserID, activityInstanceID, processInstanceID, entryDataType,
                                                      entryData, idEntryData);


            string str_mensaje1 = DateTime.Now.ToString() + "   ********   ";

            str_mensaje1 = "pasa VerificarActividadRadicable: " + objRadFachada.objRadicacion._objRadDocIdentity.IdAA.ToString() + " NumeroSilpa: " + objRadFachada.objRadicacion._objRadDocIdentity.NumeroSilpa;

     

            objRadFachada.ConsultarAutoridad(objRadFachada.objRadicacion._objRadDocIdentity.IdAA);

            string str_mensaje2 = DateTime.Now.ToString() + "   ********   ";

            str_mensaje2 = "pasa ConsultarAutoridad";



            string str_ruta = objRadFachada.objRadicacion._objRadDocIdentity.UbicacionDocumento;
            string str_AA = objRadFachada.objAutoridad.objAutoridadIdentity.Nombre;

        
            SILPA.LogicaNegocio.Generico.Formulario objFormulario = new SILPA.LogicaNegocio.Generico.Formulario();
            objFormulario.ConsultaDatosEnvioCorreoEE(idEntryData, UserID, entryData, str_ruta, str_AA);
        

            return blnResult;
        }
        catch (Exception ex)
        {
            
            string str_mensaje = DateTime.Now.ToString() + "   ********   " + ex.ToString();

            str_mensaje = str_mensaje + "  Client:" + Client + "   UserID:" + UserID.ToString() +
                "  activityInstanceID:" + activityInstanceID.ToString() +
                "   processInstanceID:" + processInstanceID.ToString() +
                "   entryDataType:" + entryDataType.ToString() +
                "   entryData:" + entryData +
                "   idEntryData:" + idEntryData;

            

            SMLog.Escribir(Severidad.Informativo, "++++Fallo Incia AttachDataToActivityInstanc Detalle:" + str_mensaje);
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "AttachDataToActivityInstance", ex.ToString(), iIdPadre);
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "AttachDataToActivityInstance", blnResult.ToString(), "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Adjunta a una instancia de actividad un archivo.")]
    public bool AttachFileToActivityInstance(string Client ,Int64 UserID,Int64 activityInstanceID,Int64 processInstanceID, string FullFileName)
    {
        Int64 iIdPadre = 0;
        bool blnRespuesta = false;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "AttachFileToActivityInstance", string.Format("Client: {0} -- UserId: {1} -- activityInstanceID: {2} -- FullFileName {3}", (Client ?? "null"), UserID.ToString(), activityInstanceID.ToString(), (FullFileName ?? "null")), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            blnRespuesta = objBpmServices.AttachFileToActivityInstance(Client ,UserID,activityInstanceID,processInstanceID, FullFileName);
            return blnRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "AttachFileToActivityInstance", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "AttachFileToActivityInstance", blnRespuesta.ToString(), "", 0, iIdPadre);
        }
    }

	
    [WebMethod(Description = "Adjunta a un comentario a una instancia de proceso.")]
	public bool AttachCommentToProcessInstance(string Client,Int64 UserID,Int64 processInstanceID,string  Comment)
    {
        Int64 iIdPadre = 0;
        bool blnRespuesta = false;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "AttachCommentToProcessInstance", string.Format("Client: {0} -- UserId: {1} -- processInstanceID: {2} -- Comment {3}", (Client ?? "null"), UserID.ToString(), processInstanceID.ToString(), (Comment ?? "null")), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            blnRespuesta = objBpmServices.AttachCommentToProcessInstance(Client,UserID,processInstanceID,Comment);
            return blnRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "AttachCommentToProcessInstance", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "AttachCommentToProcessInstance", blnRespuesta.ToString(), "", 0, iIdPadre);
        }
    }
	


    [WebMethod(Description = "Retorna XML con los casos de procesos")]
    public string GetProcessCasesByProcess(string Client,Int64 UserID,Int64 IdProcess,bool IsOnlyEnabled)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetProcessCasesByProcess", string.Format("Client: {0} -- UserId: {1} -- IdProcess: {2} -- IsOnlyEnabled {3}", (Client ?? "null"), UserID.ToString(), IdProcess.ToString(), IsOnlyEnabled.ToString()), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            strRespuesta = objBpmServices.GetProcessCasesByProcess(Client, UserID, IdProcess, IsOnlyEnabled);
            return strRespuesta;
        }
        catch (Exception ex)
        {
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetProcessCasesByProcess", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetProcessCasesByProcess", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Retorna XML con los Id de los formularios que contiene un caso de proceso")]
    public string GetFormsByProcessCase(string Client,Int64 UserID,Int64 IdProcessCase)
    {
        Int64 iIdPadre = 0;
        string strRespuesta = "";

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetFormsByProcessCase", string.Format("Client: {0} -- UserId: {1} -- IdProcessCase: {2}", (Client ?? "null"), UserID.ToString(), IdProcessCase.ToString()), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            strRespuesta = objBpmServices.GetFormsByProcessCase(Client,UserID,IdProcessCase);
            return strRespuesta;
        }
        catch(Exception ex)
        {
            SMLog.Escribir(Severidad.Critico, "Error: GetFormsByProcessCase +++++ " + ex.ToString());
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetFormsByProcessCase", ex.ToString(), iIdPadre);
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetFormsByProcessCase", (strRespuesta ?? "null"), "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Obtener todos los atributos del proceso. Retorna [Id, IdProcess, Name]")]
    public BPMServices.ProcessAttributeEntity[] GetProcessAttribute(string Client, Int64 UserID, Int64 IdProcess)
    {
        Int64 iIdPadre = 0;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetProcessAttribute", string.Format("Client: {0} -- UserId: {1} -- IdProcess: {2}", (Client ?? "null"), UserID.ToString(), IdProcess.ToString()), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            return objBpmServices.GetProcessAttribute(Client,UserID,IdProcess);
        }
        catch(Exception ex)
        {
            SMLog.Escribir(Severidad.Critico, "Error: GetProcessAttribute +++++ " + ex.ToString());
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetProcessAttribute", ex.ToString(), iIdPadre);
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetProcessAttribute", "", "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Obtener todos los valores de los atributos del proceso. Retorna [Id, IdProcess, Name]")]
    public BPMServices.ProcessAttributeEntity[] GetProcessAttributeValue(string Client, Int64 UserID, Int64 IdProcessInstance)
    {
        Int64 iIdPadre = 0;
        
        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetProcessAttributeValue", string.Format("Client: {0} -- UserId: {1} -- IdProcessInstance: {2}", (Client ?? "null"), UserID.ToString(), IdProcessInstance.ToString()), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            return objBpmServices.GetProcessAttributeValue(Client, UserID, IdProcessInstance);
        }
        catch(Exception ex)
        {
            SMLog.Escribir(Severidad.Critico, "Error: GetProcessAttributeValue +++++ " + ex.ToString());
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetProcessAttributeValue", ex.ToString(), iIdPadre);
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetProcessAttributeValue", "", "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Obtener un valor en especifico de los atributos del proceso. Retorna un DataTable")]
    public BPMServices.ProcessAttributeEntity[] GetProcessAttributeValueById(string Client,Int64 UserID ,Int64 lIdProcessInstance,Int64 IdProcessAttribute)
    {
        Int64 iIdPadre = 0;

        try
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "GetProcessAttributeValueById", string.Format("Client: {0} -- UserId: {1} -- lIdProcessInstance: {2} -- IdProcessAttribute: {3}", (Client ?? "null"), UserID.ToString(), lIdProcessInstance.ToString(), IdProcessAttribute.ToString()), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            return objBpmServices.GetProcessAttributeValueById(Client,UserID,lIdProcessInstance,IdProcessAttribute);
        }
        catch(Exception ex)
        {
            SMLog.Escribir(Severidad.Critico, "Error: GetProcessAttributeValueById +++++ " + ex.ToString());
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "GetProcessAttributeValueById", ex.ToString(), iIdPadre);
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "GetProcessAttributeValueById", "", "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Actualizar un valor en especifico de los atributos del proceso, si este se ejecuto correctamente retorna True")]
    public bool UpdateProcessAttributeValue(string Client,Int64 UserID, Int64  IdProcessInstance, Int64 IdProcessAttribute, string Value)
    {
        Int64 iIdPadre = 0;
        bool blnRespuesta = false;

        try 
        {
            iIdPadre = SoftManagement.LogWS.SMLogWS.EscribirInicio(this.ToString(), "UpdateProcessAttributeValue", string.Format("Client: {0} -- UserId: {1} -- IdProcessInstance: {2} -- IdProcessAttribute: {3} -- Value: {4}", (Client ?? "null"), UserID.ToString(), IdProcessInstance.ToString(), IdProcessAttribute.ToString(), (Value ?? "null")), "", 0);

            BPMServices.GattacaBPMServices9000 objBpmServices = new BPMServices.GattacaBPMServices9000();
            SetUrlServicio(ref objBpmServices);
            blnRespuesta = objBpmServices.UpdateProcessAttributeValue(Client, UserID, IdProcessInstance, IdProcessAttribute, Value);
            return blnRespuesta;
        }
        catch(Exception ex)
        {
            SMLog.Escribir(Severidad.Critico, "Error: UpdateProcessAttributeValue +++++ " + ex.ToString());
            SoftManagement.LogWS.SMLogWS.EscribirExcepcion(this.ToString(), "UpdateProcessAttributeValue", ex.ToString(), iIdPadre);
            throw;
        }
        finally
        {
            SoftManagement.LogWS.SMLogWS.EscribirFinalizar(this.ToString(), "UpdateProcessAttributeValue", blnRespuesta.ToString(), "", 0, iIdPadre);
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

    
    /// <summary>
    /// mascara que utililiza la impresion dinámica de FUS
    /// </summary>
    /// <param name="idProcessInstance">Objecto que representa el Id de la instancia del proceso</param>
    private void EjecucionImpresion(int idProcessInstance)
    {
        try
        {
            //WSIMP01 impresor = new WSIMP01();
            Referenciador.WSIMP01.WSIMP01 impresor = new Referenciador.WSIMP01.WSIMP01();
            impresor.AdicionarProcesoImpresionFus(idProcessInstance);   
        }
        catch(Exception ex)
        {
            SMLog.Escribir(Severidad.Critico, "Error: EjecucionImpresion +++++ " + ex.ToString());
            throw;
        }
        
    }
}
