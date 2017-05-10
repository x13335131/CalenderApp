namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Month", "random", c => c.Int(nullable: false));
            DropColumn("dbo.Month", "ran");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Month", "ran", c => c.Int(nullable: false));
            DropColumn("dbo.Month", "random");
        }
    }
}
