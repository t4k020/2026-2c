using Clase6.EF.Entidades;
using Clase6.EF.Repositorios;
using System.Net.Http.Json;

namespace Clase6.EF.Logica
{
    public record PaginaLectura(int LibroId, string Titulo, int Numero, int TotalPaginas, string Contenido);
    public interface ILibroLogica
    {
        Task<List<Libro>> ListarLibrosAsync();
        Task<Libro?> ObtenerLibroAsync(string titulo);
        Task<PaginaLectura?> ObtenerPaginaAsync(int libroId, int numero);
    }

    public class LibroLogica : ILibroLogica
    {
        private readonly ILibroRepositorio _repositorio;
        private readonly IGutendexLogica _gutendex;
        private readonly IPaginasLogica _paginador;

        public LibroLogica(ILibroRepositorio repositorio, IGutendexLogica gutendex, IPaginasLogica paginador)
        {
            _repositorio = repositorio;
            _gutendex = gutendex;
            _paginador = paginador;
        }

        public async Task<Libro?> ObtenerLibroAsync(string titulo)
        {
            // 1. Si ya está en la base, se entrega directamente
            var existente = await _repositorio.BuscarPorTituloAsync(titulo);
            if (existente != null) return existente;

            // 2. Si no, se pide a la API
            var descargado = await _gutendex.BuscarAsync(titulo);
            if (descargado == null) return null;

            // 3. El título que devuelve Gutendex puede diferir del buscado: evitar duplicados
            existente = await _repositorio.BuscarPorTituloAsync(descargado.Titulo);
            if (existente != null) return existente;

            // 4. Se guarda y se entrega
            var textos = _paginador.Dividir(descargado.Texto);

            var libro = new Libro
            {
                Titulo = descargado.Titulo,
                Autor = descargado.Autor,
                Tematicas = await _repositorio.ObtenerOCrearTematicasAsync(descargado.Tematicas),
                Paginas = textos.Select((t, i) => new Pagina { Numero = i + 1, Contenido = t }).ToList()
            };

            await _repositorio.GuardarAsync(libro);
            return libro;
        }

        public async Task<PaginaLectura?> ObtenerPaginaAsync(int libroId, int numero)
        {
            var pagina = await _repositorio.ObtenerPaginaAsync(libroId, numero);
            if (pagina == null) return null;

            var total = await _repositorio.ContarPaginasAsync(libroId);

            return new PaginaLectura(libroId, pagina.Libro.Titulo, pagina.Numero, total, pagina.Contenido);
        }

        public async Task<List<Libro>> ListarLibrosAsync()
        {
            return await _repositorio.ListarAsync();
        }
    }
}
