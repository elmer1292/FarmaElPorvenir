using DevExpress.Office.Utils;
using DevExpress.XtraGrid.Accessibility;
using FarmaciaElPorvenir.Database;
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
        private void ActualizarEstadoBotones(bool nuevo, bool guardar, bool eliminar,bool actualizar, bool cancelar, bool camposHabilitados)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnActualizar.Enabled = actualizar;
            btnEliminar.Enabled = eliminar;
            btnCancelar.Enabled = cancelar;

            // Habilitar o deshabilitar los campos
            searchLookUpEditMedicamento.Enabled = camposHabilitados;
            txtStock.Enabled = camposHabilitados;
            txtPrecioCompra.Enabled = camposHabilitados;
            txtPrecioVenta.Enabled = camposHabilitados;
            txtVencimiento.Enabled = camposHabilitados;
           
            txtDescuento.Enabled = camposHabilitados;
            cmbCategorias.Enabled = camposHabilitados;
            cmbProveedor.Enabled = camposHabilitados;
        }

       
        private void Limpiar()
        {
            
            txtDescuento.Text="";
            cmbCategorias.Text = "";
            cmbProveedor.Text = "";
            searchLookUpEditMedicamento.Text = "";
            txtStock.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtVencimiento.Text = "";
            searchLookUpEditMedicamento.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            ActualizarEstadoBotones(false, true, false, false, true,true);
            Limpiar();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            ActualizarEstadoBotones(true, false, false, false, false, false);
            
        }

        private void gridViewRoles_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
        }

        private void searchLookUpEditMedicamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto c = (Producto)gridViewProducto.GetFocusedRow();
            if (c != null)
            {
                DialogResult r = MessageBox.Show("¿Desea Eliminar Registro?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    unitOfWork1.Delete(c);
                    unitOfWork1.CommitChanges();
                    xpCollection1.Reload();
                    Limpiar();
                    ActualizarEstadoBotones(true, false, false, false, false, false);

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
            if (string.IsNullOrEmpty(txtPrecioCompra.Text)|| 
                string.IsNullOrEmpty(txtPrecioVenta.Text)||
                string.IsNullOrEmpty(txtStock.Text)||
                string.IsNullOrEmpty(searchLookUpEditMedicamento.Text)||
                string.IsNullOrEmpty(txtDescuento.Text)||
                string.IsNullOrEmpty(cmbCategorias.Text)||
                string.IsNullOrEmpty(cmbProveedor.Text)|| string.IsNullOrEmpty(comboBoxEditLaboratorio.Text))
            {
                MessageBox.Show("Campos Requeridos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {        
                Producto producto = new Producto(unitOfWork1);

                // Asignar los valores a las propiedades del rol
                producto.Vencimiento =txtVencimiento.DateTime;
                producto.Precio_Compra = float.Parse(txtPrecioCompra.Text);
                producto.Precio_Venta = float.Parse(txtPrecioVenta.Text);
                producto.Stock = int.Parse(txtStock.Text);
                producto.Medicamento = searchLookUpEditMedicamento.Text;
                producto.Descuento = float.Parse(txtDescuento.Text);
                producto.Id_Categoria = (Categoria)gridViewCategoria.GetFocusedRow();
                producto.Id_Proveedor = (Proveedor)searchLookUpEdit1ViewProveedor.GetFocusedRow();
                producto.Id_Laboratorio = (Laboratorio)searchLookUpEditLaboratorio.GetFocusedRow();
                // Guardar los cambios
                producto.Save();
                unitOfWork1.CommitChanges();

                // Limpiar los controles del formulario
                Limpiar();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Guardado Exitoso", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la colección de roles para reflejar los cambios
                xpCollection1.Reload();
                ActualizarEstadoBotones(true, false, false, false,  false,false);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gridViewProducto_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                searchLookUpEditMedicamento.Text = gridViewProducto.GetRowCellValue(e.RowHandle,"Medicamento").ToString();
                txtDescuento.Text=gridViewProducto.GetRowCellValue(e.RowHandle,"Descuento").ToString();
                txtStock.Text= gridViewProducto.GetRowCellValue(e.RowHandle, "Stock").ToString();
                txtPrecioCompra.Text = gridViewProducto.GetRowCellValue(e.RowHandle, "Precio_Compra").ToString();
                txtPrecioVenta.Text = gridViewProducto.GetRowCellValue(e.RowHandle, "Precio_Venta").ToString();
                txtVencimiento.Text = gridViewProducto.GetRowCellValue(e.RowHandle, "Vencimiento").ToString();
                cmbCategorias.EditValue = gridViewProducto.GetRowCellValue(e.RowHandle, "Id_Categoria!Key").ToString();
                cmbProveedor.EditValue = gridViewProducto.GetRowCellValue(e.RowHandle, "Id_Proveedor!Key").ToString();

                ActualizarEstadoBotones(false, false, true, true, true,true);

            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos obligatorios están vacíos
            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrEmpty(txtPrecioCompra.Text) ||
                string.IsNullOrEmpty(txtPrecioVenta.Text) ||
                string.IsNullOrEmpty(txtStock.Text) ||
                string.IsNullOrEmpty(searchLookUpEditMedicamento.Text) ||
                string.IsNullOrEmpty(txtDescuento.Text) ||
                string.IsNullOrEmpty(cmbCategorias.Text) ||
                string.IsNullOrEmpty(cmbProveedor.Text))
            {
                MessageBox.Show("Campos Requeridos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Verificar si se ha seleccionado una fila en el gridViewRoles
            int id = (int)gridViewProducto.GetFocusedRowCellValue("Id");

            if (id <= 0)
            {
                MessageBox.Show("Por favor, seleccione un producto para actualizar.", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Buscar el rol en la base de datos
                Producto producto = unitOfWork1.GetObjectByKey<Producto>(id);
                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Asignar los valores a las propiedades del rol
                producto.Vencimiento = txtVencimiento.DateTime;
                producto.Precio_Compra = float.Parse(txtPrecioCompra.Text);
                producto.Precio_Venta = float.Parse(txtPrecioVenta.Text);
                producto.Stock = int.Parse(txtStock.Text);
                producto.Medicamento = searchLookUpEditMedicamento.Text;
                producto.Descuento = float.Parse(txtDescuento.Text);
                producto.Id_Categoria = (Categoria)gridViewCategoria.GetFocusedRow();
                producto.Id_Proveedor = (Proveedor)searchLookUpEdit1ViewProveedor.GetFocusedRow();
                // Guardar los cambios
                producto.Save();
                unitOfWork1.CommitChanges();

                // Limpiar los controles del formulario
                Limpiar();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Actualización Exitosa", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la colección de roles para reflejar los cambios
                xpCollection1.Reload();
                ActualizarEstadoBotones(true, false, false,false, false, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ActualizarEstadoBotones(true, false, false, false, false, false);
            Limpiar();
        }

        private void searchLookUpEditMedicamento_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
