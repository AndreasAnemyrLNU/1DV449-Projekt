namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmodeltobemoregenericforseveralapps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categories", "App_Id", c => c.Int());
            CreateIndex("dbo.Categories", "App_Id");
            AddForeignKey("dbo.Categories", "App_Id", "dbo.Apps", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "App_Id", "dbo.Apps");
            DropIndex("dbo.Categories", new[] { "App_Id" });
            DropColumn("dbo.Categories", "App_Id");
            DropTable("dbo.Apps");
        }
    }
}
