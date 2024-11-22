using DevExpress.Xpo;
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
            txtUser.Select();
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            xpUsuario.Reload();
            string login = txtUser.Text.Trim();
            string clave = txtPwd.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Por favor, ingrese su nombre de usuario y contraseña.");
                return;
            }
            

            Usuario us = null;
            foreach (Usuario usuario in xpUsuario)
            {
                if (usuario.Usuario1 == login)
                {
                    us = usuario;
                    break;
                }
            }
            string passHashed = us.Pass;

            bool verificado = BcryptPasswordHasher.VerifyPassword(clave, passHashed);

            if (us != null && verificado)
            {
                // Crear instancia del formulario Dashboard y mostrarlo
                Dashboard frm = new Dashboard(us, us.Id_Rol);
                frm.FormClosed += (s, args) =>
                {
                    // Al cerrar el Dashboard, instanciar de nuevo el formulario de login
                    frmLogin newLoginForm = new frmLogin();
                    newLoginForm.Show();
                };

                this.Hide(); // Oculta el formulario de login
                frm.ShowDialog(); // Muestra el Dashboard
                
            }
            else
            {
                MessageBox.Show("Datos incorrectos.");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            xpUsuario.Reload();
        }
    }
}