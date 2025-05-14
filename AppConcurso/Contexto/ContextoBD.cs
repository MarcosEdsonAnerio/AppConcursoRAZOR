using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;

namespace AppConcurso.Contexto
{
    public class ConcursoContext : DbContext
    {
        public ConcursoContext(DbContextOptions<ConcursoContext> options) : base(options) { }

        public DbSet<Models.Cargo> Cargos { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Models.Inscricao> Inscricoes { get; set; }
        public DbSet<Nota> Notas { get; set; }
    }
}
