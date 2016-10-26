using MyForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyForum.Repository
{
    public interface IForumRepository : IDisposable
    {
        List<SectionViewModel> GetSections();
        List<PostViewModel> GetSectionPosts(string id);
        List<Comment> GetPostComments(Post post);

        Section GetSectionById(string secId);
        void AddNewSection(SectionViewModel section);

        ThisPostViewModel GetPostVmById(string postId);
        Post GetPostById(string postId);
        void AddNewPost(Post post);
        void DeletePost(string postId);

        Comment GetCommentById(string comId);
        void AddComment(Comment comment);
        void DeleteComment(string comId);

        void Save();
        
    }
}