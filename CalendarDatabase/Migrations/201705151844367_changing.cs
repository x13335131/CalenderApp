namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Contact_ContactID", "dbo.Contacts");
            DropForeignKey("dbo.Appointments", "Contact_ContactID1", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "Appointment_AppointmentID", "dbo.Appointments");
            DropIndex("dbo.Appointments", new[] { "Contact_ContactID" });
            DropIndex("dbo.Appointments", new[] { "Contact_ContactID1" });
            AddColumn("dbo.Contacts", "AppointmentID", c => c.Int());
            AddColumn("dbo.Contacts", "Appointment_AppointmentID1", c => c.Int());
            CreateIndex("dbo.Contacts", "Appointment_AppointmentID1");
            AddForeignKey("dbo.Contacts", "Appointment_AppointmentID", "dbo.Appointments", "AppointmentID");
            AddForeignKey("dbo.Contacts", "Appointment_AppointmentID1", "dbo.Appointments", "AppointmentID");
            DropColumn("dbo.Appointments", "Contact_ContactID");
            DropColumn("dbo.Appointments", "Contact_ContactID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Contact_ContactID1", c => c.Int());
            AddColumn("dbo.Appointments", "Contact_ContactID", c => c.Int());
            DropForeignKey("dbo.Contacts", "Appointment_AppointmentID1", "dbo.Appointments");
            DropForeignKey("dbo.Contacts", "Appointment_AppointmentID", "dbo.Appointments");
            DropIndex("dbo.Contacts", new[] { "Appointment_AppointmentID1" });
            DropColumn("dbo.Contacts", "Appointment_AppointmentID1");
            DropColumn("dbo.Contacts", "AppointmentID");
            CreateIndex("dbo.Appointments", "Contact_ContactID1");
            CreateIndex("dbo.Appointments", "Contact_ContactID");
            AddForeignKey("dbo.Contacts", "Appointment_AppointmentID", "dbo.Appointments", "AppointmentID");
            AddForeignKey("dbo.Appointments", "Contact_ContactID1", "dbo.Contacts", "ContactID");
            AddForeignKey("dbo.Appointments", "Contact_ContactID", "dbo.Contacts", "ContactID");
        }
    }
}
