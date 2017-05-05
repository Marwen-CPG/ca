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
    public class SiegeController : Controller
    {
        private Model db = new Model();

        // GET: Siege
        public ActionResult Index(string chercher, int? pageNumber)
        {
            var Siege = db.SIEGE ;
            if (chercher != null && chercher.Length > 0)
            { return View(Siege.Where(s => s.LIBELLE_FR.ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 10)); }
            else
            {
                return View(Siege.ToList().ToPagedList(pageNumber ?? 1, 10));
            }
        }

        // GET: Siege/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIEGE sIEGE = await db.SIEGE.FindAsync(id);
            if (sIEGE == null)
            {
                return HttpNotFound();
            }
            return View(sIEGE);
        }

        // GET: Siege/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Siege/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NUMERO_SIEGE,LIBELLE_FR,LIBELLE_AR,NUMERO_SIEGE_COMPTABLE")] SIEGE sIEGE)
        {
            if (ModelState.IsValid)
            {
                var x = db.SIEGE.Where(p => p.NUMERO_SIEGE == sIEGE.NUMERO_SIEGE).ToList();
                if (x.Count != 0)
                {
                    ViewBag.Message = " Une valeur existe deja pour ce code atelier ! Pensez a le modifier ";
                }
                else
                {
                    db.SIEGE.Add(sIEGE);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return View(sIEGE);
        }

        // GET: Siege/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIEGE sIEGE = await db.SIEGE.FindAsync(id);
            if (sIEGE == null)
            {
                return HttpNotFound();
            }
            return View(sIEGE);
        }

        // POST: Siege/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NUMERO_SIEGE,LIBELLE_FR,LIBELLE_AR,NUMERO_SIEGE_COMPTABLE")] SIEGE sIEGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sIEGE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sIEGE);
        }

        // GET: Siege/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIEGE sIEGE = await db.SIEGE.FindAsync(id);
            if (sIEGE == null)
            {
                return HttpNotFound();
            }
            return View(sIEGE);
        }

        // POST: Siege/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            SIEGE sIEGE = await db.SIEGE.FindAsync(id);
            db.SIEGE.Remove(sIEGE);
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
