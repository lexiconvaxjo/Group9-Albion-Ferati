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
        List<PostViewModel> GetAllPosts();
        List<PostViewModel> GetSectionPosts(string id);
        List<CommentViewModel> GetComments();
        List<CommentViewModel> GetPostComments(ThisPostViewModel post);

        Section GetSectionById(string secId);
        void AddNewSection(Section section);
        //void DeleteSection(string secId);
        //void EditSection(string secId);

        ThisPostViewModel GetPostById(string postId);
        void AddNewPost(Post post);
        void DeletePost(string postId);
        //void EditPost(string postId);

        Comment GetCommentById(string comId);
        void AddComment(Comment comment);
        void DeleteComment(string comId);
        //void EditComment(string comId);

        void Save();
        
    }
}