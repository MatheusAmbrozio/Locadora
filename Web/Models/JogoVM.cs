using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraS2IT.Web.Models
{
    public class JogoVM
    {
        [Required(ErrorMessage = "O Jogo é obrigatorio")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Jogo")]
        public string Nome { get; set; }
        
        public GeneroVM Genero { get; set; }
        

    }
}