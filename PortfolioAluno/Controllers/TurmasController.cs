using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAluno.Data;
using PortfolioAluno.Models;

namespace PortfolioAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TurmasController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurmas()
        {
            return await _context.Turmas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CriarTurma(Turma turma)
        {
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();
            return Ok("Turma Criada.");
        }
        [HttpPut("{id}")]

        public async Task<ActionResult> AlterarTurma(
    int id, Turma turma)
        {
            var turmaAtual = await _context.Turmas.FindAsync(id);
            if (turmaAtual == null)
            {
                return NotFound();
            }
            turmaAtual.NomeDaSala = turma.NomeDaSala;
            turmaAtual.Id = turma.Id;

            return Ok("Turma Alterada!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound("Turma não encontrada.");
            }
            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();
            return Ok("Turma deletada com sucesso.");
        }



    }
}
