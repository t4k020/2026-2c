using Clase6.EF.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Clase6.EF.Logica
{
    public interface IGutendexLogica
    {
        Task<LibroDescargado?> BuscarAsync(string titulo);
    }

    public class GutendexLogica : IGutendexLogica
    {
        private readonly HttpClient _http;

        public GutendexLogica(HttpClient http)
        {
            _http = http;
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("ClaseEntityFramework/1.0");
        }

        public async Task<LibroDescargado?> BuscarAsync(string titulo)
        {
            try
            {
                var url = $"https://gutendex.com/books?search={Uri.EscapeDataString(titulo)}";
                var respuesta = await _http.GetFromJsonAsync<GutendexRespuesta>(url);

                var resultado = respuesta?.Results.FirstOrDefault();
                if (resultado == null) return null;

                var urlTexto = $"https://www.gutenberg.org/cache/epub/{resultado.Id}/pg{resultado.Id}.txt";
                var texto = await _http.GetStringAsync(urlTexto);

                return new LibroDescargado(
                    resultado.Title,
                    resultado.Authors.FirstOrDefault()?.Name ?? "Desconocido",
                    texto,
                    resultado.Bookshelves);
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
        


    }
}
