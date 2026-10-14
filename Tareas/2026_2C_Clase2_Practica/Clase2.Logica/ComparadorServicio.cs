using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Clase2.Logica;
public interface IComparadorServicio
{
    Task AgregarComparacion(Comparador.Entidad.Comparador comparacion);
    Task<List<Comparador.Entidad.Comparador>> ObtenerComparaciones();
}

public class ComparadorServicio : IComparadorServicio
{
    public async Task AgregarComparacion(Comparador.Entidad.Comparador comparacion)
    {
        using var client = new HttpClient();
        await client.PostAsJsonAsync("https://localhost:7148/api/Comparador", comparacion);
    }    
    public async Task<List<Comparador.Entidad.Comparador>> ObtenerComparaciones()
    {
        using var client = new HttpClient();
        var result = await client.GetFromJsonAsync<List<Comparador.Entidad.Comparador>>("https://localhost:7148/api/Comparador");
        return result ?? new List<Comparador.Entidad.Comparador>();
    }               
}
