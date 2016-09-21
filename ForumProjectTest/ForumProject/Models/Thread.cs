using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumProject.Models
{
    public class Thread
    {
        public int Id { get; set; }

        public ApplicationUser UserThatPosted { get; set; }

        public string ThreadName { get; set; }

        public string ThreadContent { get; set; }
        
        public List<Reply> ThreadReplies { get; set; }
    }
}