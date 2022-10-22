<%@ Page Language="C#" MasterPageFile="~/plantillas/SILPABuscador.master" AutoEventWireup="true" CodeFile="ActualizarFechaSancion.aspx.cs" Inherits="RUIA_ActualizarFechaSancion" Title="Actualizar Fecha sanción" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Resources/Bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/jquery.datetimepicker.css" rel="stylesheet" />
    <link rel="stylesheet" href="../Resources/Buscador/css/buscadorVITAL.css" />
    <link href="../Resources/EstilosBase/css/tabs-nuevas.css" rel="stylesheet" />

    <script src='<%= ResolveClientUrl("~/Resources/jquery/3.2.1/jquery.min.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Resources/jquery/fontsize/js/jquery.jfontsize-1.0.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Resources/Bootstrap/5.0.1/js/bootstrap.min.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Scripts/jquery.datetimepicker.js") %>' type="text/javascript"></script>
     <script src='<%= ResolveClientUrl("~/Resources/RUIA/ActualizarFechaSancion.js") %>'></script>
    <style type="text/css">
        label {
            font-weight: 400;
        }
        table tr td {
            border: 0px solid #ddd !important;
            padding: 4px;
        }
    </style>
    <asp:ScriptManager ID="scmManejador" runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <div class="row">
        <div class="titulo_pagina">
            Actualización de fecha de sanción
        </div>
    </div>
    <asp:UpdatePanel ID="uppPanelPublicaciones" runat="server">
        <ContentTemplate>
            <div class="table-responsive">
                <asp:GridView ID="grdSanciones" runat="server" CssClass="RadGridVITAL"
                                    OnRowCreated="grdSanciones_RowCreated" 
                                    OnPageIndexChanging="grdSanciones_PageIndexChanging" 
                                    EmptyDataText="No Existen Registros Sin Fecha de Sancion" 
                                    OnRowCancelingEdit="grdSanciones_RowCancelingEdit" 
                                    OnRowEditing="grdSanciones_RowEditing" 
                                    OnRowUpdating="grdSanciones_RowUpdating" 
                                    
                                    DataKeyNames="SAN_ID_SANCION" 
                                    AutoGenerateColumns="False" Width="100%">
                                    <HeaderStyle CssClass="rgHeader" />
                                    <FooterStyle Font-Size="9pt" ForeColor="#000000" />
                                    <RowStyle CssClass="rgRow" />
                                    <SelectedRowStyle Font-Size="9pt" ForeColor="#000000" />
                                    <EditRowStyle Font-Size="9pt" ForeColor="#000000" />
                                    <AlternatingRowStyle CssClass="rgRow" />
                                    <Columns>
                                        <asp:BoundField DataField="SAN_ID_SANCION" ReadOnly="true">
	                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
	                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="9pt" ForeColor="#000000" />
	                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AUT_NOMBRE" HeaderText="Autoridad Ambiental" Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="SAN_NUMERO_EXPE" HeaderText="N&#250;mero de Expediente" ReadOnly="true">
	                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
	                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="9pt" ForeColor="#000000" />
	                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SAN_NUMERO_ACTO" ReadOnly="true" HeaderText="N&#250;mero de Acto que impone sanci&#243;n ">
	                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
	                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="9pt" ForeColor="#000000" />
	                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TIF_NOMBRE" HeaderText="Tipo de Falta" ReadOnly="true">
	                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
	                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="9pt" ForeColor="#000000" />
	                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OPS_NOMBRE_OPCION" ReadOnly="true" HeaderText="Tipo de Sanci&#243;n">
	                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
	                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="9pt" ForeColor="#000000" />
	                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NOMBRES" ReadOnly="true" HeaderText="Nombre de la Persona Sancionada">
	                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
	                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="9pt" ForeColor="#000000" />
	                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Fecha de Cumplimiento de la Sanci&#243;n">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtFechaEjecucion" runat="server"  Text='<%# Bind("SAN_FECHA_EJECUCION_ACTO","{0:dd/MM/yyyy}") %>' MaxLength="10" class="form-control textbox-calendar"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvFechaEjecucion" runat="server"  Display="Dynamic" ErrorMessage="Ingrese fecha de ejecución o cuplimiento de la sanción" ControlToValidate="txtFechaEjecucion">*</asp:RequiredFieldValidator>
                                                <asp:Label ID="lblSancionPrincipal" runat="server" Text='<%# Bind("RSA_ID_OPCION") %>' Visible="False"  SkinID="etiqueta_negra9"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaCumplimiento" runat="server" Text='<%# Bind("SAN_FECHA_EJECUCION_ACTO","{0:dd/MM/yyyy}") %>' SkinID="etiqueta_negra9"></asp:Label>
                                            </ItemTemplate>
	                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
	                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9pt" ForeColor="#000000" />
	                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False">
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lnkGuardar" runat="server" Text="Guardar" CausesValidation="false" CommandName="UPDATE"></asp:LinkButton>
                                                <asp:LinkButton ID="lnkCancelar" runat="server" Text="Cancelar" CausesValidation="false" CommandName="CANCEL"></asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkActualizar" runat="server" Text="Actualizar" CausesValidation="false" CommandName="EDIT"></asp:LinkButton>
                                            </ItemTemplate>
	                                        <HeaderStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
	                                        <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
	                                        <FooterStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                </div>
            <div class="row col-md-4 botones">
                <div class="col-md-6">
                    <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" CssClass="boton-principal" Text="Regresar" ValidationGroup="xxx" OnClientClick="return cancelarRUIA();"></asp:Button>
                </div>
                <asp:ValidationSummary ID="valResumen" runat="server"></asp:ValidationSummary>
            </div>    
            
                                
            
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

