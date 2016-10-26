using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyForum.Models
{
    public class Section
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Post> SectionPosts { get; set; }
    }

    public class Post
    {
        public string Id { get; set; }

        public string SectionId { get; set; }

        public string Topic { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }

        public bool Published { get; set; }

        public Section PostSection { get; set; }

        public List<Comment> PostComments { get; set; }
    }

    public class Comment
    {
        public string Id { get; set; }

        public string SectionId { get; set; }

        public string PostId { get; set; }

        public string UserName { get; set; }

        public string Body { get; set; }

        public bool Deleted { get; set; }

        public Post Post { get; set; }

        public Section Section { get; set; }
    }



    public class SectionViewModel
    {
        public string ID { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        //public int TotalPosts { get; set; }
    }

    public class PostViewModel
    {
        public string Id { get; set; }

        public string SectionId { get; set; }

        [Display(Name ="Topic")]
        public string PostTopic { get; set; }

        [Display(Name ="Content")]
        public string postContent { get; set; }

        public string UserThatPosted { get; set; }
    }

    public class ThisPostViewModel
    {
        public string Id { get; set; }

        public string Topic { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }

        public List<Comment> PostComments { get; set; }
    }

    public class CommentViewModel
    {
        public string Id { get; set; }

        public string PostId { get; set; }

        public string CommentContent { get; set; }

        public string UserThatCommented { get; set; }

        //public DateTime CommentedOn { get; set; }
    }
}