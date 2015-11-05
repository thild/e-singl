using System.ComponentModel.DataAnnotations;

namespace Neadm.Models
{
    public enum TipoCurso
    {
        Bacharelado,
        Licenciatura,
        Mestrado,
        Doutorado,
        [Display(Name="Especialização")]
        Especialiacao

    }
}