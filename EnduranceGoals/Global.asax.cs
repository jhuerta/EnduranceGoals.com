using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using EnduranceGoals.Models;
using EnduranceGoals.Models.ViewModels;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using GoalViewModel = EnduranceGoals.Models.ViewModels.GoalViewModel;

namespace EnduranceGoals
{
    public class MvcApplication : System.Web.HttpApplication
    {
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
            // Check this: http://stackoverflow.com/questions/1807298/configuring-automapper-in-bootstrapper-violates-open-closed-principle

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            Mapper.CreateMap<Goal, GoalViewModel>();

            Mapper.AssertConfigurationIsValid();

            NHibernateProfiler.Initialize();
        }
    }
}