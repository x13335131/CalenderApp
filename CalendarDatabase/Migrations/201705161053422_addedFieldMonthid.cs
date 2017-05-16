namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFieldMonthid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Monthid_ID", c => c.Int());
            CreateIndex("dbo.Appointments", "Monthid_ID");
            AddForeignKey("dbo.Appointments", "Monthid_ID", "dbo.Months", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Monthid_ID", "dbo.Months");
            DropIndex("dbo.Appointments", new[] { "Monthid_ID" });
            DropColumn("dbo.Appointments", "Monthid_ID");
        }
    }
}
