using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparador.Entidad;

namespace Comparador.ServicioLocal;

public interface IProductosServicio
{
    List <Producto> ObtenerProductos();
}

public class ProductosServicio : IProductosServicio
{
    private List<Producto> _productos;
    public ProductosServicio()
    {
        _productos = new List<Producto>();
        _productos.Add(new Producto { Id = 1, nombre = "Heladera" });
        _productos.Add(new Producto { Id = 2, nombre = "Microondas" });
        _productos.Add(new Producto { Id = 3, nombre = "Cocina" });
        _productos.Add(new Producto { Id = 4, nombre = "Batidora" });
        _productos.Add(new Producto { Id = 5, nombre = "Horno Eléctrico" });
    }
    public List<Producto> ObtenerProductos()
    {
        return _productos;
    }
}