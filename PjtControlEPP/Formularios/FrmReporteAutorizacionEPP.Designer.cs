namespace PjtControlEPP.Formularios
{
    partial class FrmReporteAutorizacionEPP
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportes = new PjtControlEPP.Reportes();
            this.reporteAutorizacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteAutorizacionTableAdapter = new PjtControlEPP.ReportesTableAdapters.ReporteAutorizacionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteAutorizacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.reporteAutorizacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PjtControlEPP.Formularios.ReporteAutorizacion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(848, 519);
            this.reportViewer1.TabIndex = 0;
            // 
            // reportes
            // 
            this.reportes.DataSetName = "Reportes";
            this.reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteAutorizacionBindingSource
            // 
            this.reporteAutorizacionBindingSource.DataMember = "ReporteAutorizacion";
            this.reporteAutorizacionBindingSource.DataSource = this.reportes;
            // 
            // reporteAutorizacionTableAdapter
            // 
            this.reporteAutorizacionTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteAutorizacionPoliza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 519);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteAutorizacionPoliza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReporteAutorizacionPoliza";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReporteAutorizacionPoliza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteAutorizacionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reportes reportes;
        private System.Windows.Forms.BindingSource reporteAutorizacionBindingSource;
        private ReportesTableAdapters.ReporteAutorizacionTableAdapter reporteAutorizacionTableAdapter;
    }
}