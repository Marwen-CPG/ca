using AspNet.Identity.AdoNet;
using Comptabilite_Analytique.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comptabilite_Analytique.Controllers
{
    public class GridController : Controller
    {
        Model db = new Model();
        
        // GET: Grid

        public ActionResult Crf()
        {
            return View();
        }


        [HttpGet]
        public JsonResult getCleRepFixe()
        {
            var cLE_REPARTITION_FIXE = db.CLE_REPARTITION_FIXE ;

            var nb = cLE_REPARTITION_FIXE.ToList().Count;
            var l = cLE_REPARTITION_FIXE.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = cLE_REPARTITION_FIXE.ToList().Count,
                rows = (
                  from crf in l
                  select new
                  {
                      id = crf.IDCLE_REP_FIXE,
                      cell = new string[] {   
                      crf.NATURE_DEPENSE1.NUMERO.ToString(),
                      crf.COMPTE_NUMERO.ToString(),   
                      crf.SIEGE_N_SIEGE.ToString() ,   
                      crf.CODE_GROUPEMENT.ToString(),
                      crf.UR_REPARTITION.ToString(),   
                      crf.CA_REPARTITION.ToString() , 
                      crf.TAUX_REPARTITION.ToString() , 
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Crv()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getCleRepVar()
        {
            var cLE_REPARTITION_VAR = db.CLE_REPARTITION_VARIABLE;

            var nb = cLE_REPARTITION_VAR.ToList().Count;
            var l = cLE_REPARTITION_VAR.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = cLE_REPARTITION_VAR.ToList().Count,
                rows = (
                  from crf in l
                  select new
                  {
                      id = crf.IDCLE_REP_VAR,
                      cell = new string[] {   
                      crf.NATURE_DEPENSE1.NUMERO.ToString(),
                      crf.COMPTE_NUMERO.ToString(),   
                      crf.SIEGE_N_SIEGE.ToString() ,   
                      crf.CODE_GROUPEMENT.ToString(),
                      crf.UR_REPARTITION.ToString(),   
                      crf.CA_REPARTITION.ToString() , 
                      crf.TAUX_REPARTITION.ToString() , 
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Siege()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getSiege()
        {
            var Siege = db.SIEGE;

            var nb = Siege.ToList().Count;
            var liste = Siege.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = Siege.ToList().Count,
                rows = (
                  from val in liste
                  select new
                  {
                      id = val.NUMERO_SIEGE,
                      cell = new string[] {   
                      val.NUMERO_SIEGE.ToString(),
                      val.LIBELLE_FR.ToString(),   
                     val.LIBELLE_AR == null ? "" :val.LIBELLE_AR.ToString()  ,   
                   val.NUMERO_SIEGE_COMPTABLE.ToString() ,
                    
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Magasin()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getMagasin()
        {
            var Magasin = db.MAGASIN;

            var nb = Magasin.ToList().Count;
            var liste = Magasin.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = Magasin.ToList().Count,
                rows = (
                  from val in liste
                  select new
                  {
                      id = val.CODE_MAGASIN ,
                      cell = new string[] {   
                      val.CODE_MAGASIN.ToString(),
                      val.SIEGE_N_SIEGE.ToString(),
                      val.LIBELLE_FR == null ? "" : val.LIBELLE_FR.ToString(),   
                      val.LIBELLE_AR == null ? "" :val.LIBELLE_AR.ToString()  ,  
                      
                    
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Atelier()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getAtelier()
        {
            var Atelier = db.ATELIER;

            var nb = Atelier.ToList().Count;
            var liste = Atelier.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = Atelier.ToList().Count,
                rows = (
                  from val in liste
                  select new
                  {
                      id = val.CODE_ATELIER,
                      cell = new string[] {   
                      val.CODE_ATELIER.ToString(),
                      val.LIBELLE_FR == null ? "" :val.LIBELLE_FR.ToString()  ,    
                       val.LIBELLE_AR == null ? "" :val.LIBELLE_AR.ToString()  ,  
                      val.SIEGE_N_SIEGE == null ? "" :val.SIEGE_N_SIEGE.ToString()  ,  
                    
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Pca3()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getPca3()
        {
            var Pca3 = db.COMPTE_ANA3CH;

            var nb = Pca3.ToList().Count;
            var liste = Pca3.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = Pca3.ToList().Count,
                rows = (
                  from val in liste
                  select new
                  {
                      id = val.NUMERO,
                      cell = new string[] {   
                      val.NUMERO.ToString(),
                      val.LIBELLE_FR == null ? "" :val.LIBELLE_FR.ToString()  ,   
                       val.LIBELLE_AR == null ? "" :val.LIBELLE_AR.ToString()  ,  
 
                    
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Pca4()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getPca4()
        {
            var Pca4 = db.COMPTE_ANA4CH;

            var nb = Pca4.ToList().Count;
            var liste = Pca4.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = Pca4.ToList().Count,
                rows = (
                  from val in liste
                  select new
                  {
                      id = val.NUMERO,
                      cell = new string[] {   
                      val.NUMERO.ToString(),
                      val.LIBELLE_FR == null ? "" :val.LIBELLE_FR.ToString()  ,    
                       val.LIBELLE_AR == null ? "" :val.LIBELLE_AR.ToString()  ,  
 
                    
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Pca5()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getPca5()
        {
            var Pca5 = db.COMPTE_ANA5CH;

            var nb = Pca5.ToList().Count;
            var liste = Pca5.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = Pca5.ToList().Count,
                rows = (
                  from val in liste
                  select new
                  {
                      id = val.NUMERO,
                      cell = new string[] {   
                      val.NUMERO.ToString(),
                      val.SIEGE_N_SIEGE.ToString(),
                      val.LIBELLE_FR.ToString(),   
                       val.LIBELLE_AR == null ? "" :val.LIBELLE_AR.ToString()  ,  
 
                    
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult NatureDepense()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getNd()
        {
            var Nd = db.NATURE_DEPENSE;

            var nb = Nd.ToList().Count;
            var liste = Nd.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = Nd.ToList().Count,
                rows = (
                  from val in liste
                  select new
                  {
                      id = val.NUMERO,
                      cell = new string[] {  
                      val.NDR_NUMERO.ToString(),
                      val.NUMERO.ToString(),
                      val.LIBELLE_FR.ToString(),   
                       val.LIBELLE_AR == null ? "" :val.LIBELLE_AR.ToString()  ,  
 
                    
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NatureDepenseReg()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getNdr()
        {
            var Ndr = db.NATURE_DEPENSE_REG;

            var nb = Ndr.ToList().Count;
            var liste = Ndr.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = Ndr.ToList().Count,
                rows = (
                  from val in liste
                  select new
                  {
                      id = val.NUMERO,
                      cell = new string[] {  
                      val.NUMERO.ToString(),
                      val.LIBELLE_FR == null ? "" :val.LIBELLE_FR.ToString()  ,    
                       val.LIBELLE_AR == null ? "" :val.LIBELLE_AR.ToString()  ,       
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult NatureDepenseSub()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getNds()
        {
            var Nds = db.NATURE_DEPENSE_SUBVENTION;

            var nb = Nds.ToList().Count;
            var liste = Nds.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = Nds.ToList().Count,
                rows = (
                  from val in liste
                  select new
                  {
                      id = val.NUMERO,
                      cell = new string[] {  
                      val.ND_NUMERO.ToString(),
                      val.NUMERO.ToString(),
                      val.LIBELLE_FR == null ? "" :val.LIBELLE_FR.ToString()  ,  
                       val.LIBELLE_AR == null ? "" :val.LIBELLE_AR.ToString()  ,       
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MethRegComp()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getMrtc()
        {
            var Mrtc = db.METHODE_REG_COMPAGNIE;

            var nb = Mrtc.ToList().Count;
            var liste = Mrtc.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = Mrtc.ToList().Count,
                rows = (
                  from val in liste
                  select new
                  {
                      id = val.IDMETHODE_REG_COMPAGNIE,
                      cell = new string[] {  
                      val.COMPTE_ANA5_NUMERO.ToString(),
                      val.SIEGE_N_SIEGE.ToString(),
                      val.CODE_GROUPEMENT.ToString(),   
                      val.METHODE_REG_COMPAGNIE1.ToString() ,
                     val.LIBELLE_FR == null ? "" :val.LIBELLE_FR.ToString()  ,  
                       val.LIBELLE_AR == null ? "" :val.LIBELLE_AR.ToString()  , 
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MethRegSiege()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getMrts()
        {
            var Mrts = db.METHODE_REG_SIEGE;

            var nb = Mrts.ToList().Count;
            var liste = Mrts.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = Mrts.ToList().Count,
                rows = (
                  from val in liste
                  select new
                  {
                      id = val.IDMETHODE_REG_SIEGE,
                      cell = new string[] {  
                      val.COMPTE_ANA5_NUMERO.ToString(),
                      val.SIEGE_N_SIEGE.ToString(),
                      val.CODE_GROUPEMENT.ToString(),   
                      val.METHODE_REG_SIEGE1.ToString() ,
                     val.LIBELLE_FR == null ? "" :val.LIBELLE_FR.ToString()  ,  
                       val.LIBELLE_AR == null ? "" :val.LIBELLE_AR.ToString()  , 
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Ecriture()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getecriture()
        {
            var ecriture = db.ECRITURE_ANALYTIQUE;

            var nb = ecriture.ToList().Count;
            var liste = ecriture.ToList();
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = ecriture.ToList().Count,
                rows = (
                  from val in liste
                  select new
                  {
                      id = val.IDECRIRE_ANALYTIQUE,
                      cell = new string[] {  
                      val.ORIGINE.ToString(),
                      val.GROUPE.ToString(),
                      String.Format("{0:y}", val.DATE_ECRITURE) ,   
                      val.COMPTE_ANA5_NUMERO.ToString() ,
                      val.SIEGE_N_SIEGE.ToString() ,
                      val.ND_NUMERO.ToString() ,
                      val.MONTANT.ToString() ,
                     val.LIBELLE_FR == null ? "" :val.LIBELLE_FR.ToString()  ,  
                       val.LIBELLE_AR == null ? "" :val.LIBELLE_AR.ToString()  , 
               }
                  }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

    }
}