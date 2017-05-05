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
    public class NatureDepenseSubController : Controller
    {
        private Model db = new Model();

        // GET: NatureDepenseSub
        public ActionResult Index(string chercher, int? pageNumber)
        {
            var nATURE_DEPENSE_SUBVENTION = db.NATURE_DEPENSE_SUBVENTION.Include(n => n.NATURE_DEPENSE).OrderBy(p => p.NUMERO);

            var nATURE_DEPENSE = db.NATURE_DEPENSE_REG;
            if (chercher != null && chercher.Length > 0)
            { return View(nATURE_DEPENSE_SUBVENTION.Where(s => s.LIBELLE_FR.ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 10)); }
            else
            {
                return View(nATURE_DEPENSE_SUBVENTION.ToList().ToPagedList(pageNumber ?? 1, 10));
            }
        }

        // GET: NatureDepenseSub/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NATURE_DEPENSE_SUBVENTION nATURE_DEPENSE_SUBVENTION = await db.NATURE_DEPENSE_SUBVENTION.FindAsync(id);
            if (nATURE_DEPENSE_SUBVENTION == null)
            {
                return HttpNotFound();
            }
            return View(nATURE_DEPENSE_SUBVENTION);
        }

        // GET: NatureDepenseSub/Create
        public ActionResult Create()
        {
            ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO");
            return View();
        }

        // POST: NatureDepenseSub/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NUMERO,ND_NUMERO,LIBELLE_FR,LIBELLE_AR")] NATURE_DEPENSE_SUBVENTION nATURE_DEPENSE_SUBVENTION)
        {
            if (ModelState.IsValid)
            {
                var x = db.NATURE_DEPENSE_SUBVENTION.Where(p => p.NUMERO == nATURE_DEPENSE_SUBVENTION.NUMERO).ToList();
                if (x.Count != 0)
                {
                    ViewBag.Message = " Une valeur existe deja pour ce numero nature depense de subvension ! Pensez a le modifier ";

                }
                else
                {
                    db.NATURE_DEPENSE_SUBVENTION.Add(nATURE_DEPENSE_SUBVENTION);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", nATURE_DEPENSE_SUBVENTION.ND_NUMERO);
            return View(nATURE_DEPENSE_SUBVENTION);
        }

        // GET: NatureDepenseSub/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NATURE_DEPENSE_SUBVENTION nATURE_DEPENSE_SUBVENTION = await db.NATURE_DEPENSE_SUBVENTION.FindAsync(id);
            if (nATURE_DEPENSE_SUBVENTION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", nATURE_DEPENSE_SUBVENTION.ND_NUMERO);
            return View(nATURE_DEPENSE_SUBVENTION);
        }

        // POST: NatureDepenseSub/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NUMERO,ND_NUMERO,LIBELLE_FR,LIBELLE_AR")] NATURE_DEPENSE_SUBVENTION nATURE_DEPENSE_SUBVENTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nATURE_DEPENSE_SUBVENTION).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", nATURE_DEPENSE_SUBVENTION.ND_NUMERO);
            return View(nATURE_DEPENSE_SUBVENTION);
        }

        // GET: NatureDepenseSub/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NATURE_DEPENSE_SUBVENTION nATURE_DEPENSE_SUBVENTION = await db.NATURE_DEPENSE_SUBVENTION.FindAsync(id);
            if (nATURE_DEPENSE_SUBVENTION == null)
            {
                return HttpNotFound();
            }
            return View(nATURE_DEPENSE_SUBVENTION);
        }

        // POST: NatureDepenseSub/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            NATURE_DEPENSE_SUBVENTION nATURE_DEPENSE_SUBVENTION = await db.NATURE_DEPENSE_SUBVENTION.FindAsync(id);
            db.NATURE_DEPENSE_SUBVENTION.Remove(nATURE_DEPENSE_SUBVENTION);
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
