using RocamERP.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RocamERP.Infra.Data.EntityConfiguration.ClienteConfiguration
{
    public class EntityConfigurationClientePessoaFisica : EntityTypeConfiguration<ClientePessoaFisica>
    {
        public EntityConfigurationClientePessoaFisica() : base()
        {
            ToTable("PessoaFisica");

            Property(pf => pf.CPF)
                .HasMaxLength(11)
                .IsRequired();

            Property(pf => pf.RG)
                .HasMaxLength(12)
                .IsOptional();
        }
    }
}
