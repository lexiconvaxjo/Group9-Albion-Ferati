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

        private Section _choosenSection = new Section();

        // GET: Forum
        public ActionResult Index()
        {
            var model = _context.Sections.ToList();
            return View(model);
        }

        //---------------------------------------------------------------
        public ActionResult Threads(int id)
        {
            var model = _context.Threads.Where(x => x.Section.Id.Equals(id));

            var theSection = _context.Sections.ToList().Where(x => x.Id.Equals(id));

            _choosenSection = theSection.FirstOrDefault(x => x.Id == id);
            
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
            
            _choosenSection.SectionThreads.Add(thread);

            _context.Threads.Add(thread);


            var modelList = _context.Threads.ToList();

            _context.SaveChanges();
            return View("Threads", modelList);
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