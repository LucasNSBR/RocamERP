using RocamERP.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RocamERP.Infra.Data.EntityConfiguration
{
    public class EntityConfigurationCheque : EntityTypeConfiguration<Cheque>
    {
        public EntityConfigurationCheque()
        {
            HasKey(c => c.ChequeId);

            Property(ch => ch.Agencia)
                    .HasMaxLength(10)
                    .IsRequired();

            Property(ch => ch.ContaCorrente)
                .HasMaxLength(10)
                .IsRequired();

            Property(ch => ch.NumeroCheque)
                .HasMaxLength(7)
                .IsRequired();

            Property(ch => ch.Observacao)
                .HasMaxLength(250)
                .IsOptional();

            Property(ch => ch.Valor)
                .IsRequired();

            Property(ch => ch.DataRecebimento)
                .IsRequired();

            Property(ch => ch.DataVencimento)
                .IsRequired();

            Property(ch => ch.SituacaoCheque)
               .IsRequired();

            HasRequired(ch => ch.Banco)
                .WithMany(b => b.Cheques)
                .HasForeignKey(ch => ch.BancoId);

            HasRequired(ch => ch.Pessoa)
                .WithMany(c => c.Cheques)
                .HasForeignKey(ch => ch.PessoaId);
        }
    }
}
