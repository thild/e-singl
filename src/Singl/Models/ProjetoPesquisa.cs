using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Linq;

// I - Informações do pesquisador: PqI (      ) PqE (      )
// Nome do pesquisador:
// Departamento pedagógico ou setor de lotação:
// Regime de Trabalho: 
// Período previsto do credenciamento (mê/ano - mês/ano):
// Grupo de pesquisa CNPq:
// Nesta pesquisa será vinculado o Regime de TIDE: (    )Sim    (    )Não
// Grande Área, Área, Subárea
// Pqi ou Pqe
// Título do projeto: 
// Proponente: 
// Departamento/setor de lotação: 
// Setor de Conhecimento: 
// Descricao
// Objetivos

namespace Singl.Models
{
    //Curso
    public class ProjetoPesquisa : IModel<Guid>
    {

        public ProjetoPesquisa()
        {
            Id = Guid.NewGuid();
            Pesquisadores = new List<Usuario>();
        }
        
        [Required]
        public Guid Id { get; set; }
        
        public Usuario Coordenador { get; set; }
        
        public DateTimeOffset Inicio { get; set; }
        
        public DateTimeOffset Termino { get; set; }
        
        [Required]
        [MinLength(4)]
        [MaxLength(200)]
        public string Titulo { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(1000)]
        public string Descricao { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(1000)]
        public string Objetivos { get; set; }
        
        public Departamento Departamento { get; set; }
        
        public Guid? DepartamentoId { get; set; }
        
        public SetorAdministrativo SetorAdministrativo { get; set; }
        
        public Guid? SetorAdministrativoId { get; set; }
        
        [Display(Name = "Tipo")]
        public TipoPesquisa Tipo { get; set; }

        [NotMapped()]
        public IList<Usuario> Pesquisadores { get; set; }

    }
}