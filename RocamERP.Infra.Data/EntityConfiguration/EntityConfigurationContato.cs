using RocamERP.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RocamERP.Infra.Data.EntityConfiguration
{
    public class EntityConfigurationContato : EntityTypeConfiguration<Contato>
    {
        public EntityConfigurationContato() : base()
        {
            HasKey(c => c.ContatoId);

            Property(c => c.Observacao)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.TipoContato)
                .IsRequired();

            HasRequired(c => c.Pessoa)
                .WithMany(co => co.Contatos)
                .HasForeignKey(c => c.PessoaId);
        }
    }
}
