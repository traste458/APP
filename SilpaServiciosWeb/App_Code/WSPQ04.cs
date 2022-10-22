using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using SILPA.LogicaNegocio.Generico;
using SILPA.Comun;
using System.Xml;
using SoftManagement.Log;
using SoftManagement.LogWS;
using PSEWebServicesClient3;
using System.Collections.Generic;
using SILPA.AccesoDatos.Generico;
using SILPA.AccesoDatos.DAA;
using Silpa.Workflow;

/// <summary>
/// Summary description for WSPQ04
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
//[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WSPQ04 : System.Web.Services.WebService
{

    #region Metodos Privados

        /// <summary>
        /// Indica si el log informativo se encuentra activo
        /// </summary>
        /// <returns>bool que indica si el log se encuentra activo</returns>
        private bool LogInformativoActivo()
        {
            SILPA.AccesoDatos.Generico.ParametroDalc objParametroDalc = null;
            SILPA.AccesoDatos.Generico.ParametroEntity objParametroLog = null;

            //Consultar el valor del parametro
            objParametroLog = new SILPA.AccesoDatos.Generico.ParametroEntity();
            objParametroLog.IdParametro = -1;
            objParametroLog.NombreParametro = "LOG_PSE_WS_Resultado_Pago";
            objParametroDalc = new SILPA.AccesoDatos.Generico.ParametroDalc();
            objParametroDalc.obtenerParametros(ref objParametroLog);

            //Retornar respuesta
            return (objParametroLog.Parametro.Trim().Equals("1") ? true : false);
        }

    #endregion



    public WSPQ04()
    {
               
    }





    
    /// <summary>
    /// Entrega los datos recibidos del pago realizado
    /// </summary>   
    [WebMethod(Description = "[Entrega los datos recibidos del pago realizado]", MessageName = "CU-NG-07")]
    public string EnviarDatosPago(string numReferencia)
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), "EnviarDatosPago", numReferencia, "", 0);
            //Se envia informacion  
            Cobro obj = new Cobro();
            return obj.ConsultarDatosPago(numReferencia);
        }
        catch (Exception ex)
        {
            //SMLog.Escribir(ex);
            SMLogWS.EscribirExcepcion(this.ToString(), "EnviarDatosPago", ex.ToString(), iIdPadre);
            return "";
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), "EnviarDatosPago", numReferencia, strNoVital, iAA, iIdPadre);
        }
    }

    [WebMethod(Description = "[Entrega los datos recibidos del pago realizado por pse]", MessageName = "CU-I-EXPI-10")]
    public string EnviarDatosPago(string numReferencia, string codigoExpediente, string estado)
    {
        Int64 iIdPadre = 0;
        Int32 iAA = 0;
        String strNoVital = "";
        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), "EnviarDatosPago", "Numero Referencia: " + numReferencia + "CodigoEspediente: " + codigoExpediente + "Estado" + estado, "", 0);
            //Se envia informacion  
            Cobro obj = new Cobro();
            return obj.ConsultarDatosPago(numReferencia, codigoExpediente, estado);
        }
        catch (Exception ex)
        {
            //SMLog.Escribir(ex);
            SMLogWS.EscribirExcepcion(this.ToString(), "EnviarDatosPago", ex.ToString(), iIdPadre);
            return "";
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), "EnviarDatosPago", "Numero Referencia: " + numReferencia + "CodigoEspediente: " + codigoExpediente + "Estado" + estado, strNoVital, iAA, iIdPadre);
        }
    }


    /// <summary>
    /// Acciones a ejecutar en caso que el solicitante no haya realizado el pago
    /// </summary>   
    [WebMethod(Description = "[Verificar el estado de pago de una transacci�n contra PSE]", MessageName = "CU-NG-08")]
    public string MonitorearPagoPSE(string strNumeroTransaccionCUS)
    {
        MainServices objPSEWs = null;
        getTransactionInformationBodyType objRequest = null;
        getTransactionInformationResponseBodyType objResponse = null;
        finalizeTransactionPaymentInformationType objfin = null;
        Cobro objCobro = null;
        CobroIdentity objCobroIdentity = null;
        TransaccionPSEIdentity objTransaccion = null;
        EstadoCobro objEstadoCobro = null;
        EstadoCobroIdentity objEstadoCobroIdentity = null;
        bool blnLogInformativo = false;
        string strMensajeError = "";
        Int64 iIdPadre = 0;

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), "MonitorearPagoPSE", "strNumeroTransaccionCUS: " + (strNumeroTransaccionCUS ?? "null"), "", 0);

            //Cargar si se encuentra el log informativo cargado
            blnLogInformativo = this.LogInformativoActivo();

            if (blnLogInformativo)
                SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, "WSQ04 :: Pago: Iniciando Proceso de Validaci�n Transacci�n " + (strNumeroTransaccionCUS != null && strNumeroTransaccionCUS.Trim() != "" ? strNumeroTransaccionCUS : "-"));

            //Verificar que se especifique la referencia de pago
            if (strNumeroTransaccionCUS != null && strNumeroTransaccionCUS.Trim() != "")
            {
                //Consultar informaci�n de la transacci�n
                objCobro = new Cobro();
                objTransaccion = objCobro.ConsultarInformacionTransaccion(Convert.ToInt64(strNumeroTransaccionCUS));

                if (blnLogInformativo)
                    SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, "WSQ04 :: Pago: Verificar si se encontro informaci�n transcci�n " + strNumeroTransaccionCUS);

                //Validar que se encuentre informaci�n de la transacci�n
                if (objTransaccion != null)
                {
                    if (blnLogInformativo)
                        SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, "WSQ04 :: Pago: Verificar si se estado es Pendiente para transcci�n " + (strNumeroTransaccionCUS != null && strNumeroTransaccionCUS.Trim() != "" ? strNumeroTransaccionCUS : "-"));

                    //Validar que el estado sea pendiente
                    if (objTransaccion.Estado == (int)CobroEstados.PENDING)
                    {
                        if (blnLogInformativo)
                            SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, "WSQ04 :: Pago: Se inicia validaci�n contra PSE de la transacci�n " + (strNumeroTransaccionCUS != null && strNumeroTransaccionCUS.Trim() != "" ? strNumeroTransaccionCUS : "-"));

                        //Cargar datos de consulta
                        objRequest = new getTransactionInformationBodyType();
                        objRequest.trazabilityCode = strNumeroTransaccionCUS;
                        objRequest.entityCode = PPEController.GetConfiguration("PPE_CODE");

                        //REalizar consulta PSE
                        try
                        {
                            if (blnLogInformativo)
                                SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, "WSQ04 :: Pago: Se realiza consulta PSE de la transacci�n " + (strNumeroTransaccionCUS != null && strNumeroTransaccionCUS.Trim() != "" ? strNumeroTransaccionCUS : "-"));

                            objPSEWs = PPEController.GetPSEWebservice();
                            objResponse = objPSEWs.getTransactionInformation(objRequest);

                            if (blnLogInformativo)
                                SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, string.Format("WSQ04 :: Pago: Resultado consulta transacci�n " + (strNumeroTransaccionCUS != null && strNumeroTransaccionCUS.Trim() != "" ? strNumeroTransaccionCUS : "-") + " :: returnCode: {0} - transactionState: {1}", (objResponse != null ? objResponse.returnCode.ToString() : "-"), (objResponse != null ? objResponse.transactionState.ToString() : "")));

                            //Validar que se obtenga respuesta
                            if (objResponse != null)
                            {
                                if (blnLogInformativo)
                                    SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, "WSQ04 :: Pago: Se realiza verificaci�n codigo exitoso de consulta para transacci�n " + (strNumeroTransaccionCUS != null && strNumeroTransaccionCUS.Trim() != "" ? strNumeroTransaccionCUS : "-"));

                                //Validar si la consulta es exitosa
                                if (objResponse.returnCode == getTransactionInformationResponseReturnCodeList.SUCCESS)
                                {
                                    //Validar si la transacci�n fue exitosa
                                    if (objResponse.transactionState.ToString().Equals("OK"))
                                    {
                                        try
                                        {
                                            if (blnLogInformativo)
                                                SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, "WSQ04 :: Pago: Obtiene informaci�n de persona para transacci�n " + (strNumeroTransaccionCUS != null && strNumeroTransaccionCUS.Trim() != "" ? strNumeroTransaccionCUS : "-") + " - N�mero SILPA: " + objTransaccion.NumeroSilpa);

                                            //Obtener informaci�n de persona
                                            objCobro.ObtenerPersona(objTransaccion.NumeroSilpa);

                                            if (blnLogInformativo)
                                                SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, "WSQ04 :: Pago: Avanza transaccion en BPM para transacci�n " + (strNumeroTransaccionCUS != null && strNumeroTransaccionCUS.Trim() != "" ? strNumeroTransaccionCUS : "-"));

                                            //Avanzar la transacci�n en BPM si el origen no es autoliquidaci�n
                                            this.adelantarActividadToActividadBPM(objTransaccion.NumeroSilpa, objCobro.objPersona.Identity.NumeroIdentificacion.ToString());
                                        }
                                        catch (Exception exc)
                                        {
                                            //Escribir Log
                                            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "WSP04 :: MonitorearPagoPSE -> Se presento error realizando avance BPM de la transacci�n CUS: " + strNumeroTransaccionCUS + " Error: " + exc.StackTrace.ToString());

                                            strMensajeError = "Se presento error realizando avanze de transacci�n en BPM";
                                        }
                                    }

                                    //Si no se presento error y el estado es diferente a pendiente finalizar la transacci�n
                                    if (strMensajeError == "" && !objResponse.ToString().Equals("PENDING"))
                                    {
                                        try
                                        {
                                            if (blnLogInformativo)
                                                SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, "WSP04 :: Pago: Finaliza transacci�n en PSE  de transacci�n CUS: " + (strNumeroTransaccionCUS != null && strNumeroTransaccionCUS.Trim() != "" ? strNumeroTransaccionCUS : "-"));

                                            //Finalizar transacci�n
                                            objfin = new finalizeTransactionPaymentInformationType();
                                            objfin.entityCode = PPEController.GetConfiguration("PPE_CODE");
                                            objfin.trazabilityCode = objResponse.trazabilityCode;
                                            objPSEWs.finalizeTransactionPayment(objfin);
                                        }
                                        catch (Exception exc)
                                        {
                                            //Escribir Log
                                            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "WSP04 :: MonitorearPagoPSE -> Se presento error finalizando la transacci�n CUS: " + strNumeroTransaccionCUS + " Error: " + exc.StackTrace.ToString());

                                            strMensajeError = "Se presento error finalizando transacci�n";
                                        }
                                    }

                                    //Validar que no se presentaran errores 
                                    if (strMensajeError == "")
                                    {
                                        if (blnLogInformativo)
                                            SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, "WSP04 :: Pago: Actualizar estado de la transacci�n CUS: " + (strNumeroTransaccionCUS != null && strNumeroTransaccionCUS.Trim() != "" ? strNumeroTransaccionCUS : "-"));

                                        try
                                        {
                                            //Consultar informaci�n estado de cobro de acuerdo a respuesta
                                            objEstadoCobro = new EstadoCobro();
                                            objEstadoCobroIdentity = new EstadoCobroIdentity();
                                            objEstadoCobroIdentity.Nombre = objResponse.transactionState.ToString();
                                            objEstadoCobro.ConsultarEstadoCobro(ref objEstadoCobroIdentity);

                                            //Cargar datos de cobro
                                            objCobroIdentity = new CobroIdentity();
                                            objCobroIdentity.NumReferencia = objResponse.ticketId;
                                            objCobroIdentity.Transaccion = Convert.ToInt32(objResponse.trazabilityCode.Trim());
                                            objCobroIdentity.OrigenLlamadoPSE = "WS";
                                            objCobroIdentity.ServicioLlamadoPSE = "getTransactionInformation";
                                            objCobroIdentity.ResultadoServicioLlamadoPSE = objResponse.returnCode.ToString();
                                            objCobroIdentity.EstadoPSE = objResponse.transactionState.ToString().Trim();
                                            objCobroIdentity.EstadoCobro = objEstadoCobroIdentity.IdEstadoCobro;
                                            objCobroIdentity.FechaTransaccionBancaria = objResponse.bankProcessDate;

                                            //Actualizar estado
                                            objCobro.ActualizarCobroEstado(objCobroIdentity);
                                        }
                                        catch (Exception exc)
                                        {
                                            //Escribir Log
                                            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "WSP04 :: MonitorearPagoPSE -> Se presento error actualizando estado de la transacci�n CUS: " + strNumeroTransaccionCUS + " Error: " + exc.StackTrace.ToString());

                                            strMensajeError = "Se presento error actualizando estado de la transacci�n";
                                        }

                                    }
                                }
                                else
                                {
                                    //Escribir Log
                                    SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "WSP04 :: MonitorearPagoPSE -> No se obtuvo confirmaci�n exitosa por parte de PSE para la transacci�n CUS: " + strNumeroTransaccionCUS + " codigo retornado: " + objResponse.returnCode.ToString());

                                    strMensajeError = "No se obtuvo informaci�n de PSE para la transacci�n CUS";
                                }
                            }
                            else
                            {
                                //Escribir Log
                                SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "WSP04 :: MonitorearPagoPSE -> No se obtuvo informaci�n de PSE para la transacci�n CUS: " + strNumeroTransaccionCUS);

                                strMensajeError = "No se obtuvo informaci�n de PSE para la transacci�n CUS";
                            }
                        }
                        catch (Exception exc)
                        {
                            //Escribir Log
                            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "WSP04 :: MonitorearPagoPSE -> Se presento error realizando la consulta de transacci�n CUS: " + strNumeroTransaccionCUS + " Error: " + exc.StackTrace.ToString());

                            strMensajeError = "Se presento error consultando informaci�n contra PSE";
                        }
                    }
                    else
                    {
                        //Escribir Log
                        SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "WSP04 :: MonitorearPagoPSE -> No se encuentra en estado pendiente la transacci�n CUS: " + strNumeroTransaccionCUS + " el estado es: " + objTransaccion.Estado.ToString());

                        //Escribir mensaje de error
                        strMensajeError = "No se encuentra en estado pendiente la transacci�n CUS: " + strNumeroTransaccionCUS;
                    }
                }
                else
                {
                    //Escribir Log
                    SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "WSP04 :: MonitorearPagoPSE -> No se encontro informaci�n para la transacci�n CUS: " + strNumeroTransaccionCUS);

                    //Escribir mensaje de error
                    strMensajeError = "No se encontro informaci�n para la transacci�n CUS: " + strNumeroTransaccionCUS;
                }

            }
            else
            {
                //Escribir Log
                SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "WSP04 :: MonitorearPagoPSE -> No se especifico el n�mero de transacci�n CUS");

                //Escribir mensaje de error
                strMensajeError = "No se especifico el n�mero de transacci�n CUS";
            }

            if (blnLogInformativo)
                SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, "WSQ04 :: Pago: Finalizo Proceso de Validaci�n Transacci�n " + (strNumeroTransaccionCUS != null && strNumeroTransaccionCUS.Trim() != "" ? strNumeroTransaccionCUS : "-") + " - Resultado: " + (strMensajeError != "" ? strMensajeError : "OK"));

            return strMensajeError;
        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), "MonitorearPagoPSE", ex.ToString(), iIdPadre);
            throw ex;
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), "MonitorearPagoPSE", strMensajeError, "", 0, iIdPadre);
        }
    }


    public void adelantarActividadToActividadBPM(string strNumeroSilpa,string Usuario)
    {
        Int64 iIdPadre = 0;

        try
        {
            iIdPadre = SMLogWS.EscribirInicio(this.ToString(), "adelantarActividadToActividadBPM", string.Format("strNumeroSilpa: {0} -- Usuario: {1}", (strNumeroSilpa ?? "null"), (Usuario ?? "null")), "", 0);

            SolicitudDAAEIAIdentity _solicitud = new SolicitudDAAEIAIdentity();
            SolicitudDAAEIADalc _solicitudDalc = new SolicitudDAAEIADalc();
            _solicitud = _solicitudDalc.ObtenerSolicitud(null, null, strNumeroSilpa);

            string casoProceso = string.Empty;
            Proceso _objProceso = new Proceso();

            if (_solicitud.IdProcessInstance != null)
            {
                ProcesoDalc pDalc = new ProcesoDalc();
                _objProceso.PIdentity = pDalc.ObtenerObjProceso(_solicitud.IdProcessInstance);
            }

            string condicion = string.Empty;
            _objProceso.ObtenerCondicionPagoElectronico();
         
            condicion = _objProceso.PIdentity.CondicionPago;         
         
            ServicioWorkflow servicioWorkflow = new ServicioWorkflow();
            int intIDProcessInstance = Convert.ToInt32(_solicitud.IdProcessInstance);
            string strMensaje = servicioWorkflow.ValidarActividadActual(intIDProcessInstance,Usuario, (long)ActividadSilpa.ConsultarPago);
            if (string.IsNullOrWhiteSpace(strMensaje))
                servicioWorkflow.FinalizarTarea(intIDProcessInstance, ActividadSilpa.ConsultarPago, Usuario, condicion);            
            else
                //JNS 20190822 se escribe mensaje de error
                SMLog.Escribir(SoftManagement.Log.Severidad.Informativo, "BPM - Validacion :: WSPQ04::adelantarActividadToActividadBPM - strNumeroSilpa: " + (!string.IsNullOrEmpty(strNumeroSilpa) ? strNumeroSilpa : "null") + " - Usuario: " + (!string.IsNullOrWhiteSpace(Usuario) ? Usuario : "null") + "\n\n Error: " + strMensaje, "BPM_VAL_CON");

        }
        catch (Exception ex)
        {
            SMLogWS.EscribirExcepcion(this.ToString(), "adelantarActividadToActividadBPM", ex.ToString(), iIdPadre);
            SMLog.Escribir(SoftManagement.Log.Severidad.Critico, "Pago: Error Adelantar Tarea Pago PSE");                          
        }
        finally
        {
            SMLogWS.EscribirFinalizar(this.ToString(), "adelantarActividadToActividadBPM", "", "", 0, iIdPadre);
        }
    }


    [WebMethod(Description = "Metodo de test del servicio")]
    public void Test()
    {
        return;
    }
    
}

