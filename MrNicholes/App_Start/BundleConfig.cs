﻿using System.Web.Optimization;

namespace MrNicholes
{
  public class BundleConfig
  {
    // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery")
        .Include("~/Scripts/jquery-{version}.js"));

      bundles.Add(new ScriptBundle("~/bundles/jqueryval")
        .Include("~/Scripts/jquery.validate*"));

      bundles.Add(new ScriptBundle("~/Scripts/bootstrap")
        .Include("~/Scripts/bootstrap.js"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
        "~/Scripts/modernizr-*"));

      bundles.Add(new StyleBundle("~/Styles/bootstrap")
        .Include("~/Content/Bootstrap/bootstrap.css")
        .Include("~/Content/site.css"));

      bundles.Add(new StyleBundle("~/Styles/kube")
        .Include("~/Content/Kube/css/kube.css")
        .Include("~/Content/Site.css"));

      // Set EnableOptimizations to false for debugging. For more information,
      // visit http://go.microsoft.com/fwlink/?LinkId=301862
      BundleTable.EnableOptimizations = false;
    }
  }
}