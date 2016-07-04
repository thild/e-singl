using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace Singl.Models
{
    public class Cidade : IModel<Guid>
    {
        public Cidade()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public dynamic ToDto()
        {
            dynamic dto = new ExpandoObject();
            dto.Id = Id;
            dto.Nome = Nome;
            return dto;
        }

    }
}
