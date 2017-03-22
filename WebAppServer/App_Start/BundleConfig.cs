using System.Web;
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

			bundles.Add(new ScriptBundle("~/bundles/OwlCarouselJS").Include(
						 "~/WebAppDesign/design/js/owl.carousel.js"));

			bundles.Add(new ScriptBundle("~/bundles/DatePickerJS").Include(
						 "~/WebAppDesign/design/js/datepicker.js"));

			bundles.Add(new StyleBundle("~/bundles/css").Include(
						 "~/WebAppDesign/design/css/styles.css"
						 //,"~/WebAppDesign/design/css/normalize.css"
						 ));

			bundles.Add(new StyleBundle("~/bundles/OwlCarouselCSS").Include(
						 "~/WebAppDesign/design/css/owl.carousel.css",
						 "~/WebAppDesign/design/css/owl.theme.default.css"));

			bundles.Add(new StyleBundle("~/bundles/DatePickerCSS").Include(
						 "~/WebAppDesign/design/css/datepicker.css"));
		}
	}
}
