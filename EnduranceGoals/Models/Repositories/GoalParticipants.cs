using NHibernate;

namespace EnduranceGoals.Models.Repositories
{
    public class GoalParticipants : Repository<GoalParticipant>, IGoalParticipantsRepository
    {
        public GoalParticipants(ISession _session)
            : base(_session)
        {
        }
    }
}