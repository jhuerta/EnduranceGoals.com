using System.Collections.Generic;

namespace EnduranceGoals.Models.Repositories
{
    public interface ICityRepository
    {
        IList<City> GetAllByCountry(Country country);
    }
}