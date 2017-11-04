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
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Nome);
            
            CreateTable(
                "dbo.Cheque",
                c => new
                    {
                        ChequeId = c.Int(nullable: false, identity: true),
                        BancoId = c.String(),
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
                        Banco_Nome = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ChequeId)
                .ForeignKey("dbo.Banco", t => t.Banco_Nome)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId)
                .Index(t => t.Banco_Nome);
            
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
                        NumeroDocumento = c.String(nullable: false, maxLength: 12),
                        TipoCadastroEstadual = c.Int(nullable: false),
                        PessoaId = c.Int(nullable: false),
                        Pessoa_PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumeroDocumento)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_PessoaId)
                .Index(t => t.Pessoa_PessoaId);
            
            CreateTable(
                "dbo.CadastroNacional",
                c => new
                    {
                        NumeroDocumento = c.String(nullable: false, maxLength: 14),
                        TipoCadastroNacional = c.Int(nullable: false),
                        PessoaId = c.Int(nullable: false),
                        Pessoa_PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumeroDocumento)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_PessoaId)
                .Index(t => t.Pessoa_PessoaId);
            
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        ContatoId = c.Int(nullable: false, identity: true),
                        Observacao = c.String(nullable: false, maxLength: 100),
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
                        CidadeId = c.String(nullable: false, maxLength: 100),
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
                        Nome = c.String(nullable: false, maxLength: 100),
                        CEP = c.String(nullable: false, maxLength: 8),
                        EstadoId = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Nome)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Nome);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Endereco", "CidadeId", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Contato", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Cheque", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.CadastroNacional", "Pessoa_PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.CadastroEstadual", "Pessoa_PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Cheque", "Banco_Nome", "dbo.Banco");
            DropIndex("dbo.Cidade", new[] { "EstadoId" });
            DropIndex("dbo.Endereco", new[] { "PessoaId" });
            DropIndex("dbo.Endereco", new[] { "CidadeId" });
            DropIndex("dbo.Contato", new[] { "PessoaId" });
            DropIndex("dbo.CadastroNacional", new[] { "Pessoa_PessoaId" });
            DropIndex("dbo.CadastroEstadual", new[] { "Pessoa_PessoaId" });
            DropIndex("dbo.Cheque", new[] { "Banco_Nome" });
            DropIndex("dbo.Cheque", new[] { "PessoaId" });
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
