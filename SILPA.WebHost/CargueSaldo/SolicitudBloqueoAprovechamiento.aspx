<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/plantillas/SILPASUNL.master" CodeFile="SolicitudBloqueoAprovechamiento.aspx.cs" Inherits="CargueSaldo_SolicitudBloqueoAprovechamiento" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="headPlaceHolder" runat="Server">
    <link href="../Resources/Bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/jquery.datetimepicker.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="div-titulo">
        <asp:Label ID="lblTituloPrincipal" runat="server" Text="Solicitud Bloqueo y Desbloqueo Aprovechamientos" SkinID="titulo_principal_blanco"></asp:Label>
        &nbsp;
        <a href="#" id="hrCerrarVentana" visible="false" runat="server" onclick="window.close();return false;">Salir</a>
    </div>


    <div class="table-responsive">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="contact_form">
            <asp:UpdatePanel runat="server" ID="UpnCargueInformacion">
                <ContentTemplate>
                    <table style="left: 0 !important; margin: 0 !important; padding: 0 !important; border: 0px solid #ddd !important;">
                        <tr>
                            <td>
                                <label for="cboMotivoBloqueoAprovechamiento" style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt; color: #000000;">Motivo Solicitud :</label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="upnlMotivoBloqueoAprovechamiento" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="cboMotivoBloqueoAprovechamiento" runat="server"></asp:DropDownList><asp:RequiredFieldValidator ID="RfvMotivoBloqueoAprovechamiento" runat="server" ControlToValidate="cboMotivoBloqueoAprovechamiento" Display="Dynamic" ValidationGroup="SolicBloqueoAprov">*</asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr runat="server" id="trDescripcionBloqueo">
                            <td>
                                <label for="txtDescripcionBloqueoAprov" style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt; color: #000000;">Descripcion Solicitud :</label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="upnlDescripcionBloqueoAprov" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDescripcionBloqueoAprov" runat="server" TextMode="MultiLine" Width="500px" Style="resize: none" ToolTip="Describa el Motivo de la solicitud"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVDescricionSolicitud" runat="server" ControlToValidate="txtDescripcionBloqueoAprov" ValidationGroup="Solicitud" ErrorMessage="Solicitud Bloqueo/ Descripcion Bloqueo">*</asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr runat="server" id="trDocumentoSoporteSolicitud">
                            <td>
                                <label for="fuplDocumentoSoporteBloqueo" style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt; color: #000000;">Documento soporte Solicitud :</label>
                            </td>
                            <td>
                                <div style="width: 100%;" runat="server" id="DivCargarArchivoSolBloqueo">
                                    <asp:UpdatePanel ID="upnlArchivo" runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSolciitarBloqueo" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <cc1:AsyncFileUpload runat="server" ID="fuplActoAdministrativo" ClientIDMode="AutoID" OnClientUploadComplete="UploadAnexo" OnClientUploadStarted="AssemblyFileUpload_Started" />
                                            <asp:Label ID="lblArchivo" runat="server" Text="-" Visible="false" SkinID="etiqueta_negra"></asp:Label>
                                            <asp:HyperLink ID="lnkVerArchivo" runat="server" NavigateUrl='~/VerAnexo.ashx' Text="Ver Archivo" Visible="false" />
                                            <asp:LinkButton ID="lnkAdicionarArchivo" runat="server" Text="Modificar Archivo" Visible="false" OnClick="lnkAdicionarArchivo_Click" />
                                            <asp:LinkButton ID="lnkCancelarArchivo" runat="server" Text="Cancelar" Visible="false" OnClick="lnkCancelarArchivo_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="upnlAccionesBoton" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSolciitarBloqueo" SkinID="boton_copia" runat="server" Text="Enviar Solicitud" ValidationGroup="Solicitud" OnClick="btnSolciitarBloqueo_Click" OnClientClick="return confirm('Desea generar la solicitud para este aprovechamiento?') " />
                                        <asp:Button ID="BtnCancelar" SkinID="boton_copia" runat="server" Text="Cancelar Solicitud" OnClick="BtnCancelar_Click" OnClientClick="return confirm('Desea Cancelar la solicitud para este aprovechamiento?') " />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>

            </asp:UpdatePanel>



        </div>
    </div>
    <script src="../Scripts/jquery-1.9.1.js"></script>
    <script src="../Scripts/jquery.datetimepicker.js"></script>
    <script src="../jquery/jquery.numeric.js"></script>
    <script src="../js/SaldoAprovechamiento.js"></script>
</asp:Content> 

