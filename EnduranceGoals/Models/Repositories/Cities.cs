using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace EnduranceGoals.Models.Repositories
{
    public class Cities : RepositoryWithName<City>, ICityRepository
    {
        public Cities(ISession _session)
            : base(_session)
        {
        }

        public IList<City> GetAllByCountry(Country country)
        {
            return session.CreateCriteria<City>()
                .Add(Restrictions.Eq("Country", country)).List<City>();
        }
    }
}