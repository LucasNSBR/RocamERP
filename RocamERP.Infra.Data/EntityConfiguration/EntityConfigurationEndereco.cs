using RocamERP.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RocamERP.Infra.Data.EntityConfiguration
{
    public class EntityConfigurationEndereco : EntityTypeConfiguration<Endereco>
    {
        public EntityConfigurationEndereco() : base()
        {
            HasKey(e => e.EnderecoId);
            
           Property(e => e.Numero)
                .IsRequired();

            Property(e => e.Rua)
                .HasMaxLength(50)
                .IsRequired();

            Property(e => e.Bairro)
                .HasMaxLength(30)
                .IsRequired();

            Property(e => e.Complemento)
                .HasMaxLength(50)
                .IsOptional();

            Property(c => c.CEP)
                .HasMaxLength(8)
                .IsRequired();

            Property(e => e.TipoEndereco)
                .IsRequired();

            HasRequired(e => e.Cidade)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.CidadeId);

            HasRequired(e => e.Pessoa)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.PessoaId);
        }
    }
}
