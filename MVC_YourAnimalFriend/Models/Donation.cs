using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_YourAnimalFriend.Models
{
    [Table("Donation")]
    public class Donation
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String Regulary { get; set; }

        // Come up with a new solution for volunteers
        public List<HelpingPaws> Volunteers { get; set; }
     }
}