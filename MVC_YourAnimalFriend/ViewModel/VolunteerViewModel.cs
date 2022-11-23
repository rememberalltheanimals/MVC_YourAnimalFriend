using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_YourAnimalFriend.ViewModel
{
    public class VolunteerViewModel
    {
        [Display(Name = "Volunteer Name:")]
        public String Name { get; set; }
        public String Type { get; set; }
        public String Description { get; set; }

        [Display(Name = "Primary Focus")]
        public String Primary { get; set; }

        [Display(Name = "Secondary Focus")]
        public String Secondary { get; set; }

        [Display(Name = "number of Visits")]
        [Required(ErrorMessage = "Must specify a number of visits")]
        public int Visits { get; set; }

        [Display(Name = "Number of Sent")]
        [Required(ErrorMessage = "Must specify a number of sent")]
        public int Sent { get; set; }

        public int FreeHours { get; set; }

        public int DonationId { get; set; }
    }
}