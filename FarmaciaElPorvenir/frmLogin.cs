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
                    this.Hide();
                    fp.ShowDialog();
                    this.Close();
                    txtUser.Clear();
                    txtPwd.Clear();
                    usr = true;
                }
            }

            if (!usr)
            {
                MessageBox.Show("Usuario o contraseña incorrecta.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }
}