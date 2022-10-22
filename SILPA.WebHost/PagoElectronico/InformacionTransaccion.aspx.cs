using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SILPA.Comun;
using SILPA.LogicaNegocio.Generico;
using SILPA.AccesoDatos.Generico;
using SoftManagement.Log;
using SILPA.AccesoDatos.DAA;  // agregado
using Silpa.Workflow;   // agregado
using PSEWebServicesClient3;

public partial class PagoElectronico_InformacionTransaccion : System.Web.UI.Page
{
    #region Propiedades

        /// <summary>
        /// Referencia de pago
        /// </summary>
        private string _TrazabilityCode
        {
            get;
            set;
        }

        /// <summary>
        /// Referencia de pago
        /// </summary>
        private string _TicketId
        {
            get;
            set;
        }

        /// <summary>
        /// Informaci�n del cobro
        /// </summary>
        private CobroIdentity _objCobroIdentity
        {
            get;
            set;
        }

        /// <summary>
        /// Indica si el log informativo se encuentra activo
        /// </summary>
        private bool _LogInformativoActivo
        {
            get;
            set;
        }

    #endregion


    #region Metodos Privados


        /// <summary>
        /// Carga el trazability code
        /// </summary>        
        private void CargarInformacionLogInformativo()
        {
            SILPA.AccesoDatos.Generico.ParametroDalc objParametroDalc = null;
            SILPA.AccesoDatos.Generico.ParametroEntity objParametroLog = null;

            //Consultar el valor del parametro
            objParametroLog = new SILPA.AccesoDatos.Generico.ParametroEntity();
            objParametroLog.IdParametro = -1;
            objParametroLog.NombreParametro = "LOG_PSE_Resultado_Pago";
            objParametroDalc = new SILPA.AccesoDatos.Generico.ParametroDalc();
            objParametroDalc.obtenerParametros(ref objParametroLog);

            //Cargar respuesta
            this._LogInformativoActivo = (objParametroLog.Parametro.Trim().Equals("1") ? true : false);
        }


        /// <summary>
        /// Carga el ticket id
        /// </summary>        
        private void CargarTicketID()
        {            
            if (this._LogInformativoActivo)
                SMLog.Escribir(Severidad.Informativo, "Pago: Cargar Informaci�n de ticket id");

            if (Request["ticketID"] == null && Context.Application[Request["ticketID"].ToString()] == null)
                throw new Exception("No se tiene informaci�n de ticket id");
            else if (Request["ticketID"] != null)
            {
                if (this._LogInformativoActivo)
                    SMLog.Escribir(Severidad.Critico, "Pago:Request[ticketID]:" + Request["ticketID"].ToString());

                this._TicketId = Request["ticketID"].ToString().Trim();
            }
            else
            {
                if (this._LogInformativoActivo)
                    SMLog.Escribir(Severidad.Critico, "Pago:Request[ticketID]:" + Request["ticketID"].ToString());

                this._TicketId = Context.Application[Request["ticketID"].ToString()].ToString();
            }            
        }

        /// <summary>
        /// Ocultar mensaje mostrado
        /// </summary>
        private void OcultarMensaje()
        {
            this.lblMensaje.Text = "";
            this.divMensajeError.Visible = false;
        }

        /// <summary>
        /// Mostrar el mensaje especificado
        /// </summary>
        /// <param name="p_strMensaje">string con el mensaje</param>
        private void MostrarMensaje(string p_strMensaje)
        {
            this.lblMensaje.Text = p_strMensaje;
            this.divMensajeError.Visible = true;
        }

        /// <summary>
        /// Verificar que la transaccion sea valida
        /// </summary>
        /// <returns>bool con true si la transacci�n se encuentra en estado pendiente y no supero tiempo m�ximo. false en caso contrario</returns>
        private bool TransaccionValida()
        {
            Cobro objCobro = null;
            bool blnTransaccionValida = false;
            int intNumeroMinutosTransaccion = 0;
            TimeSpan objDiferencia;

            //Cargar informaci�n de cobro
            objCobro = new Cobro();
            this._objCobroIdentity = objCobro.ObtenerCobroTransaccion(this._TicketId);
            
            //Verificar que exista informaci�n de la transacci�n
            if (this._objCobroIdentity != null)
            {
                //Cargar trazability code
                this._TrazabilityCode = this._objCobroIdentity.Transaccion.ToString();
                Session["TrazabilityCode"] = this._TrazabilityCode;

                //Validar que se tenga fecha de �ltima transaccion
                if (this._objCobroIdentity.FechaTransaccionPSE != default(DateTime))
                {
                    //Cargar cantidad de minutos de transaccion
                    intNumeroMinutosTransaccion = Convert.ToInt32(ConfigurationManager.AppSettings["PSE_Tiempo_Minutos_TransaccionValida"]);

                    //Calcular la diferencia de fechas
                    objDiferencia = DateTime.Now - this._objCobroIdentity.FechaTransaccionPSE;

                    //Validar que no se supere el n�mero de minutos de la transacci�n
                    if (objDiferencia.TotalMinutes <= intNumeroMinutosTransaccion)
                    {
                        blnTransaccionValida = true;
                    }
                }
                
            }

            return blnTransaccionValida;
        }


        /// <summary>
        /// Avanza la actividad de un proceso directamente a otra actividad
        /// </summary>
        /// <param name="strNumeroSilpa">String: identificador del numero silpa</param>
        private void adelantarActividadToActividadBPM(string strNumeroSilpa, PagoElectronico opcionPago)
        {
            try
            {
                SMLog.Escribir(Severidad.Informativo, "Pago:Adelantar Tarea adelantarActividadToActividadBPM" + " Numero_silpa: " + strNumeroSilpa + " Session[IDProcessInstance]: " + Session["IDProcessInstance"].ToString());

                SolicitudDAAEIAIdentity _solicitud = new SolicitudDAAEIAIdentity();
                SolicitudDAAEIADalc _solicitudDalc = new SolicitudDAAEIADalc();
                _solicitud = _solicitudDalc.ObtenerSolicitud(null, null, strNumeroSilpa);

                string casoProceso = string.Empty;

                Proceso _objProceso = new Proceso();

                if (Session["IDProcessInstance"] != null)
                {
                    ProcesoDalc pDalc = new ProcesoDalc();
                    _objProceso.PIdentity = pDalc.ObtenerObjProceso((long)Session["IDProcessInstance"]);
                }

                string condicion = string.Empty;
                _objProceso.ObtenerCondicionPagoElectronico();

                if (_objProceso.PIdentity != null && opcionPago == PagoElectronico.btnPago)
                {
                    condicion = _objProceso.PIdentity.CondicionPago;
                }

                if (_objProceso.PIdentity != null && opcionPago == PagoElectronico.btnImpresion)
                {
                    condicion = _objProceso.PIdentity.CondicionImprimirReciboPago;
                }

                SMLog.Escribir(Severidad.Informativo, "Pago:Adelantar Tarea adelantarActividadToActividadBPM" + " Procesinstance: " + _solicitud.IdProcessInstance.ToString() + " Condicion: " + condicion);
                ServicioWorkflow servicioWorkflow = new ServicioWorkflow();
                int intIDProcessInstance = Convert.ToInt32(_solicitud.IdProcessInstance);
                servicioWorkflow.ValidarActividadActual(intIDProcessInstance, DatosSesion.Usuario, (long)ActividadSilpa.ConsultarPago);
                servicioWorkflow.FinalizarTarea(intIDProcessInstance, ActividadSilpa.ConsultarPago, DatosSesion.Usuario, condicion);

            }
            catch (Exception ex)
            {
                SMLog.Escribir(ex);
                throw;
            }
        }


        /// <summary>
        /// Consultar informaci�n de la transacci�n y actualizar estado de acuerdo al resultado
        /// </summary>
        private void ConsultarInformacionTransaccion()
        {
            SILPA.AccesoDatos.Generico.ParametroDalc objParametroDalc = null;
            SILPA.AccesoDatos.Generico.ParametroEntity objParametro = null;
            SILPA.AccesoDatos.Generico.ParametroEntity objParametro2 = null;
            MainServices objPSEWs = null;
            getTransactionInformationBodyType objRequest = null;
            getTransactionInformationResponseBodyType objResponse = null;
            finalizeTransactionPaymentInformationType objfin = null;
            CobroIdentity objCobroIdentity = null;
            EstadoCobro objEstadoCobro = null;
            EstadoCobroIdentity objEstadoCobroIdentity = null;
            Cobro objCobro = null;

            //Consultar parametros
            objParametroDalc = new SILPA.AccesoDatos.Generico.ParametroDalc();
            objParametro = new SILPA.AccesoDatos.Generico.ParametroEntity();
            objParametro2 = new SILPA.AccesoDatos.Generico.ParametroEntity();
            objParametro.IdParametro = -1;
            objParametro2.IdParametro = -1;
            objParametro.NombreParametro = "Mensaje_Error_Pago";
            objParametro2.NombreParametro = "Mensaje_Pago_Pendiente";
            objParametroDalc.obtenerParametros(ref objParametro);
            objParametroDalc.obtenerParametros(ref objParametro2);

            //Cargar parametros de consulta de transacci�n
            if (this._LogInformativoActivo)
                SMLog.Escribir(Severidad.Informativo, "Pago: Cargando informaci�n de consulta");
            objRequest = new getTransactionInformationBodyType();
            objRequest.trazabilityCode = this._TrazabilityCode;
            objRequest.entityCode = PPEController.GetConfiguration("PPE_CODE");

            try
            {
                if (this._LogInformativoActivo)
                    SMLog.Escribir(Severidad.Informativo, "Pago: Realizando consulta contra PSE :: trazabilityCode: " + objRequest.trazabilityCode + " entityCode: " + objRequest.entityCode);

                objPSEWs = PPEController.GetPSEWebservice();
                objResponse = objPSEWs.getTransactionInformation(objRequest);

                if (this._LogInformativoActivo)
                    SMLog.Escribir(Severidad.Informativo, string.Format("Pago: Resultado consulta :: returnCode: {0} - transactionState: {1}", (objResponse != null ? objResponse.returnCode.ToString() : "-"), (objResponse != null ? objResponse.transactionState.ToString() : "")));

                //Validar que se obtenga respuesta
                if (objResponse != null)
                {
                    if (this._LogInformativoActivo)
                        SMLog.Escribir(Severidad.Informativo, "Pago: Se muestra informaci�n de acuerdo al resultado obtenido");

                    //Validar si la consulta es exitosa
                    if (objResponse.returnCode == getTransactionInformationResponseReturnCodeList.SUCCESS)
                    {
                        //Validar si la transacci�n fue exitosa
                        if (objResponse.transactionState.ToString().Equals("OK"))
                        {
                            try
                            {
                                if (this._LogInformativoActivo)
                                    SMLog.Escribir(Severidad.Informativo, "Pago: Avanza transaccion en BPM");

                                this.adelantarActividadToActividadBPM(this._objCobroIdentity.NumSILPA, PagoElectronico.btnPago);

                                try
                                {
                                    if (this._LogInformativoActivo)
                                        SMLog.Escribir(Severidad.Informativo, "Pago: Finaliza transacci�n en PSE");

                                    //Finalizar transacci�n
                                    objfin = new finalizeTransactionPaymentInformationType();
                                    objfin.entityCode = PPEController.GetConfiguration("PPE_CODE");
                                    objfin.trazabilityCode = objResponse.trazabilityCode;
                                    objPSEWs.finalizeTransactionPayment(objfin);
                                }
                                catch(Exception exc){
                                    //Escribir log
                                    SMLog.Escribir(Severidad.Critico, "PagoElectronico_InformacionTransaccion :: Pago: Error durante finalizaci�n de proceso en PSE " + exc.StackTrace.ToString());

                                    //Escalar excepcion
                                    throw exc;
                                }
                            }
                            catch(Exception exc){
                                //Escribir log
                                SMLog.Escribir(Severidad.Critico, "PagoElectronico_InformacionTransaccion :: Pago: Error durante avance de proceso de BPM " + exc.StackTrace.ToString());

                                //Escalar excepcion
                                throw exc;
                            }
                        }                        
                        else if (objResponse.transactionState.ToString().Equals("NOT_AUTHORIZED"))
                        {
                            try
                            {
                                if (this._LogInformativoActivo)
                                    SMLog.Escribir(Severidad.Informativo, "Pago: Finaliza transacci�n en PSE");

                                //Finalizar transacci�n
                                objfin = new finalizeTransactionPaymentInformationType();
                                objfin.entityCode = PPEController.GetConfiguration("PPE_CODE");
                                objfin.trazabilityCode = objResponse.trazabilityCode;
                                objPSEWs.finalizeTransactionPayment(objfin);
                            }
                            catch (Exception exc)
                            {
                                //Escribir log
                                SMLog.Escribir(Severidad.Critico, "PagoElectronico_InformacionTransaccion :: Pago: Error durante finalizaci�n de proceso en PSE " + exc.StackTrace.ToString());

                                //Escalar excepcion
                                throw exc;
                            }
                        }
                        else if (objResponse.transactionState.ToString().Equals("FAILED"))
                        {
                            try
                            {
                                if (this._LogInformativoActivo)
                                    SMLog.Escribir(Severidad.Informativo, "Pago: Finaliza transacci�n en PSE");

                                //Finalizar transacci�n
                                objfin = new finalizeTransactionPaymentInformationType();
                                objfin.entityCode = PPEController.GetConfiguration("PPE_CODE");
                                objfin.trazabilityCode = objResponse.trazabilityCode;
                                objPSEWs.finalizeTransactionPayment(objfin);
                            }
                            catch (Exception exc)
                            {
                                //Escribir log
                                SMLog.Escribir(Severidad.Critico, "PagoElectronico_InformacionTransaccion :: Pago: Error durante finalizaci�n de proceso en PSE " + exc.StackTrace.ToString());

                                //Escalar excepcion
                                throw exc;
                            }
                        }

                        if (this._LogInformativoActivo)
                            SMLog.Escribir(Severidad.Informativo, "Pago: Realizar el cambio de estado");

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
                            objCobroIdentity.OrigenLlamadoPSE = "IT";
                            objCobroIdentity.ServicioLlamadoPSE = "getTransactionInformation";
                            objCobroIdentity.ResultadoServicioLlamadoPSE = objResponse.returnCode.ToString();
                            objCobroIdentity.EstadoPSE = objResponse.transactionState.ToString().Trim();
                            objCobroIdentity.EstadoCobro = objEstadoCobroIdentity.IdEstadoCobro;
                            objCobroIdentity.FechaTransaccionBancaria = objResponse.bankProcessDate;
                            
                            //Actualizar estado
                            objCobro = new Cobro();
                            objCobro.ActualizarCobroEstado(objCobroIdentity);

                            //Cargr datos nuevamente
                            this._objCobroIdentity = objCobro.ObtenerCobroTransaccion(this._TicketId);
                        }
                        catch (Exception exc)
                        {
                            //Escribir log
                            SMLog.Escribir(Severidad.Critico, "PagoElectronico_InformacionTransaccion :: Pago: Error Actualizando estado " + exc.StackTrace.ToString());

                            //Mostrar mensaje
                            this.MostrarMensaje("Se presento error durante la actualizaci�n del estado en sistema VITAL");
                        }
                    }
                    else
                    {
                        //Genera excepci�n
                        throw new Exception("Se presento error durante la consulta de informaci�n. Se obtuvo resultado de transacci�n: " + objResponse.returnCode.ToString());
                    }
                }
                else
                {
                    throw new Exception("No se obtuvo informaci�n de la transacci�n " + (!string.IsNullOrWhiteSpace(this._TrazabilityCode) ? this._TrazabilityCode : "-") + " por parte de PSE");
                }
            }
            catch(Exception exc){
                //Mostrar mensaje
                this.MostrarMensaje("Se presento error durante la consulta del resultado de la transacci�n");

                //Escribir log
                SMLog.Escribir(Severidad.Critico, "PagoElectronico_InformacionTransaccion :: Pago: Error durante consulta contra PSE " + exc.StackTrace.ToString());
            }

        }


        /// <summary>
        /// Mostrar la informaci�n de pago
        /// </summary>
        private void MostrarRespuestaPago()
        {
            SILPA.AccesoDatos.Generico.ParametroDalc objParametroDalc = null;
            SILPA.AccesoDatos.Generico.ParametroEntity objParametro = null;
            SILPA.AccesoDatos.Generico.ParametroEntity objParametro2 = null;
            Cobro objCobro = null;
            TransaccionPSEIdentity objTransaccionPSEIdentity = null;


            //Validar que el objeto de cobro no se encuentre nulo
            if (this._objCobroIdentity != null)
            {
                //Consultar parametros
                objParametroDalc = new SILPA.AccesoDatos.Generico.ParametroDalc();
                objParametro = new SILPA.AccesoDatos.Generico.ParametroEntity();
                objParametro2 = new SILPA.AccesoDatos.Generico.ParametroEntity();
                objParametro.IdParametro = -1;
                objParametro2.IdParametro = -1;
                objParametro.NombreParametro = "Mensaje_Error_Pago";
                objParametro2.NombreParametro = "Mensaje_Pago_Pendiente";
                objParametroDalc.obtenerParametros(ref objParametro);
                objParametroDalc.obtenerParametros(ref objParametro2);

                if (this._LogInformativoActivo)
                    SMLog.Escribir(Severidad.Informativo, "Pago: Consultar informaci�n de la transacci�n: " + this._TrazabilityCode);

                //Cosnultar informacion de transaccion
                objCobro = new Cobro();
                objTransaccionPSEIdentity = objCobro.ConsultarInformacionTransaccion(Convert.ToInt64(this._TrazabilityCode));

                if (objTransaccionPSEIdentity != null)
                {
                    if (this._LogInformativoActivo)
                        SMLog.Escribir(Severidad.Informativo, "Pago: Inicio escribir resultado con datos registro local");

                    //Cargar informaci�n de acuerdo a resultado
                    if (objTransaccionPSEIdentity.Estado == (int)CobroEstados.OK)
                    {
                        //Cargar datos de resultado
                        this.lblValorEstado.Text = "Transacci�n Aprobada";
                        this.btnRegresar.Visible = true;
                        this.btnVerHistorico.Visible = false;
                        this.btnRegresar.Text = "Finalizar Transacci�n";
                        this.dvObservacion.Visible = false;
                        this.hdfNombreEstado.Value = "OK";
                    }
                    else if (objTransaccionPSEIdentity.Estado == (int)CobroEstados.PENDING)
                    {

                        //Cargar datos de resultado
                        this.lblValorEstado.Text = "Transacci�n Pendiente";
                        this.btnRegresar.Visible = true;
                        this.btnVerHistorico.Visible = true;
                        this.btnRegresar.Text = "Salir";
                        this.dvObservacion.Visible = true;
                        this.lblObservacion.Text = objParametro2.Parametro.ToString().Replace("{INFO}", objParametro.Parametro).Replace("{REF}", this._TicketId).Replace("{CUS}", this._TrazabilityCode) + ".<br /><br />Por favor verificar si el d�bito fue realizado en el Banco";
                        this.dvValorEstado.Attributes.Clear();
                        this.dvValorObservacion.Attributes.Clear();
                        this.dvValorEstado.Attributes.Add("class", "CellFormularioPagoDatosError");
                        this.dvValorObservacion.Attributes.Add("class", "CellFormularioPagoDatosError");
                        this.hdfNombreEstado.Value = "PENDING";
                    }
                    else if (objTransaccionPSEIdentity.Estado == (int)CobroEstados.NOT_AUTHORIZED)
                    {
                        //Cargar datos de resultado
                        this.lblValorEstado.Text = "Transacci�n Rechazada";
                        this.btnRegresar.Visible = true;
                        this.btnReintentar.Visible = true;
                        this.btnVerHistorico.Visible = false;
                        this.btnRegresar.Text = "Finalizar Transacci�n";
                        this.dvObservacion.Visible = true;
                        this.lblObservacion.Text = "La transacci�n no fue autorizada por la instituci�n financiera, " + objParametro.Parametro.ToString();
                        this.dvValorEstado.Attributes.Clear();
                        this.dvValorObservacion.Attributes.Clear();
                        this.dvValorEstado.Attributes.Add("class", "CellFormularioPagoDatosError");
                        this.dvValorObservacion.Attributes.Add("class", "CellFormularioPagoDatosError");
                        this.hdfNombreEstado.Value = "NOT_AUTHORIZED";
                    }
                    else if (objTransaccionPSEIdentity.Estado == (int)CobroEstados.FAILED)
                    {
                        //Cargar datos de resultado
                        this.lblValorEstado.Text = "Transacci�n Fallida";
                        this.btnRegresar.Visible = true;
                        this.btnReintentar.Visible = true;
                        this.btnVerHistorico.Visible = false;
                        this.btnRegresar.Text = "Finalizar Transacci�n";
                        this.dvObservacion.Visible = true;
                        this.lblObservacion.Text = "El procesamiento de la transacci�n fall�, " + objParametro.Parametro.ToString();
                        this.dvValorEstado.Attributes.Clear();
                        this.dvValorObservacion.Attributes.Clear();
                        this.dvValorEstado.Attributes.Add("class", "CellFormularioPagoDatosError");
                        this.dvValorObservacion.Attributes.Add("class", "CellFormularioPagoDatosError");
                        this.hdfNombreEstado.Value = "FAILED";
                    }

                    //Mostrar datos de la transacci�n en pantalla
                    this.lblValorTransaccion.Text = this._TrazabilityCode;
                    this.lblValorTotal.Text = objTransaccionPSEIdentity.Valor.ToString("$ #,##0.00");
                    this.lblValorFactura.Text = this._TicketId;
                    this.lblValorFecha.Text = objTransaccionPSEIdentity.FechaSolicitud.ToString("dd/MM/yyyy HH:mm");
                    this.lblDescripcion.Text = objTransaccionPSEIdentity.DescripcionTransaccion;
                    this.lblValorNit.Text = objTransaccionPSEIdentity.CodigoPSEEntidad;
                    this.lblValorRazonSocial.Text = objTransaccionPSEIdentity.RazonSocialComercio;
                    this.lblValorBanco.Text = objTransaccionPSEIdentity.Banco;
                    this.lblIpPublica.Text = objTransaccionPSEIdentity.IPTransaccion;
                }
                else
                {
                    this.MostrarMensaje("No se encontro informaci�n de la transacci�n");
                }
            }
            else
            {
                this.MostrarMensaje("No se encontro informaci�n para ser mostrada");
            }
        }


    #endregion


    #region Eventos

        /// <summary>
        /// Evento que se ejecuta al cargar la pagina. 
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar que no sea un postback
            if (!this.IsPostBack)
            {
                try
                {
                    //Cargar informacion de log
                    this.CargarInformacionLogInformativo();

                    //Inicio de consulta de transacci�n
                    if (this._LogInformativoActivo)
                        SMLog.Escribir(Severidad.Informativo, Page.AppRelativeVirtualPath.ToString() + ".Page_Load.Inicio");

                    if (this._LogInformativoActivo)
                        SMLog.Escribir(Severidad.Informativo, "Pago. Consultar CUS");

                    //Cargar trazability code
                    this.CargarTicketID();

                    if (this._LogInformativoActivo)
                        SMLog.Escribir(Severidad.Informativo, "Pago. Validar disponibilidad de la transacci�n");

                    //Verificar que la verificaci�n de datos sea valida
                    if (this.TransaccionValida())
                    {
                        //Verificar si el estado de la transaccion es pendiente para ir a verificar
                        if (this._objCobroIdentity.EstadoCobro == (int)CobroEstados.PENDING)
                        {
                            this.ConsultarInformacionTransaccion();
                        }
                        
                        this.MostrarRespuestaPago();                        
                    }
                    else
                    {
                        if (this._LogInformativoActivo)
                            SMLog.Escribir(Severidad.Informativo, "Pago. No hay disponibilidad de la transacci�n" + (!string.IsNullOrWhiteSpace(this._TrazabilityCode) ? this._TrazabilityCode : "-"));

                        //Ocultar informaci�n
                        this.divInformacionTransaccion.Visible = false;

                        //Mostrar mensaje
                        this.MostrarMensaje("Informaci�n de transacci�n no disponible. Comunicarse con el administrador del sistema para validar el resultado de la transacci�n");

                        //Escribir log
                        SMLog.Escribir(Severidad.Critico, "PagoElectronico_InformacionTransaccion :: Pago: Consulta de transacci�n vencida o no existente. TrazabilityCode: " + (!string.IsNullOrWhiteSpace(this._TrazabilityCode) ? this._TrazabilityCode : "-" ));
                    }

                }
                catch (Exception exc)
                {

                    //Mostrar mensaje
                    this.MostrarMensaje("Se presento error durante la verificaci�n de informaci�n de la transacci�n");

                    //Escribir log
                    SMLog.Escribir(Severidad.Critico, "PagoElectronico_InformacionTransaccion :: Pago: Error Cargo de Informaci�n " + exc.StackTrace.ToString());
                }
            }
        }


        /// <summary>
        /// Evento que cierra pagina y recarga datos de tareas
        /// </summary>
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                //Eliminar datos
                Session["TicketID"] = null;
                Session["Amount"] = null;
                Session["ServiceCode"] = null;
                Session["VATAmount"] = null;
                Session["PaymentDescription"] = null;
                Session["ReferenceNumber1"] = null;
                Session["ReferenceNumber2"] = null;
                Session["ReferenceNumber3"] = null;
                Session["NumeroSilpa"] = null;
                Session["PpeCertificateSubject"] = null;
                Session["PpeUrl"] = null;
                Session["PpeCode"] = null;
                Session["RazonSocial"] = null;
                Session["EstadoPSE"] = null;
                Session["TransaccionPSE"] = null;
                Session["TrazabilityCode"] = null;

                //Cerrar ventana
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "cerrarVentana();", true);
            }
            catch (Exception ex)
            {
                SMLog.Escribir(ex);
                Mensaje.MostrarMensaje(this.Page, "Excepci�n generada por el c�digo del aplicativo implementado por la entidad");
            }
        }


        /// <summary>
        /// Evento que redirecciona a p�gina para reintentar pago
        /// </summary>
        protected void btnReintentar_Click(object sender, EventArgs e)
        {
            //Eliminar datos
            Session["TicketID"] = null;
            Session["Amount"] = null;
            Session["ServiceCode"] = null;
            Session["VATAmount"] = null;
            Session["PaymentDescription"] = null;
            Session["ReferenceNumber1"] = null;
            Session["ReferenceNumber2"] = null;
            Session["ReferenceNumber3"] = null;
            Session["NumeroSilpa"] = null;
            Session["PpeCertificateSubject"] = null;
            Session["PpeUrl"] = null;
            Session["PpeCode"] = null;
            Session["RazonSocial"] = null;
            Session["EstadoPSE"] = null;
            Session["TransaccionPSE"] = null;
            Session["TrazabilityCode"] = null;

            //Redireccionar a formulario de pago
            if (Session["IDProcessInstance"] !=  null)
                Response.Redirect("~/PermisosAmbientales/Liquidacion/FormularioPago.aspx?IDProcessInstance=" + Session["IDProcessInstance"]);
            else if(Session["CobroSolicitudLiquidacionPSEID"] != null)
                Response.Redirect("~/PermisosAmbientales/Liquidacion/FormularioPagoAutoliquidacion.aspx?AL=" + Session["CobroSolicitudLiquidacionPSEID"]);
            
        }

        /// <summary>
        /// Evento que redirecciona al historico de pagos
        /// </summary>
        protected void btnVerHistorico_Click(object sender, EventArgs e)
        {
            
            //Eliminar datos
            Session["TicketID"] = null;
            Session["Amount"] = null;
            Session["ServiceCode"] = null;
            Session["VATAmount"] = null;
            Session["PaymentDescription"] = null;
            Session["ReferenceNumber1"] = null;
            Session["ReferenceNumber2"] = null;
            Session["ReferenceNumber3"] = null;
            Session["NumeroSilpa"] = null;
            Session["PpeCertificateSubject"] = null;
            Session["PpeUrl"] = null;
            Session["PpeCode"] = null;
            Session["RazonSocial"] = null;
            Session["EstadoPSE"] = null;
            Session["TransaccionPSE"] = null;
            
            //Redireccionar a pagina de historicos
            Response.Redirect("HistoricoTransacciones.aspx");
            
        }

    #endregion


        
}
