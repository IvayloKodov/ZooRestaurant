namespace ZooRestaurant.Web
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Infrastructure.Mapping;
    using Models.Contracts;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            // Add /MyVeryOwn/ folder to the default location scheme for STANDARD Views
            var razorEngine = ViewEngines.Engines.OfType<RazorViewEngine>().First();
            razorEngine.ViewLocationFormats =
                razorEngine.ViewLocationFormats.Concat(new string[] {
            "~/Areas/Admin/Views/{1}/{0}.cshtml"
                    // add other folders here (if any)
                }).ToArray();

            // Add /MyVeryOwnPartialFolder/ folder to the default location scheme for PARTIAL Views
            razorEngine.PartialViewLocationFormats =
                razorEngine.PartialViewLocationFormats.Concat(new string[] {
            "~/Areas/Admin/Views/{1}/{0}.cshtml"
                    // add other folders here (if any)
                }).ToArray();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            DatabaseConfig.Initialize();
            AutoMapperConfig.Initialize(typeof(IMapping).Assembly);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
