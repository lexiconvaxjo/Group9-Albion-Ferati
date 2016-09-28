using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumProject.Models.ViewModels
{
    public class ReplyViewModel
    {
        public int Id { get; set; }

        public string ReplyContent { get; set; }

        public int ThreadId { get; set; }
    }
}