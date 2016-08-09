namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedmodelGrainOfGoldagain : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GrainOfGols", newName: "GrainOfGolds");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.GrainOfGolds", newName: "GrainOfGols");
        }
    }
}
