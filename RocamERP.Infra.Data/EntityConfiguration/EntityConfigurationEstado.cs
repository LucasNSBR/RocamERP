using RocamERP.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RocamERP.Infra.Data.EntityConfiguration
{
    public class EntityConfigurationEstado : EntityTypeConfiguration<Estado>
    {
        public EntityConfigurationEstado() : base()
        {
            HasKey(e => e.Nome);

            Property(e => e.Nome)
                        .HasMaxLength(20)
                        .IsRequired();
        }
    }
}
