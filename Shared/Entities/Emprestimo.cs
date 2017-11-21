using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraS2IT.Shared.Entities
{
    public class Emprestimo:Entity
    {
        public virtual Amigo Amigo { get; set; }
        public virtual Jogo Jogo { get; set; }
    }
}
