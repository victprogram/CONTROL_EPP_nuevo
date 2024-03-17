namespace PjtControlEPP.Formularios
{
    partial class FrmBuscarDespachoEppArea
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
            if (disposing && (components != null))
            {
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DtpFinal = new System.Windows.Forms.DateTimePicker();
            this.CmbArea = new System.Windows.Forms.ComboBox();
            this.DtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnGuardar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnGuardar.Location = new System.Drawing.Point(304, 266);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(196, 37);
            this.btnGuardar.TabIndex = 196;
            this.btnGuardar.Text = "Aceptar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnCancelar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCancelar.Location = new System.Drawing.Point(506, 266);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(191, 37);
            this.btnCancelar.TabIndex = 197;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.label6);
            this.radGroupBox1.Controls.Add(this.DtpFinal);
            this.radGroupBox1.Controls.Add(this.CmbArea);
            this.radGroupBox1.Controls.Add(this.DtpInicio);
            this.radGroupBox1.Controls.Add(this.label4);
            this.radGroupBox1.Controls.Add(this.label5);
            this.radGroupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "SELECCIONE UN RANGO DE FECHA ";
            this.radGroupBox1.Location = new System.Drawing.Point(304, 110);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(393, 137);
            this.radGroupBox1.TabIndex = 195;
            this.radGroupBox1.Text = "SELECCIONE UN RANGO DE FECHA ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(66, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 18);
            this.label6.TabIndex = 199;
            this.label6.Text = "Area";
            // 
            // DtpFinal
            // 
            this.DtpFinal.CalendarTitleForeColor = System.Drawing.Color.SteelBlue;
            this.DtpFinal.Font = new System.Drawing.Font("Verdana", 9F);
            this.DtpFinal.Location = new System.Drawing.Point(117, 62);
            this.DtpFinal.Name = "DtpFinal";
            this.DtpFinal.Size = new System.Drawing.Size(261, 22);
            this.DtpFinal.TabIndex = 19;
            // 
            // CmbArea
            // 
            this.CmbArea.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbArea.ForeColor = System.Drawing.Color.SteelBlue;
            this.CmbArea.FormattingEnabled = true;
            this.CmbArea.Location = new System.Drawing.Point(117, 90);
            this.CmbArea.Name = "CmbArea";
            this.CmbArea.Size = new System.Drawing.Size(261, 26);
            this.CmbArea.TabIndex = 198;
            // 
            // DtpInicio
            // 
            this.DtpInicio.CalendarTitleForeColor = System.Drawing.Color.SteelBlue;
            this.DtpInicio.Font = new System.Drawing.Font("Verdana", 9F);
            this.DtpInicio.Location = new System.Drawing.Point(117, 28);
            this.DtpInicio.Name = "DtpInicio";
            this.DtpInicio.Size = new System.Drawing.Size(261, 22);
            this.DtpInicio.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha Inicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha Final";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTitle.Enabled = false;
            this.txtTitle.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.Black;
            this.txtTitle.Location = new System.Drawing.Point(0, 0);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(1024, 20);
            this.txtTitle.TabIndex = 198;
            this.txtTitle.Text = "Consultar despacho EPP";
            // 
            // FrmBuscarDespachoEppArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.ControlBox = false;
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBuscarDespachoEppArea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuscarDespachoEppArea";
            this.Load += new System.EventHandler(this.FrmBuscarDespachoEppArea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.DateTimePicker DtpFinal;
        private System.Windows.Forms.DateTimePicker DtpInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbArea;
        private System.Windows.Forms.TextBox txtTitle;
    }
}