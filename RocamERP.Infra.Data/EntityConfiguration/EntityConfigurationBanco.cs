using RocamERP.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RocamERP.Infra.Data.EntityConfiguration
{
    public class EntityConfigurationBanco : EntityTypeConfiguration<Banco>
    {
        public EntityConfigurationBanco() : base()
        {
            HasKey(b => b.BancoId);

            Property(b => b.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(b => b.CodigoCompensacao)
                .IsRequired();
        }
    }
}
