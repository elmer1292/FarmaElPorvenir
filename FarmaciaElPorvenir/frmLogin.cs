using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            txtUser.Clear();
            txtPwd.Clear();
            txtUser.Focus();
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            // Comprobar si la colección tiene elementos
            if (xpUsuario.Count == 0)
            {
                MessageBox.Show("No se encontraron usuarios registrados.");
                return;
            }

            string login = txtUser.Text.Trim();
            string clave = txtPwd.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor, ingrese su nombre de usuario y contraseña.");
                return;
            }

            Usuario us;
            foreach (Usuario item in xpUsuario)
            {
                us = item;
                if (us.Usuario1 == login && BcryptPasswordHasher.VerifyPassword(clave, us.Pass))
                {
                    // Crear instancia del formulario Dashboard y mostrarlo
                    Dashboard frm = new Dashboard(us, us.Id_Rol);
                    frm.FormClosed += (s, args) => this.Show(); // Muestra el login cuando se cierra el dashboard

                    // Recargar los datos de la colección de usuarios antes de proceder
                    xpUsuario.Reload();

                    // Ocultar el formulario de login
                    this.Hide();

                    // Mostrar el Dashboard
                    frm.Show();
                    return;
                }
            }
            MessageBox.Show("Datos incorrectos.");
        }
    }
}