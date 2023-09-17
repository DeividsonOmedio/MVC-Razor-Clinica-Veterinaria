using ClinicaVeterinaria.Context;
using ClinicaVeterinaria.Models;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<Procedimento> procedimentos = _Contex.Procedimentos;
            return View(procedimentos);
        
        }
        public IActionResult CadastrarAnimal()
        {
            return View();
        }

        public IActionResult CadastrarProcedimento()
        {
            var animais = _Contex.Animais;
            return View(animais);
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
            novoPrcedimento.AnimalId = Convert.ToInt32(novoPrcedimento.Animal);
            novoPrcedimento.FuncionarioId = Convert.ToInt32(novoPrcedimento.Funcionario);

            var conferencia = _Contex.Procedimentos.FirstOrDefault(x => x.Codigo == novoPrcedimento.Codigo);
            if (conferencia != null)
            {
                TempData["MensagemErro"] = "Procedimento já cadastrado";
                return View("Index");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _Contex.Procedimentos.Add(novoPrcedimento);
                    _Contex.SaveChanges();
                }
                catch
                {
                    return View("Index");
                }
                TempData["MensagemSucesso"] = "Adição realizada com sucesso!";
                return View("Index");
            }
            return View("Index");
        }
        public IActionResult Editar(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Procedimento procedimento = _Contex.Procedimentos.FirstOrDefault(x => x.Id == id);

            if (procedimento == null)
            {
                return NotFound();
            }


            return View(procedimento);
        }
        [HttpPost]
        public IActionResult Editar(Procedimento procedimento)
        {
            if (ModelState.IsValid)
            {
                _Contex.Procedimentos.Update(procedimento);
                _Contex.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Ocorreu algum erro no momento da edição!";
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
