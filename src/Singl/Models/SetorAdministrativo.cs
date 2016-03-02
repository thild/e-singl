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
                    DisplayName = "Setor administrativo",
                    DetailNavigationUrl = "`/setoresadministrativos/${model.Sigla}/${model.SiglaCampus}`",
                    DescriptionProperty = "Nome",
                    SelectionProperty = "Sigla",
                    DetailRouteName = "SetorAdministrativoDetail",
                    DetailRouteParams = @"`{""sigla"":""${model.Sigla}"",""campus"":""${model.SiglaCampus}""}`",
                    ListNavigationUrl = "`/setoresadministrativos`",
                    ListRouteName = "SetorAdministrativoList",
                    ListRouteParams = @"`{""sigla"":""${model.Sigla}""}`"
                    )]
    public class SetorAdministrativo : IModel<Guid>
    {
        public SetorAdministrativo()
        {
            Id = Guid.NewGuid();
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

        [ScaffoldColumn(true)]
        [Display(Name = "Supersetor")]
        public SetorAdministrativo Supersetor { get; set; }

        [ForeignKey("SupersetorId")]
        public Guid? SupersetorId { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "Subsetores")]
        public IList<SetorAdministrativo> Subsetores { get; set; }

        [ScaffoldColumn(true)]
        public Campus Campus { get; set; }

        [NotMapped]
        public string SiglaCampus
        {
            get
            {
                return Campus?.Sigla ?? string.Empty;

            }
        }

        [NotMapped]
        public string SiglaCompleta
        {
            get
            {
                return Sigla + (SiglaCampus != "" ? "/" + SiglaCampus : "");
            }
        }

        public Guid CampusId { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Fax { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Sobre { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "Facebook")]
        [Url]
        public string UrlFacebook { get; set; }
        
        [ScaffoldColumn(true)]
        [Display(Name = "Vínculos")]
        public IList<VinculoSetorAdministrativo> Vinculos { get; } = new List<VinculoSetorAdministrativo>();
        public string Historico { get; set; }

        public dynamic ToDto()
        {
            dynamic dto = new ExpandoObject();
            dto.Nome = Campus == null ? null : new { Campus.Id, Campus.Nome, Campus.Sigla };
            dto.Sigla = Sigla;
            dto.SiglaCampus = SiglaCampus;
            dto.Supersetor = Supersetor == null ? null : new { Supersetor.Id, Supersetor.Nome, Supersetor.Sigla, Supersetor.SiglaCampus };
            dto.Campus = Campus == null ? null : new { Campus.Id, Campus.Nome, Campus.Sigla };
            dto.Subsetores = Subsetores == null ? null : Subsetores.Select(x => new { x.Id, x.Nome, x.Sigla, x.SiglaCampus });
            dto.Nome = Nome;
            dto.Sobre = Sobre;
            dto.Historico = Historico;
            dto.Endereco = Endereco;
            dto.UrlFacebook = UrlFacebook;
            dto.Telefone = Telefone;
            dto.Fax = Fax;
            dto.Email = Email;
            return dto;
        }

    }
}
