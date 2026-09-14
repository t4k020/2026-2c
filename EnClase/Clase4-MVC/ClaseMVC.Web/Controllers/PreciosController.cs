using ClaseMVC.Entidades;
using ClaseMVC.Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaseMVC.Web.Controllers
{
    public class PreciosController : Controller
    {
        private readonly IPreciosServicios _preciosServicios;
        public PreciosController(IPreciosServicios preciosServicios)
        {
            _preciosServicios = preciosServicios;
        }
        // GET: HomeController1
        public ActionResult Index()
        {
            var comercios = _preciosServicios.ObtenerComercios();
            return View(comercios);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public IActionResult Crear()
        {
            var comercios = _preciosServicios.ObtenerComercios();
            ViewBag.Comercios = comercios;
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ClaseMVC.Entidades.Producto producto, string nombreComercio)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(nombreComercio))
            {
                // Guardar el producto asociándolo al comercio correspondiente
                _preciosServicios.AgregarProductoAComercio(nombreComercio, producto);

                return RedirectToAction(nameof(Index));
            }

            // Si falla la validación, recargamos la lista de comercios y devolvemos la vista
            ViewBag.Comercios = _preciosServicios.ObtenerComercios();
            return View(producto);
        }
        [HttpGet]
        public IActionResult CrearComercio()
        {
            // Obtenemos la lista única de productos existentes para mostrarlos en el formulario
            var productosDisponibles = _preciosServicios.ObtenerComercios()
                .SelectMany(c => c.Productos)
                .Select(p => p.Nombre)
                .Distinct()
                .ToList();

            ViewBag.ProductosDisponibles = productosDisponibles;
            return View();
        }

        // POST: Precios/CrearComercio
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearComercio(Comercio comercio, List<string> productosSeleccionados, Dictionary<string, double> precios)
        {
            if (!string.IsNullOrWhiteSpace(comercio.Nombre))
            {
                // Filtramos solo los precios de los productos seleccionados
                var productosAInsertar = productosSeleccionados != null
                    ? productosSeleccionados
                        .Where(p => precios.ContainsKey(p))
                        .ToDictionary(p => p, p => precios[p])
                    : new Dictionary<string, double>();

                _preciosServicios.AgregarComercio(comercio, productosAInsertar);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.ProductosDisponibles = _preciosServicios.ObtenerComercios()
                .SelectMany(c => c.Productos)
                .Select(p => p.Nombre)
                .Distinct()
                .ToList();

            return View(comercio);
        }

        [HttpGet]
        public IActionResult Editar(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return RedirectToAction(nameof(Index));
            }

            var preciosPorComercio = _preciosServicios.ObtenerPreciosPorProducto(nombre);

            if (!preciosPorComercio.Any())
            {
                return NotFound();
            }

            ViewBag.NombreProducto = nombre;
            return View(preciosPorComercio);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(string nombreProducto, Dictionary<string, string> preciosPorComercio)
        {
            if (!string.IsNullOrEmpty(nombreProducto) && preciosPorComercio != null)
            {
                _preciosServicios.ActualizarPreciosProducto(nombreProducto, preciosPorComercio);
                return RedirectToAction(nameof(Index));
            }

            // En caso de reintentar, obtenemos los valores numéricos de nuevo
            var modelos = _preciosServicios.ObtenerPreciosPorProducto(nombreProducto);
            ViewBag.NombreProducto = nombreProducto;
            return View(modelos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(string nombreProducto)
        {
            if (!string.IsNullOrEmpty(nombreProducto))
            {
                _preciosServicios.EliminarProducto(nombreProducto);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
