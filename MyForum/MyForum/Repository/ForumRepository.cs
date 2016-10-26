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

        public void AddNewSection(SectionViewModel model)
        {
            Section section = new Section
            {
                Id = GenerateSecurityStamp(),
                Title = model.Title,
                Description = model.ShortDescription
            };

            _context.Sections.Add(section);
            Save();
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
        
        

        /// <summary>
        /// Method to comments of a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns>comments through viewmodel</returns>
        public List<Comment> GetPostComments(Post post)
        {
            var comments = _context.Comments.Where(x => x.PostId == post.Id).ToList();

            return comments;
        }




        public Section GetSectionById(string secId)
        {
            return _context.Sections.Find(secId);
        }

        



        public Post GetPostById(string postId)
        {
            var post = _context.Posts.Find(postId);

            return post;
        }


        public ThisPostViewModel GetPostVmById(string postId)
        {
            var query = _context.Posts.Include("PostComments").Where(x => x.Id == postId)
                        .Select(x => new ThisPostViewModel
                        {
                            Id = x.Id,
                            Topic = x.Topic,
                            Username = x.Username,
                            Content = x.Content,
                            PostComments = x.PostComments
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
            comment.Id = GenerateSecurityStamp();
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

        public static string GenerateSecurityStamp()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            char[] hash = new char[15];
            for (int i = 0; i < 15; i++)
            {
                var tempChar = chars[rand.Next(chars.Length)]; hash[i] = tempChar;
            }
            return string.Join("", hash);
        }
    }
}