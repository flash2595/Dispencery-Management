using System.Web;
using System.Web.Optimization;

namespace DispenceryManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/jquery.min.js",
                      "~/Scripts/popper.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery.backtotop.js",
                      "~/Scripts/jquery.mobilemenu.js",
                      "~/Scripts/typeahead.bundle.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/datatables/jquery.dataTables.js",
                      "~/Scripts/datatables/dataTables.bootstrap.js",
                      "~/Scripts/jquery-1.12.4.js",
                      "~/Scripts/jquery-ui.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/script.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/fontawsom-all.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/framework.css",
                      "~/Content/layout.css",
                      "~/Content/style.css",
                      "~/Content/typeahead.css",
                      "~/Content/datatables/css/dataTables.bootstrap.css",
                      "~/Content/bootstrap-glyphicons.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));
        }
    }
}
