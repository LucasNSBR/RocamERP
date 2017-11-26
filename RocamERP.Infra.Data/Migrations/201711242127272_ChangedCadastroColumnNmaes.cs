namespace RocamERP.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCadastroColumnNmaes : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pessoa", name: "CadastroEstadual_NumeroDocumento", newName: "CadastroEstadualNumeroDocumento");
            RenameColumn(table: "dbo.Pessoa", name: "CadastroEstadual_TipoCadastroEstadual", newName: "CadastroEstadualTipoDocumento");
            RenameColumn(table: "dbo.Pessoa", name: "CadastroNacional_NumeroDocumento", newName: "CadastroNacionalNumeroDocumento");
            RenameColumn(table: "dbo.Pessoa", name: "CadastroNacional_TipoCadastroNacional", newName: "CadastroNacionalTipoDocumento");
            AlterColumn("dbo.Pessoa", "CadastroEstadualNumeroDocumento", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.Pessoa", "CadastroNacionalNumeroDocumento", c => c.String(nullable: false, maxLength: 14));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoa", "CadastroNacionalNumeroDocumento", c => c.String());
            AlterColumn("dbo.Pessoa", "CadastroEstadualNumeroDocumento", c => c.String());
            RenameColumn(table: "dbo.Pessoa", name: "CadastroNacionalTipoDocumento", newName: "CadastroNacional_TipoCadastroNacional");
            RenameColumn(table: "dbo.Pessoa", name: "CadastroNacionalNumeroDocumento", newName: "CadastroNacional_NumeroDocumento");
            RenameColumn(table: "dbo.Pessoa", name: "CadastroEstadualTipoDocumento", newName: "CadastroEstadual_TipoCadastroEstadual");
            RenameColumn(table: "dbo.Pessoa", name: "CadastroEstadualNumeroDocumento", newName: "CadastroEstadual_NumeroDocumento");
        }
    }
}
