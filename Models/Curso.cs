using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Neadm.Models
{
    //Curso
    public class Curso
    {
        
        public Curso()
        {
            Id = Guid.NewGuid();
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        public string Nome { get; set; }
        
        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        
        [Newtonsoft.Json.JsonProperty("disciplinas")]
        [NotMappedAttribute]
        public IList<Disciplina> Disciplinas { get; set; }
        
        [Newtonsoft.Json.JsonProperty("alunos")]
        [NotMappedAttribute]
        public IList<Usuario> Alunos {get; private set;}
    }
}