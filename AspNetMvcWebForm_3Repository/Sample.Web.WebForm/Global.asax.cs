using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Sample.Domain;
using Sample.Repository.Interface;
using Sample.Web.WebForm;
using SimpleInjector;
using StackExchange.Profiling;

namespace Sample.Web.WebForm
{
    public class Global : HttpApplication
    {
        public static string RepositoryType
        {
            get
            {
                return WebConfigurationManager.AppSettings["RepositoryType"].ToString();
            }
        }

        void Application_Start(object sender, EventArgs e)
        {
            // 應用程式啟動時執行的程式碼
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Simple Injector
            SimpleInjectorBootstrap();

            // MiniProfiler
            InitProfilerSettings();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  應用程式關閉時執行的程式碼

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 發生未處理錯誤時執行的程式碼

        }

        protected void Application_BeginRequest()
        {
            MiniProfiler profiler = null;
            // might want to decide here (or maybe inside the action) whether you want
            // to profile this request - for example, using an "IsSystemAdmin" flag against
            // the user, or similar; this could also all be done in action filters, but this
            // is simple and practical; just return null for most users. For our test, we'll
            // profile only for local requests (seems reasonable)
            if (Request.IsLocal)
            {
                profiler = MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }


        #region -- Simple Injector Bootstrap --

        private static Container container;

        [System.Diagnostics.DebuggerStepThrough]
        public static TService GetInstance<TService>()
            where TService : class
        {
            return container.GetInstance<TService>();
        }

        private void SimpleInjectorBootstrap()
        {
            //=====================================================================================
            // 1. Create a new Simple Injector container
            var container = new Container();

            //=====================================================================================
            // 2. Get Repository Assembly Name

            string repositoryType = WebConfigurationManager.AppSettings["RepositoryType"].ToString().Trim();

            //=====================================================================================
            // 3. Register Type for Repository

            string repositoryAssemblyName = repositoryType;
            string classFullName = string.Concat(repositoryType, ".CategoryRepository");

            //這邊加入類別的註冊
            container.Register
            (
                typeof(IEmployeeRepository),
                ReflectionHelper.GetType(repositoryType, string.Concat(repositoryType, ".EmployeeRepository"))
            );
            
            //=====================================================================================
            // 4. Store the container for use by Page classes.

            container.Verify();
            Global.container = container;

        }

        #endregion

        #region -- MiniProfiler Init Settings --

        private void InitProfilerSettings()
        {
            // some things should never be seen
            var ignored = MiniProfiler.Settings.IgnoredPaths.ToList();
            ignored.Add("WebResource.axd");
            ignored.Add("/Styles/");
            ignored.Add("/bundles/");
            MiniProfiler.Settings.IgnoredPaths = ignored.ToArray();
            MiniProfiler.Settings.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();
            MiniProfilerEF.Initialize();
        }

        #endregion
    
    
    }
}
