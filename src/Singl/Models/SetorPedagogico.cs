using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Singl.Models
{
    public class SetorPedagogico : ISetorPedagogico
    {
        public SetorPedagogico()
        {
        }

        public string Nome
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
    
    public interface ISetor
    {
        string Nome { get; set; }
        
    }
    
    public interface ISetorPedagogico : ISetor
    {
        
    } 
   
   public interface ISetorAdministrativo : ISetor
   {
       
   }
   
}
