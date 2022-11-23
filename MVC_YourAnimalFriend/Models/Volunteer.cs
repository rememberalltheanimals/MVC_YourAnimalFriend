using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_YourAnimalFriend.Models
{
    [Table("Volunteer")]
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String Description { get; set; }
        public String Primary { get; set; }
        public String Secondary { get; set; }

    }
}