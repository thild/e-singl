
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Neadm.Models
{
    public class Questao
    {
        [Required]
        public Guid Id { get; set; }
      
        public string Enunciado { get; set; }

        public RelatorioEvasao RelatorioEvasao { get; set; }

        public List<Alternativa> Alternativas { get; set; }
    }
}