namespace FinalProject_ADONET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Login", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Accounts", "Passw", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Books", "BookName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Books", "Publisher", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Books", "CostPrice", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Books", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Books", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Books", "CostPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Books", "Publisher", c => c.String());
            AlterColumn("dbo.Books", "Author", c => c.String());
            AlterColumn("dbo.Books", "BookName", c => c.String());
            AlterColumn("dbo.Accounts", "Passw", c => c.String());
            AlterColumn("dbo.Accounts", "Login", c => c.String());
        }
    }
}
