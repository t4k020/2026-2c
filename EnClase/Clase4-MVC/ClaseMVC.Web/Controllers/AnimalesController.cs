using System.Diagnostics;
using System.Linq;
using ClaseMVC.Entidades;
using ClaseMVC.Logica;
using ClaseMVC.Web.Models;
using ClaseMVC.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClaseMVC.Web.Controllers;

public class AnimalesController : Controller
{
    private readonly IAnimalesServicios _animalesServicios;
    private readonly IRecientesService _recientesService;

    public AnimalesController(IAnimalesServicios animalesServicios, IRecientesService recientesService)
    {
        _animalesServicios = animalesServicios;
        _recientesService = recientesService;
    }

    public IActionResult Index()
    {
        var animales = _animalesServicios.Listar();
        if (new Random().NextDouble() < 0.3)
        {
            var random = new Random();
            var animalAleatorio = animales[random.Next(animales.Count)];
            var raza = animalAleatorio.Raza; 
            var porcentaje = random.Next(1, 50);

            TempData["Alerta"] = $"Durante el último año la raza {raza} redujo su población en {porcentaje}%";
        }
        // map to viewmodels
        var vms = animales.Select(a => a.ToViewModel()).ToList();

        // Load recently viewed from session (list of ids) via service
        var recientesIds = _recientesService.ObtenerRecientes();
        var recientes = recientesIds
            .Select(id => _animalesServicios.ObtenerPorId(id))
            .Where(a => a != null)
            .Select(a => a!.ToViewModel())
            .ToList();

        ViewBag.Recientes = recientes;

        return View(vms);
    }

    //Agregar


    [HttpGet]
    public IActionResult Agregar()
    {
        ViewBag.NacimientosUltimoMes = new Random().Next(0, 20);
        var vm = new AnimalViewModel { NacimientosUltimoMes = (int)ViewBag.NacimientosUltimoMes };
        return View(vm);
    }

    [HttpPost]
    public IActionResult Agregar(AnimalViewModel animal)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.NacimientosUltimoMes = new Random().Next(0, 20);
            animal.NacimientosUltimoMes = (int)ViewBag.NacimientosUltimoMes;
            return View(animal);
        }

        var entidad = animal.ToEntity();
        _animalesServicios.Agregar(entidad);
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
        //viewbag
        //viewdata
        //tempdata --> tiempo de vida + 1 request (1 redirect)

        //mock de datos
        //datos actualizados de una api de cuantos ejemplares quedan a nivel mundial

        ViewBag.CantidadEjemplares = new Random().Next(2500);
        ViewBag.NacimientosUltimoMes = new Random().Next(0, 20);
        //ViewData["CantidadEjemplares"] = new Random().Next(2500);
        //TempData["CantidadEjemplares"] = new Random().Next(2500);

        var vm = animal.ToViewModel();
        vm.CantidadEjemplares = (int)ViewBag.CantidadEjemplares;
        vm.NacimientosUltimoMes = (int)ViewBag.NacimientosUltimoMes;

        // Update recientes via service
        _recientesService.AgregarReciente(id);

        return View(vm);
    }

    [HttpPost]
    public IActionResult Editar(AnimalViewModel animal)
    {
        var animalDB = _animalesServicios.ObtenerPorId(animal.Id);
        if (animalDB == null)
            return NotFound();

        if (ModelState.IsValid)
        {
            var entidad = animal.ToEntity();
            _animalesServicios.Actualizar(entidad);
            return RedirectToAction("Index");
        }

        ViewBag.NacimientosUltimoMes = new Random().Next(0, 20);
        animal.NacimientosUltimoMes = (int)ViewBag.NacimientosUltimoMes;
        return View(animal);
    }

    [HttpGet]
    public IActionResult Eliminar(int id)
    {
        var animal = _animalesServicios.ObtenerPorId(id);
        if (animal == null)
        {
            return NotFound();
        }
        TempData["Mensaje"] = $"El animal {animal.Raza} ha sido eliminado correctamente.";

        _animalesServicios.Eliminar(id);

        return RedirectToAction("Index");
    }
}
