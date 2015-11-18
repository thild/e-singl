using System.Collections.Generic;
using Singl.Models;

namespace Singl.ViewModels
{
    public class CurriculoIndexViewModel
    {
        public CurriculoIndexViewModel() {
            
        }
        public Curso Curso { get; set; }
        public IEnumerable<Curriculo> Curriculos { get; set; }
    }
}