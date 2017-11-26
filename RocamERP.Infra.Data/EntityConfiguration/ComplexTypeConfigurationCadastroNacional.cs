using RocamERP.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RocamERP.Infra.Data.EntityConfiguration
{
    public class ComplexTypeConfigurationCadastroNacional : ComplexTypeConfiguration<CadastroNacional>
    {
        public ComplexTypeConfigurationCadastroNacional()
        {
            Property(cn => cn.NumeroDocumento)
                .HasMaxLength(14)
                .IsRequired()
                .HasColumnName("CadastroNacionalNumeroDocumento");

            Property(cn => cn.TipoCadastroNacional)
                .IsRequired()
                .HasColumnName("CadastroNacionalTipoDocumento");
        }
    }
}
