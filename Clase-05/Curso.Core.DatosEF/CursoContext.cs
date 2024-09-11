using Microsoft.EntityFrameworkCore;

namespace Curso.Core.DatosEF
{
    public class CursoContext: DbContext
    {


        public DbSet<Curso.Core.Entidades.Curso> Cursos { get; set; }
        public DbSet<Curso.Core.Entidades.Profesor> Profesores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Persist Security Info=True;Initial Catalog=CursoDemo;Data Source=.; Application Name=Curso; Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        }
    }
}
