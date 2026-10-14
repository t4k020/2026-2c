using Comparador.ServicioLocal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2026_2C_API_Comparador.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : Controller
{
    IProductosServicio _productosServicio;

    public ProductoController(IProductosServicio productosServicio)
    {
        _productosServicio = productosServicio;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var productos = _productosServicio.ObtenerProductos();
        return Ok(productos);
    }
}
