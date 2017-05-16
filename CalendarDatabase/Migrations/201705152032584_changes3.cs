namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Month_ID", "dbo.Months");
            AddColumn("dbo.Appointments", "Contact_ContactID", c => c.Int());
            AddColumn("dbo.Appointments", "Month_ID1", c => c.Int());
            AddColumn("dbo.Months", "AppointmentIdentity_AppointmentID", c => c.Int());
            AddColumn("dbo.Months", "Appointment_AppointmentID", c => c.Int());
            CreateIndex("dbo.Appointments", "Contact_ContactID");
            CreateIndex("dbo.Appointments", "Month_ID1");
            CreateIndex("dbo.Months", "AppointmentIdentity_AppointmentID");
            CreateIndex("dbo.Months", "Appointment_AppointmentID");
            AddForeignKey("dbo.Appointments", "Contact_ContactID", "dbo.Contacts", "ContactID");
            AddForeignKey("dbo.Months", "AppointmentIdentity_AppointmentID", "dbo.Appointments", "AppointmentID");
            AddForeignKey("dbo.Months", "Appointment_AppointmentID", "dbo.Appointments", "AppointmentID");
            AddForeignKey("dbo.Appointments", "Month_ID1", "dbo.Months", "ID");
            DropColumn("dbo.Contacts", "AppointmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "AppointmentID", c => c.Int());
            DropForeignKey("dbo.Appointments", "Month_ID1", "dbo.Months");
            DropForeignKey("dbo.Months", "Appointment_AppointmentID", "dbo.Appointments");
            DropForeignKey("dbo.Months", "AppointmentIdentity_AppointmentID", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "Contact_ContactID", "dbo.Contacts");
            DropIndex("dbo.Months", new[] { "Appointment_AppointmentID" });
            DropIndex("dbo.Months", new[] { "AppointmentIdentity_AppointmentID" });
            DropIndex("dbo.Appointments", new[] { "Month_ID1" });
            DropIndex("dbo.Appointments", new[] { "Contact_ContactID" });
            DropColumn("dbo.Months", "Appointment_AppointmentID");
            DropColumn("dbo.Months", "AppointmentIdentity_AppointmentID");
            DropColumn("dbo.Appointments", "Month_ID1");
            DropColumn("dbo.Appointments", "Contact_ContactID");
            AddForeignKey("dbo.Appointments", "Month_ID", "dbo.Months", "ID");
        }
    }
}
