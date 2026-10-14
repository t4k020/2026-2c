using Comparador.ServicioLocal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2026_2C_API_Comparador.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComparadorController : ControllerBase
{
    IComparadorServicio _comparadorServicio;

    public ComparadorController(IComparadorServicio comparadorServicio)
    {
        _comparadorServicio = comparadorServicio;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var comparaciones = _comparadorServicio.ObtenerComparaciones();
        return Ok(comparaciones);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Comparador.Entidad.Comparador comparacion)
    {
        _comparadorServicio.AgregarComparacion(comparacion);
        return Ok();
    }


}
