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
            bool desativar = Desativar();
            if (desativar)
                return View();
            return NotFound("falha ao conectar");
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
            //FormsAuthentication.SetAuthCookie(username, false);
            bool ativar = Ativar();
            if (ativar)
            {
                return RedirectToAction("Index", "Veterinaria", new { area = "" });
            }
            return NotFound("Erro ao redirecionar");
        }
        [HttpPut]
        public  bool Ativar() 
        {
            try
            {
                var funcionario = _Context.Funcionarios.FirstOrDefault(x => x.Email == "admin@admin.com.br");
                funcionario.Ativo = true;
                _Context.Funcionarios.Update(funcionario);
                _Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        [HttpPut]
        public bool Desativar()
        {
            try
            {
                var funcionario = _Context.Funcionarios.FirstOrDefault(x => x.Email == "admin@admin.com.br");
                funcionario.Ativo = false;
                _Context.Funcionarios.Update(funcionario);
                _Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
