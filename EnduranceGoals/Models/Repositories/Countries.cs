using NHibernate;

namespace EnduranceGoals.Models.Repositories
{
    public class Countries : RepositoryWithName<Country>
    {
        public Countries(ISession _session)
            : base(_session)
        {
        }
    }
}