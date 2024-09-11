using Curso.Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Curso.Core.DatosEF
{
    public class CursoContext: DbContext
    {
        public AppConfig Config { get; set; }

        public DbSet<Entidades.Curso> Cursos { get; set; }
        public DbSet<Curso.Core.Entidades.Profesor> Profesores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }
    }
}
