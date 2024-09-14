using DevExpress.XtraBars.Docking2010.Views;
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
        public frmFacturaVenta()
        {
            InitializeComponent();
        }

        private void frmFacturaVenta_Load(object sender, EventArgs e)
        {
            deFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
           
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            // Verifica si los campos están vacíos antes de hacer las conversiones
            if (!string.IsNullOrEmpty(txtCantidad.Text) &&
                !string.IsNullOrEmpty(txtPrecio.Text) &&
                !string.IsNullOrEmpty(txtDescuento.Text) &&
                !string.IsNullOrEmpty(txtIVA.Text))
            {
                try
                {
                    int cantidad = int.Parse(txtCantidad.Text);
                    float precio = float.Parse(txtPrecio.Text);
                    float descuento = precio * float.Parse(txtDescuento.Text) / 100;
                    float iva = precio * (float.Parse(txtIVA.Text) / 100);
                    float total = (cantidad * precio - descuento)+iva;
                    txtTotal.Text = total.ToString();
                }
                catch (FormatException)
                {
                    // Opcional: Muestra un mensaje o maneja el error
                    MessageBox.Show("Por favor ingresa un valor numérico válido.");
                }
            }
            else
            {
                // Si hay algún campo vacío, limpias el campo de total o haces otra acción
                txtTotal.Text = "0";
            }
        }

        private void searchLookUpEditProducto_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                txtPrecio.Text = searchLookUpEditProducto.GetFocusedRowCellValue("Precio_Venta").ToString();
                txtDescuento.Text = searchLookUpEditProducto.GetFocusedRowCellValue("Descuento").ToString();
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            

            // Verifica si los campos están vacíos antes de hacer las conversiones
            if (!string.IsNullOrEmpty(txtCantidad.Text) &&
                !string.IsNullOrEmpty(txtPrecio.Text) &&
                !string.IsNullOrEmpty(txtDescuento.Text) &&
                !string.IsNullOrEmpty(txtIVA.Text))
            {
                try
                {
                    float subtotal = float.Parse(txtTotal.Text);
                    float descuento = float.Parse(txtDescuento.Text) / 100;
                    float total = subtotal - descuento;
                    txtTotal.Text = total.ToString();
                }
                catch (FormatException)
                {
                    // Opcional: Muestra un mensaje o maneja el error
                    MessageBox.Show("Por favor ingresa un valor numérico válido.");
                }
            }
            
        }
    }
}
