using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp2BytesMusic
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteTable.Routes.MapPageRoute("", "", "~/login.aspx");
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}