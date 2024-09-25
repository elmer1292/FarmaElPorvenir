using DevExpress.CodeParser;
using DevExpress.Xpo;
using DevExpress.XtraBars.Docking2010.Views;
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
    public partial class frmFacturaVenta : Form
    {
        Factura_venta factura;
        private float totalFactura = 0;
        private decimal ivaTotal = 0m;

        public frmFacturaVenta()
        {
            InitializeComponent();
        }

        private void RecalcularTotales()
        {
            totalFactura = 0;
            ivaTotal = 0m;

            for (int i = 0; i < gridViewDetalleVenta.RowCount; i++)
            {
                Detalleventa detallefactura = (Detalleventa)gridViewDetalleVenta.GetRow(i);
                if (detallefactura != null)
                {
                    totalFactura += detallefactura.Total;
                    ivaTotal += detallefactura.IVA;
                }
            }

            // Actualiza los controles de texto
            txtTotalFactura.Text = totalFactura.ToString("F2");
            txtIVATotal.Text = ivaTotal.ToString("F2");
        }


        private void frmFacturaVenta_Load(object sender, EventArgs e)
        {
            deFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            factura = new Factura_venta(unitOfWork1);
            factura.Fecha = DateTime.Now.ToLocalTime();

            txtNoFactura.Text = (factura.No_Factura + 1).ToString();
            txtIdFactura.Text = (factura.Id+1).ToString();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Verificar si hay un producto seleccionado en el SearchLookupEdit
            if (searchLookUpEditViewProducto.GetFocusedRow() == null)
            {
                MessageBox.Show("Por favor, seleccione un producto.");
                return;
            }

            // Obtener los detalles del producto seleccionado
            var selectedProduct = (Producto)searchLookUpEditViewProducto.GetFocusedRow();

            // Añadir el producto al GridView
            gridViewDetalleVenta.AddNewRow();
            gridViewDetalleVenta.SetRowCellValue(gridViewDetalleVenta.FocusedRowHandle, "Id_Producto!Key", selectedProduct.Id);
            gridViewDetalleVenta.SetRowCellValue(gridViewDetalleVenta.FocusedRowHandle, "Cantidad", 0);
            gridViewDetalleVenta.SetRowCellValue(gridViewDetalleVenta.FocusedRowHandle, "Precio", selectedProduct.Precio_Venta);
            gridViewDetalleVenta.SetRowCellValue(gridViewDetalleVenta.FocusedRowHandle, "Descuento", selectedProduct.Descuento);
            gridViewDetalleVenta.SetRowCellValue(gridViewDetalleVenta.FocusedRowHandle, "IVA", 0.15m); // 15% IVA
            gridViewDetalleVenta.SetRowCellValue(gridViewDetalleVenta.FocusedRowHandle, "SubTotal", 0);

            // Actualiza el GridView para reflejar los cambios
            gridViewDetalleVenta.UpdateCurrentRow();

            // Recalcular totales
            RecalcularTotales();
            // Focar el campo "Cantidad"
            gridViewDetalleVenta.FocusedColumn = gridViewDetalleVenta.Columns["Cantidad"];
            gridViewDetalleVenta.ShowEditor();
        }

       

       

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDetalleVenta.RowCount > 0)
                {
                    Detalleventa detallefactura = (Detalleventa)gridViewDetalleVenta.GetFocusedRow();
                    if (detallefactura != null)
                    {
                        gridViewDetalleVenta.DeleteRow(gridViewDetalleVenta.FocusedRowHandle);
                        RecalcularTotales(); // Recalcular totales después de la eliminación
                    }
                }
            }
            catch
            {
                XtraMessageBox.Show("Se ha producido un error inesperado.");
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay un cliente seleccionado
                var cliente = gridViewCliente.GetFocusedRow();
                if (cliente == null)
                {
                    XtraMessageBox.Show("Por favor, seleccione un cliente.");
                    return;
                }

                // Verificar si hay un empleado seleccionado
                var empleado = gridViewEmpleado.GetFocusedRow();
                if (empleado == null)
                {
                    XtraMessageBox.Show("Por favor, seleccione un empleado.");
                    return;
                }

                // Asignar cliente y empleado a la factura
                factura.Id_Cliente = (Cliente)cliente;
                factura.Id_Empleado = (Empleado)empleado;

                // Verificar si hay productos en el detalle de la venta
                if (gridViewDetalleVenta.RowCount == 0)
                {
                    XtraMessageBox.Show("No hay productos en la factura. Por favor, añada productos antes de procesar.");
                    return;
                }

                // Asignar los totales calculados a la factura
                factura.Total_Factura = totalFactura;
                factura.Total_IVA = (float)ivaTotal;
                factura.No_Factura = (txtNoFactura.Text);
              //  factura.Id = Convert.ToInt32( txtIdFactura.Text);
              //  factura.Save();

                // Guardar los detalles de venta
                for (int i = 0; i < gridViewDetalleVenta.RowCount; i++)
                {
                    Detalleventa detallefactura = (Detalleventa)gridViewDetalleVenta.GetRow(i);
                    if (detallefactura != null)
                    {
                        // Crear una nueva instancia de Detalleventa
                        Detalleventa nuevoDetalle = new Detalleventa(unitOfWork1)
                        {
                            Id_Producto = detallefactura.Id_Producto,
                            Cantidad = detallefactura.Cantidad,
                            Precio = detallefactura.Precio,
                            Descuento = detallefactura.Descuento,
                            IVA = detallefactura.IVA,
                            SubTotal = detallefactura.SubTotal,
                            Total = detallefactura.Total,
                            //Id_FacturaVenta = factura,
                        };

                        // Guardar el nuevo detalle                        
                        nuevoDetalle.Save();
                        factura.Detalleventas.Add(nuevoDetalle);
                       // factura.Save();
                    }
                }

                // Hacer commit de los cambios
                factura.Save();
                unitOfWork1.CommitChanges();

                // Informar al usuario que la factura se guardó correctamente
                XtraMessageBox.Show("Factura guardada con éxito.");
                LimpiarFormulario();
            }
            catch (FormatException ex)
            {
                // Manejo de errores de formato
                XtraMessageBox.Show($"Error en el formato de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                XtraMessageBox.Show($"Se ha producido un error al procesar la factura: {ex.Message}");
            }

        }


        private void gridViewDetalleVenta_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Cantidad" || e.Column.FieldName == "Descuento")
            {
                // Obtener la fila actual
                Detalleventa detallefactura = (Detalleventa)gridViewDetalleVenta.GetFocusedRow();

                // Obtener los valores necesarios
                decimal cantidad = detallefactura.Cantidad;
                decimal precio = Convert.ToDecimal(detallefactura.Precio);
                decimal descuento = Convert.ToDecimal(detallefactura.Descuento);
                decimal iva = 0.15m; // 15% IVA

                // Calcular el subtotal
                decimal subtotal = (precio * cantidad) - descuento;

                // Calcular el IVA
                decimal ivaTotal = subtotal * iva;

                // Calcular el total
                decimal total = subtotal + ivaTotal;

                // Asignar los valores calculados a las propiedades del detalle
                detallefactura.SubTotal = (float)subtotal;
                detallefactura.IVA = (int)ivaTotal;
                detallefactura.Total = (float)total;

                // Actualizar la fila en el GridView
                gridViewDetalleVenta.SetRowCellValue(gridViewDetalleVenta.FocusedRowHandle, "SubTotal", subtotal);
                gridViewDetalleVenta.SetRowCellValue(gridViewDetalleVenta.FocusedRowHandle, "IVA", ivaTotal);
                gridViewDetalleVenta.SetRowCellValue(gridViewDetalleVenta.FocusedRowHandle, "Total", total);

                // Actualizar el GridView para reflejar los cambios
                gridViewDetalleVenta.UpdateCurrentRow();

                // Recalcular totales después de la actualización
                RecalcularTotales();
            }
        }

        private void LimpiarFormulario()
        {
            // Aquí puedes reiniciar los controles a su estado inicial
            gridViewDetalleVenta.ClearSelection();
            txtTotalFactura.Text = string.Empty;
            txtIVATotal.Text = string.Empty;
            deFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            factura = null; // Reiniciar la factura
        }

        private void gridControlProducto_Click(object sender, EventArgs e)
        {

        }
    }
}
