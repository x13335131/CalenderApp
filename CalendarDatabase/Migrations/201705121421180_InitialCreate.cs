namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentID = c.Int(nullable: false, identity: true),
                        AptDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        OrganizerID = c.Int(nullable: false),
                        Contact_ContactID = c.Int(),
                        Contact_ContactID1 = c.Int(),
                        Month_ID = c.Int(),
                        Organizer_ContactID = c.Int(),
                    })
                .PrimaryKey(t => t.AppointmentID)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactID)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactID1)
                .ForeignKey("dbo.Months", t => t.Month_ID)
                .ForeignKey("dbo.Contacts", t => t.Organizer_ContactID)
                .Index(t => t.Contact_ContactID)
                .Index(t => t.Contact_ContactID1)
                .Index(t => t.Month_ID)
                .Index(t => t.Organizer_ContactID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Appointment_AppointmentID = c.Int(),
                    })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.Appointments", t => t.Appointment_AppointmentID)
                .Index(t => t.Appointment_AppointmentID);
            
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AptMonth = c.Int(),
                        AppointmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Organizer_ContactID", "dbo.Contacts");
            DropForeignKey("dbo.Appointments", "Month_ID", "dbo.Months");
            DropForeignKey("dbo.Appointments", "Contact_ContactID1", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "Appointment_AppointmentID", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "Contact_ContactID", "dbo.Contacts");
            DropIndex("dbo.Contacts", new[] { "Appointment_AppointmentID" });
            DropIndex("dbo.Appointments", new[] { "Organizer_ContactID" });
            DropIndex("dbo.Appointments", new[] { "Month_ID" });
            DropIndex("dbo.Appointments", new[] { "Contact_ContactID1" });
            DropIndex("dbo.Appointments", new[] { "Contact_ContactID" });
            DropTable("dbo.Months");
            DropTable("dbo.Contacts");
            DropTable("dbo.Appointments");
        }
    }
}
