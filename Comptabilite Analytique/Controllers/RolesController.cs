using AspNet.Identity.AdoNet;
using Microsoft.AspNet.Identity;
using Comptabilite_Analytique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Comptabilite_Analytique.Controllers;

namespace oracleidentitytest.Controllers
{
   [Authorize(Roles = "administrateur")]
    public class RolesController : Controller
    {
        public ActionResult Index()
        {
            // Populate Dropdown Lists
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var rolelist = roleManager.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;

            var userlist = UserManager.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
            new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userlist;

            ViewBag.Message = "Panel d'administration des roles/utilisateurs";

            return View();
        }

  
        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                var context = new ApplicationDbContext();
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var role = new IdentityRole();

                role.Name = collection["RoleName"];
                roleManager.Create(role);
                ViewBag.Message = "Rôle créé avec succès !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    
        public ActionResult Delete(string RoleName)
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var thisRole = roleManager.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            roleManager.Delete(thisRole);

            return RedirectToAction("Index");
        }

        //
        // GET: /Roles/Edit/5
        public ActionResult Edit(string roleName)
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var thisRole = roleManager.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole role)
        {
            try
            {
                var context = new ApplicationDbContext();
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Update(role);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //  Adding Roles to a user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (context == null)
            {
                throw new ArgumentNullException("context", "Context must not be null.");
            }

            ApplicationUser user = UserManager.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.AddToRole(user.Id, RoleName);


            ViewBag.Message = "Rôle affecté a l'utilisateur avec succès!";

            // Repopulate Dropdown Lists
            var rolelist = roleManager.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;
            var userlist = UserManager.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
            new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userlist;

            return View("Index");
        }


        //Getting a List of Roles for a User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                var context = new ApplicationDbContext();
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                ApplicationUser user = UserManager.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                ViewBag.RolesForThisUser = userManager.GetRoles(user.Id); 
 
                // Repopulate Dropdown Lists
                var rolelist = roleManager.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = rolelist;
                var userlist = UserManager.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
                ViewBag.Users = userlist;
                ViewBag.Message = "Rôles récupérés avec succès !";
            }

            return View("Index");
        }

        //Deleting a User from A Role
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            var account = new AccountController();
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ApplicationUser user = UserManager.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);


            if (userManager.IsInRole(user.Id, RoleName))
            {
                userManager.RemoveFromRole(user.Id, RoleName);
                ViewBag.Message = "Rôle retiré de cet utilisateur avec succès !";
            }
            else
            {
                ViewBag.Message = "Cet utilisateur n'appartient pas au rôle sélectionné.";
            }

            // Repopulate Dropdown Lists
            var rolelist = roleManager.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;
            var userlist = UserManager.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
            new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userlist;

            return View("Index");
        }
    }
}