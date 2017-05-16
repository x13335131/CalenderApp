namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "AppointmentID_AppointmentID", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "Contact_ContactID", "dbo.Contacts");
            DropForeignKey("dbo.Appointments", "Contact_ContactID1", "dbo.Contacts");
            DropForeignKey("dbo.Appointments", "Organizer_ContactID", "dbo.Contacts");
            DropIndex("dbo.Contacts", new[] { "AppointmentID_AppointmentID" });
            DropPrimaryKey("dbo.Contacts");
            AlterColumn("dbo.Contacts", "ContactID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contacts", "ContactID");
            AddForeignKey("dbo.Appointments", "Contact_ContactID", "dbo.Contacts", "ContactID");
            AddForeignKey("dbo.Appointments", "Contact_ContactID1", "dbo.Contacts", "ContactID");
            AddForeignKey("dbo.Appointments", "Organizer_ContactID", "dbo.Contacts", "ContactID");
            DropColumn("dbo.Contacts", "AppointmentID_AppointmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "AppointmentID_AppointmentID", c => c.Int());
            DropForeignKey("dbo.Appointments", "Organizer_ContactID", "dbo.Contacts");
            DropForeignKey("dbo.Appointments", "Contact_ContactID1", "dbo.Contacts");
            DropForeignKey("dbo.Appointments", "Contact_ContactID", "dbo.Contacts");
            DropPrimaryKey("dbo.Contacts");
            AlterColumn("dbo.Contacts", "ContactID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Contacts", "ContactID");
            CreateIndex("dbo.Contacts", "AppointmentID_AppointmentID");
            AddForeignKey("dbo.Appointments", "Organizer_ContactID", "dbo.Contacts", "ContactID");
            AddForeignKey("dbo.Appointments", "Contact_ContactID1", "dbo.Contacts", "ContactID");
            AddForeignKey("dbo.Appointments", "Contact_ContactID", "dbo.Contacts", "ContactID");
            AddForeignKey("dbo.Contacts", "AppointmentID_AppointmentID", "dbo.Appointments", "AppointmentID");
        }
    }
}
