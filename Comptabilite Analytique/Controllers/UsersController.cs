using AspNet.Identity.AdoNet;
using Comptabilite_Analytique.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comptabilite_Analytique.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ViewBag.Users = UserManager.Users.OrderBy(u => u.UserName).ToList();

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
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser();

                user.UserName = collection["username"];
                user.Email = collection["email"];
                var password = collection["password"];
                var result =  UserManager.CreateAsync(user, password);
                ViewBag.Message = "Utilisateur créé avec succès !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(string id)
        {
            var context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var thisUser = UserManager.Users.Where( u => u.Id.Equals(id , StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault(); 
            UserManager.Delete(thisUser);
            return RedirectToAction("Index");
        }

        //
        // GET: /Roles/Edit/5
        public ActionResult Edit(string id)
        {
            var context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var thisUser = UserManager.Users.Where(u => u.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return View(thisUser);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser user, FormCollection collection)
        {
            string motdepasse = collection["password"];
       
            try
            {
                var context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                UserManager.Update(user);
                if (motdepasse!=null && motdepasse.Length>0) {
                UserManager.RemovePassword(user.Id);
                UserManager.AddPassword(user.Id, motdepasse);}
                ViewBag.Message = "Mise a jour effectuer avec succes ! ...";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Erreur pendant l'execution de la requete ! ...";
                return View();
            }
        }

 

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var context = new ApplicationDbContext();
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                ApplicationUser user = UserManager.Users.Where(u => u.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                ViewBag.RolesForThisUser = userManager.GetRoles(user.Id);

               
                ViewBag.Message = "Rôles récupérés avec succès !";
            }

            return View("Index");
        }
       
    }
}