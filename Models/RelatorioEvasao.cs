
using System;
using System.Collections.Generic;

namespace Neadm.Models
{
    public class RelatorioEvasao
    {
        public RelatorioEvasao() {
            Id = Guid.NewGuid();    
        }
        
        public Guid Id { get; set; }
        
        public Curso Curso { get; set; }
        
        public Disciplina Disciplina { get; set; }
        
        public Usuario Aluno { get; set; }
        
        public Usuario Relator { get; set; }
        
        public Usuario Coordenador { get; set; }
        
        public DateTime DataRelatorio { get; set; }

        /// Polo de apoio presencial       
        public Polo Polo { get; set; }

        public List<Questao> Questoes {get; set;}
     
        public string  Observacoes { get; set; }
    }
}