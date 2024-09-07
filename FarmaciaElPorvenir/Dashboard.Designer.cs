namespace FarmaciaElPorvenir
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAgregarCategoria = new DevExpress.XtraBars.BarButtonItem();
            this.btnListar = new DevExpress.XtraBars.BarButtonItem();
            this.btnAgregarEmpleado = new DevExpress.XtraBars.BarButtonItem();
            this.btnListarEmpleado = new DevExpress.XtraBars.BarButtonItem();
            this.btnRol = new DevExpress.XtraBars.BarButtonItem();
            this.btnListarRoles = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonCategoria = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemListarCategorias = new DevExpress.XtraBars.BarButtonItem();
            this.btnAgregarProveedor = new DevExpress.XtraBars.BarButtonItem();
            this.btnListarProveedor = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInventario = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupCliente = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageEmpleado = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupEmpleados = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageRol = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageCategoria = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageProveedor = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageInventario = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemListarClientes = new DevExpress.XtraBars.BarButtonItem();
            this.btnAgregarRol = new DevExpress.XtraBars.BarButtonItem();
            this.btnListarRol = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 647);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1033, 24);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnAgregarCategoria,
            this.btnListar,
            this.btnAgregarEmpleado,
            this.btnListarEmpleado,
            this.btnRol,
            this.btnListarRoles,
            this.barButtonCategoria,
            this.barButtonItemListarCategorias,
            this.btnAgregarProveedor,
            this.btnListarProveedor,
            this.barButtonItemInventario});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 19;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageHome,
            this.ribbonPageGroupCliente,
            this.ribbonPageEmpleado,
            this.ribbonPageRol,
            this.ribbonPageCategoria,
            this.ribbonPageProveedor,
            this.ribbonPageInventario,
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1033, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Caption = "Agregar";
            this.btnAgregarCategoria.Id = 1;
            this.btnAgregarCategoria.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarCategoria.ImageOptions.LargeImage")));
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregarCategoria_ItemClick);
            // 
            // btnListar
            // 
            this.btnListar.Caption = "Listar Clientes";
            this.btnListar.Id = 3;
            this.btnListar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnListar.ImageOptions.LargeImage")));
            this.btnListar.Name = "btnListar";
            this.btnListar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.Caption = "Agregar Empleado";
            this.btnAgregarEmpleado.Id = 4;
            this.btnAgregarEmpleado.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarEmpleado.ImageOptions.LargeImage")));
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregarEmpleado_ItemClick);
            // 
            // btnListarEmpleado
            // 
            this.btnListarEmpleado.Caption = "Listar Empleados";
            this.btnListarEmpleado.Id = 5;
            this.btnListarEmpleado.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnListarEmpleado.ImageOptions.LargeImage")));
            this.btnListarEmpleado.Name = "btnListarEmpleado";
            // 
            // btnRol
            // 
            this.btnRol.Caption = "Agregar Rol";
            this.btnRol.Id = 12;
            this.btnRol.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRol.ImageOptions.LargeImage")));
            this.btnRol.Name = "btnRol";
            this.btnRol.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRol_ItemClick);
            // 
            // btnListarRoles
            // 
            this.btnListarRoles.Caption = "Listar Roles";
            this.btnListarRoles.Id = 13;
            this.btnListarRoles.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnListarRoles.ImageOptions.LargeImage")));
            this.btnListarRoles.Name = "btnListarRoles";
            // 
            // barButtonCategoria
            // 
            this.barButtonCategoria.Caption = "Agregar Categoria";
            this.barButtonCategoria.Id = 14;
            this.barButtonCategoria.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonCategoria.ImageOptions.LargeImage")));
            this.barButtonCategoria.Name = "barButtonCategoria";
            this.barButtonCategoria.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonCategoria_ItemClick);
            // 
            // barButtonItemListarCategorias
            // 
            this.barButtonItemListarCategorias.Caption = "Listar Categorias";
            this.barButtonItemListarCategorias.Id = 15;
            this.barButtonItemListarCategorias.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemListarCategorias.ImageOptions.LargeImage")));
            this.barButtonItemListarCategorias.Name = "barButtonItemListarCategorias";
            // 
            // btnAgregarProveedor
            // 
            this.btnAgregarProveedor.Caption = "Agregar Proveedor";
            this.btnAgregarProveedor.Id = 16;
            this.btnAgregarProveedor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarProveedor.ImageOptions.LargeImage")));
            this.btnAgregarProveedor.Name = "btnAgregarProveedor";
            this.btnAgregarProveedor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAgregarProveedor_ItemClick);
            // 
            // btnListarProveedor
            // 
            this.btnListarProveedor.Caption = "Listar Proveedor";
            this.btnListarProveedor.Id = 17;
            this.btnListarProveedor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnListarProveedor.ImageOptions.LargeImage")));
            this.btnListarProveedor.Name = "btnListarProveedor";
            // 
            // barButtonItemInventario
            // 
            this.barButtonItemInventario.Caption = "Inventario";
            this.barButtonItemInventario.Id = 18;
            this.barButtonItemInventario.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemInventario.ImageOptions.LargeImage")));
            this.barButtonItemInventario.Name = "barButtonItemInventario";
            this.barButtonItemInventario.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemInventario_ItemClick);
            // 
            // ribbonPageHome
            // 
            this.ribbonPageHome.Name = "ribbonPageHome";
            this.ribbonPageHome.Text = "Home";
            // 
            // ribbonPageGroupCliente
            // 
            this.ribbonPageGroupCliente.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPageGroupCliente.Name = "ribbonPageGroupCliente";
            this.ribbonPageGroupCliente.Text = "Cliente";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAgregarCategoria);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnListar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageEmpleado
            // 
            this.ribbonPageEmpleado.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupEmpleados});
            this.ribbonPageEmpleado.Name = "ribbonPageEmpleado";
            this.ribbonPageEmpleado.Text = "Empleado";
            // 
            // ribbonPageGroupEmpleados
            // 
            this.ribbonPageGroupEmpleados.ItemLinks.Add(this.btnAgregarEmpleado);
            this.ribbonPageGroupEmpleados.ItemLinks.Add(this.btnListarEmpleado);
            this.ribbonPageGroupEmpleados.Name = "ribbonPageGroupEmpleados";
            // 
            // ribbonPageRol
            // 
            this.ribbonPageRol.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPageRol.Name = "ribbonPageRol";
            this.ribbonPageRol.Text = "Rol";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRol);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnListarRoles);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageCategoria
            // 
            this.ribbonPageCategoria.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPageCategoria.Name = "ribbonPageCategoria";
            this.ribbonPageCategoria.Text = "Categoria";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonCategoria);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItemListarCategorias);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageProveedor
            // 
            this.ribbonPageProveedor.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.ribbonPageProveedor.Name = "ribbonPageProveedor";
            this.ribbonPageProveedor.Text = "Proveedor";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnAgregarProveedor);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnListarProveedor);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonPageInventario
            // 
            this.ribbonPageInventario.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup8});
            this.ribbonPageInventario.Name = "ribbonPageInventario";
            this.ribbonPageInventario.Text = "Inventario";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItemInventario);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            // 
            // barButtonItemListarClientes
            // 
            this.barButtonItemListarClientes.Caption = "Listar";
            this.barButtonItemListarClientes.Id = 2;
            this.barButtonItemListarClientes.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemListarClientes.ImageOptions.LargeImage")));
            this.barButtonItemListarClientes.Name = "barButtonItemListarClientes";
            this.barButtonItemListarClientes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnAgregarRol
            // 
            this.btnAgregarRol.Caption = "Agregar Rol";
            this.btnAgregarRol.Id = 6;
            this.btnAgregarRol.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarRol.ImageOptions.LargeImage")));
            this.btnAgregarRol.Name = "btnAgregarRol";
            // 
            // btnListarRol
            // 
            this.btnListarRol.Caption = "Listar Roles";
            this.btnListarRol.Id = 7;
            this.btnListarRol.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnListarRol.ImageOptions.LargeImage")));
            this.btnListarRol.Name = "btnListarRol";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItemListarClientes);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbon;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "ribbonPageGroup7";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup9});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.Text = "ribbonPageGroup9";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 671);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "Dashboard";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemListarClientes;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnAgregarRol;
        private DevExpress.XtraBars.BarButtonItem btnListarRol;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnAgregarCategoria;
        private DevExpress.XtraBars.BarButtonItem btnListar;
        private DevExpress.XtraBars.BarButtonItem btnAgregarEmpleado;
        private DevExpress.XtraBars.BarButtonItem btnListarEmpleado;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageHome;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageGroupCliente;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageEmpleado;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupEmpleados;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageRol;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnRol;
        private DevExpress.XtraBars.BarButtonItem btnListarRoles;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem barButtonCategoria;
        private DevExpress.XtraBars.BarButtonItem barButtonItemListarCategorias;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageCategoria;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageProveedor;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnAgregarProveedor;
        private DevExpress.XtraBars.BarButtonItem btnListarProveedor;
        private DevExpress.XtraBars.BarButtonItem barButtonItemInventario;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageInventario;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
    }
}