using ClaseMVC.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClaseMVC.Logica
{
    public interface IPreciosServicios
    {
        List<Comercio> ObtenerComercios();
        void AgregarProductoAComercio(string nombre, Producto producto);
        void AgregarComercio(Comercio comercio, Dictionary<string, double> productosConPrecio);
        Dictionary<string, double> ObtenerPreciosPorProducto(string nombreProducto);
        void ActualizarPreciosProducto(string nombreProducto, Dictionary<string, string> preciosPorComercio);
        void EliminarProducto(string nombreProducto);
    }
    public class PreciosServicios : IPreciosServicios
    {
        private static readonly List<Comercio> comercios = new List<Comercio>();
        static PreciosServicios()
        {
            comercios.Add(new Comercio
            {
                Nombre = "Supermercado Coto",
                Productos = new List<Producto>
                {
                    new Producto { Nombre = "Leche Entera 1L", Precio = 1250.00 },
                    new Producto { Nombre = "Aceite de Girasol 1.5L", Precio = 2100.00 },
                    new Producto { Nombre = "Café Molido 500g", Precio = 4800.00 },
                    new Producto { Nombre = "Pan Lactal Blanco 500g", Precio = 1950.00 },
                    new Producto { Nombre = "Arroz Largo Fino 1kg", Precio = 1300.00 }
                }
            });

            comercios.Add(new Comercio
            {
                Nombre = "Supermercado Carrefour",
                Productos = new List<Producto>
                {
                    new Producto { Nombre = "Leche Entera 1L", Precio = 1180.00 },
                    new Producto { Nombre = "Aceite de Girasol 1.5L", Precio = 2300.00 },
                    new Producto { Nombre = "Café Molido 500g", Precio = 4500.00 },
                    new Producto { Nombre = "Pan Lactal Blanco 500g", Precio = 2100.00 },
                    new Producto { Nombre = "Arroz Largo Fino 1kg", Precio = 1250.00 }
                }
            });
        }
        public List<Comercio> ObtenerComercios()
        {
            return comercios;
        }

        public void AgregarProductoAComercio(string nombre, Producto producto)
        {
            var comercio = comercios.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (comercio != null)
            {
                comercio.Productos.Add(producto);
            }
        }
        public void AgregarComercio(Comercio nuevoComercio, Dictionary<string, double> productosConPrecio)
        {
            if (productosConPrecio != null && productosConPrecio.Any())
            {
                nuevoComercio.Productos = productosConPrecio
                    .Select(kvp => new Producto
                    {
                        Nombre = kvp.Key,
                        Precio = kvp.Value
                    })
                    .ToList();
            }

            comercios.Add(nuevoComercio);
        }
        public Dictionary<string, double> ObtenerPreciosPorProducto(string nombreProducto)
        {
            var precios = new Dictionary<string, double>();

            foreach (var comercio in comercios)
            {
                var producto = comercio.Productos.FirstOrDefault(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
                if (producto != null)
                {
                    precios[comercio.Nombre] = producto.Precio;
                }
            }

            return precios;
        }

        public void ActualizarPreciosProducto(string nombreProducto, Dictionary<string, string> preciosPorComercio)
        {
            if (preciosPorComercio == null) return;

            foreach (var item in preciosPorComercio)
            {
                var nombreComercio = item.Key;
                var precioString = item.Value;

                // Convertimos asegurando punto decimal o reemplazando comas si el usuario tipeó una
                if (double.TryParse(precioString.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double nuevoPrecio))
                {
                    var comercio = comercios.FirstOrDefault(c => c.Nombre.Equals(nombreComercio, StringComparison.OrdinalIgnoreCase));
                    if (comercio != null)
                    {
                        var producto = comercio.Productos.FirstOrDefault(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
                        if (producto != null)
                        {
                            producto.Precio = nuevoPrecio;
                        }
                    }
                }
            }
        }

        public void EliminarProducto(string nombreProducto)
        {
            if (string.IsNullOrWhiteSpace(nombreProducto)) return;

            foreach (var comercio in comercios)
            {
                // Remueve todas las instancias que coincidan con el nombre
                comercio.Productos.RemoveAll(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
