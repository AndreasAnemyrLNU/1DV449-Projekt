namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmodelGrainOfGold : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RadinOfGolds", newName: "GrainOfGols");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.GrainOfGols", newName: "RadinOfGolds");
        }
    }
}
