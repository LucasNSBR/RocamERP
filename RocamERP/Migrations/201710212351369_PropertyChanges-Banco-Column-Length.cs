namespace RocamERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyChangesBancoColumnLength : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cheque", "BancoId", "dbo.Banco");
            DropIndex("dbo.Cheque", new[] { "BancoId" });
            DropPrimaryKey("dbo.Banco");
            AlterColumn("dbo.Banco", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Cheque", "BancoId", c => c.String(nullable: false, maxLength: 100));
            AddPrimaryKey("dbo.Banco", "Nome");
            CreateIndex("dbo.Cheque", "BancoId");
            AddForeignKey("dbo.Cheque", "BancoId", "dbo.Banco", "Nome");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cheque", "BancoId", "dbo.Banco");
            DropIndex("dbo.Cheque", new[] { "BancoId" });
            DropPrimaryKey("dbo.Banco");
            AlterColumn("dbo.Cheque", "BancoId", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Banco", "Nome", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.Banco", "Nome");
            CreateIndex("dbo.Cheque", "BancoId");
            AddForeignKey("dbo.Cheque", "BancoId", "dbo.Banco", "Nome");
        }
    }
}
