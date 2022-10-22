namespace WinProcesoArchivosVITAL
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.grbConsulta = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.idSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroSilpa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carpetaSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tamanioCarpetaBytes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NuevoPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExisteEnDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solFechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autoridadNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dgvConsolidadoTamanios = new System.Windows.Forms.DataGridView();
            this.Seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mesSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCarpetaDestino = new System.Windows.Forms.TextBox();
            this.fbdCarpetaDestino = new System.Windows.Forms.FolderBrowserDialog();
            this.rbCopiar = new System.Windows.Forms.RadioButton();
            this.rbMover = new System.Windows.Forms.RadioButton();
            this.btnGenerarScript = new System.Windows.Forms.Button();
            this.gbOpcionDeProceso = new System.Windows.Forms.GroupBox();
            this.chkSobreEscribirExistentes = new System.Windows.Forms.CheckBox();
            this.dgvScriptResultante = new System.Windows.Forms.DataGridView();
            this.gbScriptResulante = new System.Windows.Forms.GroupBox();
            this.btnGeneracionScriptActualizacionPath = new System.Windows.Forms.Button();
            this.btnGenerarEjecutarbat = new System.Windows.Forms.Button();
            this.btnGenerarBat = new System.Windows.Forms.Button();
            this.btnSeleccionarCarpetaLog = new System.Windows.Forms.Button();
            this.txtCarpetaLog = new System.Windows.Forms.TextBox();
            this.fbdCarpetaLog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnValidarCarpetasDestino = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCarpetasNosEncontradas = new System.Windows.Forms.TextBox();
            this.grbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsolidadoTamanios)).BeginInit();
            this.gbOpcionDeProceso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScriptResultante)).BeginInit();
            this.gbScriptResulante.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(80, 37);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(172, 28);
            this.cmbAnio.TabIndex = 0;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(36, 40);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(38, 20);
            this.lblAnio.TabIndex = 1;
            this.lblAnio.Text = "Año";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(271, 40);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(39, 20);
            this.lblMes.TabIndex = 2;
            this.lblMes.Text = "Mes";
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(316, 37);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(121, 28);
            this.cmbMes.TabIndex = 3;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(490, 28);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(107, 44);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // grbConsulta
            // 
            this.grbConsulta.Controls.Add(this.btnConsultar);
            this.grbConsulta.Controls.Add(this.cmbMes);
            this.grbConsulta.Controls.Add(this.lblMes);
            this.grbConsulta.Controls.Add(this.lblAnio);
            this.grbConsulta.Controls.Add(this.cmbAnio);
            this.grbConsulta.Location = new System.Drawing.Point(43, 20);
            this.grbConsulta.Name = "grbConsulta";
            this.grbConsulta.Size = new System.Drawing.Size(726, 105);
            this.grbConsulta.TabIndex = 5;
            this.grbConsulta.TabStop = false;
            this.grbConsulta.Text = "Consulta";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(803, 32);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(291, 31);
            this.progressBar1.TabIndex = 6;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.AllowUserToAddRows = false;
            this.dgvRegistros.AllowUserToDeleteRows = false;
            this.dgvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSolicitud,
            this.numeroSilpa,
            this.pathDocumento,
            this.pathSolicitud,
            this.carpetaSolicitud,
            this.año,
            this.mes,
            this.tamanioCarpetaBytes,
            this.NuevoPath,
            this.ExisteEnDestino,
            this.solFechaRegistro,
            this.autoridadNombre,
            this.solicitante});
            this.dgvRegistros.Location = new System.Drawing.Point(70, 158);
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.ReadOnly = true;
            this.dgvRegistros.RowHeadersVisible = false;
            this.dgvRegistros.RowTemplate.Height = 28;
            this.dgvRegistros.Size = new System.Drawing.Size(1248, 495);
            this.dgvRegistros.TabIndex = 7;
            // 
            // idSolicitud
            // 
            this.idSolicitud.DataPropertyName = "idSolicitud";
            this.idSolicitud.HeaderText = "idSolicitud";
            this.idSolicitud.Name = "idSolicitud";
            this.idSolicitud.ReadOnly = true;
            this.idSolicitud.Width = 60;
            // 
            // numeroSilpa
            // 
            this.numeroSilpa.DataPropertyName = "numeroSilpa";
            this.numeroSilpa.HeaderText = "numeroSilpa";
            this.numeroSilpa.Name = "numeroSilpa";
            this.numeroSilpa.ReadOnly = true;
            // 
            // pathDocumento
            // 
            this.pathDocumento.DataPropertyName = "pathDocumento";
            this.pathDocumento.HeaderText = "pathDocumento";
            this.pathDocumento.Name = "pathDocumento";
            this.pathDocumento.ReadOnly = true;
            // 
            // pathSolicitud
            // 
            this.pathSolicitud.DataPropertyName = "pathSolicitud";
            this.pathSolicitud.HeaderText = "pathSolicitud";
            this.pathSolicitud.Name = "pathSolicitud";
            this.pathSolicitud.ReadOnly = true;
            // 
            // carpetaSolicitud
            // 
            this.carpetaSolicitud.DataPropertyName = "carpetaSolicitud";
            this.carpetaSolicitud.HeaderText = "carpetaSolicitud";
            this.carpetaSolicitud.Name = "carpetaSolicitud";
            this.carpetaSolicitud.ReadOnly = true;
            // 
            // año
            // 
            this.año.DataPropertyName = "anio";
            this.año.HeaderText = "anio";
            this.año.Name = "año";
            this.año.ReadOnly = true;
            this.año.Width = 50;
            // 
            // mes
            // 
            this.mes.DataPropertyName = "mes";
            this.mes.HeaderText = "mes";
            this.mes.Name = "mes";
            this.mes.ReadOnly = true;
            this.mes.Width = 30;
            // 
            // tamanioCarpetaBytes
            // 
            this.tamanioCarpetaBytes.DataPropertyName = "tamanioCarpetaBytes";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.tamanioCarpetaBytes.DefaultCellStyle = dataGridViewCellStyle1;
            this.tamanioCarpetaBytes.HeaderText = "tamanioCarpetaBytes";
            this.tamanioCarpetaBytes.Name = "tamanioCarpetaBytes";
            this.tamanioCarpetaBytes.ReadOnly = true;
            // 
            // NuevoPath
            // 
            this.NuevoPath.DataPropertyName = "newPathDocumento";
            this.NuevoPath.HeaderText = "Nuevo Path";
            this.NuevoPath.Name = "NuevoPath";
            this.NuevoPath.ReadOnly = true;
            // 
            // ExisteEnDestino
            // 
            this.ExisteEnDestino.DataPropertyName = "existeEnCarpetaDestino";
            this.ExisteEnDestino.HeaderText = "Existe";
            this.ExisteEnDestino.Name = "ExisteEnDestino";
            this.ExisteEnDestino.ReadOnly = true;
            this.ExisteEnDestino.Width = 50;
            // 
            // solFechaRegistro
            // 
            this.solFechaRegistro.DataPropertyName = "solFechaRegistro";
            this.solFechaRegistro.HeaderText = "solFechaRegistro";
            this.solFechaRegistro.Name = "solFechaRegistro";
            this.solFechaRegistro.ReadOnly = true;
            this.solFechaRegistro.Visible = false;
            // 
            // autoridadNombre
            // 
            this.autoridadNombre.DataPropertyName = "autoridadNombre";
            this.autoridadNombre.HeaderText = "autoridadNombre";
            this.autoridadNombre.Name = "autoridadNombre";
            this.autoridadNombre.ReadOnly = true;
            this.autoridadNombre.Visible = false;
            // 
            // solicitante
            // 
            this.solicitante.DataPropertyName = "solicitante";
            this.solicitante.HeaderText = "solicitante";
            this.solicitante.Name = "solicitante";
            this.solicitante.ReadOnly = true;
            this.solicitante.Visible = false;
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(79, 668);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(99, 20);
            this.lblRegistros.TabIndex = 8;
            this.lblRegistros.Text = "Nro registros";
            // 
            // dgvConsolidadoTamanios
            // 
            this.dgvConsolidadoTamanios.AllowUserToAddRows = false;
            this.dgvConsolidadoTamanios.AllowUserToDeleteRows = false;
            this.dgvConsolidadoTamanios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsolidadoTamanios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccion,
            this.mesSize,
            this.size});
            this.dgvConsolidadoTamanios.Location = new System.Drawing.Point(1362, 158);
            this.dgvConsolidadoTamanios.Name = "dgvConsolidadoTamanios";
            this.dgvConsolidadoTamanios.RowHeadersVisible = false;
            this.dgvConsolidadoTamanios.RowTemplate.Height = 28;
            this.dgvConsolidadoTamanios.Size = new System.Drawing.Size(314, 229);
            this.dgvConsolidadoTamanios.TabIndex = 10;
            // 
            // Seleccion
            // 
            this.Seleccion.HeaderText = "Seleccion";
            this.Seleccion.Name = "Seleccion";
            this.Seleccion.Width = 85;
            // 
            // mesSize
            // 
            this.mesSize.DataPropertyName = "mes";
            this.mesSize.HeaderText = "Mes";
            this.mesSize.Name = "mesSize";
            this.mesSize.ReadOnly = true;
            this.mesSize.Width = 50;
            // 
            // size
            // 
            this.size.DataPropertyName = "sizeMB";
            this.size.HeaderText = "Tamaño MB";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(803, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(279, 33);
            this.button1.TabIndex = 12;
            this.button1.Text = "Seleccionar carpeta destino";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCarpetaDestino
            // 
            this.txtCarpetaDestino.Location = new System.Drawing.Point(1099, 86);
            this.txtCarpetaDestino.Name = "txtCarpetaDestino";
            this.txtCarpetaDestino.ReadOnly = true;
            this.txtCarpetaDestino.Size = new System.Drawing.Size(366, 26);
            this.txtCarpetaDestino.TabIndex = 13;
            // 
            // rbCopiar
            // 
            this.rbCopiar.AutoSize = true;
            this.rbCopiar.Location = new System.Drawing.Point(11, 34);
            this.rbCopiar.Name = "rbCopiar";
            this.rbCopiar.Size = new System.Drawing.Size(80, 24);
            this.rbCopiar.TabIndex = 14;
            this.rbCopiar.TabStop = true;
            this.rbCopiar.Text = "Copiar";
            this.rbCopiar.UseVisualStyleBackColor = true;
            // 
            // rbMover
            // 
            this.rbMover.AutoSize = true;
            this.rbMover.Location = new System.Drawing.Point(118, 34);
            this.rbMover.Name = "rbMover";
            this.rbMover.Size = new System.Drawing.Size(77, 24);
            this.rbMover.TabIndex = 15;
            this.rbMover.TabStop = true;
            this.rbMover.Text = "Mover";
            this.rbMover.UseVisualStyleBackColor = true;
            // 
            // btnGenerarScript
            // 
            this.btnGenerarScript.Location = new System.Drawing.Point(11, 118);
            this.btnGenerarScript.Name = "btnGenerarScript";
            this.btnGenerarScript.Size = new System.Drawing.Size(235, 43);
            this.btnGenerarScript.TabIndex = 16;
            this.btnGenerarScript.Text = "Generar Script";
            this.btnGenerarScript.UseVisualStyleBackColor = true;
            this.btnGenerarScript.Click += new System.EventHandler(this.btnGenerarScript_Click);
            // 
            // gbOpcionDeProceso
            // 
            this.gbOpcionDeProceso.Controls.Add(this.chkSobreEscribirExistentes);
            this.gbOpcionDeProceso.Controls.Add(this.btnGenerarScript);
            this.gbOpcionDeProceso.Controls.Add(this.rbMover);
            this.gbOpcionDeProceso.Controls.Add(this.rbCopiar);
            this.gbOpcionDeProceso.Enabled = false;
            this.gbOpcionDeProceso.Location = new System.Drawing.Point(1362, 578);
            this.gbOpcionDeProceso.Name = "gbOpcionDeProceso";
            this.gbOpcionDeProceso.Size = new System.Drawing.Size(314, 183);
            this.gbOpcionDeProceso.TabIndex = 17;
            this.gbOpcionDeProceso.TabStop = false;
            this.gbOpcionDeProceso.Text = "Opcion";
            // 
            // chkSobreEscribirExistentes
            // 
            this.chkSobreEscribirExistentes.AutoSize = true;
            this.chkSobreEscribirExistentes.Location = new System.Drawing.Point(18, 78);
            this.chkSobreEscribirExistentes.Name = "chkSobreEscribirExistentes";
            this.chkSobreEscribirExistentes.Size = new System.Drawing.Size(208, 24);
            this.chkSobreEscribirExistentes.TabIndex = 17;
            this.chkSobreEscribirExistentes.Text = "Sobre escribir existentes";
            this.chkSobreEscribirExistentes.UseVisualStyleBackColor = true;
            // 
            // dgvScriptResultante
            // 
            this.dgvScriptResultante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScriptResultante.Location = new System.Drawing.Point(41, 32);
            this.dgvScriptResultante.Name = "dgvScriptResultante";
            this.dgvScriptResultante.RowTemplate.Height = 28;
            this.dgvScriptResultante.Size = new System.Drawing.Size(977, 150);
            this.dgvScriptResultante.TabIndex = 18;
            // 
            // gbScriptResulante
            // 
            this.gbScriptResulante.Controls.Add(this.btnGeneracionScriptActualizacionPath);
            this.gbScriptResulante.Controls.Add(this.btnGenerarEjecutarbat);
            this.gbScriptResulante.Controls.Add(this.btnGenerarBat);
            this.gbScriptResulante.Controls.Add(this.dgvScriptResultante);
            this.gbScriptResulante.Enabled = false;
            this.gbScriptResulante.Location = new System.Drawing.Point(70, 720);
            this.gbScriptResulante.Name = "gbScriptResulante";
            this.gbScriptResulante.Size = new System.Drawing.Size(1059, 259);
            this.gbScriptResulante.TabIndex = 19;
            this.gbScriptResulante.TabStop = false;
            this.gbScriptResulante.Text = "Script Resultante";
            // 
            // btnGeneracionScriptActualizacionPath
            // 
            this.btnGeneracionScriptActualizacionPath.Location = new System.Drawing.Point(433, 204);
            this.btnGeneracionScriptActualizacionPath.Name = "btnGeneracionScriptActualizacionPath";
            this.btnGeneracionScriptActualizacionPath.Size = new System.Drawing.Size(311, 38);
            this.btnGeneracionScriptActualizacionPath.TabIndex = 21;
            this.btnGeneracionScriptActualizacionPath.Text = "Generar Script Actualizacion de Path";
            this.btnGeneracionScriptActualizacionPath.UseVisualStyleBackColor = true;
            this.btnGeneracionScriptActualizacionPath.Click += new System.EventHandler(this.btnGeneracionScriptActualizacionPath_Click);
            // 
            // btnGenerarEjecutarbat
            // 
            this.btnGenerarEjecutarbat.Location = new System.Drawing.Point(198, 204);
            this.btnGenerarEjecutarbat.Name = "btnGenerarEjecutarbat";
            this.btnGenerarEjecutarbat.Size = new System.Drawing.Size(195, 38);
            this.btnGenerarEjecutarbat.TabIndex = 20;
            this.btnGenerarEjecutarbat.Text = "Generar y Ejecutar .bat";
            this.btnGenerarEjecutarbat.UseVisualStyleBackColor = true;
            // 
            // btnGenerarBat
            // 
            this.btnGenerarBat.Location = new System.Drawing.Point(42, 204);
            this.btnGenerarBat.Name = "btnGenerarBat";
            this.btnGenerarBat.Size = new System.Drawing.Size(123, 38);
            this.btnGenerarBat.TabIndex = 19;
            this.btnGenerarBat.Text = "Generar .bat";
            this.btnGenerarBat.UseVisualStyleBackColor = true;
            this.btnGenerarBat.Click += new System.EventHandler(this.btnGenerarBat_Click);
            // 
            // btnSeleccionarCarpetaLog
            // 
            this.btnSeleccionarCarpetaLog.Location = new System.Drawing.Point(1061, 668);
            this.btnSeleccionarCarpetaLog.Name = "btnSeleccionarCarpetaLog";
            this.btnSeleccionarCarpetaLog.Size = new System.Drawing.Size(279, 36);
            this.btnSeleccionarCarpetaLog.TabIndex = 20;
            this.btnSeleccionarCarpetaLog.Text = "Seleccionar carpeta Log";
            this.btnSeleccionarCarpetaLog.UseVisualStyleBackColor = true;
            this.btnSeleccionarCarpetaLog.Click += new System.EventHandler(this.btnSeleccionarCarpetaLog_Click);
            // 
            // txtCarpetaLog
            // 
            this.txtCarpetaLog.Location = new System.Drawing.Point(538, 673);
            this.txtCarpetaLog.Name = "txtCarpetaLog";
            this.txtCarpetaLog.ReadOnly = true;
            this.txtCarpetaLog.Size = new System.Drawing.Size(512, 26);
            this.txtCarpetaLog.TabIndex = 21;
            // 
            // btnValidarCarpetasDestino
            // 
            this.btnValidarCarpetasDestino.Location = new System.Drawing.Point(1362, 402);
            this.btnValidarCarpetasDestino.Name = "btnValidarCarpetasDestino";
            this.btnValidarCarpetasDestino.Size = new System.Drawing.Size(314, 66);
            this.btnValidarCarpetasDestino.TabIndex = 22;
            this.btnValidarCarpetasDestino.Text = "Validar Carpeta Destino";
            this.btnValidarCarpetasDestino.UseVisualStyleBackColor = true;
            this.btnValidarCarpetasDestino.Click += new System.EventHandler(this.btnValidarCarpetasDestino_Click);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(1362, 471);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 104);
            this.label1.TabIndex = 23;
            this.label1.Text = "Valida la existencia de las carpetas con nueva estructura en la carpeta de destin" +
    "o";
            // 
            // txtCarpetasNosEncontradas
            // 
            this.txtCarpetasNosEncontradas.Location = new System.Drawing.Point(1165, 778);
            this.txtCarpetasNosEncontradas.Multiline = true;
            this.txtCarpetasNosEncontradas.Name = "txtCarpetasNosEncontradas";
            this.txtCarpetasNosEncontradas.Size = new System.Drawing.Size(511, 201);
            this.txtCarpetasNosEncontradas.TabIndex = 24;
            this.txtCarpetasNosEncontradas.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1748, 1050);
            this.Controls.Add(this.txtCarpetasNosEncontradas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnValidarCarpetasDestino);
            this.Controls.Add(this.txtCarpetaLog);
            this.Controls.Add(this.btnSeleccionarCarpetaLog);
            this.Controls.Add(this.gbScriptResulante);
            this.Controls.Add(this.gbOpcionDeProceso);
            this.Controls.Add(this.txtCarpetaDestino);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvConsolidadoTamanios);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.dgvRegistros);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.grbConsulta);
            this.Name = "Form1";
            this.Text = "FileTransferVITAL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbConsulta.ResumeLayout(false);
            this.grbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsolidadoTamanios)).EndInit();
            this.gbOpcionDeProceso.ResumeLayout(false);
            this.gbOpcionDeProceso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScriptResultante)).EndInit();
            this.gbScriptResulante.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.GroupBox grbConsulta;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dgvConsolidadoTamanios;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCarpetaDestino;
        private System.Windows.Forms.FolderBrowserDialog fbdCarpetaDestino;
        private System.Windows.Forms.RadioButton rbCopiar;
        private System.Windows.Forms.RadioButton rbMover;
        private System.Windows.Forms.Button btnGenerarScript;
        private System.Windows.Forms.GroupBox gbOpcionDeProceso;
        private System.Windows.Forms.DataGridView dgvScriptResultante;
        private System.Windows.Forms.GroupBox gbScriptResulante;
        private System.Windows.Forms.Button btnSeleccionarCarpetaLog;
        private System.Windows.Forms.TextBox txtCarpetaLog;
        private System.Windows.Forms.FolderBrowserDialog fbdCarpetaLog;
        private System.Windows.Forms.Button btnGenerarEjecutarbat;
        private System.Windows.Forms.Button btnGenerarBat;
        private System.Windows.Forms.Button btnGeneracionScriptActualizacionPath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.Button btnValidarCarpetasDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroSilpa;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn carpetaSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn año;
        private System.Windows.Forms.DataGridViewTextBoxColumn mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamanioCarpetaBytes;
        private System.Windows.Forms.DataGridViewTextBoxColumn NuevoPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExisteEnDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn solFechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn autoridadNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn solicitante;
        private System.Windows.Forms.CheckBox chkSobreEscribirExistentes;
        private System.Windows.Forms.TextBox txtCarpetasNosEncontradas;
    }
}

