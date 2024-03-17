namespace PjtControlEPP.Formularios
{
    partial class FrmConsultaDespachoEPP
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn7 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewRelation gridViewRelation1 = new Telerik.WinControls.UI.GridViewRelation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaDespachoEPP));
            this.Detalles = new Telerik.WinControls.UI.GridViewTemplate();
            this.dtgDespacho = new Telerik.WinControls.UI.RadGridView();
            this.consultasFacturaEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.consultas = new PjtControlEPP.Consultas();
            this.consultasFacturaETableAdapter = new PjtControlEPP.ConsultasTableAdapters.ConsultasFacturaETableAdapter();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.PanelMenuLateral = new Telerik.WinControls.UI.RadPanel();
            this.BtnLocalizar = new System.Windows.Forms.Button();
            this.txtFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.txtFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Detalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDespacho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDespacho.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.consultasFacturaEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.consultas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelMenuLateral)).BeginInit();
            this.PanelMenuLateral.SuspendLayout();
            this.SuspendLayout();
            // 
            // Detalles
            // 
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "iddetallesfactura";
            gridViewDecimalColumn1.HeaderText = "iddetallesfactura";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "iddetallesfactura";
            gridViewDecimalColumn2.DataType = typeof(int);
            gridViewDecimalColumn2.FieldName = "idfactura";
            gridViewDecimalColumn2.HeaderText = "idfactura";
            gridViewDecimalColumn2.IsAutoGenerated = true;
            gridViewDecimalColumn2.IsVisible = false;
            gridViewDecimalColumn2.Name = "idfactura";
            gridViewDecimalColumn3.DataType = typeof(int);
            gridViewDecimalColumn3.FieldName = "cantidad";
            gridViewDecimalColumn3.HeaderText = "Cantidad";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.Name = "cantidad";
            gridViewDecimalColumn3.Width = 80;
            gridViewDecimalColumn4.DataType = typeof(int);
            gridViewDecimalColumn4.FieldName = "tiempovida";
            gridViewDecimalColumn4.HeaderText = "Tiempo vida Dias";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.Name = "tiempovida";
            gridViewDecimalColumn4.Width = 100;
            gridViewTextBoxColumn1.FieldName = "fechavence";
            gridViewTextBoxColumn1.HeaderText = "Vence";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "fechavence";
            gridViewTextBoxColumn1.Width = 100;
            gridViewDecimalColumn5.DataType = typeof(int);
            gridViewDecimalColumn5.FieldName = "idproducto";
            gridViewDecimalColumn5.HeaderText = "Codigo EPP";
            gridViewDecimalColumn5.IsAutoGenerated = true;
            gridViewDecimalColumn5.Name = "idproducto";
            gridViewDecimalColumn5.Width = 80;
            gridViewTextBoxColumn2.FieldName = "nombreepp";
            gridViewTextBoxColumn2.HeaderText = "Nombre EPP";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "nombreepp";
            gridViewTextBoxColumn2.Width = 300;
            gridViewTextBoxColumn3.FieldName = "estado";
            gridViewTextBoxColumn3.HeaderText = "estado";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "estado";
            this.Detalles.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4,
            gridViewTextBoxColumn1,
            gridViewDecimalColumn5,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.Detalles.ViewDefinition = tableViewDefinition1;
            // 
            // dtgDespacho
            // 
            this.dtgDespacho.Location = new System.Drawing.Point(200, 47);
            // 
            // 
            // 
            gridViewDecimalColumn6.DataType = typeof(int);
            gridViewDecimalColumn6.FieldName = "idfactura";
            gridViewDecimalColumn6.HeaderText = "NO";
            gridViewDecimalColumn6.IsAutoGenerated = true;
            gridViewDecimalColumn6.Name = "idfactura";
            gridViewDecimalColumn6.Width = 100;
            gridViewDateTimeColumn1.FieldName = "fecha";
            gridViewDateTimeColumn1.HeaderText = "FECHA";
            gridViewDateTimeColumn1.IsAutoGenerated = true;
            gridViewDateTimeColumn1.Name = "fecha";
            gridViewDateTimeColumn1.Width = 100;
            gridViewTextBoxColumn4.FieldName = "Cedula";
            gridViewTextBoxColumn4.HeaderText = "CEDULA";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "Cedula";
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn5.FieldName = "Nombre";
            gridViewTextBoxColumn5.HeaderText = "EMPLEADO";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "Nombre";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn6.FieldName = "Ocupacion";
            gridViewTextBoxColumn6.HeaderText = "OCUPACION";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "Ocupacion";
            gridViewTextBoxColumn6.Width = 110;
            gridViewTextBoxColumn7.FieldName = "NombrePO";
            gridViewTextBoxColumn7.HeaderText = "PROYECTO";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "NombrePO";
            gridViewTextBoxColumn7.Width = 120;
            gridViewTextBoxColumn8.FieldName = "AreaTrabajo";
            gridViewTextBoxColumn8.HeaderText = "AREA";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.Name = "AreaTrabajo";
            gridViewTextBoxColumn8.Width = 120;
            gridViewTextBoxColumn9.FieldName = "AfectaImpro";
            gridViewTextBoxColumn9.HeaderText = "AFECTA IMVPRO";
            gridViewTextBoxColumn9.IsAutoGenerated = true;
            gridViewTextBoxColumn9.Name = "AfectaImpro";
            gridViewTextBoxColumn9.Width = 100;
            gridViewTextBoxColumn10.FieldName = "usuario";
            gridViewTextBoxColumn10.HeaderText = "USUARIO";
            gridViewTextBoxColumn10.IsAutoGenerated = true;
            gridViewTextBoxColumn10.Name = "usuario";
            gridViewTextBoxColumn10.Width = 100;
            gridViewDecimalColumn7.DataType = typeof(int);
            gridViewDecimalColumn7.FieldName = "codigoaprovacion";
            gridViewDecimalColumn7.HeaderText = "CODIGO APROBACION";
            gridViewDecimalColumn7.IsAutoGenerated = true;
            gridViewDecimalColumn7.Name = "codigoaprovacion";
            gridViewDecimalColumn7.Width = 120;
            gridViewTextBoxColumn11.FieldName = "observacion";
            gridViewTextBoxColumn11.HeaderText = "OBS";
            gridViewTextBoxColumn11.IsAutoGenerated = true;
            gridViewTextBoxColumn11.Name = "observacion";
            gridViewTextBoxColumn11.Width = 150;
            gridViewTextBoxColumn12.FieldName = "OracleID";
            gridViewTextBoxColumn12.HeaderText = "OracleID";
            gridViewTextBoxColumn12.IsAutoGenerated = true;
            gridViewTextBoxColumn12.Name = "OracleID";
            this.dtgDespacho.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn6,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewDecimalColumn7,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.dtgDespacho.MasterTemplate.DataSource = this.consultasFacturaEBindingSource;
            this.dtgDespacho.MasterTemplate.EnableFiltering = true;
            this.dtgDespacho.MasterTemplate.Templates.AddRange(new Telerik.WinControls.UI.GridViewTemplate[] {
            this.Detalles});
            this.dtgDespacho.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.dtgDespacho.Name = "dtgDespacho";
            this.dtgDespacho.ReadOnly = true;
            gridViewRelation1.ChildColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ChildColumnNames")));
            gridViewRelation1.ChildTemplate = this.Detalles;
            gridViewRelation1.ParentColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ParentColumnNames")));
            gridViewRelation1.ParentTemplate = this.dtgDespacho.MasterTemplate;
            gridViewRelation1.RelationName = "idfactura";
            this.dtgDespacho.Relations.AddRange(new Telerik.WinControls.UI.GridViewRelation[] {
            gridViewRelation1});
            this.dtgDespacho.Size = new System.Drawing.Size(989, 561);
            this.dtgDespacho.TabIndex = 268;
            this.dtgDespacho.DoubleClick += new System.EventHandler(this.dtgDespacho_DoubleClick);
            // 
            // consultasFacturaEBindingSource
            // 
            this.consultasFacturaEBindingSource.DataMember = "ConsultasFacturaE";
            this.consultasFacturaEBindingSource.DataSource = this.consultas;
            // 
            // consultas
            // 
            this.consultas.DataSetName = "Consultas";
            this.consultas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // consultasFacturaETableAdapter
            // 
            this.consultasFacturaETableAdapter.ClearBeforeFill = true;
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.radPanel2.Controls.Add(this.BtnCancelar);
            this.radPanel2.Location = new System.Drawing.Point(-2, -1);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1204, 42);
            this.radPanel2.TabIndex = 266;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(1111, 3);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 33);
            this.BtnCancelar.TabIndex = 1;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // PanelMenuLateral
            // 
            this.PanelMenuLateral.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PanelMenuLateral.Controls.Add(this.BtnLocalizar);
            this.PanelMenuLateral.Controls.Add(this.txtFechaHasta);
            this.PanelMenuLateral.Controls.Add(this.txtFechaDesde);
            this.PanelMenuLateral.Controls.Add(this.label2);
            this.PanelMenuLateral.Controls.Add(this.label1);
            this.PanelMenuLateral.Location = new System.Drawing.Point(-2, 40);
            this.PanelMenuLateral.Name = "PanelMenuLateral";
            this.PanelMenuLateral.Size = new System.Drawing.Size(203, 583);
            this.PanelMenuLateral.TabIndex = 267;
            // 
            // BtnLocalizar
            // 
            this.BtnLocalizar.Location = new System.Drawing.Point(72, 79);
            this.BtnLocalizar.Name = "BtnLocalizar";
            this.BtnLocalizar.Size = new System.Drawing.Size(126, 33);
            this.BtnLocalizar.TabIndex = 2;
            this.BtnLocalizar.Text = "LOCALIZAR FECHA";
            this.BtnLocalizar.UseVisualStyleBackColor = true;
            this.BtnLocalizar.Click += new System.EventHandler(this.BtnLocalizar_Click);
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFechaHasta.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtFechaHasta.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtFechaHasta.Location = new System.Drawing.Point(108, 56);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFechaHasta.Size = new System.Drawing.Size(90, 17);
            this.txtFechaHasta.TabIndex = 3;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFechaDesde.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtFechaDesde.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtFechaDesde.Location = new System.Drawing.Point(108, 30);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFechaDesde.Size = new System.Drawing.Size(90, 17);
            this.txtFechaDesde.TabIndex = 2;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 290;
            this.label2.Text = "Fecha hasta";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 288;
            this.label1.Text = "Fecha desde";
            // 
            // FrmConsultaDespachoEPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1197, 620);
            this.Controls.Add(this.dtgDespacho);
            this.Controls.Add(this.PanelMenuLateral);
            this.Controls.Add(this.radPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultaDespachoEPP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConsultaDespachoEPP";
            this.Load += new System.EventHandler(this.FrmConsultaDespachoEPP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Detalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDespacho.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDespacho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.consultasFacturaEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.consultas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelMenuLateral)).EndInit();
            this.PanelMenuLateral.ResumeLayout(false);
            this.PanelMenuLateral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource consultasFacturaEBindingSource;
        private Consultas consultas;
        private ConsultasTableAdapters.ConsultasFacturaETableAdapter consultasFacturaETableAdapter;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private System.Windows.Forms.Button BtnCancelar;
        private Telerik.WinControls.UI.RadPanel PanelMenuLateral;
        private System.Windows.Forms.Button BtnLocalizar;
        internal System.Windows.Forms.MaskedTextBox txtFechaHasta;
        internal System.Windows.Forms.MaskedTextBox txtFechaDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGridView dtgDespacho;
        private Telerik.WinControls.UI.GridViewTemplate Detalles;




    }
}