using DevExpress.Office.Utils;
using DevExpress.XtraGrid.Accessibility;
using FarmaciaElPorvenir.el_porvenirdb;
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
    public partial class FInventario : Form
    {
        public FInventario()
        {
            InitializeComponent();
        }
        private void ActualizarEstadoBotones(bool nuevo, bool guardar, bool eliminar, bool cancelar, bool camposHabilitados)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnEliminar.Enabled = eliminar;
            btnCancelar.Enabled = cancelar;

            // Habilitar o deshabilitar los campos
            searchLookUpEditMedicamento.Enabled = camposHabilitados;
            txtStock.Enabled = camposHabilitados;
            txtPrecioCompra.Enabled = camposHabilitados;
            txtPrecioVenta.Enabled = camposHabilitados;
            txtVencimiento.Enabled = camposHabilitados;
        }

        private void CargarMedicamentos()
        {
            Medicamento m = new Medicamento(unitOfWork1);

            if (m != null)
            {
                List<Medicamento> med = new List<Medicamento>();
                med.Append(m);
            }
        }
        private void Limpiar()
        {
            searchLookUpEditMedicamento.Clear();
            txtStock.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            txtVencimiento.Clear();
            searchLookUpEditMedicamento.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            ActualizarEstadoBotones(false, true, true, true, true);
            Limpiar();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            ActualizarEstadoBotones(true, false, false, false, false);
            CargarMedicamentos();
        }

        private void gridViewRoles_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
        }

        private void searchLookUpEditMedicamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FInventario c = (FInventario)gridView1.GetFocusedRow();
            if (c != null)
            {
                DialogResult r = MessageBox.Show("¿Desea Eliminar Registro?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    unitOfWork1.Delete(c);
                    unitOfWork1.CommitChanges();
                    xpCollection1.Reload();
                    Limpiar();
                    ActualizarEstadoBotones(true, false, false, false, false);

                }
            }
            else
            {
                MessageBox.Show("Seleccionar un Registro", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrEmpty(txtPrecioCompra.Text)|| string.IsNullOrEmpty(txtPrecioVenta.Text)||string.IsNullOrEmpty(txtStock.Text)||string.IsNullOrEmpty(searchLookUpEditMedicamento.Text))
            {
                MessageBox.Show("Campos Requeridos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
        
                // Crear o buscar el rol en la base de datos
                Inventario c = new Inventario(unitOfWork1);

                // Asignar los valores a las propiedades del rol
                c.Fecha_Vencimiento =txtVencimiento.DateTime;
                c.Precio_Compra = float.Parse(txtPrecioCompra.Text);
                c.Precio_Venta = float.Parse(txtPrecioVenta.Text);
                c.Stock = int.Parse(txtStock.Text);
                c.Id_Medicamento = (Medicamento)searchLookUpEditViewMedicamento.GetFocusedRow();

                // Guardar los cambios
                c.Save();
                unitOfWork1.CommitChanges();

                // Limpiar los controles del formulario
                Limpiar();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Guardado Exitoso", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la colección de roles para reflejar los cambios
                xpCollection1.Reload();
                ActualizarEstadoBotones(true, false, false, false,  false);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
