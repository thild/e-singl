using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neadm.Models
{
    public class Disciplina
    {
        public Disciplina() {
            Id = Guid.NewGuid();
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Nome { get; set; }
        
        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        public string Codigo { get; set; }

        [Newtonsoft.Json.JsonProperty("alunos")]
        [NotMappedAttribute]
        public List<Usuario> Alunos {get; private set;}

        public Curso Curso { get; set; }
        
    }
}