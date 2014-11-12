using System.Web.Optimization;

namespace ServerManager
{
  public class BundleConfig
  {
    // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-{version}.js"));

      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.validate*"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/font-awesome.css",
                "~/Content/ngToast.css",
                "~/Content/site.css"));

      bundles.Add(new ScriptBundle("~/bundles/src").Include(
                "~/Scripts/src/app.js"));

      bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                  "~/Scripts/angular.js",
                  "~/Scripts/angular-animate.js",
                  "~/Scripts/angular-route.js",
                  "~/Scripts/angular-sanitize.js",
                  "~/Scripts/ngToast.js",
                  "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                  "~/Scripts//angular-ui/smart-table.js"));

      // Set EnableOptimizations to false for debugging. For more information,
      // visit http://go.microsoft.com/fwlink/?LinkId=301862
      BundleTable.EnableOptimizations = false;
    }
  }
}
