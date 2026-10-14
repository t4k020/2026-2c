using Clase2.Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Comparador.Entidad;
using Entidad = Comparador.Entidad;
using System.Threading.Tasks;

namespace Clase2.Web.Controllers
{
    public class ComparadorController : Controller
    {
        private readonly IComercioServicio _comerciosServicio;
        private readonly IProductoServicio _productosServicio;
        private readonly IComparadorServicio _comparadorServicio;

        public ComparadorController(IComercioServicio comercioServicio, IProductoServicio productoServicio, IComparadorServicio comparadorServicio)
        {
            _comerciosServicio = comercioServicio;
            _productosServicio = productoServicio;
            _comparadorServicio = comparadorServicio;
        }

        // GET: ComparadorController
        public async Task<IActionResult> Index()
        {
            var comercios = await _comerciosServicio.ObtenerComercios();
            var productos = await _productosServicio.ObtenerProductos();
            var comparaciones = await _comparadorServicio.ObtenerComparaciones();

            return View(new ComparadorViewModel
            {
                Comercios = comercios,
                Productos = productos,
                Comparaciones = comparaciones
            });
        }

        [HttpPost]
        public async Task<IActionResult> AgregarComparacion([FromBody] Entidad.Comparador comparacion)
        {
            await _comparadorServicio.AgregarComparacion(comparacion);
            return RedirectToAction("Index");
        }

    }
}
