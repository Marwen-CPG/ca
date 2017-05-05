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
    public class MethodeRegSiegeController : Controller
    {
        private Model db = new Model();

        // GET: MethodeRegSiege
        public ActionResult Index(string chercher, int? pageNumber)
        {
            var mETHODE_REG_SIEGE = db.METHODE_REG_SIEGE.Include(m => m.COMPTE_ANA5CH);
   
            if (chercher != null && chercher.Length > 0)
            { return View(mETHODE_REG_SIEGE.Where(s => s.SIEGE_N_SIEGE.ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 10)); }
            else
            {
                return View(mETHODE_REG_SIEGE.ToList().ToPagedList(pageNumber ?? 1, 30));
            }
        }

        // GET: MethodeRegSiege/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METHODE_REG_SIEGE mETHODE_REG_SIEGE = await db.METHODE_REG_SIEGE.FindAsync(id);
            if (mETHODE_REG_SIEGE == null)
            {
                return HttpNotFound();
            }
            return View(mETHODE_REG_SIEGE);
        }

        // GET: MethodeRegSiege/Create
        public ActionResult Create()
        {
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR");
            return View();
        }

        // POST: MethodeRegSiege/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDMETHODE_REG_SIEGE,COMPTE_ANA5_NUMERO,SIEGE_N_SIEGE,CODE_GROUPEMENT,METHODE_REG_SIEGE1,LIBELLE_FR,LIBELLE_AR,ANNEE_COMPTABLE")] METHODE_REG_SIEGE mETHODE_REG_SIEGE)
        {
            if (ModelState.IsValid)
            {

                var x = db.METHODE_REG_SIEGE.Where(p => p.METHODE_REG_SIEGE1 == mETHODE_REG_SIEGE.METHODE_REG_SIEGE1)
                   .Where(p => p.SIEGE_N_SIEGE == mETHODE_REG_SIEGE.SIEGE_N_SIEGE)
                   .Where(p => p.COMPTE_ANA5_NUMERO == mETHODE_REG_SIEGE.COMPTE_ANA5_NUMERO).ToList();
                if (x.Count != 0)
                {
                    ViewBag.Message = " Une valeur existe deja pour cette methode de regrouppement total siège ! Pensez a le modifier ";
                    ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mETHODE_REG_SIEGE.SIEGE_N_SIEGE);
           
                }
                else
                {
                    try
                    {
                        db.METHODE_REG_SIEGE.Add(mETHODE_REG_SIEGE);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                  
                    catch (Exception e)
                    {

                        ViewBag.Message = " Operation non aboutie ! Erreur : " + e.Message
                             + " Contacter l'adminstrateur   "; 
                           
                        ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mETHODE_REG_SIEGE.SIEGE_N_SIEGE);
                        return View(mETHODE_REG_SIEGE);
                    }
                }
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mETHODE_REG_SIEGE.SIEGE_N_SIEGE);
            return View(mETHODE_REG_SIEGE);
        }

        // GET: MethodeRegSiege/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METHODE_REG_SIEGE mETHODE_REG_SIEGE = await db.METHODE_REG_SIEGE.FindAsync(id);
            if (mETHODE_REG_SIEGE == null)
            {
                return HttpNotFound();
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mETHODE_REG_SIEGE.SIEGE_N_SIEGE);
            return View(mETHODE_REG_SIEGE);
        }

        // POST: MethodeRegSiege/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDMETHODE_REG_SIEGE,COMPTE_ANA5_NUMERO,SIEGE_N_SIEGE,CODE_GROUPEMENT,METHODE_REG_SIEGE1,LIBELLE_FR,LIBELLE_AR,ANNEE_COMPTABLE")] METHODE_REG_SIEGE mETHODE_REG_SIEGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mETHODE_REG_SIEGE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "LIBELLE_FR", mETHODE_REG_SIEGE.SIEGE_N_SIEGE);
            return View(mETHODE_REG_SIEGE);
        }

        // GET: MethodeRegSiege/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METHODE_REG_SIEGE mETHODE_REG_SIEGE = await db.METHODE_REG_SIEGE.FindAsync(id);
            if (mETHODE_REG_SIEGE == null)
            {
                return HttpNotFound();
            }
            return View(mETHODE_REG_SIEGE);
        }

        // POST: MethodeRegSiege/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            METHODE_REG_SIEGE mETHODE_REG_SIEGE = await db.METHODE_REG_SIEGE.FindAsync(id);
            db.METHODE_REG_SIEGE.Remove(mETHODE_REG_SIEGE);
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
