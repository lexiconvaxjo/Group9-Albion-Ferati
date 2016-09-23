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
            _context.SaveChanges();
            return View(model);
        }


        //---------------------------------------------------------------
        public ActionResult Threads(int SectionId)
        {
            var model = _context.Threads.Where(x => x.Section.Id.Equals(SectionId)).ToList();
            _context.SaveChanges();
            return View(model);
        }

        [HttpPost]
        public ActionResult Threads()
        {
            return View();
        }

        //--------------------------------------------------------------------------------
        public ActionResult CreateThread()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateThread(CreateThreadViewModel vm)
        {
            Thread thread = new Thread
            {
                ThreadName = vm.Name,
                ThreadContent = vm.Content

            };
            _context.Threads.Add(thread);
            _context.SaveChanges();
            var modelList = _context.Threads.ToList();
            return View("Threads", modelList);
        }

        //---------------------------------------------------------------------------------
        public ActionResult Replies()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Replies(Reply reply)
        {
            return View();
        }
    }
}