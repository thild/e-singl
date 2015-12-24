using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Mvc.Rendering;

namespace Singl.ViewModels
{
    public class DisciplinaCreateViewModel
    {
        public DisciplinaCreateViewModel() {
            var curriculos = (new DatabaseContext()).Curriculos.OrderBy(m => m.Nome).ToList();
             
            Curriculos = new SelectList(curriculos, "Id", "Nome");
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Nome { get; set; }
        
        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        public string Codigo { get; set; }

        public Guid CurriculoId { get; set; }
        
        public SelectList Curriculos { get; set; }
    }
}