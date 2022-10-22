﻿using System;
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

public partial class ConsultaDetalleAprovechamiento : System.Web.UI.Page
{
    [Serializable]
    public class Coordenada { public string Puntos { get; set; } public string Grados { get; set; } }
    private string Usuario
    {
        get { return ViewState["Usuario"].ToString(); }
        set { ViewState["Usuario"] = value; }
    }
    private String AprovechamientoID
    {
        get { return ViewState["AprovechamientoID"].ToString(); }
        set { ViewState["AprovechamientoID"] = value; }
    }

    public bool usuarioAdministradorSUNL
    {
        get { return Convert.ToBoolean(ViewState["usuarioAdministradorSUNL"].ToString()); }
        set { ViewState["usuarioAdministradorSUNL"] = value; }
    }
    public bool UsuarioAA
    {
        get { return Convert.ToBoolean(ViewState["UsuarioAA"].ToString()); }
        set { ViewState["UsuarioAA"] = value; }
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
                //CargarAprovechamiento(Convert.ToInt32(AprovechamientoID));
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
                        CargarAprovechamiento(Convert.ToInt32(AprovechamientoID));
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
                    CargarAprovechamiento(Convert.ToInt32(AprovechamientoID));
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

    public void CargarAprovechamiento(int intAprovechamientoID)
    {
        //jmartinez ajustes expedicion
        PersonaDalc per = new PersonaDalc();
        SILPA.LogicaNegocio.Generico.Listas _listaAutoridades = new SILPA.LogicaNegocio.Generico.Listas();
        SILPA.Comun.Configuracion _configuracion = new SILPA.Comun.Configuracion();
        Aprovechamiento vAprovechamiento = new Aprovechamiento();
        AnulacionAprovechamiento vAnulacionAprovechamiento = new AnulacionAprovechamiento();
        int autIDAux = 0;
        string autNombre = per.ObtenerAutoridadPorPersona(long.Parse(Session["Usuario"].ToString()), out autIDAux);
        autID = autIDAux;
        Utilidades.LlenarComboTabla(_listaAutoridades.ListarAutoridades(null).Tables[0], cboAutoridadAmbiental, "AUT_NOMBRE", "AUT_ID", true);
        ClaseRecurso vClaseRecurso = new ClaseRecurso();
        Utilidades.LlenarComboLista(vClaseRecurso.ListaClaseRecurso(),cboClaseRecurso, "ClaseRecurso", "ClaseRecursoID", true);
        Utilidades.LlenarComboLista(vAprovechamiento.ListaTipoAprovechamiento(), cboTipoAprovechamiento, "TipoAprovechamiento", "TipoAprovechamientoID", true);
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



        //jmartinez Anulacion aprovechamientos
        cboTipoAprovechamiento.SelectedValue = "1";
        cboTipoAprovechamiento.Enabled = false;
        Utilidades.LlenarComboVacio(cboClaseAprovechamiento);
        Utilidades.LlenarComboVacio(cboFormaOtorgamiento);
        Utilidades.LlenarComboVacio(cboModoAdquisicion);
        Utilidades.LlenarComboVacio(cboDepartamento);
        Utilidades.LlenarComboVacio(cboMunicipio);
        var objAprovechamiento = vAprovechamiento.ConsultaAprovechamientoXAprovechamientoId(intAprovechamientoID);
        if(objAprovechamiento != null)
        {
            this.cboAutoridadAmbiental.SelectedValue = objAprovechamiento.AutoridadEmisoraID.ToString();
            cboAutoridadAmbiental_SelectedIndexChanged(null, null);
            this.lblNumeroActoAdministrativo.Text = objAprovechamiento.Numero;
            this.lblFechaActoAdminstrativo.Text = objAprovechamiento.FechaExpedicion.Value.ToShortDateString();
            this.lblSolicitante.Text = objAprovechamiento.Solicitante.RazonSocial.ToString().Trim() != string.Empty ? objAprovechamiento.Solicitante.RazonSocial.ToString().Trim() : string.Format("{0} {1} {2} {3}", objAprovechamiento.Solicitante.PrimerNombre, objAprovechamiento.Solicitante.SegundoNombre, objAprovechamiento.Solicitante.PrimerApellido, objAprovechamiento.Solicitante.SegundoApellido);
            this.cboClaseRecurso.SelectedValue = objAprovechamiento.ClaseRecursoId.ToString();
            this.cboClaseRecurso_SelectedIndexChanged(null, null);
            this.lblAreaTotalAut.Text = objAprovechamiento.AreaTotalAutorizada.ToString();
            this.cboFormaOtorgamiento.SelectedValue = objAprovechamiento.FormatOtorgamientoID.ToString();
            this.cboFormaOtorgamiento_SelectedIndexChanged(null, null);
            this.cboModoAdquisicion.SelectedValue = objAprovechamiento.ModoAdquisicionRecursoID.ToString();
            this.cboDepartamento.SelectedValue = objAprovechamiento.DepartamentoProcedenciaID.ToString();
            this.cboDepartamento_SelectedIndexChanged(null, null);
            this.cboMunicipio.SelectedValue = objAprovechamiento.MunicipioProcedenciaID.ToString();
            this.lblCorregimiento.Text = objAprovechamiento.CorregimientoProcedencia;
            this.lblVereda.Text = objAprovechamiento.VeredaProcedencia;
            this.lblPredio.Text = objAprovechamiento.Predio;
            this.lnkArchivo.CommandArgument = objAprovechamiento.RutaArchivo;
            this.gdvEspecimenes.DataSource = objAprovechamiento.LstEspecies;
            //jmartinez salvoconducto fase 2
            this.LblFechaFinalizacionActoAdministrativo.Text = objAprovechamiento.FechaFinalizacion != null? objAprovechamiento.FechaFinalizacion.Value.ToShortDateString(): "";
            TotalizarCantidadesProdUnidadMedida(objAprovechamiento.LstEspecies);
            this.gdvEspecimenes.DataBind();
            List<Coordenada> lstCordenadas = new List<Coordenada>();
            string puntos = string.Empty;
            string grados = string.Empty;
            int int_cont = 0;
            foreach (CoordenadaAprovechamientoIndentity oCoor in objAprovechamiento.LstCoordenadas)
            {
                if (int_cont == 0)
                {
                    puntos += "N:" + oCoor.Norte.ToString() + " " + "E:" + oCoor.Este + "  ";
                    grados += "N:" + ConvertirRadianesAGrados(double.Parse(oCoor.Norte.ToString())) + " E:" + ConvertirRadianesAGrados(double.Parse(oCoor.Este.ToString()));
                }
                else
                {
                    puntos += "\n \r N:" + oCoor.Norte.ToString() + " " + "E:" + oCoor.Este + "  ";
                    grados += "\n \r N:" + ConvertirRadianesAGrados(double.Parse(oCoor.Norte.ToString())) + " E:" + ConvertirRadianesAGrados(double.Parse(oCoor.Este.ToString()));
                }

                int_cont++;
            }
            lstCordenadas.Add(new Coordenada { Puntos = puntos, Grados = grados });
            this.dgv_localizaciones.DataSource = lstCordenadas;
            this.dgv_localizaciones.DataBind();

            //jmartinez anulacion aprovechamientos
            ConsultarEstadoAprovechamiento(intAprovechamientoID);

        }
    }

    private void LimpiarSeccionAnulacionAprovechamientos()
    {

    }

    private void ConsultarEstadoAprovechamiento(int intAprovechamientoID)
    {
        AnulacionAprovechamientosIdentity ObjAnulacionAprovechamientosIdentity = new AnulacionAprovechamientosIdentity();
        AnulacionAprovechamiento ObjAnulacionAprovechamiento = new AnulacionAprovechamiento();

        ObjAnulacionAprovechamientosIdentity = ObjAnulacionAprovechamiento.ConsultarEstadoAprovechamiento(intAprovechamientoID);
        this.LblEstadoAprovechamiento.Text = ObjAnulacionAprovechamientosIdentity.strEstadoAprovechamiento;
        Accion = 0;
        //usuarioAdministradorSUNL = true;
        if (UsuarioAA)
        {
            switch (ObjAnulacionAprovechamientosIdentity.EstadoAprovechamientoID)
            {
                case (int)EstadoAprovechamiento.Activo:
                    trDatosBloqueoAprovechamiento.Visible = false;
                    BtnGenerarSolicitud.Text = "Solicitar Anulacion";
                    break;
                    
                case (int)EstadoAprovechamiento.Anulado:
                    BtnGenerarSolicitud.Text = "Solicitar Desblqueo";
                    trDatosBloqueoAprovechamiento.Visible = true;
                    LblMotivoSolicitud.Text = ObjAnulacionAprovechamientosIdentity.strMotivoBloqueo;
                    LblDescripcionBloqueoAprov.Text = ObjAnulacionAprovechamientosIdentity.strDescripcion;
                    lnkArchivoSolicitud.CommandArgument = ObjAnulacionAprovechamientosIdentity.strRutaArchivo;
                    LblUsuarioSolicitante.Text = ObjAnulacionAprovechamientosIdentity.strSolicitante;
                    break;

                case (int)EstadoAprovechamiento.Bloqueado:
                    trDatosBloqueoAprovechamiento.Visible = true;
                    BtnGenerarSolicitud.Text = "Solicitar Desblqoueo";
                    trDatosBloqueoAprovechamiento.Visible = true;
                    LblMotivoSolicitud.Text = ObjAnulacionAprovechamientosIdentity.strMotivoBloqueo;
                    LblDescripcionBloqueoAprov.Text = ObjAnulacionAprovechamientosIdentity.strDescripcion;
                    lnkArchivoSolicitud.CommandArgument = ObjAnulacionAprovechamientosIdentity.strRutaArchivo;
                    LblUsuarioSolicitante.Text = ObjAnulacionAprovechamientosIdentity.strSolicitante;
                    break;

                case (int)EstadoAprovechamiento.SolicitudAnulacion:
                    BtnGenerarSolicitud.Text = "Deshacer Solicitud Anulacion";
                    trDatosBloqueoAprovechamiento.Visible = true;
                    LblMotivoSolicitud.Text = ObjAnulacionAprovechamientosIdentity.strMotivoBloqueo;
                    LblDescripcionBloqueoAprov.Text = ObjAnulacionAprovechamientosIdentity.strDescripcion;
                    lnkArchivoSolicitud.CommandArgument = ObjAnulacionAprovechamientosIdentity.strRutaArchivo;
                    LblUsuarioSolicitante.Text = ObjAnulacionAprovechamientosIdentity.strSolicitante;
                    break;

                case (int)EstadoAprovechamiento.SolicitudBloqueo:
                    BtnGenerarSolicitud.Text = "Deshacer Solicitud Bloqueo";
                    trDatosBloqueoAprovechamiento.Visible = true;
                    LblMotivoSolicitud.Text = ObjAnulacionAprovechamientosIdentity.strMotivoBloqueo;
                    LblDescripcionBloqueoAprov.Text = ObjAnulacionAprovechamientosIdentity.strDescripcion;
                    lnkArchivoSolicitud.CommandArgument = ObjAnulacionAprovechamientosIdentity.strRutaArchivo;
                    LblUsuarioSolicitante.Text = ObjAnulacionAprovechamientosIdentity.strSolicitante;
                    break;

                case (int)EstadoAprovechamiento.SolicitudDesbloqueo:
                    BtnGenerarSolicitud.Text = "Deshacer Solicitud Desbloqueo";
                    trDatosBloqueoAprovechamiento.Visible = true;
                    LblMotivoSolicitud.Text = ObjAnulacionAprovechamientosIdentity.strMotivoBloqueo;
                    LblDescripcionBloqueoAprov.Text = ObjAnulacionAprovechamientosIdentity.strDescripcion;
                    lnkArchivoSolicitud.CommandArgument = ObjAnulacionAprovechamientosIdentity.strRutaArchivo;
                    LblUsuarioSolicitante.Text = ObjAnulacionAprovechamientosIdentity.strSolicitante;
                    break;
            }
        }
        else if (usuarioAdministradorSUNL)
        {
            switch (ObjAnulacionAprovechamientosIdentity.EstadoAprovechamientoID)
            {
                case (int)EstadoAprovechamiento.Activo:
                case (int)EstadoAprovechamiento.Anulado:
                case (int)EstadoAprovechamiento.Bloqueado:
                    trRealizarSolicitudBloqueo.Visible = false;
                    trDatosBloqueoAprovechamiento.Visible = true;
                    BtnRechazarSolicitud.Visible = false;
                    BtnGenerarSolicitud.Visible = false;
                    LblMotivoSolicitud.Text = ObjAnulacionAprovechamientosIdentity.strMotivoBloqueo;
                    LblDescripcionBloqueoAprov.Text = ObjAnulacionAprovechamientosIdentity.strDescripcion;
                    lnkArchivoSolicitud.CommandArgument = ObjAnulacionAprovechamientosIdentity.strRutaArchivo;
                    LblUsuarioSolicitante.Text = ObjAnulacionAprovechamientosIdentity.strSolicitante;
                    break;

                case (int)EstadoAprovechamiento.SolicitudAnulacion:
                    Accion = (int)AccionAprovechamientos.BloquearAprovechamiento;
                    trDatosBloqueoAprovechamiento.Visible = true;
                    BtnGenerarSolicitud.Text = "Bloquear Aprovechamiento";
                    BtnRechazarSolicitud.Visible = true;
                    BtnRechazarSolicitud.Text = "Rechazar Bloqueo Aprovechamiento";
                    LblMotivoSolicitud.Text = ObjAnulacionAprovechamientosIdentity.strMotivoBloqueo;
                    LblDescripcionBloqueoAprov.Text = ObjAnulacionAprovechamientosIdentity.strDescripcion;
                    lnkArchivoSolicitud.CommandArgument = ObjAnulacionAprovechamientosIdentity.strRutaArchivo;
                    LblUsuarioSolicitante.Text = ObjAnulacionAprovechamientosIdentity.strSolicitante;
                    trDescripcionBloqueoAprov.Visible = true;
                    break;

                case (int)EstadoAprovechamiento.SolicitudBloqueo:
                    Accion = (int)AccionAprovechamientos.BloquearAprovechamiento;
                    trDatosBloqueoAprovechamiento.Visible = true;
                    BtnGenerarSolicitud.Text = "Bloquear Aprovechamiento";
                    BtnRechazarSolicitud.Visible = true;
                    BtnRechazarSolicitud.Text = "Rechazar Bloqueo Aprovechamiento";
                    LblMotivoSolicitud.Text = ObjAnulacionAprovechamientosIdentity.strMotivoBloqueo;
                    LblDescripcionBloqueoAprov.Text = ObjAnulacionAprovechamientosIdentity.strDescripcion;
                    lnkArchivoSolicitud.CommandArgument = ObjAnulacionAprovechamientosIdentity.strRutaArchivo;
                    LblUsuarioSolicitante.Text = ObjAnulacionAprovechamientosIdentity.strSolicitante;
                    trDescripcionBloqueoAprov.Visible = true;
                    break;

                case (int)EstadoAprovechamiento.SolicitudDesbloqueo:
                    Accion = (int)AccionAprovechamientos.DesbloqueoAprovechamiento;
                    trDatosBloqueoAprovechamiento.Visible = true;
                    BtnGenerarSolicitud.Text = "Desbloquear Aprovechamiento";
                    BtnRechazarSolicitud.Visible = true;
                    BtnRechazarSolicitud.Text = "Rechazar Desbloqueo Aprovechamiento";
                    LblMotivoSolicitud.Text = ObjAnulacionAprovechamientosIdentity.strMotivoBloqueo;
                    LblDescripcionBloqueoAprov.Text = ObjAnulacionAprovechamientosIdentity.strDescripcion;
                    lnkArchivoSolicitud.CommandArgument = ObjAnulacionAprovechamientosIdentity.strRutaArchivo;
                    LblUsuarioSolicitante.Text = ObjAnulacionAprovechamientosIdentity.strSolicitante;
                    trDescripcionBloqueoAprov.Visible = true;
                    break;
            }
        }
    }

    private void InicializarFormulario()
    {
        this.gdvEspecimenes.DataSource = null;
        this.gdvEspecimenes.DataBind();
        
        
        this.dgv_localizaciones.DataSource = null;
    
        this.cboAutoridadAmbiental.SelectedIndex = 0;
        this.cboClaseRecurso.Enabled = true;
        this.cboClaseRecurso.SelectedIndex = 0;
        Utilidades.LlenarComboVacio(cboClaseAprovechamiento);
        Utilidades.LlenarComboVacio(cboFormaOtorgamiento);
        Utilidades.LlenarComboVacio(cboModoAdquisicion);
        this.lblNumeroActoAdministrativo.Text = string.Empty;
        this.lblFechaActoAdminstrativo.Text = string.Empty;
        this.cboDepartamento.SelectedIndex = 0;
        Utilidades.LlenarComboVacio(this.cboMunicipio);
        this.lblCorregimiento.Text = string.Empty;
        this.lblVereda.Text = string.Empty;
        this.lblPredio.Text = string.Empty;
        this.lblSolicitante.Text = string.Empty;
        this.dgv_localizaciones.DataBind();
        this.gdvEspecimenes.DataSource = null;
        this.gdvEspecimenes.DataBind();
        
    }
    protected void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboDepartamento.SelectedValue == "")
        {
            Utilidades.LlenarComboVacio(cboMunicipio);
            return;
        }
        else
        {
            Listas litMunicipio = new Listas();
            DataTable dtMunicipios = litMunicipio.ListaMunicipios(null, int.Parse(cboDepartamento.SelectedValue), null).Tables[0];
            dtMunicipios = dtMunicipios.AsEnumerable().Where(x => !x.Field<string>("MUN_NOMBRE").Contains("Parque")).CopyToDataTable();
            dtMunicipios = dtMunicipios.AsEnumerable().Where(x => x.Field<int>("AUT_ID") == Convert.ToInt32(this.cboAutoridadAmbiental.SelectedValue)).CopyToDataTable();
            Utilidades.LlenarComboTabla(dtMunicipios, cboMunicipio, "MUN_NOMBRE", "MUN_ID", true);
        }
    }
    private string ConvertirRadianesAGrados(double radiandes)
    {
        //tomamos la parte entera del decimal
        string coordenada = "";
        int grados = (int)Math.Truncate(radiandes);
        coordenada = grados.ToString() + "°";
        //restamos los enteros a los radianes
        double ming = double.Parse(radiandes.ToString().Replace(grados.ToString(), "0")) * 60;
        //tomamos la parte entera para obtener los minutos
        int min = (int)Math.Truncate(ming);
        coordenada = coordenada + min.ToString() + "'";
        //restamos los enteros a los radianes
        double segg = double.Parse(ming.ToString().Replace(min.ToString(), "0")) * 60;
        coordenada = coordenada + segg.ToString() + @"""";
        return coordenada;

    }
    private bool ValidacionToken()
    {
        if (DatosSesion.Usuario == string.Empty)
        {
            return false;
        }
        string idUsuario = Silpa.Workflow.AccesoDatos.ApplicationUserDao.ObtenerIdUsuario(DatosSesion.Usuario).ToString();

        Session["IDForToken"] = (object)idUsuario;

        Session["Usuario"] = Session["IDForToken"];

        SILPA.LogicaNegocio.Usuario.TokenUsuario token = new SILPA.LogicaNegocio.Usuario.TokenUsuario();

        Session["Token"] = token.TomarTokenUsuario(Int32.Parse(Session["IDForToken"].ToString()));

        using (WSValidacionToken.GattacaSecurityServices9000 servicio = new WSValidacionToken.GattacaSecurityServices9000())
        {
            servicio.Url = SILPA.Comun.DireccionamientoWS.UrlWS("WSValidacionToken");
            string mensaje = servicio.GetUserInfoByToken("Softmanagement", Session["Token"].ToString());
            //string mensaje = "Token valido";

            if (mensaje.IndexOf("Token invalido") > 0)
                return false;
        }
        return true;
    }
    private ValoresIdentity CargarValores(int id, string grupo, string valor, int orden, Byte[] archivo)
    {
        ValoresIdentity objValores = new ValoresIdentity();
        objValores.Id = id;
        objValores.Grupo = grupo;
        objValores.Valor = valor;
        objValores.Orden = orden;
        objValores.Archivo = archivo;
        return objValores;
    }
    private string CrearXml()
    {
        List<ValoresIdentity> objValoresList = new List<ValoresIdentity>();
        //objValoresList.Add(CargarValores(1, "Bas", this.txtNombreIniciativa.Text, 1, new Byte[1]));
        //objValoresList.Add(CargarValores(2, "Bas", Session["Usuario"].ToString(), 1, new Byte[1]));
        //objValoresList.Add(CargarValores(3, "Bas", this.txtNombreRazonSocial.Text, 1, new Byte[1]));
        objValoresList.Add(CargarValores(4, "Bas", "134", 1, new Byte[1])); // se envia a MADS
        MemoryStream memoryStream = new MemoryStream();
        XmlSerializer serializador = new XmlSerializer(typeof(List<ValoresIdentity>));
        serializador.Serialize(memoryStream, objValoresList);
        string xml = System.Text.UTF8Encoding.UTF8.GetString(memoryStream.ToArray());
        return xml;
    }
    protected void cboAutoridadAmbiental_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.cboAutoridadAmbiental.SelectedValue != "")
        {
            SILPA.LogicaNegocio.Generico.Listas _listaAutoridades = new SILPA.LogicaNegocio.Generico.Listas();
            SILPA.Comun.Configuracion _configuracion = new SILPA.Comun.Configuracion();
            Utilidades.LlenarComboTabla(_listaAutoridades.ListarDepartamentosPorAutoridadAmbiental(_configuracion.IdPaisPredeterminado, Convert.ToInt32(this.cboAutoridadAmbiental.SelectedValue)).Tables[0], cboDepartamento, "DEP_NOMBRE", "DEP_ID", true);
            Utilidades.LlenarComboVacio(this.cboMunicipio);
        }
        else
        {
            Utilidades.LlenarComboVacio(this.cboDepartamento);
            Utilidades.LlenarComboVacio(this.cboMunicipio);
        }
    }
    protected void cboClaseRecurso_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.cboClaseRecurso.SelectedValue != string.Empty)
        {
            ClaseAprovechamiento vClaseAprovechamiento = new ClaseAprovechamiento();
            ModoAdquisicionRecurso vModoAdquisicionRecurso = new ModoAdquisicionRecurso();
            ClaseProducto vClaseProducto = new ClaseProducto();
            FormaOtorgamiento vFormaOtorgamiento = new FormaOtorgamiento();
            //Utilidades.LlenarComboLista(vClaseAprovechamiento.ListaClaseAprovechamiento(Convert.ToInt32(this.cboClaseRecurso.SelectedValue)),cboClaseAprovechamiento, "ClaseAprovechamiento", "ClaseAprovechamientoId", true);
            Utilidades.LlenarComboLista(vModoAdquisicionRecurso.ListaModoAdquisicionRecurso(Convert.ToInt32(this.cboClaseRecurso.SelectedValue), false,null), cboModoAdquisicion, "ModAdqRecurso", "ModAdqRecursoID", true);
            Utilidades.LlenarComboLista(vFormaOtorgamiento.ListaFormaOtorgamiento(Convert.ToInt32(this.cboClaseRecurso.SelectedValue), false), cboFormaOtorgamiento, "FormaOtorgamiento", "FormaOtorgamientoID", true);

            switch (Convert.ToInt32(this.cboClaseRecurso.SelectedValue))
            {
                case 1:
                    this.cboClaseAprovechamiento.Visible = false;
                    this.cboModoAdquisicion.Visible = true;
                    this.tblAreaTotalAut.Visible = true;
                    this.lblAreaTotalAut.Text = string.Empty;
                    break;
                case 2:
                    this.cboClaseAprovechamiento.Visible = false;
                    this.cboModoAdquisicion.Visible = true;
                    this.tblAreaTotalAut.Visible = true;
                    this.lblAreaTotalAut.Text = string.Empty;
                    break;
                case 3:
                    this.cboClaseAprovechamiento.Visible = false;
                    this.cboModoAdquisicion.Visible = true;
                    this.tblAreaTotalAut.Visible = false;
                    this.lblAreaTotalAut.Text = string.Empty;
                    break;
                case 4:
                    this.cboClaseAprovechamiento.Visible = false;
                    this.cboModoAdquisicion.Visible = true;
                    this.tblAreaTotalAut.Visible = false;
                    this.lblAreaTotalAut.Text = string.Empty;
                    break;
            }
        }
        else
        {
            Utilidades.LlenarComboVacio(cboClaseAprovechamiento);
            Utilidades.LlenarComboVacio(cboModoAdquisicion);
        }
    }


    protected void lnkArchivo_Click(object sender, EventArgs e)
    {
        //Validar que exista información
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
    private void CargarTriggers()
    {
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(lnkArchivo);
    }
    //jmartinez salvoconducto Fase 2
    /// <summary>
    /// Metodo para calcular el aprovechamiento por producto y unidad de medidad
    /// </summary>
    protected void TotalizarCantidadesProdUnidadMedida(List<EspecieAprovechamientoIdentity> LstEspecies)
    {
        if (LstEspecies.Count > 0)
        {
            var Resultado = from x in (from y in LstEspecies
                                       select new
                                       {
                                           y.TipoProducto,
                                           y.UnidadMedida,
                                           y.Cantidad,
                                       })
                            group x by new { x.TipoProducto, x.UnidadMedida } into t
                            select new { t.Key.TipoProducto, t.Key.UnidadMedida, Total = t.Sum(y => y.Cantidad) };

            LblLstTotalTipProductUm.Visible = true;
            this.GrvTotalesEspecies.DataSource = Resultado.ToList();
            this.GrvTotalesEspecies.DataBind();
        }
        else
        {
            LblLstTotalTipProductUm.Visible = false;
            this.GrvTotalesEspecies.DataSource = null;
            this.GrvTotalesEspecies.DataBind();
        }
    }

    protected void cboFormaOtorgamiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClaseAprovechamiento vClaseAprovechamiento = new ClaseAprovechamiento();
        ModoAdquisicionRecurso vModoAdquisicionRecurso = new ModoAdquisicionRecurso();
        ClaseProducto vClaseProducto = new ClaseProducto();
        FormaOtorgamiento vFormaOtorgamiento = new FormaOtorgamiento();
        Utilidades.LlenarComboLista(vModoAdquisicionRecurso.ListaModoAdquisicionRecurso(Convert.ToInt32(this.cboClaseRecurso.SelectedValue), false, Convert.ToInt32(this.cboFormaOtorgamiento.SelectedValue)), cboModoAdquisicion, "ModAdqRecurso", "ModAdqRecursoID", true);
    }

    protected void btnSolciitarBloqueo_Click(object sender, EventArgs e)
    {
        GrabarSolicitudAprovechamiento();
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

    protected void Redireccionar(int AprovechamientoID)
    {
        string parametros = "AprovechamientoID=" + Convert.ToString(AprovechamientoID) + "&BloqueoSalvoConducto = false"; ;
        string query = Utilidades.Encrypt(parametros);
        string queryEncriptado = "../Salvoconducto/ConsultaDetalleAprovechamiento.aspx" + query;
        Response.Redirect(queryEncriptado);
    }

    protected void RedireccionarSolicitud(int AprovechamientoID)
    {
        string parametros = "AprovechamientoID=" + Convert.ToString(AprovechamientoID) + "&BloqueoSalvoConducto = false"; ;
        string query = Utilidades.Encrypt(parametros);
        string queryEncriptado = "../CargueSaldo/SolicitudBloqueoAprovechamiento.aspx" + query;
        Response.Redirect(queryEncriptado);
    }

    protected void GrabarSolicitudAprovechamiento()
    {
        string rutaArchivo = string.Empty;
        string Respuesta = string.Empty;
        string msj = string.Empty;
        AnulacionAprovechamientosIdentity ObjAnulacionAprovechamientosIdentity = new AnulacionAprovechamientosIdentity();
        AnulacionAprovechamiento ObjAnulacionAprovechamiento = new AnulacionAprovechamiento();

        if (string.IsNullOrEmpty(txtDescripcionBloqueoAprov.Text))
        {
            msj = "Debe Ingresar una descripcion corta del la aprobacion o rechazo de la solicitud";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Info", "alert('" + msj + "');", true);
            return;
        }

        if (string.IsNullOrEmpty(txtDescripcionBloqueoAprov.Text))
        {
            switch (Accion)
            {
                case (int)AccionAprovechamientos.DeshacerSolicitudBloqueo:
                    Respuesta = "El usuario aprobabor Rechaza la solicitud de bloqueo del aprovechamiento";
                    break;
                case (int)AccionAprovechamientos.DeshacerSolicitudDesbloqueo:
                    Respuesta = "El usuario aprobabor Rechaza la solicitud de desbloqueo del aprovechamiento";
                    break;
                case (int)AccionAprovechamientos.BloquearAprovechamiento:
                    Respuesta = "El usuario aprobabor Aprueba la solicitud de bloqueo del aprovechamiento";
                    break;
                case (int)AccionAprovechamientos.RechazarBloqueo:
                    Respuesta = "El usuario aprobabor Rechaza la solicitud de bloqueo del aprovechamiento";
                    break;
                case (int)AccionAprovechamientos.DesbloqueoAprovechamiento:
                    Respuesta = "El usuario aprobabor Aprueba la solicitud de desbloqueo del aprovechamiento";
                    break;
            }
        }
        else
        {
            Respuesta = txtDescripcionBloqueoAprov.Text;
        }

        switch (Accion)
        {
            case (int)AccionAprovechamientos.DesbloqueoAprovechamiento:
            case (int)AccionAprovechamientos.RechazarDesBloqueo:
            case (int)AccionAprovechamientos.BloquearAprovechamiento:
            case (int)AccionAprovechamientos.RechazarBloqueo:
                rutaArchivo = string.Empty;
                ObjAnulacionAprovechamientosIdentity.AprovechamientoID = Convert.ToInt32(AprovechamientoID);
                ObjAnulacionAprovechamientosIdentity.MotivobloqueoID = 0;
                ObjAnulacionAprovechamientosIdentity.strDescripcion = Respuesta;
                ObjAnulacionAprovechamientosIdentity.AutID = autID;
                ObjAnulacionAprovechamientosIdentity.SolID = long.Parse(Session["Usuario"].ToString());
                ObjAnulacionAprovechamientosIdentity.Accion = Accion;
                ObjAnulacionAprovechamientosIdentity.strRutaArchivo = rutaArchivo;
                ObjAnulacionAprovechamientosIdentity.NumeroActoAdministrativo = this.lblNumeroActoAdministrativo.Text + " - " + this.lblFechaActoAdminstrativo.Text  ;
                ObjAnulacionAprovechamientosIdentity.NombreAutoridadAmbiental = this.cboAutoridadAmbiental.SelectedItem.ToString();
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
                break;
        }
    }

    protected void BtnGenerarSolicitud_Click(object sender, EventArgs e)
    {
        switch (Accion)
        {
            case (int)AccionAprovechamientos.BloquearAprovechamiento:
            case (int)AccionAprovechamientos.DesbloqueoAprovechamiento:
                GrabarSolicitudAprovechamiento();
                break;

            default:
                RedireccionarSolicitud(Convert.ToInt32(AprovechamientoID));
                break;
        }
    }

    protected void BtnRechazarSolicitud_Click(object sender, EventArgs e)
    {
        switch (Accion)
        {
            case (int)AccionAprovechamientos.BloquearAprovechamiento:
                Accion = (int)AccionAprovechamientos.RechazarBloqueo;
                break;

            case (int)AccionAprovechamientos.DesbloqueoAprovechamiento:
                Accion = (int)AccionAprovechamientos.RechazarDesBloqueo;
                break;
        }
        GrabarSolicitudAprovechamiento();
    }
}
