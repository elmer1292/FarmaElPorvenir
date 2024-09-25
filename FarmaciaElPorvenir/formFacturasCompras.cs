using DevExpress.Xpo;
using DevExpress.XtraEditors;
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
    public partial class formFacturasCompras : Form
    {
        public formFacturasCompras()
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
            txtCantidad.Enabled = camposHabilitados;
            txtPrecio.Enabled = camposHabilitados;
            deFecha.Enabled = camposHabilitados;
            cmbProducto.Enabled = camposHabilitados;
            cmbProveedor.Enabled = camposHabilitados;
            txtTotal.Enabled = camposHabilitados;
            txtNoFac.Enabled = camposHabilitados;
        }

        private void Limpiar()
        {
            deFecha.Text = "";
            txtCantidad.Text="";
            txtPrecio.Text="";
            cmbProveedor.Text="";
            cmbProducto.Text="";
            txtTotal.Text="";
            txtNoFac.Text="";
            deFecha.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ActualizarEstadoBotones(false, true, false, true, true);
            Limpiar();
        }

        private void formFacturasCompras_Load(object sender, EventArgs e)
        {
            ActualizarEstadoBotones(true, false, false, false, false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ActualizarEstadoBotones(true, false, false, false, false);
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrEmpty(txtPrecio.Text) ||
                string.IsNullOrEmpty(txtNoFac.Text) || string.IsNullOrEmpty(deFecha.Text) ||
                cmbProducto.EditValue == null||cmbProveedor.EditValue == null)
            {
                MessageBox.Show("Campos Requeridos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Crear o buscar la factura en la base de datos
                Factura_compra factura_compra = new Factura_compra(unitOfWork1);
                Empleado empleado = unitOfWork1.GetObjectByKey<Empleado>(2);

                // Asignar los valores a las propiedades del objeto
                factura_compra.Id_Empleado = empleado;
                factura_compra.Fecha = deFecha.DateTime.Date;
                factura_compra.No_Factura = txtNoFac.Text;

                // Asignar el objeto Inventario a la propiedad en
                //Proveedor la = unitOfWork1.GetObjectByKey<Proveedor>(cmbProveedor.EditValue);
                //c.Id_Proveedor = la;

                // Verificar si el inventario es nulo
                //if (la == null)
                //{
                //    MessageBox.Show("Inventario no encontrado para el producto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //Inventario a = unitOfWork1.GetObjectByKey<Inventario>(cmbProducto.EditValue);
                //c.Id_Medicamento = a.Id_Medicamento;

                // Obtener y asignar los valores de cantidad, precio e IVA
                //int cantidad = int.Parse(txtCantidad.Text);
                //c.Cantidad = cantidad;
                //c.Precio_Compra = float.Parse(txtPrecio.Text);

                //float precio = float.Parse(txtPrecio.Text);
                //float total = cantidad * precio;

                //// Asignar los valores calculados
                //txtTotal.Text = total.ToString(); // Formatear como decimal con 2 decimales
                //c.Total = (float)total; // Convertir el total a float

                //// Restar la cantidad del inventario
                //Inventario inventario = unitOfWork1.GetObjectByKey<Inventario>(cmbProducto.EditValue); inventario.Stock += cantidad;

                //// Guardar los cambios en el inventario
                //unitOfWork1.Save(inventario);

                //// Guardar la factura
                //c.Save();
                //unitOfWork1.CommitChanges();

                //// Limpiar los controles del formulario
                //Limpiar();

                //// Mostrar un mensaje de éxito
                //MessageBox.Show("Guardado Exitoso", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //// Recargar la colección de facturas para reflejar los cambios
                xpCollectionCompras.Reload();
                ActualizarEstadoBotones(true, false, false, false, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Factura_compra c = (Factura_compra)gridView1.GetFocusedRow();
            if (c != null)
            {
                DialogResult r = MessageBox.Show("¿Desea Eliminar Registro?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    unitOfWork1.Delete(c);
                    unitOfWork1.CommitChanges();
                    xpCollectionCompras.Reload();
                    Limpiar();
                    ActualizarEstadoBotones(true, false, false, false, false);

                }
            }
            else
            {
                MessageBox.Show("Seleccionar un Registro", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle > 0)
            {
                object medicamentoId = gridView1.GetRowCellValue(e.RowHandle, "Id_Medicamento!Key");
                object labid = gridView1.GetRowCellValue(e.RowHandle, "Id_Proveedor!Key");

                if (medicamentoId != null)
                {
                    cmbProducto.EditValue = medicamentoId;
                }
                else
                {
                    // Opcional: Manejar el caso donde el ítem no se encuentra o es nulo.
                    MessageBox.Show("El medicamento no está en la lista.");
                }
                if (labid != null)
                {
                    cmbProveedor.EditValue = labid;
                }
                else
                {
                    // Opcional: Manejar el caso donde el ítem no se encuentra o es nulo.
                    MessageBox.Show("El Laboratorio no está en la lista.");
                }
                txtCantidad.Text = gridView1.GetRowCellValue(e.RowHandle,"Cantidad").ToString();
                txtNoFac.Text = gridView1.GetRowCellValue(e.RowHandle, "No_Factura").ToString();
                txtPrecio.Text = gridView1.GetRowCellValue(e.RowHandle, "Precio_Compra").ToString();
                txtTotal.Text = gridView1.GetRowCellValue(e.RowHandle, "Total").ToString();
                deFecha.Text = gridView1.GetRowCellValue(e.RowHandle,"Fecha").ToString();
                ActualizarEstadoBotones(true, false, true, true, false);
            }
        }
    }
}
