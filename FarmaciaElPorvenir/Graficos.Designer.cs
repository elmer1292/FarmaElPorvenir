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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.GraficoVentaSemana = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GraficoVendedorSemana = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.GraficoVentaSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraficoVendedorSemana)).BeginInit();
            this.SuspendLayout();
            // 
            // GraficoVentaSemana
            // 
            chartArea1.Name = "ChartArea1";
            this.GraficoVentaSemana.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.GraficoVentaSemana.Legends.Add(legend1);
            this.GraficoVentaSemana.Location = new System.Drawing.Point(29, 27);
            this.GraficoVentaSemana.Name = "GraficoVentaSemana";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.GraficoVentaSemana.Series.Add(series1);
            this.GraficoVentaSemana.Size = new System.Drawing.Size(300, 300);
            this.GraficoVentaSemana.TabIndex = 0;
            this.GraficoVentaSemana.Text = "chart1";
            this.GraficoVentaSemana.Click += new System.EventHandler(this.GraficoVentaSemana_Click);
            // 
            // GraficoVendedorSemana
            // 
            chartArea2.Name = "ChartArea1";
            this.GraficoVendedorSemana.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.GraficoVendedorSemana.Legends.Add(legend2);
            this.GraficoVendedorSemana.Location = new System.Drawing.Point(402, 36);
            this.GraficoVendedorSemana.Name = "GraficoVendedorSemana";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.GraficoVendedorSemana.Series.Add(series2);
            this.GraficoVendedorSemana.Size = new System.Drawing.Size(300, 300);
            this.GraficoVendedorSemana.TabIndex = 1;
            this.GraficoVendedorSemana.Text = "chart1";
            // 
            // Graficos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GraficoVendedorSemana);
            this.Controls.Add(this.GraficoVentaSemana);
            this.Name = "Graficos";
            this.Text = "Graficos";
            ((System.ComponentModel.ISupportInitialize)(this.GraficoVentaSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraficoVendedorSemana)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart GraficoVentaSemana;
        private System.Windows.Forms.DataVisualization.Charting.Chart GraficoVendedorSemana;
    }
}