using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistema.Contexts;
using sistema.Models;

namespace sistema.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly SistemaContext _context;

        public ProfessorController(SistemaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int? ProfessorId = HttpContext.Session.GetInt32("ProfessorId");

            if (ProfessorId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var professor = _context.Professores.Find(ProfessorId);

            var turma = _context.Turmas.Where(t => t.ProfessorId == professor!.ProfessorId).ToList();

            ViewBag.NomeProfessor = professor!.Nome;

            return View(turma);
        }

        [HttpPost]
        public IActionResult CadastrarTurma(string nomeTurma)
        {
            int? ProfessorId = HttpContext.Session.GetInt32("ProfessorId");

            var turma = new Turma
            {
                Nome = nomeTurma,
                ProfessorId = ProfessorId
            };

            _context.Turmas.Add(turma);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ExcluirTurma(int turmaId)
        {
            var turma = _context.Turmas.Include(t => t.Atividades).FirstOrDefault(t => t.TurmaId == turmaId);

            if (turma.Atividades.Any())
            {
                TempData["Mensagem"] = "Voce nao pode excluir uma turma com atividades cadastradas";

                return RedirectToAction("Index");

            }

            _context.Turmas.Remove(turma);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
