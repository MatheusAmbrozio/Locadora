using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraS2IT.Web.Models
{
    public class GeneroVM
    {
        [Required(ErrorMessage = "O genero é obrigatorio.")]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Genero")]
        public String Nome { get; set; }
    }
}