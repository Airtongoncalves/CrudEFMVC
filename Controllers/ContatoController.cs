using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using Projetomvc.Context;
using Projetomvc.Models;

namespace Projetomvc.Controllers
{
    public class ContatoController : Controller
    {

        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        public IActionResult Index(){
            
            var contatos  = _context.Contatos.ToList();
            return View(contatos);
        }

        public IActionResult Criar(){
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Contato contato ){
                if(ModelState.IsValid){
                    _context.Contatos.Add(contato);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(contato);
        }
        public ActionResult Editar(int id){
            var contato  = _context.Contatos.Find(id);

            if(contato == null){
                    return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
        [HttpPost]
        public ActionResult Editar(Contato contato){
            var contatoBanco  = _context.Contatos.Find(contato.id);
        
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;
        
                _context.Contatos.Update(contatoBanco);
                _context.SaveChanges();
        
        return RedirectToAction(nameof(Index));

        }
       
        public ActionResult Detalhes(int id)
        {
            var contato   = _context.Contatos.Find(id);
            if(contato == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
        public ActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);
            if(contato  == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
        [HttpPost]
         public ActionResult Deletar(Contato contato){
            Console.Write(contato.id);
            //Connected Scenario
           var  contatobanco = _context.Contatos.Find(contato.id);
           if(contatobanco == null)
           {
                return RedirectToAction(nameof(Index));
           }
            _context.Remove(contatobanco);
            _context.SaveChanges();
          
            return RedirectToAction(nameof(Deletar));
        
    }
    }
}