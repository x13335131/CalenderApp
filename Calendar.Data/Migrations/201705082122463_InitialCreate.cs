namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        AppointmentID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        OrganizerID = c.Int(nullable: false),
                        Contact_ContactID = c.Int(),
                        Contact_ContactID1 = c.Int(),
                        Month_ID = c.Int(),
                        Organizer_ContactID = c.Int(),
                    })
                .PrimaryKey(t => t.AppointmentID)
                .ForeignKey("dbo.Contact", t => t.Contact_ContactID)
                .ForeignKey("dbo.Contact", t => t.Contact_ContactID1)
                .ForeignKey("dbo.Month", t => t.Month_ID)
                .ForeignKey("dbo.Contact", t => t.Organizer_ContactID)
                .Index(t => t.Contact_ContactID)
                .Index(t => t.Contact_ContactID1)
                .Index(t => t.Month_ID)
                .Index(t => t.Organizer_ContactID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Appointment_AppointmentID = c.Int(),
                    })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.Appointment", t => t.Appointment_AppointmentID)
                .Index(t => t.Appointment_AppointmentID);
            
            CreateTable(
                "dbo.Month",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MonthName = c.Int(),
                        AppointmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "Organizer_ContactID", "dbo.Contact");
            DropForeignKey("dbo.Appointment", "Month_ID", "dbo.Month");
            DropForeignKey("dbo.Appointment", "Contact_ContactID1", "dbo.Contact");
            DropForeignKey("dbo.Contact", "Appointment_AppointmentID", "dbo.Appointment");
            DropForeignKey("dbo.Appointment", "Contact_ContactID", "dbo.Contact");
            DropIndex("dbo.Contact", new[] { "Appointment_AppointmentID" });
            DropIndex("dbo.Appointment", new[] { "Organizer_ContactID" });
            DropIndex("dbo.Appointment", new[] { "Month_ID" });
            DropIndex("dbo.Appointment", new[] { "Contact_ContactID1" });
            DropIndex("dbo.Appointment", new[] { "Contact_ContactID" });
            DropTable("dbo.Month");
            DropTable("dbo.Contact");
            DropTable("dbo.Appointment");
        }
    }
}
