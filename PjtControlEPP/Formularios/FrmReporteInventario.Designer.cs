namespace PjtControlEPP.Formularios
{
    partial class FrmReporteInventario
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportes = new PjtControlEPP.Reportes();
            this.reporteInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteInventarioTableAdapter = new PjtControlEPP.ReportesTableAdapters.ReporteInventarioTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteInventarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reporteInventarioBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PjtControlEPP.Formularios.ReporteInventario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(860, 499);
            this.reportViewer1.TabIndex = 0;
            // 
            // reportes
            // 
            this.reportes.DataSetName = "Reportes";
            this.reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteInventarioBindingSource
            // 
            this.reporteInventarioBindingSource.DataMember = "ReporteInventario";
            this.reporteInventarioBindingSource.DataSource = this.reportes;
            // 
            // reporteInventarioTableAdapter
            // 
            this.reporteInventarioTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 499);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReporteInventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReporteInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteInventarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reportes reportes;
        private System.Windows.Forms.BindingSource reporteInventarioBindingSource;
        private ReportesTableAdapters.ReporteInventarioTableAdapter reporteInventarioTableAdapter;
    }
}