using System.Data.Entity.ModelConfiguration;
using RocamERP.Domain.Models;

namespace RocamERP.Infra.Data.EntityConfiguration
{
    public class EntityConfigurationPesoa : EntityTypeConfiguration<Pessoa>
    {
        public EntityConfigurationPesoa() : base()
        {
            HasKey(c => c.PessoaId);

            Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.Descricao)
                 .HasMaxLength(1000)
                 .IsOptional();
        }
    }
}
