using System;

namespace Singl.Models
{
    public class Pessoa : IModel<Guid>
    {
        public Pessoa()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        string nome;


        //Se existir um usuario, usar o nome
        public string Nome
        {
            get
            {
                return Usuario?.Nome ?? nome;
            }

            set
            {
                nome = value;
            }
        }

        public Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }
        public string Axionimo { get; internal set; }
    }
}