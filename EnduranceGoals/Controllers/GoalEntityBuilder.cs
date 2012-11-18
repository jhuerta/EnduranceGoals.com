using System;
using System.Linq;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models;
using EnduranceGoals.Models.Repositories;
using EnduranceGoals.Models.ViewModels;

namespace EnduranceGoals.Controllers
{
    public class GoalEntityBuilder
    {
        public Goal OutOfGoalViewModel(GoalViewModel goalViewModel, string username)
        {
            Sports sports = new Sports(SessionProvider.CurrentSession);
            Venues venues = new Venues(SessionProvider.CurrentSession);
            Goals goals = new Goals(SessionProvider.CurrentSession);
            Users users = new Users(SessionProvider.CurrentSession);

            Goal goal;
            if(goalViewModel.Id == 0)
            {
                goal = new Goal();
                goal.CreatedOn = DateTime.Now;
                goal.UserCreator = users.GetByUserName(username);
            }
            else
            {
                goal = goals.GetById(goalViewModel.Id);
            }
            
            goal.Name = goalViewModel.Name;
            goal.Date = goalViewModel.Date;
            goal.Description = goalViewModel.Description;

            goal.Web = goalViewModel.Web;
            goal.Venue = venues.GetById(Convert.ToInt32(goalViewModel.VenueId));
            goal.Sport = sports.GetById(Convert.ToInt32(goalViewModel.SportId));

            return goal;
        }

        private User GetRandomUser(Users users)
        {
            var qry = users.GetAll();

            int count = qry.Count();
            int index = new Random().Next(count);

            return qry.Skip(index).FirstOrDefault();
        }
    }
}