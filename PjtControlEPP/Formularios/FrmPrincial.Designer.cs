namespace PjtControlEPP.Formularios
{
    partial class FrmPrincial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincial));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.respachoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.facturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autorizacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autorizacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porFechaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.porEmpleadoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.porAreaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.despachoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porFechaPlanoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eJEMPLOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SistemaTool = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarSalidaEPPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblNombre = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblApellido = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCargo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.conetado = new System.Windows.Forms.ToolStripStatusLabel();
            this.desconetado = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivosToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.configuraciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1015, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.respachoToolStripMenuItem,
            this.registrosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("archivosToolStripMenuItem.Image")));
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(98, 25);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // respachoToolStripMenuItem
            // 
            this.respachoToolStripMenuItem.Name = "respachoToolStripMenuItem";
            this.respachoToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.respachoToolStripMenuItem.Text = "Despacho EPP";
            this.respachoToolStripMenuItem.Click += new System.EventHandler(this.respachoToolStripMenuItem_Click);
            // 
            // registrosToolStripMenuItem
            // 
            this.registrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.pOToolStripMenuItem});
            this.registrosToolStripMenuItem.Name = "registrosToolStripMenuItem";
            this.registrosToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.registrosToolStripMenuItem.Text = "Registros";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // pOToolStripMenuItem
            // 
            this.pOToolStripMenuItem.Name = "pOToolStripMenuItem";
            this.pOToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.pOToolStripMenuItem.Text = "PO";
            this.pOToolStripMenuItem.Click += new System.EventHandler(this.pOToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioToolStripMenuItem1,
            this.empleadosToolStripMenuItem1,
            this.facturasToolStripMenuItem,
            this.autorizacionesToolStripMenuItem});
            this.consultasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultasToolStripMenuItem.Image")));
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(106, 25);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // inventarioToolStripMenuItem1
            // 
            this.inventarioToolStripMenuItem1.Name = "inventarioToolStripMenuItem1";
            this.inventarioToolStripMenuItem1.Size = new System.Drawing.Size(182, 26);
            this.inventarioToolStripMenuItem1.Text = "Inventario";
            this.inventarioToolStripMenuItem1.Click += new System.EventHandler(this.inventarioToolStripMenuItem1_Click);
            // 
            // empleadosToolStripMenuItem1
            // 
            this.empleadosToolStripMenuItem1.Name = "empleadosToolStripMenuItem1";
            this.empleadosToolStripMenuItem1.Size = new System.Drawing.Size(182, 26);
            this.empleadosToolStripMenuItem1.Text = "Empleados";
            this.empleadosToolStripMenuItem1.Click += new System.EventHandler(this.empleadosToolStripMenuItem1_Click);
            // 
            // facturasToolStripMenuItem
            // 
            this.facturasToolStripMenuItem.Name = "facturasToolStripMenuItem";
            this.facturasToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.facturasToolStripMenuItem.Text = "Despacho EPP";
            this.facturasToolStripMenuItem.Click += new System.EventHandler(this.facturasToolStripMenuItem_Click);
            // 
            // autorizacionesToolStripMenuItem
            // 
            this.autorizacionesToolStripMenuItem.Name = "autorizacionesToolStripMenuItem";
            this.autorizacionesToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.autorizacionesToolStripMenuItem.Text = "Autorizaciones";
            this.autorizacionesToolStripMenuItem.Click += new System.EventHandler(this.autorizacionesToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autorizacionToolStripMenuItem,
            this.despachoToolStripMenuItem,
            this.eJEMPLOToolStripMenuItem});
            this.reportesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportesToolStripMenuItem.Image")));
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(100, 25);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // autorizacionToolStripMenuItem
            // 
            this.autorizacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porFechaToolStripMenuItem1,
            this.porEmpleadoToolStripMenuItem1,
            this.porAreaToolStripMenuItem1});
            this.autorizacionToolStripMenuItem.Name = "autorizacionToolStripMenuItem";
            this.autorizacionToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.autorizacionToolStripMenuItem.Text = "Autorización";
            // 
            // porFechaToolStripMenuItem1
            // 
            this.porFechaToolStripMenuItem1.Name = "porFechaToolStripMenuItem1";
            this.porFechaToolStripMenuItem1.Size = new System.Drawing.Size(176, 26);
            this.porFechaToolStripMenuItem1.Text = "Por Fecha";
            this.porFechaToolStripMenuItem1.Click += new System.EventHandler(this.porFechaToolStripMenuItem1_Click);
            // 
            // porEmpleadoToolStripMenuItem1
            // 
            this.porEmpleadoToolStripMenuItem1.Name = "porEmpleadoToolStripMenuItem1";
            this.porEmpleadoToolStripMenuItem1.Size = new System.Drawing.Size(176, 26);
            this.porEmpleadoToolStripMenuItem1.Text = "Por Empleado";
            this.porEmpleadoToolStripMenuItem1.Click += new System.EventHandler(this.porEmpleadoToolStripMenuItem1_Click);
            // 
            // porAreaToolStripMenuItem1
            // 
            this.porAreaToolStripMenuItem1.Name = "porAreaToolStripMenuItem1";
            this.porAreaToolStripMenuItem1.Size = new System.Drawing.Size(176, 26);
            this.porAreaToolStripMenuItem1.Text = "Por Area";
            this.porAreaToolStripMenuItem1.Click += new System.EventHandler(this.porAreaToolStripMenuItem1_Click);
            // 
            // despachoToolStripMenuItem
            // 
            this.despachoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porEmpleadoToolStripMenuItem,
            this.porAreaToolStripMenuItem,
            this.porFechaToolStripMenuItem,
            this.porFechaPlanoToolStripMenuItem});
            this.despachoToolStripMenuItem.Name = "despachoToolStripMenuItem";
            this.despachoToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.despachoToolStripMenuItem.Text = "Despacho";
            // 
            // porEmpleadoToolStripMenuItem
            // 
            this.porEmpleadoToolStripMenuItem.Name = "porEmpleadoToolStripMenuItem";
            this.porEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.porEmpleadoToolStripMenuItem.Text = "Por Empleado";
            this.porEmpleadoToolStripMenuItem.Click += new System.EventHandler(this.porEmpleadoToolStripMenuItem_Click);
            // 
            // porAreaToolStripMenuItem
            // 
            this.porAreaToolStripMenuItem.Name = "porAreaToolStripMenuItem";
            this.porAreaToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.porAreaToolStripMenuItem.Text = "Por Area";
            this.porAreaToolStripMenuItem.Click += new System.EventHandler(this.porAreaToolStripMenuItem_Click);
            // 
            // porFechaToolStripMenuItem
            // 
            this.porFechaToolStripMenuItem.Name = "porFechaToolStripMenuItem";
            this.porFechaToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.porFechaToolStripMenuItem.Text = "Por Fecha";
            this.porFechaToolStripMenuItem.Click += new System.EventHandler(this.porFechaToolStripMenuItem_Click);
            // 
            // porFechaPlanoToolStripMenuItem
            // 
            this.porFechaPlanoToolStripMenuItem.Name = "porFechaPlanoToolStripMenuItem";
            this.porFechaPlanoToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.porFechaPlanoToolStripMenuItem.Text = "Por Fecha Plano";
            this.porFechaPlanoToolStripMenuItem.Click += new System.EventHandler(this.porFechaPlanoToolStripMenuItem_Click);
            // 
            // eJEMPLOToolStripMenuItem
            // 
            this.eJEMPLOToolStripMenuItem.Enabled = false;
            this.eJEMPLOToolStripMenuItem.Name = "eJEMPLOToolStripMenuItem";
            this.eJEMPLOToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.eJEMPLOToolStripMenuItem.Text = "EJEMPLO";
            this.eJEMPLOToolStripMenuItem.Click += new System.EventHandler(this.eJEMPLOToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SistemaTool,
            this.modificarSalidaEPPToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configuraciónToolStripMenuItem.Image")));
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(136, 25);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // SistemaTool
            // 
            this.SistemaTool.Name = "SistemaTool";
            this.SistemaTool.Size = new System.Drawing.Size(222, 26);
            this.SistemaTool.Text = "Sistema";
            this.SistemaTool.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // modificarSalidaEPPToolStripMenuItem
            // 
            this.modificarSalidaEPPToolStripMenuItem.Name = "modificarSalidaEPPToolStripMenuItem";
            this.modificarSalidaEPPToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.modificarSalidaEPPToolStripMenuItem.Text = "Modificar Salida EPP";
            this.modificarSalidaEPPToolStripMenuItem.Click += new System.EventHandler(this.modificarSalidaEPPToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNombre,
            this.lblApellido,
            this.lblCargo,
            this.toolStripStatusLabel1,
            this.conetado,
            this.desconetado,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip.Location = new System.Drawing.Point(0, 558);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1015, 22);
            this.statusStrip.TabIndex = 155;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(60, 17);
            this.lblNombre.Text = "NOMBRE";
            // 
            // lblApellido
            // 
            this.lblApellido.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(69, 17);
            this.lblApellido.Text = "APELLIDO";
            // 
            // lblCargo
            // 
            this.lblCargo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(51, 17);
            this.lblCargo.Text = "CARGO";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(147, 17);
            this.toolStripStatusLabel1.Text = "[ ESTADO SERVIDOR";
            // 
            // conetado
            // 
            this.conetado.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conetado.ForeColor = System.Drawing.Color.Green;
            this.conetado.Name = "conetado";
            this.conetado.Size = new System.Drawing.Size(93, 17);
            this.conetado.Text = "CONETADO ]";
            // 
            // desconetado
            // 
            this.desconetado.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desconetado.ForeColor = System.Drawing.Color.Red;
            this.desconetado.Name = "desconetado";
            this.desconetado.Size = new System.Drawing.Size(120, 17);
            this.desconetado.Text = "DESCONETADO ]";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel2.Text = "CONTACTO:";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.IsLink = true;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(272, 17);
            this.toolStripStatusLabel3.Text = "https://www.instagram.com/victorprogramacion/";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(444, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 156;
            this.label1.Text = "Copyright VictProgram©2020";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 900000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(630, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 23);
            this.label2.TabIndex = 158;
            this.label2.Text = "DESPACHO ALMACEN HELLPAD";
            // 
            // FrmPrincial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PjtControlEPP.Properties.Resources.VictProgramPNG_Navarro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1015, 580);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrincial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincial_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem respachoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SistemaTool;
        private System.Windows.Forms.ToolStripMenuItem facturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autorizacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despachoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porFechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porFechaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem porEmpleadoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem porAreaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porFechaPlanoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblNombre;
        private System.Windows.Forms.ToolStripStatusLabel lblApellido;
        private System.Windows.Forms.ToolStripStatusLabel lblCargo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel conetado;
        private System.Windows.Forms.ToolStripStatusLabel desconetado;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem autorizacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem modificarSalidaEPPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eJEMPLOToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}