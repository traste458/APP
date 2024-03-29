﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/plantillas/SILPA.master" CodeFile="RespuestaContingencias.aspx.cs" Inherits="Contingencias_RespuestaContingencias" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
    <link href="../Resources/Bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <script src='<%= ResolveClientUrl("~/Resources/jquery/3.2.1/jquery.min.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Resources/Bootstrap/3.3.7/js/bootstrap.min.js") %>' type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        table {
            /*border: 1px solid #000;*/
        }
        table tr td {
            border: 0px solid #ddd !important;
            padding: 4px;
        }
        .Button{
            background-color: #ddd;
        }
    </style>

    <link href="css/Contingencias.css" rel="stylesheet" />


    <script language="javascript" type="text/javascript">
        window.history.forward();
    </script>

    <asp:ScriptManager ID="scmManager" runat="server"></asp:ScriptManager>        

    <table class="TablaTituloSeccionContingencias ">
        <tr>
            <td class="div-titulo">
                <asp:Label ID="lblTitulo" runat="server" Text="FORMATO REPORTE DE CONTINGENCIAS" SkinID="titulo_principal_blanco"></asp:Label>
            </td>
        </tr>
    </table>

    <table class="TablaFormularioContingencias ">
        <tr>
            <td class="TituloSeccionContingencias ">
                Reporte Inicial de Contingencias
            </td>
        </tr>
        <tr>
            <td class="TextoRespuestaContingencias ">
                <asp:Literal runat="server" ID="ltlRespuestaSolicitud"></asp:Literal>
            </td>
        </tr>
    </table>



    <table class="TablaBotonesFormularioContingencias ">
        <tr>
            <td>
                <asp:Button runat="server" ID="cmdAceptar" Text="Aceptar" OnClick="cmdAceptar_Click" />
            </td>
        </tr>
    </table>


    <input type="button" runat="server" id="cmdErrorProcesoHide" style="display:none;" />
    <cc1:ModalPopupExtender ID="mpeErrorProceso" runat="server" PopupControlID="dvErrorProceso" TargetControlID="cmdErrorProcesoHide" BehaviorID="mpeErrorProcesos" BackgroundCssClass="ModalBackgroundContingencias ">
    </cc1:ModalPopupExtender>
    <div id="dvErrorProceso" style="display:none;" runat="server" clientidmode="Static" class="ContenedorModalContingencias ">
        <asp:UpdatePanel runat="server" ID="upnlErrorProceso" UpdateMode="Conditional">
            <ContentTemplate>
                <table class="TablaFormularioContingencias ">
                    <tr>
                        <td colspan="2" class="TituloSeccionContingencias ">
                            Solicitud / Información de Cambio Menor
                        </td>
                    </tr>
                    <tr>
                        <td class="ImagenesModalContingencias ">
                            <asp:Image runat="server" ID="imgIconoErrorProceso" ImageUrl="~/images/error.png" />
                        </td>
                        <td class="TextoModalErrorContingencias ">
                            <asp:Literal runat="server" ID="ltlErrorProceso"></asp:Literal>
                        </td>
                    </tr>                        
                </table>
                <table class="TablaBotonesFormularioContingencias ">
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="cmdAceptarErrorProceso" CausesValidation="false" Text="Aceptar" ClientIDMode="Static" OnClick="cmdAceptarErrorProceso_Click"/>
                            <asp:Button runat="server" ID="cmdAceptarErrorProcesoSincronico" CausesValidation="false" Text="Aceptar" ClientIDMode="Static" OnClick="cmdAceptarErrorProceso_Click"/>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmdAceptarErrorProceso" EventName="Click" />                                                        
                <asp:PostBackTrigger ControlID="cmdAceptarErrorProcesoSincronico" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:UpdateProgress ID="uppErrorProceso" runat="server" AssociatedUpdatePanelID="upnlErrorProceso">
            <ProgressTemplate>  
                <div id="ModalProgressContainer">
                    <div>
                        <p>Procesando...</p>
                        <p><asp:Image ID="imgErrorProceso" runat="server" SkinId="procesando"/></p>
                    </div>
                </div>                         
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>

</asp:Content>
