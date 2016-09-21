using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumProject.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        public List<ApplicationUser> TeamFans { get; set; }
    }
}