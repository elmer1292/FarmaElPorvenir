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
        BindingList<Detalleventa> detalleVentas; // Lista para manejar los detalles de la venta
        public formFacturaVentas()
        {
            InitializeComponent();
            detalleVentas = new BindingList<Detalleventa>(); // Inicializa la lista
        }


        private void formFacturaVentas_Load(object sender, EventArgs e)
        {
            dateFecha.Text = DateTime.Now.ToString("d/MM/yyyy");
            gridControlDetalleVenta.DataSource = detalleVentas; // Asigna la lista como DataSource
            //HabilitarBotones(false);
        }

        private void HabilitarBotones(bool v)
        {
            btnNuevo.Enabled = !v;
            btnCancelar.Enabled = v;
            btnGuardar.Enabled = v;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            fv = null;
            detalleVentas.Clear(); // Limpia la lista de detalles
            gridControlDetalleVenta.Refresh();

            //HabilitarBotones(false);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCantidad.Text, out int cantidad) ||
      !float.TryParse(txtSubTotal.Text, out float subTotal) ||
      !float.TryParse(txtDescuento.Text, out float descuento) ||
      !int.TryParse(txtIVA.Text, out int iva) ||
      !float.TryParse(txtTotal.Text, out float total)|| !float.TryParse(txtPrecio.Text, out float precio))
            {
                MessageBox.Show("Por favor, verifica los datos ingresados.");
                return;
            }

            Detalleventa d = new Detalleventa(unitOfWork1)
            {
                Precio =precio,
                Cantidad = cantidad,
                SubTotal = subTotal,
                Id_Producto = (Producto)searchViewProductos.GetFocusedRow(),
                Descuento = descuento,
                IVA = iva,
                Total = total,
            };

            // Actualiza el GridControl (asumiendo que hay una lista para la colección de detalles)
            detalleVentas.Add(d);
            gridControlDetalleVenta.RefreshDataSource();

            // Manejar la suma total de la factura
            float totalFactura = 0f;
            float.TryParse(txtTotalFactura.Text, out totalFactura); // Intenta convertir el total actual
            totalFactura += d.Total; // Suma el total del nuevo detalle
            txtTotalFactura.Text = totalFactura.ToString("0.00"); // Asigna el nuevo total formateado

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
            txtSubTotal.Text =int.TryParse(txtCantidad.Text, out int cantidad)? (p.Precio_Venta * cantidad).ToString("0.00"): "0.00"; // o string.Empty si prefieres dejarlo vacío
        }

        private void searchCliente_BeforePopup(object sender, EventArgs e)
        {
            searchViewCliente.Columns[0].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(dateFecha.Text, out DateTime fecha) ||
                 !float.TryParse(txtTotalFactura.Text, out float totalFactura) ||
                 !float.TryParse(txtTotalIVA.Text, out float totalIVA))
            {
                MessageBox.Show("Por favor, verifica los datos ingresados.");
                return;
            }
            
            // Inicializa la factura
            fv = new Factura_venta(unitOfWork1)
            {
                Fecha = fecha,
                Total_Factura = totalFactura,
                Total_IVA = totalIVA,
                Id_Cliente = (Cliente)searchViewCliente.GetFocusedRow(),
                No_Factura = txtNoFactura.Text,
                Id_Empleado = (Empleado)searchViewEmpleados.GetFocusedRow()
            };

            try
            {
                
                fv.Save(); // Guarda la factura
                unitOfWork1.CommitChanges(); // Aplica los cambios a la base de datos
                MessageBox.Show("Registro Guardado.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Reinicia la interfaz
            fv = null;
            detalleVentas.Clear(); // Limpia la lista de detalles
            gridControlDetalleVenta.Refresh();
            HabilitarBotones(false);
        }

        private void searchViewProductos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(e.RowHandle>=0)
            {
                txtPrecio.Text = searchViewProductos.GetRowCellValue(e.RowHandle,"Precio_Venta").ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
