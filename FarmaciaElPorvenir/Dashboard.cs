using DevExpress.XtraBars;
using DevExpress.XtraBars.Forms;
using FarmaciaElPorvenir.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaciaElPorvenir
{
    public partial class Dashboard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Dashboard()
        {
            InitializeComponent();
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

        private void btnRol_ItemClick(object sender, ItemClickEventArgs e)
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
                    if (form is frmProveedor)
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
    }
}