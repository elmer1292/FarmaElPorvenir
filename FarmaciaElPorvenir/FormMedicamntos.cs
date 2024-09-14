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
    public partial class FormMedicamntos : Form
    {
        public FormMedicamntos()
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
            txtPrecio.Enabled = camposHabilitados;
            seCategoria.Enabled = camposHabilitados;
            seLab.Enabled = camposHabilitados;
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            seCategoria.Clear();
            seLab.Clear();  
            txtNombre.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            ActualizarEstadoBotones(false, true, true, true, false, true);
            Limpiar();
        }

        private void formMedicamentos_Load(object sender, EventArgs e)
        {
            ActualizarEstadoBotones(true, false, false, false, false, false);

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                ActualizarEstadoBotones(false, false, true, true, true, true);
                string nombre = gridView1.GetRowCellValue(e.RowHandle, "Medicamento").ToString();
                string precio = gridView1.GetRowCellValue(e.RowHandle,"Precio_Venta").ToString();
                string lab= gridView1.GetRowCellValue(e.RowHandle,"Laboratorio").ToString() ;
                string Cat = gridView1.GetRowCellValue(e.RowHandle, "Categoria").ToString();
                txtNombre.Text = nombre;
                txtPrecio.Text = precio;
                seLab.Text = lab;
                seCategoria.Text = Cat;

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Medicamento m = (Medicamento)gridView1.GetFocusedRow();
            //if (m != null)
            //{
            //    DialogResult r = MessageBox.Show("¿Desea Eliminar Registro?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    if (r == DialogResult.Yes)
            //    {
            //        unitOfWork1.Delete(m);
            //        unitOfWork1.CommitChanges();
            //        xpMedicamento.Reload();
            //        Limpiar();
            //        ActualizarEstadoBotones(true, false, false, false, false, false);

            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Seleccionar un Registro", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos obligatorios están vacíos
            if (string.IsNullOrEmpty(txtNombre.Text)|| string.IsNullOrEmpty(txtPrecio.Text)|| string.IsNullOrEmpty(seLab.Text)|| string.IsNullOrEmpty(seCategoria.Text))

            {
                MessageBox.Show("Campos Requeridos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                //// Crear o buscar el rol en la base de datos
                //Medicamento m = new Medicamento(unitOfWork1);


                // Asignar los valores a las propiedades del rol
                //m.Nombre = txtNombre.Text;
                //m.Precio = float.Parse(txtPrecio.Text);
                //m.Id_Laboratorio =(Laboratorio)searchLookUpEditLab.GetFocusedRow();
                //m.Id_Categoria =(Categoria)searchLookUpEditCat.GetFocusedRow();
                //// Guardar los cambios
                //m.Save();
                unitOfWork1.CommitChanges();

                // Limpiar los controles del formulario
                Limpiar();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Guardado Exitoso", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la colección de roles para reflejar los cambios
                xpMedicamento.Reload();
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
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(seLab.Text) || string.IsNullOrEmpty(seCategoria.Text))
            {
                MessageBox.Show("Campos Requeridos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Verificar si se ha seleccionado una fila en el gridViewRoles
            int id = (int)gridView1.GetFocusedRowCellValue("Id");
            if (id <= 0)
            {
                MessageBox.Show("Por favor, seleccione un rol para actualizar.", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Buscar el rol en la base de datos
                ////Medicamento m = unitOfWork1.GetObjectByKey<Medicamento>(id);
                //if (m == null)
                //{
                //    MessageBox.Show("Rol no encontrado", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                //// Asignar los valores a las propiedades del rol
                //m.Nombre = txtNombre.Text;
                //m.Precio = float.Parse(txtPrecio.Text);
                //m.Id_Laboratorio = (Laboratorio)searchLookUpEditLab.GetFocusedRow();
                //m.Id_Categoria = (Categoria)searchLookUpEditCat.GetFocusedRow();

                //// Guardar los cambios
                //m.Save();
                unitOfWork1.CommitChanges();

                // Limpiar los controles del formulario
                Limpiar();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Actualización Exitosa", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la colección de roles para reflejar los cambios
               xpMedicamento.Reload();
                ActualizarEstadoBotones(true, false, false, false, false, false);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
    }
}
