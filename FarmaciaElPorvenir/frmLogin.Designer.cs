namespace FarmaciaElPorvenir
{
    partial class frmLogin
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
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.txtPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnAcceder = new DevExpress.XtraEditors.SimpleButton();
            this.unitOfWorkBD = new DevExpress.Xpo.UnitOfWork(this.components);
            this.xpUsuario = new DevExpress.Xpo.XPCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWorkBD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(171, 78);
            this.txtUser.Margin = new System.Windows.Forms.Padding(5);
            this.txtUser.Name = "txtUser";
            this.txtUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtUser.Properties.Appearance.Options.UseFont = true;
            this.txtUser.Size = new System.Drawing.Size(167, 30);
            this.txtUser.TabIndex = 0;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(171, 143);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(5);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtPwd.Properties.Appearance.Options.UseFont = true;
            this.txtPwd.Properties.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(167, 30);
            this.txtPwd.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(62, 146);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(101, 23);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Contraseña:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(94, 81);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 23);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Usuario:";
            // 
            // btnAcceder
            // 
            this.btnAcceder.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnAcceder.Appearance.Options.UseFont = true;
            this.btnAcceder.AppearanceHovered.ForeColor = System.Drawing.Color.Lime;
            this.btnAcceder.AppearanceHovered.Options.UseForeColor = true;
            this.btnAcceder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAcceder.Location = new System.Drawing.Point(0, 256);
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.Size = new System.Drawing.Size(410, 59);
            this.btnAcceder.TabIndex = 3;
            this.btnAcceder.Text = "Acceder";
            this.btnAcceder.Click += new System.EventHandler(this.btnAcceder_Click);
            // 
            // xpUsuario
            // 
            this.xpUsuario.ObjectType = typeof(FarmaciaElPorvenir.Database.Usuario);
            this.xpUsuario.Session = this.unitOfWorkBD;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnAcceder;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::FarmaciaElPorvenir.Properties.Resources.fondo_abstracto_textura;
            this.ClientSize = new System.Drawing.Size(410, 315);
            this.Controls.Add(this.btnAcceder);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUser);
            this.Font = new System.Drawing.Font("Tahoma", 14F);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesión";
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWorkBD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.TextEdit txtPwd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnAcceder;
        private DevExpress.Xpo.UnitOfWork unitOfWorkBD;
        public DevExpress.Xpo.XPCollection xpUsuario;
    }
}