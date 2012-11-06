﻿using System;
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
            var sports = new Sports(SessionProvider.CurrentSession);

            var sportsList = sports.GetAll().ToList();

            ViewData["Sports"] = new SelectList(sportsList, goal.Sport);

            GoalViewModel goalViewModel = AutoMapper.Mapper.Map<Goal, GoalViewModel>(goal);

            return View(goalViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            var goals = new Goals(SessionProvider.CurrentSession);
            var sports = new Sports(SessionProvider.CurrentSession);
            var venues = new Venues(SessionProvider.CurrentSession);
            var goalViewModel = new GoalViewModel();

            var onlyUpdateThisFields = new[] {"Id","Name", "Web", "Description", "SportName", "VenueId"};

            if (TryUpdateModel(goalViewModel, onlyUpdateThisFields))
            {
                var goal = goals.GetById(goalViewModel.Id);

                goal.Name = goalViewModel.Name;
                goal.Web = goalViewModel.Web;
                goal.Description = goalViewModel.Description;
                goal.Sport = sports.GetByName(goalViewModel.SportName);
                goal.Venue = venues.GetById(Convert.ToInt32(goalViewModel.VenueId));

                goals.Update(goal);

                return RedirectToAction("Details", new { Id = goalViewModel.Id });
            }

            return View(goalViewModel);
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

            GoalViewModel goalViewModel = AutoMapper.Mapper.Map<Goal, GoalViewModel>(goal);

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
