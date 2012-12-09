using System;
using System.Collections.Generic;
using System.Linq;
using EnduranceGoals.Models;

namespace EnduranceGoals.Controllers
{
    static internal class JsonBuilder
    {
        public static IEnumerable<object> BuildJsonGoal(IEnumerable<Goal> goalList)
        {
            return goalList.Select(goal => new
                {
                    Name = goal.Name,
                    Location = String.Format("{0}, {1} - {2}", goal.Venue, goal.Venue.City,
                                             goal.Venue.City.Country),
                    Participants = goal.Participants.Count
                }).Cast<object>();
        }

        public static IEnumerable<object> BuildJsonExtendedGoal(IEnumerable<Goal> goalList)
        {
            return goalList.Select(goal => new
            {
                Id = goal.Id,
                //Name = goal.Name,
                //Sport = goal.Sport,
                //Date = String.Format("{0:D}: ", goal.Date),
                //Location = String.Format("{0}, {1} - {2}", goal.Venue, goal.Venue.City,
                //                         goal.Venue.City.Country),
                //Participants = goal.Participants.Select(p => p.User.Username)
            }).Cast<object>();
        }
    }
}