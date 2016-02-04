using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Linq;

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
        
        public OfertaDisciplina OfertaDisciplina { get; set; }
        public Guid OfertaDisciplinaId { get; set; }
        
        [NotMappedAttribute]
        public IList<Pessoa> Alunos {get {
            return Vinculos?
                .Where(m => m.Papel.Nome == "Aluno")
                .Select(m => m.Pessoa).ToList();
        }}
        
        [ScaffoldColumn(false)]
        [Display(Name="Vínculos")]
        public IList<VinculoTurma> Vinculos { get; internal set;} = new List<VinculoTurma>();
    }
}