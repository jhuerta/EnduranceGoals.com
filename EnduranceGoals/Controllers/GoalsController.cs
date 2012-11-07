using System;
using System.Linq;
using System.Web.Mvc;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;
using GoalViewModel = EnduranceGoals.Models.ViewModels.GoalViewModel;

namespace EnduranceGoals.Controllers
{
    public class GoalsController : Controller
    {
        public ActionResult Index()
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
            var goal = goals.GetById(id);
            if(goal == null)
            {
                return View("NotFound");
            }
            return View(goal);
        }

        public ActionResult Edit(int id)
        {
            var goal = new Goals(SessionProvider.CurrentSession).GetById(id);

            GoalViewModel goalViewModel = AutoMapper.Mapper.Map<Goal, GoalViewModel>(goal);

            return View(goalViewModel);
        }

        [HttpPost]
        public ActionResult Edit(GoalViewModel goalViewModel)
        {
            if (ModelState.IsValid)
            {
                var goalEntityBuilder = new GoalEntityBuilder();

                var goal = goalEntityBuilder.OutOfGoalViewModel(goalViewModel);

                var goals = new Goals(SessionProvider.CurrentSession);

                goals.Update(goal);

                return RedirectToAction("Details", new { Id = goalViewModel.Id });
            }

            return View(goalViewModel);
        }

        public ActionResult Create()
        {
            GoalViewModel goalViewModel = AutoMapper.Mapper.Map<Goal, GoalViewModel>(new Goal());

            return View(goalViewModel);
        }

        [HttpPost]
        public ActionResult Create(GoalViewModel goalViewModel)
        {
            if (ModelState.IsValid)
            {
                var goalEntityBuilder = new GoalEntityBuilder();

                var goal = goalEntityBuilder.OutOfGoalViewModel(goalViewModel);

                var goals = new Goals(SessionProvider.CurrentSession);

                goals.Add(goal);

                return RedirectToAction("Details", new { Id = goal.Id });
            }

            return View(goalViewModel);
        }

        public ActionResult Delete(int id)
        {
            var goals = new Goals(SessionProvider.CurrentSession);
            var goal = goals.GetById(id);
            if (goal != null)
            {
                GoalViewModel goalViewModel = AutoMapper.Mapper.Map<Goal, GoalViewModel>(goal);

                return View(goalViewModel);
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
            return RedirectToAction("index");
        }
    }
}
