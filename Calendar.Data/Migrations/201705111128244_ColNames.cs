namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "FirstName", c => c.String());
            DropColumn("dbo.Contact", "FName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "FName", c => c.String());
            DropColumn("dbo.Contact", "FirstName");
        }
    }
}
