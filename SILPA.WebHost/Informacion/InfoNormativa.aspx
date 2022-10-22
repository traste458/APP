<%@ Page Title="Normativa" Language="C#" MasterPageFile="~/plantillas/SILPAInformacionPublica.master" AutoEventWireup="true" CodeFile="InfoNormativa.aspx.cs" Inherits="Informacion_InfoNormativa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css" />
     <link href="../Resources/Bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />

    <!-- CSS files (include only one of the two files!) -->
    <!-- If you are not using bootstrap: -->
    <link rel="stylesheet" type="text/css" href="../Resources/datatable-master/css/datatable.min.css" media="screen">
    <!-- If you are using bootstrap: -->
    <link rel="stylesheet" type="text/css" href="../Resources/datatable-master/css/datatable-bootstrap.min.css" media="screen">
    <link rel="stylesheet" type="text/css" href="../Resources/Buscador/css/buscadorVITAL.css" />
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
        p {
            color:gray;
            text-align: justify;
        }

        .subtitulo {
            font-weight: bold;
        }
        p a {
            font-weight: bold;
            text-decoration: underline;
        }

        .fecha_publicion {
            font-size:10px;
        }
        .dvListadoDocumentos {
            width: 100%;
            max-width: 100%;
            box-sizing: border-box;
            display: flex;
            flex-wrap: wrap;
            padding-top:10px;
            
        }
        .dvListadoDocumentos > div {
            border-bottom: solid #e6effd;
        }
        .decreto, .resolucion {
            display: flex;
            flex-wrap: wrap;
            box-sizing: border-box;
            width: 100%;
            max-width: 100%;
            margin-bottom:10px;
        }

        .imgArchivo {
            vertical-align: top;
        }

        .imgArchivo img {
            display:block;
            vertical-align: top;
            margin:auto;
        }
        
    </style>
     <div>
        <div class="titulo_pagina">
            Normativa
        </div>
    </div>
    <div class="form-group descripcion">
        <div class="contenido">
            <div id="exTab2" class="containerTab">
                <ul id="ulTabs" class="nav nav-tabs" role="tablist">
                    <li class="nav-item" id="aEstadoTramite">
                        <a class="nav-link active" id="nav-Decretos-tab" data-bs-toggle="tab" data-bs-target="#Decretos" aria-controls="nav-Decretos" role="tab" aria-selected="true" style="/* font-size: 13px; */">Decretos</a>
                    </li>
                    <li class="nav-item" id="aInfGeneral">
                        <a class="nav-link" id="nav-Resoluciones-tab" data-bs-toggle="tab" data-bs-target="#Resoluciones" aria-controls="nav-Resoluciones" role="tab" aria-selected="false">Resoluciones</a>
                    </li>
                </ul>
                <div id="panelTabs" class="panelTabs tab-content clearfix">
                    <div class="tab-pane active" id="Decretos" role="tabpanel" aria-labelledby="nav-Decretos-tab">
                        <div class="row">
                            <p class="subtitulo">Decretos</p>
                            <p>
                            Un decreto es un tipo de acto administrativo emanado habitualmente del poder ejecutivo y que, generalmente, posee un
                            contenido normativo reglamentario, por lo que su rango es jerárquicamente inferior a las leyes. Esta regla general tiene sus
                            excepciones en casi todas las legislaciones, normalmente para situaciones de urgente necesidad, y algunas otras específicamente
                            tasadas.
                            </p>
                            <div class="dvListadoDocumentos">
                                <div class="decreto">
                                    <div class="col-2 imgArchivo">
                                        <img class="img-fluid" src="../Resources/Img_Vital/imgFilePDF.png" />
                                    </div>
                                    <div class="col-10">
                                        <p>
                                            <a href="http://vital.minambiente.gov.co/VENTANILLASILPA/Portals/0/iconos2/resoluciones/dec1220.pdf" target="_blank" title="Decreto número 1220">Decreto número 1220</a>
                                        </p>
                                        <p>
                                            descripcion del decreto
                                        </p>
                                        <p class="fecha_publicion">
                                            21 de Abril de 2005
                                        </p>
                                    </div>
                                </div>
                                <div class="decreto">
                                    <div class="col-2 imgArchivo">
                                        <img class="img-fluid" src="../Resources/Img_Vital/imgFilePDF.png" />
                                    </div>
                                    <div class="col-10">
                                        <p>
                                            <a href="http://vital.minambiente.gov.co/VENTANILLASILPA/Portals/0/iconos2/resoluciones/dcto0500.pdf" target="_blank" title="Decreto número 0500">Decreto número 0500</a>
                                        </p>
                                        <p>
                                            descripcion del decreto
                                        </p>
                                        <p class="fecha_publicion">
                                            20 de Febrero de 2006
                                        </p>
                                    </div>
                                </div>
                                <div class="decreto">
                                    <div class="col-2 imgArchivo">
                                        <img class="img-fluid" src="../Resources/Img_Vital/imgFilePDF.png" />
                                    </div>
                                    <div class="col-10">
                                        <p>
                                            <a href="http://vital.minambiente.gov.co/VENTANILLASILPA/Portals/0/iconos2/resoluciones/dcto4064.pdf" target="_blank" title="Decreto número 4064">Decreto número 4064</a>
                                        </p>
                                        <p>
                                            descripcion del decreto
                                        </p>
                                        <p class="fecha_publicion">
                                            24 de Octubre de 2008
                                        </p>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="tab-pane" id="Resoluciones" role="tabpanel" aria-labelledby="nav-Resoluciones-tab">
                        <div class="row">
                            <p class="subtitulo">Resoluciones</p>
                            <p>
                            Las resoluciones son decisiones no normativas por parte de una autoridad ya sea política, administrativa o judicial que solventa un conflicto o da pautas a seguir en una materia determinada.
                            </p>
                            <div class="dvListadoDocumentos">
                                <div class="resolucion">
                                    <div class="col-2 imgArchivo">
                                        <img class="img-fluid" src="../Resources/Img_Vital/imgFilePDF.png" />
                                    </div>
                                    <div class="col-10">
                                        <p>
                                            <a href="http://vital.minambiente.gov.co/VENTANILLASILPA/Portals/0/iconos2/resoluciones/res1110.pdf" target="_blank" title="Resolución 1110">Resolución No. 1110</a>
                                        </p>
                                        <p>
                                            descripcion del decreto
                                        </p>
                                        <p class="fecha_publicion">
                                            25 de Noviembre de 2002
                                        </p>
                                    </div>
                                </div>
                                <div class="resolucion">
                                    <div class="col-2 imgArchivo">
                                        <img class="img-fluid" src="../Resources/Img_Vital/imgFilePDF.png" />
                                    </div>
                                    <div class="col-10">
                                        <p>
                                            <a href="http://vital.minambiente.gov.co/VENTANILLASILPA/Portals/0/iconos2/resoluciones/res2202.pdf" target="_blank" title="Resolución No. 2202">Resolución No. 2202</a>
                                        </p>
                                        <p>
                                            descripcion del decreto
                                        </p>
                                        <p class="fecha_publicion">
                                            29 de Diciembre de 2006
                                        </p>
                                    </div>
                                </div>
                                <div class="resolucion">
                                    <div class="col-2 imgArchivo">
                                        <img class="img-fluid" src="../Resources/Img_Vital/imgFilePDF.png" />
                                    </div>
                                    <div class="col-10">
                                        <p>
                                            <a href="http://vital.minambiente.gov.co/VENTANILLASILPA/Portals/0/iconos2/pdf.gif" target="_blank" title="Resolución No. 0295">Resolución No. 0295</a>
                                        </p>
                                        <p>
                                            descripcion del decreto
                                        </p>
                                        <p class="fecha_publicion">
                                            20 de Febrero de 2007
                                        </p>
                                    </div>
                                </div>
                                <div class="resolucion">
                                    <div class="col-2 imgArchivo">
                                        <img class="img-fluid" src="../Resources/Img_Vital/imgFilePDF.png" />
                                    </div>
                                    <div class="col-10">
                                        <p>
                                            <a href="http://vital.minambiente.gov.co/VENTANILLASILPA/Portals/0/iconos2/resoluciones/res0978.pdf" target="_blank" title="Resolución No. 978">Resolución No. 978</a>
                                        </p>
                                        <p>
                                            descripcion del decreto
                                        </p>
                                        <p class="fecha_publicion">
                                            04 de Junio de 2007
                                        </p>
                                    </div>
                                </div>
                                <div class="resolucion">
                                    <div class="col-2 imgArchivo">
                                        <img class="img-fluid" src="../Resources/Img_Vital/imgFilePDF.png" />
                                    </div>
                                    <div class="col-10">
                                        <p>
                                            <a href="http://vital.minambiente.gov.co/VENTANILLASILPA/Portals/0/iconos2/resoluciones/res1652.pdf" target="_blank" title="Resolución No. 1652">Resolución No. 1652</a>
                                        </p>
                                        <p>
                                            descripcion del decreto
                                        </p>
                                        <p class="fecha_publicion">
                                            16 de Septiembre de 2007
                                        </p>
                                    </div>
                                </div>
                                <div class="resolucion">
                                    <div class="col-2 imgArchivo">
                                        <img class="img-fluid" src="../Resources/Img_Vital/imgFilePDF.png" />
                                    </div>
                                    <div class="col-10">
                                        <p>
                                            <a href="http://vital.minambiente.gov.co/VENTANILLASILPA/Portals/0/iconos2/resoluciones/res0848.pdf" target="_blank" title="Resolución No. 0848">Resolución No. 0848</a>
                                        </p>
                                        <p>
                                            descripcion del decreto
                                        </p>
                                        <p class="fecha_publicion">
                                            23 de Mayo de 2008
                                        </p>
                                    </div>
                                </div>
                                <div class="resolucion">
                                    <div class="col-2 imgArchivo">
                                        <img class="img-fluid" src="../Resources/Img_Vital/imgFilePDF.png" />
                                    </div>
                                    <div class="col-10">
                                        <p>
                                            <a href="http://vital.minambiente.gov.co/VENTANILLASILPA/Portals/0/iconos2/resoluciones/res144.pdf" target="_blank" title="Resolución No. 1442">Resolución No. 1442</a>
                                        </p>
                                        <p>
                                            descripcion del decreto
                                        </p>
                                        <p class="fecha_publicion">
                                            14 de Agosto de 2008
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>


