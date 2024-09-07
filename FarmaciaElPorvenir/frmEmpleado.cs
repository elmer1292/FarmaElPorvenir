using DevExpress.Utils.DirectXPaint;
using FarmaciaElPorvenir.el_porvenirdb;
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
    public partial class frmEmpleado: Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }
        private void ActualizarEstadoBotones(bool nuevo, bool guardar, bool eliminar, bool cancelar, bool actualizar, bool camposHabilitados)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnEliminar.Enabled = eliminar;
            btnCancelar.Enabled = cancelar;
            btnActualizar.Enabled = actualizar;

            // Habilitar o deshabilitar los campos
            txtNombre.Enabled = camposHabilitados;
            txtCargo.Enabled = camposHabilitados;
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtCargo.Clear();
            txtNombre.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            ActualizarEstadoBotones(false, true, true, true, false, true);
            Limpiar();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            ActualizarEstadoBotones(true, false, false, false, false, false);
        }

        private void gridViewClientes_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle>=0)
            {
                ActualizarEstadoBotones(false, false, true, true, true, true);
                string nombre = gridViewEmpleados.GetRowCellValue(e.RowHandle, "Nombre_Completo").ToString();
                string cargo = gridViewEmpleados.GetRowCellValue(e.RowHandle, "Cargo").ToString();
                txtNombre.Text = nombre;
                txtCargo.Text = cargo;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Empleado c = (Empleado)gridViewEmpleados.GetFocusedRow();
            if (c != null)
            {
                DialogResult r = MessageBox.Show("¿Desea Eliminar Registro?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    unitOfWork.Delete(c);
                    unitOfWork.CommitChanges();
                    xpCollection.Reload();
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
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCargo.Text))
            {
                MessageBox.Show("Campos Requeridos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                // Crear o buscar el rol en la base de datos
                Empleado c = new Empleado(unitOfWork);


                // Asignar los valores a las propiedades del rol
                c.Nombre_Completo = txtNombre.Text;
                c.Cargo = txtCargo.Text;

                // Guardar los cambios
                c.Save();
                unitOfWork.CommitChanges();

                // Limpiar los controles del formulario
                Limpiar();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Guardado Exitoso", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la colección de roles para reflejar los cambios
                xpCollection.Reload();
                ActualizarEstadoBotones(true, false, false, false, false, false);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ActualizarEstadoBotones(true, false, false, false, false, false);
            Limpiar();
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCargo.Text))
            {
                MessageBox.Show("Campos Requeridos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Verificar si se ha seleccionado una fila en el gridViewRoles
            int id = (int)gridViewEmpleados.GetFocusedRowCellValue("Id");
            if (id <= 0)
            {
                MessageBox.Show("Por favor, seleccione un rol para actualizar.", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Buscar el rol en la base de datos
                Empleado c = unitOfWork.GetObjectByKey<Empleado>(id);
                if (c == null)
                {
                    MessageBox.Show("Rol no encontrado", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Asignar los valores a las propiedades del rol
                c.Nombre_Completo = txtNombre.Text;
                c.Cargo = txtCargo.Text;

                // Guardar los cambios
                c.Save();
                unitOfWork.CommitChanges();

                // Limpiar los controles del formulario
                Limpiar();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Actualización Exitosa", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la colección de roles para reflejar los cambios
                xpCollection.Reload();
                ActualizarEstadoBotones(true, false, false, false, false, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
