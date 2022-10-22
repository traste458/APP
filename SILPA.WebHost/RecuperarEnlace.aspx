<%@ Page Title="" Language="C#" MasterPageFile="~/plantillas/SILPAExterno.master" AutoEventWireup="true" CodeFile="RecuperarEnlace.aspx.cs" Inherits="RecuperarEnlace" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
    <script type="text/javascript">
        var key = '<%= Recaptcha.LlavePublica %>';

        var onloadCallback = function () {
            grecaptcha.render('loginRecaptcha', {
                'sitekey': key,
                'type': 'image'
            });
        };

        function CaptchaSelectionValidation(source, arguments) {
            var googleResponse = $('#g-recaptcha-response').val();

            if (googleResponse == '') {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }
        }

    </script>    
    <style>
        .button{
            font: var(--unnamed-font-style-normal) normal medium 16px/30px 'Montserrat' !important;
            background: var(--cta) 0% 0% no-repeat padding-box !important;
            background: #3366CC 0% 0% no-repeat padding-box !important;
            border-radius: 20px !important;
            opacity: 1 !important;
            text-align: left !important;
            letter-spacing: 0px !important;
            color: #FFFFFF !important;
            opacity: 1 !important;
            font-size: 16px !important;
            font-weight: 500 !important;
            border: 0 !important;
            height: 40px !important;
            width: 80% !important;
            margin-left: 10% !important;
            text-align: center !important;
            margin-bottom: 20px !important;
            max-width: 200px !important;
        }

        .CellResultadoTituloModalNot {
            background: #3366CC 0% 0% no-repeat padding-box !important;
            color: #FFFFFF !important;
        }

        .CellMensajesNot {
            font: var(--unnamed-font-style-normal) normal medium 16px/30px 'Montserrat' !important;
            font-size: 16px !important;
            font-weight: normal;
        }

        .TableFormularioNot {
            border: 0px !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="scmManejador" runat="server">
    </asp:ScriptManager>
    <div class="div-titulo">
        <asp:Label ID="lblTituloPrincipal" runat="server" Text="ENVÍAR ENLACE ACTIVACIÓN USUARIO" SkinID="titulo_principal_blanco"></asp:Label>
    </div>
    <asp:UpdatePanel runat="server" ID="upnlEnlace" UpdateMode="Conditional">
        <ContentTemplate>
            <table style="border: 0px; width:80%;">
                <tr>
                    <td style="padding-bottom: 10px;">
                        <span>
                            Número de Identificación
                            <asp:RequiredFieldValidator ID="rfvNumeroIdentificacion" ControlToValidate="txtNumeroIdentificacion" runat="server" ErrorMessage="Ingrese el número de identificación" ValidationGroup="Recordar">*</asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox runat="server" ID="txtNumeroIdentificacion" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="uppEnlace" runat="server" AssociatedUpdatePanelID="upnlEnlace">
        <ProgressTemplate>  
            <div id="ModalProgressContainer">
                <div>
                    <p>Procesando...</p>
                    <p><asp:Image ID="imgenlacePersona" runat="server" SkinId="procesando"/></p>
                </div>
            </div>                         
        </ProgressTemplate>
    </asp:UpdateProgress>  
    <table style="border: 0px; width:80%;">
        <tr>
            <td>
                <script src="<%= Recaptcha.URLAPI %>?onload=onloadCallback&render=explicit" async defer></script>
                <div id="loginRecaptcha" class="captcha"></div>
                <asp:CustomValidator runat="server" ID="cvCaptcha" Display="Dynamic" ClientValidationFunction="CaptchaSelectionValidation" ErrorMessage="Haga clic sobre el campo de verificación de captcha." ValidationGroup="Recordar">&nbsp;</asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td style="padding: 10px;">
                <asp:ValidationSummary ID="valEnvioEnlace" runat="server" ShowSummary="false" DisplayMode="List" ShowMessageBox="true" ValidationGroup="Recordar" />
                <asp:Button ID="cmdRestablecer" runat="server" Text="Enviar" SkinID="boton_copia" CausesValidation="true" OnClick="cmdRestablecer_Click"  ValidationGroup="Recordar" />
                <asp:Button ID="cmdCancelar" runat="server" Text="Volver" SkinID="boton_copia" CausesValidation="false" OnClick="cmdCancelar_Click" />
            </td>
        </tr>
    </table>
    
   <input type="hidden" runat="server" id="cmdResultadoDatosPersonaHide" style="display:none;" />
    <cc1:ModalPopupExtender ID="mpeModalResultadoDatosPersona" runat="server" PopupControlID="dvModalResultadoDatosPersona" TargetControlID="cmdResultadoDatosPersonaHide" BehaviorID="mpeModalResultadoDatosPersonas" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <div id="dvModalResultadoDatosPersona" style="display:none;" runat="server" clientidmode="Static" class="ContenedorModalFormularioNot">
        <asp:UpdatePanel runat="server" ID="upnlModalResultadoDatosPersona" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="TableResultadoModalNot">
                    <div class="RowResultadoModalNot">
                        <div class="CellResultadoTituloModalNot">
                            ENVÍAR ENLACE ACTIVACIÓN USUARIO
                        </div>
                    </div>                            
                    <div class="RowResultadoModalNot">
                        <div class="CellResultadoModalNot">
                            <div class="TableFormularioNot">
                                <div class="RowFormularioNot">
                                    <div class="CellFormularioNot">
                                        <div class="TableMensajesNot">
                                            <div class="RowMensajesNot">
                                                <div class="CellMensajesNot"><asp:Image runat="server" ID="imgOKResultadoDatosPersona" ImageUrl="~/App_Themes/Img/chulo_verde.png" Width="80px"/></div>
                                                <div class="CellMensajesNot"><asp:Literal runat="server" ID="ltlMensajeResultadoOK"></asp:Literal></div>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>                               
                            </div>
                        </div>
                    </div>
                    <div class="RowResultadoModalNot">
                        <div class="CellButtonModal">
                            <asp:Button ID="cmdAceptarResultadoDatosPersona" runat="server" ClientIDMode="Static" Text="Aceptar" CssClass="boton" CausesValidation="false" OnClick="cmdAceptarResultadoDatosPersona_Click" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmdAceptarResultadoDatosPersona" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="uppModalResultadoDatosPersona" runat="server" AssociatedUpdatePanelID="upnlModalResultadoDatosPersona">
            <ProgressTemplate>  
                <div id="ModalProgressContainer">
                    <div>
                        <p>Procesando...</p>
                        <p><asp:Image ID="imgUpdateProgresModalResultadoDatosPersona" runat="server" SkinId="procesando"/></p>
                    </div>
                </div>                         
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>             



    <input type="hidden" runat="server" id="cmdAdvertenciaHide" style="display:none;" />
    <cc1:ModalPopupExtender ID="mpeAdvertenciaRecuperar" runat="server" PopupControlID="dvAdvertenciaRecuperar" TargetControlID="cmdAdvertenciaHide" BehaviorID="mpeAdvertenciaRecuperar" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <div id="dvAdvertenciaRecuperar" style="display:none;" runat="server" clientidmode="Static" class="ContenedorModalFormularioNot">
        <asp:UpdatePanel runat="server" ID="upnlAdvertenciaRecuperar" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="TableResultadoModalNot">
                    <div class="RowResultadoModalNot">
                        <div class="CellResultadoTituloModalNot">
                            ENVÍAR ENLACE ACTIVACIÓN USUARIO
                        </div>
                    </div>                            
                    <div class="RowResultadoModalNot">
                        <div class="CellResultadoModalNot">
                            <div class="TableFormularioNot">
                                <div class="RowFormularioNot">
                                    <div class="CellFormularioNot">
                                        <div class="TableMensajesNot">
                                            <div class="RowMensajesNot">
                                                <div class="CellMensajesNot"><asp:Image runat="server" ID="Image1" ImageUrl="~/App_Themes/Img/advertencia.png" Width="80px"/></div>
                                                <div class="CellMensajesNot"><asp:Literal runat="server" ID="ltlMensajeAdvertencia"></asp:Literal></div>
                                            </div>                                            
                                        </div>
                                    </div>
                                </div>                               
                            </div>
                        </div>
                    </div>
                    <div class="RowResultadoModalNot">
                        <div class="CellButtonModal">
                            <asp:Button ID="cmdAceptarAdvertencia" runat="server" ClientIDMode="Static" Text="Aceptar" CausesValidation="false" OnClick="cmdAceptarAdvertencia_Click" />
                            <asp:Button ID="cmdRecuperarContrasenaAdvertencia" runat="server" ClientIDMode="Static" Text="Recordar Contraseña" CssClass="boton" CausesValidation="false" OnClick="cmdRecuperarContrasenaAdvertencia_Click" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmdAceptarResultadoDatosPersona" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="uppAdvertenciaRecuperar" runat="server" AssociatedUpdatePanelID="upnlAdvertenciaRecuperar">
            <ProgressTemplate>  
                <div id="ModalProgressContainer">
                    <div>
                        <p>Procesando...</p>
                        <p><asp:Image ID="imgAdvertenciaRecuperar" runat="server" SkinId="procesando"/></p>
                    </div>
                </div>                         
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>     

</asp:Content>

