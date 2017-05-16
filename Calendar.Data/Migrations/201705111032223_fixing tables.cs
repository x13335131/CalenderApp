namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingtables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "AptDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contact", "FName", c => c.String());
            AddColumn("dbo.Contact", "LName", c => c.String());
            AddColumn("dbo.Month", "AptMonth", c => c.Int());
            DropColumn("dbo.Appointment", "Date");
            DropColumn("dbo.Contact", "FirstName");
            DropColumn("dbo.Contact", "LastName");
            DropColumn("dbo.Month", "AptsMonth");
            DropColumn("dbo.Month", "random");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Month", "random", c => c.Int(nullable: false));
            AddColumn("dbo.Month", "AptsMonth", c => c.Int());
            AddColumn("dbo.Contact", "LastName", c => c.String());
            AddColumn("dbo.Contact", "FirstName", c => c.String());
            AddColumn("dbo.Appointment", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Month", "AptMonth");
            DropColumn("dbo.Contact", "LName");
            DropColumn("dbo.Contact", "FName");
            DropColumn("dbo.Appointment", "AptDate");
        }
    }
}
