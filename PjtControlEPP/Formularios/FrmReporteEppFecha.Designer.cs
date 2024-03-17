namespace PjtControlEPP.Formularios
{
    partial class FrmReporteEppFecha
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportes1 = new PjtControlEPP.Reportes();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.facturaeppfechaTableAdapter1 = new PjtControlEPP.ReportesTableAdapters.facturaeppfechaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportes1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bindingSource1;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "PjtControlEPP.Formularios.ReportFacturaEppFecha.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(844, 628);
            this.reportViewer2.TabIndex = 0;
            // 
            // reportes1
            // 
            this.reportes1.DataSetName = "Reportes";
            this.reportes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "facturaeppfecha";
            this.bindingSource1.DataSource = this.reportes1;
            // 
            // facturaeppfechaTableAdapter1
            // 
            this.facturaeppfechaTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmReporteEppFecha
            // 
            this.ClientSize = new System.Drawing.Size(844, 628);
            this.Controls.Add(this.reportViewer2);
            this.Name = "FrmReporteEppFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReporteEppFecha_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.reportes1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reportes reportes;
        private System.Windows.Forms.BindingSource facturaEppFechaBindingSource;
      //  private ReportesTableAdapters.FacturaEppFechaTableAdapter facturaEppFechaTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private Reportes reportes1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private ReportesTableAdapters.facturaeppfechaTableAdapter facturaeppfechaTableAdapter1;
    }
}