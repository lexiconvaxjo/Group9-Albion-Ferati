using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumProject.Models
{
    public class Section
    {
        public int Id { get; set; }

        public string SectionName { get; set; }

        public List<Thread> SectionThreads { get; set; }
    }
}