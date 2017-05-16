namespace CalendarDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trialanderror : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Months", "Appointment_AppointmentID", "dbo.Appointments");
            AddColumn("dbo.Months", "Appointment_AppointmentID1", c => c.Int());
            CreateIndex("dbo.Months", "Appointment_AppointmentID1");
            AddForeignKey("dbo.Months", "Appointment_AppointmentID", "dbo.Appointments", "AppointmentID");
            AddForeignKey("dbo.Months", "Appointment_AppointmentID1", "dbo.Appointments", "AppointmentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Months", "Appointment_AppointmentID1", "dbo.Appointments");
            DropForeignKey("dbo.Months", "Appointment_AppointmentID", "dbo.Appointments");
            DropIndex("dbo.Months", new[] { "Appointment_AppointmentID1" });
            DropColumn("dbo.Months", "Appointment_AppointmentID1");
            AddForeignKey("dbo.Months", "Appointment_AppointmentID", "dbo.Appointments", "AppointmentID");
        }
    }
}
