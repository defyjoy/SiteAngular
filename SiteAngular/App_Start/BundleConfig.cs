using System.Web;
using System.Web.Optimization;

namespace SiteAngular
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jQuery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jQuery/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap/bootstrap.js",
                      "~/Scripts/respond/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include("~/Scripts/angular/angular.js","~/Scripts/angular/angular-*"));
            bundles.Add(new ScriptBundle("~/bundles/ngControllers").IncludeDirectory("~/Scripts/app/controllers","*.js",true));
            bundles.Add(new ScriptBundle("~/bundles/ngFactory").IncludeDirectory("~/Scripts/app/factory", "*.js", true));
            bundles.Add(new ScriptBundle("~/bundles/toastr").Include("~/Scripts/toastr/toastr*"));

            bundles.Add(new ScriptBundle("~/bundles/ngServices").IncludeDirectory("~/Scripts/app/services","*.js",true));

            bundles.Add(new ScriptBundle("~/bundles/app").Include("~/Scripts/app/startup.js","~/Scripts/app/routes/student/routes.js"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
