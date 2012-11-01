using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;
using NHibernate;

namespace EnduranceGoals.Controllers
{
    public class GoalController : Controller
    {

        public ActionResult Sport(string id)
        {
            // SessionProvider.OpenSession() --> This should come from the HTTP context!!!!! This is defeating the purpose of 
            // HTTPRequestModule and one session per request!

            Goals goals = new Goals(SessionProvider.OpenSession());
            Sports sports = new Sports(SessionProvider.OpenSession());
            var goalList = goals.GetAllBySport(sports.GetByName(id));

            var jsonGoals = BuildJsonGoal(goalList);

            return Json(new {success = jsonGoals}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            Goals goals = new Goals(SessionProvider.OpenSession());
            var goalList = goals.GetAll();

            var jsonGoals = BuildJsonGoal(goalList);

            return Json(new {success = jsonGoals}, JsonRequestBehavior.AllowGet);
        }

        private static IEnumerable<object> BuildJsonGoal(IEnumerable<Goal> goalList)
        {
            return goalList.Select(goal => new
            {
                Name = goal.Name,
                Location =
            string.Format("{0}, {1} - {2}", goal.Venue, goal.Venue.City,
                          goal.Venue.City.Country),
                Participants = goal.Participants.Count
            }).Cast<object>();
        }

    }
}
