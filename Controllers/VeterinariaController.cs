using ClinicaVeterinaria.Context;
using ClinicaVeterinaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Controllers
{
    public class VeterinariaController : Controller
    {
        readonly private MyDbContext _Contex;

        public VeterinariaController(MyDbContext contex)
        {
            _Contex = contex;
        }
        
        public IActionResult Index()
        {
            var funcionario = _Contex.Funcionarios.FirstOrDefault(x => x.Email == "admin@admin.com.br");
            if (funcionario.Ativo)
                return RedirectToAction("Index", "Home", new { area = "" });
            IEnumerable<Procedimento> procedimentos = _Contex.Procedimentos;
            return View(procedimentos);
        
        }
        public IActionResult CadastrarAnimal()
        {
            return View();
        }

        public IActionResult CadastrarProcedimento()
        {
            var funcionario = _Contex.Funcionarios.FirstOrDefault(x => x.Email == "admin@admin.com.br");
            if (funcionario.Ativo == false)
                return RedirectToAction("Index", "Home", new { area = "" });

            return View();
        }
        [HttpPost]
        public IActionResult CadastrarAnimal(Animal novoAnimal)
        {
            
            if (ModelState.IsValid)
            {
                
                    _Contex.Animais.Add(novoAnimal);
                    _Contex.SaveChanges();
              
                
                TempData["MensagemSucesso"] = "Adição realizada com sucesso!";
                return View("Index");
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult CadastrarProcedimento(Procedimento novoPrcedimento)
        {
            

            var conferencia = _Contex.Procedimentos.FirstOrDefault(x => x.Codigo == novoPrcedimento.Codigo);
            if (conferencia != null)
            {
                TempData["MensagemErro"] = "Procedimento já cadastrado";
                return View("Index");
            }
            
                try
                {
                    _Contex.Procedimentos.Add(novoPrcedimento);
                    _Contex.SaveChanges();
                }
                catch
                {
                    return NotFound("Não foi possivel adicionar ao banco");
                }
                TempData["MensagemSucesso"] = "Adição realizada com sucesso!";
                return RedirectToAction("Index");
            
            
        }
        
        public IActionResult Editar(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Id 0");
            }

            Procedimento procedimento = _Contex.Procedimentos.FirstOrDefault(x => x.Id == id);

            if (procedimento == null)
            {
                return NotFound("Id nao localizado");
            }


            return View(procedimento);
        }
        [HttpPost]
        public IActionResult Editar(Procedimento procedimento)
        {
            try
            {
                _Contex.Procedimentos.Update(procedimento);
                _Contex.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Index");
            }
            catch
            {
                return NotFound("nao foi possivel atualizar no banco");
            }

            
        }
        public IActionResult Deletar(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound("Id 0");
            }

            Procedimento procedimento = _Contex.Procedimentos.FirstOrDefault(x => x.Id == id);

            if (procedimento == null)
            {
                return NotFound("Id nao localizado");
            }


            return View(procedimento);
        }
        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var conferencia = _Contex.Procedimentos.FirstOrDefault(x => x.Id == id);
            if (conferencia == null)
            {
                return NotFound();
            }

            _Contex.Procedimentos.Remove(conferencia);
            _Contex.SaveChanges();
            TempData["MensagemSucesso"] = "Remoção realizada com sucesso!";
            return RedirectToAction("Index");

        }
    }
}
