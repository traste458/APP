<%@ Page Language="C#" MasterPageFile="~/plantillas/SILPASUNL.master" AutoEventWireup="true" CodeFile="LogValidacionSUNL.aspx.cs" Inherits="Salvoconducto_LogValidacionSUNL" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="headPlaceHolder" runat="Server">
    <link href="../Resources/Bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/jquery.datetimepicker.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="div-titulo">
        <asp:Label ID="lblTituloPrincipal" runat="server" Text="Inconsistencias del salvoconducto" SkinID="titulo_principal_blanco"></asp:Label>
        &nbsp;
        <a href="#" id="hrCerrarVentana" visible="false" runat="server" onclick="window.close();return false;">Salir</a>
    </div>


    <div class="table-responsive">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="contact_form">
                        <table style="left: 0 !important; margin: 0 !important; padding: 0 !important; border: 0px solid #ddd !important;">
                            <tr>
                                 <asp:Label ID="LblInfoEspecies" runat="server" Text="Validacion Cantidad / Volumen Especies" SkinID="titulo_principal_blanco"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <table style="left: 0 !important; margin: 0 !important; padding: 0 !important; border: 0px solid #ddd !important; padding: 0 !important; width: 100%;">
                                        <tr>
                                            <td style="left: 0 !important; margin: 0 !important; padding: 0 !important; padding: 0 !important;">
                                                <asp:UpdatePanel ID="upnlEspecies" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gdvInconsistenciasEspecies" runat="server" AutoGenerateColumns="false"  Width="100%"
                                                            CellPadding="2" CellSpacing="1" GridLines="None" ShowFooter="True" HorizontalAlign="Center" SkinID="GrillaCoordenadas" EmptyDataText="no existen inconsistencia en cantidad de especies" >
                                                            <HeaderStyle Font-Size="9pt" />
                                                            <FooterStyle Font-Size="9pt" ForeColor="#000000" />
                                                            <RowStyle Font-Size="9pt" ForeColor="#000000" />
                                                            <SelectedRowStyle Font-Size="9pt" ForeColor="#000000" />
                                                            <EditRowStyle Font-Size="9pt" ForeColor="#000000" />
                                                            <AlternatingRowStyle Font-Size="9pt" ForeColor="#000000" />
                                                            <Columns>
                                                                <asp:BoundField DataField="COL1" HeaderText="DETALLE ERROR" />
                                                                <asp:BoundField DataField="COL2" HeaderText="ACTO ADMINISTRATIVO / SUNL ANTERIOR" />
                                                                <asp:BoundField DataField="COL3" HeaderText="NOMBRE CIENTIFICO" />
                                                                <asp:BoundField DataField="COL4" HeaderText="UNIDAD MEDIDA" />
                                                                <asp:BoundField DataField="COL5" HeaderText="CANTIDAD / VOLUMEN AUTORIZADO A MOVILIZAR" />
                                                                <asp:BoundField DataField="COL6" HeaderText="CANTIDAD / VOLUMEN MOVILIZADA" />
                                                                <asp:BoundField DataField="COL7" HeaderText="SALDO ACTUAL ESPECIE" />
                                                                <asp:BoundField DataField="COL8" HeaderText="CANTIDAD SOLICITADA ESPECIE" />
                                                                <asp:BoundField DataField="COL9" HeaderText="DIFERENCIA" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>


                        <table style="left: 0 !important; margin: 0 !important; padding: 0 !important; border: 0px solid #ddd !important;">
                            <tr>
                                 <asp:Label ID="LblInformacionGeneal" runat="server" Text="Validacion Integridad Informacion" SkinID="titulo_principal_blanco"></asp:Label>
                            </tr>
                            <tr>
                                <td>
                                    <table style="left: 0 !important; margin: 0 !important; padding: 0 !important; border: 0px solid #ddd !important; padding: 0 !important; width: 100%;">
                                        <tr>
                                            <td style="left: 0 !important; margin: 0 !important; padding: 0 !important; padding: 0 !important;">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grvValidacionGralSunl" runat="server" AutoGenerateColumns="false"  Width="100%"
                                                            CellPadding="2" CellSpacing="1" GridLines="None" ShowFooter="True" HorizontalAlign="Center" SkinID="GrillaCoordenadas" EmptyDataText="no existen inconsistencias en la integridad de la informacion del SUNL" >
                                                            <HeaderStyle Font-Size="9pt" />
                                                            <FooterStyle Font-Size="9pt" ForeColor="#000000" />
                                                            <RowStyle Font-Size="9pt" ForeColor="#000000" />
                                                            <SelectedRowStyle Font-Size="9pt" ForeColor="#000000" />
                                                            <EditRowStyle Font-Size="9pt" ForeColor="#000000" />
                                                            <AlternatingRowStyle Font-Size="9pt" ForeColor="#000000" />
                                                            <Columns>
                                                                <asp:BoundField DataField="DETALLE ERROR" HeaderText="DETALLE ERROR" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
        </div>

    </div>

    <script src="../Scripts/jquery-1.9.1.js"></script>
    <script src="../Scripts/jquery.datetimepicker.js"></script>
    <script src="../jquery/jquery.numeric.js"></script>
</asp:Content>

