namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemonthdatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Months", "AptMonth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Months", "AptMonth", c => c.Int());
        }
    }
}
