using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nuevo_proyecto.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Nuevo_proyecto.Controllers
{
    [Authorize, RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        public HomeController()
        {
        }

        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if(Request.IsAuthenticated)
            {
                var currentUserId = User.Identity.GetUserId();
                var manager = new UserManager<Nuevo_proyecto.Models.ApplicationUser>(new UserStore<Nuevo_proyecto.Models.ApplicationUser>(new Nuevo_proyecto.Models.ApplicationDbContext()));
                var currentUser = manager.FindById(currentUserId);
              
                
                var nombre = currentUser.FistName;
                ViewBag.FistName = nombre;

                var apellido = currentUser.LastName;
                ViewBag.LastName = apellido;
            }
            return View();
        }

        public ActionResult About()
        {
            if (Request.IsAuthenticated)
            {
                var currentUserId = User.Identity.GetUserId();
                var manager = new UserManager<Nuevo_proyecto.Models.ApplicationUser>(new UserStore<Nuevo_proyecto.Models.ApplicationUser>(new Nuevo_proyecto.Models.ApplicationDbContext()));
                var currentUser = manager.FindById(currentUserId);


                var nombre = currentUser.FistName;
                ViewBag.FistName = nombre;

                var apellido = currentUser.LastName;
                ViewBag.LastName = apellido;
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (Request.IsAuthenticated)
            {
                var currentUserId = User.Identity.GetUserId();
                var manager = new UserManager<Nuevo_proyecto.Models.ApplicationUser>(new UserStore<Nuevo_proyecto.Models.ApplicationUser>(new Nuevo_proyecto.Models.ApplicationDbContext()));
                var currentUser = manager.FindById(currentUserId);


                var nombre = currentUser.FistName;
                ViewBag.FistName = nombre;

                var apellido = currentUser.LastName;
                ViewBag.LastName = apellido;
            }
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}