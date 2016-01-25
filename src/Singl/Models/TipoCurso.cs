using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Singl.Extensions;

namespace Singl.Models
{
    [JsonConverter(typeof(EnumValueConverter))]
    public enum TipoCurso
    {
        Bacharelado,
        Licenciatura,
        Mestrado,
        Doutorado,
        [Display(Name="Especialização")]
        Especializacao

    }
}