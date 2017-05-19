using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
namespace CalendarDatabase
{
    class Program
    {
       public int count = 0;
        
        static void Main(string[] args)
        {
           
            using (var db = new CalenderDataContext())
            {
                // Create and save a new description
                Console.Write("Enter a description for a new Appointment: ");
                var description = Console.ReadLine();

                //enter date
                Console.Write("Enter a date for your appointment: ");
                Console.Write("Enter day: (DD:) ");
                int dd = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter month (MM): ");
                int  mm = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter year (YYYY): ");
                int yyyy = Convert.ToInt32(Console.ReadLine());
                DateTime date = new DateTime(yyyy, mm, dd);

                //enter organizer name
                Console.WriteLine("Organiser name: ");
                Console.Write("Enter your first name: ");
                var fname = Console.ReadLine();
                Console.Write("Enter your surname: ");
                var lname = Console.ReadLine();
                Console.Write("Enter your Id number: ");
                int organiserid = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your email: ");
                var email = Console.ReadLine();
                Program p = new Program();
                Contact organizer = new Contact { ContactID = p.contactID() , FirstName =fname, LastName=lname, Email=email};

                //construct month
                int aptmonth = mm;
                Month monthNum = new Month { AptMonth =aptmonth};
                //construct appointment
                var appointment = new Appointment { Description = description, AptDate = date,OrganizerID=organiserid, Organizer = organizer,  NumMonth=aptmonth, MonthNum=monthNum };
                db.Appointments.Add(appointment);
                db.SaveChanges();

                // Display all Appointments from the database 
                var query = from b in db.Appointments
                            orderby b.AptDate
                            select b;

                Console.WriteLine("All Appointments in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Description);
                    Console.WriteLine(item.AptDate);
                    Console.WriteLine(" ");
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
        public int contactID()
        {
            string stmt = "SELECT COUNT(*) FROM dbo.Contacts";
             count = 0;

            using (SqlConnection thisConnection = new SqlConnection(" Data Source=LOUISE\\SQLEXPRESS;Initial Catalog=CalendarDatabase.CalenderDataContext;Integrated Security=True"))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                {
                    thisConnection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }

            }
            return count;

        }

    }
    public class Appointment
    {
        
        [Key]
        public int AppointmentID { get; set; }
        public DateTime AptDate { get; set; }
        public string Description { get; set; }
        public int OrganizerID { get; set; }
        public Contact Organizer { get; set; }
        public Month MonthNum { get; set; }
        public int NumMonth { get; set; }
        public virtual List<Contact> Attendees { get; set; }
        public virtual List<Month> aptMonthId{ get; set; }
        public Month MonthIdentity { get; set; }
        public virtual ICollection<Month> Months { get; set; }
        // public virtual Contact Contact { get; set; }
    }
    public class Contact
    {
       
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public int? AppointmentID { get; set; }
        
        public Appointment Appointment { get; set; }
        //  public Appointment AppointmentID { get; set; }
        //Foreign key for Standard
        // public int AppointmentID { get; set; }

        // public Appointment Appointment { get; set; }
        //public virtual Appointment AppointmentID { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        
    }
    /*public enum MonthName
    {
        Jan, Feb, March, April, May, June, July, Aug, Sept, Oct, Nov, Dec
    }*/
    public class Month
    {
        [Key]
        public int ID { get; set; }
        public int AptMonth { get; set; }
        public Appointment AppointmentID { get; set; }
        public virtual Appointment AppointmentIdentity { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
    public class CalenderDataContext : DbContext
    {
       /* public CalenderDataContext() : base("name=CalendarDatabase")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 300;
        }*/
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Month> Months { get; set; }
    }

}
