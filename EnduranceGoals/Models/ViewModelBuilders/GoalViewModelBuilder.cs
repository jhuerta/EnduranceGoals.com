using System;
using EnduranceGoals.Models;
using EnduranceGoals.Models.ViewModels;

namespace EnduranceGoals.Controllers.ViewModelBuilders
{
    public class GoalViewModelBuilder
    {
        public GoalViewModel Build(Goal goal)
        {
            return new GoalViewModel()
                       {
                           CreatedOn = goal.CreatedOn,
                           Description = goal.Description,
                           Id = goal.Id,
                           Name = goal.Name,
                           Web = goal.Web
                       };
        }

        public Goal Update(Goal to, GoalViewModel from)
        {
            to.Description = from.Description;
            to.Name = from.Name;
            to.Web = from.Web;

            return to;
        }
    }
}