using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using Singl.Core.Scaffolding;

namespace Singl.Models
{

    [ModelMetadataAttribute(
                  DisplayName = "Departamento",
                  DetailNavigationUrl = "`/departamentos/${model.Sigla}/${model.SiglaUnidadeUniversitaria}`",
                  DescriptionProperty = "Nome",
                  SelectionProperty = "Sigla",
                  DetailRouteName = "DepartamentoDetail",
                  DetailRouteParams = @"`{""sigla"":""${model.Sigla}"",""unidadeUniversitaria"":""${model.SiglaUnidadeUniversitaria}""}`",
                  ListNavigationUrl = "`/departamentos`",
                  ListRouteName = "DepartamentoList",
                  ListRouteParams = @"`{""sigla"":""${model.Sigla}""}`"
                  )]
    public class Departamento : IModel<Guid>
    {
        public Departamento()
        {

        }

        [Required]
        public Guid Id { get; set; }

        [ScaffoldColumn(true)]
        public string Nome { get; set; }

        [ScaffoldColumn(true)]
        public string Sigla { get; set; }

        [NotMapped]
        public string SiglaNome
        {
            get
            {
                return $"{Sigla} - {Nome}";
            }
        }

        [NotMapped]
        public string SiglaUnidadeUniversitaria
        {
            get
            {
                return Campus?.SiglaUnidadeUniversitaria ?? string.Empty;
            }
        }

        [ScaffoldColumn(true)]
        [Display(Name = "Setor de conhecimento")]
        public SetorConhecimento SetorConhecimento { get; set; }
        public Guid SetorConhecimentoId { get; set; }

        [ScaffoldColumn(true)]
        public Campus Campus { get; set; }
        public Guid CampusId { get; set; }

        [ScaffoldColumn(true)]
        public IList<Curso> Cursos { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "Projetos de pesquisa")]
        public IList<ProjetoPesquisa> ProjetosPesquisa { get; set; }

        //TODO: Create an attribte called DtoField to genarate Dto automagically.
        public dynamic ToDto()
        {
            dynamic dto = new ExpandoObject();
            dto.Id = Id;
            dto.Nome = Nome;
            dto.Sigla = Sigla;
            dto.SiglaNome = SiglaNome;
            dto.SiglaUnidadeUniversitaria = SiglaUnidadeUniversitaria;
            dto.Campus = new { Campus.Sigla, Campus.Nome };
            dto.Cursos = Cursos?.Select(m => new { m.Nome, m.Codigo });
            dto.ProjetosPesquisa = ProjetosPesquisa?.Select(m => new { m.Titulo, m.Id });
            dto.SetorConhecimento = new { SetorConhecimento?.Sigla, SetorConhecimento.Nome, SiglaUnidadeUniversitaria };
            return dto;
        }

    }
}
