using Microsoft.EntityFrameworkCore;
using PortfolioAluno.Models;
namespace PortfolioAluno.Data
{
    public class AppDbContext : DbContext

    
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
          
    }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Projetos> Projetos { get; set; }
    }  
    


    
}
