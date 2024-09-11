using DevExpress.Office.Utils;
using DevExpress.Xpo;
using DevExpress.XtraLayout.Filtering.Templates;
using FarmaciaElPorvenir.el_porvenirdb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaciaElPorvenir
{
    public partial class formFacturasVentas :Form
    {
        private const decimal IVA_PERCENTAGE = 0.15m; // IVA del 15%

        public formFacturasVentas()
        {
            InitializeComponent();
            txtCantidad.TextChanged += new EventHandler(CalcularTotal);
            txtPrecio.TextChanged += new EventHandler(CalcularTotal);
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
            //deFechaVenta.Enabled = camposHabilitados;
            cmbProducto.Enabled = camposHabilitados;
            txtTotal.Enabled = camposHabilitados;
            txtNoFac.Enabled = camposHabilitados;
        }

        private void Limpiar()
        {
            txtCantidad.Clear();
            txtPrecio.Clear();
            //txtIVA.Clear();
            //deFechaVenta.Clear();
            cmbProducto.Clear();
            txtTotal.Clear();
            txtCantidad.Clear();
            txtNoFac.Clear();
            deFechaVenta.Focus();
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ActualizarEstadoBotones(false, true, false, true, true);
            Limpiar();
        }

        private void formFacturasVentas_Load(object sender, EventArgs e)
        {
            ActualizarEstadoBotones(true, false, false, false,  false);
            deFechaVenta.EditValue = DateTime.Now;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ActualizarEstadoBotones(true, false, false, false,  false);
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrEmpty(txtIVA.Text) ||
                string.IsNullOrEmpty(txtNoFac.Text) || string.IsNullOrEmpty(deFechaVenta.Text) ||
                cmbProducto.EditValue == null || string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Campos Requeridos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Crear o buscar la factura en la base de datos
                Factura_venta c = new Factura_venta(unitOfWork1);
                Empleado empleado = unitOfWork1.GetObjectByKey<Empleado>(3);

                // Asignar los valores a las propiedades del objeto Factura_venta
                c.Id_Empleado = empleado;
                c.Fecha = deFechaVenta.DateTime.Date;
                c.No_Factura = txtNoFac.Text;

                // Asignar el objeto Inventario a la propiedad en Factura_venta
                Inventario inventario = unitOfWork1.GetObjectByKey<Inventario>(cmbProducto.EditValue);
                c.Id_Inventario = inventario;

                // Verificar si el inventario es nulo
                if (inventario == null)
                {
                    MessageBox.Show("Inventario no encontrado para el producto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener y asignar los valores de cantidad, precio e IVA
                int cantidad = int.Parse(txtCantidad.Text);
                c.Cantidad = cantidad;
                c.Precio = float.Parse(txtPrecio.Text);
                c.IVA = decimal.Parse(txtIVA.Text);

                // Calcular el subtotal
                float precio = float.Parse(txtPrecio.Text);
                float subtotal = cantidad * precio;

                // Calcular el total
                decimal ivaDecimal = decimal.Parse(txtIVA.Text);
                decimal subtotalDecimal = (decimal)subtotal; // Convertir subtotal a decimal para precisión
                decimal total = (subtotalDecimal * (ivaDecimal/100)) + subtotalDecimal;

                // Asignar los valores calculados
                txtTotal.Text = total.ToString("F2"); // Formatear como decimal con 2 decimales
                c.Total = (float)total; // Convertir el total a float

                // Restar la cantidad del inventario
                inventario.Stock -= cantidad;
                if (inventario.Stock < 0)
                {
                    throw new Exception("La cantidad en inventario no puede ser negativa.");
                }

                // Guardar los cambios en el inventario
                unitOfWork1.Save(inventario);

                // Guardar la factura
                c.Save();
                unitOfWork1.CommitChanges();

                // Limpiar los controles del formulario
                Limpiar();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Guardado Exitoso", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la colección de facturas para reflejar los cambios
                xpCollectionFacturaVenta.Reload();
                ActualizarEstadoBotones(true, false, false, false, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Factura_venta c = (Factura_venta)gridView1.GetFocusedRow();
            if (c != null)
            {
                DialogResult r = MessageBox.Show("¿Desea Eliminar Registro?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    unitOfWork1.Delete(c);
                    unitOfWork1.CommitChanges();
                    xpCollectionFacturaVenta.Reload();
                    Limpiar();
                    ActualizarEstadoBotones(true, false, false, false,  false);

                }
            }
            else
            {
                MessageBox.Show("Seleccionar un Registro", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ActualizarEstadoBotones(true, false, true, true, false);

        }

        private void CalcularTotal(object sender, EventArgs e)
        {
            try
            {
                // Obtén los valores de los TextBox
                decimal cantidad = string.IsNullOrWhiteSpace(txtCantidad.Text) ? 0 : decimal.Parse(txtCantidad.Text);
                decimal precio = string.IsNullOrWhiteSpace(txtPrecio.Text) ? 0 : decimal.Parse(txtPrecio.Text);

                // Calcula el subtotal
                decimal subtotal = cantidad * precio;

                // Calcula el IVA
                decimal iva = subtotal * IVA_PERCENTAGE;   

                // Calcula el total
                decimal total = subtotal + iva;

                // Muestra el total en el TextBox de total
                txtTotal.Text = total.ToString("F2"); // Muestra el total con 2 decimales
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error o maneja la excepción si ocurre
                MessageBox.Show($"Error al calcular el total: {ex.Message}");
                txtTotal.Text = "0.00";
            }
        }
    }
}
