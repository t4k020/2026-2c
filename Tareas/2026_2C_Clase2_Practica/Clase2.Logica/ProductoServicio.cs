using Comparador.Entidad;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Net.Http.Json;

namespace Clase2.Logica;

public interface IProductoServicio
{
    Task<List<Producto>> ObtenerProductos();
}

public class ProductoServicio : IProductoServicio
{
    public async Task<List<Producto>> ObtenerProductos()
    {
        using var client = new HttpClient();
        
        var result = await client.GetFromJsonAsync<List<Producto>>("https://localhost:7148/api/Producto");
        return result ?? new List<Producto>();
    }
}
