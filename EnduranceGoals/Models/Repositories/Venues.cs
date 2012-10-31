using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace EnduranceGoals.Models.Repositories
{
    public class Venues : RepositoryWithName<Venue>, IVenueRepository
    {
        public Venues(ISession _session)
            : base(_session)
        {
        }

        public IList<Venue> GetAllByCity(City city)
        {
            return session.CreateCriteria<Venue>()
                .Add(Restrictions.Eq("City", city)).List<Venue>();
        }
    }
}