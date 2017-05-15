﻿using System;
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
    public class CleRepFixeController : Controller
    {
        private Model db = new Model();

        // GET: CleRepFixe
        public ActionResult Index(string chercher, int? pageNumber)
        {
            var cLE_REPARTITION_FIXE = db.CLE_REPARTITION_FIXE.Include(c => c.COMPTE_ANA5CH).Include(c => c.COMPTE_ANA5CH1).Include(c => c.NATURE_DEPENSE1).OrderBy(c => c.COMPTE_NUMERO).OrderBy(c => c.SIEGE_N_SIEGE);
            if (chercher != null && chercher.Length > 0)
            { return View(cLE_REPARTITION_FIXE.Where(s => s.NATURE_DEPENSE.ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 1000)); }
            else
            {
                return View(cLE_REPARTITION_FIXE.ToList().ToPagedList(pageNumber ?? 1, 30));
            }
        }

        // GET: CleRepFixe/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLE_REPARTITION_FIXE cLE_REPARTITION_FIXE = await db.CLE_REPARTITION_FIXE.FindAsync(id);
            if (cLE_REPARTITION_FIXE == null)
            {
                return HttpNotFound();
            }
            return View(cLE_REPARTITION_FIXE);
        }

        // GET: CleRepFixe/Create
        public ActionResult Create()
        {
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE"  );
            ViewBag.UR_REPARTITION = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE"  );
            ViewBag.NATURE_DEPENSE = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO");
            return View();
        }

        // POST: CleRepFixe/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDCLE_REP_FIXE,COMPTE_NUMERO,SIEGE_N_SIEGE,CODE_GROUPEMENT,UR_REPARTITION,CA_REPARTITION,NATURE_DEPENSE,TAUX_REPARTITION,ANNEE_COMPTABLE")] CLE_REPARTITION_FIXE cLE_REPARTITION_FIXE)
        {
            if (ModelState.IsValid)
            {
                var x = db.CLE_REPARTITION_FIXE.Where(p => p.COMPTE_NUMERO == cLE_REPARTITION_FIXE.COMPTE_NUMERO)
                   .Where(p => p.SIEGE_N_SIEGE == cLE_REPARTITION_FIXE.SIEGE_N_SIEGE)
                   .Where(p => p.UR_REPARTITION == cLE_REPARTITION_FIXE.UR_REPARTITION)
                   .Where(p => p.CA_REPARTITION == cLE_REPARTITION_FIXE.CA_REPARTITION).ToList();
                if (x.Count != 0)
                {
                    ViewBag.Message = " Une valeur existe deja pour cette clé de repartition fixe ! Pensez a le modifier ";
                    ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", cLE_REPARTITION_FIXE.SIEGE_N_SIEGE);

                }
                else
                {
                    try
                    {
                        db.CLE_REPARTITION_FIXE.Add(cLE_REPARTITION_FIXE);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }

                    catch (Exception e)
                    {
                        ViewBag.Message = " Operation non aboutie ! Erreur : " + e.Message
                             + " Contacter l'adminstrateur   ";

                        ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", cLE_REPARTITION_FIXE.SIEGE_N_SIEGE);
                        return View(cLE_REPARTITION_FIXE);
                    }
                }
            }

            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE","NUMERO_SIEGE", cLE_REPARTITION_FIXE.SIEGE_N_SIEGE);
            ViewBag.UR_REPARTITION = new SelectList(db.SIEGE, "NUMERO_SIEGE","NUMERO_SIEGE", cLE_REPARTITION_FIXE.UR_REPARTITION);
            ViewBag.NATURE_DEPENSE = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", cLE_REPARTITION_FIXE.NATURE_DEPENSE);
            return View(cLE_REPARTITION_FIXE);
        }

        // GET: CleRepFixe/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLE_REPARTITION_FIXE cLE_REPARTITION_FIXE = await db.CLE_REPARTITION_FIXE.FindAsync(id);
            if (cLE_REPARTITION_FIXE == null)
            {
                return HttpNotFound();
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE","NUMERO_SIEGE", cLE_REPARTITION_FIXE.SIEGE_N_SIEGE);
            ViewBag.UR_REPARTITION = new SelectList(db.SIEGE, "NUMERO_SIEGE","NUMERO_SIEGE", cLE_REPARTITION_FIXE.UR_REPARTITION);
            ViewBag.NATURE_DEPENSE = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", cLE_REPARTITION_FIXE.NATURE_DEPENSE);
            return View(cLE_REPARTITION_FIXE);
        }

        // POST: CleRepFixe/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDCLE_REP_FIXE,COMPTE_NUMERO,SIEGE_N_SIEGE,CODE_GROUPEMENT,UR_REPARTITION,CA_REPARTITION,NATURE_DEPENSE,TAUX_REPARTITION,ANNEE_COMPTABLE")] CLE_REPARTITION_FIXE cLE_REPARTITION_FIXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLE_REPARTITION_FIXE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", cLE_REPARTITION_FIXE.SIEGE_N_SIEGE);
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", cLE_REPARTITION_FIXE.SIEGE_N_SIEGE);
            ViewBag.NATURE_DEPENSE = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", cLE_REPARTITION_FIXE.NATURE_DEPENSE);
            return View(cLE_REPARTITION_FIXE);
        }

        // GET: CleRepFixe/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLE_REPARTITION_FIXE cLE_REPARTITION_FIXE = await db.CLE_REPARTITION_FIXE.FindAsync(id);
            if (cLE_REPARTITION_FIXE == null)
            {
                return HttpNotFound();
            }
            return View(cLE_REPARTITION_FIXE);
        }

        // POST: CleRepFixe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CLE_REPARTITION_FIXE cLE_REPARTITION_FIXE = await db.CLE_REPARTITION_FIXE.FindAsync(id);
            db.CLE_REPARTITION_FIXE.Remove(cLE_REPARTITION_FIXE);
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
