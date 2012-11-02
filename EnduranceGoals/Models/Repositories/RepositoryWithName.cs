using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Util;

namespace EnduranceGoals.Models.Repositories
{
    public class RepositoryWithName<Entity> : Repository<Entity>, IRepositoryWithName<Entity> where Entity : class
    {
        public RepositoryWithName(ISession _session): base(_session)
        {
        }

        public Entity GetByName(string entityName)
        {
            var criteria = session.CreateCriteria<Entity>().Add(Restrictions.Eq("Name", entityName));
            return GetByCriteria(criteria).First();
        }
    }
}