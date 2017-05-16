using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Calendar.Data.Models;

namespace Calendar.Data.DAL
{
    public class CalendarInitializer : System.Data.Entity.CreateDatabaseIfNotExists<CalendarContext>
    {
        protected override void Seed(CalendarContext context)
        {
             var months = new List<Month>
            {
            new Month{ID=1, AptMonth=MonthName.Jan, AppointmentID=1 },
            new Month{ID=2, AptMonth=MonthName.Feb, AppointmentID=2 },
            new Month{ID=3, AptMonth=MonthName.March, AppointmentID=3 },
            new Month{ID=4, AptMonth=MonthName.April, AppointmentID=4 },
            new Month{ID=5, AptMonth=MonthName.May, AppointmentID=5 },
            new Month{ID=6, AptMonth=MonthName.June, AppointmentID=6 },
            new Month{ID=7, AptMonth=MonthName.July, AppointmentID=7 },
            new Month{ID=8, AptMonth=MonthName.Aug, AppointmentID=8 }
            };

            months.ForEach(s => context.Months.Add(s));
            context.SaveChanges();

            var contacts = new List<Contact>
            {
            new Contact{ContactID=1050,Email="MaryJ@hotmail.com", FirstName="Mary",LastName="Jones", Ran="test" ,},
            new Contact{ContactID=4022,FirstName="Sara",LastName="Williams", Email="Sarawil@yahoo.com",},
            new Contact{ContactID=4041,FirstName="Rodger",LastName="Banks", Email="BanksR@hotmail.com",},
            new Contact{ContactID=1045,FirstName="James",LastName="Cunningham", Email="JC123@hotmail.com",},
            new Contact{ContactID=3141,FirstName="Mark",LastName="Conroy", Email="marko@gmail.com",},
            new Contact{ContactID=2021,FirstName="Richard",LastName="Dunne", Email="RichardDunne@hotmail.com",},
            new Contact{ContactID=2022,FirstName="Richie",LastName="Davis", Email="RichieD@hotmail.com",},
            new Contact{ContactID=2042,FirstName="Caroline",LastName="Mcdevitt", Email="CaroMcd@gmail.com",},
             new Contact{ContactID=2049,FirstName="Mary",LastName="Ryan", Email="MR@gmail.com",}
            };
            contacts.ForEach(s => context.Contacts.Add(s));
            context.SaveChanges();

            var appointments = new List<Appointment>
            {
            new Appointment{AppointmentID=1,AptDate=DateTime.Parse("2017-01-01"), Description="meeting jimmy", OrganizerID=1 ,},
            new Appointment{AppointmentID=2,AptDate=DateTime.Parse("2017-03-10"), Description="football", OrganizerID=1 ,}
            };
            appointments.ForEach(s => context.Appointments.Add(s));
            context.SaveChanges();
        }
    }
}