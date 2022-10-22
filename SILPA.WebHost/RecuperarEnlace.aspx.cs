using SILPA.AccesoDatos.Usuario;
using SILPA.Comun;
using SILPA.LogicaNegocio.Usuario;
using SoftManagement.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SILPA.LogicaNegocio.Generico;
using SILPA.AccesoDatos.Generico;

public partial class RecuperarEnlace : System.Web.UI.Page
{
    #region Objetos

        /// <summary>
        /// Indica si se debe validar el recaptcha
        /// </summary>
        protected string ValidarRecaptcha { get; set; }

    #endregion

    #region Metodos

        /// <summary>
        /// Inicializa la página
        /// </summary>
        private void InicializarPagina()
        {
            this.txtNumeroIdentificacion.Text = "";
        }

        /// <summary>
        /// Genera link de acceso para activación de la clave
        /// </summary>
        /// <returns>string con el link de acceso</returns>
        private string GenerarLinkActivacionUsuario(long p_lngPersonaID, string p_strNumeroDocumento)
        {
            string strEnlace = "";
            int intTiempoVigenciaEnlace = 0;
            string strLlave = "";
            SILPA.LogicaNegocio.Parametrizacion.Parametrizacion objParametrizacion = null;
            EnlaceActivacionUsuario objEnlaceActivacionUsuarioDalc = null;
            EnlaceActivacionUsuarioEntity objEnlace = null;

            try
            {
                //Generar llave
                strLlave = EnDecript.Encriptar(p_lngPersonaID.ToString() + "_" + p_strNumeroDocumento);

                //Obtener URL
                objParametrizacion = new SILPA.LogicaNegocio.Parametrizacion.Parametrizacion();
                strEnlace = objParametrizacion.ObtenerValorParametroGeneral(-1, "URL_CONFIRMACION_CORREO_REGISTRO") + HttpUtility.UrlEncode(strLlave) + "&Us=" + HttpUtility.UrlEncode(EnDecript.Encriptar(p_lngPersonaID.ToString())) + "&Id=" + HttpUtility.UrlEncode(EnDecript.Encriptar(p_strNumeroDocumento));
                intTiempoVigenciaEnlace = Convert.ToInt32(objParametrizacion.ObtenerValorParametroGeneral(-1, "TIEMPO_VIGENCIA_ENLACE_ACTIVACION_USUARIO"));

                //Insertar datos de URL
                objEnlace = new EnlaceActivacionUsuarioEntity
                {
                    PersonaID = p_lngPersonaID,
                    NumeroIdentificacion = p_strNumeroDocumento,
                    Llave = strLlave,
                    FechaVigencia = DateTime.Now.AddMinutes(intTiempoVigenciaEnlace),
                    FechaUtilizacion = default(DateTime)
                };
                objEnlaceActivacionUsuarioDalc = new EnlaceActivacionUsuario();
                objEnlaceActivacionUsuarioDalc.CrearEnlace(objEnlace);

            }
            catch (Exception exc)
            {
                //Escribir error
                SMLog.Escribir(Severidad.Critico, "RecuperarEnlace :: GenerarLinkActivacionUsuario -> Error Generando Link Activacion: " + exc.Message);

                throw exc;
            }

            return strEnlace;
        }

        /// <summary>
        /// Regenera el link y lo envía por correo al usuario
        /// </summary>
        /// <param name="p_objPersonaIdentity">PersonaIdentity con la información de la persona</param>
        private void RegenerarEnlacePersona(PersonaIdentity p_objPersonaIdentity)
        {
            EnlaceActivacionUsuario objEnlaceActivacionUsuarioDalc;
            EnlaceActivacionUsuarioEntity objEnlace;
            string strLinkActivacion;

            objEnlaceActivacionUsuarioDalc = new EnlaceActivacionUsuario();
            objEnlace = objEnlaceActivacionUsuarioDalc.ConsultarEnlace(null, -1, txtNumeroIdentificacion.Text.Trim());

            //Inactivar enlace
            if (objEnlace != null)
            {
                objEnlace.Activo = false;
                objEnlace.FechaUtilizacion = DateTime.Now;
                objEnlaceActivacionUsuarioDalc.EditarEnlace(objEnlace);
            }

            //Obtener autoridad ambiental relacionada al usuario
            AutoridadAmbiental objAutoridadAmbiental = new AutoridadAmbiental();
            objAutoridadAmbiental.ObtenerAutoridadAmbiental(p_objPersonaIdentity.IdAutoridadAmbiental);

            //Crear y enviar link
            strLinkActivacion = this.GenerarLinkActivacionUsuario(p_objPersonaIdentity.PersonaId, p_objPersonaIdentity.NumeroIdentificacion);
            SILPA.LogicaNegocio.ICorreo.Correo.EnviarCorreoConfirmacionCorreo(p_objPersonaIdentity.CorreoElectronico, p_objPersonaIdentity.NumeroIdentificacion, p_objPersonaIdentity.PrimerNombre, strLinkActivacion, objAutoridadAmbiental.objAutoridadIdentity.Nombre);
        }


        /// <summary>
        /// Enmascara el correo
        /// </summary>
        /// <param name="p_strCorreo">string con la dirección de correo</param>
        /// <returns>string con el correo enmascarado</returns>
        private string MascaraCorreo(string p_strCorreo)
        {
            string strMascara = "";
            string[] strLstSeparar1 = p_strCorreo.Split('@');
            string[] strLstSeparar2 = (strLstSeparar1.Length >= 2 ? strLstSeparar1[1].Split('.') : new string[]{""});
            string strParteInicial = (strLstSeparar1.Length >= 2 ? strLstSeparar1[0] : "");
            string strDominio = strLstSeparar2[0];
            int intVisibleInicio = strParteInicial.Length - 2;
            int intVisibleDominio = strDominio.Length - 2;

            strMascara = strParteInicial.Remove(1, intVisibleInicio).Insert(1, new string('*', intVisibleInicio));
            strMascara += "@" + strDominio.Remove(1, intVisibleDominio).Insert(1, new string('*', intVisibleDominio));
            for(int intCont = 1; intCont < strLstSeparar2.Length; intCont++)
                strMascara += "." + strLstSeparar2[intCont];

            return strMascara;
        }


        /// <summary>
        /// Enviar nuevo enlace
        /// </summary>
        private void EnviarEnlace()
        {
            bool blnCaptchaValido;
            int intEstado = 0;
            Persona objPersona;
            PersonaDalc objPersonaDalc;            

            try
            {
                //Verificar que el captcha se encuentre bien
                blnCaptchaValido = Recaptcha.Validar(Request.Form["g-Recaptcha-Response"]);
                if (blnCaptchaValido)
                {
                    objPersona = new Persona();
                    intEstado = objPersona.VerificarExistenciaByNumeroIdentificacion(txtNumeroIdentificacion.Text.Trim());

                    if (intEstado == (int)SILPA.Comun.EstadoSolicitudCredencial.EnProceso || intEstado == (int)SILPA.Comun.EstadoSolicitudCredencial.Aprobado)
                    {
                        //Consultar la persona
                        objPersonaDalc = new PersonaDalc();
                        objPersona.PersonaPorNumeroIdentificacion(txtNumeroIdentificacion.Text.Trim(), -1);

                        if (objPersona.Identity.PersonaId > 0  && intEstado == (int)SILPA.Comun.EstadoSolicitudCredencial.Aprobado)
                        {
                            //verificar si el usuario se encuentra activo
                            if (!objPersona.Identity.Activo)
                            {
                                this.RegenerarEnlacePersona(objPersona.Identity);

                                //Cargar mensaje de ok
                                this.ltlMensajeResultadoOK.Text = "Al correo electrónico " + this.MascaraCorreo(objPersona.Identity.CorreoElectronico) + " fue enviado el enlace para activación de la cuenta de usuario.";
                                this.mpeModalResultadoDatosPersona.Show();
                            }
                            else
                            {
                                this.ltlMensajeAdvertencia.Text = "El usuario se encuentra aprobado y activo en el sistema. Si olvido su contraseña debe ingresar por la opción \"Recordar contraseña\".";
                                this.upnlAdvertenciaRecuperar.Update();
                                this.mpeAdvertenciaRecuperar.Show();
                            }
                        }
                        else if (objPersona.Identity.PersonaId > 0)
                        {
                            this.RegenerarEnlacePersona(objPersona.Identity);

                            //Cargar mensaje de ok
                            this.ltlMensajeResultadoOK.Text = "Al correo electrónico " + this.MascaraCorreo(objPersona.Identity.CorreoElectronico) + " fue enviado el enlace para activación de la cuenta de usuario.";
                            this.mpeModalResultadoDatosPersona.Show();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msgBox", "<script>alert('El usuario no se encuentra registrado en el sistema, por favor verifique los datos y trate nuevamente.')</script>"); 
                        }
                    }
                    else if (intEstado == (int)SILPA.Comun.EstadoSolicitudCredencial.NoExiste)
                    {
                        Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msgBox", "<script>alert('El usuario no se encuentra registrado en el sistema, por favor verifique los datos y trate nuevamente.')</script>");                        
                    }
                    else if (intEstado == (int)SILPA.Comun.EstadoSolicitudCredencial.Rechazado)
                    {
                        Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msgBox", "<script>alert('El usuario fue rechazado por parte de la autoridad ambiental. Para acceder a VITAL debe realizar el registro nuevamente.')</script>");                        
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msgBox", "<script>alert('Verificación de captcha es incorrecto, por favor trate nuevamente')</script>");
                }
            }
            catch (Exception exc)
            {
                //Escribir error
                SMLog.Escribir(Severidad.Critico, "RecuperarEnlace :: EnviarEnlace -> Error en proceso de reenvío de enlace: " + exc.Message);

                throw exc;
            }
        }
        

    #endregion


    #region Eventos

        /// <summary>
        /// 
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    this.InicializarPagina();
                }
            }
            catch (Exception exc)
            {
                //Escribir error
                SMLog.Escribir(Severidad.Critico, "RecuperarEnlace :: Page_Load -> Error Inesperado: " + exc.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PopupScript", "alert('Se presento un problema cargando la información de la página');", true);
            }
        }

        /// <summary>
        /// Evento que efectua el envío del nuevo enlace
        /// </summary>
        protected void cmdRestablecer_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    this.EnviarEnlace();
                }
            }
            catch (Exception exc)
            {
                //Escribir error
                SMLog.Escribir(Severidad.Critico, "RecuperarEnlace :: cmdRestablecer_Click -> Error Inesperado: " + exc.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PopupScript", "alert('Se presento un problema durante el proceso de envío de nuevo enlace');", true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void cmdCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.InicializarPagina();
                Response.Redirect("DatosPersonales.aspx", false);
            }
            catch (Exception exc)
            {
                //Escribir error
                SMLog.Escribir(Severidad.Critico, "RecuperarEnlace :: cmdCancelar_Click -> Error Inesperado: " + exc.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PopupScript", "alert('Se presento un problema cancelando proceso');", true);
            }
        }


        /// <summary>
        /// Evento que cierra modal y direcciona a la página principal
        /// </summary>
        protected void cmdAceptarResultadoDatosPersona_Click(object sender, EventArgs e)
        {
            try
            {
                //Redirecciona a la ventana principal    
                this.InicializarPagina();
                Response.Redirect("DatosPersonales.aspx", false);
            }
            catch (Exception ex)
            {
                //Escribir error
                SMLog.Escribir(Severidad.Critico, "RecuperarEnlace :: cmdAceptarResultadoDatosPersona_Click -> Error Inesperado: " + ex.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PopupScript", "alert('Se presento un problema retornando a página de registro');", true);
            }
            finally
            {
                this.InicializarPagina();
                this.ltlMensajeResultadoOK.Text = "";
                this.upnlModalResultadoDatosPersona.Update();
                this.upnlEnlace.Update();
            }
        }

        /// <summary>
        /// Evento que cierra modal
        /// </summary>
        protected void cmdAceptarAdvertencia_Click(object sender, EventArgs e)
        {
            try
            {
                this.InicializarPagina();
                this.upnlEnlace.Update();
                this.ltlMensajeAdvertencia.Text = "";
                this.upnlAdvertenciaRecuperar.Update();
                this.mpeAdvertenciaRecuperar.Hide();
            }
            catch (Exception exc)
            {
                //Escribir error
                SMLog.Escribir(Severidad.Critico, "RecuperarEnlace :: cmdAceptarAdvertencia_Click -> Error Inesperado: " + exc.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PopupScript", "alert('Se presento un problema cerrando modal');", true);
            }
        }

        /// <summary>
        /// Evento cierra modal y direcciona a recuperar contraseña
        /// </summary>
        protected void cmdRecuperarContrasenaAdvertencia_Click(object sender, EventArgs e)
        {
            try
            {
                this.InicializarPagina();
                this.upnlEnlace.Update();
                this.ltlMensajeAdvertencia.Text = "";
                this.upnlAdvertenciaRecuperar.Update();
                this.mpeAdvertenciaRecuperar.Hide();
                Response.Redirect("ReestablecerClave.aspx", false);
            }
            catch (Exception exc)
            {
                //Escribir error
                SMLog.Escribir(Severidad.Critico, "RecuperarEnlace :: cmdRecuperarContrasenaAdvertencia_Click -> Error Inesperado: " + exc.StackTrace);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "PopupScript", "alert('Se presento un problema direccionando a recuperación de contraseña');", true);
            }
        }
    #endregion



        
}