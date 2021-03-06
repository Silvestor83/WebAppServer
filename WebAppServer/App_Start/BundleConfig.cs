﻿using System.Web;
using System.Web.Optimization;

namespace WebAppServer
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
							"~/WebAppDesign/design/js/jquery-{version}.js",
							"~/WebAppDesign/design/js/jquery.unobtrusive-ajax.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
							"~/WebAppDesign/design/js/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
						 "~/WebAppDesign/design/js/bootstrap.js",
						 "~/WebAppDesign/design/js/respond.js"));

			bundles.Add(new ScriptBundle("~/bundles/fancyBoxJs").Include(
						 "~/WebAppDesign/design/js/jquery.fancybox.js"));

			bundles.Add(new StyleBundle("~/bundles/css").Include(
						 "~/WebAppDesign/design/css/styles.css",
						 "~/WebAppDesign/design/css/normalize.css"
						 ));

			bundles.Add(new StyleBundle("~/bundles/fancyBox").Include(
						 "~/WebAppDesign/design/css/jquery.fancybox.css"));
		}
	}
}
