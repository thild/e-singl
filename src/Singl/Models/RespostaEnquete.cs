
using System;

namespace Singl.Models
{
    public class RespostaEnquete : IModel<Guid>
    {
        public RespostaEnquete() {
            Id = Guid.NewGuid();    
        }
        
        public Guid Id { get; set; }
        
        public Curso Curso { get; set; }
        
        public Disciplina Disciplina { get; set; }
        
        public Polo Polo { get; set; }

        public Usuario Respondente { get; set; }
        
        public DateTimeOffset Data { get; set; }

        public Enquete Enquete { get; set; }

    }
}