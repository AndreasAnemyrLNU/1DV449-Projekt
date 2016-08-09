namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmodelGrainOfGold : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MyNewEntities", newName: "RadinOfGolds");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RadinOfGolds", newName: "MyNewEntities");
        }
    }
}
