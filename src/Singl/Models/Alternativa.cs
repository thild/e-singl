
using System;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class Alternativa : IModel<Guid>
    {
        [Required]
        public Guid Id { get; set; }
        
        public string Texto { get; set; }
        
        public Questao Questao { get; set; }

    }
}