using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate;
using NHibernate.Cfg;

namespace EnduranceGoals
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory SessionFactory = CreateSessionFactory();

        protected static ISessionFactory CreateSessionFactory()
        {
            var configuration = new Configuration();
            var configure = configuration.Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EnduranceGoals.cfg.xml"));
            try
            {
                return configure.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                var innerMsg = ex.Message;
                throw;
            }
            
        }

        public static ISession CurrentSession
        {
            get { return (ISession)HttpContext.Current.Items["current.session"]; }
            set { HttpContext.Current.Items["current.session"] = value; }
        }

        protected void Global()
        {
            BeginRequest += delegate
            {
                CurrentSession = SessionFactory.OpenSession();
            };
            EndRequest += delegate
            {
                if (CurrentSession != null)
                    CurrentSession.Dispose();
            };
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}