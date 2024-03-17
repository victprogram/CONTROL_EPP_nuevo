namespace PjtControlEPP.Formularios
{
    partial class FrmConsultaEmpleados
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dtgEmpleados = new Telerik.WinControls.UI.RadGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmpleados.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgEmpleados
            // 
            this.dtgEmpleados.Location = new System.Drawing.Point(20, 46);
            // 
            // 
            // 
            gridViewTextBoxColumn1.HeaderText = "Codigo";
            gridViewTextBoxColumn1.Name = "idempleado";
            gridViewTextBoxColumn1.Width = 80;
            gridViewTextBoxColumn2.HeaderText = "Oracle ID";
            gridViewTextBoxColumn2.Name = "OracleID";
            gridViewTextBoxColumn2.Width = 80;
            gridViewTextBoxColumn3.HeaderText = "Cedula";
            gridViewTextBoxColumn3.Name = "cedula";
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn4.HeaderText = "Nombre";
            gridViewTextBoxColumn4.Name = "nombre";
            gridViewTextBoxColumn4.Width = 220;
            gridViewTextBoxColumn5.HeaderText = "Apellido";
            gridViewTextBoxColumn5.Name = "apellido";
            gridViewTextBoxColumn5.Width = 220;
            gridViewTextBoxColumn6.HeaderText = "Ocupación";
            gridViewTextBoxColumn6.Name = "ocupacion";
            gridViewTextBoxColumn6.Width = 130;
            gridViewTextBoxColumn7.HeaderText = "Area";
            gridViewTextBoxColumn7.Name = "nombrearea";
            gridViewTextBoxColumn7.Width = 150;
            gridViewTextBoxColumn8.HeaderText = "Telefono";
            gridViewTextBoxColumn8.Name = "telefono";
            gridViewTextBoxColumn8.Width = 110;
            this.dtgEmpleados.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.dtgEmpleados.MasterTemplate.EnableFiltering = true;
            this.dtgEmpleados.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dtgEmpleados.Name = "dtgEmpleados";
            this.dtgEmpleados.ReadOnly = true;
            this.dtgEmpleados.Size = new System.Drawing.Size(979, 593);
            this.dtgEmpleados.TabIndex = 1;
            this.dtgEmpleados.DoubleClick += new System.EventHandler(this.dtgEmpleados_DoubleClick);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::PjtControlEPP.Properties.Resources.close_form1;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCerrar.Location = new System.Drawing.Point(951, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(45, 26);
            this.btnCerrar.TabIndex = 210;
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmConsultaEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1024, 670);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dtgEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultaEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConsultaEmpleados";
            this.Load += new System.EventHandler(this.FrmConsultaEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmpleados.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dtgEmpleados;
        private System.Windows.Forms.Button btnCerrar;




    }
}