using MyForum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyForum.Repository
{
    public class ForumRepository : IForumRepository, IDisposable
    {
        private ForumDbContext _context;
        public ForumRepository(ForumDbContext context)
        {
            _context = context;
        }




        /// <summary>
        /// Method to get sections
        /// </summary>
        /// <returns>Sections through viewmodel</returns>
        public List<SectionViewModel> GetSections()
        {
            var query = from x in _context.Sections
                        select new SectionViewModel()
                        {
                            ID = x.Id,
                            Title = x.Title,
                            ShortDescription = x.Description
                        };

            List<SectionViewModel> sectionForView = query.ToList();

            return sectionForView;
        }


        /// <summary>
        /// Method to get post list of the chosen section
        /// </summary>
        /// <param name="section"></param>
        /// <returns>post list through viewmodel</returns>
        public List<PostViewModel> GetSectionPosts(string id)
        {
            var query = from x in _context.Posts.Where(x => x.SectionId == id)
                        select new PostViewModel()
                        {
                           Id = x.Id,
                           SectionId = x.SectionId,
                           UserThatPosted = x.Username,
                            PostTopic = x.Topic,
                           postContent = x.Content
                        };

            List<PostViewModel> postForView = query.ToList();

            return postForView;
        }

        public List<PostViewModel> GetAllPosts()
        {
            var query = from x in _context.Posts
                        select new PostViewModel()
                        {
                            Id = x.Id,
                            SectionId = x.SectionId,
                            UserThatPosted = x.Username,
                            PostTopic = x.Topic,
                            postContent = x.Content
                        };

            List<PostViewModel> postForView = query.ToList();

            return postForView;
        }
        

        public List<CommentViewModel> GetComments()
        {
            var query = from x in _context.Comments
                        select new CommentViewModel()
                        {
                            Id = x.Id,
                            PostId = x.PostId,
                            CommentContent = x.Body,
                            UserThatCommented = x.UserName
                        };

            List<CommentViewModel> commentForView = query.ToList();

            return commentForView;
        }

        /// <summary>
        /// Method to comments of a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns>comments through viewmodel</returns>
        public List<CommentViewModel> GetPostComments(ThisPostViewModel post)
        {
            var query = from x in _context.Comments.Where(x => x.PostId == post.Id)
                        select new CommentViewModel()
                        {
                            Id = x.Id,
                            PostId = x.PostId,
                            UserThatCommented = x.UserName,
                            CommentContent = x.Body
                        };

            List<CommentViewModel> commentForView = query.ToList();

            return commentForView;
        }




        public Section GetSectionById(string secId)
        {
            return _context.Sections.Find(secId);
        }

        public void AddNewSection(Section section)
        {
            _context.Sections.Add(section);
            Save();
        }



        public ThisPostViewModel GetPostById(string postId)
        {
            var query = _context.Posts.Include("PostComments").Where(x => x.Id == postId)
                        .Select(x => new Post
                        {
                            Id = x.Id,
                            Topic = x.Topic,
                            Username = x.Username,
                            Content = x.Content,
                            PostComments = x.PostComments
                        }).Select(x => new ThisPostViewModel
                        {
                            Id = x.Id,
                            Topic = x.Topic,
                            Username = x.Username,
                            Content = x.Content,
                            PostComments = 
                        }).FirstOrDefault();
            

            return query;
        }

        public void AddNewPost(Post post)
        {
            _context.Posts.Add(post);
            Save();
        }

        public void DeletePost(string id)
        {
            var post = _context.Posts.Where(x => x.Id == id).FirstOrDefault();

            _context.Posts.Remove(post);

            Save();
        }



        public Comment GetCommentById(string comId)
        {
            return _context.Comments.Find(comId);
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);

            Save();
        }

        public void DeleteComment(string id)
        {
            var com = _context.Comments.Where(x => x.Id == id).FirstOrDefault();

            _context.Comments.Remove(com);

            Save();
        }

        public void Save()
        {
            _context.SaveChanges();

        }



        #region dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion dispose
    }
}