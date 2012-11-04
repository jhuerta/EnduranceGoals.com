using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;

namespace EnduranceGoals.Controllers
{
    public class VenuesController : Controller
    {

        public ActionResult In([Bind(Prefix = "id")] string city)
        {
            // http://localhost/endurancegoals/venues/in/madrid

            Cities cities = new Cities(SessionProvider.CurrentSession);

            var venueList = cities.GetByName(city).Venues;

            var jsonGoals = GetVenueList(venueList);

            return Json(jsonGoals, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<object> GetVenueList(ICollection<Venue> venueList)
        {
            return venueList.Select(venue => new
                                                 {
                                                     Name = venue.City.Name,
                                                     Countr = venue.Name
                                                 }).Cast<Object>();
        }  
    }
}