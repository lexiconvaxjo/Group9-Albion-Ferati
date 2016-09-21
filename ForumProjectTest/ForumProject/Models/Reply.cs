using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumProject.Models
{
    public class Reply
    {
        public int Id { get; set; }

        public ApplicationUser UserThatReplied { get; set; }

        public string ReplyContent { get; set; }

        public Thread ThreadOfReply { get; set; }

    }
}