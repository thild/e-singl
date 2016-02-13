using System;

namespace Singl.Models
{
    public class PoloCurso
    {
        public PoloCurso()
        {
        }
        
        public Polo Polo { get; set; }
        public Guid PoloId { get; set; }
        public Curso Curso { get; set; }
        public Guid CursoId { get; set; }
    }
}
