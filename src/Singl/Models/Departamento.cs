using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Singl.Models
{
    public class Departamento : IModel<Guid>
    {
        public Departamento()
        {
            
        }
        
        [Required]
        public Guid Id { get; set; }
        
        public string Nome { get; set;} 
        public string Sigla { get; set;} 
        public SetorConhecimento SetorConhecimento {get; set;}
        public Guid SetorConhecimentoId {get; set;}
        public Campus Campus { get; set;}
        public Guid CampusId { get; set;}         
        public IList<Curso> Cursos { get; set; }
        public IList<ProjetoPesquisa> ProjetosPesquisa { get; set; }
    }
}
