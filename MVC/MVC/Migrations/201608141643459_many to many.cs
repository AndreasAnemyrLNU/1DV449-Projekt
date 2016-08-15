namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "App_Id", "dbo.Apps");
            DropIndex("dbo.Categories", new[] { "App_Id" });
            CreateTable(
                "dbo.CategoryApps",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        App_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.App_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Apps", t => t.App_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.App_Id);
            
            DropColumn("dbo.Categories", "App_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "App_Id", c => c.Int());
            DropForeignKey("dbo.CategoryApps", "App_Id", "dbo.Apps");
            DropForeignKey("dbo.CategoryApps", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryApps", new[] { "App_Id" });
            DropIndex("dbo.CategoryApps", new[] { "Category_Id" });
            DropTable("dbo.CategoryApps");
            CreateIndex("dbo.Categories", "App_Id");
            AddForeignKey("dbo.Categories", "App_Id", "dbo.Apps", "Id");
        }
    }
}
