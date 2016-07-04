using System;

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
    public class ProjetoExtensao : PropostaExtensionista
    {

        public ProjetoExtensao()
        {
            Id = Guid.NewGuid();
        }

        public ProgramaExtensao ProgramaExtensao { get; set; }
        
        public Guid ProgramaExtensaoId { get; set; }

        public ModalidadeProjetoExtensao Modalidade { get; set; }

    }
    public enum ModalidadeProjetoExtensao
    {
        Acao,
        Evento,
        Curso,
        PrestacaoServico
    }

}