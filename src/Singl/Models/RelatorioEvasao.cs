
using System;

namespace Singl.Models
{
    public class RelatorioEvasao
    {
        public RelatorioEvasao()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public Curso Curso { get; set; }

        public Disciplina Disciplina { get; set; }

        public Polo Polo { get; set; }

        public Usuario Aluno { get; set; }

        public Usuario Relator { get; set; }

        //public Usuario Coordenador { get; set; } //pegar de Curso

        public DateTimeOffset DataRelatorio { get; set; }

        /// Polo de apoio presencial       
        public Enquete Enquete { get; set; }
    }
}