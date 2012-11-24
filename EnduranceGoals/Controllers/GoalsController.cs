using System;
using System.Collections.Generic;
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


        
        public ActionResult Index(int? page)
        {
            var goals = new Goals(SessionProvider.CurrentSession);


            int pageNumber = page ?? 0;

            int pageSize = 10;

            var upcomingGoals = goals.FindUpcomingGoals();

            var listOfUpcomingGoals = AutoMapper.Mapper.Map<IEnumerable<Goal>, IEnumerable<GoalViewModel>>(upcomingGoals);


            return View(new PaginatedList<GoalViewModel>(listOfUpcomingGoals, pageNumber, pageSize));
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
            if (goal == null)
            {
                return View("NotFound");
            }
            GoalViewModel goalViewModel = AutoMapper.Mapper.Map<Goal, GoalViewModel>(goal);

            return View(goalViewModel);
        }


        public ActionResult Edit(int id)
        {
            var goal = new Goals(SessionProvider.CurrentSession).GetById(id);

            GoalViewModel goalViewModel = AutoMapper.Mapper.Map<Goal, GoalViewModel>(goal);

            if(!goal.IsOwner(User.Identity.Name))
            {
                return View("YouAreNotTheOwner", goalViewModel);
            }

            return View(goalViewModel);
        }

        [HttpPost]
        public ActionResult Edit(GoalViewModel goalViewModel)
        {
            var goals = new Goals(SessionProvider.CurrentSession);

            return AddOrUpdate(goalViewModel, goals.Update, "Edit");
        }

        [Authorize]
        public ActionResult Create()
        {
            GoalViewModel goalViewModel = AutoMapper.Mapper.Map<Goal, GoalViewModel>(new Goal());

            return View(goalViewModel);
        }

        [HttpPost]
        public ActionResult Create(GoalViewModel goalViewModel)
        {
            var goals = new Goals(SessionProvider.CurrentSession);

            
            return AddOrUpdate(goalViewModel, goals.Add, "Create");
        }

        public ActionResult Delete(int id)
        {
            var goals = new Goals(SessionProvider.CurrentSession);
            var goal = goals.GetById(id);

            if (goal != null)
            {
                GoalViewModel goalViewModel = AutoMapper.Mapper.Map<Goal, GoalViewModel>(goal);

                if (!goal.IsOwner(User.Identity.Name))
                {
                    return View("YouAreNotTheOwner", goalViewModel);
                }

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

            if (!goal.IsOwner(User.Identity.Name))
            {
                return View("YouAreNotTheOwner", new GoalViewModel(){Id = id});
            }

            goals.Remove(goal);

            return RedirectToAction("index");
        }

        private delegate Goal Action(Goal entity);

        private ActionResult AddOrUpdate(GoalViewModel goalViewModel, Action AddOrEdit, string viewName)
        {
            var users = new Users(SessionProvider.CurrentSession);
            if (ModelState.IsValid)
            {
                var goalEntityBuilder = new GoalEntityBuilder();

                var goal = goalEntityBuilder.OutOfGoalViewModel(goalViewModel, User.Identity.Name);

                AddOrEdit(goal);

                return RedirectToAction("Details", new { Id = goal.Id });
            }

            return View(viewName, GoalViewModelById(goalViewModel.Id));
        }

        private static GoalViewModel GoalViewModelById(int goalViewModelId)
        {
            var originalGoal = goalViewModelId == 0 ? new Goal() : new Goals(SessionProvider.CurrentSession).GetById(goalViewModelId);

            return AutoMapper.Mapper.Map<Goal, GoalViewModel>(originalGoal);
        }


    }
}
