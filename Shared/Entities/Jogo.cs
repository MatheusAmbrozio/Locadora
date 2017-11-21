using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraS2IT.Shared.Entities
{
    public class Jogo : Entity
    {
        public string Nome { get; set; }
        public virtual Genero Genero { get; set; }

    }
}
