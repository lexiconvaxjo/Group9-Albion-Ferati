using ForumProject.Models;
using ForumProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumProject.Controllers
{
    public class ForumController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Forum
        public ActionResult Index()
        {
            var model = _context.Sections.ToList();
            return View(model);
        }
        

        public ActionResult ThreadList(int id)
        {
            var model = _context.Threads.Where(x => x.Section.Id.Equals(id));
            ViewBag.sectionId = id;
            return View(model);
        }
        


        public ActionResult Thread(int id)
        {
            var model = _context.Threads.Include("ThreadReplies").Where(x => x.Id.Equals(id)).FirstOrDefault();
            ViewBag.threadId = id;
            return View(model);
        }



        public ActionResult CreateThread(int id)
        {
            ViewBag.sectionId = id;
            return View();
        }

        [HttpPost]
        public ActionResult CreateThread(CreateThreadViewModel vm)
        {
            Thread thread = new Thread
            {
                ThreadName = vm.Name,
                ThreadContent = vm.Content,
                Section = _context.Sections.Where(x => x.Id.Equals(vm.SectionId)).FirstOrDefault()
            };

            var ok = 0;
            
            _context.Threads.Add(thread);
            _context.SaveChanges();
            
            return RedirectToAction("ThreadList", new { id = vm.SectionId });
        }



        public ActionResult Reply(int id)
        {
            var reply = new ReplyViewModel
            {
                ThreadId = id
            };
            return View(reply);
        }

        [HttpPost]
        public ActionResult Reply(ReplyViewModel vm)
        {
            Reply reply = new Reply
            {
                ReplyContent = vm.ReplyContent,
                ThreadOfReply = _context.Threads.Where(x => x.Id.Equals(vm.ThreadId)).FirstOrDefault()
            };

            _context.Replies.Add(reply);
            _context.SaveChanges();

            return RedirectToAction("Thread", new { id = vm.ThreadId });
        }
















        //-------------------------------------------------------------------------------

        public ActionResult CreateSection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSection(CreateSectionViewModel vm)
        {
            Section section = new Section
            {
                SectionName = vm.SectionName
            };
            var model = _context.Sections.Add(section);
            _context.SaveChanges();

            var modelList = _context.Sections.ToList();

            return View("Index", modelList);
        }
    }
}