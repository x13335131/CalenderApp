namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreChanges : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Appointments", name: "Monthid_ID", newName: "MonthNum_ID");
            RenameIndex(table: "dbo.Appointments", name: "IX_Monthid_ID", newName: "IX_MonthNum_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Appointments", name: "IX_MonthNum_ID", newName: "IX_Monthid_ID");
            RenameColumn(table: "dbo.Appointments", name: "MonthNum_ID", newName: "Monthid_ID");
        }
    }
}
