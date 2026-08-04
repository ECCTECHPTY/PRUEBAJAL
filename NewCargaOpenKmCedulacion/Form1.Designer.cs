namespace NewCargaOpenKmCedulacion
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.Clave = new System.Windows.Forms.TextBox();
            this.lblCapClave = new System.Windows.Forms.Label();
            this.Usuario = new System.Windows.Forms.TextBox();
            this.lblCapUsuario = new System.Windows.Forms.Label();
            this.MetaDato = new System.Windows.Forms.ComboBox();
            this.lblCapMetadato = new System.Windows.Forms.Label();
            this.Instancia = new System.Windows.Forms.ComboBox();
            this.lblCapInstancia = new System.Windows.Forms.Label();
            this.SeleccionarRuta = new System.Windows.Forms.Button();
            this.DirectorioFuentes = new System.Windows.Forms.TextBox();
            this.lblCapRuta = new System.Windows.Forms.Label();
            this.pnlCargados = new System.Windows.Forms.Panel();
            this.Cantidad = new System.Windows.Forms.Label();
            this.lblCargadosCap = new System.Windows.Forms.Label();
            this.pnlErrores = new System.Windows.Forms.Panel();
            this.Error = new System.Windows.Forms.Label();
            this.lblErrorCap = new System.Windows.Forms.Label();
            this.IniciarProceso = new System.Windows.Forms.Button();
            this.lblProcesadosCap = new System.Windows.Forms.Label();
            this.CanProc = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.DialogoFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlHeader.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.pnlCargados.SuspendLayout();
            this.pnlErrores.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(31, 56, 100);
            this.pnlHeader.Controls.Add(this.lblVersion);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 64);
            this.pnlHeader.TabIndex = 0;
            //
            // lblVersion
            //
            this.lblVersion.AutoSize = false;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(143, 163, 196);
            this.lblVersion.Location = new System.Drawing.Point(796, 23);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(80, 18);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "v1.1.8";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(183, 196, 218);
            this.lblSubtitle.Location = new System.Drawing.Point(24, 36);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(268, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Carga masiva de documentos digitalizados";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(22, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cargador OpenKM";
            //
            // pnlCard
            //
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.Clave);
            this.pnlCard.Controls.Add(this.lblCapClave);
            this.pnlCard.Controls.Add(this.Usuario);
            this.pnlCard.Controls.Add(this.lblCapUsuario);
            this.pnlCard.Controls.Add(this.MetaDato);
            this.pnlCard.Controls.Add(this.lblCapMetadato);
            this.pnlCard.Controls.Add(this.Instancia);
            this.pnlCard.Controls.Add(this.lblCapInstancia);
            this.pnlCard.Controls.Add(this.SeleccionarRuta);
            this.pnlCard.Controls.Add(this.DirectorioFuentes);
            this.pnlCard.Controls.Add(this.lblCapRuta);
            this.pnlCard.Location = new System.Drawing.Point(24, 84);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(852, 224);
            this.pnlCard.TabIndex = 1;
            this.pnlCard.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPanel_Paint);
            //
            // lblCapRuta
            //
            this.lblCapRuta.AutoSize = true;
            this.lblCapRuta.Font = new System.Drawing.Font("Segoe UI Semibold", 8F);
            this.lblCapRuta.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCapRuta.Location = new System.Drawing.Point(20, 14);
            this.lblCapRuta.Name = "lblCapRuta";
            this.lblCapRuta.Size = new System.Drawing.Size(130, 13);
            this.lblCapRuta.TabIndex = 0;
            this.lblCapRuta.Text = "CARPETA DE ORIGEN";
            //
            // DirectorioFuentes
            //
            this.DirectorioFuentes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DirectorioFuentes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.DirectorioFuentes.Location = new System.Drawing.Point(20, 34);
            this.DirectorioFuentes.Name = "DirectorioFuentes";
            this.DirectorioFuentes.Size = new System.Drawing.Size(650, 25);
            this.DirectorioFuentes.TabIndex = 1;
            this.DirectorioFuentes.TabStop = false;
            //
            // SeleccionarRuta
            //
            this.SeleccionarRuta.BackColor = System.Drawing.Color.FromArgb(238, 242, 247);
            this.SeleccionarRuta.FlatAppearance.BorderSize = 0;
            this.SeleccionarRuta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(223, 230, 239);
            this.SeleccionarRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SeleccionarRuta.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.SeleccionarRuta.ForeColor = System.Drawing.Color.FromArgb(31, 56, 100);
            this.SeleccionarRuta.Location = new System.Drawing.Point(686, 33);
            this.SeleccionarRuta.Name = "SeleccionarRuta";
            this.SeleccionarRuta.Size = new System.Drawing.Size(146, 27);
            this.SeleccionarRuta.TabIndex = 2;
            this.SeleccionarRuta.Text = "Examinar";
            this.SeleccionarRuta.UseVisualStyleBackColor = false;
            this.SeleccionarRuta.Click += new System.EventHandler(this.SeleccionarRuta_Click);
            //
            // lblCapInstancia
            //
            this.lblCapInstancia.AutoSize = true;
            this.lblCapInstancia.Font = new System.Drawing.Font("Segoe UI Semibold", 8F);
            this.lblCapInstancia.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCapInstancia.Location = new System.Drawing.Point(20, 82);
            this.lblCapInstancia.Name = "lblCapInstancia";
            this.lblCapInstancia.Size = new System.Drawing.Size(58, 13);
            this.lblCapInstancia.TabIndex = 3;
            this.lblCapInstancia.Text = "INSTANCIA";
            //
            // Instancia
            //
            this.Instancia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Instancia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Instancia.FormattingEnabled = true;
            this.Instancia.Items.AddRange(new object[] {
            "CEDULACION",
            "REGISTRO CIVIL",
            "ORGANIZACION ELECTORAL"});
            this.Instancia.Location = new System.Drawing.Point(20, 100);
            this.Instancia.Name = "Instancia";
            this.Instancia.Size = new System.Drawing.Size(390, 25);
            this.Instancia.TabIndex = 4;
            this.Instancia.SelectedIndexChanged += new System.EventHandler(this.Instancia_SelectedIndexChanged);
            //
            // lblCapMetadato
            //
            this.lblCapMetadato.AutoSize = true;
            this.lblCapMetadato.Font = new System.Drawing.Font("Segoe UI Semibold", 8F);
            this.lblCapMetadato.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCapMetadato.Location = new System.Drawing.Point(432, 82);
            this.lblCapMetadato.Name = "lblCapMetadato";
            this.lblCapMetadato.Size = new System.Drawing.Size(65, 13);
            this.lblCapMetadato.TabIndex = 5;
            this.lblCapMetadato.Text = "METADATOS";
            //
            // MetaDato
            //
            this.MetaDato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MetaDato.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MetaDato.FormattingEnabled = true;
            this.MetaDato.Items.AddRange(new object[] {
            "CED_SOLICITUD_CEDULAS",
            "EXPEDIENTE_DE_EXTRANJEROS",
            "CED_POSITIVOS"});
            this.MetaDato.Location = new System.Drawing.Point(432, 100);
            this.MetaDato.Name = "MetaDato";
            this.MetaDato.Size = new System.Drawing.Size(390, 25);
            this.MetaDato.TabIndex = 6;
            //
            // lblCapUsuario
            //
            this.lblCapUsuario.AutoSize = true;
            this.lblCapUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 8F);
            this.lblCapUsuario.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCapUsuario.Location = new System.Drawing.Point(20, 142);
            this.lblCapUsuario.Name = "lblCapUsuario";
            this.lblCapUsuario.Size = new System.Drawing.Size(94, 13);
            this.lblCapUsuario.TabIndex = 7;
            this.lblCapUsuario.Text = "USUARIO OPENKM";
            //
            // Usuario
            //
            this.Usuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Usuario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Usuario.Location = new System.Drawing.Point(20, 160);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(390, 25);
            this.Usuario.TabIndex = 8;
            //
            // lblCapClave
            //
            this.lblCapClave.AutoSize = true;
            this.lblCapClave.Font = new System.Drawing.Font("Segoe UI Semibold", 8F);
            this.lblCapClave.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCapClave.Location = new System.Drawing.Point(432, 142);
            this.lblCapClave.Name = "lblCapClave";
            this.lblCapClave.Size = new System.Drawing.Size(37, 13);
            this.lblCapClave.TabIndex = 9;
            this.lblCapClave.Text = "CLAVE";
            //
            // Clave
            //
            this.Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Clave.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Clave.Location = new System.Drawing.Point(432, 160);
            this.Clave.Name = "Clave";
            this.Clave.PasswordChar = '*';
            this.Clave.Size = new System.Drawing.Size(390, 25);
            this.Clave.TabIndex = 10;
            //
            // pnlCargados
            //
            this.pnlCargados.BackColor = System.Drawing.Color.FromArgb(234, 243, 222);
            this.pnlCargados.Controls.Add(this.Cantidad);
            this.pnlCargados.Controls.Add(this.lblCargadosCap);
            this.pnlCargados.Location = new System.Drawing.Point(24, 324);
            this.pnlCargados.Name = "pnlCargados";
            this.pnlCargados.Size = new System.Drawing.Size(270, 64);
            this.pnlCargados.TabIndex = 2;
            //
            // lblCargadosCap
            //
            this.lblCargadosCap.AutoSize = true;
            this.lblCargadosCap.Font = new System.Drawing.Font("Segoe UI Semibold", 7.5F);
            this.lblCargadosCap.ForeColor = System.Drawing.Color.FromArgb(59, 109, 17);
            this.lblCargadosCap.Location = new System.Drawing.Point(16, 10);
            this.lblCargadosCap.Name = "lblCargadosCap";
            this.lblCargadosCap.Size = new System.Drawing.Size(140, 13);
            this.lblCargadosCap.TabIndex = 0;
            this.lblCargadosCap.Text = "ARCHIVOS ENCONTRADOS";
            //
            // Cantidad
            //
            this.Cantidad.AutoSize = false;
            this.Cantidad.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.Cantidad.ForeColor = System.Drawing.Color.FromArgb(39, 80, 10);
            this.Cantidad.Location = new System.Drawing.Point(14, 24);
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Size = new System.Drawing.Size(200, 32);
            this.Cantidad.TabIndex = 1;
            this.Cantidad.Text = "0";
            //
            // pnlErrores
            //
            this.pnlErrores.BackColor = System.Drawing.Color.FromArgb(250, 236, 231);
            this.pnlErrores.Controls.Add(this.Error);
            this.pnlErrores.Controls.Add(this.lblErrorCap);
            this.pnlErrores.Location = new System.Drawing.Point(306, 324);
            this.pnlErrores.Name = "pnlErrores";
            this.pnlErrores.Size = new System.Drawing.Size(270, 64);
            this.pnlErrores.TabIndex = 3;
            //
            // lblErrorCap
            //
            this.lblErrorCap.AutoSize = true;
            this.lblErrorCap.Font = new System.Drawing.Font("Segoe UI Semibold", 7.5F);
            this.lblErrorCap.ForeColor = System.Drawing.Color.FromArgb(153, 60, 29);
            this.lblErrorCap.Location = new System.Drawing.Point(16, 10);
            this.lblErrorCap.Name = "lblErrorCap";
            this.lblErrorCap.Size = new System.Drawing.Size(70, 13);
            this.lblErrorCap.TabIndex = 0;
            this.lblErrorCap.Text = "CON ERROR";
            //
            // Error
            //
            this.Error.AutoSize = false;
            this.Error.Font = new System.Drawing.Font("Segoe UI Semibold", 16F);
            this.Error.ForeColor = System.Drawing.Color.FromArgb(113, 43, 19);
            this.Error.Location = new System.Drawing.Point(14, 24);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(200, 32);
            this.Error.TabIndex = 1;
            this.Error.Text = "0";
            //
            // IniciarProceso
            //
            this.IniciarProceso.BackColor = System.Drawing.Color.FromArgb(46, 92, 138);
            this.IniciarProceso.FlatAppearance.BorderSize = 0;
            this.IniciarProceso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(36, 76, 116);
            this.IniciarProceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IniciarProceso.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.IniciarProceso.ForeColor = System.Drawing.Color.White;
            this.IniciarProceso.Location = new System.Drawing.Point(588, 324);
            this.IniciarProceso.Name = "IniciarProceso";
            this.IniciarProceso.Size = new System.Drawing.Size(288, 64);
            this.IniciarProceso.TabIndex = 4;
            this.IniciarProceso.Text = "Iniciar proceso";
            this.IniciarProceso.UseVisualStyleBackColor = false;
            this.IniciarProceso.Click += new System.EventHandler(this.IniciarProceso_Click);
            //
            // lblProcesadosCap
            //
            this.lblProcesadosCap.AutoSize = true;
            this.lblProcesadosCap.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblProcesadosCap.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblProcesadosCap.Location = new System.Drawing.Point(24, 405);
            this.lblProcesadosCap.Name = "lblProcesadosCap";
            this.lblProcesadosCap.Size = new System.Drawing.Size(66, 15);
            this.lblProcesadosCap.TabIndex = 5;
            this.lblProcesadosCap.Text = "Procesados:";
            //
            // CanProc
            //
            this.CanProc.AutoSize = true;
            this.CanProc.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.CanProc.ForeColor = System.Drawing.Color.FromArgb(31, 56, 100);
            this.CanProc.Location = new System.Drawing.Point(96, 405);
            this.CanProc.Name = "CanProc";
            this.CanProc.Size = new System.Drawing.Size(14, 15);
            this.CanProc.TabIndex = 6;
            this.CanProc.Text = "0";
            //
            // progressBar1
            //
            this.progressBar1.Location = new System.Drawing.Point(24, 428);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(852, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 7;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 248);
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.CanProc);
            this.Controls.Add(this.lblProcesadosCap);
            this.Controls.Add(this.IniciarProceso);
            this.Controls.Add(this.pnlErrores);
            this.Controls.Add(this.pnlCargados);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargador OpenKM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlCargados.ResumeLayout(false);
            this.pnlCargados.PerformLayout();
            this.pnlErrores.ResumeLayout(false);
            this.pnlErrores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblCapRuta;
        private System.Windows.Forms.TextBox DirectorioFuentes;
        private System.Windows.Forms.Button SeleccionarRuta;
        private System.Windows.Forms.Label lblCapInstancia;
        private System.Windows.Forms.ComboBox Instancia;
        private System.Windows.Forms.Label lblCapMetadato;
        private System.Windows.Forms.ComboBox MetaDato;
        private System.Windows.Forms.Label lblCapUsuario;
        private System.Windows.Forms.TextBox Usuario;
        private System.Windows.Forms.Label lblCapClave;
        private System.Windows.Forms.TextBox Clave;
        private System.Windows.Forms.Panel pnlCargados;
        private System.Windows.Forms.Label lblCargadosCap;
        private System.Windows.Forms.Label Cantidad;
        private System.Windows.Forms.Panel pnlErrores;
        private System.Windows.Forms.Label lblErrorCap;
        private System.Windows.Forms.Label Error;
        private System.Windows.Forms.Button IniciarProceso;
        private System.Windows.Forms.Label lblProcesadosCap;
        private System.Windows.Forms.Label CanProc;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FolderBrowserDialog DialogoFolder;
    }
}
