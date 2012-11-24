using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;
using EnduranceGoals.Models.ViewModels;

namespace EnduranceGoals.Controllers
{
    public class MembershipController : Controller
    {
        [Authorize]
        public ActionResult Subscribe(int goalId)
        {
            var goals = new Goals(SessionProvider.CurrentSession);

            var goal = goals.GetById(goalId);

            var users = new Users(SessionProvider.CurrentSession);

            var user = users.GetByUserName(User.Identity.Name);

            goal.Participants.Add(new GoalParticipant()
                                      {
                                          Goal = goal,
                                          User = user,
                                          SignedOnDate = DateTime.Now
                                      });

            return View("MembershipWidget", new MembershipManagementViewModel(true, goalId));
        }

        [Authorize]
        public ActionResult Unsubscribe(int goalId)
        {
            var goals = new Goals(SessionProvider.CurrentSession);

            var goal = goals.GetById(goalId);

            var goalParticipant = goal.Participants.Single(s => s.User.Username == User.Identity.Name);

            goal.Participants.Remove(goalParticipant);

            return View("MembershipWidget", new MembershipManagementViewModel(false, goalId));
        }

        [Authorize]
        [ChildActionOnly]
        public ActionResult SubscriptionStatus(int goalId)
        {
            var goals = new Goals(SessionProvider.CurrentSession);
            var users = new Users(SessionProvider.CurrentSession);

            var goal = goals.GetById(goalId);
            var user = users.GetByUserName(User.Identity.Name);

            if(goal.IsParticipant(user.Username))
            {
                return View("MembershipWidget", new MembershipManagementViewModel(true, goalId));
            }
            return View("MembershipWidget", new MembershipManagementViewModel(false, goalId));
        }
    }
}
