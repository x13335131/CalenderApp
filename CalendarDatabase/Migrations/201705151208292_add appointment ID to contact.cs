namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addappointmentIDtocontact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "AppointmentID_AppointmentID", c => c.Int());
            CreateIndex("dbo.Contacts", "AppointmentID_AppointmentID");
            AddForeignKey("dbo.Contacts", "AppointmentID_AppointmentID", "dbo.Appointments", "AppointmentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "AppointmentID_AppointmentID", "dbo.Appointments");
            DropIndex("dbo.Contacts", new[] { "AppointmentID_AppointmentID" });
            DropColumn("dbo.Contacts", "AppointmentID_AppointmentID");
        }
    }
}
