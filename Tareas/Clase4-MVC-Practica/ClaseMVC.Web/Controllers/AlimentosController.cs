using ClaseMVC.Entidades;
using ClaseMVC.Logica;
using Microsoft.AspNetCore.Mvc;

namespace ClaseMVC.Web.Controllers;

public class AlimentosController : Controller
{
    private readonly IAlimentosServicios _alimentosServicios;

    public AlimentosController(IAlimentosServicios alimentosServicios)
    {
        _alimentosServicios = alimentosServicios;
    }

    public IActionResult Lista()
    {
        var alimentos = _alimentosServicios.Listar();
        return View(alimentos);
    }

    [HttpGet]
    public IActionResult Eliminar(int id)
    {
        var alimento = _alimentosServicios.ObtenerPorId(id);
        if (alimento == null)
            return NotFound();

        var eliminado = _alimentosServicios.Eliminar(id);
        if (eliminado != null)
        {
            TempData["Mensaje"] = $"Último alimento eliminado: {eliminado.Nombre} - {eliminado.Calorias} kcal - {eliminado.Peso} g";
        }

        return RedirectToAction("Lista");
    }
}
