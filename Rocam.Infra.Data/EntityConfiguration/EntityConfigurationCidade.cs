using System.Data.Entity.ModelConfiguration;
using RocamERP.Domain.Models;

namespace RocamERP.Infra.Data.EntityConfiguration
{
    public class EntityConfigurationCidade : EntityTypeConfiguration<Cidade>
    {
        public EntityConfigurationCidade() : base()
        {
                HasKey(c => c.Nome);

                Property(c => c.Nome)
                    .HasMaxLength(100)
                    .IsRequired();

                Property(c => c.CEP)
                    .HasMaxLength(8)
                    .IsRequired();

                HasRequired(e => e.Estado)
                    .WithMany(c => c.Cidades)
                    .HasForeignKey(c => c.EstadoId);
        }
    }
}
