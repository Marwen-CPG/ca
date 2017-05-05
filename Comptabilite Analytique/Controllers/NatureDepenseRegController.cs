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
    public class NatureDepenseRegController : Controller
    {
        private Model db = new Model();

        // GET: NatureDepenseReg
        public ActionResult Index(string chercher, int? pageNumber)
        {
    
            var nATURE_DEPENSE = db.NATURE_DEPENSE_REG ;
            if (chercher != null && chercher.Length > 0)
            { return View(nATURE_DEPENSE.Where(s => s.LIBELLE_FR.ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 10)); }
            else
            {
                return View(nATURE_DEPENSE.ToList().ToPagedList(pageNumber ?? 1, 10));
            }
        }

        // GET: NatureDepenseReg/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NATURE_DEPENSE_REG nATURE_DEPENSE_REG = await db.NATURE_DEPENSE_REG.FindAsync(id);
            if (nATURE_DEPENSE_REG == null)
            {
                return HttpNotFound();
            }
            return View(nATURE_DEPENSE_REG);
        }

        // GET: NatureDepenseReg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NatureDepenseReg/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NUMERO,LIBELLE_FR,LIBELLE_AR")] NATURE_DEPENSE_REG nATURE_DEPENSE_REG)
        {
            if (ModelState.IsValid)
            {

                var x = db.NATURE_DEPENSE_REG.Where(p => p.NUMERO == nATURE_DEPENSE_REG.NUMERO).ToList();
                if (x.Count != 0)
                {
                    ViewBag.Message = " Une valeur existe deja pour ce numero nature depense regroupée ! Pensez a le modifier ";
                   
                }
                else
                {
                    db.NATURE_DEPENSE_REG.Add(nATURE_DEPENSE_REG);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return View(nATURE_DEPENSE_REG);
        }

        // GET: NatureDepenseReg/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NATURE_DEPENSE_REG nATURE_DEPENSE_REG = await db.NATURE_DEPENSE_REG.FindAsync(id);
            if (nATURE_DEPENSE_REG == null)
            {
                return HttpNotFound();
            }
            return View(nATURE_DEPENSE_REG);
        }

        // POST: NatureDepenseReg/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NUMERO,LIBELLE_FR,LIBELLE_AR")] NATURE_DEPENSE_REG nATURE_DEPENSE_REG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nATURE_DEPENSE_REG).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nATURE_DEPENSE_REG);
        }

        // GET: NatureDepenseReg/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NATURE_DEPENSE_REG nATURE_DEPENSE_REG = await db.NATURE_DEPENSE_REG.FindAsync(id);
            if (nATURE_DEPENSE_REG == null)
            {
                return HttpNotFound();
            }
            return View(nATURE_DEPENSE_REG);
        }

        // POST: NatureDepenseReg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            NATURE_DEPENSE_REG nATURE_DEPENSE_REG = await db.NATURE_DEPENSE_REG.FindAsync(id);
            db.NATURE_DEPENSE_REG.Remove(nATURE_DEPENSE_REG);
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
