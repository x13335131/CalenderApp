namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingcontacts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointment", "Contact_ContactID", "dbo.Contact");
            DropForeignKey("dbo.Appointment", "Contact_ContactID1", "dbo.Contact");
            DropForeignKey("dbo.Appointment", "Organizer_ContactID", "dbo.Contact");
            DropPrimaryKey("dbo.Contact");
            AlterColumn("dbo.Contact", "ContactID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Contact", "ContactID");
            AddForeignKey("dbo.Appointment", "Contact_ContactID", "dbo.Contact", "ContactID");
            AddForeignKey("dbo.Appointment", "Contact_ContactID1", "dbo.Contact", "ContactID");
            AddForeignKey("dbo.Appointment", "Organizer_ContactID", "dbo.Contact", "ContactID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "Organizer_ContactID", "dbo.Contact");
            DropForeignKey("dbo.Appointment", "Contact_ContactID1", "dbo.Contact");
            DropForeignKey("dbo.Appointment", "Contact_ContactID", "dbo.Contact");
            DropPrimaryKey("dbo.Contact");
            AlterColumn("dbo.Contact", "ContactID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contact", "ContactID");
            AddForeignKey("dbo.Appointment", "Organizer_ContactID", "dbo.Contact", "ContactID");
            AddForeignKey("dbo.Appointment", "Contact_ContactID1", "dbo.Contact", "ContactID");
            AddForeignKey("dbo.Appointment", "Contact_ContactID", "dbo.Contact", "ContactID");
        }
    }
}
