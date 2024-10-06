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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace FarmaciaElPorvenir
{
    public partial class formFacturasCompras : Form
    {
        Factura_compra factura_Compra;
        List<Detallecompra> detallesCompra;

        private float totalFactura;
        public formFacturasCompras()
        {
            InitializeComponent();
            detallesCompra = new List<Detallecompra>();
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
            cmbLab.Enabled = camposHabilitados;
            txtTotal.Enabled = camposHabilitados;
            txtNoFac.Enabled = camposHabilitados;
        }

        private void Limpiar()
        {
    
            txtCantidad.Text="";
            txtPrecio.Text="";
            cmbLab.EditValue= -1;
            cmbProducto.EditValue = -1;
            cmbProveedor.EditValue = -1;
            txtTotal.Text="";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GenerarNuevoNumeroFactura();
            factura_Compra = null;
            detallesCompra.Clear(); // Limpia la lista de detalles
            gridControlDetalleCompra.Refresh();
            ActualizarEstadoBotones(false, true, false, true, true);
            Limpiar();
        }

        private void formFacturasCompras_Load(object sender, EventArgs e)
        {
            deFecha.Text = DateTime.Now.ToString("d/MM/yyyy");
            gridControlDetalleCompra.DataSource = detallesCompra;
            txtNoFac.Text = GenerarNuevoNumeroFactura();
            ActualizarEstadoBotones(true, false, false, false, false);
        }
        private string GenerarNuevoNumeroFactura()
        {
            // Buscar la última factura registrada
            var ultimaFactura = unitOfWork1.Query<Factura_compra>()
                                           .OrderByDescending(f => f.No_Factura)
                                           .FirstOrDefault();

            // Si no hay facturas previas, empezar con un número base
            if (ultimaFactura == null)
            {
                return "000001"; // Primer número de factura si no hay ninguna
            }

            // Obtener el último número de factura y convertirlo a entero
            string ultimoNumeroFactura = ultimaFactura.No_Factura;

            // Suponiendo que el formato es un número secuencial de 6 dígitos
            int numeroFacturaInt;
            if (int.TryParse(ultimoNumeroFactura, out numeroFacturaInt))
            {
                // Incrementar el número de factura
                numeroFacturaInt++;

                // Devolver el nuevo número con el mismo formato, por ejemplo, 000001, 000002, etc.
                return numeroFacturaInt.ToString("D6");
            }

            // Si por alguna razón el número de factura no es un entero válido, devuelve un valor por defecto
            return "000001";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            factura_Compra = null;
            gridControlDetalleCompra.DataSource = null;
            gridControlDetalleCompra.Refresh();
            ActualizarEstadoBotones(true, false, false, false, false);
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificación de datos básicos
            if (!DateTime.TryParse(deFecha.Text, out DateTime fecha) ||
               string.IsNullOrEmpty(txtNoFac.Text) ||
               cmbLab.EditValue == null || cmbProveedor.EditValue == null)
            {
                MessageBox.Show("Por favor, verifica los datos ingresados.");
                return;
            }

            if (searchProveedor.GetFocusedRow() == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (searchLab.GetFocusedRow() == null)
            {
                MessageBox.Show("Debe seleccionar un Laboratorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica si hay detalles de compra antes de proceder
            if (detallesCompra.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un detalle de compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Empleado em = new Empleado(unitOfWork1);
            em.Id = 1; // Asigna el empleado (puedes ajustar según sea necesario)

            factura_Compra.Id_Empleado = em;
            factura_Compra.Fecha = fecha;
            factura_Compra.Total = totalFactura; // Asigna el total calculado
            factura_Compra.Id_Proveedor = (Proveedor)searchProveedor.GetFocusedRow();
            factura_Compra.No_Factura = txtNoFac.Text;
            factura_Compra.Id_Laboratorio = (Laboratorio)searchLab.GetFocusedRow();
            factura_Compra.Save();
            try
            {
                // Guardar todo en una sola transacción
                unitOfWork1.CommitChanges();
                MessageBox.Show("Registro guardado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos de la interfaz
                txtNoFac.Text = GenerarNuevoNumeroFactura(); // Generar un nuevo número de factura automáticamente
                txtCantidad.Text = string.Empty;
                txtPrecio.Text = string.Empty;
                txtTotal.Text = string.Empty;
                cmbProducto.EditValue = -1;
                cmbLab.EditValue = -1;
                cmbProveedor.EditValue = -1;
            }
            catch (Exception ex)
            {
                // Si hay algún error, revertir los cambios
                unitOfWork1.RollbackTransaction();
                MessageBox.Show("Error: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Reinicia la interfaz y limpia la lista de detalles
            factura_Compra = null;
            gridControlDetalleCompra.DataSource = null; // Limpia la lista de detalles de compra
            gridControlDetalleCompra.Refresh();
            ActualizarEstadoBotones(true, false, false, false, false);
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Factura_compra c = (Factura_compra)gridViewDetalleCompras.GetFocusedRow();
            if (c != null)
            {
                DialogResult r = MessageBox.Show("¿Desea Eliminar Registro?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    unitOfWork1.Delete(c);
                    unitOfWork1.CommitChanges();
                    xpCollectionDetalleCompras.Reload();
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
                object medicamentoId = gridViewDetalleCompras.GetRowCellValue(e.RowHandle, "Id_Medicamento!Key");
                object labid = gridViewDetalleCompras.GetRowCellValue(e.RowHandle, "Id_Proveedor!Key");

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
                    cmbLab.EditValue = labid;
                }
                else
                {
                    // Opcional: Manejar el caso donde el ítem no se encuentra o es nulo.
                    MessageBox.Show("El Laboratorio no está en la lista.");
                }
                txtCantidad.Text = gridViewDetalleCompras.GetRowCellValue(e.RowHandle,"Cantidad").ToString();
                txtNoFac.Text = gridViewDetalleCompras.GetRowCellValue(e.RowHandle, "No_Factura").ToString();
                txtPrecio.Text = gridViewDetalleCompras.GetRowCellValue(e.RowHandle, "Precio_Compra").ToString();
                txtTotal.Text = gridViewDetalleCompras.GetRowCellValue(e.RowHandle, "Total").ToString();
                deFecha.Text = gridViewDetalleCompras.GetRowCellValue(e.RowHandle,"Fecha").ToString();
                cmbLab.EditValue = gridViewDetalleCompras.GetRowCellValue(e.RowHandle, "Id_Laboratorio!Key").ToString();
                cmbProveedor.EditValue = gridViewDetalleCompras.GetRowCellValue(e.RowHandle, "Id_Proveedor!Key").ToString();
                cmbProducto.EditValue = gridViewDetalleCompras.GetRowCellValue(e.RowHandle, "Id_Inventario!Key").ToString();

                ActualizarEstadoBotones(true, false, true, true, false);
            }
        }

        private void NuevoProducto_Click(object sender, EventArgs e)
        {
            // Verificar que los campos no estén vacíos y que los valores sean válidos
            if (!int.TryParse(txtCantidad.Text, out int cantidad) ||
                !decimal.TryParse(txtPrecio.Text, out decimal precio) ||
                cmbProducto.EditValue == null)
            {
                MessageBox.Show("Por favor, verifica los datos ingresados.");
                return;
            }
            // Asegurarse de que factura_Compra no sea null
            if (factura_Compra == null)
            {
                factura_Compra = new Factura_compra(unitOfWork1); // Inicializa factura_Compra
            }
            // Calcular el total del detalle
            decimal total = cantidad * precio;

            // Crear un nuevo objeto Detallecompra con los valores ingresados
            Detallecompra nuevoDetalle = new Detallecompra(unitOfWork1);



            nuevoDetalle.Id_Producto = (Producto)searchProducto.GetFocusedRow();
            nuevoDetalle.Cantidad = cantidad;
            nuevoDetalle.Precio = (float)precio;
            nuevoDetalle.Total = (float)total;
            
            nuevoDetalle.Save();

            // Agregar el nuevo detalle a la lista de detallesCompra
            detallesCompra.Add(nuevoDetalle);  // Agregar a la lista de detallesCompra
            factura_Compra.Detallecompras.Add(nuevoDetalle); // También agregar a factura_Compra

            // Actualizar el DataSource del gridControlDetalleCompra
            gridControlDetalleCompra.DataSource = null; // Reiniciar DataSource
            gridControlDetalleCompra.DataSource = detallesCompra; // Asignar la lista actualizada
            gridControlDetalleCompra.RefreshDataSource();
            totalFactura += (float)total;

            MessageBox.Show("Producto agregado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Limpiar los campos después de agregar el producto
            txtCantidad.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtTotal.Clear();
            cmbProducto.EditValue = 0;
            cmbProducto.Focus();


        }

        private void txtCantidad_EditValueChanged(object sender, EventArgs e)
        {
            // Verificar que los campos no estén vacíos y que los valores sean válidos
            if (!string.IsNullOrEmpty(txtCantidad.Text) && !string.IsNullOrEmpty(txtPrecio.Text))
            {
                int cantidad;
                decimal precio;

                // Intentar convertir los valores
                if (int.TryParse(txtCantidad.Text, out cantidad) && decimal.TryParse(txtPrecio.Text, out precio))
                {
                    txtTotal.Text = (cantidad * precio).ToString();
                }
                else
                {
                    // Manejar el caso en que los valores no son válidos
                    txtTotal.Text = "0";
                }
            }
            
        }

        private void txtPrecio_EditValueChanged_1(object sender, EventArgs e)
        {
            // Verificar que los campos no estén vacíos y que los valores sean válidos
            if (!string.IsNullOrEmpty(txtCantidad.Text) && !string.IsNullOrEmpty(txtPrecio.Text))
            {
                int cantidad;
                decimal precio;

                // Intentar convertir los valores
                if (int.TryParse(txtCantidad.Text, out cantidad) && decimal.TryParse(txtPrecio.Text, out precio))
                {
                    txtTotal.Text = (cantidad * precio).ToString();
                }
                else
                {
                    // Manejar el caso en que los valores no son válidos
                    txtTotal.Text = "0";
                }
            }

        }
    }
}
