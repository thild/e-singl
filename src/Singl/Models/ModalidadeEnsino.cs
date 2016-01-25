using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Singl.Extensions;

namespace Singl.Models
{
    [JsonConverter(typeof(EnumValueConverter))]
    public enum ModalidadeEnsino
    {
        [Display(Name = "Distânca", Description = "Modalidade de ensino a distância")]
        Distancia,
        [Display(Name = "Presencial", Description = "Modalidade de ensino presencial")]
        Presencial,
        [Display(Name = "Misto", Description = "Modalidade de ensino presencial e a distância")]
        Semipresencial
    }
}