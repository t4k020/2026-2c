using Comparador.ServicioLocal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2026_2C_API_Comparador.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComercioController : Controller
{
    IComerciosServicio _comercioServicio;

    public ComercioController(IComerciosServicio comercioServicio)
    {
        _comercioServicio = comercioServicio;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var comercios = _comercioServicio.ObtenerComercios();
        return Ok(comercios);
    }
}
