namespace FarmaciaElPorvenir
{
    partial class loggin
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
            this.accder = new System.Windows.Forms.Button();
            this.txtUsser = new System.Windows.Forms.Button();
            this.txtPassw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accder
            // 
            this.accder.Location = new System.Drawing.Point(366, 241);
            this.accder.Name = "accder";
            this.accder.Size = new System.Drawing.Size(75, 23);
            this.accder.TabIndex = 4;
            this.accder.Text = "acceder";
            this.accder.UseVisualStyleBackColor = true;
            this.accder.Click += new System.EventHandler(this.accder_Click);
            // 
            // txtUsser
            // 
            this.txtUsser.Location = new System.Drawing.Point(366, 108);
            this.txtUsser.Name = "txtUsser";
            this.txtUsser.Size = new System.Drawing.Size(75, 23);
            this.txtUsser.TabIndex = 5;
            this.txtUsser.UseVisualStyleBackColor = true;
            // 
            // txtPassw
            // 
            this.txtPassw.Location = new System.Drawing.Point(366, 150);
            this.txtPassw.Name = "txtPassw";
            this.txtPassw.Size = new System.Drawing.Size(75, 23);
            this.txtPassw.TabIndex = 6;
            this.txtPassw.UseVisualStyleBackColor = true;
            // 
            // loggin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(644, 450);
            this.Controls.Add(this.txtPassw);
            this.Controls.Add(this.txtUsser);
            this.Controls.Add(this.accder);
            this.Location = new System.Drawing.Point(1, 1);
            this.Name = "loggin";
            this.Text = "loggin";
            this.Load += new System.EventHandler(this.loggin_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button accder;
        private System.Windows.Forms.Button txtUsser;
        private System.Windows.Forms.Button txtPassw;
    }
}