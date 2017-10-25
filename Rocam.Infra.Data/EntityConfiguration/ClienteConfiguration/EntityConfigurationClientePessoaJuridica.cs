using RocamERP.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RocamERP.Infra.Data.EntityConfiguration.ClienteConfiguration
{
    public class EntityConfigurationClientePessoaJuridica : EntityTypeConfiguration<ClientePessoaJuridica>
    {
        public EntityConfigurationClientePessoaJuridica() : base()
        {
            Property(pj => pj.CNPJ)
                .HasMaxLength(14)
                .IsOptional();

            Property(pj => pj.InscricaoEstadual)
                .HasMaxLength(9)
                .IsOptional();
        }
    }
}
