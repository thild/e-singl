using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Singl.Core.Scaffolding;

namespace Singl.Models
{
    [ModelMetadataAttribute(
                DisplayName = "Disciplina",
                DetailNavigationUrl = "`/disciplinas/${model.Codigo}`",
                DescriptionProperty = "Nome",
                SelectionProperty = "Codigo",
                DetailRouteName = "DisciplinaDetail",
                DetailRouteParams = @"`{""codigo"":""${model.Codigo}""}`",
                ListNavigationUrl = "`/disciplinas`",
                ListRouteName = "DisciplinaList",
                ListRouteParams = @"`{""codigo"":""${model.Codigo}""}`"
                )]
    public class Disciplina : IModel<Guid>
    {
        public Disciplina() {
            Id = Guid.NewGuid();
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [ScaffoldColumn(true)]
        public string Nome { get; set; }
        
        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        [ScaffoldColumn(true)]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        
        [NotMapped]
        public string CodigoNome {
            get {
                return $"{Codigo} - {Nome}";
            }
        }        
        
        [ScaffoldColumn(true)]
        public int Ano { get; set; }
        
        [Display(Name = "Série")]
        [ScaffoldColumn(true)]
        public int Serie { get; set; }
        
        [ScaffoldColumn(true)]
        public int Ordem { get; set; }
        
        [DataType(DataType.Url)]
        public string UrlImagem { get; set; }
        
        //TODO: Faz parte da oferta da disciplina Singl.Models.OfertaDisciplina
        [DataType(DataType.Url)]
        [ScaffoldColumn(true)]
        [Display(Name = "AVA")]
        [Url]
        public string UrlAva { get; set; }
        
        [ScaffoldColumn(true)]
        public bool Optativa { get; set; }
        
        [ScaffoldColumn(true)]
        public int Semestre { get; set; }
        
        [Display(Name = "Carga horária semanal")]
        [ScaffoldColumn(true)]
        public int CargaHorariaSemanal { get; set; }
        
        [Display(Name = "Carga horária total")]
        [ScaffoldColumn(true)]
        public int CargaHorariaTotal { get; set; }
        
        [ScaffoldColumn(true)]
        public string Ementa { get; set; }
        
        [ScaffoldColumn(true)]
        public string Objetivos { get; set; } 

        [Display(Name = "Currículo")]
        [ScaffoldColumn(true)]
        public Curriculo Curriculo { get; set; }

        public Guid CurriculoId { get; set; }
        
        //TODO: Manter a bibliografia apenas na oferta da disciplina
        [ScaffoldColumn(true)]
        public string Bibliografia { get; internal set; }
        
        [Display(Name = "Créditos")]
        [ScaffoldColumn(true)]
        public int Creditos { get; internal set; }
        public string Modulo { get; internal set; }
    }
}