namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "FirstName", c => c.String());
            AddColumn("dbo.Contact", "LastName", c => c.String());
            AddColumn("dbo.Contact", "Ran", c => c.String());
            DropColumn("dbo.Contact", "FName");
            DropColumn("dbo.Contact", "LName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "LName", c => c.String());
            AddColumn("dbo.Contact", "FName", c => c.String());
            DropColumn("dbo.Contact", "Ran");
            DropColumn("dbo.Contact", "LastName");
            DropColumn("dbo.Contact", "FirstName");
        }
    }
}
