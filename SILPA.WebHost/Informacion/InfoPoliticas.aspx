<%@ Page Title="Politicas" Language="C#" MasterPageFile="~/plantillas/SILPAInformacionPublica.master" AutoEventWireup="true" CodeFile="InfoPoliticas.aspx.cs" Inherits="Informacion_InfoPoliticas" %>

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
    </style>
    <div>
        <div class="titulo_pagina">
            Políticas
        </div>
    </div>
    <div class="form-group descripcion">
        <div class="contenido">
            <div id="exTab2" class="containerTab">
                <ul id="ulTabs" class="nav nav-tabs" role="tablist">
                    <li class="nav-item" id="aEstadoTramite">
                        <a class="nav-link active" id="nav-SobreAplicativo-tab" data-bs-toggle="tab" data-bs-target="#SobreAplicativo" aria-controls="nav-SobreAplicativo" role="tab" aria-selected="true" style="/* font-size: 13px; */">Sobre el aplicativo</a>
                    </li>
                    <li class="nav-item" id="aInfGeneral">
                        <a class="nav-link" id="nav-TerminosGenerales-tab" data-bs-toggle="tab" data-bs-target="#TerminosGenerales" aria-controls="nav-TerminosGenerales" role="tab" aria-selected="false">Terminos Generales</a>
                    </li>
                    <li class="nav-item" id="Li1">
                        <a class="nav-link" id="nav-UsoContenido-tab" data-bs-toggle="tab" data-bs-target="#UsoContenido" aria-controls="nav-UsoContenido" role="tab" aria-selected="false">Uso del contenido</a>
                    </li>
                    <li class="nav-item" id="Li2">
                        <a class="nav-link" id="nav-ProteccionDatos-tab" data-bs-toggle="tab" data-bs-target="#ProteccionDatos" aria-controls="nav-ProteccionDatos" role="tab" aria-selected="false">Protección de datos</a>
                    </li>
                </ul>
                <div id="panelTabs" class="panelTabs tab-content clearfix">
                    <div class="tab-pane active" id="SobreAplicativo" role="tabpanel" aria-labelledby="nav-SobreAplicativo-tab">
                        <div class="row">
                            <p class="subtitulo">Misión</p>
                            <p>
                            La Ventanilla Única de Trámites Ambientales es el instrumento  a través del cual las autoridades ambientales del país buscan la automatización de los diversos trámites administrativos de carácter ambiental  que se constituyen en requisito  previo a la ejecución de proyectos, obras o actividades, en aras de contribuir a la interacción del ciudadano y las empresas con las autoridades ambientales, a través del uso de tecnologías de información y comunicaciones (TIC) bajo los principios de eficiencia, trasparencia y eficacia de la gestión pública.
                            </p>
 
                            <p class="subtitulo">
                            Visión
                                </p>
                            <p>
                            Ser un sistema único centralizado de cobertura nacional a través del cual se direccionen y unifiquen los trámites administrativos de carácter ambiental y la información de todos los actores que participan de una u otra forma en los mismos, lo cual permitirá mejorar la eficiencia y eficacia de la capacidad institucional en aras del cumplimiento de los fines esenciales de Estado.
                                </p>
                        </div>
                    </div>
                      <div class="tab-pane" id="TerminosGenerales" role="tabpanel" aria-labelledby="nav-TerminosGenerales-tab">
                        <div class="row">
                            <p class="subtitulo">1.1     Términos generales</p>
                            <p>
                            Dando cumplimiento a los objetivos institucionales y al fuerte compromiso que posee para entregar información, servicios y tramites confiables y de calidad, informa a los usuarios de su ventanilla para trámites ambientales: VITAL acerca de su política de privacidad.
                            Se adhiere de esta forma a las normas auto regulatorias que buscan proteger el derecho básico de personas y empresas a resguardar la confidencialidad de sus datos, y que cumplen integralmente con las recomendaciones hechas por organismos especializados en estos temas.
                            Estos principios buscan asegurar la correcta utilización de la información que se recopile a través de las visitas a VITAL  y de otro tipo de información de entrega voluntaria.
                            VITALse reserva el derecho a modificar la presente política para adaptarla a novedades legislativas o jurisprudenciales así como a prácticas generales de la industria. Cualquier modificación será debidamente anunciada a los Usuarios
                            </p>
                            <p class="subtitulo">
                            1.2. Aceptación de las Condiciones de Uso
                                </p>
                            <p>
                            Para todos los efectos legales y por el mero hecho de acceder a la ventanilla VITAL, el Usuario acepta y reconoce que ha revisado y que está de acuerdo con la Política de Privacidad, en lo que en Derecho corresponda. Será responsabilidad del Usuario la lectura y acatamiento de la Política de Privacidad, cada vez que los utilice.
                            </p>
                            <p class="subtitulo">
                            1.3. Solución de Controversias
                                </p>
                            <p>
                            Todas las controversias y/o reclamos que puedan surgir por el uso de la ventanilla VITAL implican la aceptación y sometimiento a las Leyes y normas de la República de Colombia y serán resueltas por los tribunales competentes en la capital de la republica de Colombia.
                            </p>
                            <p class="subtitulo">
                            1.4 Responsabilidad por las Opiniones e Informaciones vertidas en el Portal
                                </p>
                            <p>
                            VITAL no se responsabiliza por las informaciones y opiniones emitidas en la ventanilla VITAL, cuando no sean de su exclusiva emisión. Las informaciones y opiniones emitidas por personas diferentes a éstos, no necesariamente reflejan la posición de VITAL, incluyendo sin limitación a sus empleados, directores, asesores y proveedores. En consecuencia, éste no se hace responsable por ninguna de las informaciones y opiniones que se emitan en sus productos Web, en las condiciones descritas
                                </p>
                        </div>
                    </div>
                     <div class="tab-pane" id="UsoContenido" role="tabpanel" aria-labelledby="nav-UsoContenido-tab">
                        <div class="row">
                            <p class="subtitulo">
                                2.1 Uso correcto de los Contenidos
                                </p>

                            <p>
                            El Usuario se obliga a utilizar los Contenidos de forma diligente, correcta y lícita. En general se compromete a no utilizar los Contenidos de forma ilícita y para fines contrarios a la Ley o el Orden Público. Entre otras obligaciones, a manera meramente referencial y sin que implique limitación alguna, al Usuario se le prohíbe especialmente:
                                </p>
                            <p>
                            (a)
                            Suprimir, eludir o manipular el "copyright" y demás datos identificadores de los derechos del sitio Web o de sus titulares, incorporados a los Contenidos, así como los dispositivos técnicos de protección, las huellas digitales o cualesquiera mecanismos de información que pudieren contener los Contenidos
                                </p>
                            <p>
                            (b)
                            No respetar la privacidad, opiniones, punto de vista, ideología, religión y etnia de otros Usuarios, así como aquellas otras opciones personales o aspectos pertenecientes su esfera de intimidad y privacidad;
                                </p>
                            <p>
                            (c)
                            Usar los Contenidos con propósitos comerciales, incluyendo la promoción de cualquier bien o servicio;
                                </p>
                            <p>
                            (d)
                            Proporcionar información obscena, difamatoria, dañina o conocidamente falsa;
                                </p>
                            <p>
                            (e)
                            Obstaculizar, entorpecer, restringir o limitar el uso de los Contenidos por parte de otros Usuarios;
                                </p>
                            <p>
                            (f)
                            En general, el Usuario deberá abstenerse de utilizar los contenidos de la ventanilla VITAL de manera que atente contra los legítimos derechos de terceros, o bien que pueda dañar, inutilizar, sobrecargar o deteriorar los Contenidos o impedir su normal uso por parte de otros Usuarios.
                                </p>
                        </div>
                    </div>
                     <div class="tab-pane" id="ProteccionDatos" role="tabpanel" aria-labelledby="nav-ProteccionDatos-tab">
                        <div class="row">
                            <p class="subtitulo">3.1. Utilización de la información obtenida de los usuarios y privacidad de datos personales.
                                </p>

                            <p>
                            VITAL se preocupa por la protección de datos de carácter personal de sus Usuarios, por lo cual, asegura la confidencialidad de los mismos, y no los transferirá o cederá o de otra manera proveerá, salvo en aquellos casos en que la legislación vigente así lo indique. El uso que el Usuario haga de los productos de la ventanilla VITAL puede ser almacenado con el objeto de generar una información estadística respecto a la utilización de las secciones, partes y en general, del Contenido de éstos, de manera de determinar los números totales y específicos, por sección, de visitantes a la ventanilla VITAL, con el objetivo principal de conocer las necesidades e intereses de los Usuarios y otorgar un mejor servicio.
                            Los Usuarios determinan libre y voluntariamente si desean facilitar los datos personales que se les puedan requerir o que se puedan obtener de los Usuarios, con ocasión de la suscripción o alta en algunos de los servicios ofrecidos en la ventanilla VITAL.
                            </p>
                            <p class="subtitulo">
                            3.2. Sobre la seguridad de la información
                                </p>
                            <p>
                            VITAL ha adoptado los niveles de seguridad de protección de los Datos Personales legalmente requeridos, y ha instalado todos los medios y medidas técnicas a su alcance para evitar la pérdida, mal uso, alteración, acceso no autorizado y robo de los Datos Personales facilitados por los Usuarios. Ello no obstante, el Usuario debe ser consciente de que las medidas de seguridad en Internet no son inexpugnables
                                </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

