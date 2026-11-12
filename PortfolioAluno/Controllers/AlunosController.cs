using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAluno.Data;
using PortfolioAluno.Models;

namespace PortfolioAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> CriarAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return Ok("Aluno Criado.");
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> AlterarAluno(
       int id, Aluno aluno)
        {
            var alunoAtual = await _context.Alunos.FindAsync(id);
            if (alunoAtual == null)
            {
                return NotFound();
            }
            alunoAtual.CPF = aluno.CPF;
            alunoAtual.Nome = aluno.Nome;
            alunoAtual.Experiencia = aluno.Experiencia;
            alunoAtual.Tecnologias = aluno.Tecnologias;
            alunoAtual.FerramentasDeIa = aluno.FerramentasDeIa;
            alunoAtual.Turmaid = aluno.Turmaid;

            return Ok("Aluno Alterado!");
        }

        [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAluno(int id)
            {
                var aluno = await _context.Projetos.FindAsync(id);

                if (aluno == null)
                {
                    return NotFound("Aluno não encontrado.");
                }

                _context.Projetos.Remove(aluno);
                await _context.SaveChangesAsync();

                return Ok("Aluno excluído com sucesso.");
            }



        }
    }

