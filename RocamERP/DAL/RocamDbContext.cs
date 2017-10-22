using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RocamERP.DAL
{
    public class RocamDbContext : DbContext
    {
        public DbSet<Models.Estado> Estados { get; set; }
        public DbSet<Models.Cidade> Cidades { get; set; }
        public DbSet<Models.Endereco> Enderecos { get; set; }

        public DbSet<Models.Banco> Bancos { get; set; }
        public DbSet<Models.Cheque> Cheques { get; set; }

        public DbSet<Models.Cliente> Clientes { get; set; }
        public DbSet<Models.Contato> Contatos { get; set; }

        public RocamDbContext() : base("RocamTests") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Models.ClientePessoaFisica>().ToTable("PessoaFisica");
            modelBuilder.Entity<Models.ClientePessoaJuridica>().ToTable("PessoaJuridica");

            //Configura a entidade cliente
            ConfigureBaseClienteEntity(modelBuilder);
            ConfigurePessoaFisicaClienteEntity(modelBuilder);
            ConfigurePessoaJuridicaClienteEntity(modelBuilder);

            //Configura a entidade cheque
            ConfigureChequeEntity(modelBuilder);

            //Configura a entidade endereço
            ConfigureEnderecoEntity(modelBuilder);

            //Configura a entidade cidade
            ConfigureCidadeEntiy(modelBuilder);

            //Configura a entidade estado
            ConfigureEstadoEntity(modelBuilder);

            //Configura a entidade contato
            ConfigureContatoEntity(modelBuilder);

            //configura a entidade banco
            ConfigureBancoEntity(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void ConfigureEstadoEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Estado>().HasKey(e => e.Nome);

            #region Properties
            modelBuilder.Entity<Models.Estado>()
                    .Property(e => e.Nome)
                    .HasMaxLength(20)
                    .IsRequired();
            #endregion
        }

        private static void ConfigureCidadeEntiy(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Cidade>().HasKey(c => c.Nome);

            #region Properties
            modelBuilder.Entity<Models.Cidade>()
                .Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Models.Cidade>()
                .Property(c => c.CEP)
                .HasMaxLength(8)
                .IsRequired();
            #endregion

            #region Relationships
            modelBuilder.Entity<Models.Cidade>()
                .HasRequired(e => e.Estado)
                .WithMany(c => c.Cidades)
                .HasForeignKey(c => c.EstadoId);
            #endregion
        }

        private static void ConfigureEnderecoEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Endereco>().HasKey(e => e.EnderecoId);

            #region Properties
            modelBuilder.Entity<Models.Endereco>()
                .Property(e => e.Numero)
                .IsRequired();

            modelBuilder.Entity<Models.Endereco>()
                .Property(e => e.Rua)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Models.Endereco>()
                .Property(e => e.Complemento)
                .HasMaxLength(50)
                .IsOptional();

            modelBuilder.Entity<Models.Endereco>()
                .Property(e => e.Bairro)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Models.Endereco>()
                .Property(e => e.TipoEndereco)
                .IsRequired();
            #endregion

            #region Relationships
            modelBuilder.Entity<Models.Endereco>()
                .HasRequired(e => e.Cidade)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.CidadeId);

            modelBuilder.Entity<Models.Endereco>()
                .HasRequired(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId);
            #endregion
        }

        private static void ConfigureBancoEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Banco>().HasKey(b => b.Nome);

            #region Properties
            modelBuilder.Entity<Models.Banco>()
                .Property(b => b.Nome)
                .HasMaxLength(100)
                .IsRequired();
            #endregion
        }

        private static void ConfigureChequeEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Cheque>().HasKey(c => c.ChequeId);

            #region Properties
            modelBuilder.Entity<Models.Cheque>()
                    .Property(ch => ch.Agencia)
                    .HasMaxLength(10)
                    .IsRequired();

            modelBuilder.Entity<Models.Cheque>()
                .Property(ch => ch.ContaCorrente)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Models.Cheque>()
                .Property(ch => ch.Observacao)
                .HasMaxLength(250)
                .IsRequired();

            modelBuilder.Entity<Models.Cheque>()
                .Property(ch => ch.Valor)
                .IsRequired();

            modelBuilder.Entity<Models.Cheque>()
                .Property(ch => ch.DataRecebimento)
                .IsRequired();

            modelBuilder.Entity<Models.Cheque>()
                .Property(ch => ch.DataVencimento)
                .IsRequired();

            modelBuilder.Entity<Models.Cheque>()
               .Property(ch => ch.SituacaoCheque)
               .IsRequired();
            #endregion

            #region Relationships
            modelBuilder.Entity<Models.Cheque>()
                .HasRequired(ch => ch.Banco)
                .WithMany(b => b.Cheques)
                .HasForeignKey(ch => ch.BancoId);

            modelBuilder.Entity<Models.Cheque>()
                .HasRequired(ch => ch.Cliente)
                .WithMany(c => c.Cheques)
                .HasForeignKey(ch => ch.ClienteId);
            #endregion
        }

        private static void ConfigureContatoEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Contato>().HasKey(c => c.ContatoId);

            #region Properties
            modelBuilder.Entity<Models.Contato>()
                .Property(c => c.Observacao)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Models.Contato>()
                .Property(c => c.TipoContato)
                .IsRequired();
            #endregion

            #region Relationships
            modelBuilder.Entity<Models.Contato>()
                .HasRequired(c => c.Cliente)
                .WithMany(co => co.Contatos)
                .HasForeignKey(c => c.ClienteId);
            #endregion
        }

        private static void ConfigureBaseClienteEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Cliente>().HasKey(c => c.ClienteId);

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

        private static void ConfigurePessoaJuridicaClienteEntity(DbModelBuilder modelBuilder)
        {
            #region Properties
            modelBuilder.Entity<Models.ClientePessoaJuridica>()
                .Property(pj => pj.CNPJ)
                .HasMaxLength(14)
                .IsOptional();

            modelBuilder.Entity<Models.ClientePessoaJuridica>()
                .Property(pj => pj.InscricaoEstadual)
                .HasMaxLength(9)
                .IsOptional();
            #endregion
        }

        private static void ConfigurePessoaFisicaClienteEntity(DbModelBuilder modelBuilder)
        {
            #region Properties
            modelBuilder.Entity<Models.ClientePessoaFisica>()
                    .Property(pf => pf.CPF)
                    .HasMaxLength(11)
                    .IsOptional();

            modelBuilder.Entity<Models.ClientePessoaFisica>()
                .Property(pf => pf.RG)
                .HasMaxLength(12)
                .IsOptional(); 
            #endregion
        }
    }
}