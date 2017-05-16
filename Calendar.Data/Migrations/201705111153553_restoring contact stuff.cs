namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restoringcontactstuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactID = c.Int(nullable: false),
                        FName = c.String(),
                        LName = c.String(),
                        Email = c.String(),
                        Appointment_AppointmentID = c.Int(),
                    })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.Appointment", t => t.Appointment_AppointmentID)
                .Index(t => t.Appointment_AppointmentID);
            
            AddColumn("dbo.Appointment", "Contact_ContactID", c => c.Int());
            AddColumn("dbo.Appointment", "Contact_ContactID1", c => c.Int());
            AddColumn("dbo.Appointment", "Organizer_ContactID", c => c.Int());
            CreateIndex("dbo.Appointment", "Contact_ContactID");
            CreateIndex("dbo.Appointment", "Contact_ContactID1");
            CreateIndex("dbo.Appointment", "Organizer_ContactID");
            AddForeignKey("dbo.Appointment", "Contact_ContactID", "dbo.Contact", "ContactID");
            AddForeignKey("dbo.Appointment", "Contact_ContactID1", "dbo.Contact", "ContactID");
            AddForeignKey("dbo.Appointment", "Organizer_ContactID", "dbo.Contact", "ContactID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "Organizer_ContactID", "dbo.Contact");
            DropForeignKey("dbo.Appointment", "Contact_ContactID1", "dbo.Contact");
            DropForeignKey("dbo.Contact", "Appointment_AppointmentID", "dbo.Appointment");
            DropForeignKey("dbo.Appointment", "Contact_ContactID", "dbo.Contact");
            DropIndex("dbo.Contact", new[] { "Appointment_AppointmentID" });
            DropIndex("dbo.Appointment", new[] { "Organizer_ContactID" });
            DropIndex("dbo.Appointment", new[] { "Contact_ContactID1" });
            DropIndex("dbo.Appointment", new[] { "Contact_ContactID" });
            DropColumn("dbo.Appointment", "Organizer_ContactID");
            DropColumn("dbo.Appointment", "Contact_ContactID1");
            DropColumn("dbo.Appointment", "Contact_ContactID");
            DropTable("dbo.Contact");
        }
    }
}
