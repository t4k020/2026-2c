using Clase6.EF.Logica;
using Clase6.EF.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clase6.EF.Web.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ILibroLogica _logica;

        public LibrosController(ILibroLogica logica)
        {
            _logica = logica;
        }

        public async Task<IActionResult> Index()
        {
            return View(await ArmarBusquedaAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Buscar(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                return View("Index", await ArmarBusquedaAsync(mensaje: "Ingresá un título."));

            var libro = await _logica.ObtenerLibroAsync(titulo);
            if (libro == null)
                return View("Index", await ArmarBusquedaAsync(titulo, $"No se encontró ningún libro para \"{titulo}\"."));

            return RedirectToAction(nameof(Leer), new { id = libro.Id, numero = 1 });
        }

        public async Task<IActionResult> Leer(int id, int numero = 1)
        {
            var pagina = await _logica.ObtenerPaginaAsync(id, numero);
            if (pagina == null) return NotFound();

            var vm = new LeerLibroViewModel
            {
                LibroId = pagina.LibroId,
                Titulo = pagina.Titulo,
                Numero = pagina.Numero,
                TotalPaginas = pagina.TotalPaginas,
                Contenido = pagina.Contenido
            };

            return View(vm);
        }

        private async Task<BuscarLibroViewModel> ArmarBusquedaAsync(string? titulo = null, string? mensaje = null)
        {
            var libros = await _logica.ListarLibrosAsync();

            return new BuscarLibroViewModel
            {
                Titulo = titulo,
                Mensaje = mensaje,
                Libros = libros.Select(l => new LibroViewModel
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    Tematicas = l.Tematicas.Select(t => t.Nombre).ToList()
                }).ToList()
            };
        }
    }
}
