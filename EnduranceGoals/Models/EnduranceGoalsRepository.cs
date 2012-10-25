using System;
using System.Data.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnduranceGoals.Models
{
    
    public class EnduranceGoalsRepository
    {
        private EnduranceGoalsEntities entities = new EnduranceGoalsEntities();
        public IQueryable<Goals>  FindAllGoals()
        {
            return entities.Goals
                .Include("Sports")
                .Include("Venues")
                .Include("Users");
        }

        public IQueryable<Goals> FindUpcomingGoals()
        {
            return entities.Goals
                .Include("Sports")
                .Include("Venues")
                .Include("Users")
                .Where(g => g.Date > DateTime.Now).OrderBy(g => g.Date);
        }

        public Goals GetGoal(int id)
        {
            return entities.Goals
                .Include("Sports")
                .Include("Venues")
                .Include("Users").
                First(g => g.Id == id);
        }

        public void AddGoal(Goals goal)
        {
            entities.AddToGoals(goal);
        }

        public void DeleteGoal(Goals goal)
        {
            foreach (var goalsParticipant in entities.GoalParticipants)
            {
                entities.DeleteObject(goalsParticipant);
            }
            entities.DeleteObject(goal);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}
