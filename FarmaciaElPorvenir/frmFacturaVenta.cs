using DevExpress.XtraBars.Docking2010.Views;
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
        private List<Detalleventa> listaDetalleVenta = new List<Detalleventa>();
        public frmFacturaVenta()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            txtNoFactura.Clear();
            txtPrecio.Clear();
            txtTotal.Clear();
            txtTotalFactura.Clear();
            txtCliente.Clear();
            txtDescuento.Clear();
            lookUpEditProducto.Clear();
            lookUpEditProducto.Focus();
        }

        private void HabilitarCampos(bool nuevo,bool agregar,bool eliminar,bool procesar,bool cancelar, bool campos)
        {
            btnNuevo.Enabled = nuevo; 
            btnAgregarProducto.Enabled = agregar;
            btnEliminarProducto.Enabled = eliminar;
            btnCancelarProducto.Enabled = cancelar;
            btnProcesar.Enabled = procesar;

            txtCantidad.Enabled = campos;
            txtCliente.Enabled = campos;
            txtDescuento.Enabled = campos;
            txtNoFactura.Enabled = campos;
        }

        //private void CalcularTotal()
        //{
        //    // Verifica si los campos están vacíos antes de hacer las conversiones
        //    if (!string.IsNullOrEmpty(txtCantidad.Text) &&
        //        !string.IsNullOrEmpty(txtPrecio.Text) &&
        //        !string.IsNullOrEmpty(txtDescuento.Text) &&
        //        !string.IsNullOrEmpty(txtIVA.Text))
        //    {
        //        try
        //        {
        //            int cantidad = int.Parse(txtCantidad.Text);
        //            float precio = float.Parse(txtPrecio.Text);
        //            float descuento = precio * (float.Parse(txtDescuento.Text) / 100);  // Calculo del descuento
        //            float precioConDescuento = precio - descuento; // Precio con el descuento aplicado
        //            float iva = precioConDescuento * (float.Parse(txtIVA.Text) / 100); // Calculo del IVA
        //            float subtotal = cantidad * precioConDescuento; // Subtotal antes del IVA
        //            float total = subtotal + (cantidad * iva); // Total con IVA aplicado

        //            // Mostrar valores en los campos correspondientes
        //            //txtTotal.Text = subtotal.ToString("F2");
        //            txtTotal.Text = total.ToString("F2");
        //        }
        //        catch (FormatException)
        //        {
        //            // Muestra un mensaje o maneja el error
        //            MessageBox.Show("Por favor ingresa valores numéricos válidos.");
        //        }
        //    }
        //    else
        //    {
        //        // Si hay algún campo vacío, resetea los campos
        //        //txtTotal.Text = "0";
        //        txtTotal.Text = "0";
        //    }
        //}

        private void CalcularTotal()
        {
            if (!string.IsNullOrEmpty(txtCantidad.Text) &&
                !string.IsNullOrEmpty(txtPrecio.Text) &&
                !string.IsNullOrEmpty(txtDescuento.Text) &&
                !string.IsNullOrEmpty(txtIVA.Text))
            {
                try
                {
                    int cantidad = int.Parse(txtCantidad.Text);
                    float precio = float.Parse(txtPrecio.Text);
                    float descuento = precio * (float.Parse(txtDescuento.Text) / 100);
                    float precioConDescuento = precio - descuento;
                    float iva = precioConDescuento * (float.Parse(txtIVA.Text) / 100);
                    float subtotal = cantidad * precioConDescuento;
                    float total = subtotal + (cantidad * iva);

                    txtTotal.Text = total.ToString("F2");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Por favor ingresa valores numéricos válidos.");
                }
            }
            else
            {
                txtTotal.Text = "0";
            }
        }


        private void frmFacturaVenta_Load(object sender, EventArgs e)
        {
            deFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            HabilitarCampos(true,false, false, false, false, false);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "" && txtPrecio.Text != "")
            {
                // Crear un nuevo detalle de venta y agregarlo a la lista temporal
                Detalleventa detalle = new Detalleventa(unitOfWork1);
                {
                    detalle.Id_Producto = (Producto)searchLookUpEditProducto.GetFocusedRowCellValue("Id_Producto");
                    detalle.Cantidad = int.Parse(txtCantidad.Text);
                    detalle.Precio = float.Parse(txtPrecio.Text);
                    detalle.Descuento = int.Parse(txtDescuento.Text);
                    detalle.IVA = int.Parse(txtIVA.Text); // Asegúrate de que txtIVA esté presente y tenga valor
                    detalle.Total = float.Parse(txtTotal.Text);
                };

                listaDetalleVenta.Add(detalle);  // Añadir a la lista temporal

                // Limpiar campos y preparar para agregar otro producto
                Limpiar();
                HabilitarCampos(false, true, true, true, true, true);
            }
            else
            {
                MessageBox.Show("Por favor completa todos los campos.");
            }

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal(); // Llama al método para recalcular el total
        }

        private void searchLookUpEditProducto_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                // Asigna los valores de precio y descuento al seleccionar un producto
                txtPrecio.Text = searchLookUpEditProducto.GetFocusedRowCellValue("Precio_Venta").ToString();
                txtDescuento.Text = searchLookUpEditProducto.GetFocusedRowCellValue("Descuento").ToString();

                // Habilitar los campos de cantidad y descuento
                HabilitarCampos(true,true,true,true,true,true);
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal(); // Llama al método para recalcular el total

        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            HabilitarCampos(true, false,false,false,false,false);
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarCampos(false,true, false, true, true, true);
            Limpiar();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            // Validar que haya productos agregados
            if (listaDetalleVenta.Count > 0)
            {
                try
                {
                    // Obtener el empleado y cliente desde la base de datos
                    int empleadoId = Convert.ToInt32(txtEmpleado.EditValue);
                    Empleado empleado = unitOfWork1.GetObjectByKey<Empleado>(empleadoId); // Busca al empleado por ID

                    int clienteId = Convert.ToInt32(txtCliente.EditValue);
                    Cliente cliente = unitOfWork1.GetObjectByKey<Cliente>(clienteId); // Busca al cliente por ID

                    // Crear una nueva factura
                    Factura_venta factura = new Factura_venta(unitOfWork1);
                    {
                        factura.Id_Empleado = empleado;  // Asigna el objeto Empleado
                        factura.Id_Cliente = cliente;    // Asigna el objeto Cliente
                        factura.Fecha = DateTime.Now;
                        factura.No_Factura = txtNoFactura.Text;
                        factura.Total_Factura = listaDetalleVenta.Sum(d => d.Total);  // Suma total de todos los productos
                        factura.Total_IVA = listaDetalleVenta.Sum(d => d.IVA); // O el cálculo correcto del IVA
                    };

                    // Guardar la factura en la base de datos
                    factura.Save();  // O usa tu ORM o método para guardar

                    // Guardar los detalles de la factura
                    foreach (var detalle in listaDetalleVenta)
                    {
                        detalle.Id_FacturaVenta = factura;  // Asocia la entidad Factura_venta
                        detalle.Save();  // Guardar en la base de datos
                    }

                    MessageBox.Show("Factura procesada correctamente.");

                    // Limpiar todo para una nueva venta
                    Limpiar();
                    listaDetalleVenta.Clear();
                    HabilitarCampos(true, false, false, false, false, false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al procesar la factura: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("No hay productos agregados.");
            }
        }

    }
}
