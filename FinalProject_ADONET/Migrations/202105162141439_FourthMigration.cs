namespace FinalProject_ADONET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Accounts", "TypeAccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "TypeAccountId");
            AddForeignKey("dbo.Accounts", "TypeAccountId", "dbo.TypeAccounts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "TypeAccountId", "dbo.TypeAccounts");
            DropIndex("dbo.Accounts", new[] { "TypeAccountId" });
            DropColumn("dbo.Accounts", "TypeAccountId");
            DropTable("dbo.TypeAccounts");
        }
    }
}
