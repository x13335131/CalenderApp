namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Months", "AppointmentID_AppointmentID", c => c.Int());
            CreateIndex("dbo.Months", "AppointmentID_AppointmentID");
            AddForeignKey("dbo.Months", "AppointmentID_AppointmentID", "dbo.Appointments", "AppointmentID");
            DropColumn("dbo.Months", "AppointmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Months", "AppointmentID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Months", "AppointmentID_AppointmentID", "dbo.Appointments");
            DropIndex("dbo.Months", new[] { "AppointmentID_AppointmentID" });
            DropColumn("dbo.Months", "AppointmentID_AppointmentID");
        }
    }
}
