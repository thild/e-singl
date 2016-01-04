using System.Collections.Generic;
using Singl.Models;

namespace Singl.ViewModels
{
    public class UnidadeUniversitariaIndexViewModel
    {
        public UnidadeUniversitariaIndexViewModel() {
            
        }
        public Curso Curso { get; set; }
        public IEnumerable<Curriculo> Curriculos { get; set; }
    }
}