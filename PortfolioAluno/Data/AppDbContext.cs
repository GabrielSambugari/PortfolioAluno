using Microsoft.EntityFrameworkCore;
using PortfolioAluno.Models;
namespace PortfolioAluno.Data
{
    public class AppDbContext : DbContext

    
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
          
    }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Turma> Turmas { get; set; }
    }  
    


    
}
