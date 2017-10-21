using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RocamERP.DAL
{
    public class RocamDbContext : DbContext
    {
        public RocamDbContext() : base("name=RocamDbConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Models.ClientePessoaFisica>().ToTable("PessoaFisica");
            modelBuilder.Entity<Models.ClientePessoaJuridica>().ToTable("PessoaJuridica");

            ConfigureBaseClienteEntity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void ConfigureBaseClienteEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Cliente>().HasKey(c => c.ClienteId);

            #region Relationships
            modelBuilder.Entity<Models.Cliente>()
                .HasMany(c => c.Cheques)
                .WithRequired(ch => ch.Cliente)
                .HasForeignKey(ch => ch.ClienteId);

            modelBuilder.Entity<Models.Cliente>()
                .HasMany(c => c.Contatos)
                .WithRequired(co => co.Cliente)
                .HasForeignKey(co => co.ClienteId);

            modelBuilder.Entity<Models.Cliente>()
                .HasMany(c => c.Enderecos)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId);
            #endregion

            #region Properties
            modelBuilder.Entity<Models.Cliente>()
                .Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Models.Cliente>()
                 .Property(c => c.Descricao)
                 .HasMaxLength(1000)
                 .IsOptional();
            #endregion
        }

        private static void ConfigurePessoaFisicaCliente()
        {

        }
    }
}