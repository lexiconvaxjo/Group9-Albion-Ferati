using ForumProject.Models.ViewModels;
using ForumProject.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ForumProject.Controllers
{
    public class AccountController : Controller
    {
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ErrorLogin", "Type your username or password");
                return View();
            }

            var status = SignIn.PasswordSignIn(vm.Username, vm.Password, false, false);

            switch (status)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index");
                case SignInStatus.Failure:
                    ModelState.AddModelError("ErrorLogin", "Incorrect username or password!");
                    return View();
            }
            return View();

        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ErrorRegister", "Fill all required");
                return View("Index");
            }

            var user = new ApplicationUser
            {
                UserName = vm.Email,
                Email = vm.Email
            };

            var create = await UserManager.CreateAsync(user, vm.Password);

            var errors = create.Errors;

            if (create.Succeeded)
            {
                //user is succefully registered, here you can write what you want to happen next
            }




            return View("Index");
        }
    }
}