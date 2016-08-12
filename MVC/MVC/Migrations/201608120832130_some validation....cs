namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somevalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Apps", "AppName", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Apps", "AppName", c => c.String());
        }
    }
}
