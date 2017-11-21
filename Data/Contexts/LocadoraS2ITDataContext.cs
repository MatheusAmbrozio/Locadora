using LocadoraS2IT.Data.Mappings;
using LocadoraS2IT.Shared;
using LocadoraS2IT.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace LocadoraS2IT.Data.Contexts
{
    public class LocadoraS2ITDataContext : DbContext
    {
        public LocadoraS2ITDataContext() : base(Runtime.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Amigo> Amigo { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AmigoMap());
            modelBuilder.Configurations.Add(new GeneroMap());
            modelBuilder.Configurations.Add(new JogoMap());
            modelBuilder.Configurations.Add(new EmprestimoMap());
            
    }

        
    }
}
