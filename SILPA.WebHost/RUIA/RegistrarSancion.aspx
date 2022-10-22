<%@ Page Language="C#" MasterPageFile="~/plantillas/SILPABuscador.master" AutoEventWireup="true" CodeFile="RegistrarSancion.aspx.cs" Inherits="RUIA_RegistrarSancion" Title="Registro Unico de Infractores Ambientales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../Resources/Bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/jquery.datetimepicker.css" rel="stylesheet" />
    <link rel="stylesheet" href="../Resources/Buscador/css/buscadorVITAL.css" />
    <link href="../Resources/EstilosBase/css/tabs-nuevas.css" rel="stylesheet" />

    <script src='<%= ResolveClientUrl("~/Resources/jquery/3.2.1/jquery.min.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Resources/jquery/fontsize/js/jquery.jfontsize-1.0.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Resources/Bootstrap/5.0.1/js/bootstrap.min.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Scripts/jquery.datetimepicker.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Resources/RUIA/RegistrarSancion.js") %>'></script>
    <style type="text/css">
        label {
            font-weight: 400;
        }
        table tr td {
            border: 0px solid #ddd !important;
            padding: 4px;
        }
    </style>
    <asp:ScriptManager ID="scmManejadorSancion" runat="server">
    </asp:ScriptManager>

    
    <div class="row">
        <div class="titulo_pagina">
            Registro único de infractores ambientales
        </div>
    </div>
    <asp:UpdatePanel ID="uppPanelSancion" runat="server">
        <ContentTemplate>
            <div class="row resultados">
                <div class="row">
                    <cc1:TabContainer ID="tbcContenedor" runat="server" ActiveTabIndex="0">
                        <cc1:TabPanel runat="server" ID="tabDatosSancion" HeaderText="Datos de Infracci&#243;n o Sanci&#243;n">
                            <ContentTemplate>
                                <table style="width:100%">
                                    <tr>
                                        <td style="width:30%; align-content:flex-start">
                                            <label for="cboTipoPersona">Tipo de persona sancionada</label>
                                            <asp:Label ID="lblId" runat="server" SkinID="etiqueta_negra" Visible="False">0</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboTipoPersona" runat="server" OnSelectedIndexChanged="cboTipoPersona_SelectedIndexChanged" AutoPostBack="True" class="form-control"></asp:DropDownList>
                                            <asp:Label ID="lblFormulario" TabIndex="1" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="cboTipoFalta">Tipo de Infracción</label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboTipoFalta" runat="server" class="form-control"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="txtDescripcionNorma">Descripción de la norma específica</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDescripcionNorma" runat="server" placeholder="Descripción de la norma específica" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvDescripcionNorma" runat="server" ControlToValidate="txtDescripcionNorma" ErrorMessage="Ingrese descripción de la norma específica">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="Subtitulo">
                                                Lugar de Ocurrencia de los Hechos
                                            </div>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="cboDepartamentoOcurrencia">Departamento de ocurrencia</label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboDepartamentoOcurrencia" runat="server" OnSelectedIndexChanged="cboDepartamentoOcurrencia_SelectedIndexChanged" AutoPostBack="True" class="form-control"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="reqDepartamentoOcurrencia" runat="server" Display="Dynamic" ControlToValidate="cboDepartamentoOcurrencia" ErrorMessage="Seleccione el departamento de ocurrencia">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="cboMunicipioOcurrencia">Municipio de ocurrencia</label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboMunicipioOcurrencia" runat="server" OnSelectedIndexChanged="cboMunicipioOcurrencia_SelectedIndexChanged" AutoPostBack="True" class="form-control"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="reqMunicipioOcurrencia" runat="server" Display="Dynamic" ControlToValidate="cboMunicipioOcurrencia" ErrorMessage="Seleccione el municipio de ocurrencia de los hechos">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="cboCorregimientoOcurrencia">Corregimiento de ocurrencia</label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboCorregimientoOcurrencia" runat="server" OnSelectedIndexChanged="cboCorregimientoOcurrencia_SelectedIndexChanged" class="form-control"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="cboVeredaOcurrencia">Vereda de ocurrencia</label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboVeredaOcurrencia" runat="server" class="form-control"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left">
                                            <label for="cboOpcionesPrincipal">Tipo de Sanción Principal</label>
                                        </td>
                                        <td valign="top" align="left">
                                            <asp:DropDownList ID="cboOpcionesPrincipal" runat="server" class="form-control"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="reqOpcionPrincipal" runat="server" Display="Dynamic" ControlToValidate="cboOpcionesPrincipal" ErrorMessage="Seleccione el tipo de opción principal">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left">
                                            <label for="txtSancionAplicadaPpal">Sanción Aplicada Principal</label>
                                        </td>
                                        <td valign="top" align="left">
                                            <asp:TextBox ID="txtSancionAplicadaPpal" runat="server" class="form-control" placeholder="Sanción Aplicada Principal"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reqSancionAplicadaPpal" runat="server" Display="Dynamic" ControlToValidate="txtSancionAplicadaPpal" ErrorMessage="Digite la sanción principal aplicada">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <label for="cboTipoSancionSecundaria">Sanciones Accesorias</label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="cboTipoSancionSecundaria">Tipo Sanción Accesoria</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="cboTipoSancionSecundaria" runat="server" class="form-control"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="txtSancionAplicadaSec">Sanción Aplicada Accesoria</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSancionAplicadaSec" runat="server" class="form-control" placeholder="Sanción Aplicada Accesoria"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnAgregarSec" OnClick="btnAgregarSec_Click" runat="server" CssClass="button btn-high btn-gov-mads" Text="Agregar" CausesValidation="False"></asp:Button>
                                            <asp:Button ID="btnQuitarSec" OnClick="btnQuitarSec_Click" runat="server" CssClass="button btn-high btn-gov-mads" Text="Quitar" CausesValidation="False"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMensajeSecundaria" runat="server" ForeColor="Red"></asp:Label>
                                            
                                        </td>
                                        <td>
                                            <asp:ListBox ID="lstSecundaria" runat="server" class="form-control"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="txtNumeroExpediente">Número de Expediente</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtNumeroExpediente" runat="server" CssClass="form-control" placeholder="Número de Expediente"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNumeroExpediente" runat="server" Display="Dynamic" ControlToValidate="txtNumeroExpediente" ErrorMessage="Ingrese número de expediente">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="txtNumeroActo">Número de Acto que impone sanción</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtNumeroActo" runat="server" CssClass="form-control" placeholder="Número de Acto que impone sanción" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNumeroActo" runat="server" Display="Dynamic" ControlToValidate="txtNumeroActo" ErrorMessage="Ingrese el número del Acto Administrativo">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="txtFechaExpedicion">Fecha de Expedición del Acto Administrativo</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFechaExpedicion" runat="server" MaxLength="10" class="form-control textbox-calendar"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFechaExpedicion" runat="server" Display="Dynamic" ControlToValidate="txtFechaExpedicion" ErrorMessage="Ingrese fecha de expedición del acto administrativo">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revFechaExpedicion" runat="server" ControlToValidate="txtFechaExpedicion" ErrorMessage="Formato de fecha no valido para la fecha de expedición del acto" ValidationExpression="^\d{2}\/\d{2}\/\d{4}">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="txtFechaEjecutoria">Fecha de ejecutoria del Acto que impone sanción</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFechaEjecutoria" runat="server"  MaxLength="10" class="form-control textbox-calendar"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFechaEjecutoria" runat="server" Display="Dynamic" ControlToValidate="txtFechaEjecutoria" ErrorMessage="Ingrese la fecha de ejecutoria del acto">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revFechaEjecutoria" runat="server" ControlToValidate="txtFechaEjecutoria" ErrorMessage="Formato de fecha no valido para la fecha de ejecutoria del acto" ValidationExpression="^\d{2}\/\d{2}\/\d{4}">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="txtFechaEjecutoria">Fecha de ejecución o cumplimiento de la sanción</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFechaEjecucion" runat="server" MaxLength="10" class="form-control textbox-calendar"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="revFechaEjecucion" runat="server" ControlToValidate="txtFechaEjecucion" ErrorMessage="Formato de fecha no valido para la fecha de ejecución o cumplimiento de la sanción" ValidationExpression="^\d{2}\/\d{2}\/\d{4}">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left">
                                            <label for="txtObservaciones">Observaciones</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="from-control" placeholder="Observaciones" Rows="8" TextMode="MultiLine" Width="100%" Style="resize: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="titleUpdate" colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="Subtitulo">
                                                Datos de Publicación
                                            </div>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="titleUpdate" colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="txtDescripcionDesfijacion">Descripción de la Desfijación de la publicación</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDescripcionDesfijacion" runat="server" CssClass="form-control" placeholder="Descripción de la Desfijación de la publicación"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvDescripcionDesfijacion" runat="server" Display="Dynamic" ControlToValidate="txtDescripcionDesfijacion" ErrorMessage="Ingrese la descripción de la desfijación de la publicación">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trMotivoModificacion" runat="server" visible="false">
                                        <td valign="top" align="left">
                                            <label for="txtMotivoModificacion">Motivo de la Modificación</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMotivoModificacion" runat="server" CssClass="form-control" placeholder="Motivo de la Modificación" Height="100px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="trMotivoModificacion2" runat="server" visible="false">
                                        <td align="left">
                                            <label for="cboTramiteModificacion">Reporte en Trámite de Modificación</label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboTramiteModificacion" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                                <asp:ListItem Value="1">Si</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel runat="server" ID="tabDatosNatural" HeaderText="Datos de Persona Natural">
                            <ContentTemplate>
                                <table style="width:100%">
                                    <tr>
                                        <td style="width:30%; align-content:flex-start">
                                            <label for="txtPrimerNombre">Primer Nombre</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPrimerNombre" runat="server" CssClass="form-control" placeholder="Primer Nombre"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPrimerNombre" runat="server" Display="Dynamic" ErrorMessage="Ingrese el primer nombre de Persona Natural" ControlToValidate="txtPrimerNombre">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="txtSegundoNombre">Segundo Nombre</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSegundoNombre" runat="server" CssClass="form-control" placeholder="Segundo Nombre"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="txtPrimerApellido">Primer Apellido</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="form-control" placeholder="Primer Apellido"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPrimerApellido" runat="server" Display="Dynamic" ErrorMessage="Ingrese el primer apellido de Persona Natural" ControlToValidate="txtPrimerApellido">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="txtSegundoApellido">Segundo Apellido</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="form-control" placeholder="Segundo Apellido"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="cboTipoDocumento">Tipo de Documento</label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboTipoDocumento" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <label for="txtNumeroDocumento">Número de Documento</label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control" placeholder="Número de Documento"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNumeroDocumento" runat="server" Display="Dynamic" ErrorMessage="Ingrese número de documento de Persona Natural" ControlToValidate="txtNumeroDocumento">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left">
                                            <label for="cboMunicipioNatural">De</label>
                                        </td>
                                        <td valign="top" align="left">
                                            <asp:DropDownList ID="cboDepartamentoNatural" runat="server" CssClass="form-control" OnSelectedIndexChanged="cboDepartamentoNatural_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                            <br />
                                            <asp:DropDownList ID="cboMunicipioNatural" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel runat="server" ID="tabDatosJuidica" HeaderText="Datos de Persona Jur&#237;dica">
                            <ContentTemplate>
                                <table style="width:100%">
                                        <tr>
                                            <td style="width:30%; align-content:flex-start">
                                                <label for="txtRazonSocial">Razón Social</label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="form-control" placeholder="Razón Social"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvRazonSocial" runat="server" Display="Dynamic" ErrorMessage="Ingrese la Razón Social" ControlToValidate="txtRazonSocial">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <label for="txtNit">NIT</label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtNit" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvNit" runat="server" Display="Dynamic" ErrorMessage="Ingrese el NIT de la Razón Social (XXXXXXXXX-X)" ControlToValidate="txtNit">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revNit" runat="server" Display="Dynamic" ErrorMessage="Formato no válido para el NIT de la Razón Social" ControlToValidate="txtNit" ValidationExpression="\d{5,9}-\d{1}">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <label for="txtPrimerNombreRepresentante">Primer Nombre Representante Legal</label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtPrimerNombreRepresentante" runat="server" CssClass="form-control" placeholder="Primer Nombre Representante Legal"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvPrimerNombreRepresentante" runat="server" Display="Dynamic" ErrorMessage="Ingrese el primer nombre del Representante Legal" ControlToValidate="txtPrimerNombreRepresentante">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <label for="txtSegundoNombreRepresentante">Segundo Nombre Representante Legal</label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSegundoNombreRepresentante" runat="server" CssClass="form-control" placeholder="Segundo Nombre Representante Legal"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <label for="txtPrimerApellidoRepresentante">Primer Apellido Representante legal</label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtPrimerApellidoRepresentante" runat="server" CssClass="form-control" placeholder="Primer Apellido Representante legal"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvPrimerApellidoRepresentante" runat="server" Display="Dynamic" ErrorMessage="Ingrese el primer apellido del Representante Legal" ControlToValidate="txtPrimerApellidoRepresentante">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <label for="txtSegundoApellidoRepresentante">Segundo Apellido Representante legal</label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSegundoApellidoRepresentante" runat="server" CssClass="form-control" placeholder="Segundo Apellido Representante legal"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <label for="cboTipoDocumentoJuridica">Tipo de Documento</label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="cboTipoDocumentoJuridica" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <label for="txtNumeroDocumentoRepresentante">Número de Documento</label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtNumeroDocumentoRepresentante" runat="server" CssClass="form-control" placeholder="Número de Documento"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvNumeroDocumentoRepresentante" runat="server" Display="Dynamic" ErrorMessage="Ingrese el número de documento del Representante Legal" ControlToValidate="txtNumeroDocumentoRepresentante">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left">
                                                <label for="cboMunicipioJuridica">De</label>
                                            </td>
                                            <td valign="top" align="left">
                                                <asp:DropDownList ID="cboDepartamentoJuridica" runat="server" CssClass="form-control" OnSelectedIndexChanged="cboDepartamentoJuridica_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                <br />
                                                <asp:DropDownList ID="cboMunicipioJuridica" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </td>
                                        </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:TabContainer>
                </div>
                <div class="row col-md-4 botones">
                    <div class="col-md-6">
                        <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="button btn-high btn-gov-mads" runat="server" Text="Guardar RUIA"></asp:Button>
                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="button btn-high btn-gov-mads" runat="server" Text="Cancelar" CausesValidation="false" OnClientClick="return cancelarRUIA();" />
                    </div>
                </div>
                <asp:ValidationSummary ID="valResumen" runat="server"></asp:ValidationSummary>
            </div>

        </ContentTemplate>

    </asp:UpdatePanel>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="uppPanelSancion">
        <ProgressTemplate>  
            <div id="ModalProgressContainer">
                <div id="container-loader" class="container-loader-buscadorVITAL"></div>
                <div id="loader" class="loader-buscadorVITAL"></div
            </div>                         
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
