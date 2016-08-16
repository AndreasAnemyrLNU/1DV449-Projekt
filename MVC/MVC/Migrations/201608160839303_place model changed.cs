namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class placemodelchanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Places", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Places", new[] { "Category_Id" });
            CreateTable(
                "dbo.PlaceCategories",
                c => new
                    {
                        Place_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Place_Id, t.Category_Id })
                .ForeignKey("dbo.Places", t => t.Place_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Place_Id)
                .Index(t => t.Category_Id);
            
            AlterColumn("dbo.Places", "Name", c => c.String(nullable: false, maxLength: 25));
            DropColumn("dbo.Places", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Places", "Category_Id", c => c.Int());
            DropForeignKey("dbo.PlaceCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.PlaceCategories", "Place_Id", "dbo.Places");
            DropIndex("dbo.PlaceCategories", new[] { "Category_Id" });
            DropIndex("dbo.PlaceCategories", new[] { "Place_Id" });
            AlterColumn("dbo.Places", "Name", c => c.String());
            DropTable("dbo.PlaceCategories");
            CreateIndex("dbo.Places", "Category_Id");
            AddForeignKey("dbo.Places", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
