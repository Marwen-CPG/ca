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
    public class AtelierController : Controller
    {
        private Model db = new Model();

        // GET: Atelier
        public  ActionResult Index(string chercher, int? pageNumber)
        {
            var aTELIER = db.ATELIER.Include(a => a.SIEGE);
             if ( chercher != null && chercher.Length > 0)
            { return View(aTELIER.Where(s => s.LIBELLE_FR.ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 10)); }
            else 
             {  
            return View(  aTELIER.ToList().ToPagedList(pageNumber ?? 1, 10));
        }}

        // GET: Atelier/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATELIER aTELIER = await db.ATELIER.FindAsync(id);
            if (aTELIER == null)
            {
                return HttpNotFound();
            }
            return View(aTELIER);
        }

        // GET: Atelier/Create
        public ActionResult Create()
        {
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR");
            return View();
        }

        // POST: Atelier/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CODE_ATELIER,LIBELLE_FR,LIBELLE_AR,SIEGE_N_SIEGE")] ATELIER aTELIER)
        {
            if (ModelState.IsValid)
            {
                var x = db.ATELIER.Where(p => p.CODE_ATELIER == aTELIER.CODE_ATELIER).ToList() ;
                        if ( x.Count != 0)
                        { ViewBag.Message = " Une valeur existe deja pour ce code atelier ! Pensez a le modifier ";
                        ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", aTELIER.SIEGE_N_SIEGE);
                        }
                else
                {
                db.ATELIER.Add(aTELIER);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            } }

            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", aTELIER.SIEGE_N_SIEGE);
            return View(aTELIER);
        }

        // GET: Atelier/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATELIER aTELIER = await db.ATELIER.FindAsync(id);
            if (aTELIER == null)
            {
                return HttpNotFound();
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", aTELIER.SIEGE_N_SIEGE);
            return View(aTELIER);
        }

        // POST: Atelier/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CODE_ATELIER,LIBELLE_FR,LIBELLE_AR,SIEGE_N_SIEGE")] ATELIER aTELIER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aTELIER).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", aTELIER.SIEGE_N_SIEGE);
            return View(aTELIER);
        }

        // GET: Atelier/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATELIER aTELIER = await db.ATELIER.FindAsync(id);
            if (aTELIER == null)
            {
                return HttpNotFound();
            }
            return View(aTELIER);
        }

        // POST: Atelier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ATELIER aTELIER = await db.ATELIER.FindAsync(id);
            db.ATELIER.Remove(aTELIER);
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
