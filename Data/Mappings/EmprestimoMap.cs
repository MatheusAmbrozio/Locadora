using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraS2IT.Shared.Entities;

namespace LocadoraS2IT.Data.Mappings
{
    public class EmprestimoMap: EntityTypeConfiguration<Emprestimo>
    {
        public EmprestimoMap()
        {
            ToTable("Emprestimo");
            HasKey(x => x.Id);
        }
    }
}
