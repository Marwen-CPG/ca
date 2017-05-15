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
    public class Compte5chController : Controller
    {
        private Model db = new Model();

        // GET: Compte5ch
        public ActionResult Index(string chercher, int? pageNumber)
        {
            var cOMPTE_ANA5CH = db.COMPTE_ANA5CH.Include(c => c.COMPTE_ANA4CH).Include(c => c.SIEGE).OrderBy(c => c.SIEGE_N_SIEGE);

            if (chercher != null && chercher.Length > 0)
            { return View(cOMPTE_ANA5CH.Where(s => s.LIBELLE_FR.ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 1000)); }
            else
            {
                return View(cOMPTE_ANA5CH.ToList().ToPagedList(pageNumber ?? 1, 30));
            }
        }

        // GET: Compte5ch/Details/5
        public async Task<ActionResult> Details(string id, int id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPTE_ANA5CH cOMPTE_ANA5CH = await db.COMPTE_ANA5CH.FindAsync(id , id1);
            if (cOMPTE_ANA5CH == null)
            {
                return HttpNotFound();
            }
            return View(cOMPTE_ANA5CH);
        }

        // GET: Compte5ch/Create
        public ActionResult Create()
        {
            ViewBag.COMPTE_ANA4CH_NUMERO = new SelectList(db.COMPTE_ANA4CH, "NUMERO", "NUMERO");
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE");
            return View();
        }

        // POST: Compte5ch/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SIEGE_N_SIEGE,NUMERO,COMPTE_ANA4CH_NUMERO,LIBELLE_FR,LIBELLE_AR,ANNEE_COMPTABLE")] COMPTE_ANA5CH cOMPTE_ANA5CH)
        {
            if (ModelState.IsValid)
            {
                var x = db.COMPTE_ANA5CH.Where(p => p.NUMERO == cOMPTE_ANA5CH.NUMERO).ToList();
                if (x.Count != 0)
                {
                    ViewBag.Message = " Un compte existe deja avec ce numero ! Pensez a le modifier ";

                }
                else
                {
                    try
                    {


                        db.COMPTE_ANA5CH.Add(cOMPTE_ANA5CH);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }

                    catch (Exception e)
                    {

                        ViewBag.Message = " Operation non aboutie ! Erreur : " + e.Message
                             + " Contacter l'adminstrateur   ";
                        return View(cOMPTE_ANA5CH);
                    }
                }
            }


            ViewBag.COMPTE_ANA4CH_NUMERO = new SelectList(db.COMPTE_ANA4CH, "NUMERO", "NUMERO", cOMPTE_ANA5CH.COMPTE_ANA4CH_NUMERO);
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", cOMPTE_ANA5CH.SIEGE_N_SIEGE);
            return View(cOMPTE_ANA5CH);
        }

        // GET: Compte5ch/Edit/5
        public async Task<ActionResult> Edit(string id, int id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPTE_ANA5CH cOMPTE_ANA5CH = await db.COMPTE_ANA5CH.FindAsync(id , id1);
            if (cOMPTE_ANA5CH == null)
            {
                return HttpNotFound();
            }
            ViewBag.COMPTE_ANA4CH_NUMERO = new SelectList(db.COMPTE_ANA4CH, "NUMERO", "NUMERO", cOMPTE_ANA5CH.COMPTE_ANA4CH_NUMERO);
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", cOMPTE_ANA5CH.SIEGE_N_SIEGE);
            return View(cOMPTE_ANA5CH);
        }

        // POST: Compte5ch/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SIEGE_N_SIEGE,NUMERO,COMPTE_ANA4CH_NUMERO,LIBELLE_FR,LIBELLE_AR,ANNEE_COMPTABLE")] COMPTE_ANA5CH cOMPTE_ANA5CH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPTE_ANA5CH).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.COMPTE_ANA4CH_NUMERO = new SelectList(db.COMPTE_ANA4CH, "NUMERO", "NUMERO", cOMPTE_ANA5CH.COMPTE_ANA4CH_NUMERO);
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", cOMPTE_ANA5CH.SIEGE_N_SIEGE);
            return View(cOMPTE_ANA5CH);
        }

        // GET: Compte5ch/Delete/5
        public async Task<ActionResult> Delete(string id, int id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPTE_ANA5CH cOMPTE_ANA5CH = await db.COMPTE_ANA5CH.FindAsync(id , id1);
            if (cOMPTE_ANA5CH == null)
            {
                return HttpNotFound();
            }
            return View(cOMPTE_ANA5CH);
        }

        // POST: Compte5ch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id, int id1)
        {
            COMPTE_ANA5CH cOMPTE_ANA5CH = await db.COMPTE_ANA5CH.FindAsync(id , id1 );
            db.COMPTE_ANA5CH.Remove(cOMPTE_ANA5CH);
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
