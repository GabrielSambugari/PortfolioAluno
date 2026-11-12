using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAluno.Data;
using PortfolioAluno.Models;

namespace PortfolioAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjetosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projetos>>> GetProjetos()
        {
            return await _context.Projetos.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> CriarProjetos(Projetos projetos)
        {
            _context.Projetos.Add(projetos);
            await _context.SaveChangesAsync();
            return Ok("Projetos Criados.");
        }
        [HttpPut("{id}")]

        public async Task<ActionResult> AlterarProjetos(
       int id, Projetos projetos)
        {
            var projetosAtual = await _context.Projetos.FindAsync(id);
            if (projetosAtual == null)
            {
                return NotFound();
            }
            projetosAtual.Titulo = projetos.Titulo;
            projetosAtual.Descricao = projetos.Descricao;
            projetosAtual.Tecnologias = projetos.Tecnologias;
            projetosAtual.imagem = projetos.imagem;

            return Ok("Projetos Alterados!");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjetos(int id)
        {
            var projetos = await _context.Projetos.FindAsync(id);

            if (projetos == null)
            {
                return NotFound("Projetos não encontrados.");
            }

            _context.Projetos.Remove(projetos);
            await _context.SaveChangesAsync();

            return Ok("Projetos excluídos com sucesso.");
        }
    }
}
