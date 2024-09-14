namespace FarmaciaElPorvenir
{
    partial class frmFacturaVenta
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.xpCollectionProducto = new DevExpress.Xpo.XPCollection(this.components);
            this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.xpCollectionDetalleVenta = new DevExpress.Xpo.XPCollection(this.components);
            this.gridViewDetalleVenta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionDetalleVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(164, 450);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lookUpEdit1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(164, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(636, 64);
            this.panelControl2.TabIndex = 1;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.EditValue = "Null";
            this.lookUpEdit1.Location = new System.Drawing.Point(25, 23);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 19, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Medicamento", "Medicamento", 72, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Categoria!", "Id_Categoria", 72, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Categoria!Key", "Id_Categoria", 72, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Precio_Compra", "Precio_Compra", 81, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Precio_Venta", "Precio_Venta", 72, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descuento", "Descuento", 60, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Stock", "Stock", 35, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Vencimiento", "Vencimiento", 66, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Proveedor!", "Id_Proveedor", 75, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id_Proveedor!Key", "Id_Proveedor", 75, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEdit1.Properties.DataSource = this.xpCollectionProducto;
            this.lookUpEdit1.Properties.DisplayMember = "Medicamento";
            this.lookUpEdit1.Properties.NullText = "Seleccione un Producto";
            this.lookUpEdit1.Properties.ValueMember = "Id";
            this.lookUpEdit1.Size = new System.Drawing.Size(427, 20);
            this.lookUpEdit1.TabIndex = 0;
            // 
            // xpCollectionProducto
            // 
            this.xpCollectionProducto.ObjectType = typeof(FarmaciaElPorvenir.Database.Producto);
            this.xpCollectionProducto.Session = this.unitOfWork1;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.xpCollectionDetalleVenta;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(164, 64);
            this.gridControl1.MainView = this.gridViewDetalleVenta;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(636, 386);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetalleVenta});
            // 
            // xpCollectionDetalleVenta
            // 
            this.xpCollectionDetalleVenta.ObjectType = typeof(FarmaciaElPorvenir.Database.Detalleventa);
            this.xpCollectionDetalleVenta.Session = this.unitOfWork1;
            // 
            // gridViewDetalleVenta
            // 
            this.gridViewDetalleVenta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.colCantidad,
            this.colPrecio,
            this.colDescuento,
            this.colIVA,
            this.colTotal});
            this.gridViewDetalleVenta.GridControl = this.gridControl1;
            this.gridViewDetalleVenta.Name = "gridViewDetalleVenta";
            this.gridViewDetalleVenta.OptionsCustomization.AllowFilter = false;
            this.gridViewDetalleVenta.OptionsDragDrop.AllowDataReordering = false;
            this.gridViewDetalleVenta.OptionsDragDrop.AllowSortedDataDragDrop = false;
            this.gridViewDetalleVenta.OptionsFilter.InHeaderSearchMode = DevExpress.XtraGrid.Views.Grid.GridInHeaderSearchMode.Disabled;
            this.gridViewDetalleVenta.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewDetalleVenta.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Id_FacturaVenta!";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Id_FacturaVenta!Key";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.FieldName = "Id_Producto.Medicamento";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.FieldName = "Id_Producto!Key";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // colCantidad
            // 
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 1;
            // 
            // colPrecio
            // 
            this.colPrecio.FieldName = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.Visible = true;
            this.colPrecio.VisibleIndex = 2;
            // 
            // colDescuento
            // 
            this.colDescuento.FieldName = "Descuento";
            this.colDescuento.Name = "colDescuento";
            this.colDescuento.Visible = true;
            this.colDescuento.VisibleIndex = 3;
            // 
            // colIVA
            // 
            this.colIVA.FieldName = "IVA";
            this.colIVA.Name = "colIVA";
            this.colIVA.Visible = true;
            this.colIVA.VisibleIndex = 4;
            // 
            // colTotal
            // 
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 5;
            // 
            // frmFacturaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmFacturaVenta";
            this.Text = "Venta";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionDetalleVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetalleVenta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDetalleVenta;
        private DevExpress.Xpo.XPCollection xpCollectionDetalleVenta;
        private DevExpress.Xpo.UnitOfWork unitOfWork1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn colDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn colIVA;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.Xpo.XPCollection xpCollectionProducto;
    }
}