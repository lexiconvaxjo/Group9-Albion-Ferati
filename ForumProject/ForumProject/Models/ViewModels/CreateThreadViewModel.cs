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


        //public static implicit operator CreateThreadViewModel(Thread thread)
        //{
        //    return new  CreateThreadViewModel
        //    {
        //        Id = thread.Id,
        //        Name = thread.ThreadName,
        //        Content = thread.ThreadContent
        //    };
        //}

        //public static implicit operator Thread(CreateThreadViewModel vm)
        //{
        //    return new Thread
        //    {
        //        Id = vm.Id,
        //        ThreadName = vm.Name,
        //        ThreadContent = vm.Content
        //    };
        //}
    }

    
}