namespace FarmaciaElPorvenir
{
    partial class Graficos
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
            this.chartControlVendedores = new DevExpress.XtraCharts.ChartControl();
            this.chartControlProductos = new DevExpress.XtraCharts.ChartControl();
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartControlVendedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControlVendedores
            // 
            this.chartControlVendedores.Location = new System.Drawing.Point(146, 12);
            this.chartControlVendedores.Name = "chartControlVendedores";
            this.chartControlVendedores.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControlVendedores.Size = new System.Drawing.Size(351, 320);
            this.chartControlVendedores.TabIndex = 0;
            // 
            // chartControlProductos
            // 
            this.chartControlProductos.Location = new System.Drawing.Point(357, 335);
            this.chartControlProductos.Name = "chartControlProductos";
            this.chartControlProductos.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControlProductos.Size = new System.Drawing.Size(300, 200);
            this.chartControlProductos.TabIndex = 1;
            // 
            // Graficos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 558);
            this.Controls.Add(this.chartControlProductos);
            this.Controls.Add(this.chartControlVendedores);
            this.Name = "Graficos";
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Graficos_FormClosing);
            this.Load += new System.EventHandler(this.Graficos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartControlVendedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControlVendedores;
        private DevExpress.XtraCharts.ChartControl chartControlProductos;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
    }
}