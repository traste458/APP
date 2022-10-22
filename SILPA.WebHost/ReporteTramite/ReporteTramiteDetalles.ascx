<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReporteTramiteDetalles.ascx.cs" Inherits="ReporteTramite_ReporteTramiteDetalles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<link rel="stylesheet" type="text/css" href="../Resources/Buscador/css/buscadorVITAL.css" />
<link rel="stylesheet" type="text/css" href="../Resources/Buscador/css/ReporteTramiteDetallesCiudadano.css" />
<script language="javascript" type="text/javascript"> 
    function cerrar() {
        window.close();
    } 
</script>

<div style="text-align: left">
    <asp:HiddenField ID="hdfMostrarDocumentos" runat="server" />
    <div class="col-md-12 estadoTramite">
        <div class="row">
             <label class="col-sm-2 Subtitulo">N�mero VITAL:</label>
            <div class="col-sm-10 numeroVITAL">
                <asp:Label ID="lblNumeroSilpa" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row">
            <asp:Label ID="lblTexxto" runat="server" Text="Expedientes Asociados:" class="col-sm-3 Subtitulo"></asp:Label>
            <div class="col-sm-9 expedienteAscociado">
                <asp:DropDownList ID="cboExpedientesAsociados" runat="server" OnSelectedIndexChanged="cboExpedientesAsociados_SelectedIndexChanged" SkinID="lista_desplegable" AutoPostBack="True"></asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <div class="row">
             <asp:GridView ID="grdSolAsoc" Width="90%" runat="server" OnRowCommand="grdSolAsoc_RowCommand" AutoGenerateColumns="False" SkinID="grilla">
                                <Columns>
                                    <asp:TemplateField HeaderText="Tipo Tramite">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTipoTramite" runat="server" Text='<%# Eval("NOMBRE_TIPO_TRAMITE")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Numero Vital">
                                        <ItemTemplate>
                                            <asp:Label ID="lbNumeroSilpa" runat="server" Text='<%# Eval("SOL_NUMERO_SILPA")%>'></asp:Label>
                                            <asp:Label ID="lblIdSol" runat="server" Visible="false" Text='<%# Eval("SOL_ID_SOLICITANTE")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Numero Expediente">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' Text="Ver Tramite" ID="lbVerDetalles" runat="server" CommandName="DETALLE"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
        </div>
        <div class="row">
             <cc1:Accordion ID="MyAccordion"
                    runat="Server"
                    HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected"
                    ContentCssClass="accordionContent"
                    AutoSize="None"
                    FadeTransitions="true"
                    TransitionDuration="250"
                    FramesPerSecond="40"
                    RequireOpenedPane="false"
                    SuppressHeaderPostbacks="true">
                    <Panes>
                        <cc1:AccordionPane runat="server" ID="acpnInfoRedd"
                            HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent" Width="100%">
                            <Header>Informaci�n REDD+</Header>
                            <Content>
                                <table>
                                    <tr runat="server" id="tr5">
                                        <td width="20%">
                                            <asp:Label ID="Label17" runat="server" Text="Nombre Proyecto" SkinID="etiqueta_negra">
                                            </asp:Label>
                                            <asp:Label ID="LBLReddID" runat="server" Text="Codifo " SkinID="etiqueta_negra" Visible="false">
                                            </asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNombreProyectoRedds" runat="server" Text="" SkinID="etiqueta_negra">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="tr8">
                                        <td>
                                            <asp:Label ID="Label24" runat="server" Text="Solicitante" SkinID="etiqueta_negra">
                                            </asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSolicitanteRedds" runat="server" Text="" SkinID="etiqueta_negra">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="tr10">
                                        <td>
                                            <asp:Label ID="Label28" runat="server" Text="Ubicaci�n" SkinID="etiqueta_negra">
                                            </asp:Label>
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td width="90%">
                                                        <asp:Label ID="Label29" runat="server" Text="" SkinID="etiqueta_negra">
                                                        </asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:ImageButton runat="server" ID="btnMapaRedd" Visible="false" SkinID="icoMapa" ToolTip="Ubicaci�n geografica" OnClick="btnMapaRedd_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane runat="server" ID="InfoSila"
                            HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent" Width="100%">
                            <Header>Informaci�n</Header>
                            <Content>
                                <div class="col-md-12">
                                    <div class="form-group row" id="trNombreProyecto" runat="server">
                                        <label class="col-sm-2 label-sm label-etiqueta">Nombre Proyecto:</label>
                                        <div class="col-sm-10 label-detalle">
                                            <asp:label class="label-sm" id="lblCodigoExpediente" runat="server" Visible="false"></asp:label>
                                            <asp:label class="label-sm" id="lblNombreProyectoValue" runat="server"></asp:label>
                                        </div>
                                    </div>
                                    <div class="form-group row" id="trDescripcionProyecto" runat="server">
                                        <label class="col-sm-2 label-sm label-etiqueta" id="lblTramite">Descipci�n Proyecto:</label>
                                        <div class="col-sm-10 label-detalle">
                                            <asp:label class="label-sm" id="lblDescripcionProyectoValue" runat="server"></asp:label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-sm-2 label-sm label-etiqueta">Sector:</label>
                                        <div class="col-sm-10 label-detalle">
                                            <asp:label class="label-sm" id="lblSector" runat="server"></asp:label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-sm-2 label-sm label-etiqueta">Solicitante:</label>
                                        <div class="col-sm-10 label-detalle">
                                            <asp:label class="label-sm" id="lblSolicitante" runat="server"></asp:label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-sm-2 label-sm label-etiqueta">Correo electr�nico solicitante:</label>
                                        <div class="col-sm-10 label-detalle">
                                            <asp:label class="label-sm" id="lblCorreoElectronicoSolicitante" runat="server"></asp:label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-sm-2 label-sm label-etiqueta">Ubicaci�n:</label>
                                        <div class="col-sm-10 label-detalle">
                                            <asp:label class="label-sm" id="lblUbicacion" runat="server"></asp:label>
                                            <asp:ImageButton runat="server" ID="btnMapas" Visible="false" SkinID="icoMapa" ToolTip="Ubicaci�n geografica" OnClick="btnMapas_Click" />
                                        </div>
                                    </div>
                                </div>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane runat="server" ID="Calendar"
                            HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent" Width="100%">
                            <Header>Tiempos</Header>
                            <Content>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td valign="middle">
                                                        <asp:ImageButton runat="server" ID="btnAnteriosCalendario" SkinID="icoAnteriorCalendare" OnClick="btnAnteriosCalendario_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Calendar ID="PrimerMes" runat="server" SkinID="CalendarioMisTramites"
                                                            OnDayRender="PrimerMes_DayRender"></asp:Calendar>
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <asp:Calendar ID="SegundoMes" runat="server" SkinID="CalendarioMisTramites"
                                                            OnDayRender="SegundoMes_DayRender"></asp:Calendar>
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <asp:Calendar ID="TercerMes" runat="server" SkinID="CalendarioMisTramites"
                                                            OnDayRender="TercerMes_DayRender"></asp:Calendar>
                                                        <br />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Calendar ID="CuartoMes" runat="server" SkinID="CalendarioMisTramites"
                                                            OnDayRender="CuartoMes_DayRender"></asp:Calendar>
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <asp:Calendar ID="QuintoMes" runat="server" SkinID="CalendarioMisTramites"
                                                            OnDayRender="QuintoMes_DayRender"></asp:Calendar>
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <asp:Calendar ID="SextoMes" runat="server" SkinID="CalendarioMisTramites"
                                                            OnDayRender="SextoMes_DayRender"></asp:Calendar>
                                                        <br />
                                                    </td>
                                                    <td valign="middle">
                                                        <asp:ImageButton runat="server" ID="btnSiguienteCalendario" SkinID="icoSiguienteCalendare" OnClick="btnSiguienteCalendario_Click" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td valign="top">
                                            <asp:GridView runat="server" ID="grvDetalleActual" AutoGenerateColumns="false" ShowHeader="false" SkinID="Grilla_sin_formato" OnRowDataBound="grvDetalles_RowDataBound" OnRowCommand="grvDetalles_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField>

                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="Label8" Text='<%# Eval("NombreDocumento") %>' SkinID="etiqueta_negra9"></asp:Label>
                                                            <asp:Label runat="server" ID="Label9" Text='<%# Eval("FechaEjecucion") %>' SkinID="fecha_noticia"></asp:Label>
                                                            <asp:Label runat="server" ID="lblDocumento" Text='<%# Eval("Documentos") %>' SkinID="fecha_noticia" Visible="false"></asp:Label>
                                                            <asp:Label runat="server" ID="lblNotificado" Text='<%# Eval("NOTIFICADO") %>' SkinID="fecha_noticia" Visible="false"></asp:Label>
                                                            <asp:ImageButton runat="server" ToolTip="Ver Documentos" ID="btnDocs" SkinID="icoDocumento" CommandArgument='<%# Eval("Documentos") %>' CommandName="Documentos" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:GridView runat="server" ID="grvConvenciones1" AutoGenerateColumns="false" ShowHeader="false" OnRowDataBound="grvConvenciones1_RowDataBound" SkinID="Grilla_sin_formato">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblColor" Text='' Width="20px" Height="20px"></asp:Label>
                                                            <asp:Label runat="server" ID="lblColorFondo" Text='<%# Eval("COLOR_FONDO") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblDetalleMovimientos" Text='<%# Eval("Nombre") %>' SkinID="etiqueta_negra"></asp:Label>
                                                            <asp:Label runat="server" ID="Label10" Text='(' SkinID="etiqueta_negra"></asp:Label>
                                                            <asp:Label runat="server" ID="lblDescripcionEstado" Text='<%# Eval("Descripcion_Estado") %>' SkinID="etiqueta_negra"></asp:Label>
                                                            <asp:Label runat="server" ID="Label11" Text=')' SkinID="etiqueta_negra"></asp:Label>
                                                            <asp:Image runat="server" ID="imgEstado"></asp:Image>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </Content>
                        </cc1:AccordionPane>
                        <cc1:AccordionPane runat="server" ID="Calendar2"
                            HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected" Width="100%"
                            ContentCssClass="accordionContent">
                            <Header>Informacion Agrupada</Header>
                            <Content>
                                <cc1:TabContainer ID="tbcDetalles" runat="server" Width="100%" ActiveTabIndex="0" AutoPostBack="false" Style="width: 100% !important;" class="tabs">
                                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="headerSol" SkinID="etiqueta_negra10" runat="server" Text="Solicitud"></asp:Label>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <br />
                                            <asp:GridView OnSorting="grdFUS_onSorting" AllowSorting="True"
                                                ID="grdFUS" runat="server" EnableTheming="false" CssClass="tabla_datos"
                                                Width="100%" BorderStyle="Solid" BorderWidth="1px"
                                                GridLines="Vertical"
                                                CellPadding="0" 
                                                AutoGenerateColumns="False"
                                                OnRowDataBound="grdFUS_RowDataBound"  DataKeyNames="RUTA">
                                                 <%--<FooterStyle Font-Size="9pt" ForeColor="#000000" CssClass="texto_tablas_paginador" />
                                                <RowStyle Font-Size="9pt" ForeColor="#000000" />
                                                <SelectedRowStyle Font-Size="9pt" ForeColor="#000000" />
                                                <EditRowStyle Font-Size="9pt" ForeColor="#000000" />
                                                <AlternatingRowStyle Font-Size="9pt" ForeColor="#000000" />--%>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Tipo de Usuario">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <img src='<%# (
                                                                Eval("idparticipant").ToString().ToLower().IndexOf("/imagenesreportes/") > -1 ?
                                                                Eval("idparticipant").ToString().Substring(Eval("idparticipant").ToString().ToLower().IndexOf("imagenesreportes/")+17)
                                                                    .Split(".".ToCharArray())[0]
                                                                :
                                                                Eval("idparticipant") )%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha Solicitud" SortExpression="SOL_FECHA_CREACION" >
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("SOL_FECHA_CREACION", "{0:dd/MM/yyyy}") %>' SkinID="etiqueta_negra"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci�n" SortExpression="DESCRIPCION">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RUTA" HeaderText="RUTA" Visible="False"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="Documentos">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbDocumentos" runat="server" Text="Ver Documentos" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' OnCommand="lbDocumentos_Click"></asp:LinkButton>
                                                            <asp:Label ID="lbEntryData" runat="server" Text='<%# Eval("EntryData")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lbIdEntryData" runat="server" Text='<%# Eval("IdEntryData")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lbEntryDataType" runat="server" Text='<%# Eval("EntryDataType")%>' Visible="false"></asp:Label>

                                                            <asp:Label ID="lbIdActivityInstance" runat="server" Text='<%# Eval("IdActivity")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lbProcessInstance" runat="server" Text='<%# Eval("IdProcessInstance")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lbRuta" runat="server" Text='<%# Eval("Ruta")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lbUrl" runat="server" Text='<%# Eval("URLDataView")%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lbIdRelated" runat="server" Text='<%# Eval("IdRelated")%>' Visible="false"></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID_EXPEDIENTE" HeaderText="Expediente" SortExpression="ID_EXPEDIENTE">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>

                                                <%--<AlternatingRowStyle BackColor="#CCCCCC"></AlternatingRowStyle>
                                                <FooterStyle BackColor="#CCCCCC"></FooterStyle>
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"></HeaderStyle>
                                                <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>--%>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="headerEval" runat="server" Text="Evaluaci�n" SkinID="etiqueta_negra10"></asp:Label>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <br />
                                            <asp:GridView OnSorting="grdEvaluacion_onSorting"  ID="grdEvaluacion"
                                                OnRowCommand="grdEvaluacion_RowCommand" runat="server" EnableTheming="false" CssClass="tabla_datos"
                                                Width="100%" BorderStyle="Solid" BorderWidth="1px"
                                                GridLines="Vertical"
                                                CellPadding="0" 
                                                AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Tipo de Usuario">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <img src='<%#(
                                                    Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("/imagenesreportes/") > -1 ?
                                                    Eval("URL_PARTICIPANTE").ToString().Substring(Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("imagenesreportes/"))
                                                    :
                                                    Eval("URL_PARTICIPANTE")
                                                    )%>' />

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha" SortExpression="FechaActo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRutaDocumento" runat="server" Text='<%# Eval("DIR") %>' Style="display: none"></asp:Label>
                                                            <span><%# Eval( "FECHA", "{0:dd/MM/yyyy}" )%></span>
                                                            <asp:Label ID="lbArchivo" runat="server" Text='<%# Eval("PATH_DOCUMENTO") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lbArchivo2" runat="server" Text='<%# Eval("RUTAARCHIVO") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" SortExpression="ParteResolutiva"></asp:BoundField>
                                                    <asp:ButtonField CommandName="viewFile" Text="Descargar Archivo"></asp:ButtonField>
                                                    <asp:BoundField DataField="ID_EXPEDIENTE" HeaderText="Id Expediente" SortExpression="ID_EXPEDIENTE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>

                                                <FooterStyle BackColor="#CCCCCC"></FooterStyle>
                                                <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"></HeaderStyle>
                                                <AlternatingRowStyle BackColor="#CCCCCC"></AlternatingRowStyle>

                                            </asp:GridView>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel runat="server" HeaderText="TabPanel3" ID="tbSeguimiento" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="headerSegui" runat="server" Text="Seguimiento" SkinID="etiqueta_negra10"></asp:Label>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <br />
                                            <asp:GridView OnSorting="grdSeguimiento_onSorting" AllowSorting="true" ID="grdSeguimiento" OnRowCommand="grdSeguimiento_RowCommand" runat="server" 
                                                SkinID="grilla" Width="100%" EnableTheming="false" CssClass="tabla_datos"
                                                BorderStyle="Solid" BorderWidth="1px"
                                                GridLines="Vertical"
                                                CellPadding="0"  AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Tipo de Usuario">
                                                        <ItemTemplate>
                                                            <img src='<%#(
                                                    Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("/imagenesreportes/") > -1 ?
                                                    Eval("URL_PARTICIPANTE").ToString().Substring(Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("imagenesreportes/"))
                                                    :
                                                    Eval("URL_PARTICIPANTE")
                                                    )%>' />
                                                            <br />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha" SortExpression="FechaActo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblArchivo" runat="server" Text='<%# Eval("PATH_DOCUMENTO") %>' Style="display: none"></asp:Label>
                                                            <asp:Label ID="lbArchivo2" runat="server" Text='<%# Eval("RUTAARCHIVO") %>' Visible="false"></asp:Label>

                                                            <asp:Label ID="lblRutaDocumento" runat="server" Text='<%# Eval("DIR") %>' Style="display: none"></asp:Label>
                                                            <span><%# Eval( "FECHA", "{0:dd/MM/yyyy}" )%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" SortExpression="ParteResolutiva"></asp:BoundField>
                                                    <asp:ButtonField CommandName="viewFile" Text="Descargar Archivo"></asp:ButtonField>
                                                    <asp:BoundField DataField="ID_EXPEDIENTE" HeaderText="Id Expediente" SortExpression="ID_EXPEDIENTE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>

                                                <FooterStyle BackColor="#CCCCCC"></FooterStyle>
                                                <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>
                                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                                <AlternatingRowStyle BackColor="#CCCCCC"></AlternatingRowStyle>

                                            </asp:GridView>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel runat="server" HeaderText="TabPanel4" ID="TabPanel4" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="headerInvs" runat="server" Text="Investigaci�n" SkinID="etiqueta_negra10"></asp:Label>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <br />
                                            <asp:GridView OnSorting="grdInvestigacion_onSorting" AllowSorting="true" ID="grdInvestigacion" OnRowCommand="grdInvestigacion_RowCommand" runat="server" EnableTheming="false" CssClass="tabla_datos"
                                                Width="100%" BorderStyle="Solid" BorderWidth="1px"
                                                GridLines="Vertical"
                                                CellPadding="0" 
                                                AutoGenerateColumns="False" OnPageIndexChanging="grdInvestigacion_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Tipo de Usuario">
                                                        <ItemTemplate>
                                                            <img src='<%#(
                                                    Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("/imagenesreportes/") > -1 ?
                                                    Eval("URL_PARTICIPANTE").ToString().Substring(Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("imagenesreportes/"))
                                                    :
                                                    Eval("URL_PARTICIPANTE")
                                                    )%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha" SortExpression="FechaActo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblArchivo" runat="server" Text='<%# Eval("PATH_DOCUMENTO") %>' Style="display: none"></asp:Label>
                                                            <asp:Label ID="lbArchivo2" runat="server" Text='<%# Eval("RUTAARCHIVO") %>' Visible="false"></asp:Label>

                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("DIR") %>' Style="display: none"></asp:Label>
                                                            <span><%# Eval( "FECHA", "{0:dd/MM/yyyy}" )%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" SortExpression="ParteResolutiva"></asp:BoundField>
                                                    <asp:ButtonField CommandName="viewFile" Text="Descargar Archivo"></asp:ButtonField>
                                                    <asp:BoundField DataField="ID_EXPEDIENTE" HeaderText="Id Expediente" SortExpression="ID_EXPEDIENTE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel runat="server" HeaderText="TabPanel5" ID="TabPanel5" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="headerCobr" runat="server" Text="Pagos y Cobros" SkinID="etiqueta_negra10"></asp:Label>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <br />
                                            <asp:GridView OnSorting="grdCobros_onSorting" AllowSorting="true" OnRowCommand="grdCobros_RowCommand" ID="grdCobros" runat="server" 
                                                EnableTheming="false" CssClass="tabla_datos"
                                                Width="100%" BorderStyle="Solid" BorderWidth="1px"
                                                GridLines="Vertical"
                                                CellPadding="0" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Tipo de Usuario">
                                                        <ItemTemplate>
                                                            <img src='<%#(
                                                    Eval("IDParticipant").ToString().ToLower().IndexOf("/imagenesreportes/") > -1 ?
                                                    Eval("IDParticipant").ToString().Substring(Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("imagenesreportes/"))
                                                    :
                                                    Eval("IDParticipant")
                                                    )%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="COB_NUMERO_SILPA" HeaderText="N&#250;mero SILPA" SortExpression="COB_NUMERO_SILPA"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="Fecha" SortExpression="COB_FECHA_EXPEDICION">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblArchivo" runat="server" Text='<%# Bind("COB_RUTA_ARCHIVOS") %>' Style="display: none;"></asp:Label>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("COB_FECHA_EXPEDICION", "{0:dd/MM/yyyy HH:mm}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="COB_NUMERO_EXPEDIENTE" HeaderText="Descripci&#243;n" SortExpression="COB_NUMERO_EXPEDIENTE"></asp:BoundField>
                                                    <asp:ButtonField CommandName="viewFile" Text="Descargar Archivo"></asp:ButtonField>
                                                </Columns>
                                                
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel runat="server" HeaderText="TabPanel6" ID="TabPanel3" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="headerOtro" runat="server" Text="Otros" SkinID="etiqueta_negra10"></asp:Label>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <br />
                                                
                                            <asp:GridView OnSorting="grdOtros_onSorting" AllowSorting="true" ID="grdOtros" OnRowCommand="grdOtros_RowCommand" runat="server" EnableTheming="false" CssClass="tabla_datos"
                                                Width="100%" BorderStyle="Solid" BorderWidth="1px"
                                                GridLines="Vertical"
                                                CellPadding="0" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Tipo de Usuario">
                                                        <ItemTemplate>
                                                            <img src='<%#(
                                                    Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("/imagenesreportes/") > -1 ?
                                                    Eval("URL_PARTICIPANTE").ToString().Substring(Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("imagenesreportes/"))
                                                    :
                                                    Eval("URL_PARTICIPANTE")
                                                    )%>' />
                                                            <br />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha" SortExpression="FechaActo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblArchivo" runat="server" Text='<%# Eval("PATH_DOCUMENTO") %>' Style="display: none"></asp:Label>
                                                            <asp:Label ID="lbArchivo2" runat="server" Text='<%# Eval("RUTAARCHIVO") %>' Visible="false"></asp:Label>

                                                            <asp:Label ID="lblRutaDocumento" runat="server" Text='<%# Eval("DIR") %>' Style="display: none"></asp:Label>
                                                            <span><%# Eval( "FECHA", "{0:dd/MM/yyyy}" )%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" SortExpression="ParteResolutiva"></asp:BoundField>
                                                    <asp:ButtonField CommandName="viewFile" Text="Descargar Archivo"></asp:ButtonField>
                                                    <asp:BoundField DataField="ID_EXPEDIENTE" HeaderText="Id Expediente" SortExpression="ID_EXPEDIENTE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>

                                                
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel runat="server" HeaderText="TabPanel7" ID="TabPanel7" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="HeaderReposicion" runat="server" Text="Reposicion" SkinID="etiqueta_negra10"></asp:Label>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <br />
                                            <asp:Label ID="Label5" runat="server" Text="Numeros Vitales Recursos de Reposici�n Asociados"></asp:Label>
                                            <asp:GridView Style="text-align: center" ID="grdAsocRep" OnRowCommand="grdAsocRep_RowCommand" runat="server" Width="100%" EnableTheming="false" CssClass="tabla_datos"
                                                BorderStyle="Solid" BorderWidth="1px"
                                                GridLines="Vertical"
                                                CellPadding="0" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="N�mero VITAL" SortExpression="NUMERO_VITAL">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lblNumeroVITAL" runat="server" CommandName="Editar" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' Text='<%# Eval("NUMERO_VITAL") %>'></asp:LinkButton>
                                                            <asp:Label ID="lblIdUser" runat="server" Text='<%# Eval("PER_ID") %>' Style="display: none"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView OnSorting="grdRepos_onSorting" AllowSorting="true" ID="grdRepos" OnRowCommand="grdRepos_RowCommand" runat="server" EnableTheming="false" CssClass="tabla_datos"
                                                Width="100%" BorderStyle="Solid" BorderWidth="1px"
                                                GridLines="Vertical"
                                                CellPadding="0" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Tipo de Usuario">
                                                        <ItemTemplate>
                                                            <img src='<%#(
                                                    Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("/imagenesreportes/") > -1 ?
                                                    Eval("URL_PARTICIPANTE").ToString().Substring(Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("imagenesreportes/"))
                                                    :
                                                    Eval("URL_PARTICIPANTE")
                                                    )%>' />
                                                            <br />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha" SortExpression="FechaActo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblArchivo" runat="server" Text='<%# Eval("PATH_DOCUMENTO") %>' Style="display: none"></asp:Label>
                                                            <asp:Label ID="lbArchivo2" runat="server" Text='<%# Eval("RUTAARCHIVO") %>' Visible="false"></asp:Label>

                                                            <asp:Label ID="lblRutaDocumento" runat="server" Text='<%# Eval("DIR") %>' Style="display: none"></asp:Label>
                                                            <span><%# Eval( "FECHA", "{0:dd/MM/yyyy}" )%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" SortExpression="ParteResolutiva"></asp:BoundField>
                                                    <asp:ButtonField CommandName="viewFile" Text="Descargar Archivo"></asp:ButtonField>
                                                    <asp:BoundField DataField="ID_EXPEDIENTE" HeaderText="Id Expediente" SortExpression="ID_EXPEDIENTE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel runat="server" HeaderText="TabPanel3" ID="TabPanel6" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="headerModificacion" runat="server" Text="Modificaci�n" SkinID="etiqueta_negra10"></asp:Label>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <br />
                                            <asp:GridView OnSorting="grdModificacion_onSorting" AllowSorting="true" ID="grdModificacion" OnRowCommand="grdOtros_RowCommand" runat="server" EnableTheming="false" CssClass="tabla_datos"
                                                Width="100%" BorderStyle="Solid" BorderWidth="1px"
                                                GridLines="Vertical"
                                                CellPadding="0" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Tipo de Usuario">
                                                        <ItemTemplate>
                                                            <img src='<%#(
                                                    Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("/imagenesreportes/") > -1 ?
                                                    Eval("URL_PARTICIPANTE").ToString().Substring(Eval("URL_PARTICIPANTE").ToString().ToLower().IndexOf("imagenesreportes/"))
                                                    :
                                                    Eval("URL_PARTICIPANTE")
                                                    )%>' />
                                                            <br />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha" SortExpression="FechaActo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblArchivo" runat="server" Text='<%# Eval("PATH_DOCUMENTO") %>' Style="display: none"></asp:Label>
                                                            <asp:Label ID="lbArchivo2" runat="server" Text='<%# Eval("RUTAARCHIVO") %>' Visible="false"></asp:Label>

                                                            <asp:Label ID="lblRutaDocumento" runat="server" Text='<%# Eval("DIR") %>' Style="display: none"></asp:Label>
                                                            <span><%# Eval( "FECHA", "{0:dd/MM/yyyy}" )%></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" SortExpression="ParteResolutiva"></asp:BoundField>
                                                    <asp:ButtonField CommandName="viewFile" Text="Descargar Archivo"></asp:ButtonField>
                                                    <asp:BoundField DataField="ID_EXPEDIENTE" HeaderText="Id Expediente" SortExpression="ID_EXPEDIENTE">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                </cc1:TabContainer>
                                <table style="margin: 10px !important;">
                                    <tr>
                                        <td width="10%">
                                            <asp:Image ID="imgSolicitantel" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lbSolicitante" Text="Documento ingresado por Solicitante" runat="server" SkinID="etiqueta_negra"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Image ID="imgAutAmb" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" Text="Documento ingresado por Autoridad Ambiental" runat="server" SkinID="etiqueta_negra"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Image ID="imgEntExt" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" Text="Documento ingresado por Entidad Externa" runat="server" SkinID="etiqueta_negra"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Image ID="imgPDIl" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" Text="Documento ingresado por PDI" runat="server" SkinID="etiqueta_negra"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label7" Text="" runat="server" ForeColor="red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                </table>
                            </Content>
                        </cc1:AccordionPane>
                    </Panes>
                </cc1:Accordion>
        </div>
    </div>
    <div class="row col-md-4 botones">
        <div class="col-md-6">
            <asp:Button ID="btnAtras" runat="server" Text="Atras" OnClientClick="cerrar()" CssClass="boton-secundario"></asp:Button>
        </div>
        <div class="col-md-6">
            <asp:Button ID="Button1" runat="server" OnClick="btnMisTra_Click" Text="Mis Tramites" CssClass="boton-principal"/>
        </div>
    </div>
</div>
