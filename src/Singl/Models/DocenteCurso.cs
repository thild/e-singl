using System;

namespace Singl.Models
{
    public class DocenteCurso
    {
        public DocenteCurso()
        {
        }
        
        public Docente Docente { get; set; }
        public Guid DocenteId { get; set; }
        public Curso Curso { get; set; }
        public Guid CursoId { get; set; }
    }
}
