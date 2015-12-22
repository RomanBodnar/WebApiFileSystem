using System.Web;
using System.Web.Optimization;

namespace WebApiFileSystem.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/Scripts").Include(
                    "~/Scripts/libs/angular.min.js",
                    "~/Scripts/libs/angular-route.min.js",
                    "~/Scripts/libs/bootstrap.min.js",
                    "~/Scripts/libs/modernizr-2.6.2.js",
                    "~/Scripts/app/module.js",
                    "~/Scripts/app/service.js"));
            bundles.Add(new StyleBundle("~/bundles/Content").Include(
                    "~/Content/Site.css",
                    "~/Content/bootstrap.min.css",
                    "~/Content/font-awesome.min.css"));
        }
    }
}
