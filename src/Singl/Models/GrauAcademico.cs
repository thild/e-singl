using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Singl.Extensions;

namespace Singl.Models
{
    [JsonConverter(typeof(EnumValueConverter))]
    public enum GrauAcademico
    {
        [Display(Name = "Tecnólogo")]
        Tecnologo,
        Licentiatura,
        Bacharelado,
        [Display(Name = "Especialização")]
        Especializacao,
        Mestrado,
        Doutorado,
    }
}