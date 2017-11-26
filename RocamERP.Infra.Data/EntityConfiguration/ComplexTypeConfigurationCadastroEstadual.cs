using RocamERP.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RocamERP.Infra.Data.EntityConfiguration
{
    public class ComplexTypeConfigurationCadastroEstadual : ComplexTypeConfiguration<CadastroEstadual>
    {
        public ComplexTypeConfigurationCadastroEstadual()
        {
            Property(ce => ce.NumeroDocumento)
                .HasMaxLength(13)
                .IsRequired()
                .HasColumnName("CadastroEstadualNumeroDocumento");

            Property(cn => cn.TipoCadastroEstadual)
                .IsRequired()
                .HasColumnName("CadastroEstadualTipoDocumento");
        }
    }
}
