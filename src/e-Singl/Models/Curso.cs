using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Linq;
using Singl.Models.Validators;

namespace Singl.Models
{
    //Curso
    [CursoValidator]
    public class Curso
    {

        public Curso()
        {
            Id = Guid.NewGuid();
            Curriculos = new List<Curriculo>();
        }

        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage="Bla")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres alfanuméricos.")]
        [RegularExpression(@"^[\w\s]*$", ErrorMessage = "O campo {0} deve conter apenas caracteres alfanuméricos.")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Display(Name = "Tipo")]
        public TipoCurso Tipo { get; set; }

        [Display(Name = "Perfil do egresso")]
        public string PerfilEgresso { get; set; }

        [Display(Name = "Currículos")]
        public IList<Curriculo> Curriculos { get; set; }

        [Display(Name = "Currículos em andamento")]
        [NotMapped]
        public IList<Curriculo> CurriculosEmAndamento
        {
            get
            {
                return Curriculos.Where(m => m.SituacaoCurriculo != SituacaoCurriculo.Arquivado).ToList();
            }
        }


        [Display(Name = "Currículo")]
        [NotMapped]
        public Curriculo Curriculo
        {
            get
            {
                return CurriculosEmAndamento.Where(m => m.SituacaoCurriculo == SituacaoCurriculo.Vigente).SingleOrDefault();
            }
        }

        [Newtonsoft.Json.JsonProperty("disciplinas")]
        [NotMapped]
        public IList<Disciplina> Disciplinas
        {
            get
            {
                return Curriculo?.Disciplinas;
            }
        }


    }
}