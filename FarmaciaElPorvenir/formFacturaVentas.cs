using DevExpress.Xpo;
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
    public partial class formFacturaVentas : Form
    {
        Factura_venta fv;
        private List<Detalleventa> detallesVenta;
        Usuario us;
        public formFacturaVentas(Usuario us)
        {
            InitializeComponent();
            detallesVenta = new List<Detalleventa>();
            this.us = us;
        }


        private void formFacturaVentas_Load(object sender, EventArgs e)
        {
            var cliente = unitOfWork1.Query<Cliente>()
                         .FirstOrDefault(f => f.Id == 25);

            searchCliente.EditValue = cliente;

            dateFecha.Text = DateTime.Now.ToString("d/MM/yyyy");
            gridControlDetalleVenta.DataSource = detallesVenta; // Asigna la lista como DataSource
            ActualizarEstadoBotones(true, false, false, false, false);

            txtNoFactura.Text= GenerarNuevoNumeroFactura();
        }

        private void ActualizarEstadoBotones(bool nuevo, bool guardar, bool eliminar, bool cancelar, bool camposHabilitados)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnEliminar.Enabled = eliminar;
            btnCancelar.Enabled = cancelar;

            // Habilitar o deshabilitar los campos
            txtCantidad.Enabled = camposHabilitados;
            searchCliente.Enabled = camposHabilitados;
            txtDescuento.Enabled = camposHabilitados;
            searchProducto.Enabled = camposHabilitados;
            btnAgregarNuevoCliente.Enabled = camposHabilitados;
            btnAgregar.Enabled = camposHabilitados;
        }

        private void Limpiar()
        {

            txtCantidad.Clear();
            txtPrecio.Clear();
            txtDescuento.Clear();
            txtIVA.Clear();
            txtSubTotal.Clear();
            txtTotalIVA.Clear();
            txtTotalFactura.Clear();
            txtTotal.Clear();
            searchProducto.Clear();
            detallesVenta.Clear(); // Limpia la lista de detalles

        }
        private void LimpiarCamposDetalle()
        {
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtDescuento.Clear();
            txtIVA.Clear();
            txtSubTotal.Clear();
            txtTotal.Clear();
            searchProducto.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            fv = null;
            detallesVenta.Clear(); // Limpia la lista de detalles
            gridControlDetalleVenta.Refresh();
            ActualizarEstadoBotones(true, false, false, false, false);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0 ||
                !float.TryParse(txtSubTotal.Text, out float subTotal) ||
                !float.TryParse(txtDescuento.Text, out float descuento) ||
                !float.TryParse(txtIVA.Text, out float iva) ||
                !float.TryParse(txtTotal.Text, out float total) ||
                !float.TryParse(txtPrecio.Text, out float precio))
            {
                MessageBox.Show("Por favor, verifica los datos ingresados.");
                return;
            }

            // Buscar el producto seleccionado
            Producto productoSeleccionado = (Producto)searchViewProductos.GetFocusedRow();
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Por favor, selecciona un producto válido.");
                return;
            }

            // Verificar que haya suficiente stock
            if (productoSeleccionado.Stock < cantidad)
            {
                MessageBox.Show("No hay suficiente stock para completar la venta.");
                return;
            }

            // Mostrar advertencia si el stock es bajo
            if (productoSeleccionado.Stock <= 10)
            {
                MessageBox.Show($"El producto '{productoSeleccionado.Medicamento}' tiene un stock bajo ({productoSeleccionado.Stock} unidades).",
                                "Advertencia de Stock",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

            var detalle = new Detalleventa(unitOfWork1)
            {
                Precio = precio,
                Cantidad = cantidad,
                SubTotal = subTotal,
                Id_Producto = productoSeleccionado, // Asegúrate de que esto sea solo el objeto Producto
                Descuento = descuento,
                IVA = iva,
                Total = total,
            };

            // Agregar el nuevo detalle a la lista de detalles de venta
            detallesVenta.Add(detalle);
            gridControlDetalleVenta.RefreshDataSource();

            RecalcularTotalFactura();
            LimpiarCamposDetalle();
            productoSeleccionado.Stock -= cantidad;
            productoSeleccionado.Save(); // Guarda los cambios en el producto
            ActualizarEstadoBotones(false, true, true, true, true);
        }



        private void txtCantidad_EditValueChanged(object sender, EventArgs e)
        {
            Producto p = (Producto)searchViewProductos.GetFocusedRow();
            if (p == null)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Agregar Producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtPrecio.Text = p.Precio_Venta.ToString();
            txtSubTotal.Text = int.TryParse(txtCantidad.Text, out int cantidad) ? (p.Precio_Venta * cantidad).ToString("0.00") : "0.00"; // o string.Empty si prefieres dejarlo vacío
            txtIVA.Text = (float.Parse(txtSubTotal.Text) * 15 / 100).ToString();
            txtTotal.Text = (float.Parse(txtSubTotal.Text)+float.Parse(txtIVA.Text)).ToString();
        }
        private void searchCliente_BeforePopup(object sender, EventArgs e)
        {
            searchViewCliente.Columns[0].Visible = false;
        }

        public Graficos formularioGraficosGlobal;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(dateFecha.Text, out DateTime fecha) ||
                !float.TryParse(txtTotalFactura.Text, out float totalFactura) ||
                !float.TryParse(txtTotalIVA.Text, out float totalIVA))
            {
                MessageBox.Show("Por favor, verifica los datos ingresados.");
                return;
            }
            if (searchViewProductos.GetFocusedRow() == null)
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (searchViewCliente.GetFocusedRow() == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica si hay detalles de venta antes de proceder
            if (detallesVenta.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un detalle de venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var empleado = unitOfWork1.Query<Empleado>()
                             .FirstOrDefault(empleadoActual => empleadoActual.Id == us.Id_Empleado.Id);

            // Inicializa la factura
            fv = new Factura_venta(unitOfWork1)
            {
                Fecha = fecha,
                Total_Factura = totalFactura,
                Total_IVA = totalIVA,
                Id_Cliente = (Cliente)searchViewCliente.GetFocusedRow(),
                No_Factura = txtNoFactura.Text,
                Id_Empleado = empleado,
            };

            try
            {
                fv.Save(); // Guarda la factura

                // Agregar los detalles de venta a la colección DetalleVentas
                foreach (var detalle in detallesVenta)
                {
                    var detalleVenta = new Detalleventa(unitOfWork1)
                    {
                        Id_Producto = detalle.Id_Producto,
                        Cantidad = detalle.Cantidad,
                        Precio = detalle.Precio,
                        Descuento = detalle.Descuento,
                        IVA = detalle.IVA,
                        Total = detalle.Total,
                        SubTotal = detalle.SubTotal,
                        Factura_venta_Id = fv // Asignar la factura a cada detalle
                    };

                    detalleVenta.Save(); // Guardar el detalle de venta
                }

                unitOfWork1.CommitChanges(); // Aplica los cambios a la base de datos
                MessageBox.Show("Registro Guardado.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos de la interfaz
                txtNoFactura.Text = GenerarNuevoNumeroFactura(); // Podrías generar un nuevo número automáticamente
                Limpiar();

                // Reinicia la interfaz
                fv = null;
                gridControlDetalleVenta.DataSource = null;
                gridControlDetalleVenta.Refresh();
                ActualizarEstadoBotones(true, false, false, false, false);

                // Intenta encontrar el formulario de gráficos ya abierto
                var formularioGraficos = Application.OpenForms.OfType<Graficos>().FirstOrDefault();

                if (formularioGraficos != null)
                {
                    formularioGraficos.CargarGraficoProductos();
                    formularioGraficos.CargarGraficoVendedores();
                }
            }
            catch (Exception ex)
            {
                unitOfWork1.RollbackTransaction(); // Revertir los cambios en caso de error
                MessageBox.Show("Error: " + ex.Message, "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void searchViewProductos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(e.RowHandle>=0)
            {
                txtPrecio.Text = searchViewProductos.GetRowCellValue(e.RowHandle,"Precio_Venta").ToString();
                txtDescuento.Text = searchViewProductos.GetRowCellValue(e.RowHandle, "Descuento").ToString();
            }
        }

        private void RecalcularTotalFactura()
        {
            float totalFactura = detallesVenta.Sum(d => d.Total);
            txtTotalFactura.Text = totalFactura.ToString("0.00");
            // Manejar la suma total del IVA
            float totalIVA = detallesVenta.Sum(d => d.IVA); ;
            txtTotalIVA.Text = totalIVA.ToString("0.00"); // Asigna el nuevo total formateado
        }
        private string GenerarNuevoNumeroFactura()
        {
            // Buscar la última factura registrada
            var ultimaFactura = unitOfWork1.Query<Factura_venta>()
                                           .OrderByDescending(f => f.No_Factura)
                                           .FirstOrDefault();

            // Si no hay facturas previas, empezar con un número base
            if (ultimaFactura == null)
            {
                return (1).ToString(); // Primer número de factura si no hay ninguna
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
                return numeroFacturaInt.ToString();
            }

            // Si por alguna razón el número de factura no es un entero válido, devuelve un valor por defecto
            return (1).ToString();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GenerarNuevoNumeroFactura();
            ActualizarEstadoBotones(false, true, true, true, true);
            fv = null;
            detallesVenta.Clear(); // Limpia la lista de detalles
            gridControlDetalleVenta.Refresh();
        }

        private void btnAgregarNuevoCliente_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.ShowDialog();
            xpCollectionClientes.Reload();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si hay un detalle seleccionado en el grid
            searchViewCliente.RefreshData();
            var filaSeleccionada = gridViewDetalleVenta.GetSelectedRows();
            
            if (filaSeleccionada.Length == 0)
            {
                MessageBox.Show("Por favor, selecciona un detalle de venta para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtiene el detalle de venta seleccionado (asumiendo que 'detallesVenta' es la lista de detalles)
            int rowHandle = filaSeleccionada[0];
            Detalleventa detalleSeleccionado = (Detalleventa)gridViewDetalleVenta.GetRow(rowHandle);

            if (detalleSeleccionado != null)
            { 
                // Eliminar el detalle de la lista de detalles
                detallesVenta.Remove(detalleSeleccionado);

                // Actualiza el DataSource del gridControl
                gridControlDetalleVenta.RefreshDataSource();
                // Recalcular el total de la factura después de la eliminación
                RecalcularTotalFactura();

                // Actualizar el estado de los botones (si es necesario)
                ActualizarEstadoBotones(false, detallesVenta.Count > 0, detallesVenta.Count > 0, true, true);
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un detalle válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
