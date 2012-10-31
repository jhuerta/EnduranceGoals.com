using NHibernate;
using NHibernate.Criterion;

namespace EnduranceGoals.Models.Repositories
{
    public class RepositoryWithName<Entity> : Repository<Entity>, IRepositoryWithName<Entity> where Entity : class
    {
        public RepositoryWithName(ISession _session)
            : base(_session)
        {
        }

        public Entity GetByName(string entityName)
        {
            return session.CreateCriteria<Entity>()
                .Add(Restrictions.Eq("Name", entityName))
                .UniqueResult<Entity>();
        }
    }
}