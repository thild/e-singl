
using System;
using System.ComponentModel.DataAnnotations;

namespace Neadm.Models
{
    public class Alternativa
    {
        [Required]
        public Guid Id { get; set; }
        
        public string Texto { get; set; }
        
        public Questao Questao { get; set; }

    }
}