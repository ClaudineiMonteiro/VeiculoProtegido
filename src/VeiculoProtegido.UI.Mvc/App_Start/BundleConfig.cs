using System.Web;
using System.Web.Optimization;

namespace VeiculoProtegido.UI.Mvc
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/vendor/jquery/dist/jquery.min.js"));

			//bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
			//			"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/vendor/modernizr/modernizr.js"));

			bundles.Add(new ScriptBundle("~/bootstrap").Include(
					  "~/vendor/jquery/dist/jquery.min.js",
					  "~/vendor/jquery-pjax/jquery.pjax.js",
					  "~/vendor/bootstrap-sass/assets/javascripts/bootstrap/transition.js",
					  "~/vendor/bootstrap-sass/assets/javascripts/bootstrap/collapse.js",
					  "~/vendor/bootstrap-sass/assets/javascripts/bootstrap/dropdown.js",
					  "~/vendor/bootstrap-sass/assets/javascripts/bootstrap/button.js",
					  "~/vendor/bootstrap-sass/assets/javascripts/bootstrap/tooltip.js",
					  "~/vendor/bootstrap-sass/assets/javascripts/bootstrap/alert.js",
					  "~/vendor/slimScroll/jquery.slimscroll.min.js",
					  "~/vendor/widgster/widgster.js",
					  "~/vendor/pace.js/pace.js",
					  "~/vendor/jquery-touchswipe/jquery.touchSwipe.js"
					  ));

			bundles.Add(new ScriptBundle("~/app").Include(
					  "~/js/settings.js",
					  "~/js/app.js"
					  ));

			bundles.Add(new ScriptBundle("~/cadastro").Include(
					  "~/vendor/bootstrap-sass/assets/javascripts/bootstrap/tooltip.js",
					  "~/vendor/bootstrap-sass/assets/javascripts/bootstrap/modal.js",
					  "~/vendor/bootstrap-select/dist/js/bootstrap-select.min.js",
					  "~/vendor/jquery-autosize/jquery.autosize.min.js",
					  "~/vendor/bootstrap3-wysihtml5/lib/js/wysihtml5-0.3.0.min.js",
					  "~/vendor/bootstrap3-wysihtml5/src/bootstrap3-wysihtml5.js",
					  "~/vendor/select2/select2.min.js",
					  "~/vendor/switchery/dist/switchery.min.js",
					  "~/vendor/moment/min/moment.min.js",
					  "~/vendor/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
					  "~/vendor/mjolnic-bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js",
					  "~/vendor/jasny-bootstrap/js/inputmask.js",
					  "~/vendor/jasny-bootstrap/js/fileinput.js",
					  "~/vendor/holderjs/holder.js",
					  "~/vendor/dropzone/dist/min/dropzone.min.js",
					  "~/vendor/markdown/lib/markdown.js",
					  "~/vendor/bootstrap-markdown/js/bootstrap-markdown.js",
					  "~/vendor/seiyria-bootstrap-slider/dist/bootstrap-slider.min.js"
					  ));

			bundles.Add(new StyleBundle("~/css").Include(
					  "~/css/application.min.css",
					  "~/vendor/bootstrap/dist/css/bootstrap.min.css.map",
					  "~/vendor/bootstrap/dist/css/bootstrap-theme.css",
					  "~/vendor/bootstrap/dist/css/bootstrap-theme.css.map",
					  "~/vendor/bootstrap/dist/css/bootstrap-theme.min.css",
					  "~/vendor/bootstrap/dist/css/bootstrap-theme.min.css.map",
					  "~/vendor/bootstrap/dist/css/bootstrap.css",
					  "~/vendor/bootstrap/dist/css/bootstrap.css.map"
					  ));
		}
	}
}
