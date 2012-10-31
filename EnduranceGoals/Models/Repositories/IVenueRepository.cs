using System.Collections.Generic;

namespace EnduranceGoals.Models.Repositories
{
    public interface IVenueRepository
    {
        IList<Venue> GetAllByCity(City city);
    }
}