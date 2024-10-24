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
        }

        private void GraficoVentaSemana_Click(object sender, EventArgs e)
        {
            // Cargar datos de la base de datos
            var productos = LoadProductsFromDatabase();
            var vendedores = LoadVendorsFromDatabase();

            // Configurar gráfico de productos más vendidos
            GraficoVentaSemana.Series.Clear();
            Series series = new Series("Productos Vendidos", ViewType.Bar);
            foreach (var producto in productos)
            {
                series.Points.Add(new SeriesPoint(producto.Key, producto.Value));
            }
            GraficoVentaSemana.Series.Add(series);

            // Configurar gráfico de vendedor más vendido
            GraficoVendedorSemana.Series.Clear();
            Series series2 = new Series("Ventas por Vendedor", ViewType.Pie);
            foreach (var vendedor in vendedores)
            {
                series2.Points.Add(new SeriesPoint(vendedor.Key, vendedor.Value));
            }
            GraficoVendedorSemana.Series.Add(series2);
        }

        private Dictionary<string, int> LoadProductsFromDatabase()
        {
            var productos = new Dictionary<string, int>();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string query = "SELECT NombreProducto, SUM(CantidadVendida) AS TotalVendida FROM Ventas WHERE Fecha >= DATEADD(week, -1, GETDATE()) GROUP BY NombreProducto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader["NombreProducto"].ToString();
                        int cantidadVendida = Convert.ToInt32(reader["TotalVendida"]);
                        productos[nombre] = cantidadVendida;
                    }
                }
            }

            return productos;
        }

        private Dictionary<string, int> LoadVendorsFromDatabase()
        {
            var vendedores = new Dictionary<string, int>();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string query = "SELECT NombreVendedor, SUM(CantidadVendida) AS TotalVendida FROM Ventas WHERE Fecha >= DATEADD(week, -1, GETDATE()) GROUP BY NombreVendedor";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader["NombreVendedor"].ToString();
                        int cantidadVendida = Convert.ToInt32(reader["TotalVendida"]);
                        vendedores[nombre] = cantidadVendida;
                    }
                }
            }

            return vendedores;
        }
    }
}
