using ClaseMVC.Logica;
using ClaseMVC.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaseMVC.Web.Controllers;

public class FloresController : Controller
{
    private readonly IFloresServicios _floresServicios;
    public FloresController(IFloresServicios floresServicios)
    {
        _floresServicios = floresServicios;
    }

    // GET: FloresController
    public IActionResult Index()
    {
        var flores = _floresServicios.Listar();
        return View(flores);
    }

    [HttpGet]
    public IActionResult Eliminar(int id)
    {
        _floresServicios.Eliminar(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Agregar(Flor flor)
    {
        _floresServicios.Agregar(flor);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Agregar()
    {
        return View(new Flor());
    }

    [HttpPost]
    public IActionResult Editar(Flor flor)
    {
        var florDB = _floresServicios.ObtenerPorId(flor.Id);
        if (florDB == null)
            return NotFound();
        _floresServicios.Actualizar(flor);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Editar(int id)
    {
        var flor = _floresServicios.ObtenerPorId(id);
        if (flor == null)
            return NotFound();
        return View(flor);
    }
}
