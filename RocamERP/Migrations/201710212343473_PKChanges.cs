namespace RocamERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PKChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cheque", "BancoId", "dbo.Banco");
            DropIndex("dbo.Cheque", new[] { "BancoId" });
            DropPrimaryKey("dbo.Banco");
            AlterColumn("dbo.Cheque", "BancoId", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.Banco", "Nome");
            CreateIndex("dbo.Cheque", "BancoId");
            AddForeignKey("dbo.Cheque", "BancoId", "dbo.Banco", "Nome");
            DropColumn("dbo.Banco", "BancoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banco", "BancoId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Cheque", "BancoId", "dbo.Banco");
            DropIndex("dbo.Cheque", new[] { "BancoId" });
            DropPrimaryKey("dbo.Banco");
            AlterColumn("dbo.Cheque", "BancoId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Banco", "BancoId");
            CreateIndex("dbo.Cheque", "BancoId");
            AddForeignKey("dbo.Cheque", "BancoId", "dbo.Banco", "BancoId");
        }
    }
}
