using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
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