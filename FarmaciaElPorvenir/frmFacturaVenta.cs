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
    public partial class frmFacturaVenta : Form
    {
        public frmFacturaVenta()
        {
            InitializeComponent();
        }

        private void frmFacturaVenta_Load(object sender, EventArgs e)
        {
            deFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
