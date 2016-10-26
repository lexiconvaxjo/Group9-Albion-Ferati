using MyForum.Models;
using MyForum.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyForum.Controllers
{
    public class ForumController : Controller
    {

        #region MustHave
        private IForumRepository _forumRepository;

        public ForumController()
        {
            _forumRepository = new ForumRepository(new ForumDbContext());
        }

        public ForumController(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }
        #endregion
        
        #region Forum
        // GET: Forum
        public ActionResult Index()
        {
            var sections = GetSections();

            return View(sections);
        }
        
        public ActionResult PostList(string id)
        {
            var postList = GetSectionPosts(id);

            return View(postList);
        }

        public ActionResult Post(string id)
        {
            var post = _forumRepository.GetPostById(id);

            Comments(post);

            return View(_forumRepository.GetPostVmById(id));
        }

        public ActionResult AddPost(string id)
        {
            var post = new PostViewModel
            {
                SectionId = id
            };
            return View(post);
        }

        [HttpPost]
        public ActionResult AddPost(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post
                {
                    Id = GenerateSecurityStamp(),
                    Topic = model.PostTopic,
                    Content = model.postContent,
                    Username = User.Identity.Name,
                    SectionId = model.SectionId
                };
                _forumRepository.AddNewPost(post);

                return RedirectToAction("Post", new { id = post.Id });
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddReply(Comment com)
        {
            _forumRepository.AddComment(com);
            return RedirectToAction("Post", com.PostId);
        }


        [ChildActionOnly]
        public ActionResult Comments(Post post)
        {
            var postComments = _forumRepository.GetPostComments(post).ToList();

            return View(postComments);
        }
        
        public ActionResult AddComment(string id)
        {
            var com = new CommentViewModel
            {
                PostId = id
            };
            return View(com);
        }

        [HttpPost]
        public ActionResult AddComment(CommentViewModel model)
        {
            Comment com = new Comment
            {
                Id = GenerateSecurityStamp(),
                Body = model.CommentContent,
                UserName = User.Identity.Name,
                PostId = model.PostId
            };

            _forumRepository.AddComment(com);

            return RedirectToAction("Post", new { id = com.PostId });
        }

        #endregion

        #region Admin

        [Authorize(Roles = "Admin")]
        public ActionResult AddSection()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddSection(SectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                _forumRepository.AddNewSection(model);

                return RedirectToAction("Index", GetSections());
            }

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeletePost(string id)
        {
            var post = _forumRepository.GetPostById(id);
            return View(post);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("DeletePost")]
        public ActionResult DeletePostConfirmed(string id)
        {
            var post = _forumRepository.GetPostById(id);

            var secId = post.SectionId;

            if (post == null)
            {
                return HttpNotFound();
            }

            _forumRepository.DeletePost(id);

            return View("PostList", GetSectionPosts(_forumRepository.GetSectionById(secId).Id));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteComment(string id)
        {
            var com = _forumRepository.GetCommentById(id);
            return View(com);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("DeleteComment")]
        public ActionResult DeleteCommentConfirmed(string id)
        {
            var com = _forumRepository.GetCommentById(id);

            var postId = com.PostId;

            if (com == null)
            {
                return HttpNotFound();
            }

            _forumRepository.DeleteComment(id);

            return RedirectToAction("Post", new { id = postId });
        }

        #endregion

        #region Helpers

        public List<SectionViewModel> GetSections()
        {
            return _forumRepository.GetSections();
        }

        public List<PostViewModel> GetSectionPosts(string id)
        {
            return _forumRepository.GetSectionPosts(id);
        }
        
        public List<Comment> GetPostComments(Post post)
        {
            return _forumRepository.GetPostComments(post);
        }


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
        #endregion
    }
}