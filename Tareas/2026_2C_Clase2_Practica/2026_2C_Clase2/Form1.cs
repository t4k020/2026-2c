using Comparador.Entidad;
using Microsoft.VisualBasic;
using System.Globalization;

namespace _2026_2C_Clase2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cargarProductos();
            cargarComercios();
        }



        private async Task cargarProductos()
        {
            //cargar combo de productos
            //cboProducto.Items.Add("Freidora de Aire");
            //cboProducto.Items.Add("Aspiradora");
            using (var client = new HttpClient())
            {
                // Enviar la solicitud GET a la API
                var response = await client.GetAsync("https://localhost:7148/api/Producto");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(json,
                            new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    foreach (var producto in productos)
                    {
                        cboProducto.Items.Add(producto.nombre);
                    }
                }
                else
                {
                    MessageBox.Show($"Error al obtener productos de la API: {response.StatusCode}");
                }
            }


        }

        private async Task cargarComercios()
        {
            //List<ComboBox> combos = new List<ComboBox> { cboComercio1, cboComercio2 };
            //foreach (ComboBox c in combos)
            //{
            //cargar combo de comercios
            //    c.Items.Add("Mercado Libre");
            //    c.Items.Add("Garbarino");
            //    c.Items.Add("Fravega");
            //}
            using (var client = new HttpClient())
            {
                // Enviar la solicitud GET a la API
                var response = await client.GetAsync("https://localhost:7148/api/Comercio");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var comercios = System.Text.Json.JsonSerializer.Deserialize<List<Comercio>>(json,
                            new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    foreach (var comercio in comercios)
                    {
                        cboComercio1.Items.Add(comercio.nombre);
                        cboComercio2.Items.Add(comercio.nombre);
                    }
                }
                else
                {
                    MessageBox.Show($"Error al obtener comercios de la API: {response.StatusCode}");
                }
            }

        }

        private void btnCargarGrilla_Click(object sender, EventArgs e)
        {
            ////dgvComparacion.Rows.Clear();
            //dgvComparacion.Rows.Add(
            //    dtpFecha.Value.ToString("dd/MM/yyyy"),
            //    cboProducto.SelectedItem.ToString(),
            //    cboComercio1.SelectedItem.ToString(),
            //    txtPrecio1.Text,
            //    cboComercio2.SelectedItem.ToString(),
            //    txtPrecio2.Text
            //    );

            // Verificar que los precios no estén vacíos
            if (string.IsNullOrWhiteSpace(txtPrecio1.Text) || string.IsNullOrWhiteSpace(txtPrecio2.Text))
            {
                MessageBox.Show("Los campos de precio no pueden estar vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aceptar tanto coma como punto como separador decimal
            var p1Text = txtPrecio1.Text.Trim().Replace(',', '.');
            var p2Text = txtPrecio2.Text.Trim().Replace(',', '.');

            if (!decimal.TryParse(p1Text, NumberStyles.Number, CultureInfo.InvariantCulture, out _) ||
                !decimal.TryParse(p2Text, NumberStyles.Number, CultureInfo.InvariantCulture, out _))
            {
                MessageBox.Show("Solo se pueden ingresar números en los campos de precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EnviarComparacionesAAPI();

            limpiarCampos();

        }

        private void limpiarCampos()
        {
            cboProducto.SelectedIndex = -1;
            cboComercio1.SelectedIndex = -1;
            cboComercio2.SelectedIndex = -1;
            txtPrecio1.Clear();
            txtPrecio2.Clear();

        }

        private async Task EnviarComparacionesAAPI()
        {
            // Crear un objeto con los datos a enviar
            var comparaciones = new
            {
                Fecha = dtpFecha.Value.ToString("yyyy-MM-dd"),
                Producto = cboProducto.SelectedItem.ToString(),
                Comercio1 = cboComercio1.SelectedItem.ToString(),
                Precio1 = txtPrecio1.Text,
                Comercio2 = cboComercio2.SelectedItem.ToString(),
                Precio2 = txtPrecio2.Text
            };
            // Serializar el objeto a JSON
            var json = System.Text.Json.JsonSerializer.Serialize(comparaciones);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                // Enviar la solicitud POST a la API
                var response = await client.PostAsync("https://localhost:7148/api/Comparador", content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("comparaciones enviadas correctamente a la API.");
                }
                else
                {
                    MessageBox.Show($"Error al enviar comparaciones a la API: {response.StatusCode}");
                }
            }

        }

        private async Task ObtenerComparacionesDeAPI()
        {
            using (var client = new HttpClient())
            {
                // Enviar la solicitud GET a la API
                var response = await client.GetAsync("https://localhost:7148/api/Comparador");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var comparaciones = System.Text.Json.JsonSerializer.Deserialize<List<Comparador.Entidad.Comparador>>(json,
                            new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    dgvComparacion.Rows.Clear();
                    foreach (var comparacion in comparaciones)
                    {
                        dgvComparacion.Rows.Add(
                            comparacion.fecha,
                            comparacion.producto,
                            comparacion.comercio1,
                            comparacion.precio1,
                            comparacion.comercio2,
                            comparacion.precio2
                        );
                    }
                }
                else
                {
                    MessageBox.Show($"Error al obtener comparaciones de la API: {response.StatusCode}");
                }
            }
        }

        private void btnRefrescarGrilla_Click(object sender, EventArgs e)
        {
            ObtenerComparacionesDeAPI();
        }

        private void cboComercio2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboComercio1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
