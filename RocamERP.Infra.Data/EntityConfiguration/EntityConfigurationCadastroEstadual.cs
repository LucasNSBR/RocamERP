using RocamERP.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RocamERP.Infra.Data.EntityConfiguration
{
    public class EntityConfigurationCadastroEstadual : EntityTypeConfiguration<CadastroEstadual>
    {
        public EntityConfigurationCadastroEstadual()
        {
            HasKey(ce => ce.CadastroEstadualId);

            Property(ce => ce.NumeroDocumento)
                .HasMaxLength(12)
                .IsRequired();

            HasRequired(ce => ce.Pessoa)
                .WithOptional(p => p.CadastroEstadual);
        }
    }
}
