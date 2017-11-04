using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RocamERP.Domain.Models;
using RocamERP.Infra.Data.EntityConfiguration;

namespace RocamERP.Infra.Data
{
    public class RocamDbContext : DbContext
    {
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Cheque> Cheques { get; set; }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        public DbSet<CadastroEstadual> CadastroEstadual { get; set; }
        public DbSet<CadastroNacional> CadastroNacional { get; set; }

        public RocamDbContext() : base("name=RocamDb") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            modelBuilder.Configurations.Add(new EntityConfigurationPesoa());
            modelBuilder.Configurations.Add(new EntityConfigurationEstado());
            modelBuilder.Configurations.Add(new EntityConfigurationCidade());
            modelBuilder.Configurations.Add(new EntityConfigurationEndereco());
            modelBuilder.Configurations.Add(new EntityConfigurationBanco());
            modelBuilder.Configurations.Add(new EntityConfigurationContato());
            modelBuilder.Configurations.Add(new EntityConfigurationCadastroEstadual());
            modelBuilder.Configurations.Add(new EntityConfigurationCadastroNacional());

            base.OnModelCreating(modelBuilder);
        }
    }
}