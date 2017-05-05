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
using System.Text.RegularExpressions;

namespace Comptabilite_Analytique.Controllers
{
    public class EcritureController : Controller
    {
        private Model db = new Model();

 
        public ActionResult Index(string chercher, int? pageNumber)
        {
            var eCRITURE_ANALYTIQUE = db.ECRITURE_ANALYTIQUE.Include(e => e.COMPTE_ANA5CH).Include(e => e.NATURE_DEPENSE).OrderBy(p => p.NUMERO_SEQUENCE);
            if (chercher != null && chercher.Length > 0)
            { return View(eCRITURE_ANALYTIQUE.Where(s => s.DATE_ECRITURE.Value.Month.ToString().ToLower().Contains(chercher.ToLower().Trim())).ToList().ToPagedList(pageNumber ?? 1, 1000)); }
            else
            {
                return View(eCRITURE_ANALYTIQUE.ToList().ToPagedList(pageNumber ?? 1, 30));
            }
        }

 
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECRITURE_ANALYTIQUE eCRITURE_ANALYTIQUE = await db.ECRITURE_ANALYTIQUE.FindAsync(id);
            if (eCRITURE_ANALYTIQUE == null)
            {
                return HttpNotFound();
            }
            return View(eCRITURE_ANALYTIQUE);
        }
        public ActionResult Ajoutert1()
        {
            //ViewBag.SIEGE_N_SIEGED = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE");
            //ViewBag.SIEGE_N_SIEGEC = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE");
            //ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO");
            return View();
        }


  
        //[Bind(Include = "ND_NUMERO,COMPTE_ANA5_NUMEROC,COMPTE_ANA5_NUMEROD,SIEGE_N_SIEGEC,SIEGE_N_SIEGED,ORIGINE,GROUPE,DATE_ECRITURE,LIBELLE_FR,LIBELLE_AR,MONTANT,CODE_BUDGETD,CODE_BUDGETC,COMPTE_GENERALE")] 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Ajoutert1(EcritureT1ViewModel eCRITURE_ANALYTIQUE)
        {
            Regex e = new Regex(@"\d{6}$");
            var etat = db.ETAT_GLOBALE.First();
            ECRITURE_ANALYTIQUE ecrituredebit = new ECRITURE_ANALYTIQUE();
            ECRITURE_ANALYTIQUE ecriturecredit = new ECRITURE_ANALYTIQUE();
            string err = "";

            ecrituredebit.GROUPE = eCRITURE_ANALYTIQUE.GROUPE;
            ecrituredebit.ORIGINE = eCRITURE_ANALYTIQUE.ORIGINE;
            ecrituredebit.SIEGE_N_SIEGE = eCRITURE_ANALYTIQUE.SIEGE_N_SIEGED;
            ecrituredebit.ND_NUMERO = eCRITURE_ANALYTIQUE.ND_NUMERO;
            ecrituredebit.COMPTE_ANA5_NUMERO = eCRITURE_ANALYTIQUE.COMPTE_ANA5_NUMEROD;
            ecrituredebit.MONTANT = eCRITURE_ANALYTIQUE.MONTANT;
            ecrituredebit.CODE_BUDGET = eCRITURE_ANALYTIQUE.CODE_BUDGETD;
            ecrituredebit.COMPTE_GENERALE = eCRITURE_ANALYTIQUE.COMPTE_GENERALE;
            ecrituredebit.LIBELLE_FR = eCRITURE_ANALYTIQUE.LIBELLE_FR;
            ecrituredebit.LIBELLE_AR = eCRITURE_ANALYTIQUE.LIBELLE_AR;
            ecrituredebit.DATE_ECRITURE = eCRITURE_ANALYTIQUE.DATE_ECRITURE;
            ecrituredebit.DATE_AJOUT = DateTime.Now;
            ecrituredebit.NUMERO_SEQUENCE = etat.NUMSEQ.ToString();
            ecrituredebit.NUMERO_ECRITURE = etat.NUMECR.ToString();
            ecrituredebit.ANNEE_COMPTABLE = etat.ANNEE_COMPTABLE;

            ecriturecredit.GROUPE = eCRITURE_ANALYTIQUE.GROUPE;
            ecriturecredit.ORIGINE = eCRITURE_ANALYTIQUE.ORIGINE;
            ecriturecredit.SIEGE_N_SIEGE = eCRITURE_ANALYTIQUE.SIEGE_N_SIEGEC;
            ecriturecredit.ND_NUMERO = eCRITURE_ANALYTIQUE.ND_NUMERO;
            ecriturecredit.COMPTE_ANA5_NUMERO = eCRITURE_ANALYTIQUE.COMPTE_ANA5_NUMEROC;
            ecriturecredit.MONTANT = (eCRITURE_ANALYTIQUE.MONTANT * -1);
            ecriturecredit.CODE_BUDGET = eCRITURE_ANALYTIQUE.CODE_BUDGETC;
            ecriturecredit.COMPTE_GENERALE = eCRITURE_ANALYTIQUE.COMPTE_GENERALE;
            ecriturecredit.LIBELLE_FR = eCRITURE_ANALYTIQUE.LIBELLE_FR;
            ecriturecredit.LIBELLE_AR = eCRITURE_ANALYTIQUE.LIBELLE_AR;
            ecriturecredit.DATE_ECRITURE = eCRITURE_ANALYTIQUE.DATE_ECRITURE;
            ecriturecredit.DATE_AJOUT = DateTime.Now;
            ecriturecredit.NUMERO_ECRITURE = etat.NUMECR.ToString();
            ecriturecredit.NUMERO_SEQUENCE = (etat.NUMSEQ + 1).ToString();
            ecriturecredit.ANNEE_COMPTABLE = etat.ANNEE_COMPTABLE;
            etat.NUMSEQ+=2;
            etat.NUMECR++;

            if (eCRITURE_ANALYTIQUE.COMPTE_ANA5_NUMEROC.ToString().Substring(0, 2) == "93" && String.IsNullOrWhiteSpace(eCRITURE_ANALYTIQUE.CODE_BUDGETC)  )
            {
                ModelState.AddModelError("CODE_BUDGETC", "Veuillez saisir le Code Budget !!");
            ViewBag.Message="le Code Budget doit être compsé de  6 chiffres !!";}
            else if (e.IsMatch(eCRITURE_ANALYTIQUE.CODE_BUDGETD))
            { ModelState.AddModelError("CODE_BUDGETD", "le Code Budget doit être compsé de  6 chiffres !!"); }

            if (eCRITURE_ANALYTIQUE.COMPTE_ANA5_NUMEROD.ToString().Substring(0, 2) == "93" && String.IsNullOrWhiteSpace(eCRITURE_ANALYTIQUE.CODE_BUDGETD))
            {
                ModelState.AddModelError("CODE_BUDGETD", "Veuillez saisir le Code Budget !!");
            }
            else if (e.IsMatch(eCRITURE_ANALYTIQUE.CODE_BUDGETD))
            { ModelState.AddModelError("CODE_BUDGETD", "le Code Budget doit être compsé de  6 chiffres !!"); }
            if (ModelState.IsValid)
            {
                var cc = db.COMPTE_ANA5CH.Where(c => c.NUMERO == eCRITURE_ANALYTIQUE.COMPTE_ANA5_NUMEROD
                    && c.SIEGE_N_SIEGE == eCRITURE_ANALYTIQUE.SIEGE_N_SIEGED).ToList();
                if (cc.Count == 0)
                {
                    err += "La paire  Compte  Siege n'existe pas dans le plan comptable !! veuillez verifier les données saisies ... ";
                    ViewBag.Message = err;
                    //ViewBag.SIEGE_N_SIEGED = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGED);
                    //ViewBag.SIEGE_N_SIEGEC = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGEC);
                    //ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", eCRITURE_ANALYTIQUE.ND_NUMERO);
                    return View(eCRITURE_ANALYTIQUE);
                }
                var x = db.ECRITURE_ANALYTIQUE.Where(p => p.COMPTE_ANA5_NUMERO == eCRITURE_ANALYTIQUE.COMPTE_ANA5_NUMEROD)
                          .Where(p => p.SIEGE_N_SIEGE == eCRITURE_ANALYTIQUE.SIEGE_N_SIEGED)
                          .Where(p => p.DATE_ECRITURE == eCRITURE_ANALYTIQUE.DATE_ECRITURE)
                          .Where(p => p.MONTANT == eCRITURE_ANALYTIQUE.MONTANT)
                          .Where(p => p.ORIGINE == eCRITURE_ANALYTIQUE.ORIGINE)
                          .Where(p => p.GROUPE == eCRITURE_ANALYTIQUE.GROUPE)
                          .Where(p => p.ND_NUMERO == eCRITURE_ANALYTIQUE.ND_NUMERO).ToList();
                if (x.Count != 0)
                {
                    ViewBag.Message = " Une valeur existe deja pour cette ecriture ! Pensez a la modifier ";
                    //ViewBag.SIEGE_N_SIEGED = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGED);
                    //ViewBag.SIEGE_N_SIEGEC = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGEC);
                    //ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", eCRITURE_ANALYTIQUE.ND_NUMERO);

                }
                else
                {
                    try
                    {
                        db.ECRITURE_ANALYTIQUE.Add(ecrituredebit);
                        db.ECRITURE_ANALYTIQUE.Add(ecriturecredit);
                        db.Entry(etat).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }

                    catch (Exception ex)
                    {
                        ViewBag.Message = " Operation non aboutie ! Erreur : " + ex.Message
                             + " Contacter l'adminstrateur   ";

                        //ViewBag.SIEGE_N_SIEGED = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGED);
                        //ViewBag.SIEGE_N_SIEGEC = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGEC);
                        //ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", eCRITURE_ANALYTIQUE.ND_NUMERO);
                        return View(eCRITURE_ANALYTIQUE);
                    }
                }
            }

            //ViewBag.SIEGE_N_SIEGED = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGED);
            //ViewBag.SIEGE_N_SIEGEC = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGEC);
            //ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", eCRITURE_ANALYTIQUE.ND_NUMERO);
            return View(eCRITURE_ANALYTIQUE);
        }
        public ActionResult Ajouter()
        {
            ViewBag.SIEGE_N_SIEGED = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE");
            ViewBag.SIEGE_N_SIEGEC = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE");
            ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO");
            return View();
        }

        //[Bind(Include = "ND_NUMERO,COMPTE_ANA5_NUMEROC,COMPTE_ANA5_NUMEROD,SIEGE_N_SIEGEC,SIEGE_N_SIEGED,ORIGINE,GROUPE,DATE_ECRITURE,LIBELLE_FR,LIBELLE_AR,MONTANT,CODE_BUDGETD,CODE_BUDGETC,COMPTE_GENERALE")] 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Ajouter(EcritureMultiligneViewModel eCRITURE_ANALYTIQUE, FormCollection col)
        {


            var etat = db.ETAT_GLOBALE.First();
            ECRITURE_ANALYTIQUE ecriture = new ECRITURE_ANALYTIQUE();
            string err = "";
            Int16 n = 0;

            foreach (string e in col.Keys)
            {
                if (e.Equals("naturedepense" + n.ToString()))
                    n++;
            }
            var m = n - 1;
            var a = col.Keys.Count;
            while (col["naturedepense" + n.ToString()] != null)
            {
                ecriture.GROUPE = eCRITURE_ANALYTIQUE.GROUPE;
                ecriture.ORIGINE = eCRITURE_ANALYTIQUE.ORIGINE;
                ecriture.SIEGE_N_SIEGE = col["siege" + n.ToString()];
                ecriture.ND_NUMERO = col["naturedepense" + n.ToString()];
                ecriture.COMPTE_ANA5_NUMERO = int.Parse(col["compte" + n.ToString()]);
                ecriture.MONTANT = Decimal.Parse(col["montant" + n.ToString()]);
                ecriture.CODE_BUDGET = col["codebudget" + n.ToString()];
                ecriture.LIBELLE_FR = col["naturedepense" + n.ToString()];
                ecriture.DATE_ECRITURE = eCRITURE_ANALYTIQUE.DATE_ECRITURE;
                ecriture.DATE_AJOUT = DateTime.Now;
                ecriture.NUMERO_SEQUENCE = etat.NUMSEQ.ToString();
                ecriture.NUMERO_ECRITURE = etat.NUMECR.ToString();
                var e = ecriture;
                n++;
            }
            var mx = n;




            if (ModelState.IsValid)
            {
                var cc = db.COMPTE_ANA5CH.Where(c => c.NUMERO == eCRITURE_ANALYTIQUE.COMPTE_ANA5_NUMEROD
                    && c.SIEGE_N_SIEGE == eCRITURE_ANALYTIQUE.SIEGE_N_SIEGED).ToList();
                if (cc.Count == 0)
                {
                    err += "La paire  Compte  Siege n'existe pas dans le plan comptable !! veuillez verifier les données saisies ... ";
                    ViewBag.Message = err;
                    ViewBag.SIEGE_N_SIEGED = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGED);
                    ViewBag.SIEGE_N_SIEGEC = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGEC);
                    ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", eCRITURE_ANALYTIQUE.ND_NUMERO);
                    return View(eCRITURE_ANALYTIQUE);
                }
                var x = db.ECRITURE_ANALYTIQUE.Where(p => p.COMPTE_ANA5_NUMERO == eCRITURE_ANALYTIQUE.COMPTE_ANA5_NUMEROD)
                          .Where(p => p.SIEGE_N_SIEGE == eCRITURE_ANALYTIQUE.SIEGE_N_SIEGED)
                          .Where(p => p.DATE_ECRITURE == eCRITURE_ANALYTIQUE.DATE_ECRITURE)
                          .Where(p => p.MONTANT == eCRITURE_ANALYTIQUE.MONTANT)
                          .Where(p => p.ORIGINE == eCRITURE_ANALYTIQUE.ORIGINE)
                          .Where(p => p.GROUPE == eCRITURE_ANALYTIQUE.GROUPE)
                          .Where(p => p.ND_NUMERO == eCRITURE_ANALYTIQUE.ND_NUMERO).ToList();
                if (x.Count != 0)
                {
                    ViewBag.Message = " Une valeur existe deja pour cette ecriture ! Pensez a la modifier ";
                  

                }
                else
                {
                    try
                    {
                        db.ECRITURE_ANALYTIQUE.Add(ecriture);
                        db.Entry(etat).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }

                    catch (Exception e)
                    {
                        ViewBag.Message = " Operation non aboutie ! Erreur : " + e.Message
                             + " Contacter l'adminstrateur   ";

                         
                        return View(eCRITURE_ANALYTIQUE);
                    }
                }
            }

           
            return View(eCRITURE_ANALYTIQUE);
        }
 
        public ActionResult Create()
        {
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE");
            ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDECRIRE_ANALYTIQUE,ND_NUMERO,COMPTE_ANA5_NUMERO,SIEGE_N_SIEGE,NUMERO_SEQUENCE,ORIGINE,GROUPE,DATE_ECRITURE,NUMERO_ECRITURE,LIBELLE_FR,LIBELLE_AR,DATE_AJOUT,ANNEE_COMPTABLE,MONTANT,CODE_BUDGET,CENTRE_ECRITURE,COMPTE_GENERALE")] ECRITURE_ANALYTIQUE eCRITURE_ANALYTIQUE)
        {
            string err ="" ;
            eCRITURE_ANALYTIQUE.NUMERO_ECRITURE =  "" ; 
            eCRITURE_ANALYTIQUE.NUMERO_SEQUENCE =   "";
            if (ModelState.IsValid)
            {
                var cc = db.COMPTE_ANA5CH.Where(c => c.NUMERO == eCRITURE_ANALYTIQUE.COMPTE_ANA5_NUMERO
                    && c.SIEGE_N_SIEGE == eCRITURE_ANALYTIQUE.SIEGE_N_SIEGE ).ToList();
                if (cc.Count == 0)
                { err += "La paire  Compte  Siege n'existe pas dans le plan comptable !! veuillez verifier les donnees saisies ... ";
                ViewBag.Message = err;
                ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGE);
                ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", eCRITURE_ANALYTIQUE.ND_NUMERO);
                return View(eCRITURE_ANALYTIQUE);
                }
                var x = db.ECRITURE_ANALYTIQUE.Where(p => p.COMPTE_ANA5_NUMERO == eCRITURE_ANALYTIQUE.COMPTE_ANA5_NUMERO)
                          .Where(p => p.SIEGE_N_SIEGE == eCRITURE_ANALYTIQUE.SIEGE_N_SIEGE)
                          .Where(p => p.DATE_ECRITURE == eCRITURE_ANALYTIQUE.DATE_ECRITURE)
                          .Where(p => p.MONTANT == eCRITURE_ANALYTIQUE.MONTANT)
                          .Where(p => p.ORIGINE == eCRITURE_ANALYTIQUE.ORIGINE)
                          .Where(p => p.GROUPE == eCRITURE_ANALYTIQUE.GROUPE)
                          .Where(p => p.ND_NUMERO == eCRITURE_ANALYTIQUE.ND_NUMERO).ToList();
                if (x.Count != 0)
                {
                    ViewBag.Message = " Une valeur existe deja pour cette ecriture ! Pensez a la modifier ";
                    ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGE);

                }
                else
                {
                    try
                    {
                        db.ECRITURE_ANALYTIQUE.Add(eCRITURE_ANALYTIQUE);
                        await db.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }

                    catch (Exception e)
                    {
                        ViewBag.Message = " Operation non aboutie ! Erreur : " + e.Message
                             + " Contacter l'adminstrateur   ";

                        ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGE);
                        ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", eCRITURE_ANALYTIQUE.ND_NUMERO);
                        return View(eCRITURE_ANALYTIQUE);
                    }
                }
            }
          
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGE);
            ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", eCRITURE_ANALYTIQUE.ND_NUMERO);
            return View(eCRITURE_ANALYTIQUE);
        }
 
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECRITURE_ANALYTIQUE eCRITURE_ANALYTIQUE = await db.ECRITURE_ANALYTIQUE.FindAsync(id);
            if (eCRITURE_ANALYTIQUE == null)
            {
                return HttpNotFound();
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGE);
            ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", eCRITURE_ANALYTIQUE.ND_NUMERO);
            return View(eCRITURE_ANALYTIQUE);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDECRIRE_ANALYTIQUE,ND_NUMERO,COMPTE_ANA5_NUMERO,SIEGE_N_SIEGE,NUMERO_SEQUENCE,ORIGINE,GROUPE,DATE_ECRITURE,NUMERO_ECRITURE,LIBELLE_FR,LIBELLE_AR,DATE_AJOUT,ANNEE_COMPTABLE,MONTANT,CODE_BUDGET,CENTRE_ECRITURE,COMPTE_GENERALE")] ECRITURE_ANALYTIQUE eCRITURE_ANALYTIQUE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eCRITURE_ANALYTIQUE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SIEGE_N_SIEGE = new SelectList(db.SIEGE, "NUMERO_SIEGE", "NUMERO_SIEGE", eCRITURE_ANALYTIQUE.SIEGE_N_SIEGE);
            ViewBag.ND_NUMERO = new SelectList(db.NATURE_DEPENSE, "NUMERO", "NUMERO", eCRITURE_ANALYTIQUE.ND_NUMERO);
            return View(eCRITURE_ANALYTIQUE);
        }

 
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECRITURE_ANALYTIQUE eCRITURE_ANALYTIQUE = await db.ECRITURE_ANALYTIQUE.FindAsync(id);
            if (eCRITURE_ANALYTIQUE == null)
            {
                return HttpNotFound();
            }
            return View(eCRITURE_ANALYTIQUE);
        }

 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ECRITURE_ANALYTIQUE eCRITURE_ANALYTIQUE = await db.ECRITURE_ANALYTIQUE.FindAsync(id);
            db.ECRITURE_ANALYTIQUE.Remove(eCRITURE_ANALYTIQUE);
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
        #region validation
        public JsonResult ValidateSC(string SIEGE_N_SIEGED, int COMPTE_ANA5_NUMEROD)
        {
            if (!this.Request.IsAjaxRequest()) return null;
            var cc = db.COMPTE_ANA5CH.Where(c => c.NUMERO == COMPTE_ANA5_NUMEROD
                       && c.SIEGE_N_SIEGE == SIEGE_N_SIEGED).ToList();
            if (cc.Count == 0)
                return Json(string.Format("La paire  Compte '{0}' Siege '{1}' n'existe pas dans le plan comptable !!", COMPTE_ANA5_NUMEROD, SIEGE_N_SIEGED), JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ValidateSCC(string SIEGE_N_SIEGEC, int COMPTE_ANA5_NUMEROC)
        {
            if (!this.Request.IsAjaxRequest()) return null;
            var cc = db.COMPTE_ANA5CH.Where(c => c.NUMERO == COMPTE_ANA5_NUMEROC
                       && c.SIEGE_N_SIEGE == SIEGE_N_SIEGEC).ToList();
            if (cc.Count == 0)
                return Json(string.Format("La paire  Compte '{0}' Siege '{1}' n'existe pas dans le plan comptable !!", COMPTE_ANA5_NUMEROC, SIEGE_N_SIEGEC), JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ValidateND(string ND_NUMERO)
        {
            if (!this.Request.IsAjaxRequest()) return null;
            var cc = db.NATURE_DEPENSE.Where(c => c.NUMERO.Substring(2, 2) == ND_NUMERO).ToList();
            if (cc.Count == 0)
                return Json(string.Format("La nature dépense '{0}' n'existe pas!!", ND_NUMERO), JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ValidateSG(string SIEGE_N_SIEGED)
        {
            if (!this.Request.IsAjaxRequest()) return null;
            var cc = db.SIEGE.Where(c => c.NUMERO_SIEGE  == SIEGE_N_SIEGED).ToList();
            if (cc.Count == 0)
                return Json(string.Format("Le siège '{0}' n'existe pas !!", SIEGE_N_SIEGED), JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ValidateSGC(string SIEGE_N_SIEGEC)
        {
            if (!this.Request.IsAjaxRequest()) return null;
            var cc = db.SIEGE.Where(c => c.NUMERO_SIEGE == SIEGE_N_SIEGEC).ToList();
            if (cc.Count == 0)
                return Json(string.Format("Le siège '{0}' n'existe pas !!", SIEGE_N_SIEGEC), JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateCBD(string CODE_BUDGETD , string COMPTE_ANA5_NUMEROD)
        { Regex e = new Regex(@"\d{6}$");
            if (!this.Request.IsAjaxRequest()) return null;
                   
                if (COMPTE_ANA5_NUMEROD.Substring(0, 2) == "93" && String.IsNullOrWhiteSpace(CODE_BUDGETD) && CODE_BUDGETD.Length < 6)
                return Json(string.Format("Veuillez saisir le Code Budget !! "), JsonRequestBehavior.AllowGet);
                if (!e.IsMatch(CODE_BUDGETD))
                  return Json(string.Format("le Code Budget doit être compsé de  6 chiffres !! "), JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ValidateCBC(string CODE_BUDGETC, string COMPTE_ANA5_NUMEROC)
        {
            if (!this.Request.IsAjaxRequest()) return null;

            if (COMPTE_ANA5_NUMEROC.Substring(0, 2) == "93" && String.IsNullOrWhiteSpace(CODE_BUDGETC) && CODE_BUDGETC.Length < 6 )
                return Json(string.Format("Veuillez saisir le Code Budget !! "), JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
