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
            return new JsonResult();
            //var firstUser = entity.Users.FirstOrDefault();
            //firstUser.Username = new Random().Next().ToString();

            //var myentity = new EnduranceGoalsEntities();
            
            
            

            //return Json(
            //    new
            //        {
            //            Users = entity.Users.Select(s => s.Username),
            //            Goals = entity.Goals.Select(s => s.Id),
            //            Cities = entity.Cities.Select(s => s.Id),
            //            Countries = entity.Countries.Select(c => c.Id),
            //            Venues = entity.Venues.Select(v => v.Id)
            //        }, JsonRequestBehavior.AllowGet
            //    );
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
