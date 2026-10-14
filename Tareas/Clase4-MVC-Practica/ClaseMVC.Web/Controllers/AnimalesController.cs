using System.Diagnostics;
using ClaseMVC.Entidades;
using ClaseMVC.Logica;
using ClaseMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClaseMVC.Web.Controllers;

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

    //Agregar


    [HttpGet]
    public IActionResult Agregar()
    {
        return View(new Animal());
    }

    [HttpPost]
    public IActionResult Agregar(Animal animal)
    {
        _animalesServicios.Agregar(animal);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Editar(int id)
    {
        var animal = _animalesServicios.ObtenerPorId(id);

        if (animal == null)
        {
            return NotFound();
        }

        return View(animal);
    }

    [HttpPost]
    public IActionResult Editar(Animal animal)
    {
        var animalDB = _animalesServicios.ObtenerPorId(animal.Id);
        if (animalDB == null)
            return NotFound();

        _animalesServicios.Actualizar(animal);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Eliminar(int id)
    {
        var animal = _animalesServicios.ObtenerPorId(id);
        if (animal == null)
        {
            return NotFound();
        }

        _animalesServicios.Eliminar(id);

        return RedirectToAction("Index");
    }
}
