using Clase6.EF.Logica;
using Clase6.EF.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clase6.EF.Web.Controllers;

public class TematicaController : Controller
{
    private readonly ITematicaLogica tematicaLogica;

    public TematicaController(ITematicaLogica tematicaLogica)
    {
        this.tematicaLogica = tematicaLogica;
    }

    public IActionResult Index()
    {
        var tematicas = tematicaLogica.Obtener();
        return View(TematicaViewModel.FromEntity(tematicas));
    }

    [HttpGet]
    public IActionResult Agregar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Agregar(TematicaViewModel tematica)
    {
        if (!ModelState.IsValid)
            return View(tematica);

        tematicaLogica.Agregar(tematica.ToEntity());

        return RedirectToAction("Index");
    }
}
