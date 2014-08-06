using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sample.Web.MVC
{
    // 注意: 如需啟用 IIS6 或 IIS7 傳統模式的說明，
    // 請造訪 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static string RepositoryType
        {
            get
            {
                // Get Repository Assembly Name
                return WebConfigurationManager.AppSettings["RepositoryType"].ToString().Trim();
            }
        }

        public static string ConnectionString
        {
            get
            {
                return WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            }
        }

        public static string EFConnectionString
        {
            get
            {
                return WebConfigurationManager.ConnectionStrings["NorthwindEntities"].ConnectionString;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}