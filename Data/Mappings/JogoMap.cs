using LocadoraS2IT.Shared.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LocadoraS2IT.Data.Mappings
{
    class JogoMap : EntityTypeConfiguration<Jogo>
    {
        public JogoMap()
        {
            ToTable("Jogo");
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired().HasMaxLength(50);
            HasRequired(x => x.Genero);
        }
    }
}
