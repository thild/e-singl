
using System;
using System.Collections.Generic;

namespace Singl.Models
{
    public class Enquete
    {
        public Enquete()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }
        
        public string Descrição { get; set; }
        
        public string Objetivos { get; set; }

        public List<Questao> Questoes { get; set; }

        public string Observacoes { get; set; }
    }
}