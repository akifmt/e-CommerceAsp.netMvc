using System.Web;
using System.Web.Optimization;

namespace eCommerce.MvcWebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            // Layout HEAD
            bundles.Add(new StyleBundle("~/Content/VendorCSS").Include(
                      "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/vendor/animate/animate.min.css",
                      "~/Content/vendor/simple-line-icons/css/simple-line-icons.min.css",
                      "~/Content/vendor/owl.carousel/assets/owl.carousel.min.css",
                      "~/Content/vendor/owl.carousel/assets/owl.theme.default.min.css",
                      "~/Content/vendor/magnific-popup/magnific-popup.min.css"
                      ));
            
            bundles.Add(new StyleBundle("~/Content/ThemeCSS").Include(
                      "~/Content/css/theme.css",
                      "~/Content/css/theme-elements.css",
                      "~/Content/css/theme-blog.css",
                      "~/Content/css/theme-shop.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/PageCSS").Include(
                      "~/Content/vendor/rs-plugin/css/settings.css",
                      "~/Content/vendor/rs-plugin/css/layers.css",
                      "~/Content/vendor/rs-plugin/css/navigation.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/OtherCSS").Include(
                      "~/Content/css/skins/skin-shop-6.css",
                      "~/Content/css/demos/demo-shop-6.css",
                      "~/Content/css/custom.css"
                      ));
            
            bundles.Add(new ScriptBundle("~/bundles/HeadLibs").Include(
                      "~/Content/vendor/modernizr/modernizr.min.js"
                      ));


            //Layout FOOT
            bundles.Add(new ScriptBundle("~/bundles/VendorJs").Include(
                      "~/Content/vendor/jquery/jquery.min.js",
                      "~/Content/vendor/jquery.appear/jquery.appear.min.js",
                      "~/Content/vendor/query.easing/jquery.easing.min.js",
                      "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Content/vendor/common/common.min.js",
                      "~/Content/vendor/jquery.validation/jquery.validation.min.js",
                      "~/Content/vendor/jquery.easy-pie-chart/jquery.easy-pie-chart.min.js",
                      "~/Content/vendor/jquery.gmap/jquery.gmap.min.js",
                      "~/Content/vendor/jquery.lazyload/jquery.lazyload.min.js",
                      "~/Content/vendor/isotope/jquery.isotope.min.js",
                      "~/Content/vendor/owl.carousel/owl.carousel.min.js",
                      "~/Content/vendor/magnific-popup/jquery.magnific-popup.min.js",
                      "~/Content/vendor/vide/vide.min.js"

                      ));

            bundles.Add(new ScriptBundle("~/bundles/OtherJs").Include(
                      "~/Content/js/theme.js",
                      "~/Content/js/views/view.contact.js",
                      "~/Content/js/demos/demo-shop-6.js",
                      "~/Content/js/custom.js",
                      "~/Content/js/theme.init.js"
                      ));

            

        }
    }
}
