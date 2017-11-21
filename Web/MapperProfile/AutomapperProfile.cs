using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LocadoraS2IT.Shared.Entities;
using LocadoraS2IT.Web.Models;

namespace LocadoraS2IT.Web.MapperProfile
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Genero, GeneroVM>();
            CreateMap<GeneroVM, Genero>();
            
            CreateMap<JogoVM, Jogo>();
            CreateMap<Jogo, JogoVM>();

            CreateMap<AmigoVM, Amigo>();
            CreateMap<Amigo, AmigoVM>();

            CreateMap<EmprestimoVM, Emprestimo>();
            CreateMap<Emprestimo, EmprestimoVM>();
        }
    }
}