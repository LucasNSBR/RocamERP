using RocamERP.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RocamERP.Infra.Data.EntityConfiguration
{
    public class EntityConfigurationCadastroNacional : EntityTypeConfiguration<CadastroNacional>
    {
        public EntityConfigurationCadastroNacional()
        {
            HasKey(cn => cn.NumeroDocumento);

            Property(cn => cn.NumeroDocumento)
                .HasMaxLength(14)
                .IsRequired();

            HasRequired(cn => cn.Pessoa)
                .WithOptional(p => p.CadastroNacional);
        }
    }
}
