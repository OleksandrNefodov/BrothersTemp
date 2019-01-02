using System.Linq;
using System.Web.Mvc;
using Brothers.Repository.IdentityInfrastructure;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using Brothers.Common.Models.Identity;
using Brothers.Repository.ServiceMapping.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace BrothersProjects.Controllers
{
    public class AuthenticationController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(AuthenticationViewBase userModel)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindByEmailAsync(userModel.Email).Result;
                if (user != null)
                {
                    var isValidPass = UserManager.CheckPassword(user, userModel.Password);
                    if (isValidPass)
                    {
                        var identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                        AuthManger.SignOut();
                        AuthManger.SignIn(new AuthenticationProperties
                        {
                            IsPersistent = false
                        }, identity);

                        return RedirectToAction("Photos", "Photo");
                    }                             
                }
               
                ModelState.AddModelError("Password", "Email or password is not correct");
            }

            return View(userModel);
        }

        public ActionResult Create(AuthenticationView userModel)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(userModel.Name))
                {
                    userModel.Name = userModel.Email;
                }

                var user = new AppUser { UserName = userModel.Name, Email = userModel.Email };
                IdentityResult result = UserManager.CreateAsync(user, userModel.Password).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }            

            return View("Signup");
        }

        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult Users()
        {
            var users = UserManager.Users;

            return View(users);
        }


        private IAuthenticationManager AuthManger
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private UserManagement UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManagement>(); }
        }
    }
}