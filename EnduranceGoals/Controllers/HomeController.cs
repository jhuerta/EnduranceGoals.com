using System;
using System.Data.Objects;
using System.Linq;
using System.Web.Mvc;
using EnduranceGoals.Models;

namespace EnduranceGoals.Controllers
{
    [HandleError]
    public class HomeController : EFControllerBase
    {
        

    
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        [HandleError]
        public ActionResult Test()
        {
            var firstUser = entity.Users.FirstOrDefault();
            firstUser.Username = new Random().Next().ToString();

            var myentity = new EnduranceGoalsEntities();
            
            
            

            return Json(
                new
                    {
                        Users = entity.Users.Select(s => s.Username),
                        Goals = entity.Goals.Select(s => s.GoalId),
                        Cities = entity.Cities.Select(s => s.CityId),
                        Countries = entity.Countries.Select(c => c.CountryId),
                        Venues = entity.Venues.Select(v => v.VenueId)
                    }, JsonRequestBehavior.AllowGet
                );
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
