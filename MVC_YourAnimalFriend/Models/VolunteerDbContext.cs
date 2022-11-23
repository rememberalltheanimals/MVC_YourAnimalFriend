using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_YourAnimalFriend.Models
{
    public class VolunteerDbContext : DbContext
    {
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<HelpingPaws> HelpingPawsHands { get; set; }
    }
}