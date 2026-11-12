namespace PortfolioAluno.Models
{
    public class Projetos
    {
        public int Id { get; set; }
        public string Experiencia { get; set; }
        public string Tecnologias { get; set; }
        public string FerramentasDeIa { get; set; }
        public int Alunoid { get; set; }
        public Aluno Aluno { get; set; }
    }
}
