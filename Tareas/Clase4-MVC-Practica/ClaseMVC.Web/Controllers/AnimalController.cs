using ClaseMVC.Entidades;
using ClaseMVC.Logica;
using Microsoft.AspNetCore.Mvc;


namespace ClaseMVC.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAnimalesServicios _animalesServicios;

    public AnimalController(IAnimalesServicios animalesServicios)
    {
        _animalesServicios = animalesServicios;
    }

    // GET: api/<AnimalController>
    [HttpGet]
    public IEnumerable<Animal> Get()
    {
        var animales = _animalesServicios.Listar();
        return animales.ToArray();
    }

    // GET api/<AnimalController>/5
    [HttpGet("{id}")]
    public Animal Get(int id)
    {
        var animal = _animalesServicios.ObtenerPorId(id);
        if (animal == null)
        {
            return null;
        }
        return animal;
    }

    // POST api/<AnimalController>
    [HttpPost]
    public void Post([FromBody] Animal animal)
    {
        _animalesServicios.Agregar(animal);
    }

    // PUT api/<AnimalController>
    [HttpPut("{id}")]
    public void Put([FromBody] Animal animal)
    {
        _animalesServicios.Actualizar(animal);
    }

    // DELETE api/<AnimalController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _animalesServicios.Eliminar(id);
    }
}
