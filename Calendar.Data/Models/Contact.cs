using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Calendar.Data.Models
{
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}