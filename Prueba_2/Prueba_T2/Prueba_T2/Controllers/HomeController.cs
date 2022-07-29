using Microsoft.AspNetCore.Mvc;
using Prueba_T2.Models;
using Prueba_T2.Data;
using System.Diagnostics;

namespace Prueba_T2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly bd_pruebaContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = _context.TopTen().ToList();
            return View(usuarios);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}