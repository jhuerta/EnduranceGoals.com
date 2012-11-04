using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EnduranceGoals.Controllers.ViewModelBuilders;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;
using EnduranceGoals.Models.ViewModels;
using NHibernate;

namespace EnduranceGoals.Controllers
{
    public class GoalsController : Controller
    {

        public void html([Bind(Prefix = "id")] string name)
        {
            Goals goals = new Goals(SessionProvider.CurrentSession);
            Sports sports = new Sports(SessionProvider.CurrentSession);
            var goalList = goals.GetAllBySport(sports.GetByName(name));
            string html = "<ul>";
            foreach (Goal goal in goalList)
            {
                html += string.Format("<li> -Name: {0} <br/>-Description: {1}</li>", goal.Name, goal.Description);
            }
            html += "</ul>";

            Response.Write(html);
        }
        public ActionResult BySportName([Bind(Prefix = "id")] string name)
        {
            // http://localhost/endurancegoals/goals/bysportname/10k

            Goals goals = new Goals(SessionProvider.CurrentSession);
            Sports sports = new Sports(SessionProvider.CurrentSession);
            var goalList = goals.GetAllBySport(sports.GetByName(name));

            var jsonGoals = BuildJsonGoal(goalList);

            return Json(new {success = jsonGoals}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var goal = new Goals(SessionProvider.CurrentSession).GetById(id);
            var goalViewModelBuilder = new GoalViewModelBuilder();
            GoalViewModel goalViewModel = goalViewModelBuilder.Build(goal);
            return View(goalViewModel);
        }

        [HttpPost]
        public ActionResult Edit_(GoalViewModel viewModelGoal)
        {
            // This would be the manual process, using the update hard coded. 
            // Better use the UpdateModel integrated in the framework!
            UpdateModel(viewModelGoal);
            
            var goals = new Goals(SessionProvider.CurrentSession);
            var currentGoal = goals.GetById(viewModelGoal.Id);
            var goalViewModelBuilder = new GoalViewModelBuilder();
            currentGoal = goalViewModelBuilder.Update(currentGoal, viewModelGoal);
            goals.Update(currentGoal);

            return RedirectToAction("Details", new {Id = currentGoal.Id});
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            var goals = new Goals(SessionProvider.CurrentSession);
            var goal = goals.GetById(id);

            if(TryUpdateModel(goal))
            {
                goals.Update(goal);
                return RedirectToAction("Details", new { Id = goal.Id });
            }
            var goalViewModelBuilder = new GoalViewModelBuilder();

            return View(goalViewModelBuilder.Build(goal));
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formValues)
        {
            // This is following the same way as the edit method, using the UpdateModel or TryUpdateModel
            var goals = new Goals(SessionProvider.CurrentSession);
            var anyGoal = goals.GetAll().First();
            var goal = new Goal()
                           {
                               CreatedOn = DateTime.Now,
                               Venue = anyGoal.Venue,
                               Sport = anyGoal.Sport,
                               UserCreator = anyGoal.UserCreator
                           };


            if (TryUpdateModel(goal))
            {
                goals.Add(goal);
                return RedirectToAction("Details", new { Id = goal.Id });
            }

            var goalViewModelBuilder = new GoalViewModelBuilder();

            return View(goalViewModelBuilder.Build(goal));
        }

        [HttpPost]
        public ActionResult Create_(Goal goal)
        {
            // This method is casting the values from the form and validating the state.
            // However, since there are some fiels as of now that we are still not adding, 
            // the validate state is failing. We have workarounds to add the missing values 
            // and validate the state. The issue is that we wont know anymore if 
            // there was some legit error coming from the site.

            var goals = new Goals(SessionProvider.CurrentSession);
            var anyGoal = goals.GetAll().First();
            goal.CreatedOn = DateTime.Now;
            goal.Venue = anyGoal.Venue;
            goal.Sport = anyGoal.Sport;
            goal.UserCreator = anyGoal.UserCreator;


            ModelState.Where(m => m.Value.Errors != null).ToList().ForEach(e =>
                                                                               {
                                                                                   var error = e.Value.Errors;
                                                                                   error.Clear();
                                                                               });

            UpdateModel(goal);
            if (ModelState.IsValid)
            {
                goals.Add(goal);
                return RedirectToAction("Details", new {Id = goal.Id});
            }

            var goalViewModelBuilder = new GoalViewModelBuilder();

            return View(goalViewModelBuilder.Build(goal));
        }


        public ActionResult Delete(int id)
        {
            var goals = new Goals(SessionProvider.CurrentSession);
            var goal = goals.GetById(id);
            if (goal != null)
            {
                var goalViewModelBuilder = new GoalViewModelBuilder();

                return View(goalViewModelBuilder.Build(goal));
            }

            ViewData["IdNotFound"] = id;
            return View("GoalNotFound");
        }

        [HttpPost]
        public ActionResult Delete(int id, string confirmatonbutton)
        {
            var goals = new Goals(SessionProvider.CurrentSession);
            var goal = goals.GetById(id);


            goals.Remove(goal);
            return RedirectToAction("upcoming");
        }

        public ActionResult Upcoming()
        {
            var goals = new Goals(SessionProvider.CurrentSession);

            var upcomingGoals = goals.FindUpcomingGoals();

            return View(upcomingGoals);
        }

        public ActionResult Next()
        {
            Goals goals = new Goals(SessionProvider.CurrentSession);

            var nextGoal = goals.FindUpcomingGoals().First();

            return View("Details", nextGoal);
        }
        public ActionResult Details(int id)
        {
            Goals goals = new Goals(SessionProvider.CurrentSession);
            Sports sports = new Sports(SessionProvider.CurrentSession);
            var goal = goals.GetById(id);
            if(goal == null)
            {
                return View("NotFound");
            }
            return View(goal);
        }

        public ActionResult Index()
        {
            // http://localhost/endurancegoals/goals
            Goals goals = new Goals(SessionProvider.OpenSession());
            var goalList = goals.GetAll();

            var jsonGoals = BuildJsonGoal(goalList);

            return Json(new { success = jsonGoals }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult index_json()
        {
            // http://localhost/endurancegoals/goals
            Goals goals = new Goals(SessionProvider.OpenSession());
            var goalList = goals.GetAll();

            var jsonGoals = BuildJsonGoal(goalList);

            return Json(new { success = jsonGoals }, JsonRequestBehavior.AllowGet);
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
