namespace RocamERP.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodigoCompensacaoBanco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banco", "CodigoCompensacao", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banco", "CodigoCompensacao");
        }
    }
}
