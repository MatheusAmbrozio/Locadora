using System.Data.Entity.Migrations.Model;
using LocadoraS2IT.Shared.Entities;
using System.Data.Entity.ModelConfiguration;
using System.Security.Cryptography.X509Certificates;

namespace LocadoraS2IT.Data.Mappings
{

    public class AmigoMap : EntityTypeConfiguration<Amigo>
    {
        public AmigoMap()
        {
            ToTable("Amigo");
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired().HasMaxLength(160);
        }
    }
}
