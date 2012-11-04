using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;

namespace EnduranceGoals.Controllers
{
    public class CitiesController : Controller
    {
        // http://localhost/endurancegoals/cities/of/spain
        public ActionResult of([Bind(Prefix = "id")] string countryName)
        {
            Countries goals = new Countries(SessionProvider.OpenSession());

            var cityList = goals.GetByName(countryName).Cities;

            var jsonGoals = GetCityList(cityList);

            return Json(jsonGoals, JsonRequestBehavior.AllowGet);
        }



        private static IEnumerable<object> GetCityList(ICollection<City> cityList)
        {
            return cityList.Select(city => new
                                               {
                                                   Name = city.Name,
                                                   Country = city.Country.Name
                                               }).Cast<Object>();
        }
    }
}