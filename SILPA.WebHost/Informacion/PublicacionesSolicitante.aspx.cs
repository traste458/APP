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
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using SILPA.AccesoDatos.Publicacion;
using SILPA.LogicaNegocio.Publicacion;
using SILPA.LogicaNegocio.Generico;
using SILPA.Comun;
using SILPA.AccesoDatos.Generico;
using SoftManagement.Log;

public partial class Informacion_PublicacionesSolicitante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // hava
        Mensaje.LimpiarMensaje(this);
       
        if (!IsPostBack)
        {
            CargarTipoTramite();
            CargarAutoridades();
            CargarSectores();
            CargarTipoDocumento();
        }
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        DateTime? fechaInicial = null;
        DateTime? fechaFinal = null;

        if (txtFechaInicial.Text != string.Empty)
        {
            try
            {
                fechaInicial = Convert.ToDateTime(txtFechaInicial.Text);
            }
            catch
            {
                Mensaje.MostrarMensaje(this, "El valor del campo Fecha Desde no es v�lido");
                return;
            }
        }
        if (txtFechaFinal.Text != string.Empty)
        {
            try
            {
                fechaFinal = Convert.ToDateTime(txtFechaFinal.Text);
            }
            catch
            {
                Mensaje.MostrarMensaje(this, "El valor del campo Fecha Hasta no es v�lido");
                return;
            }
        }

        if (txtFechaFinal.Text != string.Empty && txtFechaInicial.Text != string.Empty)
        {
            if (fechaFinal < fechaInicial)
            {
                Mensaje.MostrarMensaje(this, "El valor del campo Fecha Hasta, debe ser posterior o igual al valor del campo Fecha Desde");
                return;
            }
        }

        CargarPublicaciones();
    }

    protected void grdPublicaciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "VerDetalle")
        {
            int _indice = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _fila = grdPublicaciones.Rows[_indice];
            DataKey dk = this.grdPublicaciones.DataKeys[_indice];

            // id_publicaci�n
            long _codigoPublicacion = long.Parse(dk.Values[0].ToString());

            //Int64 _codigoPublicacion = Convert.ToInt64(_fila.Cells[1].Text);
            Session.Add("codPublicacion", "");
            Session["codPublicacion"] = _codigoPublicacion.ToString();

            CargarVistaDetalle(_codigoPublicacion);

            /// hava:22-abr-10
            /// preparando la session para listar los documentos desde el panel de detalle
            string archivo = dk.Values[1].ToString();
            List<DetalleDocumentoIdentity> ListaDocumentos = new List<DetalleDocumentoIdentity>();

            TraficoDocumento tf = new SILPA.Comun.TraficoDocumento();
            List<string> ListaNombreArchivos = tf.ListarDocumentosDirectorio(archivo);

            foreach (string str in ListaNombreArchivos)
            {
                DetalleDocumentoIdentity doc = new DetalleDocumentoIdentity();
                doc.Ubicacion = str;
                doc.NombreArchivo = System.IO.Path.GetFileName(str);
                ListaDocumentos.Add(doc);
            }

            Session["ListaDocumentos"] = ListaDocumentos;
            //Page.Response.Redirect("DetalleDocumentos.aspx");
        }

        if (e.CommandName == "VerDocumento")
        {

            int _indice = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _fila = grdPublicaciones.Rows[_indice];

            DataKey dk = this.grdPublicaciones.DataKeys[_indice];

            //string idPublicaicon = dk.Values[0].ToString();
            string archivo = dk.Values[1].ToString();
            List<DetalleDocumentoIdentity> ListaDocumentos = new List<DetalleDocumentoIdentity>();

            TraficoDocumento tf = new SILPA.Comun.TraficoDocumento();
            List<string> ListaNombreArchivos = tf.ListarDocumentosDirectorio(archivo);

            foreach (string str in ListaNombreArchivos)
            {
                DetalleDocumentoIdentity doc = new DetalleDocumentoIdentity();
                doc.Ubicacion = str;
                doc.NombreArchivo = System.IO.Path.GetFileName(str);
                ListaDocumentos.Add(doc);
            }

            Session["ListaDocumentos"] = ListaDocumentos;
            Page.Response.Redirect("DetalleDocumentos.aspx");
        }
    }

    protected void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
    {
        //JDG 2010/28/02 Esto se debe redefinir despues de reuni�n para validar tipos de documentos
        //cboObjetoDocumento.Items.Clear();
        //cboObjetoDocumento.Items.Add(new ListItem("Seleccione...", "-1"));
        //if (cboTipoDocumento.SelectedValue != "-1")
        //{            
        //    Listas _listaObjetoDocumento = new Listas();
        //    DataSet _temp = _listaObjetoDocumento.ListarActoAdministrativo(null, Convert.ToInt16(cboTipoDocumento.SelectedValue));            
        //    foreach (DataRow _fila in _temp.Tables[0].Rows)
        //    {
        //        ListItem _item = new ListItem(_fila["AAD_NOMBRE"].ToString(), _fila["AAD_ID"].ToString());
        //        cboObjetoDocumento.Items.Add(_item);
        //    }
        //}
    }

    #region Funciones Programador

    /// <summary>
    /// Funcion que carga el listado de Autoridades Ambientales.
    /// </summary>
    private void CargarAutoridades()
    {
        try
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".CargarAutoridades.Inicio");
            Listas _listaAutoridades = new Listas();
            DataSet _temp = _listaAutoridades.ListarAutoridades(null);
            foreach (DataRow _fila in _temp.Tables[0].Rows)
            {
                ListItem _item = new ListItem(_fila["AUT_NOMBRE"].ToString(), _fila["AUT_ID"].ToString());
                cboAutoridadAmbiental.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            SMLog.Escribir(ex);
        }
        finally
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".CargarAutoridades.Finalizo");
        }
    }

    /// <summary>
    /// Funcion que carga el listado de sectores en el combo correspondiente.
    /// </summary>
    private void CargarSectores()
    {
        try
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".CargarSectores.Inicio");
            SILPA.LogicaNegocio.Generico.Listas _listaSectores = new SILPA.LogicaNegocio.Generico.Listas();
            DataSet _temp = _listaSectores.ListarSectorTipoProyecto(null, -1);
            foreach (DataRow _fila in _temp.Tables[0].Rows)
            {
                ListItem _item = new ListItem(_fila["SEC_NOMBRE"].ToString(), _fila["SEC_ID"].ToString());
                cboSectorPublicacion.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            SMLog.Escribir(ex);
        }
        finally
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".CargarSectores.Finalizo");
        }
    }

    private void CargarPublicaciones()
    {
        try
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".CargarPublicaciones.Inicio");
            String strFechaInicial = "";
            String strFechaFinal = "";

            if (txtFechaInicial.Text != "")
            {
                strFechaInicial = ConvFechas(Convert.ToDateTime(txtFechaInicial.Text));
            }

            if (txtFechaFinal.Text != "")
            {
                strFechaFinal = ConvFechas(Convert.ToDateTime(txtFechaFinal.Text));
            }

            DateTime? fechaFinal = null;
            if (txtFechaFinal.Text != string.Empty)
                fechaFinal = Convert.ToDateTime(txtFechaFinal.Text).AddDays(1);
            Publicacion _listaPublicaciones = new Publicacion();
            DataSet _temp = _listaPublicaciones.ListarPublicacion(null,
                Convert.ToInt16(cboTipoTramite.SelectedValue),
                Convert.ToInt16(cboAutoridadAmbiental.SelectedValue),
                Convert.ToInt16(cboSectorPublicacion.SelectedValue),
                ((txtNombreProyecto.Text == "") ? null : txtNombreProyecto.Text),
                Convert.ToInt16(cboTipoDocumento.SelectedValue),
                ((txtNumeroDocumento.Text == "") ? null : txtNumeroDocumento.Text),
                ((txtNumeroExpediente.Text == "") ? null : txtNumeroExpediente.Text),
                //((txtFechaInicial.Text == "") ? null : txtFechaInicial.Text),
                ((strFechaInicial == "") ? null : strFechaInicial),
                ((strFechaFinal == "") ? null : strFechaFinal),
                //((fechaFinal == null) ? null : fechaFinal.ToString()),
                null);
            if (_temp.Tables[0].Rows.Count > 0)
            {
                grdPublicaciones.DataSource = _temp;
                grdPublicaciones.DataBind();
                pnlPublicaciones.Visible = true;
                dvwDocumento.Visible = false;
                pnlComentarios.Visible = false;
                pnlAgregarComentario.Visible = false;
            }
            else
            {
                pnlPublicaciones.Visible = false;
                dvwDocumento.Visible = false;
                pnlComentarios.Visible = false;
                pnlAgregarComentario.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMLog.Escribir(ex);
        }
        finally
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".CargarPublicaciones.Finalizo");
        }
    }

    /// <summary>
    /// Funci�n que carga el listado de Tipos de Documento en el respectivo combo.
    /// </summary>
    private void CargarTipoTramite()
    {
        try
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".CargarTipoTramite.Inicio");
            Listas _listaTipoTramite = new Listas();
            DataSet _temp = _listaTipoTramite.ListarTipoTramite(null);
            foreach (DataRow _fila in _temp.Tables[0].Rows)
            {
                ListItem _item = new ListItem(_fila["NOMBRE_TIPO_TRAMITE"].ToString(), _fila["ID_TIPO_PROCESO"].ToString());
                cboTipoTramite.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            SMLog.Escribir(ex);
        }
        finally
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".CargarTipoTramite.Finalizo");
        }
    }

    /// <summary>
    /// Funci�n que carga el listado de Tipos de Documento en el respectivo combo.
    /// </summary>
    private void CargarTipoDocumento()
    {
        try
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".CargarTipoDocumento.Inicio");
            TipoDocumentoDalc _tipoDocumentoDalc = new TipoDocumentoDalc();
            DataSet _temp = _tipoDocumentoDalc.ListarTiposDeDocumento(null, null);
            foreach (DataRow _fila in _temp.Tables[0].Rows)
            {
                ListItem _item = new ListItem(_fila["NOMBRE_DOCUMENTO"].ToString(), _fila["ID"].ToString());
                cboTipoDocumento.Items.Add(_item);
            }
        }
        catch (Exception ex)
        {
            SMLog.Escribir(ex);
        }
        finally
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".CargarTipoDocumento.Finalizo");
        }
    }

    /// <summary>
    /// Funcion que carga la publicacion en vista detalle
    /// </summary>
    /// <param name="_codigoPublicacion">Identificador de la publicacion</param>
    private void CargarVistaDetalle(Int64 _codigoPublicacion)
    {
        try
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".CargarVistaDetalle.Inicio");
            Publicacion _listaPublicaciones = new Publicacion();
            DataSet _temp = _listaPublicaciones.ListarPublicacion(_codigoPublicacion, null, null, null, null, null, null, null, null, null, null);
            Session["Resultado"] = _temp;
            dvwDocumento.DataSource = _temp;
            dvwDocumento.DataBind();

            pnlPublicaciones.Visible = false;
            dvwDocumento.Visible = true;
            lblComentarioError.Text = "No ha insertado texto para el comentario";
            lblComentarioError.Visible = false;

            string _vigencia = _temp.Tables[0].Rows[0][3].ToString();
            string _tipo = _temp.Tables[0].Rows[0][19].ToString();

            Publicacion _listaComentarios = new Publicacion();
            DataSet _comentarios = _listaComentarios.ListarComentario(null, _codigoPublicacion);

            if (_comentarios.Tables[0].Rows.Count > 0)
            {
                pnlComentarios.Visible = true;
                grdComentarios.DataSource = _comentarios;
                grdComentarios.DataBind();
            }

            if ((_vigencia == "0") || (_vigencia == "1" && _tipo == "1"))
            {
                pnlAgregarComentario.Visible = true;
            }
            else
            {
                pnlAgregarComentario.Visible = false;
            }
        }
        catch (Exception ex)
        {
            SMLog.Escribir(ex);
        }
        finally
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".CargarVistaDetalle.Finalizo");
        }
    }

    #endregion

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".btnAgregar_Click.Inicio");
            if (txtComentario.Text == "")
                lblComentarioError.Visible = true;
            else
            {
                lblComentarioError.Visible = false;
                Int64 _codigoPub = Convert.ToInt64(Session["codPublicacion"].ToString());
                Publicacion _publicacion = new Publicacion(_codigoPub, txtComentario.Text);
                _publicacion.InsertarComentario();
                txtComentario.Text = "";
                CargarVistaDetalle(_codigoPub);
            }
        }
        catch (Exception ex)
        {
            SMLog.Escribir(ex);
        }
        finally
        {
            SMLog.Escribir(Severidad.Critico, Page.AppRelativeVirtualPath.ToString() + ".btnAgregar_Click.Finalizo");
        }
    }

    protected void grdPublicaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grdPublicaciones.PageIndex = e.NewPageIndex;
        this.CargarPublicaciones();
    }

    protected void grdPublicaciones_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                LinkButton lnkEliminar = (LinkButton)e.Row.FindControl("lnkEliminar");
                lnkEliminar.Attributes.Add("onClick", "return confirm('Esta seguro que desea eliminar el registro?')");
            }
        }
    }

    protected void grdPublicaciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label lblId = (Label)this.grdPublicaciones.Rows[e.RowIndex].FindControl("lblId");
            Publicacion _publicacion = new Publicacion();
            _publicacion.EliminarPublicacion(Convert.ToInt64(lblId.Text));
            this.CargarPublicaciones();
        }
        catch
        {
        }
    }

    protected void dvwDocumento_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Descargar")
        {

            //string idPublicaicon = dk.Values[0].ToString();,
            //string _nombreArchivo = dk.Values[1].ToString();
            DataSet datos = (DataSet)Session["Resultado"];
            string ruta = Convert.ToString(datos.Tables[0].Rows[0]["RUTA_PUB"]);
            string[] archivos = System.IO.Directory.GetFiles(ruta);
            string _nombreArchivo = archivos[0];
           
            System.IO.FileInfo targetFile = new System.IO.FileInfo(_nombreArchivo);
            this.Response.Clear();
            this.Response.AddHeader("Content-Disposition", "attachment; filename=" + targetFile.Name);
            this.Response.AddHeader("Content-Length", targetFile.Length.ToString());
            this.Response.ContentType = "application/octet-stream";
            this.Response.ContentType = "application/base64";
            this.Response.WriteFile(targetFile.FullName);
            this.Response.WriteFile(_nombreArchivo);

        }
    }

    /// <summary>
    /// Funcion que recibe como parametro una fecha y la devuelve como string en formato ANSI
    /// </summary>
    /// <param name="dtFecha"></param>
    /// <returns></returns>
    private string ConvFechas(DateTime dtFecha)
    {
        string strFecha;
        string strMes;
        string strDia;
        
        if (dtFecha.Month < 10)
        {
            strMes = "0" + dtFecha.Month.ToString();
        }
        else
        {
            strMes = dtFecha.Month.ToString();
        }

        if (dtFecha.Day < 10)
        {
            strDia = "0" + dtFecha.Day.ToString();
        }
        else
        {
            strDia = dtFecha.Day.ToString();
        }

        strFecha = dtFecha.Year.ToString() + strMes + strDia;

        return strFecha;
    }
}
