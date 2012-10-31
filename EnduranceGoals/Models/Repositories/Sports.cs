using NHibernate;

namespace EnduranceGoals.Models.Repositories
{
    public class Sports : RepositoryWithName<Sport>, ISports
    {
        public Sports(ISession _session)
            : base(_session)
        {
        }

    }
}