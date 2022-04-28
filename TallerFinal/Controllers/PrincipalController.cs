using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TallerFinal.Models;

namespace TallerFinal.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly ILogger<PrincipalController> _logger;

        public PrincipalController(ILogger<PrincipalController> logger)
        {
            _logger = logger;
        }

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Help()
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