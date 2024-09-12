using DevExpress.XtraEditors;
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
    public partial class loggin : Form
    {
        public loggin()
        {
            InitializeComponent();
        }

        private void loggin_Load(object sender, EventArgs e)
        {
            
            string user = txtUsser.Text;
            string password = txtPassw.Text;

            
            if (user == "root" && password == "root123")
            {
                MessageBox.Show("Inicio de sesión exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accder_Click(object sender, EventArgs e)
        {

        }
    }
}
