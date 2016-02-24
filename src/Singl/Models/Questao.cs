
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class Questao : IModel<Guid>
    {
        public Questao() {
            Id = Guid.NewGuid();
        }
        
        [Required]
        public Guid Id { get; set; }
      
        public string Enunciado { get; set; }

        public Enquete RelatorioEvasao { get; set; }
 
        public List<Alternativa> Alternativas { get; set; }
    }
}