using DevExpress.Xpo;
using FarmaciaElPorvenir.Database;
using FarmaciaElPorvenir.utilidades;
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
    public partial class formUsuario : Form
    {
        public formUsuario()
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
            txtUsuario.Enabled = camposHabilitados;
            txtPass.Enabled = camposHabilitados;
            cmbRol.Enabled = camposHabilitados;
            cmbEmpleado.Enabled = camposHabilitados;
        }
        private void Limpiar()
        {
            txtUsuario.Clear();
            txtPass.Clear();
            cmbRol.SelectedIndex = -1;
            cmbEmpleado.SelectedIndex =-1;
        }

        private void CargarCombos()
        {
            List<Empleado> lista = unitOfWork1.Query<Empleado>().ToList();            
            List<Rol> listaRol = unitOfWork1.Query<Rol>().ToList();

            cmbEmpleado.DataSource = lista;
            cmbEmpleado.DisplayMember = "Nombre_Completo";
            cmbEmpleado.ValueMember = "Id";
            cmbEmpleado.SelectedIndex = -1;

            cmbRol.DataSource = listaRol;
            cmbRol.DisplayMember = "Nombre_Rol";
            cmbRol.ValueMember = "Id";
            cmbRol.SelectedIndex = -1;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            ActualizarEstadoBotones(false, true, true, true, false, true);
            Limpiar();
        }
        private void formUsuario_Load(object sender, EventArgs e)
        {
            CargarCombos();
            ActualizarEstadoBotones(true, false, false, false, false, false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuario c = (Usuario)gridView1.GetFocusedRow();
            if (c != null)
            {
                DialogResult r = MessageBox.Show("¿Desea Eliminar Registro?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    unitOfWork1.Delete(c);
                    unitOfWork1.CommitChanges();
                    xpUsuario.Reload();
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
            if (string.IsNullOrEmpty(txtUsuario.Text)|| string.IsNullOrEmpty(txtPass.Text)||string.IsNullOrEmpty(cmbEmpleado.Text)|| string.IsNullOrEmpty(cmbRol.Text))
            {
                MessageBox.Show("Campos Requeridos", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                // Crear o buscar el rol en la base de datos
                Usuario usuario = new Usuario(unitOfWork1);


                // Asignar los valores a las propiedades del rol
                usuario.Usuario1 = txtUsuario.Text;
                usuario.Pass =BcryptPasswordHasher.HashPassword(txtPass.Text);
                usuario.Id_Empleado = (Empleado)cmbEmpleado.SelectedItem;
                usuario.Id_Rol = (Rol)cmbRol.SelectedItem;

                // Guardar los cambios
                usuario.Save();
                unitOfWork1.CommitChanges();

                // Limpiar los controles del formulario
                Limpiar();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Guardado Exitoso", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la colección de roles para reflejar los cambios
                xpUsuario.Reload();
                ActualizarEstadoBotones(true, false, false, false, false, false);

            }
            catch (Exception )
            {
                MessageBox.Show("Error registro duplicado" , "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(cmbEmpleado.Text) || string.IsNullOrEmpty(cmbRol.Text))
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
                Usuario usuario = unitOfWork1.GetObjectByKey<Usuario>(id);
                if (usuario == null)
                {
                    MessageBox.Show("Rol no encontrado", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Asignar los valores a las propiedades del rol
                usuario.Usuario1 = txtUsuario.Text;
                usuario.Pass = BcryptPasswordHasher.HashPassword(txtPass.Text);
                usuario.Id_Empleado = (Empleado)cmbEmpleado.SelectedItem;
                usuario.Id_Rol = (Rol)cmbRol.SelectedItem;
                // Guardar los cambios
                usuario.Save();
                unitOfWork1.CommitChanges();

                // Limpiar los controles del formulario
                Limpiar();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Actualización Exitosa", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la colección de roles para reflejar los cambios
                xpUsuario.Reload();
                ActualizarEstadoBotones(true, false, false, false, false, false);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle>=0)
            {
                ActualizarEstadoBotones(false, false, true, true, true, true);
                txtUsuario.Text = gridView1.GetRowCellValue(e.RowHandle,"Usuario1").ToString();
                txtPass.Text = gridView1.GetRowCellValue(e.RowHandle,"Pass").ToString();
                cmbEmpleado.Text = gridView1.GetRowCellValue(e.RowHandle,"Id_Empleado.Nombre_Completo").ToString();
                cmbRol.Text = gridView1.GetRowCellValue(e.RowHandle, "Id_Rol.Nombre_Rol").ToString();
            }
        }

        private void btnAgregarNuevoEmpleado_Click(object sender, EventArgs e)
        {
            frmEmpleado frm = new frmEmpleado();
            frm.ShowDialog();
            CargarCombos();
        }
    }
}
