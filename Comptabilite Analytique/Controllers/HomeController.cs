using Comptabilite_Analytique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comptabilite_Analytique.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Model db = new Model();
            var etat = db.ETAT_GLOBALE.FirstOrDefault();

            ViewBag.AnneeComptable = etat.ANNEE_COMPTABLE;
            ViewBag.MoisComptable = etat.MOISENCOURS;
            if (etat.CHEVAUCHEMENT)

            { ViewBag.Chevauchement = "Oui";
            ViewBag.MoisChevauchement = etat.MOISCHEV;
            }
            else {
                ViewBag.Chevauchement = "Non";
                ViewBag.MoisChevauchement = "N/D"; }

            if (etat.VEROUILLE)

            ViewBag.EtatSystème = "Bloqué";
            else
                ViewBag.EtatSystème = "Accessible";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}