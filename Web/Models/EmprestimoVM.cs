using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraS2IT.Web.Models
{
    public class EmprestimoVM
    {
        public Guid Id { get; set; }
        public AmigoVM Amigo { get; set; }
        public JogoVM Jogo { get; set; }
        
    }
}