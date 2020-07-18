namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CreatedBy", c => c.String());
            AddColumn("dbo.Products", "ModifiedBy", c => c.String());
            AddColumn("dbo.Products", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Enable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Enable");
            DropColumn("dbo.Products", "ModifiedOn");
            DropColumn("dbo.Products", "CreatedOn");
            DropColumn("dbo.Products", "ModifiedBy");
            DropColumn("dbo.Products", "CreatedBy");
        }
    }
}
