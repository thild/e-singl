using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Linq;
using Singl.Models.Validators;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Singl.Extensions;
using Singl.Core.Scaffolding;
using System.Dynamic;
using System.Dynamic;
using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNet.Mvc.Formatters;

namespace Singl.Models
{
    //Curso
    [CursoValidator]
    [ModelMetadataAttribute(
                DisplayName = "Curso",
                DetailNavigationUrl = "`/cursos/${model.Codigo}`",
                DescriptionProperty = "Nome",
                SelectionProperty = "Codigo",
                DetailRouteName = "CursoDetail",
                DetailRouteParams = @"`{""codigo"":""${model.Codigo}""}`",
                ListNavigationUrl = "`/cursos`",
                ListRouteName = "CursoList",
                ListRouteParams = @"`{""codigo"":""${model.Codigo}""}`"
                )]
    public class Curso : IModel<Guid>
    {

        public Curso()
        {
            Id = Guid.NewGuid();
            Curriculos = new List<Curriculo>();
            ModalidadeEnsino = ModalidadeEnsino.Presencial;
        }

        [Required]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Bla")]
        [MaxLength(100)]
        [ScaffoldColumn(true)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres alfanuméricos.")]
        [RegularExpression(@"^[\w\s]*$", ErrorMessage = "O campo {0} deve conter apenas caracteres alfanuméricos.")]
        [Display(Name = "Código")]
        [ScaffoldColumn(true)]
        public string Codigo { get; set; }

        [NotMapped]
        public string CodigoNome
        {
            get
            {
                return $"{Codigo} - {Nome}";
            }
        }
        [ScaffoldColumn(true)]
        public Departamento Departamento { get; set; }
        public Guid DepartamentoId { get; set; }

        [Display(Name = "Tipo")]
        [JsonConverter(typeof(EnumValueConverter))]
        [ScaffoldColumn(true)]
        public TipoCurso Tipo { get; set; }

        [Display(Name = "Perfil do egresso")]
        [ScaffoldColumn(true)]
        public string PerfilEgresso { get; set; }

        [Display(Name = "Modalidade de ensino")]
        [ScaffoldColumn(true)]
        [JsonConverter(typeof(EnumValueConverter))]
        public ModalidadeEnsino ModalidadeEnsino { get; set; }

        [ScaffoldColumn(true)]
        public Campus Campus { get; set; }

        public Guid CampusId { get; set; }

        [Display(Name = "Currículos")]
        public IList<Curriculo> Curriculos { get; set; }

        [Display(Name = "Currículos em andamento")]
        [NotMapped]
        public IList<Curriculo> CurriculosEmAndamento
        {
            get
            {
                return Curriculos.Where(m => m.SituacaoCurriculo != SituacaoCurriculo.Arquivado).ToList();
            }
        }


        [Display(Name = "Currículo")]
        [NotMapped]
        public Curriculo Curriculo
        {
            get
            {
                return CurriculosEmAndamento.Where(m => m.SituacaoCurriculo == SituacaoCurriculo.Vigente).SingleOrDefault();
            }
        }

        [NotMapped]
        [ScaffoldColumn(true)]
        public IList<Disciplina> Disciplinas
        {
            get
            {
                return Curriculo?.Disciplinas;
            }
        }

        public dynamic ToDto()
        {
            dynamic dto = new ExpandoObject();
            dto.Campus = Campus == null ? null : new { Campus.Id, Campus.Nome, Campus.Sigla };
            dto.Codigo = Codigo;
            dto.Curriculo = Curriculo == null ? null : new { Curriculo.Id, Curriculo.Nome, Curriculo.Ano };
            dto.Departamento = Departamento == null ? null : new { Departamento.Id, Departamento.Nome, Departamento.Sigla, Departamento.SiglaUnidadeUniversitaria };
            var uu = Campus?.UnidadeUniversitaria;
            dto.UnidadeUniversitaria = uu == null ? null : new { uu.Id, uu.Nome, uu.Sigla };
            dto.Disciplinas = Disciplinas == null ? null : Disciplinas.Select(x => new { x.Id, x.Nome, x.Codigo });
            dto.ModalidadeEnsino = ModalidadeEnsino;
            dto.Nome = Nome;
            dto.PerfilEgresso = PerfilEgresso;
            //TypeDescriptor.CreateProperty(dto, new JsonConverterAttribute(typeof(EnumValueConverter)));
            dto.Tipo = Tipo;
            return dto;
        }
    }
}