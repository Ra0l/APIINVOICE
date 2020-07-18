namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Details", "Client_UserID", "dbo.Users");
            DropIndex("dbo.Details", new[] { "Client_UserID" });
            RenameColumn(table: "dbo.Details", name: "Client_UserID", newName: "UserID");
            AlterColumn("dbo.Details", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Details", "UserID");
            AddForeignKey("dbo.Details", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            DropColumn("dbo.Details", "ClientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Details", "ClientID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Details", "UserID", "dbo.Users");
            DropIndex("dbo.Details", new[] { "UserID" });
            AlterColumn("dbo.Details", "UserID", c => c.Int());
            RenameColumn(table: "dbo.Details", name: "UserID", newName: "Client_UserID");
            CreateIndex("dbo.Details", "Client_UserID");
            AddForeignKey("dbo.Details", "Client_UserID", "dbo.Users", "UserID");
        }
    }
}
