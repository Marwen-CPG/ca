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
    public class NatureDepenseController : Controller
    {
        private Model db = new Model();

        // GET: NatureDepense
        public   ActionResult Index(string chercher, int? pageNumber)
        {
            var nATURE_DEPENSE = db.NATURE_DEPENSE.Include(n => n.NATURE_DEPENSE_REG);
            if (chercher != null && chercher.Length > 0)
            { return View(nATURE_DEPENSE.Where(s => s.LIBELLE_FR.ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 10)); }
            else
            {
                return View(nATURE_DEPENSE.ToList().ToPagedList(pageNumber ?? 1, 10));
            }
        }

        // GET: NatureDepense/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NATURE_DEPENSE nATURE_DEPENSE = await db.NATURE_DEPENSE.FindAsync(id);
            if (nATURE_DEPENSE == null)
            {
                return HttpNotFound();
            }
            return View(nATURE_DEPENSE);
        }

        // GET: NatureDepense/Create
        public ActionResult Create()
        {
            ViewBag.NDR_NUMERO = new SelectList(db.NATURE_DEPENSE_REG, "NUMERO", "LIBELLE_FR");
            return View();
        }

        // POST: NatureDepense/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NUMERO,NDR_NUMERO,LIBELLE_FR,LIBELLE_AR")] NATURE_DEPENSE nATURE_DEPENSE)
        {
            if (ModelState.IsValid)
            {
                var x = db.NATURE_DEPENSE.Where(p => p.NUMERO == nATURE_DEPENSE.NUMERO).ToList();
                if (x.Count != 0)
                {
                    ViewBag.Message = " Une valeur existe deja pour ce numero nature depense ! Pensez a le modifier ";
                    ViewBag.NDR_NUMERO = new SelectList(db.NATURE_DEPENSE_REG, "NUMERO", "LIBELLE_FR", nATURE_DEPENSE.NDR_NUMERO);
                }
                else
                {
                    db.NATURE_DEPENSE.Add(nATURE_DEPENSE);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.NDR_NUMERO = new SelectList(db.NATURE_DEPENSE_REG, "NUMERO", "LIBELLE_FR", nATURE_DEPENSE.NDR_NUMERO);
            return View(nATURE_DEPENSE);
        }

        // GET: NatureDepense/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NATURE_DEPENSE nATURE_DEPENSE = await db.NATURE_DEPENSE.FindAsync(id);
            if (nATURE_DEPENSE == null)
            {
                return HttpNotFound();
            }
            ViewBag.NDR_NUMERO = new SelectList(db.NATURE_DEPENSE_REG, "NUMERO", "LIBELLE_FR", nATURE_DEPENSE.NDR_NUMERO);
            return View(nATURE_DEPENSE);
        }

        // POST: NatureDepense/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NUMERO,NDR_NUMERO,LIBELLE_FR,LIBELLE_AR")] NATURE_DEPENSE nATURE_DEPENSE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nATURE_DEPENSE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.NDR_NUMERO = new SelectList(db.NATURE_DEPENSE_REG, "NUMERO", "LIBELLE_FR", nATURE_DEPENSE.NDR_NUMERO);
            return View(nATURE_DEPENSE);
        }

        // GET: NatureDepense/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NATURE_DEPENSE nATURE_DEPENSE = await db.NATURE_DEPENSE.FindAsync(id);
            if (nATURE_DEPENSE == null)
            {
                return HttpNotFound();
            }
            return View(nATURE_DEPENSE);
        }

        // POST: NatureDepense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            NATURE_DEPENSE nATURE_DEPENSE = await db.NATURE_DEPENSE.FindAsync(id);
            db.NATURE_DEPENSE.Remove(nATURE_DEPENSE);
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
