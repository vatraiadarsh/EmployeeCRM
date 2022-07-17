using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Adarsh.EmployeeCRM.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/bootstrap")
                .Include("~/Content/bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/js/bootstrap")
                .Include("~/Scripts/bootstrap.min.js"));
        }
    }
}