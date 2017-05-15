using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Comptabilite_Analytique.Models;
using PagedList;

namespace Comptabilite_Analytique.Controllers
{
    public class Compte3chController : Controller
    {
        private Model db = new Model();

        // GET: Compte3ch
        public ActionResult Index(string chercher, int? pageNumber)
        {
            var cpt3 = db.COMPTE_ANA3CH.OrderBy(c => c.NUMERO) ;
            if (chercher != null && chercher.Length > 0)
            { return View(cpt3.Where(s => s.LIBELLE_FR.ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 1000)); }
            else
            {
                return View(cpt3.ToList().ToPagedList(pageNumber ?? 1, 30));
            }
        }

        // GET: Compte3ch/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPTE_ANA3CH cOMPTE_ANA3CH = await db.COMPTE_ANA3CH.FindAsync(id);
            if (cOMPTE_ANA3CH == null)
            {
                return HttpNotFound();
            }
            return View(cOMPTE_ANA3CH);
        }

        // GET: Compte3ch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compte3ch/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NUMERO,LIBELLE_FR,LIBELLE_AR,ANNEE_COMPTABLE")] COMPTE_ANA3CH cOMPTE_ANA3CH)
        {
            var x = db.COMPTE_ANA3CH.Where(p => p.NUMERO == cOMPTE_ANA3CH.NUMERO).ToList();

            if (ModelState.IsValid)
            {
                if (x.Count != 0)
                {
                    ViewBag.Message = " Un compte existe deja avec ce numero ! Pensez a le modifier ";

                }
                else
                {
                    try
                    {

                        db.COMPTE_ANA3CH.Add(cOMPTE_ANA3CH);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }

                    catch (Exception e)
                    {

                        ViewBag.Message = " Operation non aboutie ! Erreur : " + e.Message
                             + " Contacter l'adminstrateur   ";
                        return View(cOMPTE_ANA3CH);
                    }
                }
            }

            return View(cOMPTE_ANA3CH);
        }

        // GET: Compte3ch/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPTE_ANA3CH cOMPTE_ANA3CH = await db.COMPTE_ANA3CH.FindAsync(id);
            if (cOMPTE_ANA3CH == null)
            {
                return HttpNotFound();
            }
            return View(cOMPTE_ANA3CH);
        }

        // POST: Compte3ch/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NUMERO,LIBELLE_FR,LIBELLE_AR,ANNEE_COMPTABLE")] COMPTE_ANA3CH cOMPTE_ANA3CH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPTE_ANA3CH).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cOMPTE_ANA3CH);
        }

        // GET: Compte3ch/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPTE_ANA3CH cOMPTE_ANA3CH = await db.COMPTE_ANA3CH.FindAsync(id);
            if (cOMPTE_ANA3CH == null)
            {
                return HttpNotFound();
            }
            return View(cOMPTE_ANA3CH);
        }

        // POST: Compte3ch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            COMPTE_ANA3CH cOMPTE_ANA3CH = await db.COMPTE_ANA3CH.FindAsync(id);
            db.COMPTE_ANA3CH.Remove(cOMPTE_ANA3CH);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
