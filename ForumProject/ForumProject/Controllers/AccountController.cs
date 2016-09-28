using ForumProject.Models.ViewModels;
using ForumProject.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ForumProject.Controllers
{
    // Just for testing
    public class AccountController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        private ApplicationSignInManager _signIn;
        public ApplicationSignInManager SignIn
        {
            get
            {
                return _signIn ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            set
            {
                _signIn = value;
            }
        }
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        public AccountController()
        {

        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signIn)
        {
            _userManager = userManager;
            _signIn = signIn;
        }

        public ActionResult ChooseTeam()
        {
            var team = new Team();
            return View(team);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ErrorLogin", "Incorrect username or password");
                return View(vm);
            }

            var status = SignIn.PasswordSignIn(vm.Username, vm.Password, false, false);

            switch (status)
            {
                case SignInStatus.Success:
                    Session.Add("Username", vm.Username);
                    return RedirectToAction("Index", "Home");
                case SignInStatus.Failure:
                    ModelState.AddModelError("ErrorLogin", "Incorrect username or password!");
                    return View();
            }
            return View();

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel vm)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = vm.Username, Email = vm.Email };
                var result = await UserManager.CreateAsync(user, vm.Password);
                if (result.Succeeded)
                {
                    await SignIn.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    
                    Session.Add("Username", vm.Username);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(vm);


            //In workshop we did the following code
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("ErrorRegister", "Fill all required");
            //    return View("Index");
            //}

            //var user = new ApplicationUser
            //{
            //    UserName = vm.Username,
            //    Email = vm.Email
            //};

            //var create = await UserManager.CreateAsync(user, vm.Password);

            ////var errors = create.Errors;

            //if (create.Succeeded)
            //{
            //    //user is succefully registered, here you can write what you want to happen next
            //    Session.Add("Username", user.UserName);
            //    return View("Index");
            //}
            //return View("Index");
        }

        //Identity error method
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}