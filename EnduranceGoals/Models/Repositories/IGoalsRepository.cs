using System.Collections.Generic;

namespace EnduranceGoals.Models.Repositories
{
    internal interface IGoalsRepository
    {
        IList<Goal> GetAllBySport(Sport id);
        IList<Goal> GetAllByUserCreator(User user);
        IList<Goal> GetAllByParticipant(User participant);
        IList<Goal> GetAllByCreator(User creator);
    }
}