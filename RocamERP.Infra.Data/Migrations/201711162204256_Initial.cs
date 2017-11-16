namespace RocamERP.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banco",
                c => new
                    {
                        BancoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.BancoId);
            
            CreateTable(
                "dbo.Cheque",
                c => new
                    {
                        ChequeId = c.Int(nullable: false, identity: true),
                        BancoId = c.Int(nullable: false),
                        Agencia = c.String(),
                        ContaCorrente = c.String(),
                        NumeroCheque = c.String(),
                        PessoaId = c.Int(nullable: false),
                        Observacao = c.String(),
                        SituacaoCheque = c.Int(nullable: false),
                        DataRecebimento = c.DateTime(nullable: false),
                        DataVencimento = c.DateTime(nullable: false),
                        DataPagamento = c.DateTime(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ChequeId)
                .ForeignKey("dbo.Banco", t => t.BancoId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.BancoId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.PessoaId);
            
            CreateTable(
                "dbo.CadastroEstadual",
                c => new
                    {
                        CadastroEstadualId = c.Int(nullable: false),
                        NumeroDocumento = c.String(nullable: false, maxLength: 12),
                        TipoCadastroEstadual = c.Int(nullable: false),
                        PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CadastroEstadualId)
                .ForeignKey("dbo.Pessoa", t => t.CadastroEstadualId)
                .Index(t => t.CadastroEstadualId);
            
            CreateTable(
                "dbo.CadastroNacional",
                c => new
                    {
                        CadastroNacionalId = c.Int(nullable: false),
                        NumeroDocumento = c.String(nullable: false, maxLength: 14),
                        TipoCadastroNacional = c.Int(nullable: false),
                        PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CadastroNacionalId)
                .ForeignKey("dbo.Pessoa", t => t.CadastroNacionalId)
                .Index(t => t.CadastroNacionalId);
            
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        ContatoId = c.Int(nullable: false, identity: true),
                        Informacao = c.String(nullable: false, maxLength: 100),
                        Observacao = c.String(maxLength: 1000),
                        PessoaId = c.Int(nullable: false),
                        TipoContato = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContatoId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        Rua = c.String(nullable: false, maxLength: 50),
                        Bairro = c.String(nullable: false, maxLength: 30),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 50),
                        CEP = c.String(nullable: false, maxLength: 8),
                        CidadeId = c.Int(nullable: false),
                        PessoaId = c.Int(nullable: false),
                        TipoEndereco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Cidade", t => t.CidadeId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.CidadeId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        CidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CidadeId)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EstadoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Endereco", "CidadeId", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Contato", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Cheque", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.CadastroNacional", "CadastroNacionalId", "dbo.Pessoa");
            DropForeignKey("dbo.CadastroEstadual", "CadastroEstadualId", "dbo.Pessoa");
            DropForeignKey("dbo.Cheque", "BancoId", "dbo.Banco");
            DropIndex("dbo.Cidade", new[] { "EstadoId" });
            DropIndex("dbo.Endereco", new[] { "PessoaId" });
            DropIndex("dbo.Endereco", new[] { "CidadeId" });
            DropIndex("dbo.Contato", new[] { "PessoaId" });
            DropIndex("dbo.CadastroNacional", new[] { "CadastroNacionalId" });
            DropIndex("dbo.CadastroEstadual", new[] { "CadastroEstadualId" });
            DropIndex("dbo.Cheque", new[] { "PessoaId" });
            DropIndex("dbo.Cheque", new[] { "BancoId" });
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
            DropTable("dbo.Endereco");
            DropTable("dbo.Contato");
            DropTable("dbo.CadastroNacional");
            DropTable("dbo.CadastroEstadual");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Cheque");
            DropTable("dbo.Banco");
        }
    }
}
