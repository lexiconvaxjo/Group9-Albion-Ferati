using IdentityTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityTest.Controllers
{
    public class HomeController : Controller
    {
        private static AppContext _context = new AppContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _context.Users.Where(x => x.Username.Equals(vm.Username) && x.Password.Equals(vm.Password)).FirstOrDefault();

                if (currentUser != null)
                {
                    Session.Add("Username", currentUser.Username);
                }
            }
            return View("Secret");
        }

        public ActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout(string )
        {
            return View();
        }
    }
}