using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Forms;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.Native;
using DevExpress.XtraReports.Wizards;
using FarmaciaElPorvenir.Database;
using FarmaciaElPorvenir.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaciaElPorvenir
{
    public partial class Dashboard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Usuario us;
        private Rol rols;
        //public Dashboard(Usuario u, Rol id_Rol)
        //{
        //    InitializeComponent();

        //}

        public Dashboard(Usuario us, Rol rol)
        {
            this.us = us;
            this.rols = rol;
            InitializeComponent();
            Accesos(rols);
        }

        private void btnAgregarCategoria_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                frmClientes formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is frmClientes)
                    {
                        formularioExistente = (frmClientes)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    frmClientes nuevoFormulario = new frmClientes();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                ListaClientes formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is ListaClientes)
                    {
                        formularioExistente = (ListaClientes)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    ListaClientes nuevoFormulario = new ListaClientes();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void btnAgregarEmpleado_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                frmEmpleado formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is frmEmpleado)
                    {
                        formularioExistente = (frmEmpleado)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    frmEmpleado nuevoFormulario = new frmEmpleado();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void barButtonCategoria_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                frmCategoria formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is frmCategoria)
                    {
                        formularioExistente = (frmCategoria)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    frmCategoria nuevoFormulario = new frmCategoria();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void barButtonItemInventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                FInventario formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is FInventario)
                    {
                        formularioExistente = (FInventario)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    FInventario nuevoFormulario = new FInventario();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void btnAgregarProveedor_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                frmProveedor formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is formFacturaVentas)
                    {
                        formularioExistente = (frmProveedor)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    frmProveedor nuevoFormulario = new frmProveedor();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void Accesos(Rol r)
        {
            try
            {
                if (r != null) 
                { 
                    if(r.Nombre_Rol == "Vendedor")
                    {
                        ribbonPageCliente.Visible = true;
                        ribbonPageFacturas.Visible = true;
                    }else if(r.Nombre_Rol =="Consulta")
                    {
                        ribbonPageInventario.Visible = true;
                    }
                    else
                    {
                        ribbonPageHome.Visible = true;
                        ribbonPageCliente.Visible=true;
                        ribbonPageEmpleado.Visible=true;
                        ribbonPageFacturas.Visible=true;
                        ribbonPageFacturas.Visible = true;
                        ribbonPageUsuario.Visible=true;
                        ribbonPageInventario.Visible=true;
                        ribbonPageInformes.Visible=true;
                    }
                }
            }
            catch
            {

            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            barStaticItemUser.Caption = us.Usuario1;
            try
            {
                // Verifica si el formulario ya está abierto
                Graficos formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is Graficos)
                    {
                        formularioExistente = (Graficos)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    Graficos nuevoFormulario = new Graficos();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.ControlBox = false; // Oculta el botón de cierre
                    nuevoFormulario.Show(); // Abre el formulario como diálogo modal
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void barButtonItemVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                formFacturaVentas formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is formFacturaVentas)
                    {
                        formularioExistente = (formFacturaVentas)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    formFacturaVentas nuevoFormulario = new formFacturaVentas(us);
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void barButtonItemCompras_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                formFacturasCompras formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is formFacturasCompras)
                    {
                        formularioExistente = (formFacturasCompras)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    formFacturasCompras nuevoFormulario = new formFacturasCompras();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void btnAgregarUsuario_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                formUsuario formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is formUsuario)
                    {
                        formularioExistente = (formUsuario)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    formUsuario nuevoFormulario = new formUsuario();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void btnAgregarR_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                frmRol formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is frmRol)
                    {
                        formularioExistente = (frmRol)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    frmRol nuevoFormulario = new frmRol();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void barButtonItemRespaldo_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "SQL Files (*.sql)|*.sql";
                saveFileDialog.Title = "Save Backup File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = saveFileDialog.FileName;
                    BackupDatabase("localhost", "root", "root123", "el_porvenirdb", backupFilePath);
                }
            }
        }

        private void barButtonItemRestaurar_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL Files (*.sql)|*.sql";
                openFileDialog.Title = "Open Backup File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = openFileDialog.FileName;
                    RestoreDatabase("localhost", "root", "root123", "el_porvenirdb", backupFilePath);
                }
            }
        }

        private void BackupDatabase(string server, string user, string password, string database, string backupFilePath)
        {
            // Ruta al ejecutable mysqldump
            string mysqldumpPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe";

            // Argumentos para mysqldump, incluyendo los triggers y los stored procedures
            string arguments = $"-h{server} -u{user} -p{password} --routines --triggers {database}";

            // Ejecutar el proceso para realizar el backup
            ExecuteProcess(mysqldumpPath, arguments, backupFilePath);
        }


        private void RestoreDatabase(string server, string user, string password, string database, string backupFilePath)
        {
            string mysqlPath = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe";
            string arguments = $"-h{server} -u{user} -p{password} {database}";

            ExecuteProcess(mysqlPath, arguments, backupFilePath, isRestore: true);
        }

        private void ExecuteProcess(string fileName, string arguments, string outputFilePath = null, bool isRestore = false)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardError = true,
                RedirectStandardOutput = !isRestore,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            if (!isRestore && outputFilePath != null) // Handle output file for backup
            {
                using (Process process = new Process())
                {
                    process.StartInfo = processInfo;
                    process.Start();

                    using (var fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                    using (var streamWriter = new StreamWriter(fileStream))
                    {
                        process.StandardOutput.BaseStream.CopyTo(streamWriter.BaseStream);
                    }

                    process.WaitForExit();
                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show("Respaldo Completo.");
                    }
                    else
                    {
                        string error = process.StandardError.ReadToEnd();
                        MessageBox.Show($"Error: {error}");
                    }
                }
            }
            else // Handle input file for restore
            {
                processInfo.Arguments = $"{arguments} < \"{outputFilePath}\"";

                try
                {
                    using (Process process = Process.Start(processInfo))
                    {
                        process.WaitForExit();
                        if (process.ExitCode == 0)
                        {
                            MessageBox.Show("Restauracion completa.");
                        }
                        else
                        {
                            string error = process.StandardError.ReadToEnd();
                            MessageBox.Show($"Error: {error}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during operation: {ex.Message}");
                }
            }
        }

        private void btnInformeCompras_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                Reportes.InformeCompras formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is InformeCompras)
                    {
                        formularioExistente = (Reportes.InformeCompras)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    InformeCompras nuevoFormulario = new InformeCompras();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void btnInformeVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                Reportes.InformeVentas formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is InformeVentas)
                    {
                        formularioExistente = (Reportes.InformeVentas)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    InformeVentas nuevoFormulario = new InformeVentas();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                InventarioDeInventario formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is InventarioDeInventario)
                    {
                        formularioExistente = (InventarioDeInventario)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    InventarioDeInventario nuevoFormulario = new InventarioDeInventario();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void btnClientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                ListaClientes formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is ListaClientes)
                    {
                        formularioExistente = (ListaClientes)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    ListaClientes nuevoFormulario = new ListaClientes();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void btnMaestroDetalleVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                MaestroDetalle formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is MaestroDetalle)
                    {
                        formularioExistente = (MaestroDetalle)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    MaestroDetalle nuevoFormulario = new MaestroDetalle ();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }


        private void btnLaboratorio_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                frmLaboratorio formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is frmLaboratorio)
                    {
                        formularioExistente = (frmLaboratorio)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    frmLaboratorio nuevoFormulario = new frmLaboratorio();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void btnVentasVendedor_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                frmVentasVendedor formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is frmVentasVendedor)
                    {
                        formularioExistente = (frmVentasVendedor)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    frmVentasVendedor nuevoFormulario = new frmVentasVendedor();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }

        private void btnStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Verifica si el formulario ya está abierto
                frmStokBajo formularioExistente = null;
                foreach (Form form in this.MdiChildren)
                {
                    if (form is frmStokBajo)
                    {
                        formularioExistente = (frmStokBajo)form;
                        break;
                    }
                }

                // Si el formulario no está abierto, crea una nueva instancia y muéstrala
                if (formularioExistente == null)
                {
                    frmStokBajo nuevoFormulario = new frmStokBajo();
                    nuevoFormulario.MdiParent = this;
                    nuevoFormulario.Show();
                }
                else
                {
                    // Si el formulario ya está abierto, lo traemos al frente
                    formularioExistente.BringToFront();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el formulario: " + ex.Message);
            }
        }
    }
}