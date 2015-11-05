using System.Collections.Generic;
using Neadm.Models;

namespace Neadm.ViewModels
{
    public class CurriculoIndexViewModel
    {
        public CurriculoIndexViewModel() {
            
        }
        public Curso Curso { get; set; }
        public IEnumerable<Curriculo> Curriculos { get; set; }
    }
}