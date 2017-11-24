namespace RocamERP.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ObservacaoEndereco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Endereco", "Observacao", c => c.String());
            AlterColumn("dbo.Endereco", "Complemento", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Endereco", "Complemento", c => c.String(maxLength: 50));
            DropColumn("dbo.Endereco", "Observacao");
        }
    }
}
