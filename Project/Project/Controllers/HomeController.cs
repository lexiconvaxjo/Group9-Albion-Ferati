using Project.Models;
using Project.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            PersonViewModel vm = new PersonViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Register(PersonViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person();
                person.FirstName = pvm.FirstName;
                person.LastName = pvm.LastName;
                person.UserName = pvm.UserName;
                person.Email = pvm.Email;
                person.Password = pvm.Password;
                person.ConfirmPassword = pvm.ConfirmPassword;
                db.People.Add(person);
                db.SaveChanges();
                ViewBag.confirmRegistration = "Success!";
            }

            return View();
        }

        public ActionResult Login ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                var currentUser = db.People.Where(x => x.UserName.Equals(pvm.UserName) && x.Password.Equals(pvm.Password)).FirstOrDefault();

                if (currentUser != null)
                {
                    Session["LoggedUser"] = currentUser.UserName.ToString();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}