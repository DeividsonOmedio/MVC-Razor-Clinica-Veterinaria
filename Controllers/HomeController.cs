using ClinicaVeterinaria.Context;
using ClinicaVeterinaria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClinicaVeterinaria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly private MyDbContext _context;
        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult buscarProcedimento(string codigo)
        {
            var procedimento = _context.Procedimentos.FirstOrDefault(x => x.Codigo == codigo);
            if(procedimento != null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

        public IActionResult Consulta(string codigo)
        {
            Procedimento procedimento = _context.Procedimentos.FirstOrDefault(x => x.Codigo == codigo);
            if (procedimento != null)
            {
                return View(procedimento);
            }
            return NotFound("Código não encontrado");
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