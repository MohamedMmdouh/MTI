using System.Web;
using System.Web.Optimization;

namespace MTI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/jquary-ui.js",             
                        "~/Scripts/jspdf.js",
                        "~/Scripts/jquary.min.js",
                        "~/Scripts/Cavans.js",
                        "~/Scripts/jquery.marquee.js",
                        "~/Scripts/jquery.marquee.min.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js",
                        "~/Scripts/MTI/Main/Main.js"

                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(
                new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-spacelap.css",
                      "~/Content/datatables/datatables.bootstrap.css",
                      "~/Conten/jquery-ui.css",
                      "~/Content/Student-profile.css",
                      "~/Content/Site.css",
                      "~/Content/toastr.css",
                      "~/Content/Styles/Main.css"
                      )
                 );


            // scripts
            bundles.Add(new ScriptBundle("~/Scripts/Index").Include(
                "~/Scripts/MTI/Home/Index.js"
                ));


            // Styles
            bundles.Add(new StyleBundle("~/Styles/Login").Include(
                "~/Content/Style/Account/Login.css"
                ));

            bundles.Add(new StyleBundle("~/Styles/Attend").Include(
                "~/Content/Style/Attened/create"
                ));
        }
    }
}
