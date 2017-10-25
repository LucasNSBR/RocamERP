using System.Data.Entity.ModelConfiguration;
using RocamERP.Domain.Models;

namespace RocamERP.Infra.Data.EntityConfiguration.ClienteConfiguration
{
    public class EntityConfigurationClienteBase : EntityTypeConfiguration<Cliente>
    {
        public EntityConfigurationClienteBase() : base()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.Descricao)
                 .HasMaxLength(1000)
                 .IsOptional();
        }
    }
}
