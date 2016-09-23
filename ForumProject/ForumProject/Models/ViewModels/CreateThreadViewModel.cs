using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumProject.Models.ViewModels
{
    public class CreateThreadViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public ApplicationUser User { get; set; }

        public Section Section { get; set; }
    }

    
}