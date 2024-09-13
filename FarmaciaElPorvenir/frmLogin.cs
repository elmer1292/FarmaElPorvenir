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
            foreach (Usuario u in xpCollectionUsuario)
            {
                if (u.Usuario1.Equals(txtUser.Text) &&
                    u.Pass.Equals(txtPwd.Text))
                {
                    Dashboard fp = new Dashboard(u,u.Id_Rol);
                    this.Visible = false;
                    fp.ShowDialog();
                    this.Visible = true;
                    txtPwd.Clear();
                    txtUser.Clear();
                    usr = true;
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