using System;
using System.Linq;
using System.Web;
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
                "GoalsPaginated", // Route name
                "goals/page/{page}", // URL with parameters
                new {controller = "Goals", action = "Index"} // Parameter defaults
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Goals", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            // Check this: http://stackoverflow.com/questions/1807298/configuring-automapper-in-bootstrapper-violates-open-closed-principle

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            Mapper.CreateMap<Goal, GoalViewModel>()
                .ForMember(dest => dest.Venues, opt => opt.ResolveUsing<VenuesToCollectionResolver>())
                .ForMember(dest => dest.Sports, opt => opt.ResolveUsing<SportsToCollectionResolver>())
                .ForMember(dest => dest.ListOrParticipants, opt => opt.ResolveUsing<ListOfParticipantsResolver>())
                .ForMember(dest => dest.NumberParticipants, source => source.MapFrom(item => item.Participants.Count))
                .ForMember(dest => dest.UserCanModifyEvent,
                           source => source.MapFrom(item => item.UserCreator.Username == HttpContext.Current.User.Identity.Name))
                .ForMember(dest => dest.Location,
                           source => source.MapFrom(item => { return String.Format("{0}, {1} ({2})",item.Venue, item.Venue.City,item.Venue.City.Country); }));
        }

    }
}