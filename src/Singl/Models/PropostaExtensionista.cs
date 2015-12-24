using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public class PropostaExtensionista : IModel<Guid>
    {

        public PropostaExtensionista()
        {
            Id = Guid.NewGuid();
            EquipeExecutora = new List<Usuario>();
        }

        [Required]
        public Guid Id { get; set; }

        public Usuario Coordenador { get; set; }

        public DateTimeOffset Inicio { get; set; }

        public DateTimeOffset Termino { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(1000)]
        public string Descricao { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(1000)]
        public string Objetivos { get; set; }

        public Departamento Departamento { get; set; }
        
        public Guid DepartamentoId { get; set; }
        
        public SetorAdministrativo SetorAdministrativo { get; set; }
        
        public Guid SetorAdministrativoId { get; set; }

        public int CargaHorariaSemanal { get; set; }

        public int CargaHorariaTotal { get; set; }

        /// (a quem se destina o Projeto?)
        public string PublicoAlvo { get; set; }

        //(a abrangência é local, regional, nacional ou internacional?Quais cidades?)
        public string Abrangencia { get; set; }

        //(qual espaço físico, bairro, cidade?)        
        public string LocalRealizacao { get; set; }
        
        public string EntidadesParceiras { get; set; }
        
        [NotMapped()]
        public List<Usuario> EquipeExecutora { get; set; }

        // TODO: Criar um ViewComponent com ajax        
        // 1.7.1. Áreas de Conhecimento CNPq 
        // Grande Área
        // Área
        // Subárea
        // Especialidade
        // 1.7.2. Plano Nacional de Extensão Universitária 
        // TODO: Criar um ViewComponent com ajax        
        // Área de extensão
        // Linha de extensão        

    }
}