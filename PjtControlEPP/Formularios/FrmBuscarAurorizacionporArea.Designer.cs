namespace PjtControlEPP.Formularios
{
    partial class FrmBuscarAurorizacionporArea
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
            this.label2 = new System.Windows.Forms.Label();
            this.CmbArea = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtError = new System.Windows.Forms.TextBox();
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
            this.btnGuardar.Location = new System.Drawing.Point(312, 284);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(181, 37);
            this.btnGuardar.TabIndex = 194;
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
            this.btnCancelar.Location = new System.Drawing.Point(499, 284);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(180, 37);
            this.btnCancelar.TabIndex = 195;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.CmbArea);
            this.radGroupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "SELECIONAR EL AREA";
            this.radGroupBox1.Location = new System.Drawing.Point(312, 131);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(367, 138);
            this.radGroupBox1.TabIndex = 193;
            this.radGroupBox1.Text = "SELECIONAR EL AREA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Area";
            // 
            // CmbArea
            // 
            this.CmbArea.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbArea.ForeColor = System.Drawing.Color.SteelBlue;
            this.CmbArea.FormattingEnabled = true;
            this.CmbArea.Location = new System.Drawing.Point(66, 48);
            this.CmbArea.Name = "CmbArea";
            this.CmbArea.Size = new System.Drawing.Size(296, 26);
            this.CmbArea.TabIndex = 12;
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
            this.txtTitle.TabIndex = 196;
            this.txtTitle.Text = "Listado de Areas";
            // 
            // txtError
            // 
            this.txtError.BackColor = System.Drawing.SystemColors.Info;
            this.txtError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtError.Enabled = false;
            this.txtError.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.Location = new System.Drawing.Point(0, 580);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.ReadOnly = true;
            this.txtError.Size = new System.Drawing.Size(1024, 20);
            this.txtError.TabIndex = 197;
            this.txtError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmBuscarAurorizacionporArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.ControlBox = false;
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBuscarAurorizacionporArea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuscarAurorizacionporArea";
            this.Load += new System.EventHandler(this.FrmBuscarAurorizacionporArea_Load);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbArea;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtError;
    }
}