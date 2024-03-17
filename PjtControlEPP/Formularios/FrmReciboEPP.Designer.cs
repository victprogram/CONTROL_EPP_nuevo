namespace PjtControlEPP.Formularios
{
    partial class FrmReciboEPP
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
            this.facturaEPPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturaEPPTableAdapter = new PjtControlEPP.ReportesTableAdapters.FacturaEPPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaEPPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.facturaEPPBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PjtControlEPP.Formularios.ReciboDespachoEPP.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(855, 515);
            this.reportViewer1.TabIndex = 0;
            // 
            // reportes
            // 
            this.reportes.DataSetName = "Reportes";
            this.reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // facturaEPPBindingSource
            // 
            this.facturaEPPBindingSource.DataMember = "FacturaEPP";
            this.facturaEPPBindingSource.DataSource = this.reportes;
            // 
            // facturaEPPTableAdapter
            // 
            this.facturaEPPTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReciboEPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 515);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReciboEPP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReciboEPP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReciboEPP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaEPPBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reportes reportes;
        private System.Windows.Forms.BindingSource facturaEPPBindingSource;
        private ReportesTableAdapters.FacturaEPPTableAdapter facturaEPPTableAdapter;


    }
}