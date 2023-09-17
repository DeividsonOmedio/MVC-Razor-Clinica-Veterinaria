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
        public IActionResult Login(Funcionario login)
        {
            var Conferencia = _Context.Funcionarios.FirstOrDefault(x => x.Email == login.Email);
            if(Conferencia == null) 
            {
                return View("Index");
            }
            if(Conferencia.Senha != login.Senha)
            {
                return View("Index");
            }
            
            return RedirectToAction("Index", "Veterinaria", new { area = "" });
        }

    }
}
