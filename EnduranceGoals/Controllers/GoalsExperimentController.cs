using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;
using EnduranceGoals.Models.ViewModels;
using FluentNHibernate.Automapping;
using GoalViewModel = EnduranceGoals.Models.ViewModels.GoalViewModel;

namespace EnduranceGoals.Controllers
{
    public class GoalsExperimentController : Controller
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

        [HttpPost]
        public ActionResult Edit_(Goal viewModelGoal)
        {
            // This would be the manual process, using the update hard coded. 
            // Better use the UpdateModel integrated in the framework!
            UpdateModel(viewModelGoal);

            var goals = new Goals(SessionProvider.CurrentSession);
            var currentGoal = goals.GetById(viewModelGoal.Id);

            currentGoal.Description = viewModelGoal.Description;
            currentGoal.Name = viewModelGoal.Name;
            currentGoal.Web = viewModelGoal.Web;

            goals.Update(currentGoal);

            return RedirectToAction("Details", new { Id = currentGoal.Id });
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
                return RedirectToAction("Details", new { Id = goal.Id });
            }

            GoalViewModel goalViewModel = AutoMapper.Mapper.Map<Goal, GoalViewModel>(goal);

            return View(goalViewModel);
        }

        public ActionResult index_json()
        {
            // http://localhost/endurancegoals/goals
            Goals goals = new Goals(SessionProvider.OpenSession());
            var goalList = goals.GetAll();

            var jsonGoals = JsonBuilder.BuildJsonGoal(goalList);

            return Json(new { success = jsonGoals }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JsonSport([Bind(Prefix = "id")] string name)
        {
            Goals goals = new Goals(SessionProvider.CurrentSession);
            Sports sports = new Sports(SessionProvider.CurrentSession);
            var goalList = goals.GetAllBySport(sports.GetByName(name));

            var jsonGoals = JsonBuilder.BuildJsonGoal(goalList);

            return Json(new { success = jsonGoals }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JsonList()
        {
            Goals goals = new Goals(SessionProvider.OpenSession());
            var goalList = goals.GetAll();

            var jsonGoals = JsonBuilder.BuildJsonGoal(goalList);

            return Json(new { success = jsonGoals }, JsonRequestBehavior.AllowGet);
        }
    }
}