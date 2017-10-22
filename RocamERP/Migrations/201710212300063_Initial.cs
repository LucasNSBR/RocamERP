namespace RocamERP.Migrations
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
                        Nome = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.BancoId);
            
            CreateTable(
                "dbo.Cheque",
                c => new
                    {
                        ChequeId = c.Int(nullable: false, identity: true),
                        BancoId = c.Int(nullable: false),
                        Agencia = c.String(nullable: false, maxLength: 10),
                        ContaCorrente = c.String(nullable: false, maxLength: 10),
                        ClienteId = c.Int(nullable: false),
                        Observacao = c.String(nullable: false, maxLength: 250),
                        SituacaoCheque = c.Int(nullable: false),
                        DataRecebimento = c.DateTime(nullable: false),
                        DataVencimento = c.DateTime(nullable: false),
                        DataPagamento = c.DateTime(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ChequeId)
                .ForeignKey("dbo.Banco", t => t.BancoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.BancoId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        ContatoId = c.Int(nullable: false, identity: true),
                        Observacao = c.String(nullable: false, maxLength: 100),
                        ClienteId = c.Int(nullable: false),
                        TipoContato = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContatoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
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
                        ClienteId = c.Int(nullable: false),
                        TipoEndereco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Cidade", t => t.CidadeId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.CidadeId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        Nome = c.String(nullable: false, maxLength: 100),
                        CEP = c.String(nullable: false, maxLength: 8),
                        EstadoId = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Nome)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Nome = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Nome);
            
            CreateTable(
                "dbo.PessoaFisica",
                c => new
                    {
                        ClienteId = c.Int(nullable: false),
                        CPF = c.String(maxLength: 11),
                        RG = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.PessoaJuridica",
                c => new
                    {
                        ClienteId = c.Int(nullable: false),
                        CNPJ = c.String(maxLength: 14),
                        InscricaoEstadual = c.String(maxLength: 9),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PessoaJuridica", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.PessoaFisica", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Cheque", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Endereco", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Endereco", "CidadeId", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Contato", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Cheque", "BancoId", "dbo.Banco");
            DropIndex("dbo.PessoaJuridica", new[] { "ClienteId" });
            DropIndex("dbo.PessoaFisica", new[] { "ClienteId" });
            DropIndex("dbo.Cidade", new[] { "EstadoId" });
            DropIndex("dbo.Endereco", new[] { "ClienteId" });
            DropIndex("dbo.Endereco", new[] { "CidadeId" });
            DropIndex("dbo.Contato", new[] { "ClienteId" });
            DropIndex("dbo.Cheque", new[] { "ClienteId" });
            DropIndex("dbo.Cheque", new[] { "BancoId" });
            DropTable("dbo.PessoaJuridica");
            DropTable("dbo.PessoaFisica");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
            DropTable("dbo.Endereco");
            DropTable("dbo.Contato");
            DropTable("dbo.Cliente");
            DropTable("dbo.Cheque");
            DropTable("dbo.Banco");
        }
    }
}
