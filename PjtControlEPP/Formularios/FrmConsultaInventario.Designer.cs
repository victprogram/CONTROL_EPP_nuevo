namespace PjtControlEPP.Formularios
{
    partial class FrmConsultaInventario
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dtgProductos = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductos.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgProductos
            // 
            this.dtgProductos.Location = new System.Drawing.Point(14, 0);
            // 
            // 
            // 
            gridViewTextBoxColumn1.HeaderText = "Grupo";
            gridViewTextBoxColumn1.Name = "grupo";
            gridViewTextBoxColumn1.Width = 80;
            gridViewTextBoxColumn2.HeaderText = "Codigo";
            gridViewTextBoxColumn2.Name = "idproducto";
            gridViewTextBoxColumn2.Width = 80;
            gridViewTextBoxColumn3.HeaderText = "Codigo Barras";
            gridViewTextBoxColumn3.Name = "barras";
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn4.HeaderText = "Nombre EPP";
            gridViewTextBoxColumn4.Name = "nombreproducto";
            gridViewTextBoxColumn4.Width = 400;
            gridViewTextBoxColumn5.HeaderText = "Exixtencia";
            gridViewTextBoxColumn5.Name = "cantidad";
            gridViewTextBoxColumn5.Width = 100;
            gridViewTextBoxColumn6.HeaderText = "Costo";
            gridViewTextBoxColumn6.Name = "Precio";
            gridViewTextBoxColumn6.Width = 80;
            gridViewTextBoxColumn7.HeaderText = "Tiempo de vida en dia";
            gridViewTextBoxColumn7.Name = "tiempovida";
            gridViewTextBoxColumn7.Width = 120;
            this.dtgProductos.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.dtgProductos.MasterTemplate.EnableFiltering = true;
            this.dtgProductos.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dtgProductos.Name = "dtgProductos";
            this.dtgProductos.ReadOnly = true;
            this.dtgProductos.Size = new System.Drawing.Size(980, 634);
            this.dtgProductos.TabIndex = 0;
            this.dtgProductos.DoubleClick += new System.EventHandler(this.radGridView1_DoubleClick);
            // 
            // FrmConsultaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1008, 636);
            this.Controls.Add(this.dtgProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmConsultaInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmConsultaInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductos.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dtgProductos;


    }
}