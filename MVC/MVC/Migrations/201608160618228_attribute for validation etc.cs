namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attributeforvalidationetc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
