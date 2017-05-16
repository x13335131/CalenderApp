namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lineofcodeadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Organizer_ContactID", "dbo.Contacts");
            DropPrimaryKey("dbo.Contacts");
            AlterColumn("dbo.Contacts", "ContactID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Contacts", "ContactID");
            AddForeignKey("dbo.Appointments", "Organizer_ContactID", "dbo.Contacts", "ContactID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Organizer_ContactID", "dbo.Contacts");
            DropPrimaryKey("dbo.Contacts");
            AlterColumn("dbo.Contacts", "ContactID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contacts", "ContactID");
            AddForeignKey("dbo.Appointments", "Organizer_ContactID", "dbo.Contacts", "ContactID");
        }
    }
}
