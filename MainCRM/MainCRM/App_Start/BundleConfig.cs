using System.Web;
using System.Web.Optimization;

namespace MainCRM
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            RegisterCore(bundles);
            RegisterLayout(bundles);
            RegisterTables(bundles);
            RegisterForms(bundles);
            RegisterProgram(bundles);
            RegisterCompose(bundles);
            RegisterTimePicker(bundles);
            RegisterDashboard(bundles);
        }

        private static void RegisterCore(BundleCollection bundles)
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
                      //"~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

        }
        private static void RegisterShared(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/shared/_Layout").Include(
                "~/Scripts/shared/_Layout.js"));
        }
        private static void RegisterLayout(BundleCollection bundles)
        {
            //custom
            bundles.Add(new StyleBundle("~/Content/AdminLTE/css/custom").Include(
                "~/Content/AdminLTE/css/custom/custom.css"));
        
            // bootstrap
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/css/js").Include(
                "~/Content/AdminLTE/css/js/bootstrap.min.js",
                "~/Content/AdminLTE/plugins/datetimepicker/js/moment.js",
                "~/Content/AdminLTE/plugins/datetimepicker/js/locale/id.js"));

            bundles.Add(new StyleBundle("~/Content/AdminLTE/css").Include(
                      "~/Content/AdminLTE/css/bootstrap.min.css"));

            // admin-theme
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/dist/js").Include(
                "~/Content/AdminLTE/dist/js/app.js"));

            bundles.Add(new StyleBundle("~/Content/AdminLTE/dist").Include(
                      "~/Content/AdminLTE/dist/AdminLTE.css"));

            bundles.Add(new StyleBundle("~/Content/AdminLTE/dist/skins").Include(
                "~/Content/AdminLTE/dist/skins/_all-skins.css"));

           
            // plugins | fastclick
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/fastclick").Include(
                                         "~/Content/AdminLTE/plugins/fastclick/fastclick.min.js"));

            // plugins | font-awesome
            bundles.Add(new StyleBundle("~/Content/AdminLTE/plugins/font-awesome").Include(
                                        "~/Content/AdminLTE/plugins/font-awesome/font-awesome.min.css"));
           
            // plugins | slimscroll
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/slimscroll").Include(
                                         "~/Content/AdminLTE/plugins/slimscroll/jquery.slimscroll.min.js"));

            // plugins | select2
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/select2/js").Include(
                                         "~/Content/AdminLTE/plugins/select2/js/select2.full.min.js"));

            bundles.Add(new StyleBundle("~/Content/AdminLTE/plugins/select2").Include(
                                        "~/Content/AdminLTE/plugins/select2/select2.min.css"));

            // plugins | datatable
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/datatable/js").Include(
                                         "~/Content/AdminLTE/plugins/datatable/js/dataTables.bootstrap.min.js",
                                         "~/Content/AdminLTE/plugins/datatable/js/jquery.dataTables.min.js"));

            bundles.Add(new StyleBundle("~/Content/AdminLTE/plugins/datatable").Include(
                                        "~/Content/AdminLTE/plugins/datatable/dataTables.bootstrap.css"));
            // plugins | jquery
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/jquery/js").Include(
                                         "~/Content/AdminLTE/plugins/jquery/js/jQuery-2.2.3.min.js"));
        }
        private static void RegisterTables(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Scripts/datatable").Include(
                "~/Scripts/datatable/Data.js"));
            bundles.Add(new ScriptBundle("~/Scripts/datatable/menu").Include(
                "~/Scripts/datatable/Data-menu.js"));
            bundles.Add(new ScriptBundle("~/Scripts/datatable/menudept").Include(
                            "~/Scripts/datatable/Datadept-menu.js"));
            bundles.Add(new ScriptBundle("~/Scripts/datatable/menutarget").Include(
                            "~/Scripts/datatable/Datatarget-menu.js"));
        }

        private static void RegisterForms(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/select2").Include(
                "~/Scripts/select2/select.js"));
        }
        private static void RegisterDashboard(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/dashboard").Include(
                "~/Scripts/dashboard/Data.js"));
        }
        private static void RegisterProgram(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Scripts/program").Include(
                "~/Scripts/program/Data.js"));
            bundles.Add(new ScriptBundle("~/Scripts/program/menu").Include(
                            "~/Scripts/program/Data-menu.js"));
            bundles.Add(new ScriptBundle("~/Scripts/program/menumod").Include(
                            "~/Scripts/program/Datamod-menu.js"));
        }

        private static void RegisterMailbox(BundleCollection bundles)
        {

            // plugins | fullcalendar
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/fullcalendar/js").Include(
                                         "~/Content/AdminLTE/plugins/fullcalendar/js/fullcalendar.min.js"));

            bundles.Add(new StyleBundle("~/Content/AdminLTE/plugins/fullcalendar").Include(
                                        "~/Content/AdminLTE/plugins/fullcalendar/fullcalendar.min.css",
                                        "~/Content/AdminLTE/plugins/fullcalendar/fullcalendar.print.css"));
        }
        private static void RegisterCompose(BundleCollection bundles)
        {

            // plugins | wysihtml5
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/bootstrap-wysihtml5/js").Include(
                                         "~/Content/AdminLTE/plugins/bootstrap-wysihtml5/js/bootstrap3-wysihtml5.all.min.js",
                                          "~/Scripts/wysihtml5/Data.js"));

            bundles.Add(new StyleBundle("~/Content/AdminLTE/plugins/bootstrap-wysihtml5").Include(
                                        "~/Content/AdminLTE/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.css"));
            //menu
            bundles.Add(new ScriptBundle("~/Scripts/bidding").Include(
               "~/Scripts/bidding/Data.js"));
            bundles.Add(new ScriptBundle("~/Scripts/bidding/sent").Include(
               "~/Scripts/bidding/Sent-menu.js"));
        }
        private static void RegisterTimePicker(BundleCollection bundles)
        {

            // plugins | timepicker
           // bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/timepicker/js").Include(
                                         //"~/Content/AdminLTE/plugins/timepicker/js/bootstrap-timepicker.min.js"));

           // bundles.Add(new StyleBundle("~/Content/AdminLTE/plugins/timepicker").Include(
                                        //"~/Content/AdminLTE/plugins/timepicker/bootstrap-timepicker.min.css"));

            // plugins | datetimepicker
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/datetimepicker/js").Include(
                                         
                                         "~/Content/AdminLTE/plugins/datetimepicker/js/bootstrap-datetimepicker.min.js"));

            bundles.Add(new StyleBundle("~/Content/AdminLTE/plugins/datetimepicker").Include(
                                        "~/Content/AdminLTE/plugins/datetimepicker/bootstrap-datetimepicker.min.css"));

            // plugins | daterangepicker
            bundles.Add(new ScriptBundle("~/Content/AdminLTE/plugins/daterangepicker/js").Include(
                                         "~/Content/AdminLTE/plugins/daterangepicker/js/daterangepicker.js",
                                         "~/Content/AdminLTE/plugins/daterangepicker/js/moment.js"));

            bundles.Add(new StyleBundle("~/Content/AdminLTE/plugins/daterangepicker").Include(
                                        "~/Content/AdminLTE/plugins/daterangepicker/daterangepicker.css"));

        }
    }
}
