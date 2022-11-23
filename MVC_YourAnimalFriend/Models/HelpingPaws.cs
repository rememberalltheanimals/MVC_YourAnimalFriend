using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_YourAnimalFriend.Models
{
    [Table("HelpingPaws")]
    public class HelpingPaws
    {
        [Key]
        public int Id { get; set; }
        public int Visits { get; set; }
        public int Sent { get; set; }
        public int FreeHours { get; set; }

        [ForeignKey("Volunteer")]
        public int VolunteerId { get; set; }
        public virtual Volunteer Volunteer { get; set; }

        [ForeignKey("Donation")]
        public int DonationId { get; set; }
        public virtual Donation Donation { get; set; }
    }
}