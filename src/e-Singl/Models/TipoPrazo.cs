using System.ComponentModel.DataAnnotations;

namespace Singl.Models
{
    public enum TipoPrazo
    {
        Hora,
        Semana,
        
        [Display(Name="Mês")]
        Mes,
        Semestre,
        Ano
    }
}