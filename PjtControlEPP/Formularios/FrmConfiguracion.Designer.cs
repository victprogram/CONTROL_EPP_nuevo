namespace PjtControlEPP.Formularios
{
    partial class FrmConfiguracion
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRNC = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtUrlJsonConsulta = new System.Windows.Forms.TextBox();
            this.txtUrlJsonConsultaEmpleado = new System.Windows.Forms.TextBox();
            this.txtCorreoAprobacion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUrlJsonSalida = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cbImpresora = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 113;
            this.label1.Text = "NOMBRE NEGOCIO";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtNombre.Location = new System.Drawing.Point(196, 44);
            this.txtNombre.MaxLength = 35;
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(360, 25);
            this.txtNombre.TabIndex = 112;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtDireccion.Location = new System.Drawing.Point(196, 74);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(360, 26);
            this.txtDireccion.TabIndex = 114;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 115;
            this.label2.Text = "DIRECCION";
            // 
            // txtRNC
            // 
            this.txtRNC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRNC.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRNC.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtRNC.Location = new System.Drawing.Point(449, 106);
            this.txtRNC.Name = "txtRNC";
            this.txtRNC.Size = new System.Drawing.Size(107, 27);
            this.txtRNC.TabIndex = 116;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(413, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 117;
            this.label4.Text = "RNC";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtTelefono.Location = new System.Drawing.Point(196, 106);
            this.txtTelefono.Mask = "(999)000-0000";
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(134, 27);
            this.txtTelefono.TabIndex = 118;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(123, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 119;
            this.label10.Text = "TELEFONO ";
            // 
            // txtCorreo
            // 
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCorreo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtCorreo.Location = new System.Drawing.Point(196, 138);
            this.txtCorreo.MaxLength = 35;
            this.txtCorreo.Multiline = true;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(360, 25);
            this.txtCorreo.TabIndex = 120;
            // 
            // txtUrlJsonConsulta
            // 
            this.txtUrlJsonConsulta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrlJsonConsulta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUrlJsonConsulta.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrlJsonConsulta.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtUrlJsonConsulta.Location = new System.Drawing.Point(196, 200);
            this.txtUrlJsonConsulta.MaxLength = 35;
            this.txtUrlJsonConsulta.Multiline = true;
            this.txtUrlJsonConsulta.Name = "txtUrlJsonConsulta";
            this.txtUrlJsonConsulta.Size = new System.Drawing.Size(596, 25);
            this.txtUrlJsonConsulta.TabIndex = 121;
            // 
            // txtUrlJsonConsultaEmpleado
            // 
            this.txtUrlJsonConsultaEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrlJsonConsultaEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUrlJsonConsultaEmpleado.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrlJsonConsultaEmpleado.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtUrlJsonConsultaEmpleado.Location = new System.Drawing.Point(196, 231);
            this.txtUrlJsonConsultaEmpleado.MaxLength = 35;
            this.txtUrlJsonConsultaEmpleado.Multiline = true;
            this.txtUrlJsonConsultaEmpleado.Name = "txtUrlJsonConsultaEmpleado";
            this.txtUrlJsonConsultaEmpleado.Size = new System.Drawing.Size(596, 25);
            this.txtUrlJsonConsultaEmpleado.TabIndex = 122;
            // 
            // txtCorreoAprobacion
            // 
            this.txtCorreoAprobacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreoAprobacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCorreoAprobacion.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoAprobacion.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtCorreoAprobacion.Location = new System.Drawing.Point(196, 169);
            this.txtCorreoAprobacion.MaxLength = 35;
            this.txtCorreoAprobacion.Multiline = true;
            this.txtCorreoAprobacion.Name = "txtCorreoAprobacion";
            this.txtCorreoAprobacion.Size = new System.Drawing.Size(360, 25);
            this.txtCorreoAprobacion.TabIndex = 123;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(140, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 124;
            this.label11.Text = "CORREO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(67, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 13);
            this.label12.TabIndex = 125;
            this.label12.Text = "CORREO APROBACION";
            // 
            // txtUrlJsonSalida
            // 
            this.txtUrlJsonSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrlJsonSalida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUrlJsonSalida.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrlJsonSalida.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtUrlJsonSalida.Location = new System.Drawing.Point(196, 262);
            this.txtUrlJsonSalida.MaxLength = 35;
            this.txtUrlJsonSalida.Multiline = true;
            this.txtUrlJsonSalida.Name = "txtUrlJsonSalida";
            this.txtUrlJsonSalida.Size = new System.Drawing.Size(596, 25);
            this.txtUrlJsonSalida.TabIndex = 126;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(43, 206);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 13);
            this.label13.TabIndex = 127;
            this.label13.Text = "URL JSON CONSULTA ITEM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 13);
            this.label6.TabIndex = 128;
            this.label6.Text = "URL JSON CONSULTA EMPLEADOS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(84, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 129;
            this.label9.Text = "URL JSON SALIDA";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnGuardar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnGuardar.Location = new System.Drawing.Point(189, 321);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(181, 37);
            this.btnGuardar.TabIndex = 191;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Verdana", 10F);
            this.button3.ForeColor = System.Drawing.Color.SteelBlue;
            this.button3.Location = new System.Drawing.Point(376, 321);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 37);
            this.button3.TabIndex = 192;
            this.button3.Text = "Cerrar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // cbImpresora
            // 
            this.cbImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImpresora.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbImpresora.FormattingEnabled = true;
            this.cbImpresora.Location = new System.Drawing.Point(196, 294);
            this.cbImpresora.Name = "cbImpresora";
            this.cbImpresora.Size = new System.Drawing.Size(360, 21);
            this.cbImpresora.TabIndex = 5;
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
            this.txtTitle.Size = new System.Drawing.Size(1080, 20);
            this.txtTitle.TabIndex = 196;
            this.txtTitle.Text = "Formulario de configuración";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.cbImpresora);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtRNC);
            this.groupBox1.Controls.Add(this.txtUrlJsonSalida);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCorreo);
            this.groupBox1.Controls.Add(this.txtCorreoAprobacion);
            this.groupBox1.Controls.Add(this.txtUrlJsonConsulta);
            this.groupBox1.Controls.Add(this.txtUrlJsonConsultaEmpleado);
            this.groupBox1.Location = new System.Drawing.Point(140, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 412);
            this.groupBox1.TabIndex = 197;
            this.groupBox1.TabStop = false;
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1080, 670);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConfiguracion";
            this.Load += new System.EventHandler(this.FrmConfiguracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUrlJsonSalida;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCorreoAprobacion;
        private System.Windows.Forms.TextBox txtUrlJsonConsultaEmpleado;
        private System.Windows.Forms.TextBox txtUrlJsonConsulta;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.MaskedTextBox txtTelefono;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtRNC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cbImpresora;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}