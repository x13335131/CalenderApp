namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingcontactstuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointment", "Contact_ContactID", "dbo.Contact");
            DropForeignKey("dbo.Contact", "Appointment_AppointmentID", "dbo.Appointment");
            DropForeignKey("dbo.Appointment", "Contact_ContactID1", "dbo.Contact");
            DropForeignKey("dbo.Appointment", "Organizer_ContactID", "dbo.Contact");
            DropIndex("dbo.Appointment", new[] { "Contact_ContactID" });
            DropIndex("dbo.Appointment", new[] { "Contact_ContactID1" });
            DropIndex("dbo.Appointment", new[] { "Organizer_ContactID" });
            DropIndex("dbo.Contact", new[] { "Appointment_AppointmentID" });
            DropColumn("dbo.Appointment", "Contact_ContactID");
            DropColumn("dbo.Appointment", "Contact_ContactID1");
            DropColumn("dbo.Appointment", "Organizer_ContactID");
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LName = c.String(),
                        Email = c.String(),
                        Appointment_AppointmentID = c.Int(),
                    })
                .PrimaryKey(t => t.ContactID);
            
            AddColumn("dbo.Appointment", "Organizer_ContactID", c => c.Int());
            AddColumn("dbo.Appointment", "Contact_ContactID1", c => c.Int());
            AddColumn("dbo.Appointment", "Contact_ContactID", c => c.Int());
            CreateIndex("dbo.Contact", "Appointment_AppointmentID");
            CreateIndex("dbo.Appointment", "Organizer_ContactID");
            CreateIndex("dbo.Appointment", "Contact_ContactID1");
            CreateIndex("dbo.Appointment", "Contact_ContactID");
            AddForeignKey("dbo.Appointment", "Organizer_ContactID", "dbo.Contact", "ContactID");
            AddForeignKey("dbo.Appointment", "Contact_ContactID1", "dbo.Contact", "ContactID");
            AddForeignKey("dbo.Contact", "Appointment_AppointmentID", "dbo.Appointment", "AppointmentID");
            AddForeignKey("dbo.Appointment", "Contact_ContactID", "dbo.Contact", "ContactID");
        }
    }
}
