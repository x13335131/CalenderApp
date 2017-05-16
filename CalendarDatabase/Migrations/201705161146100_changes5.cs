namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "NumMonth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "NumMonth");
        }
    }
}
