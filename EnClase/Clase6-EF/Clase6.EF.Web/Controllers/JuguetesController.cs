using Clase6.EF.Entidades;
using Clase6.EF.Logica;
using Clase6.EF.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clase6.EF.Web.Controllers
{
    public class JuguetesController : Controller
    {
        private readonly IJuguetesLogica juguetesLogica;
        private readonly ITematicaLogica tematicaLogica;
        private readonly ISucursalLogica sucursalLogica;

        public JuguetesController(IJuguetesLogica juguetesLogica, ITematicaLogica tematicaLogica, ISucursalLogica sucursalLogica)
        {
            this.juguetesLogica = juguetesLogica;
            this.tematicaLogica = tematicaLogica;
            this.sucursalLogica = sucursalLogica;
        }

        public IActionResult Index()
        {
            var juguetes = juguetesLogica.Obtener();
            var juguetesVM = juguetes.Select(j => JugueteViewModel.FromEntity(j)).ToList();

            return View(juguetesVM);
        }

        //Agregar
        public IActionResult Agregar()
        {
            var jugueteVM = new JugueteViewModel();
            jugueteVM.Tematicas = tematicaLogica.Obtener();
            jugueteVM.SucursalesTodas = SucursalViewModel.FromEntity(sucursalLogica.Obtener());

            return View(jugueteVM);
        }

        [HttpPost]
        public IActionResult Agregar(JugueteViewModel jugueteVM)
        {
            if (!ModelState.IsValid)
            {
                jugueteVM.SucursalesTodas = SucursalViewModel.FromEntity(sucursalLogica.Obtener());
                jugueteVM.Tematicas = tematicaLogica.Obtener();
                return View(jugueteVM);
            }
            var juguete = jugueteVM.ToEntity();
            juguete.Sucursales = jugueteVM.SucursalesIds.Select(id => sucursalLogica.ObtenerPorId(id)).Where(s => s != null).ToList()!;
            juguetesLogica.Agregar(juguete);

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            juguetesLogica.Eliminar(id);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var juguete = juguetesLogica.ObtenerPorId(id);

            if (juguete == null)
                return NotFound();

            var jugueteVM = JugueteViewModel.FromEntity(juguete, true);
            jugueteVM.Tematicas = tematicaLogica.Obtener();
            jugueteVM.SucursalesTodas = SucursalViewModel.FromEntity(sucursalLogica.Obtener());
            jugueteVM.SucursalesIds = juguete.Sucursales.Select(s => s.Id).ToList();

            return View(jugueteVM);
        }

        [HttpPost]
        public IActionResult Editar(JugueteViewModel jugueteVM)
        {
            if (!ModelState.IsValid)
            {
                jugueteVM.SucursalesTodas = SucursalViewModel.FromEntity(sucursalLogica.Obtener());
                jugueteVM.Tematicas = tematicaLogica.Obtener();
                return View(jugueteVM);
            }

            var juguete = juguetesLogica.ObtenerPorId(jugueteVM.Id);
            if (juguete == null)
                return NotFound();

            juguete.Nombre = jugueteVM.Nombre;
            juguete.Precio = jugueteVM.Precio;
            juguete.EdadRecomendada = jugueteVM.EdadRecomendada;
            juguete.TematicaId = jugueteVM.TematicaId;
            juguete.Sucursales = jugueteVM.SucursalesIds.Select(id => sucursalLogica.ObtenerPorId(id)).Where(s => s != null).ToList()!;

            juguetesLogica.Actualizar(juguete);
            return RedirectToAction("Index");
        }
    }
}
