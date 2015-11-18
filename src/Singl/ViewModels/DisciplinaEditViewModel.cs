using System.ComponentModel.DataAnnotations;
using System;
using Singl.Models;
using Microsoft.AspNet.Mvc.Rendering;
using System.Linq;

namespace Singl.ViewModels
{
    public class DisciplinaEditViewModel
    {
        public DisciplinaEditViewModel() {
            var curriculos = (new DatabaseContext()).Curriculos.OrderBy(m => m.Nome).ToList();
            
            Curriculos = new SelectList(curriculos, "Id", "Nome");
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Insra um código entre 4 e 10 caracteres alfanuméricos.")]
        [MinLength(4)]
        [MaxLength(10)]
        public string Codigo { get; set; }

        public Guid CurriculoId { get; set; }
        
        public SelectList Curriculos { get; set; }
    }
}