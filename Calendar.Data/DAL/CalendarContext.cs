using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Calendar.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Calendar.Data.DAL
{
    public class CalendarContext : DbContext
    {
        public CalendarContext() : base("CalendarContext")
        {
         
        }

        public DbSet<Month> Months { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}