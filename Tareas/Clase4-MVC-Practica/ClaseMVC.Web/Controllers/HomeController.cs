using System.Diagnostics;
using ClaseMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClaseMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
