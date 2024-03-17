namespace PjtControlEPP
{
    partial class FrmModificarAcceso
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
            this.txtIdusuario = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtRepetirClave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClaveNueva = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaveAnterior = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIdusuario
            // 
            this.txtIdusuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdusuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdusuario.Font = new System.Drawing.Font("Verdana", 12F);
            this.txtIdusuario.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtIdusuario.Location = new System.Drawing.Point(198, 31);
            this.txtIdusuario.Name = "txtIdusuario";
            this.txtIdusuario.Size = new System.Drawing.Size(229, 27);
            this.txtIdusuario.TabIndex = 178;
            this.txtIdusuario.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 10F);
            this.button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.button1.Location = new System.Drawing.Point(215, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 37);
            this.button1.TabIndex = 176;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 10F);
            this.btnCancelar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCancelar.Location = new System.Drawing.Point(306, 175);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 37);
            this.btnCancelar.TabIndex = 177;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtRepetirClave
            // 
            this.txtRepetirClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRepetirClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRepetirClave.Font = new System.Drawing.Font("Verdana", 12F);
            this.txtRepetirClave.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtRepetirClave.Location = new System.Drawing.Point(198, 130);
            this.txtRepetirClave.Name = "txtRepetirClave";
            this.txtRepetirClave.PasswordChar = '*';
            this.txtRepetirClave.Size = new System.Drawing.Size(229, 27);
            this.txtRepetirClave.TabIndex = 175;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(47, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 174;
            this.label3.Text = "Repetir contraseña";
            // 
            // txtClaveNueva
            // 
            this.txtClaveNueva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClaveNueva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveNueva.Font = new System.Drawing.Font("Verdana", 12F);
            this.txtClaveNueva.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtClaveNueva.Location = new System.Drawing.Point(198, 97);
            this.txtClaveNueva.Name = "txtClaveNueva";
            this.txtClaveNueva.PasswordChar = '*';
            this.txtClaveNueva.Size = new System.Drawing.Size(229, 27);
            this.txtClaveNueva.TabIndex = 173;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(52, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 17);
            this.label2.TabIndex = 172;
            this.label2.Text = "Contraseña nueva";
            // 
            // txtClaveAnterior
            // 
            this.txtClaveAnterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClaveAnterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClaveAnterior.Font = new System.Drawing.Font("Verdana", 12F);
            this.txtClaveAnterior.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtClaveAnterior.Location = new System.Drawing.Point(198, 64);
            this.txtClaveAnterior.Name = "txtClaveAnterior";
            this.txtClaveAnterior.Size = new System.Drawing.Size(229, 27);
            this.txtClaveAnterior.TabIndex = 171;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(39, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 170;
            this.label1.Text = "Contraseña anterior";
            // 
            // FrmModificarAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(575, 258);
            this.Controls.Add(this.txtIdusuario);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtRepetirClave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtClaveNueva);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClaveAnterior);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmModificarAcceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmModificarAcceso";
            this.Load += new System.EventHandler(this.FrmModificarAcceso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdusuario;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtRepetirClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClaveNueva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaveAnterior;
        private System.Windows.Forms.Label label1;
    }
}