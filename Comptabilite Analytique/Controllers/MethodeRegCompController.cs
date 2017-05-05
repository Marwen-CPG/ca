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
    public class MethodeRegCompController : Controller
    {
        private Model db = new Model();

        // GET: MethodeRegComp
        public ActionResult Index(string chercher, int? pageNumber)
        {
            var mETHODE_REG_COMPAGNIE = db.METHODE_REG_COMPAGNIE.Include(m => m.COMPTE_ANA5CH);
            if (chercher != null && chercher.Length > 0)
            { return View(mETHODE_REG_COMPAGNIE.Where(s => s.SIEGE_N_SIEGE.ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 10)); }
            else
            {
                return View(mETHODE_REG_COMPAGNIE.ToList().ToPagedList(pageNumber ?? 1, 30));
            }
        }

        // GET: MethodeRegComp/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METHODE_REG_COMPAGNIE mETHODE_REG_COMPAGNIE = await db.METHODE_REG_COMPAGNIE.FindAsync(id);
            if (mETHODE_REG_COMPAGNIE == null)
            {
                return HttpNotFound();
            }
            return View(mETHODE_REG_COMPAGNIE);
        }

        // GET: MethodeRegComp/Create
        public ActionResult Create()
        {
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR");
            return View();
        }

        // POST: MethodeRegComp/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDMETHODE_REG_COMPAGNIE,COMPTE_ANA5_NUMERO,SIEGE_N_SIEGE,CODE_GROUPEMENT,METHODE_REG_COMPAGNIE1,LIBELLE_FR,LIBELLE_AR,ANNEE_COMPTABLE")] METHODE_REG_COMPAGNIE mETHODE_REG_COMPAGNIE)
        {
            if (ModelState.IsValid)
            {
                var x = db.METHODE_REG_COMPAGNIE.Where(p => p.METHODE_REG_COMPAGNIE1 == mETHODE_REG_COMPAGNIE.METHODE_REG_COMPAGNIE1)
                   .Where(p => p.SIEGE_N_SIEGE == mETHODE_REG_COMPAGNIE.SIEGE_N_SIEGE)
                   .Where(p => p.COMPTE_ANA5_NUMERO == mETHODE_REG_COMPAGNIE.COMPTE_ANA5_NUMERO).ToList();
                if (x.Count != 0)
                {
                    ViewBag.Message = " Une valeur existe deja pour cette methode de regrouppement total siège ! Pensez a le modifier ";
                    ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mETHODE_REG_COMPAGNIE.SIEGE_N_SIEGE);

                }
                else
                {
                    try
                    {
                        db.METHODE_REG_COMPAGNIE.Add(mETHODE_REG_COMPAGNIE);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }

                    catch (Exception e)
                    {

                        ViewBag.Message = " Operation non aboutie ! Erreur : " + e.Message
                             + " Contacter l'adminstrateur   ";

                        ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mETHODE_REG_COMPAGNIE.SIEGE_N_SIEGE);
                        return View(mETHODE_REG_COMPAGNIE);
                    }
                }
            }

            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mETHODE_REG_COMPAGNIE.SIEGE_N_SIEGE);
            return View(mETHODE_REG_COMPAGNIE);
        }

        // GET: MethodeRegComp/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METHODE_REG_COMPAGNIE mETHODE_REG_COMPAGNIE = await db.METHODE_REG_COMPAGNIE.FindAsync(id);
            if (mETHODE_REG_COMPAGNIE == null)
            {
                return HttpNotFound();
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mETHODE_REG_COMPAGNIE.SIEGE_N_SIEGE);
            return View(mETHODE_REG_COMPAGNIE);
        }

        // POST: MethodeRegComp/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDMETHODE_REG_COMPAGNIE,COMPTE_ANA5_NUMERO,SIEGE_N_SIEGE,CODE_GROUPEMENT,METHODE_REG_COMPAGNIE1,LIBELLE_FR,LIBELLE_AR,ANNEE_COMPTABLE")] METHODE_REG_COMPAGNIE mETHODE_REG_COMPAGNIE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mETHODE_REG_COMPAGNIE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mETHODE_REG_COMPAGNIE.SIEGE_N_SIEGE);
            return View(mETHODE_REG_COMPAGNIE);
        }

        // GET: MethodeRegComp/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METHODE_REG_COMPAGNIE mETHODE_REG_COMPAGNIE = await db.METHODE_REG_COMPAGNIE.FindAsync(id);
            if (mETHODE_REG_COMPAGNIE == null)
            {
                return HttpNotFound();
            }
            return View(mETHODE_REG_COMPAGNIE);
        }

        // POST: MethodeRegComp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            METHODE_REG_COMPAGNIE mETHODE_REG_COMPAGNIE = await db.METHODE_REG_COMPAGNIE.FindAsync(id);
            db.METHODE_REG_COMPAGNIE.Remove(mETHODE_REG_COMPAGNIE);
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
