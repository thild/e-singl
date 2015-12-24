using System;

namespace Singl.Models
{
    public class PesquisadorProjetoPesquisa
    {
        public PesquisadorProjetoPesquisa()
        {
        }
        
        public ProjetoPesquisa ProjetoPesquisa { get; set; }
        public Guid ProjetoPesquisaId { get; set; }
        public Guid PesquisadorId { get; set; }
        public Usuario Pesquisador { get; internal set; }
    }
}
