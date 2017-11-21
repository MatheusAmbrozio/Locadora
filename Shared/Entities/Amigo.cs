using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraS2IT.Shared.Entities
{
    public class Amigo : Entity
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }

    }
}
