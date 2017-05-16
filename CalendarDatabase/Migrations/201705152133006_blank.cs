namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blank : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Appointments", name: "Month_ID1", newName: "MonthIdentity_ID");
            RenameIndex(table: "dbo.Appointments", name: "IX_Month_ID1", newName: "IX_MonthIdentity_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Appointments", name: "IX_MonthIdentity_ID", newName: "IX_Month_ID1");
            RenameColumn(table: "dbo.Appointments", name: "MonthIdentity_ID", newName: "Month_ID1");
        }
    }
}
