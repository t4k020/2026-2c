using System.Diagnostics;
using _2C_2026_CLASE3.Web.Models;
using Microsoft.AspNetCore.Mvc;
using _2C_2026_CLASE3.Logica;
using _2C_2026_CLASE3.Entidades;


namespace _2C_2026_CLASE3.Web.Controllers;

public class AnimalesController : Controller
{
    private readonly IAnimalesServicios _animalesServicios;

    public AnimalesController(IAnimalesServicios animalesServicios)
    {
        _animalesServicios = animalesServicios;
    }
    public IActionResult Index()
    {
        var animales = _animalesServicios.Listar();
        return View(animales);
    }

    public IActionResult Editar(int id)
    {
        var animal = _animalesServicios.ObtenerPorId(id);
        if (animal == null)
        {
            return NotFound();
        }
        ViewBag.CantidadEjemplares = Random.Shared.Next(500, 5000);
        ViewBag.Alto = animal.Alto;
        return View(animal);
    }

    [HttpPost]
    public IActionResult Editar(Animal animal)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.CantidadEjemplares = Random.Shared.Next(500, 5000);
            ViewBag.Alto = animal.Alto;
            return View(animal);
        }
        _animalesServicios.Editar(animal);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Eliminar(int id)
    {
        var animal = _animalesServicios.ObtenerPorId(id);
        if (animal == null)
        {
            return NotFound();
        }
        TempData["Mensaje"] = $"Se eliminó el animal {animal.Raza} correctamente.";
        _animalesServicios.Eliminar(id);
        return RedirectToAction("Index");
    }

    public IActionResult Agregar()
    {
        return View(new Animal());
    }

    [HttpPost]
    public IActionResult Agregar(Animal animal)
    {
        if (!ModelState.IsValid)
        {
            return View(animal);
        }
        _animalesServicios.Agregar(animal);
        return RedirectToAction("Index");
    }
}