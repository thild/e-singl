using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Singl.Models
{
    //Turma
    public class Turma : IModel<Guid>
    {
        
        public Turma()
        {
            Id = Guid.NewGuid();
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        
        [ForeignKey("DisciplinaId")]
        public Disciplina Disciplina { get; set; }
        public Guid DisciplinaId { get; set; }
        
        
        [Newtonsoft.Json.JsonProperty("alunos")]
        [NotMappedAttribute]
        public IList<Usuario> Alunos {get; private set;}
    }
}