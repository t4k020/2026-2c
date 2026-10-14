using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _2C_2026_CLASE3.Web.Models;

namespace _2C_2026_CLASE3.Web.Controllers;

// ============================================================================
//  Un Controller es una clase que atiende requests HTTP.
//
//  Reglas por convención (ASP.NET las aplica solo por el nombre):
//    - La clase termina en "Controller"  ->  HomeController atiende /Home/...
//    - Cada método público es una "action" ->  Index() atiende /Home/Index
//    - return View() busca la vista en Views/{Controller}/{Action}.cshtml
//      o sea: Index() de HomeController -> Views/Home/Index.cshtml
// ============================================================================
public class HomeController : Controller
{
    // GET /  o  GET /Home  o  GET /Home/Index
    public IActionResult Index()
    {
        return View(); // -> Views/Home/Index.cshtml
    }

    // GET /Home/Privacy
    public IActionResult Privacy()
    {
        return View(); // -> Views/Home/Privacy.cshtml
    }

    // GET /Home/Error  (a esta llega la app cuando explota algo en producción)
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        // Acá le pasamos un "modelo" a la vista: la M de MVC.
        // La vista Views/Shared/Error.cshtml lo recibe con @model ErrorViewModel
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
