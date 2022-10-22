using SILPA.ProcesoArchivosVITALDalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinProcesoArchivosVITAL.Entidades;
using System.Collections.Generic;
using SILPA.ProcesoArchivosVITALDalc.Entidades;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace WinProcesoArchivosVITAL
{
    public partial class Form1 : Form
    {
        public List<SolicitudAntiguaEntity> lstSolicitudesAntiguas { get; set; }
        public List<SolicitudAntiguaEntity> lstSolicitudesNuevoPath { get; set; }
        public List<int> lstMesesProcesar { get; set; }
        public List<string> lstscriptProcesoCarpetas { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        
        
        

        #region Metodos privados
        private void CargarCombos()
        {
            ///Ciclo para los años
            for (int i = Parametros.Default.AnioInicio; i <= Parametros.Default.AnioFinal; i++)
            {
                this.cmbAnio.Items.Add( new ComboboxItem { Text = i.ToString(), Value = i });
            }
            this.cmbAnio.Items.Insert(0, new ComboboxItem { Text = "Seleccione un año", Value = 0 });
            this.cmbAnio.SelectedIndex = 0;
            ///Ciclo para los meses
            for (int i = 1; i <= 12; i++)
            {
                this.cmbMes.Items.Add(new ComboboxItem { Text = i.ToString(), Value = i });
            }
            this.cmbMes.Items.Insert(0, new ComboboxItem { Text = "Todos", Value = 0 });
            this.cmbMes.SelectedIndex = 0;
 
        }
        private List<SolicitudAntiguaEntity> lstDummySolicitudesAntiguas()
        {
            List<SolicitudAntiguaEntity> lstDummy = new System.Collections.Generic.List<SolicitudAntiguaEntity>();
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 1, pathSolicitud = @"E:\VitalFiletraffic\20160108064329", carpetaSolicitud = "20160108064329", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 2, pathSolicitud = @"E:\VitalFiletraffic\20160108064456", carpetaSolicitud = "20160108064456", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 3, pathSolicitud = @"E:\VitalFiletraffic\20160108064617", carpetaSolicitud = "20160108064617", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 4, pathSolicitud = @"E:\VitalFiletraffic\20160108064732", carpetaSolicitud = "20160108064732", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 5, pathSolicitud = @"E:\VitalFiletraffic\20160108064848", carpetaSolicitud = "20160108064848", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 6, pathSolicitud = @"E:\VitalFiletraffic\20160108065025", carpetaSolicitud = "20160108065025", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 7, pathSolicitud = @"E:\VitalFiletraffic\20160108065137", carpetaSolicitud = "20160108065137", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 8, pathSolicitud = @"E:\VitalFiletraffic\20160108065223", carpetaSolicitud = "20160108065223", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 9, pathSolicitud = @"E:\VitalFiletraffic\20160108065343", carpetaSolicitud = "20160108065343", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 10, pathSolicitud = @"E:\VitalFiletraffic\20160108065456", carpetaSolicitud = "20160108065456", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 11, pathSolicitud = @"E:\VitalFiletraffic\20160108065559", carpetaSolicitud = "20160108065559", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 12, pathSolicitud = @"E:\VitalFiletraffic\20160108070715", carpetaSolicitud = "20160108070715", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 13, pathSolicitud = @"E:\VitalFiletraffic\20160108071616", carpetaSolicitud = "20160108071616", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 14, pathSolicitud = @"E:\VitalFiletraffic\20160108071913", carpetaSolicitud = "20160108071913", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 15, pathSolicitud = @"E:\VitalFiletraffic\20160108072034", carpetaSolicitud = "20160108072034", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 16, pathSolicitud = @"E:\VitalFiletraffic\20160108072141", carpetaSolicitud = "20160108072141", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 17, pathSolicitud = @"E:\VitalFiletraffic\20160108072236", carpetaSolicitud = "20160108072236", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 18, pathSolicitud = @"E:\VitalFiletraffic\20160108072337", carpetaSolicitud = "20160108072337", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 19, pathSolicitud = @"E:\VitalFiletraffic\20160108072427", carpetaSolicitud = "20160108072427", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 20, pathSolicitud = @"E:\VitalFiletraffic\20160108072535", carpetaSolicitud = "20160108072535", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 21, pathSolicitud = @"E:\VitalFiletraffic\20160108072538", carpetaSolicitud = "20160108072538", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 22, pathSolicitud = @"E:\VitalFiletraffic\20160108072628", carpetaSolicitud = "20160108072628", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 23, pathSolicitud = @"E:\VitalFiletraffic\20160108072718", carpetaSolicitud = "20160108072718", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 24, pathSolicitud = @"E:\VitalFiletraffic\20160108072847", carpetaSolicitud = "20160108072847", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 25, pathSolicitud = @"E:\VitalFiletraffic\20160108072936", carpetaSolicitud = "20160108072936", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 26, pathSolicitud = @"E:\VitalFiletraffic\20160108073613", carpetaSolicitud = "20160108073613", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 27, pathSolicitud = @"E:\VitalFiletraffic\20160108073750", carpetaSolicitud = "20160108073750", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 28, pathSolicitud = @"E:\VitalFiletraffic\20160108073910", carpetaSolicitud = "20160108073910", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 29, pathSolicitud = @"E:\VitalFiletraffic\20160108074004", carpetaSolicitud = "20160108074004", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 30, pathSolicitud = @"E:\VitalFiletraffic\20160108074125", carpetaSolicitud = "20160108074125", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 31, pathSolicitud = @"E:\VitalFiletraffic\20160108074251", carpetaSolicitud = "20160108074251", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 32, pathSolicitud = @"E:\VitalFiletraffic\20160108074349", carpetaSolicitud = "20160108074349", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 33, pathSolicitud = @"E:\VitalFiletraffic\20160108074444", carpetaSolicitud = "20160108074444", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 34, pathSolicitud = @"E:\VitalFiletraffic\20160108074628", carpetaSolicitud = "20160108074628", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 35, pathSolicitud = @"E:\VitalFiletraffic\20160108074723", carpetaSolicitud = "20160108074723", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 36, pathSolicitud = @"E:\VitalFiletraffic\20160108074826", carpetaSolicitud = "20160108074826", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 37, pathSolicitud = @"E:\VitalFiletraffic\20160108074934", carpetaSolicitud = "20160108074934", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 38, pathSolicitud = @"E:\VitalFiletraffic\20160108075019", carpetaSolicitud = "20160108075019", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 39, pathSolicitud = @"E:\VitalFiletraffic\20160108075033", carpetaSolicitud = "20160108075033", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 40, pathSolicitud = @"E:\VitalFiletraffic\20160108075129", carpetaSolicitud = "20160108075129", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 41, pathSolicitud = @"E:\VitalFiletraffic\20160108075225", carpetaSolicitud = "20160108075225", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 42, pathSolicitud = @"E:\VitalFiletraffic\20160108075324", carpetaSolicitud = "20160108075324", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 43, pathSolicitud = @"E:\VitalFiletraffic\20160108075435", carpetaSolicitud = "20160108075435", anio = 2016, mes = 1 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 44, pathSolicitud = @"E:\VitalFiletraffic\20160208075534", carpetaSolicitud = "20160208075534", anio = 2016, mes = 2 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 45, pathSolicitud = @"E:\VitalFiletraffic\20160208075657", carpetaSolicitud = "20160208075657", anio = 2016, mes = 2 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 46, pathSolicitud = @"E:\VitalFiletraffic\20160208081232", carpetaSolicitud = "20160208081232", anio = 2016, mes = 2 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 47, pathSolicitud = @"E:\VitalFiletraffic\20160208082118", carpetaSolicitud = "20160208082118", anio = 2016, mes = 2 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 48, pathSolicitud = @"E:\VitalFiletraffic\20160208082539", carpetaSolicitud = "20160208082539", anio = 2016, mes = 2 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 49, pathSolicitud = @"E:\VitalFiletraffic\20160208083031", carpetaSolicitud = "20160208083031", anio = 2016, mes = 2 });
            lstDummy.Add(new SolicitudAntiguaEntity { idSolicitud = 50, pathSolicitud = @"E:\VitalFiletraffic\20160208083123", carpetaSolicitud = "20160208083123", anio = 2016, mes = 2 });

            foreach (SolicitudAntiguaEntity item in lstDummy)
            {
                item.pathDocumento = item.pathSolicitud;
            }

            return lstDummy;
 
        }
        /// <summary>
        /// Consulta el tamaño de las carpetas
        /// </summary>
        private void ConsultarTamañosCarpetas()
        {
            if (this.lstSolicitudesAntiguas != null && this.lstSolicitudesAntiguas.Count > 0)
            {
                string strcarpetasNoExistentes = string.Empty;
                Parallel.ForEach(this.lstSolicitudesAntiguas, paralSolicitud =>
                {
                    var dirInfo = new DirectoryInfo(paralSolicitud.pathSolicitud);
                    if (dirInfo.Exists)
                    {
                        decimal size = 0;
                        foreach (FileInfo fi in dirInfo.GetFiles("*", SearchOption.AllDirectories))
                        {
                            size += fi.Length; // 1048576;
                        }
                        paralSolicitud.tamanioCarpetaBytes = size;
                    }
                    else
                    {
                        strcarpetasNoExistentes += string.Format("No se encontro la carpeta:{0} , IdSolicitud:{1}", paralSolicitud.pathSolicitud, paralSolicitud.idSolicitud) + Environment.NewLine;
                    }
                });

                var agrupamientoMes = this.lstSolicitudesAntiguas.GroupBy(x => x.mes).Select(y => new { mes = y.Key, sizeMB = (y.Sum(x => x.tamanioCarpetaBytes) / 1048576).Value.ToString("0.00") }).ToList();
                this.dgvConsolidadoTamanios.AutoGenerateColumns = false;
                this.dgvConsolidadoTamanios.DataSource = agrupamientoMes;
                this.dgvConsolidadoTamanios.Refresh();

                if (strcarpetasNoExistentes != string.Empty)
                {
                    MessageBox.Show("Carpetas No encontradas");
                    this.txtCarpetasNosEncontradas.Visible = true;
                    this.txtCarpetasNosEncontradas.Text = strcarpetasNoExistentes;
                }
                
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // se valida que haya selecccionado al menos un año
            if (this.cmbAnio.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar un año");
            }
            else 
            {
                try
                {
                    int anio = 0;
                    int? mes = null;
                    anio = Convert.ToInt32((this.cmbAnio.SelectedItem as ComboboxItem).Value);
                    if ((this.cmbMes.SelectedItem as ComboboxItem).Value.ToString() != "0")
                    {
                        mes = Convert.ToInt32((this.cmbMes.SelectedItem as ComboboxItem).Value);
                    }
                    SolicitudesAntiguasDalc objSolicitudesAntiguasDalc = new SolicitudesAntiguasDalc();
                    lstSolicitudesAntiguas = objSolicitudesAntiguasDalc.ConsultaSolicitudesAntiguas(anio, mes);
                    //lstSolicitudesAntiguas = lstDummySolicitudesAntiguas();
                    
                    backgroundWorker1.RunWorkerAsync();
                    if (lstSolicitudesAntiguas.Count == 0)
                    {
                        MessageBox.Show("No se encontraron registros");
                        return;
                    }
                    this.lblRegistros.Text = lstSolicitudesAntiguas.Count.ToString() + " Registros.";
                    /// se llena la grilla con los regitros
                    this.dgvRegistros.AutoGenerateColumns = false;

                    ConsultarTamañosCarpetas();
                    this.dgvRegistros.DataSource = lstSolicitudesAntiguas;
                    
                    
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                    throw;
                }
                
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(10);
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            var carpetaDestino = this.fbdCarpetaDestino.ShowDialog();
            if (carpetaDestino == DialogResult.OK)
            {
                this.txtCarpetaDestino.Text = this.fbdCarpetaDestino.SelectedPath;
            }
        }

        private void btnGenerarScript_Click(object sender, EventArgs e)
        {
            string validacion = string.Empty;
            //validamos que haya seleccionado registros opcion y carpeta de destino
            // recorremos la grilla de los tamaños
            if (this.dgvConsolidadoTamanios.Rows.Count == 0)
            {
                validacion += "No existen registros en la grilla de tamaños \n";
            }
            
            // validamos que haya seleccionado una ruta como carpeta de destino
            if (this.txtCarpetaDestino.Text.Trim() == string.Empty)
            {
                validacion += "Debe seleccionar una carpeta de destino \n";
            }
            // validamos que haya seleccionado una opcion para la generacion de script
            if (this.rbCopiar.Checked == false && this.rbMover.Checked == false)
            {
                validacion += "Debe seleccionar una opcion para generar el script \n";
            }
            // validamos que haya seleccionado una carpeta para el log
            if (this.txtCarpetaLog.Text.Trim() == string.Empty)
            {
                validacion += "Debe seleccionar una carpeta de destino para el Log \n";
            }

            // validamos si se genero alguna validacion
            if (validacion != string.Empty)
            {
                MessageBox.Show(validacion);
            }
            else
            {
                lstscriptProcesoCarpetas = new System.Collections.Generic.List<string>();
                // procede a generar el script
                foreach (int imes in lstMesesProcesar)
                {
                    foreach (SolicitudAntiguaEntity iSolicitudAntiguaMes in lstSolicitudesAntiguas.Where(x => x.mes == imes && x.existeEnCarpetaDestino == "NO"))
	                {
                        if (this.rbCopiar.Checked)
                        {
                            // se crea la instruccion de copiado de archivos
                            lstscriptProcesoCarpetas.Add(string.Format(@"XCOPY {0} {1}\{2}\{3}\{4}\ /s /Y >>{5}\ArchivosCopiados{2}{3}{6}.txt", iSolicitudAntiguaMes.pathSolicitud, this.txtCarpetaDestino.Text, iSolicitudAntiguaMes.anio, iSolicitudAntiguaMes.mes.ToString().PadLeft(2,'0'), iSolicitudAntiguaMes.carpetaSolicitud, this.txtCarpetaLog.Text, DateTime.Now.Ticks.ToString()));
                        }
	                }
                    if (this.chkSobreEscribirExistentes.Checked)
                    {
                        foreach (SolicitudAntiguaEntity iSolicitudAntiguaMes in lstSolicitudesAntiguas.Where(x => x.mes == imes && x.existeEnCarpetaDestino == "SI"))
                        {
                            if (this.rbCopiar.Checked)
                            {
                                // se crea la instruccion de copiado de archivos
                                lstscriptProcesoCarpetas.Add(string.Format(@"XCOPY {0} {1}\{2}\{3}\{4}\ /s /Y >>{5}\ArchivosCopiados{2}{3}{6}.txt", iSolicitudAntiguaMes.pathSolicitud, this.txtCarpetaDestino.Text, iSolicitudAntiguaMes.anio, iSolicitudAntiguaMes.mes.ToString().PadLeft(2, '0'), iSolicitudAntiguaMes.carpetaSolicitud, this.txtCarpetaLog.Text, DateTime.Now.Ticks.ToString()));
                            }
                        }
                    }
                }
                this.dgvScriptResultante.DataSource = lstscriptProcesoCarpetas.Select(x => new { Value = x }).ToList();
                this.gbScriptResulante.Enabled = true;

            }
        }

        private void btnSeleccionarCarpetaLog_Click(object sender, EventArgs e)
        {
            var carpetaLog = this.fbdCarpetaLog.ShowDialog();
            if (carpetaLog == DialogResult.OK)
            {
                this.txtCarpetaLog.Text = this.fbdCarpetaLog.SelectedPath;
            }
        }

        private void btnGenerarBat_Click(object sender, EventArgs e)
        {
            try
            {
                // se valida que hayan registros en la grilla script resultante
                if (this.dgvScriptResultante.Rows.Count > 0)
                {
                    MessageBox.Show("Se genero con éxito el archivo " + GenerarBat());
                }
                else
                {
                    MessageBox.Show("Debe Generar un Script");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }

        /// <summary>
        /// Devuelve el nombre del .bat generado
        /// </summary>
        /// <returns>path archivo ejecutable</returns>
        private string GenerarBat()
        {
            string pathEjecutables = Path.GetFullPath("Ejecutables");
            string nombrArchivoEjecutable = string.Empty;
            string pathArchivoEjecutable = string.Empty;
            string pathMeses = string.Empty;
            try
            {
               pathMeses = string.Join("", lstMesesProcesar.Select(x=> x.ToString().PadLeft(2,'0')).ToArray());
                if (this.rbCopiar.Checked)
                {
                    nombrArchivoEjecutable = string.Format("CopiarAnio{0}_Mes{1}_{2}.bat", this.cmbAnio.SelectedItem.ToString(), pathMeses, DateTime.Now.Ticks.ToString());
                }

                string nwFinal = string.Format(@"echo Inicio copia archivos {0} meses {1} " + Environment.NewLine + "{2}"  + Environment.NewLine + "echo fin copia archivos {0} meses {1}"  + Environment.NewLine + "pause", this.cmbAnio.SelectedItem.ToString(), pathMeses, String.Join("\n", lstscriptProcesoCarpetas.ToArray()));
                pathArchivoEjecutable = pathEjecutables + @"\"+ nombrArchivoEjecutable;
                // valida si existe la carpeta de los ejecutables
                if (!Directory.Exists(pathEjecutables))
                {
                    Directory.CreateDirectory(pathEjecutables);
                }
                System.IO.File.WriteAllText(pathArchivoEjecutable, nwFinal);
                return pathArchivoEjecutable;
            }
            catch (Exception exp)
            {

                throw new Exception("Se genero el siguiente error: " + exp.Message);
            }
            
        }

        private void btnGeneracionScriptActualizacionPath_Click(object sender, EventArgs e)
        {
            try
            {
                string pathEjecutables = Path.GetFullPath("Ejecutables");
                string nombrArchivoEjecutable = string.Empty;
                string pathArchivoEjecutable = string.Empty;
                string pathMeses = string.Empty;

                if (this.dgvScriptResultante.Rows.Count > 0)
                {
                    foreach (int iMes in lstMesesProcesar)
                    {
                        lstSolicitudesNuevoPath = new System.Collections.Generic.List<SolicitudAntiguaEntity>();
                        foreach (SolicitudAntiguaEntity iSolicitudAntigua in lstSolicitudesAntiguas.Where(x=> x.mes == iMes))
                        {
                            SolicitudAntiguaEntity iSolicituAntiguaNuevopath = iSolicitudAntigua;
                            iSolicituAntiguaNuevopath.pathDocumento = iSolicituAntiguaNuevopath.pathDocumento.Replace(iSolicituAntiguaNuevopath.carpetaSolicitud, string.Format(@"{0}\{1}\{2}", iSolicituAntiguaNuevopath.anio, iSolicituAntiguaNuevopath.mes.ToString().PadLeft(2, '0'), iSolicituAntiguaNuevopath.carpetaSolicitud));
                            lstSolicitudesNuevoPath.Add(iSolicituAntiguaNuevopath);
                        }
                    }
                    pathMeses = string.Join("", lstMesesProcesar.Select(x => x.ToString().PadLeft(2, '0')).ToArray());
                    if (this.rbCopiar.Checked)
                    {
                        nombrArchivoEjecutable = string.Format("ActualizarPathsAnio{0}_Mes{1}.sql", this.cmbAnio.SelectedItem.ToString(), pathMeses);
                    }
                    string nwFinal = string.Empty;
                    foreach (SolicitudAntiguaEntity iSolicituAntiguaNuevopath in lstSolicitudesNuevoPath)
	                {
                        nwFinal += string.Format("UPDATE TABLA SET PATH_DOCUMENTO = '{0}' where ID_SOLICITUD = {1}", iSolicituAntiguaNuevopath.pathDocumento, iSolicituAntiguaNuevopath.idSolicitud) + Environment.NewLine;
	                }
                    pathArchivoEjecutable = pathEjecutables + @"\" + nombrArchivoEjecutable;
                    // valida si existe la carpeta de los ejecutables
                    if (!Directory.Exists(pathEjecutables))
                    {
                        Directory.CreateDirectory(pathEjecutables);
                    }
                    System.IO.File.WriteAllText(pathArchivoEjecutable, "USE SILPA_PRE " + Environment.NewLine + "GO" + Environment.NewLine + nwFinal);
                    MessageBox.Show("Se genero con éxito el archivo " + pathArchivoEjecutable);
                }
                else
                {
                    MessageBox.Show("Debe Generar un Script");
                }
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }
        }

        private void btnValidarCarpetasDestino_Click(object sender, EventArgs e)
        {
            string strMensajeValidacion = string.Empty;
            // validamos que haya seleccionado una carpeta de destino
            if (this.txtCarpetaDestino.Text.Trim() == string.Empty)
            {
                strMensajeValidacion += "Debe seleccionar una carpeta de destino." + Environment.NewLine;
            }
            if (this.dgvRegistros.Rows.Count == 0)
            {
                strMensajeValidacion += "Debe realizar la consulta de registros." + Environment.NewLine;
            }
            // validamos que haya seleccionado almenos un registro
            int contadorRegistrosSeleccionados = 0;
            lstMesesProcesar = new System.Collections.Generic.List<int>();

            foreach (DataGridViewRow item in this.dgvConsolidadoTamanios.Rows)
            {
                DataGridViewCheckBoxCell check = item.Cells[0] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(check.Value) == true)
                {
                    contadorRegistrosSeleccionados++;
                    lstMesesProcesar.Add(Convert.ToInt32(item.Cells[1].Value));
                }
            }
            if (contadorRegistrosSeleccionados == 0)
            {
                strMensajeValidacion += "Debe seleccionar al menos un mes para procesar." + Environment.NewLine;
            }
            if (strMensajeValidacion != string.Empty)
            {
                MessageBox.Show(strMensajeValidacion);
            }
            else 
            {
                // procede a generar el script
                foreach (int imes in lstMesesProcesar)
                {
                    Parallel.ForEach(lstSolicitudesAntiguas.Where(x => x.mes == imes), iSolicitudAntiguaMes =>
                    {
                        string strNewPath = string.Empty;
                        strNewPath = string.Format(@"{0}\{1}\{2}\{3}", this.txtCarpetaDestino.Text.Trim(), iSolicitudAntiguaMes.anio, iSolicitudAntiguaMes.mes.ToString().PadLeft(2, '0'), iSolicitudAntiguaMes.carpetaSolicitud);
                        iSolicitudAntiguaMes.newPathDocumento = strNewPath;
                        if (Directory.Exists(strNewPath))
                        {
                            iSolicitudAntiguaMes.existeEnCarpetaDestino = "SI";
                        }
                        else
                        {
                            iSolicitudAntiguaMes.existeEnCarpetaDestino = "NO";
                        }
                    });
                }
                this.dgvRegistros.DataSource = lstSolicitudesAntiguas;
                this.dgvRegistros.Refresh();
                this.gbOpcionDeProceso.Enabled = true;
            }
        }

    }
}
