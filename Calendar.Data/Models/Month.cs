using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calendar.Data.Models
{
    public enum MonthName
    {
        Jan, Feb, March, April, May, June, July, Aug, Sept, Oct, Nov, Dec
    }
    public class Month
    {
        [Key]
        public int ID { get; set; }
        public MonthName? AptMonth { get; set; }
        public int AppointmentID { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}