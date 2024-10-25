using DevExpress.XtraCharts;
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
    public partial class Graficos : Form
    {
        public Graficos()
        {
            InitializeComponent();
            this.FormClosing += Graficos_FormClosing; // Suscribir al evento
        }

        private void Graficos_Load(object sender, EventArgs e)
        {

            // Cargar y mostrar los gráficos
            CargarGraficoVendedores();
            CargarGraficoProductos();
        }

        // Método para cargar y mostrar el gráfico de ventas por vendedor
        public void CargarGraficoVendedores()
        {
            // Ejecutar el procedimiento almacenado directamente desde el UnitOfWork
            string queryVendedores = "CALL VendedoresYVentasTotalesUltimos7Dias()";
            var resultVendedores = unitOfWork1.ExecuteQuery(queryVendedores);

            // Limpiar series existentes
            chartControlVendedores.Series.Clear();

            // Crear una nueva serie para las ventas totales
            Series seriesVendedores = new Series("Ventas Totales", ViewType.Bar);

            // Recorrer las filas de resultados
            foreach (var row in resultVendedores.ResultSet[0].Rows)
            {
                string vendedor = row.Values[0].ToString(); // Accede a la columna "Vendedor"
                decimal totalVentas = Convert.ToDecimal(row.Values[1]); // Accede a la columna "Total_Ventas"
                seriesVendedores.Points.Add(new SeriesPoint(vendedor, totalVentas));
            }

            // Añadir la serie al gráfico
            chartControlVendedores.Series.Add(seriesVendedores);

            // Opciones de visualización
            chartControlVendedores.Dock = DockStyle.Bottom;
            chartControlVendedores.Height = 300;

            // Actualizar el gráfico
            chartControlVendedores.Refresh();
        }


        public void CargarGraficoProductos()
        {
            // Ejecutar el procedimiento almacenado directamente desde el UnitOfWork
            string queryProductos = "CALL ProductosVendidosUltimos7Dias()";
            var resultProductos = unitOfWork1.ExecuteQuery(queryProductos);

            // Limpiar series existentes
            chartControlProductos.Series.Clear();

            // Crear un diccionario para acumular las cantidades de productos
            Dictionary<string, decimal> productosVendidos = new Dictionary<string, decimal>();

            // Recorrer las filas de resultados
            foreach (var row in resultProductos.ResultSet[0].Rows)
            {
                string producto = row.Values[0].ToString(); // Accede a la columna "Producto"
                decimal cantidadVendida = Convert.ToDecimal(row.Values[1]); // Accede a la columna "Cantidad_Vendida"

                // Sumar las cantidades si el producto ya existe en el diccionario
                if (productosVendidos.ContainsKey(producto))
                {
                    productosVendidos[producto] += cantidadVendida; // Sumar la cantidad vendida
                }
                else
                {
                    productosVendidos[producto] = cantidadVendida; // Añadir nuevo producto
                }
            }

            // Crear una nueva serie para los productos vendidos
            Series seriesProductos = new Series("Productos Vendidos", ViewType.Pie);

            // Agregar los productos al gráfico sumando cantidades
            foreach (var producto in productosVendidos)
            {
                seriesProductos.Points.Add(new SeriesPoint(producto.Key, producto.Value));
            }

            // Habilitar etiquetas para la serie
            seriesProductos.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True; // Mostrar etiquetas
            seriesProductos.Label.TextPattern = "{A}: {V}"; // Establecer el patrón de texto de la etiqueta

            // Añadir la serie al gráfico
            chartControlProductos.Series.Add(seriesProductos);

            // Opciones de visualización
            chartControlProductos.Dock = DockStyle.Top;
            chartControlProductos.Height = 300;

            // Actualizar el gráfico
            chartControlProductos.Refresh();
        }

        private void Graficos_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // Cancela el cierre del formulario
        }
    }
}
