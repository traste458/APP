<%@ Page Language="C#" MasterPageFile="~/plantillas/SILPABuscador.master" AutoEventWireup="true" CodeFile="RealizarBusqueda.aspx.cs" Inherits="Impersonalizacion_RealizarBusqueda" Title="Impersonalización" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Resources/Bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/jquery.datetimepicker.css" rel="stylesheet" />
    <link rel="stylesheet" href="../Resources/Buscador/css/buscadorVITAL.css" />
    <link href="../Resources/EstilosBase/css/tabs-nuevas.css" rel="stylesheet" />

    <script src='<%= ResolveClientUrl("~/Resources/jquery/3.2.1/jquery.min.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Resources/jquery/fontsize/js/jquery.jfontsize-1.0.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Resources/Bootstrap/5.0.1/js/bootstrap.min.js") %>' type="text/javascript"></script>
    <script src='<%= ResolveClientUrl("~/Scripts/jquery.datetimepicker.js") %>' type="text/javascript"></script>
   <style type="text/css">
        label {
            font-weight: 400;
        }
        table tr td {
            border: 0px solid #ddd !important;
            padding: 4px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="row">
        <div class="titulo_pagina">
            Impersonalización
        </div>
    </div>
    <div class="row resultados">
        <div class="row">
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="cboTipoIdentificacion">Tipo de Identificación</label>
                    <asp:DropDownList ID="cboTipoIdentificacion" runat="server" class="form-control">
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-6">
                    <label for="txtNumeroIdentificacion">Número de Identificación</label>
                    <asp:TextBox ID="txtNumeroIdentificacion" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row col-md-4 botones">
                <div class="col-md-6">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="boton-principal" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-12">
                    <label for="lblNombre">Nombre / Razón Social</label>
                    <asp:Label ID="lblNombre" runat="server" class="form-control"></asp:Label>
                </div>
            </div>
            <div class="row col-md-4 botones">
                <div class="col-md-6">
                    <asp:Button ID="btnIniciar" runat="server" Text="Iniciar" OnClick="btnIniciar_Click" Visible="False" CssClass="boton-principal" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
