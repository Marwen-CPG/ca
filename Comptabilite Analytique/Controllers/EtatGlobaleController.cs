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

namespace Comptabilite_Analytique.Controllers
{
    public class EtatGlobaleController : Controller
    {
        private Model db = new Model();

        // GET: EtatGlobale
        public async Task<ActionResult> Index()
        {
            return View(await db.ETAT_GLOBALE.ToListAsync());
        }

        // GET: EtatGlobale/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETAT_GLOBALE eTAT_GLOBALE = await db.ETAT_GLOBALE.FindAsync(id);
            if (eTAT_GLOBALE == null)
            {
                return HttpNotFound();
            }
            return View(eTAT_GLOBALE);
        }

        // GET: EtatGlobale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EtatGlobale/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MOISENCOURS,CHEVAUCHEMENT,VEROUILLE,ANNEE_COMPTABLE")] ETAT_GLOBALE eTAT_GLOBALE)
        {
            if (ModelState.IsValid)
            {
                db.ETAT_GLOBALE.Add(eTAT_GLOBALE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(eTAT_GLOBALE);
        }

        // GET: EtatGlobale/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETAT_GLOBALE eTAT_GLOBALE = await db.ETAT_GLOBALE.FindAsync(id);
            if (eTAT_GLOBALE == null)
            {
                return HttpNotFound();
            }
            return View(eTAT_GLOBALE);
        }

        // POST: EtatGlobale/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MOISENCOURS,CHEVAUCHEMENT,VEROUILLE,ANNEE_COMPTABLE")] ETAT_GLOBALE eTAT_GLOBALE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eTAT_GLOBALE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eTAT_GLOBALE);
        }

        // GET: EtatGlobale/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETAT_GLOBALE eTAT_GLOBALE = await db.ETAT_GLOBALE.FindAsync(id);
            if (eTAT_GLOBALE == null)
            {
                return HttpNotFound();
            }
            return View(eTAT_GLOBALE);
        }

        // POST: EtatGlobale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ETAT_GLOBALE eTAT_GLOBALE = await db.ETAT_GLOBALE.FindAsync(id);
            db.ETAT_GLOBALE.Remove(eTAT_GLOBALE);
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
