using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Singl.Core.Scaffolding;
using Singl.Extensions;

namespace Singl.Models
{
    [ModelMetadataAttribute(
                DisplayName = "Polo",
                DetailNavigationUrl = "`/polos/${model.Id}`",
                DescriptionProperty = "Nome",
                SelectionProperty = "Id",
                DetailRouteName = "PoloDetail",
                DetailRouteParams = @"`{""id"":""${model.Id}""}`",
                ListNavigationUrl = "`/polos`",
                ListRouteName = "PoloList",
                ListRouteParams = @"`{""id"":""${model.Id}""}`"
                )]
    public class Polo : IModel<Guid>
    {

        public Polo()
        {
            Id = Guid.NewGuid();
        }


        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }

        [Display(Name = "Telefone(s)")]
        public string Telefones { get; set; }

        [Display(Name = "Email(s)")]
        public string Emails { get; set; }
        public string Coordenador { get; set; }

        [ScaffoldColumn(true)]
        [NotMapped]
        public IList<Curso> Cursos { get; set; }

        [Url]
        public string Site { get; set; }

        public dynamic ToDto()
        {
            dynamic dto = this.ToExpandoObject();
            dto.Cursos = Cursos == null ? null :
                Cursos.Select(x => new
                {
                    x.Codigo,
                    x.Nome
                });

            return dto;
        }
    }
}