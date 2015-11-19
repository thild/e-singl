using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public class Departamento
    {
        public Departamento()
        {
            
        }
        
        [Required]
        public Guid Id { get; set; }
        
        public string Nome { get; set;} 
        public string Sigla { get; set;} 
        
        public IList<Curso> Cursos { get; set; }
    }
}
