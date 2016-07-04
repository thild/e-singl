using System;

namespace Singl.Models
{
    public class Documento : IModel<Guid>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
    }
}