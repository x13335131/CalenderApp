using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calendar.Data.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        public DateTime AptDate { get; set; }
        public string Description { get; set; }
        public int OrganizerID { get; set; }
        public Contact Organizer { get; set; }
        public List<Contact> Attendees { get; set; }

        public virtual Month Month { get; set; }
        public virtual Contact Contact { get; set; }
    }
}