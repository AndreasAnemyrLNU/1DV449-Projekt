namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeofmodel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MyEntities", newName: "MyNewEntities");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MyNewEntities", newName: "MyEntities");
        }
    }
}
