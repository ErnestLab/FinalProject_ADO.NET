namespace FinalProject_ADONET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration_UpdateClassAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "FIO", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Accounts", "Phone", c => c.Long(nullable: false));
            AddColumn("dbo.Accounts", "Email", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Email");
            DropColumn("dbo.Accounts", "Phone");
            DropColumn("dbo.Accounts", "FIO");
        }
    }
}
