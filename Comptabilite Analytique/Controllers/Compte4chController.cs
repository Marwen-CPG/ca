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
    public class Compte4chController : Controller
    {
        private Model db = new Model();

        // GET: Compte4ch
        public ActionResult Index(string chercher, int? pageNumber)
        {
            var cOMPTE_ANA4CH = db.COMPTE_ANA4CH.Include(c => c.COMPTE_ANA3CH);
            if (chercher != null && chercher.Length > 0)
            { return View(cOMPTE_ANA4CH.Where(s => s.LIBELLE_FR.ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 30)); }
            else
            {
                return View(cOMPTE_ANA4CH.ToList().ToPagedList(pageNumber ?? 1, 30));
            }
        }

        // GET: Compte4ch/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPTE_ANA4CH cOMPTE_ANA4CH = await db.COMPTE_ANA4CH.FindAsync(id);
            if (cOMPTE_ANA4CH == null)
            {
                return HttpNotFound();
            }
            return View(cOMPTE_ANA4CH);
        }

        // GET: Compte4ch/Create
        public ActionResult Create()
        {
            ViewBag.COMPTE_ANA3CH_NUMERO = new SelectList(db.COMPTE_ANA3CH, "NUMERO", "NUMERO");
            return View();
        }

        // POST: Compte4ch/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NUMERO,COMPTE_ANA3CH_NUMERO,LIBELLE_FR,LIBELLE_AR,ANNEE_COMPTABLE")] COMPTE_ANA4CH cOMPTE_ANA4CH)
        {
            if (ModelState.IsValid)
            {
                var x = db.COMPTE_ANA4CH.Where(p => p.NUMERO == cOMPTE_ANA4CH.NUMERO).ToList();
                if (x.Count != 0)
                {
                    ViewBag.Message = " Un compte existe deja avec ce numero ! Pensez a le modifier ";

                }
                else
                {
                    try
                    {

                        db.COMPTE_ANA4CH.Add(cOMPTE_ANA4CH);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }

                    catch (Exception e)
                    {

                        ViewBag.Message = " Operation non aboutie ! Erreur : " + e.Message
                             + " Contacter l'adminstrateur   ";
                        return View(cOMPTE_ANA4CH);
                    }
                }
            }

            ViewBag.COMPTE_ANA3CH_NUMERO = new SelectList(db.COMPTE_ANA3CH, "NUMERO", "NUMERO", cOMPTE_ANA4CH.COMPTE_ANA3CH_NUMERO);
            return View(cOMPTE_ANA4CH);
        }

        // GET: Compte4ch/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPTE_ANA4CH cOMPTE_ANA4CH = await db.COMPTE_ANA4CH.FindAsync(id);
            if (cOMPTE_ANA4CH == null)
            {
                return HttpNotFound();
            }
            ViewBag.COMPTE_ANA3CH_NUMERO = new SelectList(db.COMPTE_ANA3CH, "NUMERO", "NUMERO", cOMPTE_ANA4CH.COMPTE_ANA3CH_NUMERO);
            return View(cOMPTE_ANA4CH);
        }

        // POST: Compte4ch/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NUMERO,COMPTE_ANA3CH_NUMERO,LIBELLE_FR,LIBELLE_AR,ANNEE_COMPTABLE")] COMPTE_ANA4CH cOMPTE_ANA4CH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPTE_ANA4CH).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.COMPTE_ANA3CH_NUMERO = new SelectList(db.COMPTE_ANA3CH, "NUMERO", "NUMERO", cOMPTE_ANA4CH.COMPTE_ANA3CH_NUMERO);
            return View(cOMPTE_ANA4CH);
        }

        // GET: Compte4ch/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPTE_ANA4CH cOMPTE_ANA4CH = await db.COMPTE_ANA4CH.FindAsync(id);
            if (cOMPTE_ANA4CH == null)
            {
                return HttpNotFound();
            }
            return View(cOMPTE_ANA4CH);
        }

        // POST: Compte4ch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            COMPTE_ANA4CH cOMPTE_ANA4CH = await db.COMPTE_ANA4CH.FindAsync(id);
            db.COMPTE_ANA4CH.Remove(cOMPTE_ANA4CH);
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
