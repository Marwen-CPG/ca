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
    public class MagasinController : Controller
    {
        private Model db = new Model();

        // GET: Magasin
        public   ActionResult Index(string chercher, int? pageNumber)
        {
            var mAGASIN = db.MAGASIN.Include(m => m.SIEGE).OrderBy(m => m.CODE_MAGASIN);
 
            if (chercher != null && chercher.Length > 0)
            { return View(mAGASIN.Where(s => s.LIBELLE_FR.ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 1000)); }
            else
            {
                return View(mAGASIN.ToList().ToPagedList(pageNumber ?? 1, 10));
            }
        }


        // GET: Magasin/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAGASIN mAGASIN = await db.MAGASIN.FindAsync(id);
            if (mAGASIN == null)
            {
                return HttpNotFound();
            }
            return View(mAGASIN);
        }

        // GET: Magasin/Create
        public ActionResult Create()
        {
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR");
            return View();
        }

        // POST: Magasin/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODE_MAGASIN,SIEGE_N_SIEGE,LIBELLE_FR,LIBELLE_AR")] MAGASIN mAGASIN)
        {
            if (ModelState.IsValid)
            {

                var x = db.MAGASIN.Where(p => p.CODE_MAGASIN== mAGASIN.CODE_MAGASIN && p.SIEGE_N_SIEGE == mAGASIN.SIEGE_N_SIEGE).ToList();
                        if ( x.Count != 0)
                        { ViewBag.Message = " Une valeur existe deja pour ce code magasin dans ce siege ! Pensez a le modifier ";
                        ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mAGASIN.SIEGE_N_SIEGE);
                        }
                else
                {
                db.MAGASIN.Add(mAGASIN);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            } }
           

            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mAGASIN.SIEGE_N_SIEGE);
            return View(mAGASIN);
        }

        // GET: Magasin/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAGASIN mAGASIN = await db.MAGASIN.FindAsync(id);
            if (mAGASIN == null)
            {
                return HttpNotFound();
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mAGASIN.SIEGE_N_SIEGE);
            return View(mAGASIN);
        }

        // POST: Magasin/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODE_MAGASIN,SIEGE_N_SIEGE,LIBELLE_FR,LIBELLE_AR")] MAGASIN mAGASIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mAGASIN).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mAGASIN.SIEGE_N_SIEGE);
            return View(mAGASIN);
        }

        // GET: Magasin/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAGASIN mAGASIN = await db.MAGASIN.FindAsync(id);
            if (mAGASIN == null)
            {
                return HttpNotFound();
            }
            return View(mAGASIN);
        }

        // POST: Magasin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            MAGASIN mAGASIN = await db.MAGASIN.FindAsync(id);
            db.MAGASIN.Remove(mAGASIN);
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
