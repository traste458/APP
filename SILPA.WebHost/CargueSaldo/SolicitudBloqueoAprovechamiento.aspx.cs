using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SILPA.LogicaNegocio.REDDS;
using SILPA.LogicaNegocio.Generico;
using System.Configuration;
using SILPA.AccesoDatos.BPMProcess;
using System.IO;
using System.Xml.Serialization;
using System.Data;
using SILPA.LogicaNegocio.Salvoconducto;
using SILPA.LogicaNegocio.Aprovechamiento;
using SILPA.AccesoDatos.Generico;
using SILPA.AccesoDatos.Aprovechamiento;
using AjaxControlToolkit;
using SILPA.AccesoDatos.RegistroMinero;
using System.Globalization;
using SILPA.Comun;



public partial class CargueSaldo_SolicitudBloqueoAprovechamiento : System.Web.UI.Page
{
    public bool usuarioAdministradorSUNL
    {
        get { return Convert.ToBoolean(ViewState["usuarioAdministradorSUNL"].ToString()); }
        set { ViewState["usuarioAdministradorSUNL"] = value; }
    }

    public int autID
    {
        get { return Convert.ToInt32(ViewState["autID"].ToString()); }
        set { ViewState["autID"] = value; }
    }

    public int Accion
    {
        get { return Convert.ToInt32(ViewState["Accion"].ToString()); }
        set { ViewState["Accion"] = value; }
    }
    public bool UsuarioAA
    {
        get { return Convert.ToBoolean(ViewState["UsuarioAA"].ToString()); }
        set { ViewState["UsuarioAA"] = value; }
    }

    public string NumeroActoAdministrativo
    {
        get { return ViewState["NumeroActoAdministrativo"].ToString(); }
        set { ViewState["NumeroActoAdministrativo"] = value; }
    }

    private String AprovechamientoID
    {
        get { return ViewState["AprovechamientoID"].ToString(); }
        set { ViewState["AprovechamientoID"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        #region recibir parámetros de url
        if (Request.QueryString["enc"] != null && Request.QueryString["enc"].ToString() != "")
        {
            #region obtengo el valor de cada uno de los parámetros [modo: encriptado]
            string encryptedQueryString = Request.QueryString["enc"].Replace(" ", "+");
            string decryptedQueryString = Utilidades.Decrypt(encryptedQueryString);
            string[] QueryStringParameters = decryptedQueryString.Split(new char[] { '&' });

            AprovechamientoID = QueryStringParameters[0].Substring(QueryStringParameters[0].IndexOf("=") + 1);

            #endregion

            #region carga inro_odtial del formulario [modo: encriptado]
            if (!Page.IsPostBack)
            {
                #region deshabilitar boton atras navegador
                Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                Response.Cache.SetAllowResponseInBrowserHistory(false);
                Response.Cache.SetNoStore();
                #endregion

                //Session["Usuario"] = 32439; //Mads
                //Session["Usuario"] = 36316; //Auoridad ambiental
                //ConsultarEstadoAprovechamiento(Convert.ToInt32(AprovechamientoID));
                //return;

                //Session["Usuario"] = 22363;
                if (new Utilidades().ValidacionToken() == false)
                {
                    Response.Redirect(@"..\Utilitario\MensajeValidacion.aspx");
                }
                else
                {
                    #region recepción de parámetros [modo: encriptado]
                    if (!String.IsNullOrEmpty(AprovechamientoID))
                    {
                        //ejecutar métodos normales de tu formulario
                        ConsultarEstadoAprovechamiento(Convert.ToInt32(AprovechamientoID));
                    }
                    else
                    {
                        #region redirijo al usuario a la página de Login
                        string _strPagina = "window.top.location.href='../Utilitario/MensajeValidacion.aspx'";
                        Utilidades.AlertWindow(this.Page, "", _strPagina, (int)Utilidades._modo_apertura_formulario.ejecutarScript);
                        #endregion
                    }
                    #endregion
                }
                #endregion
            }
        }
        else if (Request.QueryString["AprovechamientoID"] != null)
        {
            #region carga inro_odtial del formulario [modo: normal]
            if (!Page.IsPostBack)
            {
                #region deshabilitar boton atras navegador
                Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                Response.Cache.SetAllowResponseInBrowserHistory(false);
                Response.Cache.SetNoStore();
                #endregion
                if (new Utilidades().ValidacionToken() == false)
                {
                    Response.Redirect(@"..\Utilitario\MensajeValidacion.aspx");
                }
                else
                {
                    #region recepción de parámetros [modo: normal]
                    AprovechamientoID = this.Request.QueryString["AprovechamientoID"];
                    #endregion
                    //ejecutar métodos normales de tu formulario
                    ConsultarEstadoAprovechamiento(Convert.ToInt32(AprovechamientoID));
                }
            }
            #endregion
            else
            {
                #region redirijo al usuario a la página de Login
                string _strPagina = "window.top.location.href='../Utilitario/MensajeValidacion.aspx'";
                Utilidades.AlertWindow(this.Page, "", _strPagina, (int)Utilidades._modo_apertura_formulario.ejecutarScript);
                #endregion
            }
        }
        #endregion
    }

    protected void btnSolciitarBloqueo_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            GrabarSolicitudAprovechamiento();
        }
    }

    private void CargarPagina()
    {
        PersonaDalc per = new PersonaDalc();
        SILPA.LogicaNegocio.Generico.Listas _listaAutoridades = new SILPA.LogicaNegocio.Generico.Listas();
        SILPA.Comun.Configuracion _configuracion = new SILPA.Comun.Configuracion();
        Aprovechamiento vAprovechamiento = new Aprovechamiento();
        AnulacionAprovechamiento vAnulacionAprovechamiento = new AnulacionAprovechamiento();
        int autIDAux = 0;
        string autNombre = per.ObtenerAutoridadPorPersona(long.Parse(Session["Usuario"].ToString()), out autIDAux);
        autID = autIDAux;
        ClaseRecurso vClaseRecurso = new ClaseRecurso();
        //jmartinez Anulacion aprovechamientos
        usuarioAdministradorSUNL = false;
        UsuarioAA = false;
        PersonaIdentity p = new PersonaIdentity();
        p = per.BuscarPersonaByUserId(Session["Usuario"].ToString());
        SILPA.LogicaNegocio.Usuario.Usuario clsusuario = new SILPA.LogicaNegocio.Usuario.Usuario();
        DataTable dtautoridad = clsusuario.ConsultarUsuarioSistemaCompania(p.NumeroIdentificacion);
        
        var grupoMads = dtautoridad.AsEnumerable().Where(x => x.Field<string>("nombregrupo").Contains("MADS_SUNL")).ToList();
        if (grupoMads.Count > 0)
        {
            usuarioAdministradorSUNL = true;
        }

        var grupoAA = dtautoridad.AsEnumerable().Where(x => x.Field<string>("nombregrupo").Contains("CARS_SUNL")).ToList();
        if (grupoAA.Count > 0)
        {
            UsuarioAA = true;
        }
    }

    private void ConsultarEstadoAprovechamiento(int intAprovechamientoID)
    {
        CargarPagina();

        AnulacionAprovechamientosIdentity ObjAnulacionAprovechamientosIdentity = new AnulacionAprovechamientosIdentity();
        AnulacionAprovechamiento ObjAnulacionAprovechamiento = new AnulacionAprovechamiento();
        

        ObjAnulacionAprovechamientosIdentity = ObjAnulacionAprovechamiento.ConsultarEstadoAprovechamiento(intAprovechamientoID);
        NumeroActoAdministrativo = ObjAnulacionAprovechamientosIdentity.NumeroActoAdministrativo;
        Utilidades.LlenarComboLista(ObjAnulacionAprovechamiento.ObtenerMotivosAnulacionAprovechamiento(ObjAnulacionAprovechamientosIdentity.EstadoAprovechamientoID), cboMotivoBloqueoAprovechamiento, "strMotivoBloqueoAprovechamiento", "MotivoAnulacionAprovechamientoID", false);
        //usuarioAdministradorSUNL = true;
        if (UsuarioAA)
        {
            switch (ObjAnulacionAprovechamientosIdentity.EstadoAprovechamientoID)
            {
                case (int)EstadoAprovechamiento.Activo:
                    this.btnSolciitarBloqueo.Text = "Solicitar Bloqueo";
                    this.DivCargarArchivoSolBloqueo.Visible = true;
                    Accion = Convert.ToInt32(AccionAprovechamientos.SolicitarBloqueo);
                    this.trDescripcionBloqueo.Visible = true;
                    break;

                case (int)EstadoAprovechamiento.Anulado:
                    this.btnSolciitarBloqueo.Text = "Solicitar Desbloqueo";
                    this.DivCargarArchivoSolBloqueo.Visible = true;
                    Accion = Convert.ToInt32(AccionAprovechamientos.SolicitudDesbloqueo);
                    this.trDescripcionBloqueo.Visible = true;
                    break;

                case (int)EstadoAprovechamiento.Bloqueado:
                    this.btnSolciitarBloqueo.Text = "Solicitar Desbloqueo";
                    DivCargarArchivoSolBloqueo.Visible = true;
                    Accion = Convert.ToInt32(AccionAprovechamientos.SolicitudDesbloqueo);
                    this.trDescripcionBloqueo.Visible = true;
                    break;

                case (int)EstadoAprovechamiento.SolicitudAnulacion:
                    DivCargarArchivoSolBloqueo.Visible = false;
                    this.btnSolciitarBloqueo.Text = "Deshacer Solicitud Anulacion";
                    Accion = Convert.ToInt32(AccionAprovechamientos.DeshacerSolicitudBloqueo);
                   this.RFVDescricionSolicitud.Enabled = false;
                    this.trDocumentoSoporteSolicitud.Visible = false;
                    this.trDescripcionBloqueo.Visible = false;
                    break;

                case (int)EstadoAprovechamiento.SolicitudBloqueo:
                    DivCargarArchivoSolBloqueo.Visible = false;
                    this.btnSolciitarBloqueo.Text = "Deshacer Solicitud Anulacion";
                    Accion = Convert.ToInt32(AccionAprovechamientos.DeshacerSolicitudBloqueo);
                    this.RFVDescricionSolicitud.Enabled = false;
                    this.trDocumentoSoporteSolicitud.Visible = false;
                    this.trDescripcionBloqueo.Visible = false;
                    break;

                case (int)EstadoAprovechamiento.SolicitudDesbloqueo:
                    this.btnSolciitarBloqueo.Text = "Deshacer Solicitud Desbloqueo";
                    this.DivCargarArchivoSolBloqueo.Visible = false;
                    Accion = Convert.ToInt32(AccionAprovechamientos.DeshacerSolicitudDesbloqueo);
                    this.trDocumentoSoporteSolicitud.Visible = false;
                    this.RFVDescricionSolicitud.Enabled = false;
                    this.trDescripcionBloqueo.Visible = false;
                    break;
            }
        }
        else if (usuarioAdministradorSUNL)
        {
            Response.Redirect(@"..\Utilitario\MensajeValidacion.aspx");
        }
    }

    protected void GrabarSolicitudAprovechamiento()
    {
        string rutaArchivo = string.Empty;
        string Respuesta = string.Empty;
        string DescripcionMotivoAprovechamiento = string.Empty;
        AnulacionAprovechamientosIdentity ObjAnulacionAprovechamientosIdentity = new AnulacionAprovechamientosIdentity();
        AnulacionAprovechamiento ObjAnulacionAprovechamiento = new AnulacionAprovechamiento();

        switch (Accion)
        {
            case (int)AccionAprovechamientos.DeshacerSolicitudBloqueo:
            case (int)AccionAprovechamientos.DeshacerSolicitudDesbloqueo:

                if (Accion == (int)AccionAprovechamientos.DeshacerSolicitudBloqueo)
                {
                    DescripcionMotivoAprovechamiento = "Se deshace Solicitud de bloqueo por parte del usuario de la autoridad ambiental";
                }


                if (Accion == (int)AccionAprovechamientos.DeshacerSolicitudDesbloqueo)
                {
                    DescripcionMotivoAprovechamiento = "Se deshace Solicitud de desbloqueo por parte del usuario de la autoridad ambiental";
                }



                rutaArchivo = string.Empty;
                ObjAnulacionAprovechamientosIdentity.AprovechamientoID = Convert.ToInt32(AprovechamientoID);
                ObjAnulacionAprovechamientosIdentity.MotivobloqueoID = Convert.ToInt32(this.cboMotivoBloqueoAprovechamiento.SelectedValue);
                ObjAnulacionAprovechamientosIdentity.strDescripcion = DescripcionMotivoAprovechamiento;
                ObjAnulacionAprovechamientosIdentity.AutID = autID;
                ObjAnulacionAprovechamientosIdentity.SolID = long.Parse(Session["Usuario"].ToString());
                ObjAnulacionAprovechamientosIdentity.Accion = Accion;
                ObjAnulacionAprovechamientosIdentity.strRutaArchivo = rutaArchivo;
                ObjAnulacionAprovechamientosIdentity.NumeroActoAdministrativo = NumeroActoAdministrativo;
                Respuesta = ObjAnulacionAprovechamiento.InsertarEstadoAnulacionAprovechamiento(ObjAnulacionAprovechamientosIdentity);
                if (!string.IsNullOrEmpty(Respuesta))
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "<script>alert('" + Respuesta + "')</script>", false);
                }
                else
                {
                    Redireccionar(Convert.ToInt32(AprovechamientoID));
                }

                break;

            default:
                if (!string.IsNullOrEmpty(this.fuplActoAdministrativo.FileName) && this.lnkAdicionarArchivo.Visible == true)
                {
                    FileInfo fi = new FileInfo(this.fuplActoAdministrativo.FileName);

                    if (!fi.ToString().ToUpper().Contains(".PDF"))
                    {
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "<script>alert('La extension del archivo de soporte para esta solicitud debe ser PDF')</script>", false);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "<script>alert('Debe cargar un archivo de soporte en formato PDF para la solicitud')</script>", false);
                    return;
                }


                if (fuplActoAdministrativo.PostedFile != null)
                {
                    ObjAnulacionAprovechamientosIdentity.AprovechamientoID = Convert.ToInt32(AprovechamientoID);
                    ObjAnulacionAprovechamientosIdentity.MotivobloqueoID = Convert.ToInt32(this.cboMotivoBloqueoAprovechamiento.SelectedValue);
                    ObjAnulacionAprovechamientosIdentity.strDescripcion = this.txtDescripcionBloqueoAprov.Text;
                    ObjAnulacionAprovechamientosIdentity.AutID = autID;
                    ObjAnulacionAprovechamientosIdentity.SolID = long.Parse(Session["Usuario"].ToString());
                    ObjAnulacionAprovechamientosIdentity.Accion = Accion;
                    ObjAnulacionAprovechamientosIdentity.NumeroActoAdministrativo = NumeroActoAdministrativo;
                    rutaArchivo = ConfigurationManager.AppSettings["DireccionFus"] + @"AnulacionAprovechamiento\";
                    if (!Directory.Exists(rutaArchivo + ObjAnulacionAprovechamientosIdentity.AprovechamientoID))
                        Directory.CreateDirectory(rutaArchivo + ObjAnulacionAprovechamientosIdentity.AprovechamientoID);

                    rutaArchivo = rutaArchivo + ObjAnulacionAprovechamientosIdentity.AprovechamientoID + "\\" + Session["Usuario"].ToString() + "-" + Accion + "-" + fuplActoAdministrativo.FileName;
                    fuplActoAdministrativo.SaveAs(rutaArchivo);
                    ObjAnulacionAprovechamientosIdentity.strRutaArchivo = rutaArchivo;

                    Respuesta = ObjAnulacionAprovechamiento.InsertarEstadoAnulacionAprovechamiento(ObjAnulacionAprovechamientosIdentity);

                    if (!string.IsNullOrEmpty(Respuesta))
                    {
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "<script>alert('" + Respuesta + "')</script>", false);
                    }
                    else
                    {
                        Redireccionar(Convert.ToInt32(AprovechamientoID));
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "script", "<script>alert('Debe seleccionar un archivo en donde se soporte la solicitud')</script>", false);
                }
                break;
        }
    }

    protected void Redireccionar(int AprovechamientoID)
    {
        string parametros = "AprovechamientoID=" + Convert.ToString(AprovechamientoID) + "&BloqueoSalvoConducto = false"; ;
        string query = Utilidades.Encrypt(parametros);
        string queryEncriptado = "../Salvoconducto/ConsultaDetalleAprovechamiento.aspx" + query;
        Response.Redirect(queryEncriptado);
    }

    protected void lnkCancelarArchivo_Click(object sender, EventArgs e)
    {
        AsyncFileUpload objFileUpload = null;
        Label objLabel = null;
        LinkButton objLinkAdicionar = null;
        LinkButton objLinkCancelar = null;
        HyperLink objLinkVerArchivo = null;

        try
        {
            //Cargar controles de la fila
            objFileUpload = fuplActoAdministrativo;
            objLinkAdicionar = lnkAdicionarArchivo;
            objLinkCancelar = lnkCancelarArchivo;
            objLinkVerArchivo = lnkVerArchivo;
            objLabel = lblArchivo;
            //Mostrar y ocultar controles                    
            if (objFileUpload.HasFile)
            {
                objFileUpload.Visible = false;
                objLabel.Visible = true;
                objLabel.Text = objFileUpload.FileName;
                objLinkAdicionar.Visible = true;
                objLinkCancelar.Visible = false;
                objLinkCancelar.Text = "Cancelar";
                if (objLinkVerArchivo != null)
                {
                    objLinkVerArchivo.Visible = false;
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(objLinkCancelar.Text))
                {
                    objFileUpload.Visible = false;
                    objLabel.Visible = true;
                    objLinkAdicionar.Visible = true;
                    objLinkCancelar.Visible = false;
                    objLinkCancelar.Text = "Cancelar";
                    if (objLinkVerArchivo != null)
                    {
                        objLinkVerArchivo.Visible = true;
                    }
                }
                else
                {
                    objFileUpload.Visible = true;
                    objLabel.Visible = false;
                    objLinkAdicionar.Visible = false;
                    objLinkCancelar.Visible = false;
                    if (objLinkVerArchivo != null)
                    {
                        objLinkVerArchivo.Visible = false;
                    }
                }
            }
        }
        catch (Exception exc)
        {
            //Escribir error
            //SMLog.Escribir(Severidad.Critico, "PDV_CrearCertificado :: lnkCancelarArchivo_Click -> Error Inesperado: " + exc.Message + " " + exc.StackTrace);

            ////Cargar mensaje de error                        
            //this.MostrarMensaje("Se genero un error cancelando adjuntar archivo. Si el error sigue presentandose por favor comunicarse con el Administrador del Sistema");
        }
        finally
        {
            //Regenerar listados
            //RecargarListados();
        }
    }

    protected void lnkArchivoSolicitud_Click(object sender, EventArgs e)
    {
        if (((LinkButton)sender).CommandArgument != null)
        {
            System.IO.FileInfo targetFile = new System.IO.FileInfo(((LinkButton)sender).CommandArgument.ToString());
            this.Response.Clear();
            this.Response.AddHeader("Content-Disposition", "attachment; filename=" + targetFile.Name);
            this.Response.AddHeader("Content-Length", targetFile.Length.ToString());
            this.Response.ContentType = "application/octet-stream";
            this.Response.ContentType = "application/base64";
            this.Response.WriteFile(targetFile.FullName);
            this.Response.WriteFile(((LinkButton)sender).CommandArgument.ToString());
        }
    }


    protected void lnkAdicionarArchivo_Click(object sender, EventArgs e)
    {
        AsyncFileUpload objFileUpload = null;
        Label objLabel = null;
        LinkButton objLinkAdicionar = null;
        LinkButton objLinkCancelar = null;
        HyperLink objLinkVerArchivo = null;

        try
        {
            //Cargar controles de la fila
            objFileUpload = fuplActoAdministrativo;
            objLinkAdicionar = lnkAdicionarArchivo;
            objLinkCancelar = lnkCancelarArchivo;
            objLinkVerArchivo = lnkVerArchivo;
            objLabel = lblArchivo;

            //Mostrar y ocultar controles
            objFileUpload.Visible = true;
            objLabel.Visible = false;
            objLinkAdicionar.Visible = false;
            objLinkCancelar.Visible = true;
            objLinkCancelar.Text = "Cancelar";

            //Ocultar boton de ver archivo
            if (objLinkVerArchivo != null)
            {
                objLinkVerArchivo.Visible = false;
            }
        }
        catch (Exception exc)
        {
            ////Escribir error
            //SMLog.Escribir(Severidad.Critico, "PDV_CrearCertificado :: lnkAdicionarArchivo_Click -> Error Inesperado: " + exc.Message + " " + exc.StackTrace);

            ////Cargar mensaje de error                        
            //this.MostrarMensaje("Se genero un error habilitando adición de archivo. Si el error sigue presentandose por favor comunicarse con el Administrador del Sistema");
        }
        finally
        {
            //Regenerar listados
            //RecargarListados();
        }
    }

    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        Redireccionar(Convert.ToInt32(AprovechamientoID));
    }
}