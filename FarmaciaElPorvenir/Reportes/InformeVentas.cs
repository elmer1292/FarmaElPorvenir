using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using FarmaciaElPorvenir.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaciaElPorvenir.Reportes
{
    public partial class InformeVentas : XtraForm
    {
        public InformeVentas()
        {
            InitializeComponent();

        }
        void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Print") gridControl.ShowRibbonPrintPreview();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            DateTime fechaInicial = deFechaInicial.DateTime;
            DateTime fechaFinal = deFechaFinal.DateTime;

            // Verifica que la fecha inicial no sea mayor o igual a la fecha actual
            if (fechaInicial >= fechaActual)
            {
                MessageBox.Show("La fecha inicial no debe ser mayor ni igual a la fecha actual", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // Verifica que la fecha final no sea menor que la fecha inicial
            else if (fechaFinal < fechaInicial)
            {
                MessageBox.Show("La fecha final no debe ser menor que la fecha inicial", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // Obtiene las facturas de compra entre las fechas inicial y final usando DevExpress XPO
                var facturasFiltradas = new XPCollection<Factura_venta>(unitOfWork1)
                {
                    Criteria = CriteriaOperator.Parse("Fecha >= ? AND Fecha <= ?", fechaInicial, fechaFinal)
                };

                // Asigna el resultado filtrado al DataSource del GridView
                gridControl.DataSource = facturasFiltradas;

                // Refresca el GridView para mostrar los resultados
                gridControl.Refresh();
            }
        }
    }
}
