using ClinicaVeterinaria.Context;
using ClinicaVeterinaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Controllers
{
    public class LoginController : Controller
    {
        readonly private MyDbContext _Context;

        public LoginController(MyDbContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string email, string senha)
        {
            var Conferencia = _Context.Funcionarios.FirstOrDefault(x => x.Email == email);
            if(Conferencia == null) 
            {
                return View("Index");
            }
            if(Conferencia.Senha != senha)
            {
                return View("Index");
            }
            
            return RedirectToAction("Index", "Veterinaria", new { area = "" });
        }

    }
}
