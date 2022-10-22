<%@ Page Title="Trpamites" Language="C#" MasterPageFile="~/plantillas/SILPAInformacionPublica.master" AutoEventWireup="true" CodeFile="InfoTramites.aspx.cs" Inherits="Informacion_InfoTramites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .row .descripcion {
            margin-top: 15px;
            border-radius: 5px;
            padding: 10px 0px 10px 0px;
            color: gray;
            box-sizing: content-box;
        }
        .contenido {
            margin-left: 5.5%;
            margin-right: 5.5%;
            display: flex;
            flex-wrap: wrap;
        }

        .descripcionOpcion {
            align-items: center;
            display: flex;
        }
        #ingresar {
            align-items: center;
            display: flex;
        }
        
    </style>
    
    <div>
        <div class="titulo_pagina">
            Tramites disponibles
        </div>
    </div>
    <div class="form-group descripcion">
        <div class="col-12">
            <h3>
            Las solicitudes  en la Ventanilla se hacen de manera electrónica mediante formularios dispuestos para los ciudadanos registrados. Estos formularios deben ser diligenciados en el momento que se accede ya que no serán guardados para un posterior llenado.  A través de este acceso todos los usuarios de la Ventanilla pueden solicitar cualquiera de los siguientes tramites ambientales y/o mecanismos de participación:
            </h3>    
        </div>
        
    </div>
    <div class="form-group descripcion">
            <div class="contenido">
                <div id="opciones_tramites" class="col-lg-9">
                    <div class="row col-12">
                        <div class="imagenOpcion col-1">
                            <img id="imgPermisosAmbientales" class="img-fluid" src="../Resources/Img_Vital/ImgPermisosAmbientales.png" />
                        </div>
                        <div class="col-4 descripcionOpcion">
                            <h3>Permisos Ambientales</h3>
                        </div>
                        <div class="imagenOpcion col-1">
                            <img id="imgDaayoTdr" class="img-fluid" src="../Resources/Img_Vital/ImgDaayoTdr.png" />
                        </div>
                        <div class="col-4 descripcionOpcion">
                            <h3>Daa y/o Tdr</h3>
                        </div>
                    </div>
                    <div class="row col-12">
                        <div class="imagenOpcion col-1">
                            <img id="imgCesionDerechos" class="img-fluid" src="../Resources/Img_Vital/ImgCesionDerechos.png" />
                        </div>
                        <div class="col-4 descripcionOpcion">
                            <h3>Cesión de Derechos</h3>
                        </div>
                        <div class="imagenOpcion col-1">
                            <img id="imgSalvoconducto" class="img-fluid" src="../Resources/Img_Vital/ImgSalvoconducto.png" />
                        </div>
                        <div class="col-4 descripcionOpcion">
                            <h3>Salvoconducto</h3>
                        </div>
                    </div>
                     <div class="row col-12">
                        <div class="imagenOpcion col-1">
                            <img id="imgLicenciasAmbientales" class="img-fluid" src="../Resources/Img_Vital/ImgLicenciaAmbiental.png" />
                        </div>
                        <div class="col-4 descripcionOpcion">
                            <h3>Cesión de Derechos</h3>
                        </div>
                        <div class="imagenOpcion col-1">
                            <img id="imgEnviarInformacion" class="img-fluid" src="../Resources/Img_Vital/ImgEnviarInformacion.png" />
                        </div>
                        <div class="col-4 descripcionOpcion">
                            <h3>Salvoconducto</h3>
                        </div>
                    </div>
                    <div class="row col-12">
                        <div class="imagenOpcion col-1">
                            <img id="imgTercerInterviniente" class="img-fluid" src="../Resources/Img_Vital/ImgTercerInterviniente.png" />
                        </div>
                        <div class="col-4 descripcionOpcion">
                            <h3>Tercer Interviniente</h3>
                        </div>
                        <div class="imagenOpcion col-1">
                            <img id="imgAudienciaPublica" class="img-fluid" src="../Resources/Img_Vital/ImgAudienciaPublica.png" />
                        </div>
                        <div class="col-4 descripcionOpcion">
                            <h3>Audiencia Pública</h3>
                        </div>
                    </div>
                    <div class="row col-12">
                        <div class="imagenOpcion col-1">
                            <img id="imgLiquidacionEvaluacion" class="img-fluid" src="../Resources/Img_Vital/ImgLiquidacionInformacion.png" />
                        </div>
                        <div class="col-4 descripcionOpcion">
                            <h3>Liquidación de Evaluación </h3>
                        </div>
                        <div class="imagenOpcion col-1">
                            <img id="imgSolicituInforEntExternas" class="img-fluid" src="../Resources/Img_Vital/ImgSolicitarInformacionEntidadesExternas.png" />
                        </div>
                        <div class="col-4 descripcionOpcion">
                            <h3>Solicitar Información a Entidades Externas</h3>
                        </div>
                    </div>
                </div>
                <div id="ingresar" class="col-lg-3">
                    <div>
                        <a href="http://vital.minambiente.gov.co/SILPA/TESTSILPA/Security/Login.aspx?ReturnUrl=%2fSILPA%2fTestSilpa%2fSecurity%2fdefault.aspx">
                            <img border="0" alt="" width="211" height="48" src="../Resources/Img_Vital/ingresar.jpg">
                        </a>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>


