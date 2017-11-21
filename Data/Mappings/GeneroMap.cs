using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraS2IT.Shared.Entities;

namespace LocadoraS2IT.Data.Mappings
{
    class GeneroMap : EntityTypeConfiguration<Genero>
    {
        public GeneroMap()
        {
            ToTable("Genero");
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired().HasMaxLength(50);
        }
    }
}
