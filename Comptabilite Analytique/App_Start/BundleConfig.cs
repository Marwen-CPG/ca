using System.Web;
using System.Web.Optimization;

namespace Comptabilite_Analytique
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                       "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new StyleBundle("~/Content/themes/base/jqueryui")
                 .Include("~/Content/themes/base/all.css"));

             bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
             //js of admin theme
             bundles.Add(new ScriptBundle("~/bundles/themeb").Include(
                "~/theme/vendor/jquery/jquery.js",
                 "~/Scripts/jquery-ui.1.12.0.js",
                "~/theme/vendor/bootstrap/js/bootstrap.js",
                "~/theme/vendor/metisMenu/metisMenu.js",
                "~/theme/vendor/morrisjs/morrisjs.js",
                "~/theme/dist/js/sb-admin-2.js"));
             //admin theme stuff
             bundles.Add(new StyleBundle("~/theme/css").Include(
                 "~/theme/vendor/bootstrap/css/bootstrap.css",
                 "~/theme/vendor/metisMenu/metisMenu.css",
                 "~/theme/dist/css/sb-admin-2.css",
                 "~/Content/jquery-ui.css",
                 "~/theme/vendor/font-awesome/css/font-awesome.css"


                 ));
            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
