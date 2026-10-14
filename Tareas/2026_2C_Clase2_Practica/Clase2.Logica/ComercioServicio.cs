using Comparador.Entidad;
using System.Net.Http.Json;

namespace Clase2.Logica;

public interface IComercioServicio
    {
        Task<List<Comercio>> ObtenerComercios();
    }

public class ComercioServicio : IComercioServicio 
{

    public async Task<List<Comercio>> ObtenerComercios()
    {
        using var client = new HttpClient();
        var result = await client.GetFromJsonAsync<List<Comercio>>("https://localhost:7148/api/Comercio");
        return result ?? new List<Comercio>();

    }
}
