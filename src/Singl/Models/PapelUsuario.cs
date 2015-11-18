using System;

namespace Singl.Models
{
    public class PapelUsuario
    {
        public Guid Id { get; set; }
        
        public Usuario Usuario { get; set; }
        
        public Papel Papel { get; set; }
        
        //Se não for nulo o role é em nível de disciplina
        public Disciplina Disciplina { get; set; }
        
        //Se não for nulo o role é em nível de curso
        public Curso Curso { get; set; }        
    }
}