using System.ComponentModel.DataAnnotations.Schema;

namespace Curso.Core.Entidades
{
    [Table("Curso")]
    public class Curso
    {
        
        public int CursoId { get; set; }

        [Column("Nombre")]
        public string CursoNombre { get; set; }
        //public int ProfesorId { get; set; }
        //public string ProfesorNombre { get; set; }
    }
}
