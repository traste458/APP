<%@ Page Language="C#" MasterPageFile="~/plantillas/SILPABuscador.master" AutoEventWireup="true" CodeFile="ConsultarSancion.aspx.cs" Inherits="RUIA_ConsultarSancion" Title="RUIA Consulta de Infracciones o Sanciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../Resources/Bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/jquery.datetimepicker.css" rel="stylesheet" />
    <link rel="stylesheet" href="../Resources/Buscador/css/buscadorVITAL.css" />

    <script src='<%= ResolveClientUrl("~/Resources/jquery/3.2.1/jquery.min.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Resources/jquery/fontsize/js/jquery.jfontsize-1.0.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Resources/Bootstrap/5.0.1/js/bootstrap.min.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Scripts/jquery.datetimepicker.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Resources/RUIA/ConsultaSancion.js") %>'></script>
    

    <script src='<%= ResolveClientUrl("~/js/dropdownWidth.js") %>' type="text/javascript"></script>
    <asp:ScriptManager runat="server" ID="scriptManager1"></asp:ScriptManager>
    <style type="text/css">
     
        .inner-addon {
            position: relative;
        }
            /* style glyph */
            .inner-addon .glyphicon {
                position: absolute;
                padding: 10px;
                pointer-events: none;
            }

        .right-addon .glyphicon {
            right: 0px;
        }

        .right-addon input {
            padding-right: 30px;
        }

        /*.row {*/
        /*margin-top: 40px;
            padding: 0 10px;
        }*/

        .clickable {
            cursor: pointer;
        }

        #panel, #flip {
            padding: 5px;
            text-align: center;
            background-color: #e5eecc;
            border: solid 1px #c3c3c3;
            position: relative;
        }

        #panel {
            position: relative;
            top: 0;
            width: 5px;
            height: 10%;
            padding: 20px;
            background-color: #333;
            color: #fff;
            box-shadow: inset 0 0 5px 5px #222;
        }

        .label-xsm {
            font-size: 12px;
            color: dimgray;
            /*line-height: 5px;*/
        }

        .lbl-sm {
            font-size: 12px;
            color: black;
        }

        .lbl-title {
            font-size: 14px;
            color: darkred;
            text-decoration: underline;
        }

        .lbl-xsm {
            font-size: 12px;
            /*line-height: 10px;*/
            color: dimgray;
        }

        .containerTab {
            /*width: 97%;*/
        }

        #exTab2 h3 {
            color: white;
            background-color: #f9fcfd; /*#c4dce4;*/
            padding: 5px 15px;
        }

        #exTab2 .nav-pills > li > a {
            border-radius: 4px 4px 0 0;
        }


        .navBar {
            height: 50px;
            padding-right: 80px;
        }

        #helpIcon {
            cursor: pointer;
            /*padding-top: 12px;*/
        }

        .spnClose {
            float: left;
            font-size: 21px;
            font-weight: 700;
            line-height: 1;
            color: #000;
            text-shadow: 0 1px 0 #fff;
            filter: alpha(opacity=20);
            opacity: .2;
        }

        .spnImagenLogo {
            float: right;
            font-size: 9px;
            line-height: 3;
            color: #000;
            text-shadow: 0 1px 0 #fff;
            /*opacity: .2;*/
            display: block;
        }

        .box {
            position: relative;
            height: 98%;
            width: 98%;
            border: solid 1px #8c8d8e;
            overflow: auto;
            overflow-y: scroll;
            background-color: #ffffff;
        }

        body.loading {
            overflow: hidden;
        }

            /* Anytime the body has the loading class, our
   modal element will be visible */
            body.loading .modal {
                display: block;
            }
    </style>
    <style>

        .tabbable-panel {
            border: 1px solid #eee;
            padding: 10px;
        }

        /* Default mode */
        .tabbable-line > .nav-tabs {
            border: none;
            margin: 0px;
        }

            .tabbable-line > .nav-tabs > li {
                margin-right: 2px;
            }

                .tabbable-line > .nav-tabs > li > a {
                    border: 0;
                    margin-right: 0;
                    color: #737373;
                }

                    .tabbable-line > .nav-tabs > li > a > i {
                        color: #a6a6a6;
                    }

                .tabbable-line > .nav-tabs > li.open, .tabbable-line > .nav-tabs > li:hover {
                    border-bottom: 4px solid #fbcdcf;
                }

                    .tabbable-line > .nav-tabs > li.open > a, .tabbable-line > .nav-tabs > li:hover > a {
                        border: 0;
                        background: none !important;
                        color: #333333;
                    }

                        .tabbable-line > .nav-tabs > li.open > a > i, .tabbable-line > .nav-tabs > li:hover > a > i {
                            color: #a6a6a6;
                        }

                    .tabbable-line > .nav-tabs > li.open .dropdown-menu, .tabbable-line > .nav-tabs > li:hover .dropdown-menu {
                        margin-top: 0px;
                    }

                .tabbable-line > .nav-tabs > li.active {
                    border-bottom: 4px solid #f3565d;
                    position: relative;
                }

                    .tabbable-line > .nav-tabs > li.active > a {
                        border: 0;
                        color: #333333;
                    }

                        .tabbable-line > .nav-tabs > li.active > a > i {
                            color: #404040;
                        }

        .tabbable-line > .tab-content {
            margin-top: -3px;
            background-color: #fff;
            border: 0;
            border-top: 1px solid #eee;
            padding: 15px 0;
        }

        .portlet .tabbable-line > .tab-content {
            padding-bottom: 0;
        }

        /* Below tabs mode */

        .tabbable-line.tabs-below > .nav-tabs > li {
            border-top: 4px solid transparent;
        }

            .tabbable-line.tabs-below > .nav-tabs > li > a {
                margin-top: 0;
            }

            .tabbable-line.tabs-below > .nav-tabs > li:hover {
                border-bottom: 0;
                border-top: 4px solid #fbcdcf;
            }

            .tabbable-line.tabs-below > .nav-tabs > li.active {
                margin-bottom: -2px;
                border-bottom: 0;
                border-top: 4px solid #f3565d;
            }

        .tabbable-line.tabs-below > .tab-content {
            margin-top: -10px;
            border-top: 0;
            border-bottom: 1px solid #eee;
            padding-bottom: 15px;
        }

        .highlight {
            font-weight: bold;
            color: green;
        }
    </style>

    <asp:UpdatePanel ID="uppPanelPublicaciones" runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="titulo_pagina">
                    Consulta de infracciones o sanciones
                </div>
            </div>

            <div class="row resultados">
                <div class="Subtitulo">
                    Información General
                </div>
                 <hr />
                <div class="row">
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <label for="cboAutoridadAmbiental">Autoridad Ambiental</label>
                            <asp:DropDownList ID="cboAutoridadAmbiental" runat="server" class="form-control">
                                <asp:ListItem Value="-1">Seleccione...</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="cboTipoFalta">Tipo de Infracción</label>
                            <asp:DropDownList ID="cboTipoFalta" runat="server" class="form-control">
                                <asp:ListItem Value="-1">Seleccione...</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="cboSancionAplicada">Tipo de Sanción</label>
                            <asp:DropDownList ID="cboSancionAplicada" runat="server" class="form-control">
                                <asp:ListItem Value="-1">Seleccione...</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="txtNumeroExpediente">Número de Expediente</label>
                            <asp:TextBox ID="txtNumeroExpediente" runat="server" class="form-control" placeholder="Número de Expediente"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="txtNumeroActo">Número de Acto que impone sanción</label>
                            <asp:TextBox ID="txtNumeroActo" runat="server" class="form-control" placeholder="Número de Acto que impone sanción"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="txtNombreResponsable">Nombre de la persona o razón social sancionada</label>
                            <asp:TextBox ID="txtNombreResponsable" runat="server" class="form-control" placeholder="Nombre de la persona o razón social sancionada"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="txtNumeroDocumento">Número Documento de la persona o razón social</label>
                            <asp:TextBox ID="txtNumeroDocumento" runat="server" class="form-control" placeholder="Número Documento de la persona o razón social"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row" runat="server" id="seccionMaestro" visible="true">
                        <div class="form-group col-md-12">
                            <label for="cboEstadoSancion">Estado Sancion</label>
                            <asp:DropDownList ID="cboEstadoSancion" runat="server" class="form-control">
                                <asp:ListItem Text="Todos" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Activo" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Eliminados" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="Subtitulo">
                    Fecha de Sanción
                </div>
                <hr />
                <div class="row">
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="txtFechaDesde">Desde</label>
                            <asp:TextBox ID="txtFechaDesde" runat="server" MaxLength="10" class="form-control textbox-calendar"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="txtFechaHasta">Hasta</label>
                            <asp:TextBox ID="txtFechaHasta" runat="server" class="form-control textbox-calendar"></asp:TextBox>
                            <asp:CompareValidator ID="covCompararFechas" runat="server" ControlToValidate="txtFechaHasta"
                                ErrorMessage='El valor del campo "Fecha Hasta", debe ser posterior al valor del campo "Fecha Desde".' Display="Dynamic"
                                Type="Date" Operator="GreaterThan" ControlToCompare="txtFechaDesde">*</asp:CompareValidator>
                        </div>
                    </div>
                </div>
                <div class="Subtitulo">
                    Lugar de Ocurrencia de los Hechos
                </div>
                <hr />
                <div class="row">
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="cboDepartamento">Departamento</label>
                            <asp:DropDownList ID="cboDepartamento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboDepartamento_SelectedIndexChanged" class="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqDepartamento" runat="server" ControlToValidate="cboDepartamento"
                                ErrorMessage="Seleccione el departamento de ocurrencia" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="cboMunicipio">Municipio</label>
                            <asp:DropDownList ID="cboMunicipio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboMunicipio_SelectedIndexChanged" class="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqMunicipio" runat="server" ControlToValidate="cboMunicipio"
                                ErrorMessage="Seleccione el municipio de ocurrencia de los hechos" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-6">
                            <label for="cboCorregimiento">Corregimiento</label>
                            <asp:DropDownList ID="cboCorregimiento" runat="server" OnSelectedIndexChanged="cboCorregimiento_SelectedIndexChanged" class="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="cboVereda">Vereda</label>
                            <asp:DropDownList ID="cboVereda" runat="server" AutoPostBack="True" class="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row col-md-4 botones">
                    <div class="col-md-6">
                        <asp:Button runat="server" id="btn_limpiar" Text="Limpiar" CssClass="boton-secundario"></asp:Button>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblConsulta" runat="server" Visible="False" SkinID="etiqueta_negra">0</asp:Label>
                        <asp:Button runat="server" id="btn_buscar"  Text="Buscar" CssClass="boton-principal" OnClick="btnConsultar_Click"></asp:Button>
                    </div>
                    <asp:ValidationSummary ID="valResumen" runat="server"></asp:ValidationSummary>
                </div>
                <div class="row">
                    <hr />
                    <asp:HyperLink Text="Aquí" NavigateUrl="" runat="server" ID="HlnkRUIA" Target="_blank" ToolTip="Para ingresar de click"></asp:HyperLink>
                    <hr />
                </div>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="grdSanciones" runat="server" CssClass="RadGridVITAL" Width="100%" 
                                    DataKeyNames="SAN_ID_SANCION" AutoGenerateColumns="False" 
                                    OnRowDeleting="grdSanciones_RowDeleting" 
                                    OnRowUpdating="grdSanciones_RowUpdating"
                                    OnRowCommand="grdSanciones_RowCommand" 
                                    OnDataBound="grdSanciones_DataBound" 
                                    OnPageIndexChanging="grdReporte_PageIndexChanging"
                                    EmptyDataText="No Existen Registros de Sanciones."
                                    EnableTheming="false">
                                    <HeaderStyle CssClass="rgHeader" />
                                    <FooterStyle Font-Size="9pt" ForeColor="#000000" />
                                    <RowStyle CssClass="rgRow" />
                                    <SelectedRowStyle Font-Size="9pt" ForeColor="#000000" />
                                    <EditRowStyle Font-Size="9pt" ForeColor="#000000" />
                                    <AlternatingRowStyle CssClass="rgRow" />
                                    <Columns>
                                        <asp:BoundField DataField="SAN_ID_SANCION"></asp:BoundField>
                                        <asp:BoundField DataField="AUT_NOMBRE" HeaderText="Autoridad Ambiental"></asp:BoundField>
                                        <asp:BoundField DataField="TIF_NOMBRE" HeaderText="Tipo de Falta"></asp:BoundField>
                                        <asp:BoundField DataField="OPS_NOMBRE_OPCION" HeaderText="Tipo de Sanci&#243;n"></asp:BoundField>
                                        <asp:BoundField DataField="LUGAR_OCURRENCIA" HeaderText="Lugar de Ocurrencia"></asp:BoundField>
                                        <asp:BoundField DataField="SAN_NUMERO_EXPE" HeaderText="N&#250;mero de Expediente"></asp:BoundField>
                                        <asp:BoundField DataField="SAN_NUMERO_ACTO" HeaderText="N&#250;mero de Acto que impone sanci&#243;n " Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="NOMBRES" HeaderText="Nombre de la Persona o Raz&#243;n Social "></asp:BoundField>
                                        <asp:ButtonField CommandName="VerDetalle" Text="Ver Detalle" ControlStyle-CssClass="a_green"></asp:ButtonField>
                                        <asp:ButtonField CommandName="UPDATE" Text="Modificar" ControlStyle-CssClass="a_blue"></asp:ButtonField>
                                        <asp:ButtonField CommandName="DELETE" Text="Eliminar" ControlStyle-CssClass="a_red"></asp:ButtonField>
                                    </Columns>
                                </asp:GridView>
                <asp:Label ID="lblContador" runat="server" Visible="false" SkinID="etiqueta_negra10" Font-Bold="true"></asp:Label>
               
            </div>
           
        </ContentTemplate>
    </asp:UpdatePanel>

    <table border="0" style="left: 0 !important; margin: 0 !important; padding: 0 !important; display: none;">
        <tr>
            <td style="text-align: right; width: 100%;">
                <asp:ImageButton id="btnRegresar2" onclick="btnRegresar_Click" runat="server" SkinID="icoAtras" ToolTip="Regresar" CausesValidation="False" Visible="false"></asp:ImageButton>
            </td>
        </tr>
    </table>
    <input type="button" runat="server" id="cmdAbrir" style="display:none;" />
    <cc1:ModalPopupExtender ID="mpeDetalles" runat="server" TargetControlID="cmdAbrir" PopupControlID="dvDetalles" BackgroundCssClass="modalBackground"/>
    
     <div id="dvDetalles" style="display:none;" runat="server" clientidmode="Static" class="ContenedorModal">  
         <asp:UpdatePanel runat="server" ID="upnlDetalles" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="row resultados">
                    <div class="Subtitulo">
                        Detalle de la Infracción o Sanción
                        <asp:ImageButton ID="ImageButton2" OnClick="btnCerrar_Click" runat="server"  ToolTip="Cerrar ventana" CausesValidation="False" Width="18px" Height="18px" Style="cursor: pointer !important;" ImageUrl="~/App_Themes/Img/iconos/close.png"
                            CssClass="pull-right"></asp:ImageButton>
                    </div>
                    <hr />
                    <div class="row">
                        <asp:DetailsView ID="dvwSancion" runat="server" Visible="False" CssClass="RadGridVITAL"  Width="100%" AutoGenerateRows="False" Height="50px">
                            <RowStyle CssClass="rgRow" />
                            <Fields>
                                <asp:BoundField DataField="SAN_ID_SANCION" HeaderText="C&#243;digo"></asp:BoundField>
                                <asp:BoundField DataField="AUT_NOMBRE" HeaderText="Autoridad Ambiental"></asp:BoundField>
                                <asp:BoundField DataField="TIF_NOMBRE" HeaderText="Tipo de Infracción"></asp:BoundField>
                                <asp:BoundField DataField="SAN_DESCRIPCION_NORMA" HeaderText="Descripción de la norma específica"></asp:BoundField>
                                <asp:BoundField DataField="DEP_NOMBRE" HeaderText="Departamento Ocurrencia"></asp:BoundField>
                                <asp:BoundField DataField="MUN_NOMBRE" HeaderText="Municipio Ocurrencia"></asp:BoundField>
                                <asp:BoundField DataField="COR_NOMBRE" HeaderText="Corregimiento Ocurrencia"></asp:BoundField>
                                <asp:BoundField DataField="VER_NOMBRE" HeaderText="Vereda Ocurrencia"></asp:BoundField>
                                <asp:BoundField DataField="OPS_NOMBRE_OPCION" HeaderText="Tipo de Sanción Principal"></asp:BoundField>
                                <asp:BoundField DataField="SANCION_ACCESORIA" HeaderText="Tipo Sanción Accesoria"></asp:BoundField>
                                <asp:BoundField DataField="SAN_NUMERO_EXPE" HeaderText="N&#250;mero de Expediente"></asp:BoundField>
                                <asp:BoundField DataField="SAN_NUMERO_ACTO" HeaderText="Número de Acto que impone sanción"></asp:BoundField>
                                <asp:BoundField DataField="SAN_FECHA_EXPEDICION_ACTO" DataFormatString="{0:yyyy/MM/dd}" HeaderText="Fecha de expedici&#243;n del acto administrativo"></asp:BoundField>
                                <asp:BoundField DataField="SAN_FECHA_EJECUTORIA_ACTO" DataFormatString="{0:yyyy/MM/dd}" HeaderText="Fecha de ejecutoria del Acto que impone sanci&#243;n"></asp:BoundField>
                                <asp:BoundField DataField="SAN_FECHA_EJECUCION_ACTO" DataFormatString="{0:yyyy/MM/dd}" HeaderText="Fecha de cumplimiento o ejecuci&#243;n de la sanci&#243;n"></asp:BoundField>
                                <asp:BoundField DataField="SAN_RAZON_SOCIAL" HeaderText="Raz&#243;n Social"></asp:BoundField>
                                <asp:BoundField DataField="SAN_NIT" HeaderText="Nit"></asp:BoundField>
                                <asp:BoundField DataField="SAN_PRIMER_NOMBRE" HeaderText="Primer Nombre"></asp:BoundField>
                                <asp:BoundField DataField="SAN_SEGUNDO_NOMBRE" HeaderText="Segundo Nombre"></asp:BoundField>
                                <asp:BoundField DataField="SAN_PRIMER_APELLIDO" HeaderText="Primer Apellido"></asp:BoundField>
                                <asp:BoundField DataField="SAN_SEGUNDO_APELLIDO" HeaderText="Segundo Apellido"></asp:BoundField>
                                <asp:BoundField DataField="TID_NOMBRE" HeaderText="Tipo de documento"></asp:BoundField>
                                <asp:BoundField DataField="SAN_NUMERO_IDENTIFICACION" HeaderText="N&#250;mero de Identificaci&#243;n"></asp:BoundField>
                                <asp:BoundField DataField="SAN_FECHA_HASTA" DataFormatString="{0:yyyy/MM/dd}" HeaderText="Fecha de Desfijaci&#243;n"></asp:BoundField>
                                <asp:BoundField DataField="SAN_DESCRIPCION_DESF" HeaderText="Descripción de la Desfijación de la publicación"></asp:BoundField>
                                <asp:BoundField DataField="SAN_OBSERVACIONES" HeaderText="Observaciones"></asp:BoundField>
                            </Fields>
                        </asp:DetailsView>
                    </div>
                </div>
                </ContentTemplate>
         </asp:UpdatePanel>
         </div>
                                
                            
     <asp:Panel ID="pnlEliminar" runat="server" Visible="False" Width="100%">
                                <table style="left: 0 !important; margin: 0 !important; padding: 0 !important; width: 100%;">
                                    <tr>
                                        <td style="text-align: left; vertical-align: middle;">
                                            <asp:Label ID="lblMotivoValidacion" runat="server" SkinID="etiqueta_negra" Text="Por favor ingrese el motivo por el cual desea eliminar la publicación:"></asp:Label>
                                            <asp:Label ID="lblId" runat="server" SkinID="etiqueta_negra" Visible="False"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" SkinID="etiqueta_negra" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; vertical-align: middle;">
                                            <asp:TextBox ID="txtMotivoEliminacion" runat="server" SkinID="texto" Width="80%" ValidationGroup="eliminar" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvMotivoEliminacion" runat="server" ErrorMessage="El motivo de eliminación de la publicación es requerido" ControlToValidate="txtMotivoEliminacion" ValidationGroup="eliminar">*
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center; vertical-align: middle;">
                                            <asp:Button ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" SkinID="boton_copia" Text="Aceptar" ValidationGroup="eliminar"></asp:Button>
                                            <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" SkinID="boton_copia" Text="Cancelar" ValidationGroup="eliminar" CausesValidation="False"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; vertical-align: middle;">
                                            <asp:ValidationSummary ID="vasEliminar" runat="server" ValidationGroup="eliminar" DisplayMode="SingleParagraph" ShowMessageBox="True"></asp:ValidationSummary>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>


    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="uppPanelPublicaciones">
        <ProgressTemplate>  
            <div id="ModalProgressContainer">
                <div id="container-loader" class="container-loader-buscadorVITAL"></div>
                <div id="loader" class="loader-buscadorVITAL"></div
            </div>                         
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

