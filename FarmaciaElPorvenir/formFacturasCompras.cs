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
        Factura_compra factura_Compra;
        List<Detallecompra> detallesCompra;
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
            cmbLab.Enabled = camposHabilitados;
            txtTotal.Enabled = camposHabilitados;
            txtNoFac.Enabled = camposHabilitados;
        }

        private void Limpiar()
        {
            deFecha.Text = "";
            txtCantidad.Text="";
            txtPrecio.Text="";
            cmbLab.Text="";
            cmbProducto.Text="";
            txtTotal.Text="";
            txtNoFac.Text="";
            deFecha.Focus();
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
            ActualizarEstadoBotones(true, false, false, false, false);
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(deFecha.Text, out DateTime fecha) ||
               string.IsNullOrEmpty(txtNoFac.Text) ||
               !int.TryParse(txtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("Por favor, verifica los datos ingresados.");
                return;
            }
            if (searchProducto.GetFocusedRow() == null)
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Verifica si hay detalles de venta antes de proceder
            if (detallesCompra.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un detalle de venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Empleado em = new Empleado(unitOfWork1);
            em.Id = 1;
            // Inicializa la factura
            factura_Compra = new Factura_compra(unitOfWork1)
            {
                Fecha = fecha,
                Total= float.Parse( txtTotal.Text),
                Id_Proveedor = (Proveedor)searchProveedor.GetFocusedRow(),
                No_Factura = txtNoFac.Text,
                Id_Empleado = em,
                Id_Laboratorio = (Laboratorio)searchLab.GetFocusedRow(),
            };

            try
            {
                factura_Compra.Save(); // Guarda la factura

                // Agregar los detalles de venta a la colección DetalleVentas
                foreach (var detalle in detallesCompra)
                {
                    var detallesCompra = new Detallecompra(unitOfWork1)
                    {
                        Id_Producto = detalle.Id_Producto,
                        Cantidad = detalle.Cantidad,
                        Precio = detalle.Precio,
                        Total = detalle.Total,
                        Id_FacturaCompra = factura_Compra // Asignar la factura a cada detalle
                    };

                    detallesCompra.Save(); // Guardar el detalle de venta
                }

                unitOfWork1.CommitChanges(); // Aplica los cambios a la base de datos
                MessageBox.Show("Registro Guardado.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos de la interfaz
                txtNoFac.Text = GenerarNuevoNumeroFactura(); // Podrías generar un nuevo número automáticamente
                txtCantidad.Text = string.Empty;
                txtPrecio.Text = string.Empty;
                txtTotal.Text = string.Empty;
                searchLab.EditingValue= null ;
                searchProducto.EditingValue = null;
                searchProveedor.EditingValue = null;
            }
            catch (Exception ex)
            {
                unitOfWork1.RollbackTransaction(); // Revertir los cambios en caso de error
                MessageBox.Show("Error: " + ex.Message, "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Reinicia la interfaz
            factura_Compra = null;
            detallesCompra.Clear(); // Limpia la lista de detalles
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
         FInventario fInventario = new FInventario();
            fInventario.ShowDialog();

            cmbProducto.Refresh();
        }
    }
}
