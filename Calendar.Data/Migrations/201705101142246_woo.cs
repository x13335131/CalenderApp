namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class woo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Month", "AptsMonth", c => c.Int());
            AddColumn("dbo.Month", "ran", c => c.Int(nullable: false));
            DropColumn("dbo.Month", "MonthName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Month", "MonthName", c => c.Int());
            DropColumn("dbo.Month", "ran");
            DropColumn("dbo.Month", "AptsMonth");
        }
    }
}
