using System.Data.Objects;
using System.Linq;

namespace EnduranceGoals.Models.Repositories
{
    
    public class EnduranceGoalsRepository
    {
        
        public IQueryable<Goal>  FindAllGoals()
        {
            IQueryable<Goal> newList = new ObjectQuery<Goal>("", new ObjectContext(""));
            return newList;
        }

        public IQueryable<Goal> FindUpcomingGoals()
        {
            IQueryable<Goal> newList = new ObjectQuery<Goal>("",new ObjectContext(""));
            return newList;
        }

        public Goal GetGoal(int id)
        {
            return new Goal();
        }

        public void AddGoal(Goal goal)
        {
            
        }

        public void DeleteGoal(Goal goal)
        {

        }

        public void Save()
        {
            
        }
    }
}
