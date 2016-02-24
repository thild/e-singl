
using System;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class Alternativa : IModel<Guid>
    {
        public Alternativa() {
            Id = Guid.NewGuid();
        }
        
        [Required]
        public Guid Id { get; set; }
        
        public string Texto { get; set; }
        
        public Questao Questao { get; set; }

    }
}