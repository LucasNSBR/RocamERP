using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RocamERP.Domain.Models;
using RocamERP.Infra.Data.EntityConfiguration;
using RocamERP.Infra.Data.EntityConfiguration.ClienteConfiguration;

namespace RocamERP.Infra.Data
{
    public class RocamDbContext : DbContext
    {
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Cheque> Cheques { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        public RocamDbContext() : base("RocamData") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            modelBuilder.Configurations.Add(new EntityConfigurationClienteBase());
            modelBuilder.Configurations.Add(new EntityConfigurationClientePessoaJuridica());
            modelBuilder.Configurations.Add(new EntityConfigurationClientePessoaFisica());
            modelBuilder.Configurations.Add(new EntityConfigurationEstado());
            modelBuilder.Configurations.Add(new EntityConfigurationCidade());
            modelBuilder.Configurations.Add(new EntityConfigurationEndereco());
            modelBuilder.Configurations.Add(new EntityConfigurationBanco());
            modelBuilder.Configurations.Add(new EntityConfigurationContato());

            base.OnModelCreating(modelBuilder);
        }
    }
}