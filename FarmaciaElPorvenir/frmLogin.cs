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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
          
            bool usr = false;
            foreach (Usuario us in xpCollectionUsuario)
            {
                if (us.Usuario1.Equals(txtUser.Text) &&
                    us.Pass.Equals(txtPwd.Text))
                {
                    Dashboard fp = new Dashboard(us, us.Id_Rol);
                    this.Hide(); // Oculta el formulario sin cerrarlo
                    fp.ShowDialog(); // Muestra el Dashboard y espera a que se cierre
                    this.Show(); // Vuelve a mostrar el formulario si el Dashboard se cierra
                    txtUser.Clear();
                    txtPwd.Clear();
                    usr = true;
                    break; // Sale del ciclo para evitar que continúe verificando usuarios
                }
            }

            if (!usr)
            {
                MessageBox.Show("Usuario o contraseña incorrecta.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}